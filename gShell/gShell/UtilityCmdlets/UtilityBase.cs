using System.Management.Automation;
using gShell.OAuth2;

namespace gShell.UtilityCmdlets
{
    public abstract class UtilityBase : OAuth2CmdletBase
    {
        protected override void BeginProcessing()
        {
            Authenticate(currentDomain);
        }

        protected override string BuildService(string givenDomain) {
            return null;
        }
    }
}
