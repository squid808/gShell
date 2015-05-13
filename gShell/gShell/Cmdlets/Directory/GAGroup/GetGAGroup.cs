using System.Collections.Generic;
using System.Management.Automation;
using Data = Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.Cmdlets.Directory.GAGroup
{
    [Cmdlet(VerbsCommon.Get, "GAGroup",
          DefaultParameterSetName = "OneUser",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAGroup")]
    public class GetGAGroup : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            ParameterSetName = "OneGroup",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The email name of the group you want to retrieve. For a group AllThings@domain.com named 'All The Things', use AllThings.")]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            ParameterSetName = "AllGroups",
            Mandatory = true,
            HelpMessage = "Indicates if you would like to retrieve the information for all groups in the domain.")]
        public SwitchParameter All { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "AllGroups")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = "OneUser")]
        public int MaxResults { get; set; }

        [Parameter(Position = 3,
            ParameterSetName = "OneUser",
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case "OneUser":
                    if (ShouldProcess(GroupName, "Get-GAGroup"))
                    {
                        WriteObject(groups.List(new dotNet.Directory.Groups.GroupsListProperties(){
                            totalResults = MaxResults,
                            domain = Domain,
                            userKey = UserName
                        }));
                    }
                    break;
                case "OneGroup":
                    if (ShouldProcess(GroupName, "Get-GAGroup"))
                    {
                        WriteObject(groups.Get(GroupName, Domain));
                    }
                    break;

                case "AllGroups":
                    if (ShouldProcess("All Groups", "Get-GAGroup"))
                    {
                        WriteObject(groups.List(new dotNet.Directory.Groups.GroupsListProperties()
                        {
                            totalResults = MaxResults,
                            domain = Domain
                        }));
                    }
                    break;
            }
        }
    }
}
