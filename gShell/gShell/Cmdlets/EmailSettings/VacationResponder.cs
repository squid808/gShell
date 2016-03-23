using System;
using System.Management.Automation;
using System.Collections.Generic;

using Google.Apis.Auth.OAuth2;
using Data = Google.Apis.admin.Emailsettings.emailsettings_v1.Data;

using gEmailsettings = gShell.dotNet.Emailsettings;

namespace gShell.Cmdlets.Emailsettings.VacationResponder
{
    [Cmdlet(VerbsCommon.Get, "GEmailSettingsVacationResponder",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGEmailSettingsVacationResponder : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Email Settings VacationResponder", "Get-GEmailSettingsVacationResponder"))
            {
                WriteObject(mainBase.vacationResponder.Get(Domain, GetUserFromEmail(UserName)));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GEmailSettingsVacationResponder",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGEmailSettingsVacationResponder : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool ContactsOnly { get; set; }

        [Parameter(Position = 3)]
        [ValidateNotNullOrEmpty]
        public bool? DomainOnly { get; set; }

        [Parameter(Position = 4,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool Enable { get; set; }

        [Parameter(Position = 5,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public DateTime EndDate { get; set; }

        [Parameter(Position = 6,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Message { get; set; }

        [Parameter(Position = 7,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public DateTime StartDate { get; set; }

        [Parameter(Position = 8,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Subject { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.VacationResponder(){
                ContactsOnly = ContactsOnly,
                DomainOnly = (DomainOnly.HasValue) ? DomainOnly.Value : false,
                Enable = Enable,
                EndDate = EndDate.ToUniversalTime().ToString("yyyy-MM-dd"),
                Message = Message,
                StartDate = StartDate.ToUniversalTime().ToString("yyyy-MM-dd"),
                Subject = Subject
            };

            if (ShouldProcess("Email Settings VacationResponder", "Get-GEmailSettingsVacationResponder"))
            {
                WriteObject(mainBase.vacationResponder.Update(body, Domain, GetUserFromEmail(UserName)));
            }
        }
    }
}