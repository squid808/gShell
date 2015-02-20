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
using Google.Apis.Admin.Reports.reports_v1;
using Google.Apis.Admin.Reports.reports_v1.Data;

using gShell.Serialization;

namespace gShell.OAuth2
{
    public class OAuth2Base
    {
        #region Properties
        /// <summary>
        /// The application name for this project.
        /// </summary>
        public static string appName { get { return _appName; } }
        private const string _appName = "gShellCmdlets";

        /// <summary>
        /// The client secrets for this Google Console project.
        /// </summary>
        public static ClientSecrets clientSecrets { get { return _clientSecrets; } }
        private static ClientSecrets _clientSecrets = new ClientSecrets
        {
            ClientId = "431325913325.apps.googleusercontent.com",
            ClientSecret = "VtfqKqUJsY0yNh0hwreAB-S0"
        };

        /// <summary>
        /// A collection of scopes required for the authentication. All scopes in the toolset are required here.
        /// </summary>
        public static string[] scopes { get { return _scopes; } }
        private static string[] _scopes = {
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
            ReportsService.Scope.AdminReportsAuditReadonly,
            ReportsService.Scope.AdminReportsUsageReadonly,
            Oauth2Service.Scope.UserinfoEmail
        };

        /// <summary>
        /// A collection of scopes for the service accounts.
        /// </summary>
        public static string[] serviceAccountScope { get { return _serviceAccountScope; } }
        private static string[] _serviceAccountScope = {
            DriveService.Scope.Drive
        };

        //Information relevent to most all services

        /// <summary>
        /// The default domain to be used in gShell when no domain is provided.
        /// </summary>
        public static string defaultDomain { get { return _defaultDomain; } }
        private static string _defaultDomain;

        /// <summary>
        /// The current domain being used in gShell. May or may not be the same as the default domain.
        /// </summary>
        public static string currentDomain { get { return _currentDomain; } }
        private static string _currentDomain;

        /// <summary>
        /// The info for the current authenticated user as retrieved from the server.
        /// </summary>
        public static Userinfoplus currentUserInfo { get { return _currentUserInfo; } }
        private static Userinfoplus _currentUserInfo;

        /// <summary>
        /// The credentials for the current authenticated user.
        /// </summary>
        public static UserCredential currentUserCredentials { get { return _currentUserCredentials; } }
        private static UserCredential _currentUserCredentials; //the most recent user returned by get user

        /// <summary>
        /// The initializer specifically for service account-based services. Use GetServiceAccountInitializer() to access.
        /// </summary>
        private static ServiceAccountCredential.Initializer _serviceAcctInitializer;

        /// <summary>
        /// a collection of credentials by domain or email address
        /// </summary>
        public static Dictionary<string, Userinfoplus> userInfoDict { get { return _userInfoDict; } }
        private static Dictionary<string, Userinfoplus> _userInfoDict = 
            new Dictionary<string,Userinfoplus>();

        /// <summary>
        /// A collection of credentials by domain or email address
        /// </summary>
        public static Dictionary<string, UserCredential> userCredentialsDict { get { return _userCredentialsDict; } }
        private static Dictionary<string, UserCredential> _userCredentialsDict =
            new Dictionary<string,UserCredential>();

        //required for authentication
        public static Clock clock { get { return _clock; } }
        private static Clock _clock = new Clock();
        #endregion

        #region Accessors
        /// <summary>
        /// Updates the current domain property.
        /// </summary>
        public static void SetCurrentDomain(string newDomain)
        {
            _currentDomain = newDomain;
        }

        /// <summary>
        /// Updates the default domain property.
        /// </summary>
        public static void SetDefaultDomain(string newDomain)
        {
            _defaultDomain = newDomain;
        }
        #endregion

        #region Authentication & Processing
        /// <summary>
        /// Attempts to resolve a given domain (if any) in to an actual domain, either from the saved file or from what is provided.
        /// </summary>
        public static string DetermineDomain(string domain)
        {
            //if no domain is provided, check for a current domain in memory
            if (string.IsNullOrWhiteSpace(domain))
            {
                if (!string.IsNullOrWhiteSpace(_defaultDomain))
                {
                    //if the current domain exists in memory, set domain to this
                    domain = _defaultDomain;
                    _currentDomain = _defaultDomain;
                }
                else
                {
                    //if no current domain exists in memory, check the file for a current domain
                    if (SavedFile.ContainsDefaultDomain())
                    {
                        //if the file contains a default domain, use this and set it to the current domain
                        domain = SavedFile.GetDefaultDomain();
                        _defaultDomain = domain;
                        _currentDomain = domain;
                    }
                    else
                    {
                        //no default domains were provided. set all to blanks.
                        _defaultDomain = string.Empty;
                        _currentDomain = string.Empty;
                    }
                }
            }

            return domain;
        }

