using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Responses;


namespace gShell.dotNet.Utilities.OAuth2
{
    /// <summary> A collection of OAuthDomain objects that can be serialized to disk for secure storage. </summary>
    [Serializable]
    public class OAuth2Info : ISerializable
    {
        /////<summary> Client credential details for installed and web applications customized for serialization. </summary>
        //[Serializable]
        //public class gClientSecrets
        //{
        //    public string ClientId { get; set; }

        //    public string ClientSecret { get; set; }

        //    public static implicit operator ClientSecrets(gClientSecrets secrets)
        //    {
        //        if (secrets == null) return null;

        //        return new ClientSecrets()
        //        {
        //            ClientId = secrets.ClientId,
        //            ClientSecret = secrets.ClientSecret
        //        };
        //    }

        //    public static implicit operator gClientSecrets(ClientSecrets secrets)
        //    {
        //        if (secrets == null) return null;

        //        return new gClientSecrets()
        //        {
        //            ClientId = secrets.ClientId,
        //            ClientSecret = secrets.ClientSecret
        //        };
        //    }
        //}

        #region Properties

        /// <summary> Increment this number any time you happen to change anything in these files. </summary>
        private int fileVersion = 3;

        /// <summary> The overall default domain in gShell. </summary>
        public string defaultDomain { get; set; }

        //private string _defaultDomain;

        /// <summary> A collection of domains that have at least one authenticated user. </summary>
        public Dictionary<string, OAuth2Domain> domains { get; set; }

        /// <summary> Gets or sets the default client secrets. </summary>
        public ClientSecrets defaultClientSecrets { get; set; }

        #endregion

        #region Constructors
        public OAuth2Info()
        {
            domains = new Dictionary<string, OAuth2Domain>();
        }

        #endregion

        #region Serialization
        //this constructs the class from serialized data
        public OAuth2Info(SerializationInfo info, StreamingContext ctxt)
        {
            try
            {
                if (((int)info.GetValue("fileVersion", typeof(int))) < fileVersion)
                {
                    throw new System.InvalidOperationException(
                        "Authentication file is an old version and needs to be recreated.");
                }
            }
            catch
            {
                throw new System.InvalidOperationException(
                        "Authentication file is an old version and needs to be recreated.");
            }


            domains = (Dictionary<string, OAuth2Domain>)info.GetValue("domains",
                typeof(Dictionary<string, OAuth2Domain>));
            defaultDomain = (string)info.GetValue("defaultDomain", typeof(string));
            object ClientSecretsObject = info.GetValue("clientSecrets", typeof(Object));
            if (ClientSecretsObject != null)
            {
                defaultClientSecrets = (ClientSecrets)info.GetValue("clientSecrets", typeof(ClientSecrets));
            }

        }

