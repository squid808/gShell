using System.Collections.Generic;
using gShell.dotNet.Utilities.OAuth2;
using System.Management.Automation;

namespace gShell.Cmdlets.Utilities.GASavedDomain
{
    [Cmdlet(VerbsCommon.Get, "GASavedDomainList",
          SupportsShouldProcess = true,
          HelpUri=@"https://github.com/squid808/gShell/wiki/Get-GASavedDomainList")]
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
