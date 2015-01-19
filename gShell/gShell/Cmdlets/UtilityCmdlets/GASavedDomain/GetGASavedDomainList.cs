using System.Collections.Generic;
using gShell.OAuth2;
using System.Management.Automation;

namespace gShell.UtilityCmdlets.SavedDomain
{
    [Cmdlet(VerbsCommon.Get, "GASavedDomainList",
          SupportsShouldProcess = true)]
    public class GetGASavedDomainList : UtilityBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("GAShell", "Get-GASavedDomainList"))
            {
                WriteObject(RetrieveAllDomains());
            }
        }

        private List<string> RetrieveAllDomains()
        {
            return SavedFile.GetDomainList();
        }
    }
}