        //This serializes the data
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("fileVersion", fileVersion, typeof(int));
            info.AddValue("domains", domains, typeof(Dictionary<string, OAuth2Domain>));
            info.AddValue("defaultDomain", defaultDomain, typeof(string));
            info.AddValue("clientSecrets", defaultClientSecrets, typeof(ClientSecrets));
        }
        #endregion

    }

    /// <summary> A collection of <OAuth2DomainUser/> objects, and a reference to the default account for the domain. </summary>
    [Serializable]
    public class OAuth2Domain
    {
        #region Properties

        /// <summary> The default username for this domain. </summary>
        public string defaultUser { get; set; }

        /// <summary>The domain this object represents.</summary>
        public string domain { get; set; }

        /// <summary> A collection of users keyed by their email username. </summary>
        public Dictionary<string, OAuth2DomainUser> users { get; set; }

        /// <summary> The email address of the service account for this domain. </summary>
        public string serviceAccountEmail { get; set; }

        /// <summary> The stored cert for the service account. </summary>
        public X509Certificate2 serviceAccountCertificate { get; set; }

        /// <summary> The stored byte array for the service account. </summary>
        public byte[] certificateByteArray { get; set; }

        #endregion

        #region Constructors
        public OAuth2Domain()
        {
            users = new Dictionary<string, OAuth2DomainUser>();
            certificateByteArray = new byte[0];
        }

        //public OAuth2Domain(string userEmail, string storedToken, HashSet<string> scopes) : this()
        //{
        //    _defaultEmail = userEmail;
        //    users.Add(userEmail, new OAuth2DomainUser(userEmail));
        //}
        #endregion

        #region Serialization
        //this constructs the class from serialized data
        public OAuth2Domain(SerializationInfo info, StreamingContext ctxt)
        {
            users = (Dictionary<string, OAuth2DomainUser>)info.GetValue("users",
                typeof(Dictionary<string, OAuth2DomainUser>));

            defaultUser = (string)info.GetValue("defaultUser", typeof(string));
            domain = (string)info.GetValue("domain", typeof(string));
            serviceAccountEmail = (string)info.GetValue("serviceAccountEmail", typeof(string));

            //It's possible this is not declared, so check to see if it's empty or not.
            if (serviceAccountEmail != "temp")
            {
                certificateByteArray = (byte[])info.GetValue("certificateByteArray", typeof(byte[]));
                serviceAccountCertificate = new X509Certificate2();
                serviceAccountCertificate.Import(certificateByteArray, "notasecret", X509KeyStorageFlags.Exportable);
            }
            else
            {
                certificateByteArray = new byte[0];
                serviceAccountEmail = string.Empty;
            }
        }

        //This serializes the data
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("users", users, typeof(Dictionary<string, OAuth2DomainUser>));
            info.AddValue("defaultUser", defaultUser, typeof(string));
            info.AddValue("domain", domain, typeof(string));

            if (string.IsNullOrWhiteSpace(serviceAccountEmail))
            {
                info.AddValue("serviceAccountEmail", "temp", typeof(string));
            }
            else
            {
                info.AddValue("serviceAccountEmail", serviceAccountEmail, typeof(string));
                info.AddValue("certificateByteArray",
                    serviceAccountCertificate.Export(X509ContentType.Pkcs12, "notasecret"), typeof(byte[]));
            }

        }
        #endregion

    }

    /// <summary>
    /// An [authenticated] user for a single domain. Meant to be stored in an OAuth2Domain object and serialized.
    /// </summary>
    [Serializable]
    public class OAuth2DomainUser
    {
        #region Properties

        /// <summary>The username for the user.</summary>
        public string userName { get; set; }

        /// <summary>The domain this user is from.</summary>
        public string domain { get; set; }

        /// <summary>The email address of this user </summary>
        public string email { get { return Utils.GetFullEmailAddress(userName, domain); } }

        /// <summary>Gets or sets the collection of Api Tokens keyed by their respective Api names. </summary>
        public Dictionary<string, OAuth2TokenInfo> tokenAndScopesByApi { get; set; }

        /// <summary> Gets or sets the client secrets for this user within the domain. </summary>
        public ClientSecrets clientSecrets { get; set; }

        #endregion

        #region Constructors
        public OAuth2DomainUser()
        {
            tokenAndScopesByApi = new Dictionary<string, OAuth2TokenInfo>();
        }

        //public OAuth2DomainUser(string UserEmail)
        //    : this()
        //{
        //    this.email = UserEmail;
        //}
        #endregion

        #region Serialization
        //this constructs the class from serialized data
        public OAuth2DomainUser(SerializationInfo info, StreamingContext ctxt)
        {
            userName = (string)info.GetValue("userName", typeof(string));
            domain = (string)info.GetValue("domain", typeof(string));
            tokenAndScopesByApi = (Dictionary<string, OAuth2TokenInfo>)info.GetValue("tokenAndScopes", typeof(Dictionary<string, OAuth2TokenInfo>));
            clientSecrets = (ClientSecrets)info.GetValue("clientSecrets", typeof(ClientSecrets));
        }

        //This serializes the data
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("userName", userName, typeof(string));
            info.AddValue("domain", domain, typeof(string));
            info.AddValue("tokenAndScopes", tokenAndScopesByApi, typeof(Dictionary<string, OAuth2TokenInfo>));
            info.AddValue("clientSecrets", clientSecrets, typeof(ClientSecrets));
        }
        #endregion

    }

    /// <summary> An object that matches a token with the scopes it represents. </summary>
    [Serializable]
    public class OAuth2TokenInfo
    {
        #region Properties
        public List<string> scopes { get; set; }
        public string tokenString { get; set; }
        public TokenResponse token { get; set; }
        #endregion

        #region Constructors
        public OAuth2TokenInfo() { }

        public OAuth2TokenInfo(IEnumerable<string> scopes, string tokenString, TokenResponse tokenResponse)
        {
            this.scopes = new List<string>(scopes);
            this.tokenString = tokenString;
            this.token = tokenResponse;
        }
        #endregion

        #region Serialization
        //TODO - implement
        #endregion
    }
}
