using System;
using System.Management.Automation;
using System.Collections.Generic;

using Google.Apis.Auth.OAuth2;
using Data = Google.Apis.admin.Emailsettings.emailsettings_v1.Data;

using gEmailsettings = gShell.dotNet.Emailsettings;
using gShell.Cmdlets.Emailsettings;

namespace gShell.Cmdlets.Emailsettings.Pop
{
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsPop",
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
            if (ShouldProcess("Email Settings Pop", "Get-GEmailSettingsPop"))
            {
                WriteObject(mainBase.pop.Get(Domain, GetUserFromEmail(UserName)));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GEmailSettingsPop",
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
        [ValidateNotNullOrEmpty]
        public bool Enable { get; set; }

        [Parameter(Position = 3)]
        [ValidateNotNullOrEmpty]
        public PopEnableForEnum? EnableFor { get; set; }

        [Parameter(Position = 4)]
        [ValidateNotNullOrEmpty]
        public PopActionEnum? Action { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Pop(){
                Enable = Enable
            };

            if (EnableFor != null) body.EnableFor = EnableFor.ToString();

            if (Action != null) body.Action = Action.ToString();

            if (ShouldProcess("Email Settings Pop", "Get-GEmailSettingsPop"))
            {
                WriteObject(mainBase.pop.Update(body, Domain, GetUserFromEmail(UserName)));
            }
        }
    }
}