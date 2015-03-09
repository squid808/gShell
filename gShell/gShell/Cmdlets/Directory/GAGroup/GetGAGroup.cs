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

        [Parameter(Position = 3,
            ParameterSetName = "AllGroups",
            HelpMessage = "Retrieves the information from local memory if it already exists, this may not get up-to-date information from the web.")]
        public SwitchParameter Cache { get; set; }

        [Parameter(Position = 4,
            ParameterSetName = "AllGroups",
            HelpMessage = "Force the cmdlet to refresh any cached information. This will ensure you get up-to-date information from the web.")]
        public SwitchParameter ForceCacheReload { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case "OneGroup":
                    if (ShouldProcess(GroupName, "Get-GAGroup"))
                    {
                        WriteObject(Groups.Get(GetFullEmailAddress(GroupName, Domain)));
                    }
                    break;

                case "AllGroups":
                    if (ShouldProcess("All Groups", "Get-GAGroup"))
                    {
                        WriteObject(Groups.List());
                    }
                    break;
            }
        }
    }
}
