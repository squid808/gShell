using System;
using System.Collections.Generic;
using System.Management.Automation;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using gShell.dotNet.Utilities.OAuth2;

namespace gShell.Cmdlets.Directory.GAUser
{
    [Cmdlet(VerbsCommon.Remove, "GAUser",
        DefaultParameterSetName="UserName",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GAUser")]
    public class RemoveGAUser : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            ParameterSetName = "UserName",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Help Text")]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        //Domain position = 1

        [Parameter(Position = 0,
            ParameterSetName = "GAUserObject",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A Google Apps User object")]
        [ValidateNotNullOrEmpty]
        public User GAUserObject { get; set; }

        [Parameter(Position = 2)]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(UserName, "Remove-GAUser"))
            {
                if (Force || ShouldContinue((String.Format("User {0} will be removed from the {1} Google Apps domain.\nContinue?",
                    UserName, Domain)), "Confirm Google Apps User Removal"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove user {0}@{1}...",
                            UserName, Domain));
                        RemoveUser();
                        WriteVerbose(string.Format("Removal of {0}@{1} completed without error.",
                            UserName, Domain));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, UserName));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Account deletion not confirmed"),
                        "", ErrorCategory.InvalidData, UserName));
                }
            }
        }

        private void RemoveUser()
        {
            string fullEmail = "";
            switch (ParameterSetName)
            {
                case "UserName":
                    fullEmail = OAuth2Base.GetFullEmailAddress(UserName, Domain);
                    break;

                case "GAUserObject":
                    fullEmail = GAUserObject.PrimaryEmail;
                    break;
            }

            directoryServiceDict[Domain].Users.Delete(fullEmail).Execute();
        }
    }
}
