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
    public class OAuth2Domain : ISerializable
    {
        [Serializable]
        public enum CertTypeEnum { json, x509}

        #region Properties

        /// <summary> The default username for this domain. </summary>
        public string defaultUser { get; set; }

        /// <summary>The domain this object represents.</summary>
        public string domain { get; set; }

        /// <summary> A collection of users keyed by their email username. </summary>
        public Dictionary<string, OAuth2DomainUser> users { get; set; }

        /// <summary> The email address of the service account for this domain. </summary>
        public string serviceAccountEmail { get; set; }

        /// <summary>The format of the certificate to use, either json or x509 (p12).</summary>
        public CertTypeEnum? certType { get; set; }

        /// <summary> The stored cert for the service account. </summary>
        /// <remarks>This is how a p12/X509 certificate is stored in memory.</remarks>
        public X509Certificate2 p12Certificate { get; set; }

        /// <summary> The stored cert for the service account. </summary>
        /// <remarks>This is how a p12/X509 certificate is stored in memory.</remarks>
        public string jsonCertificate { get; set; }

        /// <summary> The stored byte array for the service account. </summary>
        /// <remarks>This is how the certificate is stored in the serialized file.</remarks>
        public byte[] certificateByteArray { get; set; }

        /// <summary>The key password.</summary>
        public string keyPassword { get; set; }
        #endregion

        #region Constructors
        public OAuth2Domain()
        {
            users = new Dictionary<string, OAuth2DomainUser>();
            certificateByteArray = new byte[0];
        }
        #endregion

        #region Serialization
        //this constructs the class from serialized data
        public OAuth2Domain(SerializationInfo info, StreamingContext ctxt)
        {
            users = (Dictionary<string, OAuth2DomainUser>)info.GetValue("users",
                typeof(Dictionary<string, OAuth2DomainUser>));

            foreach(SerializationEntry entry in info) {
                switch(entry.Name) {
                    case "defaultUser":
                        defaultUser = (string)info.GetValue("defaultUser", typeof(string));
                        break;

                    case "domain":
                        domain = (string)info.GetValue("domain", typeof(string));
                        break;

                    case "certType":
                        certType = (CertTypeEnum)info.GetValue("certType", typeof(CertTypeEnum));

                        if (certType.HasValue)
                        {
                            keyPassword = (string)info.GetValue("keyPassword", typeof(string));
                            serviceAccountEmail = (string)info.GetValue("serviceAccountEmail", typeof(string));

                            if (certType.Value == CertTypeEnum.x509)
                            {
                                certificateByteArray = (byte[])info.GetValue("certificateByteArray", typeof(byte[]));
                                p12Certificate = new X509Certificate2(certificateByteArray, keyPassword, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
                                //p12Certificate.Import(certificateByteArray, keyPassword, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
                                // else certificateByteArray = new byte[0];
                            }
                            else
                            {
                                jsonCertificate = (string)info.GetValue("jsonCertificate", typeof(string));
                            }
                        }
                        break;
                }
            }
        }

        //This serializes the data
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("users", users, typeof(Dictionary<string, OAuth2DomainUser>));
            info.AddValue("defaultUser", defaultUser, typeof(string));
            info.AddValue("domain", domain, typeof(string));

            if (certType.HasValue)
            {
                info.AddValue("certType", certType, typeof(CertTypeEnum));
                info.AddValue("keyPassword", keyPassword, typeof(string));
                info.AddValue("serviceAccountEmail", serviceAccountEmail, typeof(string));

                if (certType.Value == CertTypeEnum.x509)
                {
                    info.AddValue("certificateByteArray",
                        p12Certificate.Export(X509ContentType.Pkcs12, keyPassword), typeof(byte[]));
                }
                else
                {
                    info.AddValue("jsonCertificate", jsonCertificate, typeof(string));
                }
            }
        }
        #endregion

    }

    /// <summary>
    /// An [authenticated] user for a single domain. Meant to be stored in an OAuth2Domain object and serialized.
    /// </summary>
    [Serializable]
    public class OAuth2DomainUser : ISerializable
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
