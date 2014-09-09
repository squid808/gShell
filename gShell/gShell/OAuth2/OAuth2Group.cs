using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

using Google.Apis.Oauth2.v2.Data;

namespace gShell.OAuth2
{
    [Serializable]
    public class OAuth2Group : ISerializable
    {
        #region Properties
        public int fileVersion = 1;

        public string defaultDomain;
        public Dictionary<string, string> defaultUsers;
        public Dictionary<string, OAuth2Info> storedInfo;

        public string serviceAccountEmail;
        public X509Certificate2 serviceAccountCertificate;
        public byte[] certificateByteArray;
        #endregion

        #region Constructors
        public OAuth2Group()
        {
            defaultUsers = new Dictionary<string, string>(); //a mapping of domain to email address 
            storedInfo = new Dictionary<string, OAuth2Info>(); //a mapping of email address to oauthinfo
            certificateByteArray = new byte[0];
            //set the default domain if it's the first domain
            //defaultDomain = info.domain; no longer the case - 11-8-13
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
            storedInfo = (Dictionary<string, OAuth2Info>)info.GetValue("storedInfo", 
                typeof(Dictionary<string, OAuth2Info>));
            defaultUsers = (Dictionary<string, string>)info.GetValue("defaultUsers",
                typeof(Dictionary<string, string>));
            defaultDomain = (string)info.GetValue("defaultDomain", typeof(string));

            serviceAccountEmail = (string)info.GetValue("serviceAccountEmail", typeof(string));
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
            info.AddValue("fileVersion", fileVersion, typeof(int));
            info.AddValue("storedInfo", storedInfo, typeof(Dictionary<string, OAuth2Info>));
            info.AddValue("defaultUsers", defaultUsers, typeof(Dictionary<string, string>));
            info.AddValue("defaultDomain", defaultDomain, typeof(string));
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

        public void AddCertificate(string filePath)
        {
            serviceAccountCertificate =
                new X509Certificate2(filePath, "notasecret", X509KeyStorageFlags.Exportable);
        }

        public void AddServiceAccountEmail(string emailAddress)
        {
            serviceAccountEmail = emailAddress;
        }

        public void Add(OAuth2Info info)
        {
            //take care of the main list
            if (storedInfo.ContainsKey(info.email))
            {
                storedInfo[info.email] = info;
            }
            else
            {
                storedInfo.Add(info.email, info);
            }

            string _domain = info.domain;

            //take care of the domain-based list
            if (!defaultUsers.ContainsKey(_domain))
            {
                defaultUsers.Add(_domain, info.email);
            }

            //take care of default domain
            if (string.IsNullOrWhiteSpace(defaultDomain))
            {
                defaultDomain = _domain;
            }
        }

        public void Update(OAuth2Info info)
        {
            Add(info);
        }

        public OAuth2Info Load(string key)
        {
            if (storedInfo.ContainsKey(key))
            {
                return LoadByUser(key);
            }
            else if (defaultUsers.ContainsKey(key))
            {
                return LoadByDomain(key);
            }
            else
            {
                if (key.Contains("@"))
                {
                    return LoadByDomain(key.Split('@')[1]);
                }
                else
                {
                    throw new System.InvalidOperationException(
                    "No Oauth domain settings exist for " + key);
                }
            }
        }

        public OAuth2Info LoadByUser(Userinfoplus userInfo)
        {
            return LoadByUser(userInfo.Email);
        }

        public OAuth2Info LoadByUser(string userEmail)
        {
            try
            {
                return (storedInfo[userEmail]);
            }
            catch
            {
                throw new System.InvalidOperationException(
                    "No Oauth domain settings exist for " + userEmail);
            }
        }

        public OAuth2Info LoadByDomain(string domainName)
        {
            try
            {
                return (storedInfo[defaultUsers[domainName]]);
            }
            catch
            {
                throw new System.InvalidOperationException(
                    "No Oauth domain settings exist for " + domainName);
            }
        }

        public List<string> GetAllDomains()
        {
            List<string> keys = new List<string>();

            HashSet<string> keySet = new HashSet<string>();

            foreach (string key in storedInfo.Keys)
            {
                keySet.Add(OAuth2CmdletBase.GetDomainFromEmail(key));
            }

            keys.AddRange(keySet);

            return keys;
        }

        public bool ContainsUser(string userEmail)
        {
            return (storedInfo.ContainsKey(userEmail));
        }

        public bool ContainsDomain(string domainName)
        {
            return (defaultUsers.ContainsKey(domainName));
        }

        public bool ContainsServiceAccountInfo()
        {
            if (!string.IsNullOrWhiteSpace(serviceAccountEmail) &&
                null != serviceAccountCertificate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return storedInfo.Keys.ToString();
        }

        public void RemoveDomain(string domainName)
        {
            storedInfo.Remove(defaultUsers[domainName]);

            List<string> remainingDomains = GetAllDomains();

            if (remainingDomains.Contains(domainName))
            {
                //a user from this domain yet remains
                foreach (string key in storedInfo.Keys)
                {
                    string _domain = OAuth2CmdletBase.GetDomainFromEmail(key);

                    if (_domain == domainName)
                    {
                        defaultUsers[domainName] = _domain;
                        break;
                    }
                }
            }
            else
            {
                defaultUsers.Remove(domainName);
            }
        }

        public string GetDomainDefaultUser(string domain)
        {
            try
            {
                return (defaultUsers[domain]);
            }
            catch
            {
                throw new System.InvalidOperationException(
                    "No Oauth domain settings exist for " + domain);
            }
        }

        public void ClearAll()
        {
            //storedInfo = new Dictionary<string, OAuth2Info>();
            //defaultUsers = new Dictionary<string, string>();
        }

    }
}
