using DotNetOpenAuth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Authentication.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;

namespace gShell.OAuth2
{
    /// <summary>
    /// A package containing most everything needed to set up a service.
    /// </summary>
    public class OAuth2SetupPackage
    {
        #region Properties
        public string domain;
        public NativeApplicationClient provider;
        public OAuth2Authenticator<NativeApplicationClient> oAuth2Authenticator;
        public BaseClientService.Initializer initializer;
        public IAuthorizationState authState;

        private const string clientID = "431325913325.apps.googleusercontent.com";
        private const string clientSecret = "VtfqKqUJsY0yNh0hwreAB-S0";
        #endregion

        #region Constructors
        public OAuth2SetupPackage() { }

        public OAuth2SetupPackage(NativeApplicationClient _provider, 
            OAuth2Authenticator<NativeApplicationClient> _oAuth2Authenticator,
            BaseClientService.Initializer _initializer)
        {
            provider = _provider;
            oAuth2Authenticator = _oAuth2Authenticator;
            initializer = _initializer;
        }

        public OAuth2SetupPackage(string _domain, NativeApplicationClient _provider,
            OAuth2Authenticator<NativeApplicationClient> _oAuth2Authenticator, 
            BaseClientService.Initializer _initializer)
        {
            domain = _domain;
            provider = _provider;
            oAuth2Authenticator = _oAuth2Authenticator;
            initializer = _initializer;
        }
        #endregion

        /// <summary>
        /// The delegate required in the constructor of the OAuth2Authenticator, called on the first method execution.
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private IAuthorizationState GetAuthState(NativeApplicationClient arg = null)
        {
            return this.authState;
        }

        /// <summary>
        /// Static method to initialize and return a new package, sans AuthState and Domain.
        /// </summary>
        /// <returns></returns>
        public static OAuth2SetupPackage CreatePackage()
        {
            OAuth2SetupPackage package = new OAuth2SetupPackage();

            NativeApplicationClient _provider = new NativeApplicationClient(GoogleAuthenticationServer.Description)
            {
                ClientIdentifier = clientID,
                ClientSecret = clientSecret,
            };

            OAuth2Authenticator<NativeApplicationClient> _oAuth2Authenticator = 
                new OAuth2Authenticator<NativeApplicationClient>(_provider, package.GetAuthState);

            BaseClientService.Initializer _initializer = new BaseClientService.Initializer()
            {
                Authenticator = _oAuth2Authenticator,
                ApplicationName = "gShell",
                ApiKey = "This is apparently not necessary"
            };

            package.provider = _provider;
            package.oAuth2Authenticator = _oAuth2Authenticator;
            package.initializer = _initializer;

            return package;
        }
    }
}
