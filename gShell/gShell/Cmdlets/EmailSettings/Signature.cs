using System;
using System.Management.Automation;
using System.Collections.Generic;

using Google.Apis.Auth.OAuth2;
using Data = Google.Apis.admin.Emailsettings.emailsettings_v1.Data;

using gEmailsettings = gShell.dotNet.Emailsettings;
using gShell.Cmdlets.Emailsettings;

namespace gShell.Cmdlets.Emailsettings.Signature
{
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsSignature",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGEmailSettingsPop : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings Signature", "Get-GEmailSettingsSignature"))
            {
                WriteObject(mainBase.signature.Get(Domain, GetUserFromEmail(UserName)));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GEmailSettingsSignature",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGEmailSettingsPop : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNull]
        public string Signature { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Signature()
            {
                SignatureValue = this.Signature
            };

            if (ShouldProcess("Email Settings Signature", "Get-GEmailSettingsSignature"))
            {
                WriteObject(mainBase.signature.Update(body, Domain, GetUserFromEmail(UserName)));
            }
        }
    }
}