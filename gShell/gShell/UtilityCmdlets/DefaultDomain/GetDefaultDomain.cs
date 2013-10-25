using gShell.OAuth2;
using System.Management.Automation;

namespace gShell.UtilityCmdlets.DefaultDomain
{
    [Cmdlet(VerbsCommon.Get, "GADefaultDomain",
          SupportsShouldProcess = true)]
    public class GetDefaultDomainCommand : DefaultDomainObject
    {
        protected override void ProcessRecord()
        {
            WriteObject(RetrieveDefaultDomain());
        }

        private string RetrieveDefaultDomain()
        {
            return SavedFile.GetDefaultDomain();
        }
    }
}
