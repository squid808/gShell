using System;
using System.Management.Automation;
using System.Collections.Generic;
using gShell.dotNet.Utilities.OAuth2;

namespace gShell.Cmdlets.Utilities.GAServiceAccount
{
    [Cmdlet(VerbsCommon.Set, "GAServiceAccount",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAServiceAccount")]
    public class SetGAServiceAccount : PSCmdlet
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Email { get; set; }

        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string CertificatePath { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(Email, "Set-GAServiceAccount"))
            {
                SavedFile.SetServiceAccountInfo(Email, CertificatePath);
            }
        }

    }
}
