using System;
using System.Collections.Generic;
using System.Management.Automation;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using gShell.dotNet.Utilities.OAuth2;

namespace gShell.Cmdlets.Directory.GAGroup
{
    [Cmdlet(VerbsCommon.Remove, "GAGroup",
          DefaultParameterSetName = "GroupName",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GAGroup")]
    public class RemoveGAGroup : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            ParameterSetName = "GroupName",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The email name of the group to remove. For a group AllThings@domain.com named 'All The Things', use AllThings.")]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        //Domain position = 1

        [Parameter(Position = 1,
            ParameterSetName = "GAGroupObject",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A Google Apps Group object representing the group. Retrieved from Get-GAGroup.")]
        [ValidateNotNullOrEmpty]
        public Group GAGroupObject { get; set; }

        [Parameter(Position = 2,
            HelpMessage = "Force the action to complete without a prompt to continue.")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(GroupName, "Remove-GAGroup"))
            {
                if (Force || ShouldContinue((String.Format("Group {0} will be removed from the {1} Google Apps domain.\nContinue?",
                    GroupName, Domain)), "Confirm Google Apps Group Removal"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove group {0}@{1}...",
                            GroupName, Domain));
                        RemoveGroup();
                        WriteVerbose(string.Format("Removal of {0}@{1} completed without error.",
                            GroupName, Domain));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, GroupName));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Group deletion not confirmed"),
                        "", ErrorCategory.InvalidData, GroupName));
                }
            }
        }

        private void RemoveGroup()
        {
            string fullEmail = "";
            switch (ParameterSetName)
            {
                case "GroupName":
                    fullEmail = OAuth2Base.GetFullEmailAddress(GroupName, Domain);
                    break;

                case "GAGroupObject":
                    fullEmail = GAGroupObject.Email;
                    break;
            }

            Console.WriteLine(fullEmail);
            directoryServiceDict[Domain].Groups.Delete(fullEmail).Execute();
        }
    }
}
