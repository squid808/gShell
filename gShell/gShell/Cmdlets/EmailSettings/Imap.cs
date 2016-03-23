using System;
using System.Management.Automation;
using System.Collections.Generic;

using Google.Apis.Auth.OAuth2;
using Data = Google.Apis.admin.Emailsettings.emailsettings_v1.Data;

using gEmailsettings = gShell.dotNet.Emailsettings;

namespace gShell.Cmdlets.Emailsettings.Imap
{
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsImap",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGEmailSettingsImap : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings Imap", "Get-GEmailSettingsImap"))
            {
                WriteObject(mainBase.imap.Get(Domain, GetUserFromEmail(UserName)));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GEmailSettingsImap",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGEmailSettingsImap : EmailsettingsBase
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
            var body = new Data.Imap(){
                Enable = Enable
            };

            if (ShouldProcess("Email Settings Imap", "Set-GEmailSettingsImap"))
            {
                WriteObject(mainBase.imap.Update(body, Domain, GetUserFromEmail(UserName)));
            }
        }
    }
}