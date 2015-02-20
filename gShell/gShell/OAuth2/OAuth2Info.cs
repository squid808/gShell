using System;
using Google.Apis.Oauth2.v2.Data;

namespace gShell.OAuth2
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
            this.domain = OAuth2Base.GetDomainFromEmail(UserInfo.Email);
            this.storedToken = StoredToken;
        }
    }

    //[Serializable] public class SUserinfo : Userinfo {
    //    //public string Email;
    //    //public string ETag;
    //    //public string FamilyName;
    //    //public string Gender;
    //    //public string Hd;
    //    //public string GivenName;
    //    //public string Id;
    //    //public string Link;
    //    //public string Locale;
    //    //public string Name;
    //    //public string Picture;
    //    //public string Timezone;
    //    //public bool? VerifiedEmail;

    //    public SUserinfo(Userinfo info)
    //    {
    //        this.Email = info.Email;
    //        this.ETag = info.ETag;
    //        this.FamilyName = info.FamilyName;
    //        this.Gender = info.Gender;
    //        this.Hd = info.Hd;
    //        this.GivenName = info.GivenName;
    //        this.Id = info.Id;
    //        this.Link = info.Link;
    //        this.Locale = info.Locale;
    //        this.Name = info.Name;
    //        this.Picture = info.Picture;
    //        this.Timezone = info.Timezone;
    //        this.VerifiedEmail = info.VerifiedEmail;
    //    }
    //}
}
