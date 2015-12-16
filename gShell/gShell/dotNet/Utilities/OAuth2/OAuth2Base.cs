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
    public class OAuth2Base
    {
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

        private static UserCredential asyncUserCredential { get; set; }

        public static AuthenticationInfo currentAuthInfo { get { return _currentAuthInfo; } }
        private static AuthenticationInfo _currentAuthInfo { get; set; }


        //Example call: Authenticate("DirectoryV.3", "myDomain.com", "myUser);

        public static AuthenticationInfo Authenticate(string Api, string Domain = null, string User = null)
        {
            _currentAuthInfo = AuthorizeUser(Api, null, Domain, User);

            return currentAuthInfo;
        }


        /// <summary>Checks the stored info to see if this domain matches or not.</summary>
        public static string CheckDomain(string Domain = null)
        {
            //If null, check for a default but only return it if it exists.
            if (string.IsNullOrWhiteSpace(Domain)) {
                
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

        /// <summary>Authorize the user against Google's servers.</summary>
        public static AuthenticationInfo AuthorizeUser(string Api, IEnumerable<string> scopes, string Domain = null, string User = null)
        {
            //First, if the domain or user are missing, see if we can fill it in using the defaults
            Domain = CheckDomain(Domain);
            if (Domain != null) User = CheckUser(Domain, User);

            //Now let's see if we still have any missing information.
            bool userOrDomainIsNull = User == null || Domain == null;

            //First, if we are able to load a key based on the domain and user, we do that and add it to the data store.
            // This will make sure that when we authenticate, the Google Flow has something to load.
            if (!userOrDomainIsNull)
            {
                OAuth2TokenInfo tokenInfo = infoConsumer.GetTokenInfo(Api, Domain, User);
                memoryObjectDataStore.SetToken(tokenInfo.token);
            }

            //Populate asyncUserCredential either from the data store or from the web via authorization.
            AwaitUserCredential(scopes).Wait();

            //Load the token from the temp data store
            string token = memoryObjectDataStore.GetToken();

            //At this point we assume the authentication worked and we should have a token. So, make sure we have the 
            // proper domain and user if we didn't already so that we can save it.
            if (userOrDomainIsNull)
            {
                using (Oauth2Service oService = new Oauth2Service(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = asyncUserCredential,
                    ApplicationName = _appName + "." + Api,
                }))
                {
                    Userinfoplus userInfoPlus = oService.Userinfo.Get().Execute();
                    User = Utils.GetUserFromEmail(userInfoPlus.Email);
                    Domain = userInfoPlus.Hd;
                }
            }

            //Now for sure we have the user and domain, as well as the token, so we can save it.
            infoConsumer.SaveToken(Api, Domain, User, token, scopes.ToList());

            return new AuthenticationInfo(User, Domain);
        }

        private static async Task AwaitUserCredential(IEnumerable<string> scopes)
        {
            asyncUserCredential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                infoConsumer.GetClientSecrets(),
                scopes,
                "UseTempKeysSetterInstead",
                System.Threading.CancellationToken.None,
                memoryObjectDataStore
            );
        }

        /// <summary>
        /// Returns an initializer used to create a new service.
        /// </summary>
        public static BaseClientService.Initializer GetInitializer(string domain)
        {
            gInitializer initializer = new gInitializer()
            {
                HttpClientInitializer = asyncUserCredential,
                ApplicationName = _appName,
            };

            return initializer;
        }

        /// <summary>
        /// Returns an initializer used to create a non-authenticated service.
        /// </summary>
        public static BaseClientService.Initializer GetInitializer()
        {
            return (new gInitializer());
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
    }

    public struct AuthenticationInfo
    {
        public AuthenticationInfo(string User, string Domain)
        {
            authenticatedUser = Utils.GetUserFromEmail(User);
            authenticatedDomain = Utils.GetDomainFromEmail(Domain);
        }

        public string authenticatedUser { get; set; }
        public string authenticatedDomain { get; set; }
    }
}
