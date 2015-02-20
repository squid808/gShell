using gShell.OAuth2;
using System.Management.Automation;

namespace gShell.UtilityCmdlets.SavedDomain
{
    [Cmdlet(VerbsCommon.Get, "GADefaultDomain",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GADefaultDomain")]
    public class GetGADefaultDomainCommand : UtilityBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("GAShell", "Get-GADefaultDomain"))
            {
                WriteObject(RetrieveDefaultDomain());
            }
        }

        private string RetrieveDefaultDomain()
        {
            return SavedFile.GetDefaultDomain();
        }
    }
}
