using System;
using System.Management.Automation;
using System.Collections.Generic;

using gShell.dotNet.Utilities;
using gShell.dotNet.Utilities.OAuth2;

namespace gShell.Cmdlets.Utilities.GShellServiceAccount
{
    [Cmdlet(VerbsCommon.Set, "GShellServiceAccount",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAServiceAccount")]
    public class SetGShellServiceAccount : PSCmdlet
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Email { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string CertificatePath { get; set; }

        [Parameter(Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string KeyPassword { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(Email, "Set-GShellServiceAccount"))
            {
                OAuth2Base.SetServiceAccount(Domain, Email, CertificatePath, KeyPassword);
            }
        }

    }
}
