using System;
using System.Management.Automation;
using System.Collections.Generic;

using Google.Apis.Auth.OAuth2;
using Data = Google.Apis.admin.Emailsettings.emailsettings_v1.Data;

using gEmailsettings = gShell.dotNet.Emailsettings;

namespace gShell.Cmdlets.Emailsettings.WebClip
{
    [Cmdlet(VerbsCommon.Set, "GEmailSettingsWebClip",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGEmailSettingsWebClip : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool Enable { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.WebClip(){
                Enable = Enable
            };

            if (ShouldProcess("Email Settings WebClip", "Set-GEmailSettingsWebClip"))
            {
                WriteObject(mainBase.webClip.Update(body, Domain, GetUserFromEmail(UserName)));
            }
        }
    }
}