using System;
using System.Management.Automation;
using System.Collections.Generic;

using Google.Apis.Auth.OAuth2;
using Data = Google.Apis.admin.Emailsettings.emailsettings_v1.Data;

using gEmailsettings = gShell.dotNet.Emailsettings;

namespace gShell.Cmdlets.Emailsettings.SendasAlias
{
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsSendasAlias",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGEmailSettingsSendasAlias : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings SendasAlias", "Get-GEmailSettingsSendasAlias"))
            {
                WriteObject(mainBase.sendasAliases.Get(Domain, GetUserFromEmail(UserName)).SendasAliases);
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GEmailSettingsSendasAlias",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGEmailSettingsSendasAlias : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 3,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Address { get; set; }

        [Parameter(Position = 4)]
        [ValidateNotNullOrEmpty]
        public string ReplyTo { get; set; }

        [Parameter(Position = 5)]
        [ValidateNotNullOrEmpty]
        public bool? MakeDefault { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.SendasAlias(){
                Name = Name,
                Address = Address
            };

            if (!string.IsNullOrWhiteSpace(ReplyTo)) body.ReplyTo = ReplyTo;

            if (MakeDefault.HasValue) body.MakeDefault = MakeDefault.Value;

            if (ShouldProcess("Email Settings SendasAlias", "New-GEmailSettingsSendasAlias"))
            {
                WriteObject(mainBase.sendasAliases.Insert(body, Domain, GetUserFromEmail(UserName)));
            }
        }
    }
}