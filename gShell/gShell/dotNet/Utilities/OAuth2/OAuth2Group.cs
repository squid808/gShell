using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

using Google.Apis.Oauth2.v2.Data;

using gShell.dotNet.Utilities;

namespace gShell.dotNet.Utilities.OAuth2
{
    /// <summary>
    /// A collection of OAuthDomain objects that can be serialized to disk for secure storage.
    /// </summary>
    [Serializable]
    public class OAuth2Group : ISerializable
    {
        #region Properties

        /// <summary>
        /// Increment this number any time you happen to change anything in these files.
        /// </summary>
        public int fileVersion = 2;

        /// <summary>
        /// The overall default domain in gShell.
        /// </summary>
        public string defaultDomain { get { return _defaultDomain; } }

        private string _defaultDomain;

        /// <summary>
        /// A collection of domains that have at least one authenticated user.
        /// </summary>
        public Dictionary<string, OAuth2Domain> domains = new Dictionary<string,OAuth2Domain>();        
        #endregion

        #region Constructors
        public OAuth2Group() { }
        
        public OAuth2Group(Userinfoplus userInfo, string storedToken, HashSet<string> scopes)
        {
            SetUser(userInfo, storedToken, scopes);
        }

        public OAuth2Group(string userEmail, string storedToken, HashSet<string> scopes)
        {
            SetUser(userEmail, storedToken, scopes);
        }
        #endregion

        #region Serialization
        //this constructs the class from serialized data
        public OAuth2Group(SerializationInfo info, StreamingContext ctxt)
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
            _defaultDomain = (string)info.GetValue("defaultDomain", typeof(string));

            
        }

        //This serializes the data
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("fileVersion", fileVersion, typeof(int));

