using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2;
using Google.Apis.Oauth2.v2.Data;
using Google.Apis.Services;

using gShell.dotNet.CustomSerializer;
using gShell.dotNet.Utilities.OAuth2;

namespace gShell.dotNet.Utilities.OAuth2
{
    /// <summary>
    /// Responsible for acting as a relay between the info consumer and the API calls; handles the authentication for
    /// any Google API-based services.
    /// </summary>
    /// <remarks>
    /// In this and other files, the flow assumes that before each API call the Authenticate() method is called, which
    /// in turn sets the OAuth2Base.currentAuthInfo, which contains the currently authenticated domain and user (and 
    /// possibly more). Here, the infoConsumer is the relay to the underlying datastore which contains all of the
    /// stored token information.
    /// </remarks>
    public class OAuth2Base
    {
        #region Properties
        private const string _appName = "gShellCmdlets";
        public static OAuth2InfoConsumer infoConsumer
        {
            get
            {
                if (_infoConsumer == null) _infoConsumer = new OAuth2InfoConsumer();
                return _infoConsumer;
            }
        }
        private static OAuth2InfoConsumer _infoConsumer;

        public static MemoryObjectDataStore memoryObjectDataStore
        {
            get
            {
                if (_memoryObjectDataStore == null) _memoryObjectDataStore = new MemoryObjectDataStore();
                return _memoryObjectDataStore;
            }
        }
        private static MemoryObjectDataStore _memoryObjectDataStore;

        public static UserCredential asyncUserCredential { get; set; }

        public static AuthenticationInfo currentAuthInfo { get { return _currentAuthInfo; } }
        private static AuthenticationInfo _currentAuthInfo { get; set; }
    
        #endregion

        #region Authentication and Authorization

        //Example call: Authenticate("DirectoryV.3", "myDomain.com", "myUser);

        public static AuthenticationInfo Authenticate(string Api, IEnumerable<string> Scopes, ClientSecrets Secrets,
            string Domain = null, string User = null)
        {
            _currentAuthInfo = AuthorizeUser(Api, Scopes, Secrets, Domain, User);

            return currentAuthInfo;
        }

        /// <summary>Authorize the user against Google's servers.</summary>
        public static AuthenticationInfo AuthorizeUser(string Api, IEnumerable<string> Scopes, ClientSecrets Secrets,
            string Domain = null, string User = null)
        {

            //First, if the domain or user are missing, see if we can fill it in using the defaults
            Domain = CheckDomain(Domain);
            if (Domain != null) User = CheckUser(Domain, User);

            //Now let's see if we still have any missing information.
            bool userOrDomainIsNull = User == null || Domain == null;

            OAuth2TokenInfo preTokenInfo = null;

            //First, if we are able to load a key based on the domain and user, we do that and add it to the data store.
            // This will make sure that when we authenticate, the Google Flow has something to load.
            if (!userOrDomainIsNull && infoConsumer.TokenAndScopesExist(Domain, User, Api))
            {
                preTokenInfo = infoConsumer.GetTokenInfo(Api, Domain, User);
                memoryObjectDataStore.SetToken(preTokenInfo.tokenString);
            }

            //Populate asyncUserCredential either from the data store or from the web via authorization.
            AwaitUserCredential(Scopes, Secrets).Wait();

            if (preTokenInfo == null || asyncUserCredential.Token.Issued != preTokenInfo.token.Issued ||
                asyncUserCredential.Token.AccessToken != preTokenInfo.token.AccessToken)
            {

                //Load the token from the temp data store
                string tokenString = memoryObjectDataStore.GetToken();

                //At this point we assume the authentication worked and we should have a token. So, make sure we have the 
                // proper domain and user if we didn't already so that we can save it.
                if (userOrDomainIsNull)
                {
                    using (Oauth2Service oService = new Oauth2Service(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = asyncUserCredential,
                        ApplicationName = GetAppName(Api),
                    }))
                    {
                        Userinfoplus userInfoPlus = oService.Userinfo.Get().Execute();
                        User = Utils.GetUserFromEmail(userInfoPlus.Email);
                        Domain = userInfoPlus.Hd;
                    }
                }

                if (infoConsumer.GetDefaultDomain() == null)
                {
                    infoConsumer.SetDefaultDomain(Domain);
                }

                if (infoConsumer.GetDefaultUser(Domain) == null)
                {
                    infoConsumer.SetDefaultUser(Domain, User);
                }

                //Now for sure we have the user and domain, as well as the token, so we can save it.
                infoConsumer.SaveToken(Api, Domain, User, tokenString, asyncUserCredential.Token, Scopes.ToList());
            }

