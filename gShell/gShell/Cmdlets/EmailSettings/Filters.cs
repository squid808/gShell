using System;
using System.Management.Automation;
using System.Collections.Generic;

using Google.Apis.Auth.OAuth2;
using Data = Google.Apis.admin.Emailsettings.emailsettings_v1.Data;

using gEmailsettings = gShell.dotNet.Emailsettings;

namespace gShell.Cmdlets.Emailsettings.Filters
{
    [Cmdlet(VerbsCommon.New, "GEmailSettingsFilter",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGEmailSettingsFilter : EmailsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 2)]
        [ValidateNotNullOrEmpty]
        public string From { get; set; }

        [Parameter(Position = 3)]
        [ValidateNotNullOrEmpty]
        public string To { get; set; }

        [Parameter(Position = 4)]
        [ValidateNotNullOrEmpty]
        public string Subject { get; set; }

        [Parameter(Position = 5)]
        [ValidateNotNullOrEmpty]
        public string HasTheWords { get; set; }

        [Parameter(Position = 6)]
        [ValidateNotNullOrEmpty]
        public string DoesntHave { get; set; }

        [Parameter(Position = 7)]
        [ValidateNotNullOrEmpty]
        public bool? HasAttachment { get; set; }

        [Parameter(Position = 8)]
        [ValidateNotNullOrEmpty]
        public bool? ArchiveIt { get; set; }

        [Parameter(Position = 9)]
        [ValidateNotNullOrEmpty]
        public bool? MarkAsRead { get; set; }

        [Parameter(Position = 10)]
        [ValidateNotNullOrEmpty]
        public bool? StarIt { get; set; }

        [Parameter(Position = 11)]
        [ValidateNotNullOrEmpty]
        public string ApplyTheLabel { get; set; }

        [Parameter(Position = 12)]
        [ValidateNotNullOrEmpty]
        public string ForwardIt { get; set; }

        [Parameter(Position = 13)]
        [ValidateNotNullOrEmpty]
        public bool? DeleteIt { get; set; }

        [Parameter(Position = 14)]
        [ValidateNotNullOrEmpty]
        public bool? NeverSendItToSpam { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (!string.IsNullOrWhiteSpace(From)
                && !string.IsNullOrWhiteSpace(To)
                && !string.IsNullOrWhiteSpace(Subject)
                && !string.IsNullOrWhiteSpace(HasTheWords)
                && !string.IsNullOrWhiteSpace(DoesntHave)
                && HasAttachment.HasValue)
            {
                WriteError(new ErrorRecord(null, (new Exception(
                    "Must use at least one of: From, To, Subject, HasTheWords, DoesntHave or HasAttachment"))));
            }

            if (ArchiveIt.HasValue
                && MarkAsRead.HasValue
                && StarIt.HasValue
                && !string.IsNullOrWhiteSpace(ApplyTheLabel)
                && !string.IsNullOrWhiteSpace(ForwardIt)
                && DeleteIt.HasValue
                && NeverSendItToSpam.HasValue)
            {
                WriteError(new ErrorRecord(null, (new Exception(
                    "Must use at least one of: MarkAsRead, StarIt, ApplyTheLabel, ForwardIt, DeleteIt, or NeverSendItToSpam"))));
            }

            var body = new Data.Filter();

            if(!string.IsNullOrWhiteSpace(From)) { body.From = From; }
            if(!string.IsNullOrWhiteSpace(To)) { body.To = To; }
            if(!string.IsNullOrWhiteSpace(Subject)) { body.Subject = Subject; }
            if(!string.IsNullOrWhiteSpace(HasTheWords)) { body.HasTheWord = HasTheWords; }
            if(!string.IsNullOrWhiteSpace(DoesntHave)) { body.DoesNotHaveTheWord = DoesntHave; }
            if(HasAttachment.HasValue) { body.HasAttachment = HasAttachment.Value; }

            if(ArchiveIt.HasValue) { body.ShouldArchive = ArchiveIt.Value; }
            if(MarkAsRead.HasValue) { body.ShouldMarkAsRead = MarkAsRead.Value; }
            if(StarIt.HasValue) { body.ShouldStar = StarIt.Value; }
            if(!string.IsNullOrWhiteSpace(ApplyTheLabel)) { body.Label = ApplyTheLabel; }
            if(!string.IsNullOrWhiteSpace(ForwardIt)) { body.ForwardTo = ForwardIt; }
            if(DeleteIt.HasValue) { body.ShouldTrash = DeleteIt.Value; }
            if(NeverSendItToSpam.HasValue) { body.NeverSpam = NeverSendItToSpam.Value; }


            if (ShouldProcess("Email Settings Filter", "New-GEmailSettingsFilter"))
            {
                WriteObject(mainBase.filters.Insert(body, Domain, GetUserFromEmail(UserName)));
            }
        }
    }
}
