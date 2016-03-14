using System.Management.Automation;
using System.Collections.Generic;

using Google.Apis.Auth.OAuth2;
using Data = Google.Apis.Discovery.v1.Data;

using gEmailsettings = gShell.dotNet.Emailsettings;

namespace gShell.Cmdlets.Emailsettings.Label
{
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsLabel",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetEmailSettingsLabel : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings Label", "Get-GEmailSettingsLabel"))
            {
                WriteObject(mainBase.labels.Get(Domain, UserName));
            }
        }
    }
}
