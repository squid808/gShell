using System;
using System.Management.Automation;
using System.Collections.Generic;

using Google.Apis.Auth.OAuth2;
using Data = Google.Apis.admin.Emailsettings.emailsettings_v1.Data;

using gEmailsettings = gShell.dotNet.Emailsettings;

namespace gShell.Cmdlets.Emailsettings.Delegation
{
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsDelegation",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGEmailSettingsDelegation : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings Delegation", "Get-GEmailSettingsDelegation"))
            {
                WriteObject(mainBase.delegation.Get(Domain, GetUserFromEmail(UserName)).DelegatesValue);
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GEmailSettingsDelegation",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGEmailSettingsDelegation : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Address { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Delegate(){
                Address = Address
            };

            if (ShouldProcess("Email Settings Delegation", "New-GEmailSettingsDelegation"))
            {
                WriteObject(mainBase.delegation.Insert(body, Domain, GetUserFromEmail(UserName)));
            }
        }
    }

    [Cmdlet(VerbsCommon.Remove, "GEmailSettingsDelegation",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class RemoveGEmailSettingsDelegation : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DelegateEmail { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings Delegation", "Remove-GEmailSettingsDelegation"))
            {
                mainBase.delegation.Delete(Domain, GetUserFromEmail(UserName), DelegateEmail);
            }
        }
    }
}