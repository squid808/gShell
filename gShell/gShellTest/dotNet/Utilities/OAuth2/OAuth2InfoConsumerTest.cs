using System;
using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

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
        string domainName { get; set; }
        string userName { get; set; }
        OAuth2Info info { get; set; }

        [SetUp]
        public void Init()
        {
            dataStore = new TestDataStore();
            consumer = new OAuth2InfoConsumer(dataStore);
            domainName = "myDomain";
            userName = "myUser";
        }

        #region Domains

        [Test]
        public void GetDomainTest()
        {
            var domain = new OAuth2Domain() { domain = domainName };

            consumer.SetDomain(domain);

            OAuth2Domain loadedDomain = consumer.GetDomain(domainName);

            Assert.AreEqual(domain, loadedDomain);
        }

        [Test]
        public void GetAllDomainsTest()
        {
            string dName1 = "1";
            string dName2 = "2";

            var domain1 = new OAuth2Domain() { domain = dName1 };
            var domain2 = new OAuth2Domain() { domain = dName2 };

            consumer.SetDomain(domain1);
            consumer.SetDomain(domain2);

            IEnumerable<OAuth2Domain> domains = consumer.GetAllDomains();

            info = dataStore.LoadInfo();

            Assert.That(info.domains.ContainsKey(dName1));
            Assert.That(info.domains.ContainsKey(dName2));
        }

        [Test]
        public void SetDomainTest()
        {
            var domain = new OAuth2Domain() { domain = domainName };

            consumer.SetDomain(domain);

            info = dataStore.LoadInfo();

            Assert.That(info.domains[domainName] != null);
            Assert.That(info.domains[domainName].domain == domainName);
            Assert.That(info.domains[domainName].users != null);
        }

        [Test]
        public void DomainExistsTest()
        {
            var domain = new OAuth2Domain() { domain = domainName };

            consumer.SetDomain(domain);

            Assert.That(consumer.DomainExists(domainName) == true);
            Assert.That(consumer.DomainExists("someOtherName") == false);        }

        [Test]
        public void RemoveDomainTest()
        {
            var domain = new OAuth2Domain() { domain = domainName };

            consumer.SetDomain(domain);

            consumer.RemoveDomain(domainName);

            Assert.That(consumer.DomainExists(domainName) == false);        }

        [Test]
        public void RemoveAllDomainsTest()
        {
            var domain = new OAuth2Domain() { domain = domainName };

            consumer.SetDomain(domain);

            consumer.RemoveAllDomains();

            info = dataStore.LoadInfo();

            Assert.That(info.domains.Count == 0);        }

        #endregion

        #region DefaultDomain

        [Test]
        public void GetDefaultDomainTest()
        {            throw new NotImplementedException();        }

        [Test]
        public void SetDefaultDomainTest()
        {            throw new NotImplementedException();        }

        [Test]
        public void DefaultDomainExistsTest()
        {            throw new NotImplementedException();        }

        [Test]
        public void RemoveDefaultDomainTest()
        {            throw new NotImplementedException();        }

        #endregion

        #region Users

        [Test]
        public void GetUserTest()
        {            throw new NotImplementedException();        }

        [Test]
        public void GetAllUsersTest()
        {            throw new NotImplementedException();        }

        [Test]
        public void SetUserTest()
        {            throw new NotImplementedException();        }

        [Test]
        public void UserExistsTest()
        {            throw new NotImplementedException();        }

        [Test]
        public void RemoveUserTest()
        {            throw new NotImplementedException();        }

        #endregion

        #region Token and Scope

        [Test]
        public void GetTokenInfoTest()
        {            throw new NotImplementedException();        }

        [Test]
        public void SetTokenAndScopesTest()
        {            throw new NotImplementedException();        }

        [Test]
        public void TokenAndScopesExistTest()
        {            throw new NotImplementedException();        }

        [Test]
        public void RemoveTokenAndScopesTest()
        {            throw new NotImplementedException();        }

        #endregion

        #region DefaultUser

        [Test]
        public void GetDefaultUserTest()
        {            throw new NotImplementedException();        }

        [Test]
        public void SetDefaultUserTest()
        {            throw new NotImplementedException();        }

        [Test]
        public void DefaultUserExistsTest()
        {            throw new NotImplementedException();        }

        [Test]
        public void RemoveDefaultUserTest()
        {            throw new NotImplementedException();        }

        #endregion

        #region ClientSecrets

        [Test]
        public void GetClientSecretsTest()
        {            throw new NotImplementedException();        }

        [Test]
        public void SetClientSecretsTest()
        {            throw new NotImplementedException();        }

        [Test]
        public void ClientSecretsExistTest()
        {            throw new NotImplementedException();        }

        [Test]
        public void RemoveClientSecretsTest()
        {            throw new NotImplementedException();        }

        #endregion

        #region DefaultClientSecrets

        [Test]
        public void GetDefaultClientSecretsTest()
        {            throw new NotImplementedException();        }

        [Test]
        public void SetDefaultClientSecretsTest()
        {            throw new NotImplementedException();        }

        [Test]
        public void DefaultClientSecretsExistTest()
        {            throw new NotImplementedException();        }

        [Test]
        public void RemoveDefaultClientSecretsTest()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ServiceAccount

        [Test]
        public void GetServiceAccountTest()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void SetServiceAccountTest()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void CheckServiceAccountTest()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void RemoveServiceAccountTest()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