            memoryObjectDataStore.ClearToken();

            return new AuthenticationInfo(User, Domain);
        }

        public static string GetAppName(string ApiNameAndVersion)
        {
            return _appName + "." + ApiNameAndVersion.Replace(':', '.');
        }

        public static async Task AwaitUserCredential(IEnumerable<string> scopes, ClientSecrets clientSecrets)
        {
            asyncUserCredential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                clientSecrets,
                scopes,
                "UseTempKeysSetterInstead",
                System.Threading.CancellationToken.None,
                memoryObjectDataStore
            );
        }

        #endregion

        #region Helpers

        /// <summary>Checks the stored info to see if this domain matches or not.</summary>
        public static string CheckDomain(string Domain = null)
        {
            //If null, check for a default but only return it if it exists.
            if (string.IsNullOrWhiteSpace(Domain))
            {

                string DefaultDomain = infoConsumer.GetDefaultDomain();

                if (string.IsNullOrWhiteSpace(DefaultDomain))
                { return null; }
                else
                { return DefaultDomain; }
            }

            if (infoConsumer.DomainExists(Domain)) return Domain;

            return null;
        }

        /// <summary>Checks the stored info to see if this user matches anything stored or not.</summary>
        public static string CheckUser(string Domain, string User = null)
        {
            //If null, check for a default but only return it if it exists.
            if (string.IsNullOrWhiteSpace(User))
            {
                string DefaultUser = infoConsumer.GetDefaultUser(Domain);

                if (string.IsNullOrWhiteSpace(DefaultUser))
                { return null; }
                else
                { return DefaultUser; }
            }

            if (infoConsumer.UserExists(Domain, User)) return User;

            return null;
        }

        #endregion

        

        #region Accessors

        /// <summary>
        /// Set the Client Id and Secret 
        /// </summary>
        public static void SetClientSecrets(string ClientId, string ClientSecret, string Domain = null, string UserEmail = null)
        {
            ClientSecrets secrets = new ClientSecrets() {
                ClientId = ClientId,
                ClientSecret = ClientSecret
            };

            infoConsumer.SetDefaultClientSecrets(secrets);
        }

        /// <summary>
        /// Returns an initializer used to create a non-authenticated service.
        /// </summary>
        public static BaseClientService.Initializer GetInitializer()
        {
            return (new gInitializer());
        }

        //public static BaseClientService.Initializer GetInitializer(Google.Apis.Http.IConfigurableHttpClientInitializer credentials)
        //{
        //    gInitializer initializer = new gInitializer()
        //    {
        //        HttpClientInitializer = credentials,
        //        ApplicationName = _appName,
        //    };

        //    return initializer;
        //}

        /// <summary>
        /// Returns an initializer used to create a new service.
        /// </summary>
        public static BaseClientService.Initializer GetInitializer(string AppName)
        {
            gInitializer initializer = new gInitializer()
            {
                HttpClientInitializer = asyncUserCredential,
                ApplicationName = AppName,
            };

            return initializer;
        }

        #endregion
    }

    public class AuthenticationInfo
    {
        public AuthenticationInfo(string User, string UserDomain)
        {
            UserName = Utils.GetUserFromEmail(User);
            Domain = Utils.GetDomainFromEmail(UserDomain);
            UserEmail = Utils.GetFullEmailAddress(UserName, Domain);
        }

        public string UserName { get; set; }
        public string Domain { get; set; }
        public string UserEmail { get; set; }
    }
}
