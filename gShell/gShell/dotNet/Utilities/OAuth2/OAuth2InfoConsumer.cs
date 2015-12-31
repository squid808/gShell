using System;
using System.IO;
using System.Collections.Generic;

using Google.Apis.Auth.OAuth2;
using gShell.dotNet.Utilities.OAuth2.DataStores;
using gShell.dotNet.Utilities.Settings;

namespace gShell.dotNet.Utilities.OAuth2
{
    /// <summary>
    /// Maintains a copy of the OAuth2 Info in memory and acts as a mediator for saving and loading information to and 
    /// from the OAuth2 Info.
    /// </summary>
    public class OAuth2InfoConsumer
    {
        #region Properties

        public gShellSettings settings { get; set; }

        public static string dataStoreLocation { get { return Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData), @"gShell\"); } }

        /// <summary>The data store responsible for saving and loading the OAuth2 information.</summary>
        private IOAuth2DataStore dataStore { get { return _dataStore; } }
        private readonly IOAuth2DataStore _dataStore;

        /// <summary>An in-memory copy of the stored OAuth2 information.</summary>
        private OAuth2Info info;

        #endregion

        #region Constructors

        public OAuth2InfoConsumer()
        {
            settings = gShellSettingsLoader.Load();

            if (settings != null && settings.SerializeType == gShellSettings.SerializeTypes.Json)
            {
                _dataStore = new OAuth2JsonDataStore(dataStoreLocation);
            }
            else
            {
                _dataStore = new OAuth2BinDataStore(dataStoreLocation);
            }

            info = dataStore.LoadInfo();
            if (info == null)
            {
                info = new OAuth2Info();
                dataStore.SaveInfo(info);
            }
        }

        public OAuth2InfoConsumer(IOAuth2DataStore DataStore)
        {
            _dataStore = DataStore;
            info = dataStore.LoadInfo();
            if (info == null)
            {
                info = new OAuth2Info();
                dataStore.SaveInfo(info);
            }
        }

        #endregion

        #region Get

        public ClientSecrets GetClientSecrets()
        {
            if (info == null) return null;

            return info.GetClientSecrets();
        }

        public string GetDefaultDomain()
        {
            if (info == null || string.IsNullOrWhiteSpace(info.defaultDomain)) return null;

            return info.defaultDomain;
        }

        /// <summary>Returns the Domain if it exists.</summary>
        public OAuth2Domain GetDomain(string Domain)
        {
            if (info == null || !info.ContainsDomain(Domain) || string.IsNullOrWhiteSpace(Domain)) return null;

            return info.GetDomain(Domain);
        }

        //TODO: Rename this to just GetDomain but give a bool parameter of 'all' to indicate the choice. not nullable
        /// <summary>Return all Domains.</summary>
        public IEnumerable<OAuth2Domain> GetAllDomains()
        {
            return info.GetAllDomains();
        }

        public string GetDefaultUser(string Domain)
        {
            if (DomainExists(Domain))
            {
                OAuth2Domain oDomain = GetDomain(Domain);
                return oDomain.defaultUser;
            }

            return null;
        }

        /// <summary>Returns the DomainUser if both it and the domain exist, and uses the default user if user is blank.</summary>
        public OAuth2DomainUser GetUser(string Domain, string UserName = null)
        {
            if (UserName == null) { UserName = info.domains[Domain].defaultUser; }

            if (info == null || !info.ContainsUser(Domain, UserName) || string.IsNullOrWhiteSpace(UserName)) return null;

            return info.GetUser(UserName, Domain);
        }

        public IEnumerable<OAuth2DomainUser> GetAllUsers(string Domain = null)
        {
            List<OAuth2DomainUser> users = new List<OAuth2DomainUser>();

            List<string> domains = new List<string>();

            if (Domain != null)
            {
                domains.Add(Domain);
            }
            else
            {
                foreach (var domain in info.domains.Keys)
                {
                    domains.Add(domain);
                }
            }

            foreach (var domain in domains)
            {
                users.AddRange(info.GetUsers(domain));
            }

            return users;
        }

        public OAuth2TokenInfo GetTokenInfo(string Api, string Domain, string User){
            return info.GetTokenAndScopes(Api, Domain, User);
        }

        #endregion

        #region Check

        public bool DomainExists(string Domain)
        {
            if (info == null) return false;

            return info.ContainsDomain(Domain);
        }

        public bool UserExists(string Domain, string User)
        {
            if (info == null) return false;

            return (info.ContainsUser(Domain, User));
        }

        public bool TokenAndScopesExist(string Domain, string User, string Api)
        {
            if (info == null) return false;

            return (info.ContainsTokenAndScopes(Domain, User, Api));
        }

        #endregion

        #region Set

        //NOTE: Any time something changes, you MUST update the in-memory OAuth2Info as well - or update the memory and then save
        public void SaveToken(string Api, string Domain, string User, string TokenString, 
            Google.Apis.Auth.OAuth2.Responses.TokenResponse TokenResponse, List<string> Scopes)
        {
            info.SetTokenAndScopes(Api, TokenString, TokenResponse, Scopes, User, Domain);
            dataStore.SaveInfo(info);
        }

        public void SetDefaultDomain(string Domain)
        {
            info.SetDefaultDomain(Domain);
            dataStore.SaveInfo(info);
        }

        public void SetDefaultUser(string Domain, string UserName)
        {
            info.SetDefaultUser(Domain, UserName);
            dataStore.SaveInfo(info);
        }

        public void SetDefaultClientSecrets(ClientSecrets Secrets)
        {
            info.SetClientSecrets(Secrets);
            dataStore.SaveInfo(info);
        }

        public void AddDomain(string Domain)
        {
            info.AddDomain(Domain);
            dataStore.SaveInfo(info);
        }

        public void AddUser(string Domain, string UserName)
        {
            info.AddDomain(Domain);
            info.AddUser(UserName, Domain);
            dataStore.SaveInfo(info);
        }

        #endregion

        #region Remove

        /// <summary>Removes the given domain and any references to it, if matching.</summary>
        public void RemoveDomain(string Domain)
        {
            info.domains.Remove(Domain);

            if (info.defaultDomain == Domain)
            {
                info.defaultDomain = null;
            }

            dataStore.SaveInfo(info);
        }

        /// <summary>Removes all domains if set to true.</summary>
        public void RemoveDomain(bool removeAll)
        {
            info.domains = new Dictionary<string, OAuth2Domain>();

            info.defaultDomain = null;

            dataStore.SaveInfo(info);
        }

        public void RemoveUser(string Domain, string UserName)
        {

            info.domains[Domain].users.Remove(UserName);

            if (info.domains[Domain].defaultUser == UserName)
            {
                info.domains[Domain].defaultUser = null;
            }

            dataStore.SaveInfo(info);
        }

        /// <summary>Remove the default client secrets unless a domain and username are provided.</summary>
        public void RemoveClientSecrets(string Domain = null, string UserName = null)
        {
            if (Domain == null || UserName == null)
            {
                info.defaultClientSecrets = null;
            }
            else
            {
                info.domains[Domain].users[UserName].clientSecrets = null;
            }

            dataStore.SaveInfo(info);
        }
        #endregion

        ////TODO: Remove reliance on the OAuth2Info accessors (and remove them entirely) by handling all of that from the consumer, using the below setup
        //#region Domains

        ////get
        ///// <summary>Summary.</summary>
        //public void DoThing()
        //{
        
        //}


        ////set
        ///// <summary>Summary.</summary>
        //public void DoThing()
        //{

        //}

        ////check
        ///// <summary>Summary.</summary>
        //public void DoThing()
        //{

        //}

        ////remove
        ///// <summary>Summary.</summary>
        //public void DoThing()
        //{

        //}

        //#endregion

        //#region Users

        ////get


        ////set
        ///// <summary>Summary.</summary>
        //public void DoThing()
        //{

        //}

        ////check
        ///// <summary>Summary.</summary>
        //public void DoThing()
        //{

        //}

        ////remove
        ///// <summary>Summary.</summary>
        //public void DoThing()
        //{

        //}

        //#endregion

        //#region ClientSecrets

        ////get
        ///// <summary>Summary.</summary>
        //public void DoThing()
        //{

        //}

        ////set
        ///// <summary>Summary.</summary>
        //public void DoThing()
        //{

        //}

        ////check
        ///// <summary>Summary.</summary>
        //public void DoThing()
        //{

        //}

        ////remove
        ///// <summary>Summary.</summary>
        //public void DoThing()
        //{

        //}

        //#endregion

        //#region ServiceAccount

        ////get
        ///// <summary>Summary.</summary>
        //public void DoThing()
        //{

        //}

        ////set
        ///// <summary>Summary.</summary>
        //public void DoThing()
        //{

        //}

        ////check
        ///// <summary>Summary.</summary>
        //public void DoThing()
        //{

        //}

        ////remove
        ///// <summary>Summary.</summary>
        //public void DoThing()
        //{

        //}

        //#endregion

    }
}
