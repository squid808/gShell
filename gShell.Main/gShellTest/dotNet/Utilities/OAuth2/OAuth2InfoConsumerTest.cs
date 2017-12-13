using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Responses;

using gShell.dotNet.Utilities;
using gShell.dotNet.Utilities.OAuth2;
using gShell.dotNet.Utilities.OAuth2.DataStores;

namespace gShellTest.dotNet.Utilities.OAuth2
{
    [TestFixture]
    public class OAuth2InfoConsumerTest
    {
        private class TestDataStore : IOAuth2DataStore
        {
            public OAuth2Info internalInfo { get; set; }

            public string fileName { get { return ""; } }

            public string destFolder { get; set; }

            public string destFile { get { return ""; } }

            public OAuth2Info LoadInfo()
            {
                return internalInfo;
            }

            public void SaveInfo(OAuth2Info infoToSave)
            {
                internalInfo = infoToSave;
            }
        }

        TestDataStore dataStore { get; set; }
        OAuth2InfoConsumer consumer { get; set; }
        OAuth2Info info { get; set; }

        string domainNameString = "myDomainName";
        string userNameString = "myUserName";
        string apiString = "myApi";
        string tokenStringString = "{\"access_token\":\"ya29\",\"Issued\":\"2016-01-07T16:43:08.596-05:00\"}";
        string clientIdString = "myClientId";
        string clientSecretString = "myClientSecret";
        string accessTokenString = "accessToken";
        ClientSecrets clientSecretsObj { get; set; }
        OAuth2DomainUser domainUserObj { get; set; }
        OAuth2Domain domainObj { get; set; }
        TokenResponse tokenResponseObj { get; set; }
        OAuth2TokenInfo tokenInfoObj { get; set; }
        
        [SetUp]
        public void Init()
        {
            //manually set up the dataStore
            dataStore = new TestDataStore();

            tokenInfoObj = new OAuth2TokenInfo(){
                token = tokenResponseObj,
                tokenString = tokenStringString
            };

            tokenResponseObj = new TokenResponse() { AccessToken = accessTokenString };

            clientSecretsObj = new ClientSecrets() { ClientId = clientIdString, ClientSecret = clientSecretString };

            domainUserObj = new OAuth2DomainUser() { clientSecrets = clientSecretsObj, domain = domainNameString, userName = userNameString };

            domainUserObj.tokenAndScopesByApi.Add(apiString, tokenInfoObj);

            domainObj = new OAuth2Domain() { defaultUser = userNameString };

            domainObj.users.Add(userNameString, domainUserObj);

            var internalInfo = new OAuth2Info() { defaultDomain = domainNameString, defaultClientSecrets = clientSecretsObj };

            internalInfo.domains.Add(domainNameString, domainObj);

            dataStore.internalInfo = internalInfo;

            consumer = new OAuth2InfoConsumer(dataStore);
        }

        #region Domains

        [Test]
        public void GetDomainTest()
        {
            Assert.AreEqual(consumer.GetDomain(domainNameString), domainObj);
        }

        [Test]
        public void GetAllDomainsTest()
        {
            var newDomain = new OAuth2Domain() { domain = "newDomain" };

            consumer.SetDomain(newDomain);

            List<OAuth2Domain> domains = consumer.GetAllDomains().ToList();

            Assert.Contains(newDomain, domains);
            Assert.Contains(domainObj, domains);
        }

        [Test]
        public void SetDomainTest()
        {
            string newDomainName = "newDomain";

            var newDomain = new OAuth2Domain() { domain = newDomainName };

            consumer.SetDomain(newDomain);

            Assert.IsTrue(consumer.DomainExists(newDomainName));
        }

        [Test]
        public void DomainExistsTest()
        {
            Assert.IsTrue(consumer.DomainExists(domainNameString));
            Assert.IsFalse(consumer.DomainExists("someOtherDomain"));
        }

        [Test]
        public void RemoveDomainTest()
        {
            string newDomainName = "newDomain";

            var newDomain = new OAuth2Domain() { domain = newDomainName };

            consumer.SetDomain(newDomain);

            consumer.RemoveDomain(domainNameString);

            Assert.IsFalse(consumer.DomainExists(domainNameString));
            Assert.IsTrue(consumer.DomainExists(newDomainName));
        }

        [Test]
        public void RemoveAllDomainsTest()
        {
            consumer.RemoveAllDomains();

            List<OAuth2Domain> domains = consumer.GetAllDomains().ToList();

            Assert.IsEmpty(domains);
        }

        #endregion

        #region DefaultDomain

        [Test]
        public void GetDefaultDomainTest()
        {
            Assert.AreEqual(consumer.GetDefaultDomain(), domainNameString);
        }

