using System.Management.Automation;
using gShell.dotNet.Utilities.OAuth2;

namespace gShell.Cmdlets.Utilities
{
    public abstract class UtilityBase : OAuth2CmdletBase
    {
        protected override void BeginProcessing()
        {
            //Authenticate(OAuth2Base.currentDomain);
        }

        protected override string Authenticate(string givenDomain)
        {
            return null;
        }
    }
}
