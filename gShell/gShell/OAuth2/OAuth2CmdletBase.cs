using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Drive.v2;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Json;
using Google.Apis.Util;
using Google.Apis.Oauth2.v2;
using Google.Apis.Oauth2.v2.Data;
using Google.Apis.Services;

namespace gShell.OAuth2
{
    /// <summary>
    /// The base from which all gShell cmdlet type classes must derive containing
    /// authentication and setup logic.
    /// </summary>
    public abstract class OAuth2CmdletBase : PSCmdlet, IModuleAssemblyInitializer
    {
        #region Properties
        /// <summary>
        /// A flag to determine if the assemblies have already been resolved.
        /// </summary>
        protected static bool assembliesResolved;

        protected const string appName = "gShellCmdlets";
        protected static ClientSecrets clientSecrets = new ClientSecrets
        {
            ClientId = "431325913325.apps.googleusercontent.com",
            ClientSecret = "VtfqKqUJsY0yNh0hwreAB-S0"
        };

        //SCOPES
        protected static string[] directoryScopes = {
            DirectoryService.Scope.AdminDirectoryUser,
            DirectoryService.Scope.AdminDirectoryUserAlias,
            DirectoryService.Scope.AdminDirectoryUserAlias,
            DirectoryService.Scope.AdminDirectoryOrgunit,
            DirectoryService.Scope.AdminDirectoryGroup,
            DirectoryService.Scope.AdminDirectoryGroupMember,
            DriveService.Scope.Drive,
            DriveService.Scope.DriveFile,
            DriveService.Scope.DriveAppdata,
            DriveService.Scope.DriveScripts,
            Oauth2Service.Scope.UserinfoEmail
        };

        protected static string[] serviceAccountScope = {
            DriveService.Scope.Drive
        };

        protected static string defaultDomain;
        protected static string currentDomain;
        protected static Userinfoplus currentUserInfo;
        protected static UserCredential currentUserCredentials; //the most recent user returned by get user
        protected static ServiceAccountCredential.Initializer serviceAcctInitializer;

        protected static ProgressRecord progressBar;

        protected static Dictionary<string, Userinfoplus> userInfoDict; //a collection of credentials by domain or email address
        protected static Dictionary<string, UserCredential> userCredentialsDict; //a collection of credentials by domain or email address
        protected static Dictionary<string, DirectoryService> directoryServiceDict; //a collection of directory services by domain
        protected static Dictionary<string, Dictionary<string,DriveService>> driveServiceDict; //a collection of drive services by email address

        private static Clock clock = new Clock();
        #endregion

        #region Constructors
        public OAuth2CmdletBase()
        {
            if (null == userCredentialsDict)
            {
                userCredentialsDict = new Dictionary<string, UserCredential>();
            }

            if (null == userInfoDict)
            {
                userInfoDict = new Dictionary<string, Userinfoplus>();
            }
            
            //AuthStatesDict = new Dictionary<string, IAuthorizationState>();
            //packageDict = new Dictionary<string, OAuth2SetupPackage>();
        }
        #endregion

        #region AssemblyResolution
        /// <summary>
        /// Required for the implementation of IModuleAssemblyInitializer - resolves the GAC and machine.config issues
        /// This gets fired for each cmdlet that inherits this base class when importing the module in PoSh
        /// </summary>
        public void OnImport()
        {
            if (!assembliesResolved) { //use the static flag to only fire it once
                AppDomain currentDomain = AppDomain.CurrentDomain;
                currentDomain.AssemblyResolve += new ResolveEventHandler(ResolveSystemPrimitives);
                assembliesResolved = true;
            }
        }

        /// <summary>
        /// Provide the appropriate path to the System.Net.Http.Primitives assembly.
        /// </summary>
        private static Assembly ResolveSystemPrimitives(object sender, ResolveEventArgs args)
        {
            Assembly accurate = Assembly.LoadFrom(System.IO.Path.Combine(AssemblyDirectory, "System.Net.Http.Primitives.dll"));
            return accurate;
        }

