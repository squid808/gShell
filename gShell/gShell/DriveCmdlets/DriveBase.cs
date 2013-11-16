using System;
using System.Management.Automation;
using System.Collections.Generic;
//using System.Security.Cryptography;
using gShell.OAuth2;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Admin.Directory.directory_v1;
using System.Security.Cryptography.X509Certificates;

namespace gShell.DriveCmdlets
{
    public abstract class DriveBase : OAuth2CmdletBase
    {
        protected static DriveService serviceAccountService;

        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipeline = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The target user to control.")]
        [ValidateNotNullOrEmpty]
        public string User { get; set; }

        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipeline = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The name of the Google Apps domain, ex contoso.com")]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        public DriveBase()
        {
            if (null == driveServiceDict)
            {
                driveServiceDict = new Dictionary<string, Dictionary<string, DriveService>>();
            }

            if (null == directoryServiceDict)
            {
                directoryServiceDict = new Dictionary<string, DirectoryService>();
            }
        }

        protected override void BeginProcessing()
        {
            Domain = Authenticate(Domain);
            User = DetermineUserEmail(User, Domain);
        }

        protected override string BuildService(string givenDomain)
        {
            //first we need to make sure we have the proper domain credentials

            if (string.IsNullOrWhiteSpace(givenDomain) ||
                !userCredentialsDict.ContainsKey(givenDomain))
            {
                ReturnUserCredential(givenDomain, User); //we need the user in case of gmail
            }
            
            if (!driveServiceDict.ContainsKey(currentDomain)) {
                driveServiceDict.Add(currentDomain, new Dictionary<string,DriveService>());
            }

            User = (null == User) ? currentUserInfo.Email : GetFullEmailAddress(User, currentDomain);

            if (!driveServiceDict[currentDomain].ContainsKey(User))
            {
                if (User == currentUserInfo.Email 
                    || User == SavedFile.GetDomainDefaultUser(currentDomain)
                    || currentDomain == "gmail.com")
                {
                    //user was provided, is the current user / default user for the domain OR is a gmail user
                    CreateUserDriveService(currentDomain);
                } else {
                    //user provided is someone in the domain other than the primary user making the calls, so use a service account.
                    CreateServiceAcctDriveService(currentDomain, User);
                }
            }

            return currentDomain;
        }

        /// <summary>
        /// Create a user account-based Drive Service and make this the user's
        /// </summary>
        protected void CreateUserDriveService(string domain) {

            DriveService service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = ReturnUserCredential(domain),
                    ApplicationName = appName,
                });

            driveServiceDict[currentDomain].Add(currentUserInfo.Email, service);

            User = currentUserInfo.Email;
        }

        /// <summary>
        /// Create a service account-based Drive Service and make this the user's
        /// </summary>
        protected void CreateServiceAcctDriveService(string domain, string userEmail)
        {
            if (null == serviceAcctInitializer)
            {
                serviceAcctInitializer =
                    new ServiceAccountCredential.Initializer(SavedFile.GetServiceAccountEmail())
                    {
                        Scopes = serviceAccountScope,
                        User = userEmail
                    }.FromCertificate(SavedFile.GetServiceAccountCert());
                X509Certificate2 cert = SavedFile.GetServiceAccountCert();
            }
            else
            {
                serviceAcctInitializer.User = GetFullEmailAddress(userEmail, domain);
            }

            ServiceAccountCredential credential = new ServiceAccountCredential(serviceAcctInitializer);

            // Create the service.
            serviceAccountService = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = appName,
            });

            driveServiceDict[domain].Add(userEmail, serviceAccountService);
        }

    }
}
