using System;
using System.Management.Automation;
using System.Collections.Generic;
using gShell.OAuth2;
using gShell.DirectoryCmdlets.GAUserAlias;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.DirectoryCmdlets
{
    public abstract class DirectoryBase : OAuth2CmdletBase
    {
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the Google Apps domain, ex contoso.com")]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        protected static Dictionary<string, DirectoryService> directoryServiceDict;
        protected static Dictionary<string, List<User>> cachedDomainUsers;
        protected static Dictionary<string, List<Group>> cachedDomainGroups;
        protected static Dictionary<string, List<Alias>> cachedDomainAliases;
        protected static Dictionary<string, Dictionary<string, List<Member>>> cachedDomainGroupMembers;

        public DirectoryBase()
        {
            if (null == directoryServiceDict)
            {
                directoryServiceDict = new Dictionary<string, DirectoryService>();
                cachedDomainUsers = new Dictionary<string, List<User>>();
                cachedDomainGroups = new Dictionary<string, List<Group>>();
                cachedDomainGroupMembers = new Dictionary<string, Dictionary<string, List<Member>>>();
                cachedDomainAliases = new Dictionary<string, List<Alias>>();
            }
        }

        protected override void BeginProcessing()
        {
            Domain = Authenticate(Domain);
        }

        protected override void BuildService()
        {
            if (!directoryServiceDict.ContainsKey(currentDomain))
            {
                OAuth2SetupPackage package = packageDict[currentDomain];
                DirectoryService service = new DirectoryService(package.initializer);
                directoryServiceDict.Add(currentDomain, service);
            }
        }

        /// <summary>
        /// If the given username doesn't contain an @ assume it doesn't contain a domain and add it in.
        /// </summary>
        /// <param name="_userName"></param>
        /// <param name="_domain"></param>
        /// <returns></returns>
        protected string GetFullEmailAddress(string _userName, string _domain)
        {
            if (!_userName.Contains("@"))
            {
                _userName += "@" + _domain;
            }

            return _userName;
        }
    }
}
