using gShell.Main.Auth.OAuth2.v1;
using Google.Apis.Auth.OAuth2;

namespace gShell.Main.PowerShell.Base.v1
{
    public abstract class UtilityBase : OAuth2CmdletBase
    {
        protected override void BeginProcessing() { }

        protected override AuthenticatedUserInfo Authenticate(AuthenticatedUserInfo AuthUserInfo, ClientSecrets Secrets) { return null; }

        protected override IApiInfo ApiInfo { get { return null; } }

        //protected override string apiNameAndVersion { get { return "gShellUtils"; } }

        //protected override ScopeInfo[] scopeInfos { get { return null; } }
    }
}