        [Test]
        public void SetDefaultDomainTest()
        {
            string newDomainName = "NewDefDomain";

            consumer.SetDefaultDomain(newDomainName);

            Assert.AreEqual(consumer.GetDefaultDomain(), newDomainName);
            Assert.AreNotEqual(consumer.GetDefaultDomain(), domainNameString);
        }

        [Test]
        public void DefaultDomainExistsTest()
        {
            Assert.IsTrue(consumer.DefaultDomainExists());
        }

        [Test]
        public void DefaultDomainDoesntExistTest()
        {
            consumer.RemoveDefaultDomain();

            Assert.IsFalse(consumer.DefaultDomainExists());
        }

        [Test]
        public void RemoveDefaultDomainTest()
        {
            consumer.RemoveDefaultDomain();

            Assert.IsEmpty(consumer.GetDefaultDomain());
        }

        #endregion

        #region Users

        [Test]
        public void GetUserTest()
        {
            Assert.AreEqual(consumer.GetUser(domainNameString, userNameString), domainUserObj);
        }

        [Test]
        public void GetAllUsersFromOneDomainTest()
        {
            OAuth2DomainUser userA = new OAuth2DomainUser() { domain = domainNameString, userName = "userA" };
            OAuth2DomainUser userB = new OAuth2DomainUser() { domain = "domainB", userName = "userB" };

            consumer.SetUser(domainNameString, userA);
            var domainB = new OAuth2Domain() { domain = "domainB" };
            consumer.SetDomain(domainB);
            consumer.SetUser("domainB", userB);

            List<OAuth2DomainUser> result = consumer.GetAllUsers(domainNameString).ToList();

            Assert.AreEqual(result.Count, 2);
            Assert.Contains(domainUserObj, result);
            Assert.Contains(userA, result);
            Assert.IsFalse(result.Contains(userB));
        }

        [Test]
        public void GetAllUsersFromAllDomainsTest()
        {
            OAuth2DomainUser userA = new OAuth2DomainUser() { domain = domainNameString, userName = "userA" };
            OAuth2DomainUser userB = new OAuth2DomainUser() { domain = "domainB", userName = "userB" };

            consumer.SetUser(domainNameString, userA);
            var domainB = new OAuth2Domain() { domain = "domainB" };
            consumer.SetDomain(domainB);
            consumer.SetUser("domainB", userB);

            List<OAuth2DomainUser> result = consumer.GetAllUsers().ToList();

            Assert.AreEqual(result.Count, 3);
            Assert.Contains(domainUserObj, result);
            Assert.Contains(userA, result);
            Assert.Contains(userB, result);
        }
        
        [Test]
        public void SetUserTest()
        {
            string newUserName = "newUser";

            OAuth2DomainUser user = new OAuth2DomainUser() { domain = domainNameString, userName = newUserName };

            consumer.SetUser(domainNameString, user);

            Assert.IsTrue(consumer.UserExists(domainNameString, newUserName));
        }

        [Test]
        public void UserExistsTest()
        {
            Assert.IsTrue(consumer.UserExists(domainNameString, userNameString));
            Assert.IsFalse(consumer.UserExists("otherDomain", userNameString));
            Assert.IsFalse(consumer.UserExists(domainNameString, "otherUser"));
        }

        [Test]
        public void RemoveUserTest()
        {
            string newUserName = "newUser";

            OAuth2DomainUser user1 = new OAuth2DomainUser() { domain = domainNameString, userName = newUserName };

            consumer.SetUser(domainNameString, user1);

            consumer.RemoveUser(domainNameString, userNameString);

            Assert.IsFalse(consumer.UserExists(domainNameString, userNameString));
            Assert.IsTrue(consumer.UserExists(domainNameString, newUserName));
        }

        #endregion

        #region DefaultUser

        [Test]
        public void GetDefaultUserTest()
        {
            Assert.AreEqual(consumer.GetDefaultUser(domainNameString), userNameString);
            Assert.AreNotEqual(consumer.GetDefaultUser(domainNameString), "someOtherUser");
        }

        [Test]
        public void SetDefaultUserTest()
        {
            string newUserName = "someUser";

            consumer.SetDefaultUser(domainNameString, newUserName);

            Assert.AreEqual(consumer.GetDefaultUser(domainNameString), newUserName);
            Assert.AreNotEqual(consumer.GetDefaultUser(domainNameString), userNameString);
        }

        [Test]
        public void DefaultUserExistsTest()
        {
            Assert.IsTrue(consumer.DefaultUserExists(domainNameString));
            Assert.IsFalse(consumer.DefaultUserExists("someOtherDomainString"));
        }

        [Test]
        public void RemoveDefaultUserTest()
        {
            consumer.RemoveDefaultUser(domainNameString);

            Assert.IsEmpty(consumer.GetDefaultUser(domainNameString));
        }

        #endregion

        #region Token and Scope

        [Test]
        public void GetTokenInfoTest()
        {
            Assert.AreEqual(consumer.GetTokenInfo(domainNameString, userNameString, apiString), tokenInfoObj);
        }

