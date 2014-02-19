using System.Collections.Generic;
using System.Management.Automation;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.DirectoryCmdlets.GAGroup
{
    [Cmdlet(VerbsCommon.Get, "GAGroup",
          DefaultParameterSetName = "OneUser",
          SupportsShouldProcess = true)]
    public class GetGAGroup : GetGAGroupBase
    {
        #region Properties

        [Parameter(Position = 0,
            ParameterSetName = "OneGroup",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Help Text")]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            ParameterSetName = "AllGroups",
            Mandatory = true)]
        public SwitchParameter All { get; set; }

        [Parameter(Position = 3,
            ParameterSetName = "AllGroups")]
        public SwitchParameter Cache { get; set; }

        [Parameter(Position = 4,
            ParameterSetName = "AllGroups")]
        public SwitchParameter ForceCacheReload { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case "OneGroup":
                    WriteObject(GetOneGroup(GroupName));
                    break;

                case "AllGroups":
                    if (Cache)
                    {
                        WriteObject(RetrieveCachedGroups(ForceCacheReload));
                    }
                    else
                    {
                        WriteObject(GetAllGroups());
                    }
                    break;
            }
        }
    }

    public class GetGAGroupBase : DirectoryBase
    {
        [Parameter()]
        public int MaxResults { get; set; }

        [Parameter(ParameterSetName = "AllGroups")]
        public SwitchParameter MultiDomain { get; set; }

        protected List<Group> RetrieveCachedGroups(bool forcedReload=false)
        {
            List<Group> groupList = new List<Group>();

            if (cachedDomainGroups.ContainsKey(Domain) && !forcedReload)
            {
                groupList = cachedDomainGroups[Domain];
            }
            else
            {
                groupList = GetAllGroups();
                cachedDomainGroups[Domain] = groupList;
            }

            return groupList;
        }

        protected Group GetOneGroup(string GroupName)
        {
            string fullEmail = GetFullEmailAddress(GroupName, Domain);

            Group returnedGroup = directoryServiceDict[Domain].
                        Groups.Get(fullEmail).Execute();

            return (returnedGroup);
        }

        protected List<Group> GetAllGroups()
        {
            //TODO: Figure out multi-domain accounts

            GroupsResource.ListRequest request = directoryServiceDict[Domain].Groups.List();

            if (MultiDomain)
            {
                request.Customer = currentUserInfo.Id;
            }
            else
            {
                request.Domain = Domain;
            }

            if (0 != MaxResults && 200 > MaxResults)
            {
                request.MaxResults = MaxResults;
            }
            else
            {
                request.MaxResults = 200;
            }

            StartProgressBar("Gathering groups", string.Empty);

            UpdateProgressBar(1, 2, "Gathering groups",
                "-Collecting accounts 1 to " + request.MaxResults.ToString());

            Groups execution = request.Execute();

            List<Group> returnedList = new List<Group>();

            returnedList.AddRange(execution.GroupsValue);

            int totalAccounts = returnedList.Count;

            while (!string.IsNullOrWhiteSpace(execution.NextPageToken) &&
                execution.NextPageToken != request.PageToken &&
                (0 == MaxResults || returnedList.Count < MaxResults))
            {
                request.PageToken = execution.NextPageToken;
                UpdateProgressBar(5, 10,"Gathering groups",
                    string.Format("-Collecting groups {0} to {1}",
                     (returnedList.Count + 1).ToString(),
                     (returnedList.Count + request.MaxResults).ToString()));
                request.Execute();
                returnedList.AddRange(execution.GroupsValue);
            }

            UpdateProgressBar(1, 2, "Gathering accounts",
                "-Returning " + returnedList.Count.ToString() + " results.");

            return (returnedList);
        }
    }
}
