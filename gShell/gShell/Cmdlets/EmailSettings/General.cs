using System;
using System.Management.Automation;
using System.Collections.Generic;

using Google.Apis.Auth.OAuth2;
using Data = Google.Apis.admin.Emailsettings.emailsettings_v1.Data;

using gEmailsettings = gShell.dotNet.Emailsettings;
using gShell.Cmdlets.Emailsettings;

namespace gShell.Cmdlets.Emailsettings.General
{
    [Cmdlet(VerbsCommon.Set, "GEmailSettingsGeneral",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGEmailSettingsGeneral : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 2)]
        [ValidateNotNullOrEmpty]
        public GeneralPageSizeEnum? PageSize { get; set; }

        [Parameter(Position = 3)]
        [ValidateNotNullOrEmpty]
        public bool? Shortcuts { get; set; }

        [Parameter(Position = 4)]
        [ValidateNotNullOrEmpty]
        public bool? Arrows { get; set; }

        [Parameter(Position = 5)]
        [ValidateNotNullOrEmpty]
        public bool? Snippets { get; set; }

        [Parameter(Position = 6)]
        [ValidateNotNullOrEmpty]
        public bool? Unicode { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (!PageSize.HasValue 
                && !Shortcuts.HasValue 
                && !Arrows.HasValue 
                && !Snippets.HasValue
                && !Unicode.HasValue)
            {
                WriteError(new ErrorRecord(null, (new Exception(
                    "Must use at least one of: PageSize, Shortcuts, Arrows, Snippets, Unicode"))));
            }

            var body = new Data.General();

            if (PageSize != null) body.PageSize = (int)(PageSize.Value);
            if (Shortcuts != null) body.Shortcuts = Shortcuts.Value;
            if (Arrows != null) body.Arrows = Arrows.Value;
            if (Snippets != null) body.Snippets = Snippets.Value;
            if (Unicode != null) body.Unicode = Unicode.Value;

            if (ShouldProcess("Email Settings General", "Set-GEmailSettingsGeneral"))
            {
                WriteObject(mainBase.general.Update(body, Domain, GetUserFromEmail(UserName)));
            }
        }
    }
}