        /// <summary>
        /// Provides the location of the executing assembly. Typically %UserProfile%\My Documents\gShell\
        /// http://stackoverflow.com/questions/52797/how-do-i-get-the-path-of-the-assembly-the-code-is-in
        /// </summary>
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return System.IO.Path.GetDirectoryName(path);
            }
        }
        #endregion

        #region AuthenticationAndProcessing
        /// <summary>
        /// A method specific to each inherited object, called during authentication. Must be implemented.
        /// </summary>
        protected abstract string BuildService(string givenDomain);

        /// <summary>
        /// A powershell specific method, called before the cmdlet is run. Must be implemented. 
        /// </summary>
        protected override abstract void BeginProcessing();

        /// <summary>
        /// Called each time a new cmdlet is fired.
        /// </summary>
        protected string Authenticate(string domain)
        {
            //if no domain is provided, check for a current domain in memory
            if (string.IsNullOrWhiteSpace(domain))
            {
                if (!string.IsNullOrWhiteSpace(defaultDomain))
                {
                    //if the current domain exists in memory, set domain to this
                    domain = defaultDomain;
                    currentDomain = defaultDomain;
                }
                else
                {
                    //if no current domain exists in memory, check the file for a current domain
                    if (SavedFile.ContainsDefaultDomain())
                    {
                        //if the file contains a default domain, use this and set it to the current domain
                        domain = SavedFile.GetDefaultDomain();
                        defaultDomain = domain;
                        currentDomain = domain;
                    }
                    else
                    {
                        //no default domains were provided. set all to blanks.
                        defaultDomain = string.Empty;
                        currentDomain = string.Empty;
                    }
                }
            }

            currentDomain = BuildService(domain);
            return currentDomain;
        }

        /// <summary>
        /// Get the Current User's email address.
        /// </summary>
        protected string DetermineUserEmail(string userAccount, string domain)
        {
            if (string.IsNullOrWhiteSpace(userAccount))
            {
                if (null == currentUserInfo || domain != currentUserInfo.Hd)
                {
                    GetCurrentUserInfo(ReturnUserCredential(domain));
                }

                return currentUserInfo.Email;
            }
            else
            {
                return GetFullEmailAddress(userAccount, domain);
            }
        }

        /// <summary>
        /// Process the user email and domain to store and return user credentials.
        /// </summary>
        private UserCredential HandleUserCredentials(string domain, string userEmail = "")
        {
            if (string.IsNullOrWhiteSpace(userEmail))
            {
                OAuth2CmdletBase.AwaitUserCredential(domain).Wait();
            }
            else
            {
                OAuth2CmdletBase.AwaitUserCredential(userEmail).Wait();
            }

            GetCurrentUserInfo(currentUserCredentials);
            string _domain = currentUserInfo.Hd;

            if (null == currentUserInfo.Hd)
            {
                //a gmail address was returned
                _domain = "gmail.com";

                userCredentialsDict[currentUserInfo.Email] = currentUserCredentials;
                userInfoDict[currentUserInfo.Email] = currentUserInfo;
            }
            else
            {
                //a gmail address was not returned, so save it as the domain instead.
                userCredentialsDict[currentUserInfo.Hd] = currentUserCredentials;
                userInfoDict[currentUserInfo.Hd] = currentUserInfo;
            }

            currentDomain = _domain;

            SavedFile.SaveToken(currentUserInfo, MemoryObjectDataStore.tokenTemp);

            if (!SavedFile.ContainsDefaultDomain())
            {
                SavedFile.SetDefaultDomain(currentDomain);
            }

            if (string.IsNullOrWhiteSpace(defaultDomain))
            {
                defaultDomain = SavedFile.GetDefaultDomain();
            }

            return currentUserCredentials;
        }

        /// <summary>
        /// Wrapper to call and store the authentication procedure.
        /// </summary>
        protected UserCredential ReturnUserCredential(string domain, string user="")
        {
            if ("gmail.com" == domain) {
                if (!string.IsNullOrWhiteSpace(user)) {
                    string userEmail = GetFullEmailAddress(user, domain);

                    if (userCredentialsDict.ContainsKey(userEmail)) {
                        currentUserCredentials = userCredentialsDict[userEmail];
                        currentUserInfo = userInfoDict[userEmail];
                        currentDomain = domain;
                        return currentUserCredentials;
                    } else {
                        return HandleUserCredentials(domain, userEmail);
                    }
                } else if (string.IsNullOrWhiteSpace(user)) {
                    //check for a default
                    if (SavedFile.ContainsDomainDefaultUser(domain)) {
                        //load the default user
                        string userEmail = SavedFile.GetDomainDefaultUser(domain);
                        return HandleUserCredentials(domain, userEmail);
                    } else {
                        //treat this as the first user for the gmail domain
                        return HandleUserCredentials(domain);
                    }
                }
            }

            //the domain is not gmail, and is either null or something else
            domain = (string.IsNullOrWhiteSpace(domain)) ? "temp" : domain;

            if (userCredentialsDict.ContainsKey(domain))
            {
                currentUserCredentials = userCredentialsDict[domain];
                currentUserInfo = userInfoDict[domain];
                currentDomain = domain;
                return currentUserCredentials;
            }
            else
            {
                return HandleUserCredentials(domain);
            }
        }

        /// <summary>
        /// Authenticates against the web and stores the result in the credential dictionary.
        /// </summary>
        private static async Task AwaitUserCredential(string key) 
        {
            //only run this if necessary (if currentUserCredentials are not set) - otherwise leave it be;
            if (null == currentUserCredentials ||
                !userCredentialsDict.ContainsKey(key) ||
                currentUserCredentials.Token.IsExpired(clock))
            {
                currentUserCredentials = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    clientSecrets,
                    directoryScopes,
                    key,
                    CancellationToken.None,
                    new MemoryObjectDataStore()
                    );
            }
        }

        /// <summary>
        /// Create a directory service for the provided domain.
        /// </summary>
        protected DirectoryService BuildDirectoryService(string givenDomain)
        {
            DirectoryService service = new DirectoryService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = ReturnUserCredential(givenDomain),
                ApplicationName = appName,
            });

            return service;
        }
        #endregion

        #region ProgressBarMethods

        /// <summary>
        /// Set up the progress bar to display to the user.
        /// </summary>
        /// <param name="activityMessage"></param>
        /// <param name="statusMessage"></param>
        protected void StartProgressBar(string activityMessage,
            string statusMessage = " ")
        {
            if (string.IsNullOrWhiteSpace(statusMessage))
            {
                statusMessage = " ";
            }

            progressBar = new ProgressRecord(1, activityMessage, statusMessage);
            progressBar.PercentComplete = 0;
            progressBar.StatusDescription = "0";
            WriteProgress(progressBar);
        }


        /// <summary>
        /// Update the displayed progress bar. Should first be initialized.
        /// </summary>
        /// <param name="activityMessage"></param>
        /// <param name="currentPercentage"></param>
        /// <param name="maxCount"></param>
        protected void UpdateProgressBar(int currentCount,
            int maxCount, string activityMessage = "", string statusDescription = "")
        {
            if (!string.IsNullOrWhiteSpace(activityMessage))
            {
                progressBar.Activity = activityMessage;
            }

            progressBar.PercentComplete = Convert.ToInt32((
                (double)currentCount / maxCount) * 100);
            if (string.IsNullOrWhiteSpace(statusDescription))
            {
                progressBar.StatusDescription = currentCount + "/" + maxCount;
            }
            else
            {
                progressBar.StatusDescription = statusDescription;
            }
            WriteProgress(progressBar);
        }
        #endregion

        #region HelperMethods
        /// <summary>
        /// If the given username doesn't contain an @ assume it doesn't contain a domain and add it in.
        /// </summary>
        /// <param name="_userName"></param>
        /// <param name="_domain"></param>
        /// <returns></returns>
        protected string GetFullEmailAddress(string _userName, string _domain)
        {
            if (!_userName.Contains("@"))
            {
                _userName += "@" + _domain;
            }

            return _userName;
        }

        public static string GetDomainFromEmail(string userEmail)
        {
            return userEmail.Split('@')[1];
        }

        public static string GetUserFromEmail(string userEmail)
        {
            return userEmail.Split('@')[0];
        }

        /// <summary>
        /// Returns the domain of the user authenticted to the current domain.
        /// Useful to double check the domain name after authenticating.
        /// </summary>
        /// <returns></returns>
        public void GetCurrentUserInfo(UserCredential userCredentials)
        {
            Oauth2Service oService = new Oauth2Service(new BaseClientService.Initializer()
            {
                HttpClientInitializer = userCredentials,
                ApplicationName = appName,
            });

            currentUserInfo = oService.Userinfo.Get().Execute();
        }
        #endregion

        #region Errors

        #endregion
    }

    /// <summary>
    /// Class required to check the expiration of a token. A bit silly if you ask me.
    /// </summary>
    public sealed class Clock : IClock 
    {
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }

        public DateTime UtcNow
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }
}