        public static string Authenticate(string domain, Func<string, string> buildServiceMethod)
        {
            domain = DetermineDomain(domain);

            _currentDomain = buildServiceMethod(domain);

            return _currentDomain;
        }

        /// <summary>
        /// Get the Current User's email address.
        /// </summary>
        public static string DetermineUserEmail(string userAccount, string domain)
        {
            if (string.IsNullOrWhiteSpace(userAccount))
            {
                if (null == _currentUserInfo || domain != _currentUserInfo.Hd)
                {
                    GetCurrentUserInfo(ReturnUserCredential(domain));
                }

                return _currentUserInfo.Email;
            }
            else
            {
                return GetFullEmailAddress(userAccount, domain);
            }
        }

        /// <summary>
        /// Process the user email and domain to store and return user credentials.
        /// </summary>
        private static UserCredential HandleUserCredentials(string domain, string userEmail = "")
        {
            if (string.IsNullOrWhiteSpace(userEmail))
            {
                AwaitUserCredential(domain).Wait();
            }
            else
            {
                AwaitUserCredential(userEmail).Wait();
            }

            GetCurrentUserInfo(_currentUserCredentials);
            string _domain = _currentUserInfo.Hd;

            if (null == _currentUserInfo.Hd)
            {
                //a gmail address was returned
                _domain = "gmail.com";

                _userCredentialsDict[_currentUserInfo.Email] = _currentUserCredentials;
                _userInfoDict[_currentUserInfo.Email] = _currentUserInfo;
            }
            else
            {
                //a gmail address was not returned, so save it as the domain instead.
                _userCredentialsDict[_currentUserInfo.Hd] = _currentUserCredentials;
                _userInfoDict[_currentUserInfo.Hd] = _currentUserInfo;
            }

            _currentDomain = _domain;

            SavedFile.SaveToken(_currentUserInfo, MemoryObjectDataStore.tokenTemp);

            if (!SavedFile.ContainsDefaultDomain())
            {
                SavedFile.SetDefaultDomain(_currentDomain);
            }

            if (string.IsNullOrWhiteSpace(_defaultDomain))
            {
                _defaultDomain = SavedFile.GetDefaultDomain();
            }

            return _currentUserCredentials;
        }

        /// <summary>
        /// Wrapper to call and store the authentication procedure.
        /// </summary>
        public static UserCredential ReturnUserCredential(string domain, string user = "")
        {
            if ("gmail.com" == domain)
            {
                if (!string.IsNullOrWhiteSpace(user))
                {
                    string userEmail = GetFullEmailAddress(user, domain);

                    if (_userCredentialsDict.ContainsKey(userEmail))
                    {
                        _currentUserCredentials = _userCredentialsDict[userEmail];
                        _currentUserInfo = _userInfoDict[userEmail];
                        _currentDomain = domain;
                        return _currentUserCredentials;
                    }
                    else
                    {
                        return HandleUserCredentials(domain, userEmail);
                    }
                }
                else if (string.IsNullOrWhiteSpace(user))
                {
                    //check for a default
                    if (SavedFile.ContainsDomainDefaultUser(domain))
                    {
                        //load the default user
                        string userEmail = SavedFile.GetDomainDefaultUser(domain);
                        return HandleUserCredentials(domain, userEmail);
                    }
                    else
                    {
                        //treat this as the first user for the gmail domain
                        return HandleUserCredentials(domain);
                    }
                }
            }

            //the domain is not gmail, and is either null or something else
            domain = (string.IsNullOrWhiteSpace(domain)) ? "temp" : domain;

            if (_userCredentialsDict.ContainsKey(domain))
            {
                _currentUserCredentials = _userCredentialsDict[domain];
                _currentUserInfo = _userInfoDict[domain];
                _currentDomain = domain;
                return _currentUserCredentials;
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
            if (null == _currentUserCredentials ||
                !_userCredentialsDict.ContainsKey(key) ||
                _currentUserCredentials.Token.IsExpired(_clock))
            {
                _currentUserCredentials = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    _clientSecrets,
                    _scopes,
                    key,
                    CancellationToken.None,
                    new MemoryObjectDataStore()
                    );
            }
        }

