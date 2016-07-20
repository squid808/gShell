using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Oauth2.v2;
using Google.Apis.Oauth2.v2.Data;
using Google.Apis.Services;

using gShell.dotNet.CustomSerializer.Json;
using gShell.dotNet.CustomSerializer.Xml;
using Newtonsoft.Json;

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
            string Domain = null, string UserName = null, bool force = false)
        {
            //reset the auth info
            _currentAuthInfo = new AuthenticatedUserInfo() { scopes = Scopes, apiNameAndVersion = Api };

            //First, if the domain or user are missing, see if we can fill it in using the defaults
            Domain = CheckDomain(Domain);
            if (Domain != null) UserName = CheckUser(Domain, UserName);

            //First, if we are able to load a key based on the domain and user, we do that and add it to the data store.
            // This will make sure that when we authenticate, the Google Flow has something to load.
            if (UserName != null && Domain != null && infoConsumer.TokenAndScopesExist(Domain, UserName, Api) && !force)
            {
                OAuth2TokenInfo preTokenInfo = infoConsumer.GetTokenInfo(Domain, UserName, Api);
                
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

            if (AuthTokenTempSwap != null)
            {
                //Now that we have asyncUserCredential filled out, we can actually save the token if we need to.
                memoryObjectDataStore.StoreAsync<TokenResponse>(string.Empty, AuthTokenTempSwap).Wait();
                AuthTokenTempSwap = null;
            }

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
                //Sets the user and domain first, if they don't already exist
                infoConsumer.SetTokenAndScopes(currentAuthInfo.domain, currentAuthInfo.userName, currentAuthInfo.apiNameAndVersion, TokenString, TokenResponse, currentAuthInfo.scopes.ToList());

                if (infoConsumer.GetDefaultDomain() == null)
                {
                    infoConsumer.SetDefaultDomain(currentAuthInfo.domain);
                }

                if (infoConsumer.GetDefaultUser(currentAuthInfo.domain) == null)
                {
                    infoConsumer.SetDefaultUser(currentAuthInfo.domain, currentAuthInfo.userName);
                }
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

        /// <summary>Set the Client Id and Secret.</summary>
        public static void SetClientSecrets(string ClientId, string ClientSecret, string Domain = null, string UserEmail = null)
        {
            ClientSecrets secrets = new ClientSecrets() {
                ClientId = ClientId,
                ClientSecret = ClientSecret
            };

            infoConsumer.SetDefaultClientSecrets(secrets);
        }

        /// <summary>Set the service account for a domain.</summary>
        public static void SetServiceAccount(string domain, string email, string certificatePath, string keyPassword = "notasecret")
        {
            if (string.IsNullOrWhiteSpace(keyPassword))
                keyPassword = "notasecret";

            if (Path.GetExtension(certificatePath) == ".json")
            {
                using (StreamReader file = File.OpenText(certificatePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    var jsonCert = (JsonKeyModel)serializer.Deserialize(file, typeof(JsonKeyModel));
                    //string certContents = file.ReadToEnd();
                    SetJsonServiceAccount(domain, email, jsonCert.private_key, keyPassword);
                }
            }
            else
            {
                var certificate = new X509Certificate2(certificatePath, keyPassword, X509KeyStorageFlags.Exportable);
                SetX509ServiceAccount(domain, email, certificate, keyPassword);
            }
        }

        /// <summary>Set the service account for a domain with a p12 cert base.</summary>
        public static void SetX509ServiceAccount(string domain, string email, X509Certificate2 certificate, string keyPassword)
        {
            infoConsumer.SetServiceAccount(domain, email, certificate, keyPassword);
        }

        /// <summary>Set the service account for a domain with a json cert base.</summary>
        public static void SetJsonServiceAccount(string domain, string email, string certificate, string keyPassword)
        {
            infoConsumer.SetServiceAccount(domain, email, certificate, keyPassword);
        }

        /// <summary>
        /// Returns an initializer used to create a non-authenticated service.
        /// </summary>
        public static BaseClientService.Initializer GetInitializer()
        {
            return (new gJsonInitializer());
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
        public static BaseClientService.Initializer GetInitializer(string AppName, AuthenticatedUserInfo authInfo, string serviceAccountUser = null)
        {
            //for non admin APIs, we need a service account
            //TODO: add in a default option to allow users to default to the DiscoveryInitializer anyways, if they want
            //if (authInfo.apiNameAndVersion.Contains("gmail")
            //    || authInfo.apiNameAndVersion.Contains("drive"))
            if (string.IsNullOrWhiteSpace(serviceAccountUser))
            {
                return GetDiscoveryInitializer(AppName, authInfo);
            }
            else
            {
                return GetServiceInitializer(AppName, authInfo, serviceAccountUser);
            }
        }

        public static BaseClientService.Initializer GetDiscoveryInitializer(string AppName, AuthenticatedUserInfo authInfo)
        {
            gJsonInitializer initializer = new gJsonInitializer()
            {
                HttpClientInitializer = asyncUserCredential,
                ApplicationName = AppName,
            };

            return initializer;
        }

        /// <summary>
        /// Returns an initializer used to create a new service for GData APIs.
        /// </summary>
        public static BaseClientService.Initializer GetGdataInitializer(string AppName, AuthenticatedUserInfo authInfo)
        {
            gXmlInitializer initializer = new gXmlInitializer()
            {
                HttpClientInitializer = asyncUserCredential,
                ApplicationName = AppName,
                //GZipEnabled = false
            };

            return initializer;
        }


        public static BaseClientService.Initializer GetServiceInitializer(string appName, AuthenticatedUserInfo authInfo, string serviceAccountUser)
        {
            var serviceAccount = infoConsumer.GetServiceAccount(authInfo.domain);

            var scopes = authInfo.scopes;

            if (authInfo.apiNameAndVersion.Contains("gmail"))
            {
                scopes = new string[] { "https://mail.google.com/" };
            }
            else if (authInfo.apiNameAndVersion.Contains("drive"))
            {
                scopes = new string[] { "https://www.googleapis.com/auth/drive" };
            }

            ServiceAccountCredential credential = null;

            if (serviceAccount.certType == OAuth2Domain.CertTypeEnum.json)
            {
                credential = new ServiceAccountCredential(
                    new ServiceAccountCredential.Initializer(serviceAccount.email)
                    {
                        User = serviceAccountUser,
                        Scopes = scopes
                    }.FromPrivateKey(serviceAccount.privateKey));
            }
            else
            {
                credential = new ServiceAccountCredential(
                    new ServiceAccountCredential.Initializer(serviceAccount.email)
                    {
                        User = serviceAccountUser,
                        Scopes = scopes
                    }.FromCertificate(serviceAccount.certificate));
            }

            var init = new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = appName,
            };

            return init;
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
