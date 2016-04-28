using System;
using System.Management.Automation;

using Data = Google.Apis.Groupssettings.v1.Data;

using gShell.Cmdlets.Emailsettings;
using gShell.Cmdlets.Emailsettings.Language;

namespace gShell.Cmdlets.Groupssettings
{
    #region Enums
    public enum WhoCanJoinEnum
    {
        ALL_IN_DOMAIN_CAN_JOIN, ANYONE_CAN_JOIN, CAN_REQUEST_TO_JOIN, INVITED_CAN_JOIN
    }

    public enum WhoCanViewMembershipEnum
    {
        ALL_IN_DOMAIN_CAN_VIEW, ALL_MANAGERS_CAN_VIEW, ALL_MEMBERS_CAN_VIEW
    }

    public enum WhoCanViewGroupEnum
    {
        ALL_IN_DOMAIN_CAN_VIEW, ALL_MANAGERS_CAN_VIEW, ALL_MEMBERS_CAN_VIEW, ANYON_CAN_VIEW
    }

    public enum WhoCanInviteEnum
    {
        ALL_MANAGERS_CAN_INVITE, ALL_MEMBERS_CAN_INVITE, NONE_CAN_INVITE
    }

    public enum WhoCanAddEnum
    {
        ALL_MEMBERS_CAN_ADD, ALL_MANAGERS_CAN_ADD, NONE_CAN_ADD
    }

    public enum WhoCanPostMessageEnum
    {
        ALL_IN_DOMAIN_CAN_POST, ALL_MANAGERS_CAN_POST, ALL_MEMBERS_CAN_POST, ANYONE_CAN_POST, NONE_CAN_POST
    }

    public enum MessageModerationLevelEnum
    {
        MODERATE_ALL_MESSAGES, MODERATE_NEW_MEMBERS, MODERATE_NONE, MODERATE_NON_MEMBERS
    }

    public enum SpamModerationLevelEnum
    {
        ALLOW, MODERATE, SILENTLY_MODERATE, REJECT
    }

    public enum ReplyToEnum
    {
        REPLY_TO_CUSTOM, REPLY_TO_IGNORE, REPLY_TO_LIST, REPLY_TO_MANAGERS, REPLY_TO_OWNER, REPLY_TO_SENDER
    }

    public enum MessageDisplayFontEnum
    {
        DEFAULT_FONT, FIXED_WIDTH_FONT
    }

    public enum WhoCanLeaveGroupEnum
    {
        ALL_MANAGERS_CAN_LEAVE, ALL_MEMBERS_CAN_LEAVE, NONE_CAN_LEAVE
    }

    public enum WhoCanContactOwnerEnum
    {
        ALL_IN_DOMAIN_CAN_CONTACT, ALL_MANAGERS_CAN_CONTACT, ALL_MEMBERS_CAN_CONTACT, ANYONE_CAN_CONTACT
    }
    #endregion

