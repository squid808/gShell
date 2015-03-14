//using System;
//using System.Management.Automation;
//using System.Collections.Generic;
////using System.Security.Cryptography;
//using gShell.dotNet.Utilities.OAuth2;
//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Services;
//using Google.Apis.Drive.v2;
//using Google.Apis.Drive.v2.Data;
//using Google.Apis.Admin.Directory.directory_v1;
//using System.Security.Cryptography.X509Certificates;

//namespace gShell.Cmdlets.Drive
//{
//    public abstract class DriveBase : OAuth2CmdletBase
//    {
//        protected static DriveService serviceAccountService;


//        protected static Dictionary<string, Dictionary<string, DriveService>> driveServiceDict
//            = new Dictionary<string,Dictionary<string,DriveService>>(); //a collection of drive services by email address

//        [Parameter(Position = 0,
//            Mandatory = false,
//            ValueFromPipeline = false,
//            ValueFromPipelineByPropertyName = false,
//            HelpMessage = "The target user to control.")]
//        [ValidateNotNullOrEmpty]
//        public string User { get; set; }

//        [Parameter(Position = 1,
//            Mandatory = false,
//            ValueFromPipeline = false,
//            ValueFromPipelineByPropertyName = false,
//            HelpMessage = "The name of the Google Apps domain, ex contoso.com")]
//        [ValidateNotNullOrEmpty]
//        public string Domain { get; set; }

//        public DriveBase()
//        {
//            //if (null == driveServiceDict)
//            //{
//            //    driveServiceDict = new Dictionary<string, Dictionary<string, DriveService>>();
//            //}

//            //if (null == directoryServiceDict)
//            //{
//            //    directoryServiceDict = new Dictionary<string, DirectoryService>();
//            //}
//        }

//        protected override void BeginProcessing()
//        {
//            Domain = Authenticate(Domain);
//            User = OAuth2Base.DetermineUserEmail(User, Domain);
//        }

//        //protected override string BuildService(string givenDomain)
//        //{
//        //    //first we need to make sure we have the proper domain credentials

//        //    if (string.IsNullOrWhiteSpace(givenDomain) ||
//        //        !OAuth2Base.userCredentialsDict.ContainsKey(givenDomain))
//        //    {
//        //        OAuth2Base.ReturnUserCredential(givenDomain, User); //we need the user in case of gmail
//        //    }

//        //    if (!driveServiceDict.ContainsKey(OAuth2Base.currentDomain))
//        //    {
//        //        driveServiceDict.Add(OAuth2Base.currentDomain, new Dictionary<string, DriveService>());
//        //    }

//        //    User = (null == User) ? OAuth2Base.currentUserInfo.Email :
//        //        OAuth2Base.GetFullEmailAddress(User, OAuth2Base.currentDomain);

//        //    if (!driveServiceDict[OAuth2Base.currentDomain].ContainsKey(User))
//        //    {
//        //        if (User == OAuth2Base.currentUserInfo.Email
//        //            || User == SavedFile.GetDomainDefaultUser(OAuth2Base.currentDomain)
//        //            || OAuth2Base.currentDomain == "gmail.com")
//        //        {
//        //            //user was provided, is the current user / default user for the domain OR is a gmail user
//        //            CreateUserDriveService(OAuth2Base.currentDomain);
//        //        } else {
//        //            //user provided is someone in the domain other than the primary user making the calls, so use a service account.
//        //            CreateServiceAcctDriveService(OAuth2Base.currentDomain, User);
//        //        }
//        //    }

//        //    return OAuth2Base.currentDomain;
//        //}

//        /// <summary>
//        /// Create a user account-based Drive Service and make this the user's
//        /// </summary>
//        protected void CreateUserDriveService(string domain) {

//            DriveService service = new DriveService(new BaseClientService.Initializer()
//                {
//                    HttpClientInitializer = OAuth2Base.ReturnUserCredential(domain),
//                    ApplicationName = OAuth2Base.appName,
//                });

//            driveServiceDict[OAuth2Base.currentDomain].Add(OAuth2Base.currentUserInfo.Email, service);

//            User = OAuth2Base.currentUserInfo.Email;
//        }

//        /// <summary>
//        /// Create a service account-based Drive Service and make this the user's
//        /// </summary>
//        protected void CreateServiceAcctDriveService(string domain, string userEmail)
//        {
//            ServiceAccountCredential credential = new ServiceAccountCredential(OAuth2Base.GetServiceAccountInitializer(userEmail, domain));

//            serviceAccountService = new DriveService(OAuth2Base.GetInitializer(credential));

//            driveServiceDict[domain].Add(userEmail, serviceAccountService);
//        }

//    }
//}
