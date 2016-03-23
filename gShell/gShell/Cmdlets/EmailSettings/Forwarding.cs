using System;
using System.Management.Automation;
using System.Collections.Generic;

using Google.Apis.Auth.OAuth2;
using Data = Google.Apis.admin.Emailsettings.emailsettings_v1.Data;

using gEmailsettings = gShell.dotNet.Emailsettings;
using gShell.Cmdlets.Emailsettings;

namespace gShell.Cmdlets.Emailsettings.Forwarding
{
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsForwarding",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGEmailSettingsForwarding : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings Forwarding", "Get-GEmailSettingsForwarding"))
            {
                WriteObject(mainBase.forwarding.Get(Domain, GetUserFromEmail(UserName)));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GEmailSettingsForwarding",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGEmailSettingsForwarding : EmailsettingsBase
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

        [Parameter(Position = 3,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ForwardTo { get; set; }

        [Parameter(Position = 4,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ForwardingActionEnum Action { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Forwarding(){
                Enable = Enable,
                ForwardTo = ForwardTo,
                Action = Action.ToString()
            };

            if (ShouldProcess("Email Settings Forwarding", "Set-GEmailSettingsForwarding"))
            {
                WriteObject(mainBase.forwarding.Update(body, Domain, GetUserFromEmail(UserName)));
            }
        }
    }
}