    [Cmdlet(VerbsCommon.Get, "GGroupssettings",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGGroupssettings : GroupssettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string GroupId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Groups Settings", "Get-GGroupssettings"))
            {
                WriteObject(groups.Get(GroupId));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GGroupssettings",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGGroupssettings : GroupssettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string GroupId { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? AllowExternalMembers { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? AllowGoogleCommunication { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? AllowWebPosting { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? ArchiveOnly { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string CustomReplyTo { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string DefaultMessageDenyNotificationText { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Email { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? IncludeInGlobalAddressList { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? IsArchived { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public int? MaxMessageBytes { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? MembersCanPostAsTheGroup { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public MessageDisplayFontEnum? MessageDisplayFont { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public MessageModerationLevelEnum? MessageModerationLevel { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public LanguageLanguageAbbrevEnum? PrimaryLanguage { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string ReplyTo { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? SendMessageDenyNotification { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? ShowInGroupDirectory { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public SpamModerationLevelEnum? SpamModerationLevel { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public WhoCanAddEnum? WhoCanAdd { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public WhoCanContactOwnerEnum? WhoCanContactOwner { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public WhoCanInviteEnum? WhoCanInvite { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public WhoCanJoinEnum? WhoCanJoin { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public WhoCanLeaveGroupEnum? WhoCanLeaveGroup { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public WhoCanPostMessageEnum? WhoCanPostMessage { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public WhoCanViewGroupEnum? WhoCanViewGroup { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public WhoCanViewMembershipEnum? WhoCanViewMembership { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Groups()
            {
                AllowExternalMembers = this.AllowExternalMembers.HasValue ? this.AllowExternalMembers.Value.ToString() : null,
                AllowGoogleCommunication = this.AllowGoogleCommunication.HasValue ? this.AllowGoogleCommunication.Value.ToString() : null,
                AllowWebPosting = this.AllowWebPosting.HasValue ? this.AllowWebPosting.Value.ToString() : null,
                ArchiveOnly = this.ArchiveOnly.HasValue ? this.ArchiveOnly.Value.ToString() : null,
                CustomReplyTo = this.CustomReplyTo,
                DefaultMessageDenyNotificationText = this.DefaultMessageDenyNotificationText,
                Description = this.Description,
                Email = this.Email,
                IncludeInGlobalAddressList = this.IncludeInGlobalAddressList.HasValue ? this.IncludeInGlobalAddressList.Value.ToString() : null,
                IsArchived = this.IsArchived.HasValue ? this.IsArchived.Value.ToString() : null,
                Kind = "groupsSettings#groups",
                MaxMessageBytes = this.MaxMessageBytes,
                MembersCanPostAsTheGroup = this.MembersCanPostAsTheGroup.HasValue ? this.MembersCanPostAsTheGroup.Value.ToString() : null,
                MessageDisplayFont = this.MessageDisplayFont != null ? this.MessageDisplayFont.ToString() : null,
                MessageModerationLevel = this.MessageModerationLevel.HasValue ? this.MessageModerationLevel.Value.ToString() : null,
                Name = this.Name,
                PrimaryLanguage = this.PrimaryLanguage.HasValue ? SetGEmailSettingsLanguage.LookupLanguage(this.PrimaryLanguage.Value) : null,
                ReplyTo = this.ReplyTo,
                SendMessageDenyNotification = this.SendMessageDenyNotification.HasValue ? this.SendMessageDenyNotification.Value.ToString() : null,
                ShowInGroupDirectory = this.ShowInGroupDirectory.HasValue ? this.ShowInGroupDirectory.Value.ToString() : null,
                SpamModerationLevel = this.SpamModerationLevel.HasValue ? this.SpamModerationLevel.Value.ToString() : null,
                WhoCanAdd = this.WhoCanAdd.HasValue ? this.WhoCanAdd.Value.ToString() : null,
                WhoCanContactOwner = this.WhoCanContactOwner.HasValue ? this.WhoCanContactOwner.Value.ToString() : null,
                WhoCanInvite = this.WhoCanInvite.HasValue ? this.WhoCanInvite.Value.ToString() : null,
                WhoCanJoin = this.WhoCanJoin.HasValue ? this.WhoCanJoin.Value.ToString() : null,
                WhoCanLeaveGroup = this.WhoCanLeaveGroup.HasValue ? this.WhoCanLeaveGroup.Value.ToString() : null,
                WhoCanPostMessage = this.WhoCanPostMessage.HasValue ? this.WhoCanPostMessage.Value.ToString() : null,
                WhoCanViewGroup = this.WhoCanViewGroup.HasValue ? this.WhoCanViewGroup.Value.ToString() : null,
                WhoCanViewMembership = this.WhoCanViewMembership.HasValue ? this.WhoCanViewMembership.Value.ToString() : null
            };

            if (!AllowExternalMembers.HasValue
                && !AllowGoogleCommunication.HasValue
                && !AllowWebPosting.HasValue
                && !ArchiveOnly.HasValue
                && string.IsNullOrWhiteSpace(CustomReplyTo)
                && string.IsNullOrWhiteSpace(DefaultMessageDenyNotificationText)
                && string.IsNullOrWhiteSpace(Description)
                && string.IsNullOrWhiteSpace(Email)
                && !IncludeInGlobalAddressList.HasValue
                && !IsArchived.HasValue
                && !MaxMessageBytes.HasValue
                && !MembersCanPostAsTheGroup.HasValue
                && !MessageDisplayFont.HasValue
                && !MessageModerationLevel.HasValue
                && string.IsNullOrWhiteSpace(Name)
                && !PrimaryLanguage.HasValue
                && string.IsNullOrWhiteSpace(ReplyTo)
                && !SendMessageDenyNotification.HasValue
                && !ShowInGroupDirectory.HasValue
                && !SpamModerationLevel.HasValue
                && !WhoCanAdd.HasValue
                && !WhoCanContactOwner.HasValue
                && !WhoCanInvite.HasValue
                && !WhoCanJoin.HasValue
                && !WhoCanLeaveGroup.HasValue
                && !WhoCanPostMessage.HasValue
                && !WhoCanViewGroup.HasValue
                && !WhoCanViewMembership.HasValue)
            {
                WriteError(new ErrorRecord(new Exception(
                    "Must supply at least one parameter for Set-GGroupsettings"),
                    "", ErrorCategory.InvalidOperation, "GGroupsettings"));
            }

            if (ShouldProcess("Groups Settings", "Set-GGroupssettings"))
            {
                WriteObject(groups.Patch(body, GroupId));
            }
        }
    }
}
