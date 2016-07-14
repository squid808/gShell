using System;
using System.Management.Automation;

using Data = Google.Apis.Groupssettings.v1.Data;

using gShell.Cmdlets.Emailsettings;
using gShell.Cmdlets.Emailsettings.Language;

namespace gShell.Cmdlets.Groupssettings
{
    /// <summary>A base class which provides support for service account integration and schema objects.</summary>
    public abstract class GroupssettingsServiceAccountBase : GroupssettingsBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The email account to be targeted by the service account.</para>
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string TargetUserEmail { get; set; }
        #endregion

        protected override void BeginProcessing()
        {
            gShellServiceAccount = TargetUserEmail;

            base.BeginProcessing();
        }
    }



    /// <summary>
    /// <para type="synopsis">Creates a new Groupssettings API Groups object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a Groups object which may be required as a parameter for some other Cmdlets in the Groupssettings API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Groupssettings.v1.Data.Groups</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Groupssettings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GGroupssettingsObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GGroupssettingsObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GGroupssettingsObj",
    SupportsShouldProcess = true)]
    [OutputType(typeof(Google.Apis.Groupssettings.v1.Data.Groups))]
    public class NewGGroupssettingsObj : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">Are external members allowed to join the group.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Are external members allowed to join the group.")]
        public string AllowExternalMembers { get; set; }

        /// <summary>
        /// <para type="description">Is google allowed to contact admins.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Is google allowed to contact admins.")]
        public string AllowGoogleCommunication { get; set; }

        /// <summary>
        /// <para type="description">If posting from web is allowed.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "If posting from web is allowed.")]
        public string AllowWebPosting { get; set; }

        /// <summary>
        /// <para type="description">If the group is archive only</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "If the group is archive only")]
        public string ArchiveOnly { get; set; }

        /// <summary>
        /// <para type="description">Default email to which reply to any message should go.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Default email to which reply to any message should go.")]
        public string CustomReplyTo { get; set; }

        /// <summary>
        /// <para type="description">Default message deny notification message</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Default message deny notification message")]
        public string DefaultMessageDenyNotificationText { get; set; }

        /// <summary>
        /// <para type="description">Description of the group</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Description of the group")]
        public string Description { get; set; }

        /// <summary>
        /// <para type="description">Email id of the group</para>
        /// </summary>
        [Parameter(Position = 7,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Email id of the group")]
        public string Email { get; set; }

        /// <summary>
        /// <para type="description">If this groups should be included in global address list or not.</para>
        /// </summary>
        [Parameter(Position = 8,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "If this groups should be included in global address list or not.")]
        public string IncludeInGlobalAddressList { get; set; }

        /// <summary>
        /// <para type="description">If the contents of the group are archived.</para>
        /// </summary>
        [Parameter(Position = 9,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "If the contents of the group are archived.")]
        public string IsArchived { get; set; }

        /// <summary>
        /// <para type="description">Maximum message size allowed.</para>
        /// </summary>
        [Parameter(Position = 10,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Maximum message size allowed.")]
        public System.Nullable<int> MaxMessageBytes { get; set; }

        /// <summary>
        /// <para type="description">Can members post using the group email address.</para>
        /// </summary>
        [Parameter(Position = 11,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Can members post using the group email address.")]
        public string MembersCanPostAsTheGroup { get; set; }

        /// <summary>
        /// <para type="description">Default message display font. Possible values are: DEFAULT_FONT FIXED_WIDTH_FONT</para>
        /// </summary>
        [Parameter(Position = 12,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Default message display font. Possible values are: DEFAULT_FONT FIXED_WIDTH_FONT")]
        public string MessageDisplayFont { get; set; }

        /// <summary>
        /// <para type="description">Moderation level for messages. Possible values are: MODERATE_ALL_MESSAGES MODERATE_NON_MEMBERS MODERATE_NEW_MEMBERS MODERATE_NONE</para>
        /// </summary>
        [Parameter(Position = 13,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Moderation level for messages. Possible values are: MODERATE_ALL_MESSAGES MODERATE_NON_MEMBERS MODERATE_NEW_MEMBERS MODERATE_NONE")]
        public string MessageModerationLevel { get; set; }

        /// <summary>
        /// <para type="description">Name of the Group</para>
        /// </summary>
        [Parameter(Position = 14,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of the Group")]
        public string Name { get; set; }

        /// <summary>
        /// <para type="description">Primary language for the group.</para>
        /// </summary>
        [Parameter(Position = 15,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Primary language for the group.")]
        public string PrimaryLanguage { get; set; }

        /// <summary>
        /// <para type="description">Whome should the default reply to a message go to. Possible values are: REPLY_TO_CUSTOM REPLY_TO_SENDER REPLY_TO_LIST REPLY_TO_OWNER REPLY_TO_IGNORE REPLY_TO_MANAGERS</para>
        /// </summary>
        [Parameter(Position = 16,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Whome should the default reply to a message go to. Possible values are: REPLY_TO_CUSTOM REPLY_TO_SENDER REPLY_TO_LIST REPLY_TO_OWNER REPLY_TO_IGNORE REPLY_TO_MANAGERS")]
        public string ReplyTo { get; set; }

        /// <summary>
        /// <para type="description">Should the member be notified if his message is denied by owner.</para>
        /// </summary>
        [Parameter(Position = 17,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Should the member be notified if his message is denied by owner.")]
        public string SendMessageDenyNotification { get; set; }

        /// <summary>
        /// <para type="description">Is the group listed in groups directory</para>
        /// </summary>
        [Parameter(Position = 18,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Is the group listed in groups directory")]
        public string ShowInGroupDirectory { get; set; }

        /// <summary>
        /// <para type="description">Moderation level for messages detected as spam. Possible values are: ALLOW MODERATE SILENTLY_MODERATE REJECT</para>
        /// </summary>
        [Parameter(Position = 19,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Moderation level for messages detected as spam. Possible values are: ALLOW MODERATE SILENTLY_MODERATE REJECT")]
        public string SpamModerationLevel { get; set; }

        /// <summary>
        /// <para type="description">Permissions to add members. Possible values are: ALL_MANAGERS_CAN_ADD ALL_MEMBERS_CAN_ADD NONE_CAN_ADD</para>
        /// </summary>
        [Parameter(Position = 20,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Permissions to add members. Possible values are: ALL_MANAGERS_CAN_ADD ALL_MEMBERS_CAN_ADD NONE_CAN_ADD")]
        public string WhoCanAdd { get; set; }

        /// <summary>
        /// <para type="description">Permission to contact owner of the group via web UI. Possible values are: ANYONE_CAN_CONTACT ALL_IN_DOMAIN_CAN_CONTACT ALL_MEMBERS_CAN_CONTACT ALL_MANAGERS_CAN_CONTACT</para>
        /// </summary>
        [Parameter(Position = 21,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Permission to contact owner of the group via web UI. Possible values are: ANYONE_CAN_CONTACT ALL_IN_DOMAIN_CAN_CONTACT ALL_MEMBERS_CAN_CONTACT ALL_MANAGERS_CAN_CONTACT")]
        public string WhoCanContactOwner { get; set; }

        /// <summary>
        /// <para type="description">Permissions to invite members. Possible values are: ALL_MEMBERS_CAN_INVITE ALL_MANAGERS_CAN_INVITE NONE_CAN_INVITE</para>
        /// </summary>
        [Parameter(Position = 22,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Permissions to invite members. Possible values are: ALL_MEMBERS_CAN_INVITE ALL_MANAGERS_CAN_INVITE NONE_CAN_INVITE")]
        public string WhoCanInvite { get; set; }

        /// <summary>
        /// <para type="description">Permissions to join the group. Possible values are: ANYONE_CAN_JOIN ALL_IN_DOMAIN_CAN_JOIN INVITED_CAN_JOIN CAN_REQUEST_TO_JOIN</para>
        /// </summary>
        [Parameter(Position = 23,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Permissions to join the group. Possible values are: ANYONE_CAN_JOIN ALL_IN_DOMAIN_CAN_JOIN INVITED_CAN_JOIN CAN_REQUEST_TO_JOIN")]
        public string WhoCanJoin { get; set; }

        /// <summary>
        /// <para type="description">Permission to leave the group. Possible values are: ALL_MANAGERS_CAN_LEAVE ALL_MEMBERS_CAN_LEAVE NONE_CAN_LEAVE</para>
        /// </summary>
        [Parameter(Position = 24,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Permission to leave the group. Possible values are: ALL_MANAGERS_CAN_LEAVE ALL_MEMBERS_CAN_LEAVE NONE_CAN_LEAVE")]
        public string WhoCanLeaveGroup { get; set; }

        /// <summary>
        /// <para type="description">Permissions to post messages to the group. Possible values are: NONE_CAN_POST ALL_MANAGERS_CAN_POST ALL_MEMBERS_CAN_POST ALL_IN_DOMAIN_CAN_POST ANYONE_CAN_POST</para>
        /// </summary>
        [Parameter(Position = 25,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Permissions to post messages to the group. Possible values are: NONE_CAN_POST ALL_MANAGERS_CAN_POST ALL_MEMBERS_CAN_POST ALL_IN_DOMAIN_CAN_POST ANYONE_CAN_POST")]
        public string WhoCanPostMessage { get; set; }

        /// <summary>
        /// <para type="description">Permissions to view group. Possible values are: ANYONE_CAN_VIEW ALL_IN_DOMAIN_CAN_VIEW ALL_MEMBERS_CAN_VIEW ALL_MANAGERS_CAN_VIEW</para>
        /// </summary>
        [Parameter(Position = 26,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Permissions to view group. Possible values are: ANYONE_CAN_VIEW ALL_IN_DOMAIN_CAN_VIEW ALL_MEMBERS_CAN_VIEW ALL_MANAGERS_CAN_VIEW")]
        public string WhoCanViewGroup { get; set; }

        /// <summary>
        /// <para type="description">Permissions to view membership. Possible values are: ALL_IN_DOMAIN_CAN_VIEW ALL_MEMBERS_CAN_VIEW ALL_MANAGERS_CAN_VIEW</para>
        /// </summary>
        [Parameter(Position = 27,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Permissions to view membership. Possible values are: ALL_IN_DOMAIN_CAN_VIEW ALL_MEMBERS_CAN_VIEW ALL_MANAGERS_CAN_VIEW")]
        public string WhoCanViewMembership { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.Groupssettings.v1.Data.Groups()
            {
                AllowExternalMembers = this.AllowExternalMembers,
                AllowGoogleCommunication = this.AllowGoogleCommunication,
                AllowWebPosting = this.AllowWebPosting,
                ArchiveOnly = this.ArchiveOnly,
                CustomReplyTo = this.CustomReplyTo,
                DefaultMessageDenyNotificationText = this.DefaultMessageDenyNotificationText,
                Description = this.Description,
                Email = this.Email,
                IncludeInGlobalAddressList = this.IncludeInGlobalAddressList,
                IsArchived = this.IsArchived,
                MaxMessageBytes = this.MaxMessageBytes,
                MembersCanPostAsTheGroup = this.MembersCanPostAsTheGroup,
                MessageDisplayFont = this.MessageDisplayFont,
                MessageModerationLevel = this.MessageModerationLevel,
                Name = this.Name,
                PrimaryLanguage = this.PrimaryLanguage,
                ReplyTo = this.ReplyTo,
                SendMessageDenyNotification = this.SendMessageDenyNotification,
                ShowInGroupDirectory = this.ShowInGroupDirectory,
                SpamModerationLevel = this.SpamModerationLevel,
                WhoCanAdd = this.WhoCanAdd,
                WhoCanContactOwner = this.WhoCanContactOwner,
                WhoCanInvite = this.WhoCanInvite,
                WhoCanJoin = this.WhoCanJoin,
                WhoCanLeaveGroup = this.WhoCanLeaveGroup,
                WhoCanPostMessage = this.WhoCanPostMessage,
                WhoCanViewGroup = this.WhoCanViewGroup,
                WhoCanViewMembership = this.WhoCanViewMembership,
            };

            if (ShouldProcess("Groups"))
            {
                WriteObject(body);
            }
        }
    }
}

namespace gShell.Cmdlets.Groupssettings.Groups
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

    /// <summary>
    /// <para type="synopsis">Gets one resource by id.</para>
    /// <para type="description">Gets one resource by id.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Groupssettings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GGroupssettings -GroupUniqueId $SomeGroupUniqueIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GGroupssettings">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GGroupssettings",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GGroupssettings")]
    public class GetGGroupssettings : GroupssettingsBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The resource ID</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The resource ID")]
        [ValidateNotNullOrEmpty]
        public string GroupUniqueId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Groups Settings", "Get-GGroupssettings"))
            {
                WriteObject(groups.Get(GroupUniqueId));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Updates an existing resource. This method supports Set semantics.</para>
    /// <para type="description">Updates an existing resource. This method supports Set semantics.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Groupssettings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GGroupssettings -GroupUniqueId $SomeGroupUniqueIdString -GroupsBody $SomeGroupsObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GGroupssettings">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GGroupssettings",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GGroupssettings")]
    public class SetGGroupssettings : GroupssettingsBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The resource ID</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The resource ID")]
        [ValidateNotNullOrEmpty]
        public string GroupUniqueId { get; set; }

        /// <summary>
        /// <para type="description">JSON template for Group resource</para>
        /// </summary>
        [Parameter(Position = 1,
        ParameterSetName = "Body",
        Mandatory = false,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "JSON template for Group resource")]
        public Data.Groups GroupsBody { get; set; }

        /// <summary>
        /// <para type="description">Are external members allowed to join the group.</para>
        /// </summary>
        [Parameter(Position = 1,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Are external members allowed to join the group.")]
        public bool? AllowExternalMembers { get; set; }

        /// <summary>
        /// <para type="description">Is google allowed to contact admins.</para>
        /// </summary>
        [Parameter(Position = 2,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Is google allowed to contact admins.")]
        public bool? AllowGoogleCommunication { get; set; }

        /// <summary>
        /// <para type="description">If posting from web is allowed.</para>
        /// </summary>
        [Parameter(Position = 3,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "If posting from web is allowed.")]
        public bool? AllowWebPosting { get; set; }

        /// <summary>
        /// <para type="description">If the group is archive only</para>
        /// </summary>
        [Parameter(Position = 4,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "If the group is archive only")]
        public bool? ArchiveOnly { get; set; }

        /// <summary>
        /// <para type="description">Default email to which reply to any message should go.</para>
        /// </summary>
        [Parameter(Position = 5,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Default email to which reply to any message should go.")]
        [ValidateNotNullOrEmpty]
        public string CustomReplyTo { get; set; }

        /// <summary>
        /// <para type="description">Default message deny notification message</para>
        /// </summary>
        [Parameter(Position = 6,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Default message deny notification message")]
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string DefaultMessageDenyNotificationText { get; set; }

        /// <summary>
        /// <para type="description">Description of the group</para>
        /// </summary>
        [Parameter(Position = 7,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Description of the group")]
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        /// <summary>
        /// <para type="description">Email id of the group</para>
        /// </summary>
        [Parameter(Position = 8,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Email id of the group")]
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Email { get; set; }

        /// <summary>
        /// <para type="description">If this groups should be included in global address list or not.</para>
        /// </summary>
        [Parameter(Position = 9,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "If this groups should be included in global address list or not.")]
        public bool? IncludeInGlobalAddressList { get; set; }

        /// <summary>
        /// <para type="description">If the contents of the group are archived.</para>
        /// </summary>
        [Parameter(Position = 10,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "If the contents of the group are archived.")]
        public bool? IsArchived { get; set; }

        /// <summary>
        /// <para type="description">Maximum message size allowed.</para>
        /// </summary>
        [Parameter(Position = 11,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Maximum message size allowed.")]
        public int? MaxMessageBytes { get; set; }

        /// <summary>
        /// <para type="description">Can members post using the group email address.</para>
        /// </summary>
        [Parameter(Position = 12,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Can members post using the group email address.")]
        public bool? MembersCanPostAsTheGroup { get; set; }

        /// <summary>
        /// <para type="description">Default message display font. Possible values are: DEFAULT_FONT FIXED_WIDTH_FONT</para>
        /// </summary>
        [Parameter(Position = 13,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Default message display font. Possible values are: DEFAULT_FONT FIXED_WIDTH_FONT")]
        public MessageDisplayFontEnum? MessageDisplayFont { get; set; }

        /// <summary>
        /// <para type="description">Moderation level for messages. Possible values are: MODERATE_ALL_MESSAGES MODERATE_NON_MEMBERS MODERATE_NEW_MEMBERS MODERATE_NONE</para>
        /// </summary>
        [Parameter(Position = 14,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Moderation level for messages. Possible values are: MODERATE_ALL_MESSAGES MODERATE_NON_MEMBERS MODERATE_NEW_MEMBERS MODERATE_NONE")]
        public MessageModerationLevelEnum? MessageModerationLevel { get; set; }

        /// <summary>
        /// <para type="description">Name of the Group</para>
        /// </summary>
        [Parameter(Position = 15,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of the Group")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// <para type="description">Primary language for the group.</para>
        /// </summary>
        [Parameter(Position = 16,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Primary language for the group.")]
        public LanguageLanguageAbbrevEnum? PrimaryLanguage { get; set; }

        /// <summary>
        /// <para type="description">Whome should the default reply to a message go to. Possible values are: REPLY_TO_CUSTOM REPLY_TO_SENDER REPLY_TO_LIST REPLY_TO_OWNER REPLY_TO_IGNORE REPLY_TO_MANAGERS</para>
        /// </summary>
        [Parameter(Position = 17,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Whome should the default reply to a message go to. Possible values are: REPLY_TO_CUSTOM REPLY_TO_SENDER REPLY_TO_LIST REPLY_TO_OWNER REPLY_TO_IGNORE REPLY_TO_MANAGERS")]
        [ValidateNotNullOrEmpty]
        public string ReplyTo { get; set; }

        /// <summary>
        /// <para type="description">Should the member be notified if his message is denied by owner.</para>
        /// </summary>
        [Parameter(Position = 18,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Should the member be notified if his message is denied by owner.")]
        public bool? SendMessageDenyNotification { get; set; }

        /// <summary>
        /// <para type="description">Is the group listed in groups directory</para>
        /// </summary>
        [Parameter(Position = 19,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Is the group listed in groups directory")]
        public bool? ShowInGroupDirectory { get; set; }

        /// <summary>
        /// <para type="description">Moderation level for messages detected as spam. Possible values are: ALLOW MODERATE SILENTLY_MODERATE REJECT</para>
        /// </summary>
        [Parameter(Position = 20,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Moderation level for messages detected as spam. Possible values are: ALLOW MODERATE SILENTLY_MODERATE REJECT")]
        public SpamModerationLevelEnum? SpamModerationLevel { get; set; }

        /// <summary>
        /// <para type="description">Permissions to add members. Possible values are: ALL_MANAGERS_CAN_ADD ALL_MEMBERS_CAN_ADD NONE_CAN_ADD</para>
        /// </summary>
        [Parameter(Position = 21,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Permissions to add members. Possible values are: ALL_MANAGERS_CAN_ADD ALL_MEMBERS_CAN_ADD NONE_CAN_ADD")]
        public WhoCanAddEnum? WhoCanAdd { get; set; }

        /// <summary>
        /// <para type="description">Permission to contact owner of the group via web UI. Possible values are: ANYONE_CAN_CONTACT ALL_IN_DOMAIN_CAN_CONTACT ALL_MEMBERS_CAN_CONTACT ALL_MANAGERS_CAN_CONTACT</para>
        /// </summary>
        [Parameter(Position = 22,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Permission to contact owner of the group via web UI. Possible values are: ANYONE_CAN_CONTACT ALL_IN_DOMAIN_CAN_CONTACT ALL_MEMBERS_CAN_CONTACT ALL_MANAGERS_CAN_CONTACT")]
        public WhoCanContactOwnerEnum? WhoCanContactOwner { get; set; }

        /// <summary>
        /// <para type="description">Permissions to invite members. Possible values are: ALL_MEMBERS_CAN_INVITE ALL_MANAGERS_CAN_INVITE NONE_CAN_INVITE</para>
        /// </summary>
        [Parameter(Position = 23,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Permissions to invite members. Possible values are: ALL_MEMBERS_CAN_INVITE ALL_MANAGERS_CAN_INVITE NONE_CAN_INVITE")]
        public WhoCanInviteEnum? WhoCanInvite { get; set; }

        /// <summary>
        /// <para type="description">Permissions to join the group. Possible values are: ANYONE_CAN_JOIN ALL_IN_DOMAIN_CAN_JOIN INVITED_CAN_JOIN CAN_REQUEST_TO_JOIN</para>
        /// </summary>
        [Parameter(Position = 24,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Permissions to join the group. Possible values are: ANYONE_CAN_JOIN ALL_IN_DOMAIN_CAN_JOIN INVITED_CAN_JOIN CAN_REQUEST_TO_JOIN")]
        public WhoCanJoinEnum? WhoCanJoin { get; set; }

        /// <summary>
        /// <para type="description">Permission to leave the group. Possible values are: ALL_MANAGERS_CAN_LEAVE ALL_MEMBERS_CAN_LEAVE NONE_CAN_LEAVE</para>
        /// </summary>
        [Parameter(Position = 25,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Permission to leave the group. Possible values are: ALL_MANAGERS_CAN_LEAVE ALL_MEMBERS_CAN_LEAVE NONE_CAN_LEAVE")]
        public WhoCanLeaveGroupEnum? WhoCanLeaveGroup { get; set; }

        /// <summary>
        /// <para type="description">Permissions to post messages to the group. Possible values are: NONE_CAN_POST ALL_MANAGERS_CAN_POST ALL_MEMBERS_CAN_POST ALL_IN_DOMAIN_CAN_POST ANYONE_CAN_POST</para>
        /// </summary>
        [Parameter(Position = 26,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Permissions to post messages to the group. Possible values are: NONE_CAN_POST ALL_MANAGERS_CAN_POST ALL_MEMBERS_CAN_POST ALL_IN_DOMAIN_CAN_POST ANYONE_CAN_POST")]
        public WhoCanPostMessageEnum? WhoCanPostMessage { get; set; }

        /// <summary>
        /// <para type="description">Permissions to view group. Possible values are: ANYONE_CAN_VIEW ALL_IN_DOMAIN_CAN_VIEW ALL_MEMBERS_CAN_VIEW ALL_MANAGERS_CAN_VIEW</para>
        /// </summary>
        [Parameter(Position = 27,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Permissions to view group. Possible values are: ANYONE_CAN_VIEW ALL_IN_DOMAIN_CAN_VIEW ALL_MEMBERS_CAN_VIEW ALL_MANAGERS_CAN_VIEW")]
        public WhoCanViewGroupEnum? WhoCanViewGroup { get; set; }

        /// <summary>
        /// <para type="description">Permissions to view membership. Possible values are: ALL_IN_DOMAIN_CAN_VIEW ALL_MEMBERS_CAN_VIEW ALL_MANAGERS_CAN_VIEW</para>
        /// </summary>
        [Parameter(Position = 28,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Permissions to view membership. Possible values are: ALL_IN_DOMAIN_CAN_VIEW ALL_MEMBERS_CAN_VIEW ALL_MANAGERS_CAN_VIEW")]
        public WhoCanViewMembershipEnum? WhoCanViewMembership { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ParameterSetName == "Params")
            {
                var body = new Data.Groups()
                {
                    AllowExternalMembers =
                        this.AllowExternalMembers.HasValue ? this.AllowExternalMembers.Value.ToString() : null,
                    AllowGoogleCommunication =
                        this.AllowGoogleCommunication.HasValue ? this.AllowGoogleCommunication.Value.ToString() : null,
                    AllowWebPosting = this.AllowWebPosting.HasValue ? this.AllowWebPosting.Value.ToString() : null,
                    ArchiveOnly = this.ArchiveOnly.HasValue ? this.ArchiveOnly.Value.ToString() : null,
                    CustomReplyTo = this.CustomReplyTo,
                    DefaultMessageDenyNotificationText = this.DefaultMessageDenyNotificationText,
                    Description = this.Description,
                    Email = this.Email,
                    IncludeInGlobalAddressList =
                        this.IncludeInGlobalAddressList.HasValue
                            ? this.IncludeInGlobalAddressList.Value.ToString()
                            : null,
                    IsArchived = this.IsArchived.HasValue ? this.IsArchived.Value.ToString() : null,
                    Kind = "groupsSettings#groups",
                    MaxMessageBytes = this.MaxMessageBytes,
                    MembersCanPostAsTheGroup =
                        this.MembersCanPostAsTheGroup.HasValue ? this.MembersCanPostAsTheGroup.Value.ToString() : null,
                    MessageDisplayFont = this.MessageDisplayFont != null ? this.MessageDisplayFont.ToString() : null,
                    MessageModerationLevel =
                        this.MessageModerationLevel.HasValue ? this.MessageModerationLevel.Value.ToString() : null,
                    Name = this.Name,
                    PrimaryLanguage =
                        this.PrimaryLanguage.HasValue
                            ? SetGEmailSettingsLanguage.LookupLanguage(this.PrimaryLanguage.Value)
                            : null,
                    ReplyTo = this.ReplyTo,
                    SendMessageDenyNotification =
                        this.SendMessageDenyNotification.HasValue
                            ? this.SendMessageDenyNotification.Value.ToString()
                            : null,
                    ShowInGroupDirectory =
                        this.ShowInGroupDirectory.HasValue ? this.ShowInGroupDirectory.Value.ToString() : null,
                    SpamModerationLevel =
                        this.SpamModerationLevel.HasValue ? this.SpamModerationLevel.Value.ToString() : null,
                    WhoCanAdd = this.WhoCanAdd.HasValue ? this.WhoCanAdd.Value.ToString() : null,
                    WhoCanContactOwner =
                        this.WhoCanContactOwner.HasValue ? this.WhoCanContactOwner.Value.ToString() : null,
                    WhoCanInvite = this.WhoCanInvite.HasValue ? this.WhoCanInvite.Value.ToString() : null,
                    WhoCanJoin = this.WhoCanJoin.HasValue ? this.WhoCanJoin.Value.ToString() : null,
                    WhoCanLeaveGroup = this.WhoCanLeaveGroup.HasValue ? this.WhoCanLeaveGroup.Value.ToString() : null,
                    WhoCanPostMessage = this.WhoCanPostMessage.HasValue ? this.WhoCanPostMessage.Value.ToString() : null,
                    WhoCanViewGroup = this.WhoCanViewGroup.HasValue ? this.WhoCanViewGroup.Value.ToString() : null,
                    WhoCanViewMembership =
                        this.WhoCanViewMembership.HasValue ? this.WhoCanViewMembership.Value.ToString() : null
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
                    WriteObject(groups.Patch(body, GroupUniqueId));
                }
            }
            else
            {
                if (ShouldProcess("Groups Settings", "Set-GGroupssettings"))
                {
                    WriteObject(groups.Patch(GroupsBody, GroupUniqueId));
                }
            }
        }
    }
}