        [Test]
        public void SetTokenAndScopesTest()
        {
            string newTokenString = "new token string";
            string newAccessTokenString = "newAccessToken";
            TokenResponse newToken = new TokenResponse() { AccessToken = newAccessTokenString };

            OAuth2TokenInfo newTokenInfoObj = new OAuth2TokenInfo()
            {
                token = new TokenResponse() { AccessToken = newAccessTokenString },
                tokenString = newTokenString
            };

            consumer.SetTokenAndScopes(domainNameString, userNameString, apiString, 
                newTokenString, newToken, new List<string>());

            var result = consumer.GetTokenInfo(domainNameString, userNameString, apiString);

            //objects won't be the same reference, so can't directly compare
            Assert.AreEqual(result.tokenString, newTokenInfoObj.tokenString);
            Assert.AreEqual(result.token.AccessToken, newTokenInfoObj.token.AccessToken);
        }

        [Test]
        public void TokenAndScopesExistTest()
        {
            Assert.IsTrue(consumer.TokenAndScopesExist(domainNameString, userNameString, apiString));
            Assert.IsFalse(consumer.TokenAndScopesExist("someOtherDomain", userNameString, apiString));
            Assert.IsFalse(consumer.TokenAndScopesExist(domainNameString, "someOtherUser", apiString));
            Assert.IsFalse(consumer.TokenAndScopesExist(domainNameString, userNameString, "someOtherApi"));
        }

        [Test]
        public void RemoveTokenAndScopesTest()
        {
            consumer.RemoveTokenAndScopes(domainNameString, userNameString, apiString);

            Assert.IsFalse(consumer.TokenAndScopesExist(domainNameString, userNameString, apiString));
        }

        #endregion

        #region ClientSecrets

        [Test]
        public void GetClientSecretsTest()
        {
            Assert.AreEqual(consumer.GetClientSecrets(domainNameString, userNameString), clientSecretsObj);
        }

        [Test]
        public void SetClientSecretsTest()
        {
            var newClientSecrets = new ClientSecrets() 
            { ClientId = "newClientId", ClientSecret = "newClientSecret" };

            consumer.SetClientSecrets(domainNameString, userNameString, newClientSecrets);

            Assert.AreEqual(consumer.GetClientSecrets(domainNameString, userNameString), newClientSecrets);
            Assert.AreNotEqual(consumer.GetClientSecrets(domainNameString, userNameString), clientSecretsObj);
        }

        [Test]
        public void ClientSecretsExistTest()
        {
            Assert.IsTrue(consumer.ClientSecretsExist(domainNameString, userNameString));
            Assert.IsFalse(consumer.ClientSecretsExist("someOtherDomain", userNameString));
            Assert.IsFalse(consumer.ClientSecretsExist(domainNameString, "someOtherUser"));
        }

        [Test]
        public void RemoveClientSecretsTest()
        {
            consumer.RemoveClientSecrets(domainNameString, userNameString);

            Assert.IsFalse(consumer.ClientSecretsExist(domainNameString, userNameString));
        }

        #endregion

        #region DefaultClientSecrets

        [Test]
        public void GetDefaultClientSecretsTest()
        {
            Assert.AreEqual(consumer.GetDefaultClientSecrets(), clientSecretsObj);
        }

        [Test]
        public void SetDefaultClientSecretsTest()
        {
            var newClientSecrets = new ClientSecrets() { ClientId = "newClientId", ClientSecret = "newClientSecret" };

            consumer.SetDefaultClientSecrets(newClientSecrets);

            Assert.AreEqual(consumer.GetDefaultClientSecrets(), newClientSecrets);
            Assert.AreNotEqual(consumer.GetDefaultClientSecrets(), clientSecretsObj);
        }

        [Test]
        public void DefaultClientSecretsExistTest()
        {
            Assert.IsTrue(consumer.DefaultClientSecretsExist());
        }

        [Test]
        public void DefaultClientSecretsDontExistTest()
        {
            consumer.RemoveDefaultClientSecrets();

            Assert.IsFalse(consumer.DefaultClientSecretsExist());
        }

        [Test]
        public void RemoveDefaultClientSecretsTest()
        {
            consumer.RemoveDefaultClientSecrets();

            Assert.IsNull(consumer.GetDefaultClientSecrets());
        }

        #endregion

        //#region ServiceAccount

        //[Test]
        //public void GetServiceAccountTest()
        //{
        //    throw new NotImplementedException();
        //}

        //[Test]
        //public void SetServiceAccountTest()
        //{
        //    throw new NotImplementedException();
        //}

        //[Test]
        //public void CheckServiceAccountTest()
        //{
        //    throw new NotImplementedException();
        //}

        //[Test]
        //public void RemoveServiceAccountTest()
        //{
        //    throw new NotImplementedException();
        //}

        //#endregion
    }
}
