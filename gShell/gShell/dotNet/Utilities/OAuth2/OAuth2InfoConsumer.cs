using System;
using System.Collections.Generic;

using Google.Apis.Auth.OAuth2;
using gShell.dotNet.Utilities.OAuth2.DataStores;

namespace gShell.dotNet.Utilities.OAuth2
{
    /// <summary>
    /// Maintains a copy of the OAuth2 Info in memory and acts as a mediator for saving and loading information to and 
    /// from the OAuth2 Info.
    /// </summary>
    public class OAuth2InfoConsumer
    {
        #region Properties

        /// <summary>The data store responsible for saving and loading the OAuth2 information.</summary>
        private IOAuth2DataStore dataStore { get { return _dataStore; } }
        private readonly IOAuth2DataStore _dataStore;

        /// <summary>An in-memory copy of the stored OAuth2 information.</summary>
        private OAuth2Info info;

        #endregion

        #region Constructors

        public OAuth2InfoConsumer()
        {
            _dataStore = new OAuth2SerializerDataStore();
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

        public string GetDefaultUser(string Domain)
        {
            //Check for the existance of the domain first
            OAuth2Domain oDomain = GetDomain(Domain);

            //throw null if the domain doesn't exist
            if (oDomain == null) return null;

            return oDomain.defaultUser;
        }

        /// <summary>Returns the DomainUser if both it and the domain exist.</summary>
        public OAuth2DomainUser GetUser(string Domain, string User)
        {
            if (info == null || !info.ContainsUser(Domain, User) || string.IsNullOrWhiteSpace(User)) return null;

            return info.GetUser(User, Domain);
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
        public void SaveToken(string Api, string Domain, string User, string Token, List<string> Scopes)
        {
            info.SetTokenAndScopes(Api, Token, Scopes, User, Domain);
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

        #endregion

        #region Remove
        




        #endregion

        #region Helpers
        /// <summary>Use this to save the info in order to force you to update and save the in-memory info.</summary>
        private void SaveInfo()
        {
            dataStore.SaveInfo(info);
        }
        #endregion

    }
}
