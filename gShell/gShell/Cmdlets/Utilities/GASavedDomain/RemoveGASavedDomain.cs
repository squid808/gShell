using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace gShell.Cmdlets.Utilities.GASavedDomain
{
    [Cmdlet(VerbsCommon.Remove, "GASavedDomain",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GASavedDomain")]
    public class RemoveGASavedDomain : UtilityBase
    {
        [Parameter(Position = 0,
            Mandatory = true,
            HelpMessage = "The domain whose saved authentication data is to be removed, ex. contoso.com")]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        [Parameter(Position = 1)]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            if (ShouldProcess(Domain, "Remove-GASavedDomain"))
            {
                if (Force || ShouldContinue((String.Format("Stored authentication information for domain {0} will be deleted.\nContinue?",
                    Domain)), "Confirm removal of stored authentication information"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove stored information for domain {0}...", Domain));

                        RemoveDomain();

                        WriteVerbose(string.Format("Removal of {0} completed without error.", Domain));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, Domain));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Deletion of stored authentication information not confirmed"),
                        "", ErrorCategory.InvalidData, Domain));
                }
            }
        }

        private void RemoveDomain()
        {
            SavedFile.DeleteToken(Domain);
        }
    }
}
