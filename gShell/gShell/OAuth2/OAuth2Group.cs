using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace gShell.OAuth2
{
    [Serializable]
    public class OAuth2Group : ISerializable
    {
        public string defaultDomain;

        private Dictionary<string, OAuth2Info> domains;

        public OAuth2Group(OAuth2Info info)
        {
            domains = new Dictionary<string, OAuth2Info>();
            domains.Add(info.domain, info);
            //set the default domain if it's the first domain
            defaultDomain = info.domain;
        }

        //this constructs the class from serialized data
        public OAuth2Group(SerializationInfo info, StreamingContext ctxt)
        {
            domains = (Dictionary<string, OAuth2Info>)info.GetValue("domains", 
                typeof(Dictionary<string, OAuth2Info>));
            defaultDomain = (string)info.GetValue("defaultDomain", typeof(string));
        }

        //This serializes the data
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("domains", domains, typeof(Dictionary<string, OAuth2Info>));
            info.AddValue("defaultDomain", defaultDomain, typeof(string));
        }

        public void Add(OAuth2Info info)
        {
            if (domains.ContainsKey(info.domain))
            {
                domains[info.domain] = info;
            }
            else
            {
                domains.Add(info.domain, info);
            }
        }

        public void Update(OAuth2Info info)
        {
            Add(info);
        }

        /// <summary>
        /// This should only be called if it is verified to exist, first.
        /// </summary>
        public OAuth2Info Load(string domainName)
        {
            try
            {
                return (domains[domainName]);
            }
            catch
            {
                throw new System.InvalidOperationException(
                    "No Oauth domain settings exist for " + domainName);
            }
        }

        public bool Contains(string domainName)
        {
            if (domains.ContainsKey(domainName))
            {
                return true;
            }
            else
            {
                return (false);
            }
        }

        public override string ToString()
        {
            return domains.Keys.ToString();
        }

        public void Remove(string domainName)
        {
            domains.Remove(domainName);
        }

    }
}
