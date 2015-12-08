using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2;
using Google.Apis.Oauth2.v2.Data;
using Google.Apis.Services;

namespace gShell.dotNet.Utilities.OAuth2
{
    public class OAuth2Base
    {
        private const string _appName = "gShellCmdlets";
        public static OAuth2InfoConsumer infoConsumer { get; set; }

        private static MemoryObjectDataStore memoryObjectDataStore {get; set;}

        private static UserCredential asyncUserCredential { get; set; }

        public OAuth2Base()
        {
            infoConsumer = new OAuth2InfoConsumer();
            memoryObjectDataStore = new MemoryObjectDataStore();
        }

        //Example call: Authenticate("DirectoryV.3", "myDomain.com", "myUser);

        public ApiCallBasicInfo Authenticate(string Api, string Domain = null, string User = null)
        {
            ApiCallBasicInfo basicInfo = AuthorizeUser(Api, null, Domain, User);

            return basicInfo;
        }


        /// <summary>Checks the stored info to see if this domain matches or not.</summary>
        private string CheckDomain(string Domain = null)
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
        private string CheckUser(string Domain, string User = null)
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
        public ApiCallBasicInfo AuthorizeUser(string Api, IEnumerable<string> scopes, string Domain = null, string User = null)
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

            return new ApiCallBasicInfo(User, Domain);
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
    }

    public struct ApiCallBasicInfo
    {
        public ApiCallBasicInfo(string User, string Domain)
        {
            authenticatedDomain = Utils.GetUserFromEmail(User);
            authenticatedDomain = Utils.GetDomainFromEmail(Domain);
        }

        public string authenticatedUser { get; set; }
        public string authenticatedDomain { get; set; }
    }
}
