using System.Collections.Generic;
using gShell.Main.Utilities;
using Google.Apis.Auth.OAuth2.Responses;

namespace gShell.Main.Auth.OAuth2.v1
{
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

        /// <summary>The username against which the authentication should look.</summary>
        public string userName { get; set; }

        /// <summary>The domain against which the authentication should look.</summary>
        public string domain { get; set; }

        /// <summary>The original domain provided to authenticate against.</summary>
        /// <remarks>This could change if primary domains are being used.</remarks>
        public string originalDomain { get; set; }

        /// <summary>The original username provided to authenticate against.</summary>
        /// <remarks>This could change if primary domains are being used.</remarks>
        public string originalUser { get; set; }

        /// <summary>The api name and version in the appropriate api:version format for google.</summary>
        public string apiNameAndVersion { get; set; }

        /// <summary>The scopes chosen for this particular authentication.</summary>
        public IEnumerable<string> scopes { get; set; }

        /// <summary>The token string.</summary>
        public string tokenString { get; set; }

        /// <summary>The token response.</summary>
        public TokenResponse tokenResponse { get; set; }
    }
}