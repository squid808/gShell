using System;
using System.Collections.Generic;
using System.Management.Automation;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.DirectoryCmdlets.GAGroup
{
    [Cmdlet(VerbsCommon.Remove, "GAGroup",
          DefaultParameterSetName = "GroupName",
          SupportsShouldProcess = true)]
    public class RemoveGAGroup : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            ParameterSetName = "GroupName",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Help Text")]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        //Domain position = 1

        [Parameter(Position = 1,
            ParameterSetName = "GAGroupObject",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A Google Apps Group object")]
        [ValidateNotNullOrEmpty]
        public Group GAGroupObject { get; set; }

        [Parameter(Position = 2)]
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
                    fullEmail = GetFullEmailAddress(GroupName, Domain);
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
