using System;
using System.Management.Automation;
using System.Collections.Generic;
using gShell.OAuth2;
using Google.Apis.Services;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using gShell.DirectoryCmdlets.GAUserAlias;

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

        //protected static Dictionary<string, DirectoryService> directoryServiceDict;
        protected static Dictionary<string, List<User>> cachedDomainUsers;
        protected static Dictionary<string, List<Group>> cachedDomainGroups;
        protected static Dictionary<string, List<Alias>> cachedDomainAliases;
        protected static Dictionary<string, Dictionary<string, List<Member>>> cachedDomainGroupMembers;

        public DirectoryBase()
        {
            if (null == directoryServiceDict)
            {
                directoryServiceDict = new Dictionary<string, DirectoryService>();
            }

            if (null == cachedDomainAliases)
            {
                cachedDomainAliases = new Dictionary<string, List<Alias>>();
            }

            if (null == cachedDomainGroupMembers)
            {
                cachedDomainGroupMembers = new Dictionary<string, Dictionary<string, List<Member>>>();
            }

            if (null == cachedDomainGroups)
            {
                cachedDomainGroups = new Dictionary<string, List<Group>>();
            }

            if (null == cachedDomainUsers)
            {
                cachedDomainUsers = new Dictionary<string, List<User>>();
            }
        }

        protected override void BeginProcessing()
        {
            Domain = Authenticate(Domain);
        }

        protected override string BuildService(string givenDomain)
        {
            if (string.IsNullOrWhiteSpace(givenDomain) ||
                !directoryServiceDict.ContainsKey(givenDomain))
            {
                DirectoryService service = BuildDirectoryService(givenDomain);

                if (currentDomain == "gmail.com")
                {
                    ThrowTerminatingError(new ErrorRecord(new Exception("This cmdlet is not available for a gmail account."),
                        "", ErrorCategory.InvalidData, currentDomain));
                }

                //current domain should be set at this point 
                directoryServiceDict.Add(currentDomain, service);

                return currentDomain;
            }
            else
            {
                return givenDomain;
            }
        }
    }
}
