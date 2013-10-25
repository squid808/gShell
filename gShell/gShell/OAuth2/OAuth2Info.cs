using System;
using DotNetOpenAuth.OAuth2;

namespace gShell.OAuth2
{
    [Serializable]
    public class OAuth2Info
    {
        public string domain { get; set; }
        public IAuthorizationState authState { get; set; }

        public OAuth2Info() { }

        public OAuth2Info(string Domain, IAuthorizationState AuthState)
        {
            this.domain = Domain;
            this.authState = AuthState;
        }
    }
}
