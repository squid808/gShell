using System.Management.Automation;

namespace gShell.Cmdlets.Gmail
{
    public abstract class GmailServiceAccountBase : GmailBase
    {
        #region Properties
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string TargetUserEmail { get; set; }
        #endregion

        protected override void BeginProcessing()
        {
            gShellServiceAccount = TargetUserEmail;

            base.BeginProcessing();
        }
    }
}