        /// <summary>
        /// Returns an initializer used to create a new service.
        /// </summary>
        public static BaseClientService.Initializer GetInitializer(string domain)
        {
            gInitializer initializer = new gInitializer()
            {
                HttpClientInitializer = ReturnUserCredential(domain),
                ApplicationName = _appName,
            };

            return initializer;
        }

        public static BaseClientService.Initializer GetInitializer(Google.Apis.Http.IConfigurableHttpClientInitializer credentials)
        {
            gInitializer initializer = new gInitializer()
            {
                HttpClientInitializer = credentials,
                ApplicationName = _appName,
            };

            return initializer;
        }
        #endregion

        #region HelperMethods
        /// <summary>
        /// If the given username doesn't contain an @ assume it doesn't contain a domain and add it in.
        /// </summary>
        /// <returns></returns>
        public static string GetFullEmailAddress(string userName, string domain)
        {
            if (!userName.Contains("@"))
            {
                userName += "@" + domain;
            }

            return userName;
        }

        /// <summary>
        /// Return the domain given a full email address.
        /// </summary>
        public static string GetDomainFromEmail(string userEmail)
        {
            return userEmail.Split('@')[1];
        }

        /// <summary>
        /// Return the username given a full email address.
        /// </summary>
        public static string GetUserFromEmail(string userEmail)
        {
            return userEmail.Split('@')[0];
        }

        /// <summary>
        /// Returns the domain of the user authenticated to the current domain.
        /// Useful to double check the domain name after authenticating, in case they provided one domain but authenticated another.
        /// </summary>
        public static void GetCurrentUserInfo(UserCredential userCredentials)
        {
            Oauth2Service oService = new Oauth2Service(new BaseClientService.Initializer()
            {
                HttpClientInitializer = userCredentials,
                ApplicationName = _appName,
            });

            _currentUserInfo = oService.Userinfo.Get().Execute();
        }

        /// <summary>
        /// Provides a custom Service Account Initializer for the given username and domain.
        /// </summary>
        public static ServiceAccountCredential.Initializer GetServiceAccountInitializer(string userEmail, string domain)
        {
            if (null == _serviceAcctInitializer)
            {
                _serviceAcctInitializer =
                    new ServiceAccountCredential.Initializer(SavedFile.GetServiceAccountEmail())
                    {
                        Scopes = serviceAccountScope,
                        User = userEmail
                    }.FromCertificate(SavedFile.GetServiceAccountCert());
                //X509Certificate2 cert = SavedFile.GetServiceAccountCert();
            }
            else
            {
                _serviceAcctInitializer.User = GetFullEmailAddress(userEmail, domain);
            }

            return _serviceAcctInitializer;
        }
        #endregion
    }

    /// <summary>
    /// The base from which all gShell cmdlet type classes must derive containing
    /// authentication and setup logic.
    /// </summary>
    public abstract class OAuth2CmdletBase : PSCmdlet, IModuleAssemblyInitializer
    {
        #region Properties
        protected static ProgressRecord progressBar;

        
        /// <summary>
        /// A flag to determine if the assemblies have already been resolved.
        /// </summary>
        public static bool assembliesResolved { get { return _assembliesResolved; } }
        private static bool _assembliesResolved;
        #endregion

        #region AssemblyResolution
        /// <summary>
        /// Required for the implementation of IModuleAssemblyInitializer - resolves the GAC and machine.config issues
        /// This gets fired for each cmdlet that inherits this base class when importing the module in PoSh
        /// </summary>
        public void OnImport()
        {
            if (!_assembliesResolved)
            { //use the static flag to only fire it once
                AppDomain currentDomain = AppDomain.CurrentDomain;
                currentDomain.AssemblyResolve += new ResolveEventHandler(ResolveSystemPrimitives);
                _assembliesResolved = true;
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

        #region Constructors
        public OAuth2CmdletBase() { }
        #endregion

        #region Authentication & Processing
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
            return OAuth2Base.Authenticate(domain, BuildService);
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
