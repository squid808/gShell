using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Responses;
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

        public static AuthenticatedUserInfo currentAuthInfo { get { return _currentAuthInfo; } }
        private static AuthenticatedUserInfo _currentAuthInfo { get; set; }

        public static bool IsAuthenticating { get { return _IsAuthenticating; } }
        private static bool _IsAuthenticating { get; set; }

        /// <summary>A memory swap placeholder for the token when in the middle of authenticating only.</summary>
        public static TokenResponse AuthTokenTempSwap { get; set; }

        #endregion

        #region Authentication and Authorization

        //Example call: Authenticate("DirectoryV.3", "myDomain.com", "myUser);

        public static AuthenticatedUserInfo Authenticate(string Api, IEnumerable<string> Scopes, ClientSecrets Secrets,
            string Domain = null, string User = null)
        {
            _currentAuthInfo = GetAuthTokenFlow(Api, Scopes, Secrets, Domain, User);

            return currentAuthInfo;
        }

        /// <summary>Retrieve an authentication token from memory or from user authentication.</summary>
        /// <remarks>Also fills out the OAuth2Base currentAuthInfo and asyncUserCredential members.</remarks>
        public static AuthenticatedUserInfo GetAuthTokenFlow(string Api, IEnumerable<string> Scopes, ClientSecrets Secrets,
            string Domain = null, string UserName = null)
        {
            //reset the auth info
            _currentAuthInfo = new AuthenticatedUserInfo() { scopes = Scopes, apiNameAndVersion = Api };

            //First, if the domain or user are missing, see if we can fill it in using the defaults
            Domain = CheckDomain(Domain);
            if (Domain != null) UserName = CheckUser(Domain, UserName);

            //First, if we are able to load a key based on the domain and user, we do that and add it to the data store.
            // This will make sure that when we authenticate, the Google Flow has something to load.
            if (UserName != null && Domain != null && infoConsumer.TokenAndScopesExist(Domain, UserName, Api))
            {
                OAuth2TokenInfo preTokenInfo = infoConsumer.GetTokenInfo(Api, Domain, UserName);
                
                _currentAuthInfo.tokenResponse = preTokenInfo.token;
                _currentAuthInfo.tokenString = preTokenInfo.tokenString;
                _currentAuthInfo.scopes = preTokenInfo.scopes; //overwrite any coming in with what is saved
            }

            //Set the domain and user now, and we'll check them again later while we authorize.
            _currentAuthInfo.domain = Domain;
            _currentAuthInfo.userName = UserName;

            _IsAuthenticating = true;

            //Populate asyncUserCredential, but we don't quite save the token yet...
            AwaitUserCredential(Scopes, Secrets).Wait();

            _IsAuthenticating = false;

            //Now that we have asyncUserCredential filled out, we can actually save the token if we need to.
            memoryObjectDataStore.StoreAsync<TokenResponse>(string.Empty, AuthTokenTempSwap).Wait();

            //The scopes, domain, user and api have already been set above. the token is set while saving.
            return currentAuthInfo;
        }

        /// <summary>
        /// Pulls the authenticated user's information from Google and uses that to update OAuth2Base.currentAuthInfo.
        /// </summary>
        /// <remarks>Requires that Authentication has taken place and filled out asyncUserCredential first.</remarks>
        public static void SetAuthenticatedUserInfo()
        {
            using (Oauth2Service oService = new Oauth2Service(new BaseClientService.Initializer()
            {
                HttpClientInitializer = asyncUserCredential,
                ApplicationName = _appName,
            }))
            {
                Userinfoplus userInfoPlus = oService.Userinfo.Get().Execute();
                _currentAuthInfo.userName = Utils.GetUserFromEmail(userInfoPlus.Email);
                _currentAuthInfo.domain = userInfoPlus.Hd;
            }
        }

        /// <summary>
        /// Saves the token using information from OAuth2Base.currentAuthInfo.
        /// </summary>
        /// <remarks>Requires that authorization has occurred and currentAuthInfo has been filled out.</remarks>
        public static void SaveToken(string TokenString, TokenResponse TokenResponse)
        {
            //Only save if we need to write or overwrite the token, so compare the token coming in with the one in memory.
            if (!string.IsNullOrWhiteSpace(TokenString) && TokenString != currentAuthInfo.tokenString)
            {
                if (infoConsumer.GetDefaultDomain() == null)
                {
                    infoConsumer.SetDefaultDomain(currentAuthInfo.domain);
                }

                if (infoConsumer.GetDefaultUser(currentAuthInfo.domain) == null)
                {
                    infoConsumer.SetDefaultUser(currentAuthInfo.domain, currentAuthInfo.userName);
                }

                infoConsumer.SaveToken(currentAuthInfo.apiNameAndVersion, currentAuthInfo.domain, currentAuthInfo.userName,
                TokenString, TokenResponse, currentAuthInfo.scopes.ToList());
            }
            

            /* 1 - get the token from the caller (string and object)
             * 
             * 2 - test if the domain and user exist
             *     - if not, get them with Oauth call
             *     
             * 3 - store it.
             * 
             * 
             * things that need to be stored by Oauth2Base:
             * Domain
             * User
             * Scopes
             * APi
             * 
             * provided by caller MODS:
             * token(s)
             * 
             * for authentication, scopes should always be provided (but only NEED to be provided when authenticating)
             * 
             * 1.a - check for pretoken. if exists, sideload it in to the MODS and make note to do OAuth call after
             * 
             * 1.b - if we have the token and the scopes, and pull the scopes out as normal for use
             * 
             * 2.a- call Await() - if the token exists, it pulls the information in to the awaitusercredentials. if not, it authenticates to do the same.
             * 
             * 2.b - if we didn't have a pretoken, call for the oAuth info to get the domain and user to save.
             * 
             * 2.c - if we authenticated, using domain, user, api, token(s) and scopes, save the token
             * 
             * 3.a - if we didn't authenticate, we have let Await...() build the credentials for us.
             * 
             * 4. cache the relevent scopes and other information in to OAuth2Base
             * 
             * 5. clear the token info from MODS (we now have it in memory on OA2B
             * 
             * end result: needs to have the information loaded in to OAuth2Base.asyncUserCredential (the result of AwaitUserCredential)
             * 
             * before service: 
             * 
             * the scope, api, token, user and domain should all be set
             * 
             * if the service needs to refresh the token it will call MODS.Store() with the token in string form
             * 
             * using this we can deserialize it to the object, and then with the info in OA2B we can store it.
             * */
        }

        /// <summary>
        /// Combines the _appName with the api name and version, and replaces ':' with '.'
        /// </summary>
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

        /// <summary>Checks the stored info to see if this domain matches any stored domains.</summary>
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

    /// <summary>
    /// Contains all information that results from authenticating a user and gathering a token, and everything
    /// that might be required to store a token. Does not store the token itself for uses other than comparison.
    /// </summary>
    public class AuthenticatedUserInfo
    {
        public AuthenticatedUserInfo() { }

        public AuthenticatedUserInfo(string User, string UserDomain, string Api, IEnumerable<string> Scopes)
        {
            userName = Utils.GetUserFromEmail(User);
            domain = Utils.GetDomainFromEmail(UserDomain);
            apiNameAndVersion = Api;
            scopes = Scopes;
        }

        public string userName { get; set; }
        public string domain { get; set; }
        public string userEmail
        {
            get
            {
                return Utils.GetFullEmailAddress(userName, domain);
            }
        }
        public string apiNameAndVersion { get; set; }
        public IEnumerable<string> scopes { get; set; }
        public string tokenString { get; set; }
        public TokenResponse tokenResponse { get; set; }
    }
}