            info.AddValue("domains", domains, typeof(Dictionary<string, OAuth2Domain>));
            info.AddValue("defaultDomain", defaultDomain, typeof(string));
        }
        #endregion

        #region Accessors

        #region Domains
        /// <summary>
        /// Returns a list of the domains stored, names only.
        /// </summary>
        public ICollection<string> GetDomains()
        {
            return domains.Keys;
        }

        /// <summary>
        /// Is a domain stored.
        /// </summary>
        public bool ContainsDomain(string domain)
        {
            return (domains.ContainsKey(domain));
        }

        /// <summary>
        /// Return the default domain stored.
        /// </summary>
        public string GetDefaultDomain()
        {
            return defaultDomain;
        }

        /// <summary>
        /// Set or update the default domain stored.
        /// </summary>
        public void SetDefaultDomain(string domain)
        {
            _defaultDomain = domain;
        }

        /// <summary>
        /// Return a domain. Assumes the domain exists.
        /// </summary>
        public OAuth2Domain GetDomain(string domain)
        {
            try
            {
                return domains[domain];
            }
            catch
            {
                throw new System.InvalidOperationException(
                    "No Oauth domain settings exist for " + domain);
            }
        }

        //SetDomain - there is no point in setting a domain, since the only reason to do that would be to set a default user, a new user, or a service account.

        /// <summary>
        /// Removes a domain, if it is stored.
        /// </summary>
        public void RemoveDomain(string domain)
        {
            if (domains.ContainsKey(domain))
            {
                domains.Remove(domain);
            }
        }

        #endregion

        #region Users
        
        /// <summary>
        /// Get all users stored in a domain.
        /// </summary>
        public ICollection<string> GetUsers(string domain)
        {
            return domains[domain].GetUsers();
        }

        /// <summary>
        /// Get all users stored in all domains.
        /// </summary>
        /// <returns></returns>
        public ICollection<string> GetUsers()
        {
            List<string> users = new List<string>();

            foreach (string key in domains.Keys)
            {
                users.AddRange(domains[key].GetUsers());
            }

            return users;
        }

        /// <summary>
        /// Is a user stored. Domain is implied by the email.
        /// </summary>
        public bool ContainsUser(string userEmail)
        {
            string domain = Utils.GetDomainFromEmail(userEmail);
            if (domains.ContainsKey(domain))
            {
                return domains[domain].ContainsUser(userEmail);
            }
            else
            {
                return false; //the entire domain isn't here.
            }
        }

        /// <summary>
        /// Returns the default user for a domain. Assumes it exists.
        /// </summary>
        public string GetDefaultUser(string domain)
        {
            try
            {
                return domains[domain].defaultEmail;
            }
            catch
            {
                throw new System.InvalidOperationException(
                    "No Oauth domain settings exist for " + domain);
            }
        }

        /// <summary>
        /// Set or update the default user stored for a domain.
        /// </summary>
        public void SetDefaultUser(Userinfoplus userInfo)
        {
            SetDefaultUser(userInfo.Email);
        }

        /// <summary>
        /// Set or update the default user stored for a domain.
        /// </summary>
        public void SetDefaultUser(string userEmail)
        {
            string domain = Utils.GetDomainFromEmail(userEmail);

            if (!domains.ContainsKey(domain))
            {
                domains.Add(domain, new OAuth2Domain());
            }
            domains[domain].SetDefaultUser(userEmail);
        }

        /// <summary>
        /// Returns a stored user. Assumes it exists.
        /// </summary>
        public OAuth2DomainUser GetUser(Userinfoplus userInfo)
        {
            return GetUser(userInfo.Email);
        }

        /// <summary>
        /// Returns a stored user. Assumes it exists.
        /// </summary>
        public OAuth2DomainUser GetUser(string userEmail)
        {
            string domain = Utils.GetDomainFromEmail(userEmail);

            try {
                return domains[domain].GetUser(userEmail);
            } catch {
                throw new System.InvalidOperationException(
                    "No Oauth domain settings exist for " + domain);
            }
        }

        /// <summary>
        /// Set or update a stored user.
        /// </summary>
        public void SetUser(Userinfoplus userInfo, string storedToken, HashSet<string> scopes)
        {
            SetUser(userInfo.Email, storedToken, scopes);
        }

        /// <summary>
        /// Set or update a stored user.
        /// </summary>
        public void SetUser(string userEmail, string storedToken, HashSet<string> scopes)
        {
            string domain = Utils.GetDomainFromEmail(userEmail);

            if (defaultDomain == null)
            {
               _defaultDomain = domain;
            }

            if (!domains.ContainsKey(domain))
            {
                domains.Add(domain, new OAuth2Domain(userEmail, storedToken, scopes));
            }
            else
            {
                domains[domain].SetUser(userEmail, storedToken, scopes);
            }
        }

        /// <summary>
        /// Removes a stored user, if it exists.
        /// </summary>
        public void RemoveUser(Userinfoplus userInfo)
        {
            RemoveUser(userInfo.Email);
        }

        /// <summary>
        /// Removes a stored user, if it exists.
        /// </summary>
        public void RemoveUser(string userEmail)
        {
            string domain = Utils.GetDomainFromEmail(userEmail);

            if (domains[domain].RemoveUser(userEmail) == 0)
            {
                domains.Remove(domain);
            };

            
        }

        public HashSet<string> GetScope(Userinfoplus userInfo)
        {
            return GetScope(userInfo.Email);
        }

        public HashSet<string> GetScope(string userEmail)
        {
            OAuth2DomainUser user = GetUser(userEmail);

            return user.scopes;
        }

        #endregion

        #region Service Accounts
        //not yet implemented for the second time...
        #endregion

        public void ClearAll()
        {
            domains = new Dictionary<string, OAuth2Domain>();
            _defaultDomain = string.Empty;
        }
        #endregion

    }

    /// <summary>
    /// A collection of <OAuth2DomainUser/> objects, and a reference to the default account for the domain.
    /// </summary>
    [Serializable]
    public class OAuth2Domain
    {
        #region Properties
        /// <summary>
        /// The default user's email for this domain.
        /// </summary>
        public string defaultEmail{ get {return _defaultEmail; }}

        private string _defaultEmail;

        /// <summary>
        /// A collection of users keyed by their email address.
        /// </summary>
        public Dictionary<string, OAuth2DomainUser> users = new Dictionary<string,OAuth2DomainUser>();

        /// <summary>
        /// The email address of the service account for this domain.
        /// </summary>
        public string serviceAccountEmail;

        /// <summary>
        /// The stored cert for the service account.
        /// </summary>
        public X509Certificate2 serviceAccountCertificate;

        /// <summary>
        /// The stored byte array for the service account.
        /// </summary>
        public byte[] certificateByteArray = new byte[0];
        #endregion

        #region Constructors
        public OAuth2Domain() { }

        public OAuth2Domain(Userinfoplus userInfo, string storedToken, HashSet<string> scopes)
        {
            _defaultEmail = userInfo.Email;
            users.Add(userInfo.Email, new OAuth2DomainUser(userInfo, storedToken, scopes));
        }

        public OAuth2Domain(string userEmail, string storedToken, HashSet<string> scopes)
        {
            _defaultEmail = userEmail;
            users.Add(userEmail, new OAuth2DomainUser(userEmail, storedToken, scopes));
        }
        #endregion
        
        #region Serialization
        //this constructs the class from serialized data
		public OAuth2Domain(SerializationInfo info, StreamingContext ctxt)
        {
            users = (Dictionary<string, OAuth2DomainUser>)info.GetValue("users",
                typeof(Dictionary<string, OAuth2DomainUser>));
            _defaultEmail = (string)info.GetValue("defaultEmail", typeof(string));

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
            info.AddValue("defaultEmail", defaultEmail, typeof(string));

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

        #region Accessors
        public bool ContainsUser(string userEmail)
        {
            return (users.ContainsKey(userEmail));
        }

        public ICollection<string> GetUsers()
        {
            return users.Keys;
        }

        public string GetDefaultUser()
        {
            return defaultEmail;
        }

        public void SetDefaultUser(string userEmail)
        {
            _defaultEmail = userEmail;
        }

        public OAuth2DomainUser GetUser(string userEmail)
        {
            if (users.ContainsKey(userEmail))
            {
                return users[userEmail];
            }
            else
            {
                return null;
            }
        }

        public OAuth2DomainUser GetUser(Userinfoplus userInfo)
        {
            return GetUser(userInfo.Email);
        }

        public void SetUser(string userEmail, string storedToken, HashSet<string> scopes)
        {
            users[userEmail] = new OAuth2DomainUser(userEmail, storedToken, scopes);

            //set this as the default user if there isn't one already
            if (_defaultEmail == null)
            {
                _defaultEmail = userEmail;
            }
        }

        public void SetUser(Userinfoplus userInfo, string storedToken, HashSet<string> scopes)
        {
            SetUser(userInfo.Email, storedToken, scopes);
        }

        public void GetServiceAccount()
        {

        }

        public void SetServiceAccount(string emailAddress, string filePath){
            serviceAccountCertificate =
                new X509Certificate2(filePath, "notasecret", X509KeyStorageFlags.Exportable);

            serviceAccountEmail = emailAddress;
        }

        /// <summary>
        /// Returns the number of users remaining
        /// </summary>
        public int RemoveUser(Userinfoplus userInfo)
        {
           return RemoveUser(userInfo.Email);
        }

        /// <summary>
        /// Returns the number of users remaining
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public int RemoveUser(string userEmail)
        {
            if (users.ContainsKey(userEmail))
            {
                users.Remove(userEmail);
            }

            return users.Count;
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
        /// <summary>
        /// The email address of this user
        /// </summary>
        public string email;

        /// <summary>
        /// The domain this user is from, derived from the domain.
        /// </summary>
        public string domain
        {
            get
            {
                return Utils.GetDomainFromEmail(email);
            }
        }

        /// <summary>
        /// The token stored for this user, used to authenticate.
        /// </summary>
        public string storedToken;

        /// <summary>
        /// A list of scopes for which this user is authenticated.
        /// </summary>
        public HashSet<string> scopes;
        #endregion

        #region Constructors
        public OAuth2DomainUser() { }

        public OAuth2DomainUser(string userEmail, string storedToken, HashSet<string> scopes)
        {
            this.email = userEmail;
            this.storedToken = storedToken;
            this.scopes = scopes;
        }

        public OAuth2DomainUser(Userinfoplus userInfo, string storedToken, HashSet<string> scopes)
        {
            this.email = userInfo.Email;
            this.storedToken = storedToken;
            this.scopes = scopes;
        }
        #endregion

        #region Serialization
        //this constructs the class from serialized data
        public OAuth2DomainUser(SerializationInfo info, StreamingContext ctxt)
        {
            email = (string)info.GetValue("email", typeof(string));
            storedToken = (string)info.GetValue("storedToken", typeof(string));
            scopes = (HashSet<string>)info.GetValue("scopes", typeof(HashSet<string>));
        }

        //This serializes the data
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("email", email, typeof(string));
            info.AddValue("storedToken", storedToken, typeof(string));
            info.AddValue("scopes", scopes, typeof(HashSet<string>));
        }
        #endregion
    }
}
