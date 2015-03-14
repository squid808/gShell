using System;
using Google.Apis.Oauth2.v2.Data;
using gShell.dotNet.Utilities;

namespace gShell.dotNet.Utilities.OAuth2
{
    [Serializable]
    public class OAuth2Info
    {
        public string email;
        public string domain;
        public string storedToken;

        public OAuth2Info() { }

        public OAuth2Info(Userinfoplus UserInfo, string StoredToken)
        {
            this.email = UserInfo.Email;
            this.domain = Utils.GetDomainFromEmail(UserInfo.Email);
            this.storedToken = StoredToken;
        }
    }
}
