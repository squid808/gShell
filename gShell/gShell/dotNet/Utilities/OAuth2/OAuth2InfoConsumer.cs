using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

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

        public static gShellSettings settings
        {
            get
            {
                if (_settings == null)
                    _settings = gShellSettingsLoader.Load();

                return _settings;
            }
        }

        private static gShellSettings _settings { get; set; }

        public static string dataStoreLocation
        {
            get { return settings.AuthInfoPath; }
        }

        /// <summary>The data store responsible for saving and loading the OAuth2 information.</summary>
        private IOAuth2DataStore dataStore { get { return _dataStore; } }
        private readonly IOAuth2DataStore _dataStore;

        /// <summary>An in-memory copy of the stored OAuth2 information.</summary>
        private OAuth2Info info;

        #endregion

        #region Constructors

        public OAuth2InfoConsumer()
        {
            if (settings.SerializeType == gShellSettings.SerializeTypes.Json)
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

        /// <summary>Create the consumer using a custom DataStore.</summary>
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

        #region Domains

        /// <summary>Get a domain.</summary>
        public OAuth2Domain GetDomain(string Domain)
        {
            if (DomainExists(Domain))
            {
                return info.domains[Domain];
            }
            else
            {
                return null;
            }
        }

        /// <summary>Return all Domains.</summary>
        public IEnumerable<OAuth2Domain> GetAllDomains()
        {
            return info.domains.Values;
        }

        /// <summary>Sets the domain.</summary>
        public void SetDomain(OAuth2Domain Domain)
        {
            if (Domain != null && !string.IsNullOrWhiteSpace(Domain.domain))
            {
                info.domains[Domain.domain] = Domain;
            }

            dataStore.SaveInfo(info);
        }

        /// <summary>Check if the domain exists.</summary>
        public bool DomainExists(string Domain)
        {
            return info.domains.ContainsKey(Domain);
        }

        /// <summary>Removes the given domain.</summary>
        public void RemoveDomain(string Domain)
        {
            info.domains.Remove(Domain);

            dataStore.SaveInfo(info);
        }

        /// <summary>Removes all domains.</summary>
        public void RemoveAllDomains()
        {
            info.domains = new Dictionary<string, OAuth2Domain>();

            info.defaultDomain = null;

            dataStore.SaveInfo(info);
        }

        #endregion

        #region DefaultDomain

        /// <summary>Get the default domain.</summary>
        public string GetDefaultDomain()
        {
            return info.defaultDomain;
        }

        /// <summary>Set the default domain.</summary>
        public void SetDefaultDomain(string Domain)
        {
            info.defaultDomain = Domain;
            dataStore.SaveInfo(info);
        }

        /// <summary>Check if the default domain exists.</summary>
        public bool DefaultDomainExists()
        {
            return !string.IsNullOrWhiteSpace(info.defaultDomain);
        }

        /// <summary>Remove the default domain.</summary>
        public void RemoveDefaultDomain()
        {
            info.defaultDomain = string.Empty;
            dataStore.SaveInfo(info);
        }

        #endregion

        #region Users

        /// <summary>Return the domain user for a domain.</summary>
        public OAuth2DomainUser GetUser(string Domain, string UserName)
        {
            if (UserExists(Domain, UserName))
            {
                return info.domains[Domain].users[UserName];
            }
            else
            {
                return null;
            }
        }

        /// <summary>Get all users.</summary>
        /// <param name="Domain">If not included, all users from all domains are returned.</param>
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
                foreach (string userName in info.domains[domain].users.Keys)
                {
                    users.Add(info.domains[domain].users[userName]);
                }
            }

            return users;
        }

        /// <summary>Set the user for a domain.</summary>
        public void SetUser(string Domain, OAuth2DomainUser User)
        {
            if (User != null)
            {
                if (DomainExists(Domain))
                {
                    info.domains[Domain].users[User.userName] = User;
                    dataStore.SaveInfo(info);
                }
                else
                {
                    OAuth2Domain domain = new OAuth2Domain() { domain = Domain };
                    domain.defaultUser = User.userName;
                    domain.users.Add(User.userName, User);
                    SetDomain(domain);

                    if (!DefaultDomainExists())
                    {
                        SetDefaultDomain(Domain);
                    }
                }
            }
        }

        /// <summary>Check if a user exists.</summary>
        public bool UserExists(string Domain, string UserName)
        {
            OAuth2Domain domain = GetDomain(Domain);

            if (domain == null) return false;

            return domain.users.ContainsKey(UserName);
        }

        /// <summary>Remove the given user from the domain.</summary>
        public void RemoveUser(string Domain, string UserName)
        {

            info.domains[Domain].users.Remove(UserName);

            if (info.domains[Domain].defaultUser == UserName)
            {
                info.domains[Domain].defaultUser = null;
            }

            dataStore.SaveInfo(info);
        }

        #endregion

        #region Token and Scope

        /// <summary>Get the token info.</summary>
        public OAuth2TokenInfo GetTokenInfo(string Domain, string UserName, string Api)
        {
            if (TokenAndScopesExist(Domain, UserName, Api))
            {
                return info.domains[Domain].users[UserName].tokenAndScopesByApi[Api];
            }
            else
            {
                return null;
            }
        }

        //TODO: Revise this to call on separate methods that fit with the rest of the consumer.
        /// <summary>Set the token and scope info all at once.</summary>
        public void SetTokenAndScopes(string Domain, string UserName, string Api, string TokenString, Google.Apis.Auth.OAuth2.Responses.TokenResponse TokenResponse, List<string> Scopes)
        {
            if (!UserExists(Domain, UserName))
            {
                SetUser(Domain, new OAuth2DomainUser()
                {
                    userName = UserName,
                    domain = Domain
                });
            }

            info.domains[Domain].users[UserName].tokenAndScopesByApi[Api] = new OAuth2TokenInfo(Scopes, TokenString, TokenResponse);

            dataStore.SaveInfo(info);
        }

        /// <summary>Checks if the token and scopes exist.</summary>
        public bool TokenAndScopesExist(string Domain, string UserName, string Api)
        {
            if (DomainExists(Domain) && UserExists(Domain, UserName))
            {
                return (info.domains[Domain].users[UserName].tokenAndScopesByApi.ContainsKey(Api));
            }
            else
            {
                return false;
            }
        }

        /// <summary>Removes the token and scopes.</summary>
        public void RemoveTokenAndScopes(string Domain, string UserName, string Api)
        {
            if (TokenAndScopesExist(Domain, UserName, Api))
            {
                info.domains[Domain].users[UserName].tokenAndScopesByApi.Remove(Api);
            }

            dataStore.SaveInfo(info);
        }

        #endregion

        #region DefaultUser

        /// <summary>Retrieves the default user for a domain.</summary>
        public string GetDefaultUser(string Domain)
        {
            if (DomainExists(Domain))
            {
                return info.domains[Domain].defaultUser;
            }

            return null;
        }

        /// <summary>Sets the default user for a domain.</summary>
        public void SetDefaultUser(string Domain, string UserName)
        {
            info.domains[Domain].defaultUser = UserName;

            dataStore.SaveInfo(info);
        }

        /// <summary>Checks if the default user exists for a domain.</summary>
        public bool DefaultUserExists(string Domain)
        {
            if (DomainExists(Domain) && !string.IsNullOrWhiteSpace(info.domains[Domain].defaultUser))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>Removes the default user from a domain.</summary>
        public void RemoveDefaultUser(string Domain)
        {
            if (DomainExists(Domain)) {
                info.domains[Domain].defaultUser = string.Empty;
            }
        }

        #endregion

        #region ClientSecrets

        /// <summary>Returns the client secrets for a domain user.</summary>
        public ClientSecrets GetClientSecrets(string Domain, string UserName)
        {
            if (UserExists(Domain, UserName))
            {
                return info.domains[Domain].users[UserName].clientSecrets;
            }
            else
            {
                return null;
            }
        }

        public void SetClientSecrets(string Domain, string UserName, string ClientId, string ClientSecret)
        {
            SetClientSecrets(Domain, UserName, new ClientSecrets() {
                ClientId = ClientId,
                ClientSecret = ClientSecret
            });
        }

        /// <summary>Sets the client secrets for the given domain user.</summary>
        public void SetClientSecrets(string Domain, string UserName, ClientSecrets Secrets)
        {
            if (!UserExists(Domain, UserName))
            {
                OAuth2DomainUser user = new OAuth2DomainUser();
                user.clientSecrets = Secrets;
                //create the domain too
                SetUser(Domain, user);
            }
            else
            {
                info.domains[Domain].users[UserName].clientSecrets = Secrets;

                dataStore.SaveInfo(info);
            }
        }

        /// <summary>Checks for the client secrets for the given domain user.</summary>
        public bool ClientSecretsExist(string Domain, string UserName)
        {
            if (UserExists(Domain, UserName))
            {
                return info.domains[Domain].users[UserName].clientSecrets != null;
            }
            else
            {
                return false;
            }
        }

        /// <summary>Removes the client secrets for the domain user.</summary>
        public void RemoveClientSecrets(string Domain, string UserName)
        {
            if (ClientSecretsExist(Domain, UserName))
            {
                info.domains[Domain].users[UserName].clientSecrets = null;
            }

            dataStore.SaveInfo(info);
        }

        #endregion

        #region DefaultClientSecrets

        /// <summary>Get the default client secrets.</summary>
        public ClientSecrets GetDefaultClientSecrets()
        {
            return info.defaultClientSecrets;
        }

        /// <summary>Set the default client secrets.</summary>
        public void SetDefaultClientSecrets(string ClientId, string ClientSecret)
        {
            SetDefaultClientSecrets(new ClientSecrets()
            {
                ClientId = ClientId,
                ClientSecret = ClientSecret
            });
        }

        /// <summary>Set the default client secrets.</summary>
        public void SetDefaultClientSecrets(ClientSecrets Secrets)
        {
            if (Secrets != null)
            {
                info.defaultClientSecrets = Secrets;
            }

            dataStore.SaveInfo(info);
        }

        /// <summary>Checks if default client secrets exist.</summary>
        public bool DefaultClientSecretsExist()
        {
            return info.defaultClientSecrets != null;
        }

        /// <summary>Removes the default client secrets.</summary>
        public void RemoveDefaultClientSecrets()
        {
            info.defaultClientSecrets = null;

            dataStore.SaveInfo(info);
        }

        #endregion

        #region ServiceAccount

        /// <summary>Retrive a service account for a domain.</summary>
        public ServiceAccount GetServiceAccount(string Domain)
        {
            if (DomainExists(Domain))
            {
                var svcAcct = new ServiceAccount()
                {
                    email = info.domains[Domain].serviceAccountEmail,
                };

                svcAcct.certType = info.domains[Domain].certType.Value;

                if (svcAcct.certType == OAuth2Domain.CertTypeEnum.x509)
                    svcAcct.certificate = info.domains[Domain].p12Certificate;
                else
                    svcAcct.privateKey = info.domains[Domain].jsonCertificate;

                return svcAcct;
            }

            return null;
        }

        /// <summary>Set a service account for a domain using a p12 cert.</summary>
        public void SetServiceAccount(string Domain, string EmailAccount, X509Certificate2 certificate, string keyPassword)
        {
            info.domains[Domain].certType = OAuth2Domain.CertTypeEnum.x509;
            info.domains[Domain].keyPassword = keyPassword;
            info.domains[Domain].serviceAccountEmail = EmailAccount;
            info.domains[Domain].p12Certificate = new X509Certificate2(certificate);
            dataStore.SaveInfo(info);
        }

        /// <summary>Set a service account for a domain using a json cert.</summary>
        public void SetServiceAccount(string Domain, string EmailAccount, string certificate, string keyPassword)
        {
            info.domains[Domain].certType = OAuth2Domain.CertTypeEnum.json;
            info.domains[Domain].keyPassword = keyPassword;
            info.domains[Domain].serviceAccountEmail = EmailAccount;
            info.domains[Domain].jsonCertificate = certificate;
            dataStore.SaveInfo(info);
        }

        /// <summary>Checks if the default user exists for a domain.</summary>
        public bool ServiceAccountExists(string Domain)
        {
            if (DomainExists(Domain) 
                && !string.IsNullOrWhiteSpace(info.domains[Domain].serviceAccountEmail)
                && info.domains[Domain].p12Certificate != null)
            {
                return true;
            }
            
            return false;
        }

        /// <summary>Removes the service account information from a domain.</summary>
        public void RemoveServiceAccount(string Domain)
        {
            info.domains[Domain].serviceAccountEmail = string.Empty;
            info.domains[Domain].p12Certificate = null;
            dataStore.SaveInfo(info);
        }

        #endregion

        #region Settings

        public static void UpdateSettings(gShellSettings settings)
        {
            _settings = settings;
        }

        #endregion

    }
}
