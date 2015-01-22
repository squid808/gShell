using System;
using System.Collections.Generic;
using System.Management.Automation;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.DirectoryCmdlets.GAGroup
{
    [Cmdlet(VerbsCommon.Set, "GAGroup",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAGroup")]
    public class SetGAGroup : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The email name of the group you want to update. For a group AllThings@domain.com named 'All The Things', use AllThings.")]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            HelpMessage = "The new description of the group.")]
        public string NewDescription { get; set; }

        [Parameter(Position = 3,
            HelpMessage = "The new formatted name of the group.")]
        public string NewName { get; set; }

        [Parameter(Position = 4,
            HelpMessage = "The new email address for the group. Does not include the @domain.com")]
        public string NewEmailAddress { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(GroupName, "Set-GAGroup"))
            {
                UpdateGroup();
            }
        }

        private void UpdateGroup()
        {
            string fullEmail = GetFullEmailAddress(GroupName, Domain);

            //Group groupAcct = directoryServiceDict[Domain].Groups.Get(fullEmail).Execute();
            Group groupAcct = new Group();

            if (null == groupAcct)
            {
                WriteError(new ErrorRecord(new Exception(
                    string.Format("No group {0} was found to update.", fullEmail)),
                        "", ErrorCategory.InvalidData, GroupName));
            }

            if (String.IsNullOrWhiteSpace(NewDescription) &&
                String.IsNullOrWhiteSpace(NewEmailAddress) &&
                String.IsNullOrWhiteSpace(NewName))
            {
                WriteError(new ErrorRecord(new Exception(
                    string.Format("No data was enetered to update {0}.", fullEmail)),
                        "", ErrorCategory.InvalidData, GroupName));
            }

            if (!String.IsNullOrWhiteSpace(NewDescription))
            {
                groupAcct.Description = NewDescription;
            }

            if (!String.IsNullOrWhiteSpace(NewEmailAddress))
            {
                string _newEmail = GetFullEmailAddress(NewEmailAddress, Domain);
                groupAcct.Email = _newEmail;
            }

            if (!String.IsNullOrWhiteSpace(NewName))
            {
                groupAcct.Name = NewName;
            }

            directoryServiceDict[Domain].Groups.Patch(groupAcct, fullEmail).Execute();
        }
    }
}
