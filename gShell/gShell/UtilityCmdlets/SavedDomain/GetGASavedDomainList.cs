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
            WriteObject(RetrieveAllDomains());
        }

        private List<string> RetrieveAllDomains()
        {
            return SavedFile.GetDomainList();
        }
    }
}
