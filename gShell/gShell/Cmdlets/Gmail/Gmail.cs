using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

using Google.Apis.Gmail.v1;
using Data = Google.Apis.Gmail.v1.Data;

using gGmail = gShell.dotNet.Gmail;

namespace gShell.Cmdlets.Gmail
{
    /// <summary>
    /// <para type="synopsis">Creates a new Gmail API AutoForwarding object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a AutoForwarding object which may be required as a parameter for some other Cmdlets in the Gmail API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Gmail.v1.Data.AutoForwarding</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GGmailAutoForwardingObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GGmailAutoForwardingObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GGmailAutoForwardingObj",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/New-GGmailAutoForwardingObj")]
    [OutputType(typeof(Google.Apis.Gmail.v1.Data.AutoForwarding))]
    public class NewGGmailAutoForwardingObjCommand : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">The state that a message should be left in after it has been forwarded.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The state that a message should be left in after it has been forwarded.")]
        public string Disposition { get; set; }

        /// <summary>
        /// <para type="description">Email address to which all incoming messages are forwarded. This email address must be a verified member of the forwarding addresses.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Email address to which all incoming messages are forwarded. This email address must be a verified member of the forwarding addresses.")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// <para type="description">Whether all incoming mail is automatically forwarded to another address.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Whether all incoming mail is automatically forwarded to another address.")]
        public System.Nullable<bool> Enabled { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.Gmail.v1.Data.AutoForwarding()
            {
                Disposition = this.Disposition,
                EmailAddress = this.EmailAddress,
                Enabled = this.Enabled,
            };

            if (ShouldProcess("AutoForwarding"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Gmail API Filter object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a Filter object which may be required as a parameter for some other Cmdlets in the Gmail API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Gmail.v1.Data.Filter</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GGmailFilterObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GGmailFilterObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GGmailFilterObj",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/New-GGmailFilterObj")]
    [OutputType(typeof(Google.Apis.Gmail.v1.Data.Filter))]
    public class NewGGmailFilterObjCommand : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">Action that the filter performs.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Action that the filter performs.")]
        public Data.FilterAction Action { get; set; }

        /// <summary>
        /// <para type="description">Matching criteria for the filter.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Matching criteria for the filter.")]
        public Data.FilterCriteria Criteria { get; set; }

        /// <summary>
        /// <para type="description">The server assigned ID of the filter.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The server assigned ID of the filter.")]
        public string Id { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.Gmail.v1.Data.Filter()
            {
                Action = this.Action,
                Criteria = this.Criteria,
                Id = this.Id,
            };

            if (ShouldProcess("Filter"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Gmail API FilterAction object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a FilterAction object which may be required as a parameter for some other Cmdlets in the Gmail API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Gmail.v1.Data.FilterAction</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GGmailFilterActionObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GGmailFilterActionObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GGmailFilterActionObj",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/New-GGmailFilterActionObj")]
    [OutputType(typeof(Google.Apis.Gmail.v1.Data.FilterAction))]
    public class NewGGmailFilterActionObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">List of labels to add to the message.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "List of labels to add to the message.")]
        public string[] AddLabelIds { get; set; }

        /// <summary>
        /// <para type="description">Email address that the message should be forwarded to.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Email address that the message should be forwarded to.")]
        public string Forward { get; set; }

        /// <summary>
        /// <para type="description">List of labels to remove from the message.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "List of labels to remove from the message.")]
        public string[] RemoveLabelIds { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.Gmail.v1.Data.FilterAction()
            {
                AddLabelIds = this.AddLabelIds,
                Forward = this.Forward,
                RemoveLabelIds = this.RemoveLabelIds,
            };

            if (ShouldProcess("FilterAction"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Gmail API FilterCriteria object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a FilterCriteria object which may be required as a parameter for some other Cmdlets in the Gmail API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Gmail.v1.Data.FilterCriteria</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GGmailFilterCriteriaObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GGmailFilterCriteriaObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GGmailFilterCriteriaObj",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/New-GGmailFilterCriteriaObj")]
    [OutputType(typeof(Google.Apis.Gmail.v1.Data.FilterCriteria))]
    public class NewGGmailFilterCriteriaObjCommand : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">Whether the response should exclude chats.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Whether the response should exclude chats.")]
        public System.Nullable<bool> ExcludeChats { get; set; }

        /// <summary>
        /// <para type="description">The sender's display name or email address.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The sender's display name or email address.")]
        public string From { get; set; }

        /// <summary>
        /// <para type="description">Whether the message has any attachment.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Whether the message has any attachment.")]
        public System.Nullable<bool> HasAttachment { get; set; }

        /// <summary>
        /// <para type="description">Only return messages not matching the specified query. Supports the same query format as the Gmail search box. For example, "from:someuser@example.com rfc822msgid: is:unread".</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Only return messages not matching the specified query. Supports the same query format as the Gmail search box. For example, \"from:someuser@example.com rfc822msgid: is:unread\".")]
        public string NegatedQuery { get; set; }

        /// <summary>
        /// <para type="description">Only return messages matching the specified query. Supports the same query format as the Gmail search box. For example, "from:someuser@example.com rfc822msgid: is:unread".</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Only return messages matching the specified query. Supports the same query format as the Gmail search box. For example, \"from:someuser@example.com rfc822msgid: is:unread\".")]
        public string Query { get; set; }

        /// <summary>
        /// <para type="description">The size of the entire RFC822 message in bytes, including all headers and attachments.</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The size of the entire RFC822 message in bytes, including all headers and attachments.")]
        public System.Nullable<int> Size { get; set; }

        /// <summary>
        /// <para type="description">How the message size in bytes should be in relation to the size field.</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "How the message size in bytes should be in relation to the size field.")]
        public string SizeComparison { get; set; }

        /// <summary>
        /// <para type="description">Case-insensitive phrase found in the message's subject. Trailing and leading whitespace are be trimmed and adjacent spaces are collapsed.</para>
        /// </summary>
        [Parameter(Position = 7,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Case-insensitive phrase found in the message's subject. Trailing and leading whitespace are be trimmed and adjacent spaces are collapsed.")]
        public string Subject { get; set; }

        /// <summary>
        /// <para type="description">The recipient's display name or email address. Includes recipients in the "to", "cc", and "bcc" header fields. You can use simply the local part of the email address. For example, "example" and "example@" both match "example@gmail.com". This field is case-insensitive.</para>
        /// </summary>
        [Parameter(Position = 8,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The recipient's display name or email address. Includes recipients in the \"to\", \"cc\", and \"bcc\" header fields. You can use simply the local part of the email address. For example, \"example\" and \"example@\" both match \"example@gmail.com\". This field is case-insensitive.")]
        public string To { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.Gmail.v1.Data.FilterCriteria()
            {
                ExcludeChats = this.ExcludeChats,
                From = this.From,
                HasAttachment = this.HasAttachment,
                NegatedQuery = this.NegatedQuery,
                Query = this.Query,
                Size = this.Size,
                SizeComparison = this.SizeComparison,
                Subject = this.Subject,
                To = this.To,
            };

            if (ShouldProcess("FilterCriteria"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Gmail API ImapSettings object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a ImapSettings object which may be required as a parameter for some other Cmdlets in the Gmail API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Gmail.v1.Data.ImapSettings</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GGmailImapSettingsObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GGmailImapSettingsObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GGmailImapSettingsObj",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/New-GGmailImapSettingsObj")]
    [OutputType(typeof(Google.Apis.Gmail.v1.Data.ImapSettings))]
    public class NewGGmailImapSettingsObjCommand : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">If this value is true, Gmail will immediately expunge a message when it is marked as deleted in IMAP. Otherwise, Gmail will wait for an update from the client before expunging messages marked as deleted.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "If this value is true, Gmail will immediately expunge a message when it is marked as deleted in IMAP. Otherwise, Gmail will wait for an update from the client before expunging messages marked as deleted.")]
        public System.Nullable<bool> AutoExpunge { get; set; }

        /// <summary>
        /// <para type="description">Whether IMAP is enabled for the account.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Whether IMAP is enabled for the account.")]
        public System.Nullable<bool> Enabled { get; set; }

        /// <summary>
        /// <para type="description">The action that will be executed on a message when it is marked as deleted and expunged from the last visible IMAP folder.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The action that will be executed on a message when it is marked as deleted and expunged from the last visible IMAP folder.")]
        public string ExpungeBehavior { get; set; }

        /// <summary>
        /// <para type="description">An optional limit on the number of messages that an IMAP folder may contain. Legal values are 0, 1000, 2000, 5000 or 10000. A value of zero is interpreted to mean that there is no limit.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "An optional limit on the number of messages that an IMAP folder may contain. Legal values are 0, 1000, 2000, 5000 or 10000. A value of zero is interpreted to mean that there is no limit.")]
        public System.Nullable<int> MaxFolderSize { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.Gmail.v1.Data.ImapSettings()
            {
                AutoExpunge = this.AutoExpunge,
                Enabled = this.Enabled,
                ExpungeBehavior = this.ExpungeBehavior,
                MaxFolderSize = this.MaxFolderSize,
            };

            if (ShouldProcess("ImapSettings"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Gmail API Message object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a Message object which may be required as a parameter for some other Cmdlets in the Gmail API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Gmail.v1.Data.Message</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GGmailMessageObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GGmailMessageObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GGmailMessageObj",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/New-GGmailMessageObj")]
    [OutputType(typeof(Google.Apis.Gmail.v1.Data.Message))]
    public class NewGGmailMessageObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">The ID of the last history record that modified this message.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The ID of the last history record that modified this message.")]
        public ulong? HistoryId { get; set; }

        /// <summary>
        /// <para type="description">The immutable ID of the message.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The immutable ID of the message.")]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">The internal message creation timestamp (epoch ms), which determines ordering in the inbox. For normal SMTP-received email, this represents the time the message was originally accepted by Google, which is more reliable than the Date header. However, for API-migrated mail, it can be configured by client to be based on the Date header.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The internal message creation timestamp (epoch ms), which determines ordering in the inbox. For normal SMTP-received email, this represents the time the message was originally accepted by Google, which is more reliable than the Date header. However, for API-migrated mail, it can be configured by client to be based on the Date header.")]
        public long? InternalDate { get; set; }

        /// <summary>
        /// <para type="description">List of IDs of labels applied to this message.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "List of IDs of labels applied to this message.")]
        public string[] LabelIds { get; set; }

        /// <summary>
        /// <para type="description">The parsed email structure in the message parts.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The parsed email structure in the message parts.")]
        public Data.MessagePart Payload { get; set; }

        /// <summary>
        /// <para type="description">The entire email message in an RFC 2822 formatted and base64url encoded string. Returned in messages.get and drafts.get responses when the format=RAW parameter is supplied.</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The entire email message in an RFC 2822 formatted and base64url encoded string. Returned in messages.get and drafts.get responses when the format=RAW parameter is supplied.")]
        public string Raw { get; set; }

        /// <summary>
        /// <para type="description">Estimated size in bytes of the message.</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Estimated size in bytes of the message.")]
        public int? SizeEstimate { get; set; }

        /// <summary>
        /// <para type="description">A short part of the message text.</para>
        /// </summary>
        [Parameter(Position = 7,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "A short part of the message text.")]
        public string Snippet { get; set; }

        /// <summary>
        /// <para type="description">The ID of the thread the message belongs to. To add a message or draft to a thread, the following criteria must be met:- The requested threadId must be specified on the Message or Draft.Message you supply with your request.- The References and In-Reply-To headers must be set in compliance with the RFC 2822 standard.- The Subject headers must match.</para>
        /// </summary>
        [Parameter(Position = 8,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The ID of the thread the message belongs to. To add a message or draft to a thread, the following criteria must be met: \n- The requested threadId must be specified on the Message or Draft.Message you supply with your request. \n- The References and In-Reply-To headers must be set in compliance with the RFC 2822 standard. \n- The Subject headers must match.")]
        public string ThreadId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.Gmail.v1.Data.Message()
            {
                HistoryId = this.HistoryId,
                Id = this.Id,
                InternalDate = this.InternalDate,
                LabelIds = this.LabelIds,
                Payload = this.Payload,
                Raw = this.Raw,
                SizeEstimate = this.SizeEstimate,
                Snippet = this.Snippet,
                ThreadId = this.ThreadId,
            };

            if (ShouldProcess("Message"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Gmail API MessagePart object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a MessagePart object which may be required as a parameter for some other Cmdlets in the Gmail API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Gmail.v1.Data.MessagePart</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GGmailMessagePartObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GGmailMessagePartObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GGmailMessagePartObj",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/New-GGmailMessagePartObj")]
    public class NewGGmailMessagePartObj : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">The immutable ID of the message part.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The immutable ID of the message part.")]
        [ValidateNotNullOrEmpty]
        public string PartId { get; set; }

        /// <summary>
        /// <para type="description">The MIME type of the message part.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The MIME type of the message part.")]
        [ValidateNotNullOrEmpty]
        public string MimeType { get; set; }

        /// <summary>
        /// <para type="description">The filename of the attachment. Only present if this message part represents an attachment.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The filename of the attachment. Only present if this message part represents an attachment.")]
        [ValidateNotNullOrEmpty]
        public string Filename { get; set; }

        /// <summary>
        /// <para type="description">Hashtable of headers on this message part. For the top-level message part, representing the entire message payload, it will contain the standard RFC 2822 email headers such as To, From, and Subject.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Hashtable of headers on this message part. For the top-level message part, representing the entire message payload, it will contain the standard RFC 2822 email headers such as To, From, and Subject.")]
        [ValidateNotNullOrEmpty]
        public Hashtable Headers { get; set; }

        /// <summary>
        /// <para type="description">When present, contains the ID of an external attachment that can be retrieved in a separate messages.attachments.get request. When not present, the entire content of the message part body is contained in the data field.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "When present, contains the ID of an external attachment that can be retrieved in a separate messages.attachments.get request. When not present, the entire content of the message part body is contained in the data field.")]
        [ValidateNotNullOrEmpty]
        public string BodyAttachmentId { get; set; }

        /// <summary>
        /// <para type="description">The body data of a MIME message part. May be empty for MIME container types that have no message body or when the body data is sent as a separate attachment. An attachment ID is present if the body data is contained in a separate attachment.</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The body data of a MIME message part. May be empty for MIME container types that have no message body or when the body data is sent as a separate attachment. An attachment ID is present if the body data is contained in a separate attachment.")]
        [ValidateNotNullOrEmpty]
        public string BodyData { get; set; }

        /// <summary>
        /// <para type="description">Total number of bytes in the body of the message part.</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Total number of bytes in the body of the message part.")]
        [ValidateNotNullOrEmpty]
        public int? BodySize { get; set; }

        /// <summary>
        /// <para type="description">The child MIME message parts of this part. This only applies to container MIME message parts, for example multipart. For non- container MIME message part types, such as text/plain, this field is empty. For more information, see RFC 1521.</para>
        /// </summary>
        [Parameter(Position = 7,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The child MIME message parts of this part. This only applies to container MIME message parts, for example multipart. For non- container MIME message part types, such as text/plain, this field is empty. For more information, see RFC 1521.")]
        [ValidateNotNullOrEmpty]
        public Data.MessagePart[] Parts { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.MessagePart
            {
                Filename = this.Filename,
                MimeType = this.MimeType,
                PartId = this.PartId,
                Parts = this.Parts
            };

            if (Headers != null)
            {
                foreach (DictionaryEntry entry in Headers)
                {
                    body.Headers.Add(new Data.MessagePartHeader()
                    {
                        Name = entry.Key.ToString(),
                        Value = entry.Value.ToString()
                    });
                }
            }

            if (!string.IsNullOrWhiteSpace(BodyAttachmentId) ||
                !string.IsNullOrWhiteSpace(BodyData) ||
                BodySize.HasValue)
            {
                body.Body = new Data.MessagePartBody()
                {
                    AttachmentId = this.BodyAttachmentId,
                    Data = this.BodyData,
                    Size = this.BodySize.Value
                };
            }

            if (ShouldProcess("Gmail User Message Payload Obj", "New-GGmailMessagePayloadObj"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Gmail API PopSettings object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a PopSettings object which may be required as a parameter for some other Cmdlets in the Gmail API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Gmail.v1.Data.PopSettings</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GGmailPopSettingsObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GGmailPopSettingsObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GGmailPopSettingsObj",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/New-GGmailPopSettingsObj")]
    [OutputType(typeof(Google.Apis.Gmail.v1.Data.PopSettings))]
    public class NewGGmailPopSettingsObjCommand : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">The range of messages which are accessible via POP.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The range of messages which are accessible via POP.")]
        public string AccessWindow { get; set; }

        /// <summary>
        /// <para type="description">The action that will be executed on a message after it has been fetched via POP.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The action that will be executed on a message after it has been fetched via POP.")]
        public string Disposition { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.Gmail.v1.Data.PopSettings()
            {
                AccessWindow = this.AccessWindow,
                Disposition = this.Disposition,
            };

            if (ShouldProcess("PopSettings"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Gmail API SendAs object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a SendAs object which may be required as a parameter for some other Cmdlets in the Gmail API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Gmail.v1.Data.SendAs</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GGmailSendAsObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GGmailSendAsObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GGmailSendAsObj",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/New-GGmailSendAsObj")]
    [OutputType(typeof(Google.Apis.Gmail.v1.Data.SendAs))]
    public class NewGGmailSendAsObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">A name that appears in the "From:" header for mail sent using this alias. For custom "from" addresses, when this is empty, Gmail will populate the "From:" header with the name that is used for the primary address associated with the account.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "A name that appears in the \"From:\" header for mail sent using this alias. For custom \"from\" addresses, when this is empty, Gmail will populate the \"From:\" header with the name that is used for the primary address associated with the account.")]
        public string DisplayName { get; set; }

        /// <summary>
        /// <para type="description">Whether this address is selected as the default "From:" address in situations such as composing a new message or sending a vacation auto-reply. Every Gmail account has exactly one default send-as address, so the only legal value that clients may write to this field is true. Changing this from false to true for an address will result in this field becoming false for the other previous default address.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Whether this address is selected as the default \"From:\" address in situations such as composing a new message or sending a vacation auto-reply. Every Gmail account has exactly one default send-as address, so the only legal value that clients may write to this field is true. Changing this from false to true for an address will result in this field becoming false for the other previous default address.")]
        public System.Nullable<bool> IsDefault { get; set; }

        /// <summary>
        /// <para type="description">Whether this address is the primary address used to login to the account. Every Gmail account has exactly one primary address, and it cannot be deleted from the collection of send-as aliases. This field is read-only.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Whether this address is the primary address used to login to the account. Every Gmail account has exactly one primary address, and it cannot be deleted from the collection of send-as aliases. This field is read-only.")]
        public System.Nullable<bool> IsPrimary { get; set; }

        /// <summary>
        /// <para type="description">An optional email address that is included in a "Reply-To:" header for mail sent using this alias. If this is empty, Gmail will not generate a "Reply-To:" header.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "An optional email address that is included in a \"Reply-To:\" header for mail sent using this alias. If this is empty, Gmail will not generate a \"Reply-To:\" header.")]
        public string ReplyToAddress { get; set; }

        /// <summary>
        /// <para type="description">The email address that appears in the "From:" header for mail sent using this alias. This is read-only for all operations except create.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The email address that appears in the \"From:\" header for mail sent using this alias. This is read-only for all operations except create.")]
        public string SendAsEmail { get; set; }

        /// <summary>
        /// <para type="description">An optional HTML signature that is included in messages composed with this alias in the Gmail web UI.</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "An optional HTML signature that is included in messages composed with this alias in the Gmail web UI.")]
        public string Signature { get; set; }

        /// <summary>
        /// <para type="description">An optional SMTP service that will be used as an outbound relay for mail sent using this alias. If this is empty, outbound mail will be sent directly from Gmail's servers to the destination SMTP service. This setting only applies to custom "from" aliases.</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "An optional SMTP service that will be used as an outbound relay for mail sent using this alias. If this is empty, outbound mail will be sent directly from Gmail's servers to the destination SMTP service. This setting only applies to custom \"from\" aliases.")]
        public Google.Apis.Gmail.v1.Data.SmtpMsa SmtpMsa { get; set; }

        /// <summary>
        /// <para type="description">Whether Gmail should  treat this address as an alias for the user's primary email address. This setting only applies to custom "from" aliases.</para>
        /// </summary>
        [Parameter(Position = 7,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Whether Gmail should  treat this address as an alias for the user's primary email address. This setting only applies to custom \"from\" aliases.")]
        public System.Nullable<bool> TreatAsAlias { get; set; }

        /// <summary>
        /// <para type="description">Indicates whether this address has been verified for use as a send-as alias. Read-only. This setting only applies to custom "from" aliases.</para>
        /// </summary>
        [Parameter(Position = 8,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Indicates whether this address has been verified for use as a send-as alias. Read-only. This setting only applies to custom \"from\" aliases.")]
        public string VerificationStatus { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.Gmail.v1.Data.SendAs()
            {
                DisplayName = this.DisplayName,
                IsDefault = this.IsDefault,
                IsPrimary = this.IsPrimary,
                ReplyToAddress = this.ReplyToAddress,
                SendAsEmail = this.SendAsEmail,
                Signature = this.Signature,
                SmtpMsa = this.SmtpMsa,
                TreatAsAlias = this.TreatAsAlias,
                VerificationStatus = this.VerificationStatus,
            };

            if (ShouldProcess("SendAs"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Gmail API SmtpMsa object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a SmtpMsa object which may be required as a parameter for some other Cmdlets in the Gmail API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Gmail.v1.Data.SmtpMsa</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GGmailSmtpMsaObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GGmailSmtpMsaObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GGmailSmtpMsaObj",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/New-GGmailSmtpMsaObj")]
    [OutputType(typeof(Google.Apis.Gmail.v1.Data.SmtpMsa))]
    public class NewGGmailSmtpMsaObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">The hostname of the SMTP service. Required.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The hostname of the SMTP service. Required.")]
        public string Host { get; set; }

        /// <summary>
        /// <para type="description">The password that will be used for authentication with the SMTP service. This is a write-only field that can be specified in requests to create or update SendAs settings; it is never populated in responses.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The password that will be used for authentication with the SMTP service. This is a write-only field that can be specified in requests to create or update SendAs settings; it is never populated in responses.")]
        public string Password { get; set; }

        /// <summary>
        /// <para type="description">The port of the SMTP service. Required.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The port of the SMTP service. Required.")]
        public System.Nullable<int> Port { get; set; }

        /// <summary>
        /// <para type="description">The protocol that will be used to secure communication with the SMTP service. Required.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The protocol that will be used to secure communication with the SMTP service. Required.")]
        public string SecurityMode { get; set; }

        /// <summary>
        /// <para type="description">The username that will be used for authentication with the SMTP service. This is a write-only field that can be specified in requests to create or update SendAs settings; it is never populated in responses.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The username that will be used for authentication with the SMTP service. This is a write-only field that can be specified in requests to create or update SendAs settings; it is never populated in responses.")]
        public string Username { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.Gmail.v1.Data.SmtpMsa()
            {
                Host = this.Host,
                Password = this.Password,
                Port = this.Port,
                SecurityMode = this.SecurityMode,
                Username = this.Username,
            };

            if (ShouldProcess("SmtpMsa"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Gmail API VacationSettings object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a VacationSettings object which may be required as a parameter for some other Cmdlets in the Gmail API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Gmail.v1.Data.VacationSettings</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GGmailVacationSettingsObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GGmailVacationSettingsObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GGmailVacationSettingsObj",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/New-GGmailVacationSettingsObj")]
    [OutputType(typeof(Google.Apis.Gmail.v1.Data.VacationSettings))]
    public class NewGGmailVacationSettingsObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">Flag that controls whether Gmail automatically replies to messages.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Flag that controls whether Gmail automatically replies to messages.")]
        public System.Nullable<bool> EnableAutoReply { get; set; }

        /// <summary>
        /// <para type="description">An optional end time for sending auto-replies (epoch ms). When this is specified, Gmail will automatically reply only to messages that it receives before the end time. If both startTime and endTime are specified, startTime must precede endTime.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "An optional end time for sending auto-replies (epoch ms). When this is specified, Gmail will automatically reply only to messages that it receives before the end time. If both startTime and endTime are specified, startTime must precede endTime.")]
        public System.Nullable<long> EndTime { get; set; }

        /// <summary>
        /// <para type="description">Response body in HTML format. Gmail will sanitize the HTML before storing it.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Response body in HTML format. Gmail will sanitize the HTML before storing it.")]
        public string ResponseBodyHtml { get; set; }

        /// <summary>
        /// <para type="description">Response body in plain text format.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Response body in plain text format.")]
        public string ResponseBodyPlainText { get; set; }

        /// <summary>
        /// <para type="description">Optional text to prepend to the subject line in vacation responses. In order to enable auto-replies, either the response subject or the response body must be nonempty.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Optional text to prepend to the subject line in vacation responses. In order to enable auto-replies, either the response subject or the response body must be nonempty.")]
        public string ResponseSubject { get; set; }

        /// <summary>
        /// <para type="description">Flag that determines whether responses are sent to recipients who are not in the user's list of contacts.</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Flag that determines whether responses are sent to recipients who are not in the user's list of contacts.")]
        public System.Nullable<bool> RestrictToContacts { get; set; }

        /// <summary>
        /// <para type="description">Flag that determines whether responses are sent to recipients who are outside of the user's domain. This feature is only available for Google Apps users.</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Flag that determines whether responses are sent to recipients who are outside of the user's domain. This feature is only available for Google Apps users.")]
        public System.Nullable<bool> RestrictToDomain { get; set; }

        /// <summary>
        /// <para type="description">An optional start time for sending auto-replies (epoch ms). When this is specified, Gmail will automatically reply only to messages that it receives after the start time. If both startTime and endTime are specified, startTime must precede endTime.</para>
        /// </summary>
        [Parameter(Position = 7,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "An optional start time for sending auto-replies (epoch ms). When this is specified, Gmail will automatically reply only to messages that it receives after the start time. If both startTime and endTime are specified, startTime must precede endTime.")]
        public System.Nullable<long> StartTime { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.Gmail.v1.Data.VacationSettings()
            {
                EnableAutoReply = this.EnableAutoReply,
                EndTime = this.EndTime,
                ResponseBodyHtml = this.ResponseBodyHtml,
                ResponseBodyPlainText = this.ResponseBodyPlainText,
                ResponseSubject = this.ResponseSubject,
                RestrictToContacts = this.RestrictToContacts,
                RestrictToDomain = this.RestrictToDomain,
                StartTime = this.StartTime,
            };

            if (ShouldProcess("VacationSettings"))
            {
                WriteObject(body);
            }
        }
    }
}

namespace gShell.Cmdlets.Gmail.Users
{
    /// <summary>
    /// <para type="synopsis">Gets the current user's Gmail profile.</para>
    /// <para type="description">Gets the current user's Gmail profile.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Get-GGmailProfile -UserId $SomeUserIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GGmailProfile">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GGmailProfile",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GGmailProfile")]
    public class GetGGmailProfileCommandCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        public string UserId { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail Users", "Get-GGmailProfile"))
            {
                WriteObject(users.GetProfile(UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
            }
        }
    }
    
    /// <summary>
    /// <para type="synopsis">Set up or update a push notification watch on the given user mailbox.</para>
    /// <para type="description">Set up or update a push notification watch on the given user mailbox.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Watch-GGmail -UserId $SomeUserIdString -WatchRequestBody $SomeWatchRequestObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Watch-GGmail">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Watch, "GGmail",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/Watch-GGmail")]
    public class WatchGGmailCommandCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">Set up or update a new push notification watch on this user's mailbox.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Set up or update a new push notification watch on this user's mailbox.")]
        public Google.Apis.Gmail.v1.Data.WatchRequest WatchRequestBody { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail Users", "Watch-GGmail"))
            {
                WriteObject(users.Watch(WatchRequestBody, UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
            }

        }
    }

    /// <summary>
    /// <para type="synopsis">Stop receiving push notifications for the given user mailbox.</para>
    /// <para type="description">Stop receiving push notifications for the given user mailbox.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Stop-GGmail -UserId $SomeUserIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Stop-GGmail">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "GGmail",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/Stop-GGmail")]
    public class StopGGmailCommandCommand : GmailBase
    {
        #region Properties


        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        public string UserId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Gmail Users", "Stop-GGmail"))
            {

                users.Stop(UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams);
            }

        }
    }
}

namespace gShell.Cmdlets.Gmail.Users.Drafts
{
    /// <summary>
    /// <para type="synopsis">Creates a new draft with the DRAFT label.</para>
    /// <para type="description">Creates a new draft with the DRAFT label.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GGmailDraft -UserId $SomeUserIdString -DraftBody $SomeDraftObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GGmailDraft">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GGmailDraft",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GGmailDraft")]
    public class NewGGmailDraftCommand : GmailBase
    {
        public enum DraftUploadTypeEnum { media, multipart, resumable }

        #region Properties

        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The message content of the draft.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The message content of the draft.")]
        [ValidateNotNullOrEmpty]
        public Data.Message DraftMessage { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Draft()
            {
                Message = this.DraftMessage
            };

            if (ShouldProcess("Gmail User", "New-GGmailDraft"))
            {
                WriteObject(users.drafts.Create(body, UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Immediately and permanently deletes the specified draft. Does not simply trash it.</para>
    /// <para type="description">Immediately and permanently deletes the specified draft. Does not simply trash it.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Remove-GGmailDraft -UserId $SomeUserIdString -Id $SomeIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GGmailDraft">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GGmailDraft",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GGmailDraft")]
    public class RemoveGGmailDraftCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the draft to delete.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The ID of the draft to delete.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            string toRemoveTarget = "Gmail User";

			if (ShouldProcess(toRemoveTarget))
			{	
				if (Force || ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
				{
					try
					{
						WriteDebug("Attempting to remove " + toRemoveTarget + "...");

                        users.drafts.Delete(UserId, Id, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams);
							
						WriteVerbose("Removal of " + toRemoveTarget + " completed without error.");
					}
					catch (Exception e)
					{
						WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, toRemoveTarget));
					}
				}
				else
				{
					WriteError(new ErrorRecord(new Exception("Deletion not confirmed"),
						"", ErrorCategory.InvalidData, toRemoveTarget));
				}
			}
        }
    }

    /// <summary>
    /// <para type="synopsis">Gets the specified draft.</para>
    /// <para type="description">Gets the specified draft.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Get-GGmailDraft -UserId $SomeUserIdString -Id $SomeIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\> Get-GGmailDraft -UserId $SomeUserIdString -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GGmailDraft">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GGmailDraft",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GGmailDraft",
        DefaultParameterSetName = "one")]
    public class GetGGmailDraftCommand : GmailBase
    {
        public enum GetDraftFormatEnum { full, metadata, minimal, raw }

        #region Properties

        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the draft to retrieve.</para>
        /// </summary>
        [Parameter(Position = 1,
        ParameterSetName = "one",
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The ID of the draft to retrieve.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">The format to return the draft in.</para>
        /// </summary>
        [Parameter(Position = 2,
        ParameterSetName = "one",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The format to return the draft in.")]
        public UsersResource.DraftsResource.GetRequest.FormatEnum? Format { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results</para>
        /// </summary>
        [Parameter(Position = 1,
        ParameterSetName = "list",
        Mandatory = true,
        HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }

        /// <summary>
        /// <para type="description">Include drafts from SPAM and TRASH in the results.</para>
        /// </summary>
        [Parameter(Position = 2,
        ParameterSetName = "list",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Include drafts from SPAM and TRASH in the results.")]
        public bool? IncludeSpamTrash { get; set; }

        /// <summary>
        /// <para type="description">Maximum number of drafts to return.</para>
        /// </summary>
        [Parameter(Position = 3,
        ParameterSetName = "list",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Maximum number of drafts to return.")]
        public int? MaxResults { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User", "Get-GGmailDraft"))
            {
                if (ParameterSetName == "list")
                {
                    var properties = new gGmail.Users.Drafts.DraftsListProperties()
                    {
                        IncludeSpamTrash = this.IncludeSpamTrash
                    };

                    if (MaxResults.HasValue) properties.TotalResults = MaxResults.Value;

                    WriteObject(users.drafts.List(UserId, properties, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams).SelectMany(x => x.Drafts).ToList());
                }
                else
                {
                    var properties = new gGmail.Users.Drafts.DraftsGetProperties()
                    {
                        Format = this.Format
                    };

                    WriteObject(users.drafts.Get(UserId, Id, properties, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Replaces a draft's content.</para>
    /// <para type="description">Replaces a draft's content.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Set-GGmailDraft -UserId $SomeUserIdString -Id $SomeIdString -DraftBody $SomeDraftObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GGmailDraft">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GGmailDraft",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GGmailDraft")]
    public class SetGGmailDraftCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the draft to update.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The ID of the draft to update.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">The message content of the draft.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The message content of the draft.")]
        [ValidateNotNullOrEmpty]
        public Data.Message DraftMessage { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Draft()
            {
                Message = DraftMessage
            };

            if (ShouldProcess("Gmail User", "Set-GGmailDraft"))
            {
                WriteObject(users.drafts.Update(body, UserId, Id, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Sends the specified, existing draft to the recipients in the To, Cc, and Bcc headers.</para>
    /// <para type="description">Sends the specified, existing draft to the recipients in the To, Cc, and Bcc headers.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Send-GGmailDraft -UserId $SomeUserIdString -DraftBody $SomeDraftObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Send-GGmailDraft">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommunications.Send, "GGmailDraft",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Send-GGmailDraft")]
    public class SendGGmailDraftCommand : GmailBase
    {
        #region Properties

        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">A draft email in the user's mailbox.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "A draft email in the user's mailbox.")]
        public Data.Message DraftMessage { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Draft()
            {
                Message = this.DraftMessage
            };

            if (ShouldProcess("Gmail User", "Send-GGmailDraft"))
            {
                WriteObject(users.drafts.Send(body, UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
            }
        }
    }
}

namespace gShell.Cmdlets.Gmail.Users.History
{
    /// <summary>
    /// <para type="synopsis">Lists the history of all changes to the given mailbox. History results are returned in chronological order (increasing historyId).</para>
    /// <para type="description">Lists the history of all changes to the given mailbox. History results are returned in chronological order (increasing historyId).</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Get-GGmailHistory -UserId $SomeUserIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GGmailHistory">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GGmailHistory",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GGmailHistory")]
    public class GetGGmailHistoryCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">Only return messages with a label matching the ID.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Only return messages with a label matching the ID.")]
        [ValidateNotNullOrEmpty]
        public string LabelId { get; set; }

        /// <summary>
        /// <para type="description">The maximum number of history records to return.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The maximum number of history records to return.")]
        public int? MaxResults { get; set; }

        /// <summary>
        /// <para type="description">Required. Returns history records after the specified startHistoryId. The supplied startHistoryId should be obtained from the historyId of a message, thread, or previous list response. History IDs increase chronologically but are not contiguous with random gaps in between valid IDs. Supplying an invalid or out of date startHistoryId typically returns an HTTP 404 error code. A historyId is typically valid for at least a week, but in some rare circumstances may be valid for only a few hours. If you receive an HTTP 404 error response, your application should perform a full sync. If you receive no nextPageToken in the response, there are no updates to retrieve and you can store the returned historyId for a future request.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Required. Returns history records after the specified startHistoryId. The supplied startHistoryId should be obtained from the historyId of a message, thread, or previous list response. History IDs increase chronologically but are not contiguous with random gaps in between valid IDs. Supplying an invalid or out of date startHistoryId typically returns an HTTP 404 error code. A historyId is typically valid for at least a week, but in some rare circumstances may be valid for only a few hours. If you receive an HTTP 404 error response, your application should perform a full sync. If you receive no nextPageToken in the response, there are no updates to retrieve and you can store the returned historyId for a future request.")]
        public ulong? StartHistoryId { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            var properties = new gGmail.Users.History.HistoryListProperties()
            {
                LabelId = LabelId
            };

            if (MaxResults.HasValue) properties.TotalResults = MaxResults.Value;

            if (StartHistoryId.HasValue) properties.StartHistoryId = StartHistoryId.Value;

            if (ShouldProcess("Gmail User History", "Get-GGmailHistory"))
            {
                WriteObject(users.history.List(UserId, properties, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams).SelectMany(x => x.History).ToList());
            }
        }
    }
}

namespace gShell.Cmdlets.Gmail.Users.Labels
{
    public enum LabelListVisibilityEnum { labelHide, labelShow, labelShowIfUnread }

    public enum MessageListVisibilityEnum { hide, show }

    /// <summary>
    /// <para type="synopsis">Creates a new label.</para>
    /// <para type="description">Creates a new label.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GGmailLabel -UserId $SomeUserIdString -LabelBody $SomeLabelObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GGmailLabel">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GGmailLabel",
        SupportsShouldProcess = true,
        HelpUri = @"")]
    public class NewGGmailLabelCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The visibility of the label in the label list in the Gmail web interface.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The visibility of the label in the label list in the Gmail web interface.")]
        [ValidateNotNullOrEmpty]
        public LabelListVisibilityEnum LabelListVisibility { get; set; }

        /// <summary>
        /// <para type="description">The visibility of the label in the message list in the Gmail web interface.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The visibility of the label in the message list in the Gmail web interface.")]
        [ValidateNotNullOrEmpty]
        public MessageListVisibilityEnum MessageListVisibility { get; set; }

        /// <summary>
        /// <para type="description">The display name of the label.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The display name of the label.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Label()
            {
                LabelListVisibility = this.LabelListVisibility.ToString(),
                MessageListVisibility = this.MessageListVisibility.ToString(),
                Name = this.Name
            };

            if (ShouldProcess("Gmail User Label", "New-GGmailLabel"))
            {
                WriteObject(users.labels.Create(body, UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Immediately and permanently deletes the specified label and removes it from any messages and threads that it is applied to.</para>
    /// <para type="description">Immediately and permanently deletes the specified label and removes it from any messages and threads that it is applied to.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Remove-GGmailLabel -UserId $SomeUserIdString -Id $SomeIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GGmailLabel">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GGmailLabel",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GGmailLabel")]
    public class RemoveGGmailLabelCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the label to delete.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The ID of the label to delete.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            string toRemoveTarget = "Gmail User Label";

			if (ShouldProcess(toRemoveTarget))
			{	
				if (Force || ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
				{
					try
					{
						WriteDebug("Attempting to remove " + toRemoveTarget + "...");

                        users.labels.Delete(UserId, Id, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams);
							
						WriteVerbose("Removal of " + toRemoveTarget + " completed without error.");
					}
					catch (Exception e)
					{
						WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, toRemoveTarget));
					}
				}
				else
				{
					WriteError(new ErrorRecord(new Exception("Deletion not confirmed"),
						"", ErrorCategory.InvalidData, toRemoveTarget));
				}
			}
        }
    }

    /// <summary>
    /// <para type="synopsis">Gets the specified label.</para>
    /// <para type="description">Gets the specified label.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Get-GGmailLabel -UserId $SomeUserIdString -Id $SomeIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\> Get-GGmailLabel -UserId $SomeUserIdString -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GGmailLabel">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GGmailLabel",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GGmailLabel",
        DefaultParameterSetName = "one")]
    public class GetGGmailLabelCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the label to retrieve.</para>
        /// </summary>
        [Parameter(Position = 1,
        ParameterSetName = "one",
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The ID of the label to retrieve.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results</para>
        /// </summary>
        [Parameter(Position = 1,
            ParameterSetName = "list",
            Mandatory = true,
            HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User Label", "Get-GGmailLabel"))
            {
                if (ParameterSetName == "list")
                {
                    WriteObject(users.labels.List(UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams).Labels);
                }
                else
                {
                    WriteObject(users.labels.Get(UserId, Id, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Updates the specified label. This method supports patch semantics.</para>
    /// <para type="description">Updates the specified label. This method supports patch semantics.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Set-GGmailLabel -UserId $SomeUserIdString -Id $SomeIdString -LabelBody $SomeLabelObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GGmailLabel">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GGmailLabel",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GGmailLabel")]
    public class SetGGmailLabelCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the label to update.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The ID of the label to update.")]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">The visibility of the label in the label list in the Gmail web interface.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The visibility of the label in the label list in the Gmail web interface.")]
        public LabelListVisibilityEnum? LabelListVisibility { get; set; }

        /// <summary>
        /// <para type="description">The visibility of the label in the message list in the Gmail web interface.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The visibility of the label in the message list in the Gmail web interface.")]
        public MessageListVisibilityEnum? MessageListVisibility { get; set; }

        /// <summary>
        /// <para type="description">The display name of the label.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The display name of the label.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (!LabelListVisibility.HasValue
                && !MessageListVisibility.HasValue
                && string.IsNullOrWhiteSpace(Name))
            {
                throw new Exception("Must set at least one label setting to continue.");
            }

            var body = new Data.Label();

            if (LabelListVisibility.HasValue) body.LabelListVisibility = this.LabelListVisibility.ToString();
            if (MessageListVisibility.HasValue) body.MessageListVisibility = this.MessageListVisibility.ToString();
            if (!string.IsNullOrWhiteSpace(Name)) body.Name = this.Name;

            if (ShouldProcess("Gmail User Label", "Set-GGmailLabel"))
            {
                WriteObject(users.labels.Patch(body, UserId, Id, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
            }
        }
    }
}

namespace gShell.Cmdlets.Gmail.Users.Messages
{

    /// <summary>
    /// <para type="synopsis">Immediately and permanently deletes the specified message. This operation cannot be undone. Prefer messages.trash instead.</para>
    /// <para type="description">Immediately and permanently deletes the specified message. This operation cannot be undone. Prefer messages.trash instead.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Remove-GGmailMessage -UserId $SomeUserIdString -Id $SomeIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\> Remove-GGmailMessage -UserId $SomeUserIdString -BatchDeleteMessagesRequestBody $SomeBatchDeleteMessagesRequestObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GGmailMessage">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GGmailMessage",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GGmailMessage",
        DefaultParameterSetName = "one")]
    public class RemoveGGmailMessageCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the message to delete.</para>
        /// </summary>
        [Parameter(Position = 1,
        ParameterSetName = "one",
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The ID of the message to delete.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">The IDs of the messages to delete.</para>
        /// </summary>
        [Parameter(Position = 0,
        ParameterSetName = "batch",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The IDs of the messages to delete.")]
        [ValidateNotNullOrEmpty]
        public string[] BatchDeleteIds { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            string toRemoveTarget = "Gmail User Message";

			if (ShouldProcess(toRemoveTarget))
			{	
				if (Force || ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
				{
					try
					{
						WriteDebug("Attempting to remove " + toRemoveTarget + "...");

                        if (ParameterSetName == "one")
                        {
                            users.messages.Delete(UserId, Id, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams);
                        }
                        else
                        {
                            var body = new Data.BatchDeleteMessagesRequest();

                            if (this.BatchDeleteIds != null) body.Ids = BatchDeleteIds;

                            users.messages.BatchDelete(body, UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams);
                        }
							
						WriteVerbose("Removal of " + toRemoveTarget + " completed without error.");
					}
					catch (Exception e)
					{
						WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, toRemoveTarget));
					}
				}
				else
				{
					WriteError(new ErrorRecord(new Exception("Deletion not confirmed"),
						"", ErrorCategory.InvalidData, toRemoveTarget));
				}
			}
        }
    }

    /// <summary>
    /// <para type="synopsis">Gets the specified message.</para>
    /// <para type="description">Gets the specified message.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Get-GGmailMessage -UserId $SomeUserIdString -Id $SomeIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\> Get-GGmailMessage -UserId $SomeUserIdString -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GGmailMessage">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GGmailMessage",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GGmailMessage",
          DefaultParameterSetName = "one")]
    public class GetGGmailMessageCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the message to retrieve.</para>
        /// </summary>
        [Parameter(Position = 1,
        ParameterSetName = "one",
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The ID of the message to retrieve.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">The format to return the message in.</para>
        /// </summary>
        [Parameter(Position = 2,
        ParameterSetName = "one",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The format to return the message in.")]
        public UsersResource.MessagesResource.GetRequest.FormatEnum? Format { get; set; }

        /// <summary>
        /// <para type="description">When given and format is METADATA, only include headers specified.</para>
        /// </summary>
        [Parameter(Position = 3,
        ParameterSetName = "one",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "When given and format is METADATA, only include headers specified.")]
        [ValidateNotNullOrEmpty]
        public string[] MetadataHeaders { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results</para>
        /// </summary>
        [Parameter(Position = 1,
        ParameterSetName = "list",
        Mandatory = true,
        HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }

        /// <summary>
        /// <para type="description">Include messages from SPAM and TRASH in the results.</para>
        /// </summary>
        [Parameter(Position = 2,
        ParameterSetName = "list",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Include messages from SPAM and TRASH in the results.")]
        public bool? IncludeSpamTrash { get; set; }

        /// <summary>
        /// <para type="description">Only return messages with labels that match all of the specified label IDs.</para>
        /// </summary>
        [Parameter(Position = 3,
        ParameterSetName = "list",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Only return messages with labels that match all of the specified label IDs.")]
        [ValidateNotNullOrEmpty]
        public string[] LabelIds { get; set; }

        /// <summary>
        /// <para type="description">Maximum number of messages to return.</para>
        /// </summary>
        [Parameter(Position = 4,
        ParameterSetName = "list",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Maximum number of messages to return.")]
        public int? MaxResults { get; set; }

        /// <summary>
        /// <para type="description">Only return messages matching the specified query. Supports the same query format as the Gmail search box. For example, "from:someuser@example.com rfc822msgid: is:unread".</para>
        /// </summary>
        [Parameter(Position = 5,
        ParameterSetName = "list",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Only return messages matching the specified query. Supports the same query format as the Gmail search box. For example, \"from:someuser@example.com rfc822msgid: is:unread\".")]
        [ValidateNotNullOrEmpty]
        public string Query { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User Message", "Get-GGmailMessage"))
            {
                if (ParameterSetName == "list")
                {
                    var properties = new gGmail.Users.Messages.MessagesListProperties()
                    {
                        IncludeSpamTrash = this.IncludeSpamTrash,
                        //LabelIds = this.LabelIds,
                        Q = this.Query
                    };
                    
                    if (this.LabelIds != null) properties.LabelIds = this.LabelIds;
                    if (MaxResults.HasValue) properties.TotalResults = this.MaxResults.Value;
                    WriteObject(users.messages.List(UserId, properties, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams).SelectMany(x => x.Messages).ToList());
                }
                else
                {
                    var properties = new gGmail.Users.Messages.MessagesGetProperties()
                    {
                        Format = this.Format
                    };

                    if (this.MetadataHeaders != null) properties.MetadataHeaders = this.MetadataHeaders;
                    WriteObject(users.messages.Get(UserId, Id, properties, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Directly inserts a message into only this user's mailbox similar to IMAP APPEND, bypassing most scanning and classification. Does not send a message.</para>
    /// <para type="description">Directly inserts a message into only this user's mailbox similar to IMAP APPEND, bypassing most scanning and classification. Does not send a message.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GGmailMessage -UserId $SomeUserIdString -MessageBody $SomeMessageObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GGmailMessage">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GGmailMessage",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GGmailMessage")]
    public class NewGGmailMessageCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">An email message.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "An email message.")]
        [ValidateNotNullOrEmpty]
        public Data.Message MessageBody { get; set; }

        /// <summary>
        /// <para type="description">Mark the email as permanently deleted (not TRASH) and only visible in Google Apps Vault to a Vault administrator. Only used for Google Apps for Work accounts.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Mark the email as permanently deleted (not TRASH) and only visible in Google Apps Vault to a Vault administrator. Only used for Google Apps for Work accounts.")]
        public bool? Deleted { get; set; }

        /// <summary>
        /// <para type="description">Source for Gmail's internal date of the message.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Source for Gmail's internal date of the message.")]
        public UsersResource.MessagesResource.InsertRequest.InternalDateSourceEnum? InternalDateSource { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var properties = new gGmail.Users.Messages.MessagesInsertProperties()
            {
                Deleted = this.Deleted,
                InternalDateSource = this.InternalDateSource
            };

            if (ShouldProcess("Gmail User Message", "New-GGmailMessage"))
            {
                WriteObject(users.messages.Insert(MessageBody, UserId, properties, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Sends the specified message to the recipients in the To, Cc, and Bcc headers.</para>
    /// <para type="description">Sends the specified message to the recipients in the To, Cc, and Bcc headers.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Send-GGmailMessage -UserId $SomeUserIdString -MessageBody $SomeMessageObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Send-GGmailMessage">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommunications.Send, "GGmailMessage",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Send-GGmailMessage")]
    public class SendGGmailMessageCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">An email message.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "An email message.")]
        [ValidateNotNullOrEmpty]
        public Data.Message Message { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User Message", "Send-GGmailMessage"))
            {
                WriteObject(users.messages.Send(Message, UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Modifies the labels on the specified message.</para>
    /// <para type="description">Modifies the labels on the specified message.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Set-GGmailMessage -UserId $SomeUserIdString -Id $SomeIdString -AddLabelIds $SomeAddLabelIds{ get; set; }</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\> Set-GGmailMessage -UserId $SomeUserIdString -Id $SomeIdString -Trash</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\> Set-GGmailMessage -UserId $SomeUserIdString -Id $SomeIdString -Untrash</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GGmailMessage">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GGmailMessage",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GGmailMessage",
        DefaultParameterSetName = "modify")]
    public class SetGGmailMessageCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the message to modify.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The ID of the message to modify.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">A list of IDs of labels to add to this message.</para>
        /// </summary>
        [Parameter(Position = 2,
        ParameterSetName = "modify",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "A list of IDs of labels to add to this message.")]
        [ValidateNotNullOrEmpty]
        public string[] AddLabelIds { get; set; }

        /// <summary>
        /// <para type="description">A list IDs of labels to remove from this message.</para>
        /// </summary>
        [Parameter(Position = 3,
            ParameterSetName = "modify",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A list IDs of labels to remove from this message.")]
        [ValidateNotNullOrEmpty]
        public string[] RemoveLabelIds { get; set; }

        /// <summary>
        /// <para type="description">Moves the specified message to the trash.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName = "trash",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Moves the specified message to the trash.")]
        public SwitchParameter Trash { get; set; }

        /// <summary>
        /// <para type="description">Removes the specified message from the trash.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName = "untrash",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Removes the specified message from the trash.")]
        public SwitchParameter Untrash { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User Message", "Set-GGmailMessage"))
            {
                switch (ParameterSetName)
                {
                    case "modify":
                        if (AddLabelIds == null && RemoveLabelIds == null)
                            throw (new Exception("Must supply at least a label to add or a label to remove."));

                        var body = new Data.ModifyMessageRequest();

                        if (this.AddLabelIds != null) body.AddLabelIds = this.AddLabelIds;
                        if (this.RemoveLabelIds != null) body.RemoveLabelIds = this.RemoveLabelIds;

                        WriteObject(users.messages.Modify(body, UserId, Id, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
                        break;

                    case "trash":
                        WriteObject(users.messages.Trash(UserId, Id, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
                        break;

                    case "untrash":
                        WriteObject(users.messages.Untrash(UserId, Id, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
                        break;
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Imports a message into only this user's mailbox, with standard email delivery scanning and classification similar to receiving via SMTP. Does not send a message.</para>
    /// <para type="description">Imports a message into only this user's mailbox, with standard email delivery scanning and classification similar to receiving via SMTP. Does not send a message.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Import-GGmailMessage -UserId $SomeUserIdString -MessageBody $SomeMessageObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Import-GGmailMessage">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsData.Import, "GGmailMessage",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Import-GGmailMessage")]
    public class ImportGGmailMessageCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">An email message.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "An email message.")]
        public Data.Message MessageBody { get; set; }

        /// <summary>
        /// <para type="description">Mark the email as permanently deleted (not TRASH) and only visible in Google Apps Vault to a Vault administrator. Only used for Google Apps for Work accounts.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Mark the email as permanently deleted (not TRASH) and only visible in Google Apps Vault to a Vault administrator. Only used for Google Apps for Work accounts.")]
        public bool? Deleted { get; set; }

        /// <summary>
        /// <para type="description">Source for Gmail's internal date of the message.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Source for Gmail's internal date of the message.")]
        public UsersResource.MessagesResource.ImportRequest.InternalDateSourceEnum? InternalDateSource { get; set; }

        /// <summary>
        /// <para type="description">Ignore the Gmail spam classifier decision and never mark this email as SPAM in the mailbox.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Ignore the Gmail spam classifier decision and never mark this email as SPAM in the mailbox.")]
        public bool? NeverMarkSpam { get; set; }

        /// <summary>
        /// <para type="description">Process calendar invites in the email and add any extracted meetings to the Google Calendar for this user.</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Process calendar invites in the email and add any extracted meetings to the Google Calendar for this user.")]
        public bool? ProcessForCalendar { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail Messages", "Import-GGmailMessage"))
            {
                var properties = new gGmail.Users.Messages.MessagesImportProperties()
                {
                    Deleted = this.Deleted,
                    InternalDateSource = this.InternalDateSource,
                    NeverMarkSpam = this.NeverMarkSpam,
                    ProcessForCalendar = this.ProcessForCalendar
                };

                WriteObject(users.messages.Import(MessageBody, UserId, properties, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
            }
        }
    }
}

namespace gShell.Cmdlets.Gmail.Users.Messages.Attachments
{
    /// <summary>
    /// <para type="synopsis">Gets the specified message attachment.</para>
    /// <para type="description">Gets the specified message attachment.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Get-GGmailAttachment -UserId $SomeUserIdString -MessageId $SomeMessageIdString -Id $SomeIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GGmailAttachment">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GGmailAttachment",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GGmailAttachment")]
    public class GetGGmailAttachmentCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the message containing the attachment.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The ID of the message containing the attachment.")]
        [ValidateNotNullOrEmpty]
        public string MessageId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the attachment.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The ID of the attachment.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">The target download path of the file, including filename and extension.</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The target download path of the file, including filename and extension.")]
        public string DownloadPath { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User", "Get-GGmailAttachments"))
            {
                var result = users.messages.attachments.Get(UserId, MessageId, Id, ServiceAccount: gShellServiceAccount,
                    StandardQueryParams: StandardQueryParams);

                if (!string.IsNullOrWhiteSpace(DownloadPath))
                {
                    //var bytes = Convert.FromBase64String(result.Data);
                    var bytes = dotNet.Utilities.Utils.UrlTokenDecode(result.Data);

                    System.IO.File.WriteAllBytes(DownloadPath, bytes);
                }
                else
                {
                    WriteObject(result);   
                }
            }
        }
    }
}

namespace gShell.Cmdlets.Gmail.Users.Threads
{
    /// <summary>
    /// <para type="synopsis">Gets the specified thread.</para>
    /// <para type="description">Gets the specified thread.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Get-GGmailThread -UserId $SomeUserIdString -Id $SomeIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\> Get-GGmailThread -UserId $SomeUserIdString -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GGmailThread">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GGmailThread",
        SupportsShouldProcess = true,
          HelpUri = @"",
          DefaultParameterSetName = "one")]
    public class GetGGmailThreadCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the thread to retrieve.</para>
        /// </summary>
        [Parameter(Position = 1,
        ParameterSetName = "one",
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The ID of the thread to retrieve.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">The format to return the messages in.</para>
        /// </summary>
        [Parameter(Position = 2,
        ParameterSetName = "one",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The format to return the messages in.")]
        [ValidateNotNullOrEmpty]
        public UsersResource.ThreadsResource.GetRequest.FormatEnum? Format { get; set; }

        /// <summary>
        /// <para type="description">When given and format is METADATA, only include headers specified.</para>
        /// </summary>
        [Parameter(Position = 3,
        ParameterSetName = "one",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "When given and format is METADATA, only include headers specified.")]
        [ValidateNotNullOrEmpty]
        public string[] MetadataHeaders { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results</para>
        /// </summary>
        [Parameter(Position = 1,
        ParameterSetName = "list",
        Mandatory = true,
        HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }

        /// <summary>
        /// <para type="description">Include threads from SPAM and TRASH in the results.</para>
        /// </summary>
        [Parameter(Position = 2,
        ParameterSetName = "list",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Include threads from SPAM and TRASH in the results.")]
        public bool? IncludeSpamTrash { get; set; }

        /// <summary>
        /// <para type="description">Only return threads with labels that match all of the specified label IDs.</para>
        /// </summary>
        [Parameter(Position = 3,
        ParameterSetName = "list",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Only return threads with labels that match all of the specified label IDs.")]
        [ValidateNotNullOrEmpty]
        public string[] LabelIds { get; set; }

        /// <summary>
        /// <para type="description">Maximum number of threads to return.</para>
        /// </summary>
        [Parameter(Position = 4,
        ParameterSetName = "list",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Maximum number of threads to return.")]
        public int? MaxResults { get; set; }

        /// <summary>
        /// <para type="description">Only return threads matching the specified query. Supports the same query format as the Gmail search box. For example, "from:someuser@example.com rfc822msgid: is:unread".</para>
        /// </summary>
        [Parameter(Position = 5,
        ParameterSetName = "list",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Only return threads matching the specified query. Supports the same query format as the Gmail search box. For example, \"from:someuser@example.com rfc822msgid: is:unread\".")]
        [ValidateNotNullOrEmpty]
        public string Query { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User Thread", "Get-GGmailThread"))
            {
                if (ParameterSetName == "list")
                {
                    var properties = new gGmail.Users.Threads.ThreadsListProperties()
                    {
                        IncludeSpamTrash = this.IncludeSpamTrash,
                        Q = this.Query
                    };

                    if (this.LabelIds != null) properties.LabelIds = this.LabelIds;

                    if (MaxResults.HasValue) properties.TotalResults = MaxResults.Value;
                    WriteObject(users.threads.List(UserId, properties, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams).SelectMany(x => x.Threads).ToList());

                }
                else
                {
                    var properties = new gGmail.Users.Threads.ThreadsGetProperties()
                    {
                        Format = this.Format,
                        MetadataHeaders = this.MetadataHeaders
                    };

                    if (this.MetadataHeaders != null) properties.MetadataHeaders = this.MetadataHeaders;

                    WriteObject(users.threads.Get(UserId, Id, properties, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Modifies the labels applied to the thread. This applies to all messages in the thread.</para>
    /// <para type="description">Modifies the labels applied to the thread. This applies to all messages in the thread.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Set-GGmailThread -UserId $SomeUserIdString -Id $SomeIdString -ModifyThreadRequestBody $SomeModifyThreadRequestObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\> Set-GGmailThread -UserId $SomeUserIdString -Id $SomeIdString -Trash</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\> Set-GGmailThread -UserId $SomeUserIdString -Id $SomeIdString -Untrash</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GGmailThread">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GGmailThread",
        SupportsShouldProcess = true,
          HelpUri = @"",
          DefaultParameterSetName = "modify")]
    public class SetGGmailThreadCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
            ParameterSetName = "modify",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        [Parameter(Position = 0,
            ParameterSetName = "trash",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        [Parameter(Position = 0,
            ParameterSetName = "untrash",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the thread to modify.</para>
        /// </summary>
        [Parameter(Position = 1,
            ParameterSetName = "modify",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the thread to modify.")]
        [Parameter(Position = 1,
            ParameterSetName = "trash",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the thread to Trash.")]
        [Parameter(Position = 1,
            ParameterSetName = "untrash",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the thread to remove from Trash.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">A list of IDs of labels to add to this thread.</para>
        /// </summary>
        [Parameter(Position = 0,
            ParameterSetName = "modify",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A list of IDs of labels to add to this thread.")]
        [ValidateNotNullOrEmpty]
        public string[] AddLabelIds { get; set; }

        /// <summary>
        /// <para type="description">A list of IDs of labels to remove from this thread.</para>
        /// </summary>
        [Parameter(Position = 1,
            ParameterSetName = "modify",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A list of IDs of labels to remove from this thread.")]
        [ValidateNotNullOrEmpty]
        public string[] RemoveLabelIds { get; set; }

        /// <summary>
        /// <para type="description">Moves the specified thread to the trash.</para>
        /// </summary>
        [Parameter(Position = 2,
            ParameterSetName = "trash",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Moves the specified thread to the trash.")]
        public SwitchParameter Trash { get; set; }

        /// <summary>
        /// <para type="description">Removes the specified thread from the trash.</para>
        /// </summary>
        [Parameter(Position = 2,
            ParameterSetName = "untrash",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Removes the specified thread from the trash.")]
        public SwitchParameter Untrash { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User Thread", "Set-GGmailThread"))
            {
                switch (ParameterSetName)
                {
                    case "modify":
                        var body = new Data.ModifyThreadRequest()
                        {
                            AddLabelIds = this.AddLabelIds,
                            RemoveLabelIds = this.RemoveLabelIds
                        };

                        if (this.AddLabelIds != null) body.AddLabelIds = this.AddLabelIds;
                        if (this.RemoveLabelIds != null) body.RemoveLabelIds = this.RemoveLabelIds;
                        WriteObject(users.threads.Modify(body, UserId, Id, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
                        break;

                    case "trash":
                        WriteObject(users.threads.Trash(UserId, Id, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
                        break;

                    case "untrash":
                        WriteObject(users.threads.Untrash(UserId, Id, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
                        break;
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Immediately and permanently deletes the specified thread. This operation cannot be undone. Prefer threads.trash instead.</para>
    /// <para type="description">Immediately and permanently deletes the specified thread. This operation cannot be undone. Prefer threads.trash instead.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Remove-GGmailThread -UserId $SomeUserIdString -Id $SomeIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GGmailThread">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GGmailThread",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GGmailThread")]
    public class RemoveGGmailThreadCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The user's email address. The special value me can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's email address. The special value me can be used to indicate the authenticated user.")]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">ID of the Thread to delete.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "ID of the Thread to delete.")]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            string toRemoveTarget = "Gmail User Thread";

            if (ShouldProcess(toRemoveTarget))
            {
                if (Force || ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
                {
                    try
                    {
                        WriteDebug("Attempting to remove " + toRemoveTarget + "...");

                        users.threads.Delete(UserId, Id, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams);

                        WriteVerbose("Removal of " + toRemoveTarget + " completed without error.");
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, toRemoveTarget));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Deletion not confirmed"),
                        "", ErrorCategory.InvalidData, toRemoveTarget));
                }
            }
        }
    }
}


namespace gShell.Cmdlets.Gmail.Users.Settings
{
    /// <summary>
    /// <para type="synopsis">Gets one or more settings for the specified account.</para>
    /// <para type="description">Gets one or more settings for the specified account.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GGmailSettings -UserId $SomeUserIdString -UserId</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GGmailSettings -UserId $SomeUserIdString -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GGmailSettings">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GGmailSettings",
    SupportsShouldProcess = true,
    DefaultParameterSetName = "choice",
    HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GGmailSettings")]
    public class GetGGmailSettingsCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">User's email address. The special value "me" can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "User's email address. The special value \"me\" can be used to indicate the authenticated user.")]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">Gets the auto-forwarding setting for the specified account.</para>
        /// </summary>
        [Parameter(Position = 1,
        ParameterSetName = "choice",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets the auto-forwarding setting for the specified account.")]
        public SwitchParameter AutoForwarding { get; set; }

        /// <summary>
        /// <para type="description">Gets IMAP settings.</para>
        /// </summary>
        [Parameter(Position = 2,
        ParameterSetName = "choice",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets IMAP settings.")]
        public SwitchParameter Imap { get; set; }

        /// <summary>
        /// <para type="description">Gets POP settings.</para>
        /// </summary>
        [Parameter(Position = 3,
        ParameterSetName = "choice",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets POP settings.")]
        public SwitchParameter Pop { get; set; }

        /// <summary>
        /// <para type="description">Gets vacation responder settings.</para>
        /// </summary>
        [Parameter(Position = 4,
        ParameterSetName = "choice",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets vacation responder settings.")]
        public SwitchParameter Vacation { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results</para>
        /// </summary>
        [Parameter(Position = 1,
        ParameterSetName = "all",
        Mandatory = true,
        HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail Settings", "Get-GGmailSettings"))
            {
                if (!AutoForwarding && !Imap && !Pop && !Vacation)
                {
                    WriteError(new ErrorRecord(new Exception("You must choose at least one setting object to retrieve."),
                        "", ErrorCategory.InvalidData, UserId));
                }

                if (ParameterSetName == "all")
                {
                    AutoForwarding = new SwitchParameter(true);
                    Imap = new SwitchParameter(true);
                    Pop = new SwitchParameter(true);
                    Vacation = new SwitchParameter(true);
                }

                var results = new GGmailSettingsResult();
                if (AutoForwarding) results.AutoForwarding = (users.settings.GetAutoForwarding(UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
                if (Imap) results.ImapSettings = (users.settings.GetImap(UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
                if (Pop) results.PopSettings = (users.settings.GetPop(UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
                if (Vacation) results.VacationSettings = (users.settings.GetVacation(UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));

                WriteObject(results);
            }
        }
    }

    /// <summary>
    /// A simple struct to contain the results of separate GmailSettings API calls
    /// </summary>
    public struct GGmailSettingsResult
    {
        public Data.AutoForwarding AutoForwarding { get; set; }
        public Data.ImapSettings ImapSettings { get; set; }
        public Data.PopSettings PopSettings { get; set; }
        public Data.VacationSettings VacationSettings { get; set; }
    }

    /// <summary>
    /// <para type="synopsis">Sets one or more settings for the specified account.</para>
    /// <para type="description">Sets one or more settings for the specified account.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GGmailSettings -UserId $SomeUserIdString -UserId</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Set-GGmailSettings -UserId $SomeUserIdString -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GGmailSettings">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GGmailSettings",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GGmailSettings")]
    public class SetGGmailSettingsCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">User's email address. The special value "me" can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "User's email address. The special value \"me\" can be used to indicate the authenticated user.")]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">Updates the auto-forwarding setting for the specified account.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Updates the auto-forwarding setting for the specified account.")]
        public Google.Apis.Gmail.v1.Data.AutoForwarding AutoForwardingBody { get; set; }

        /// <summary>
        /// <para type="description">Updates IMAP settings.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Updates IMAP settings.")]
        public Google.Apis.Gmail.v1.Data.ImapSettings ImapBody { get; set; }

        /// <summary>
        /// <para type="description">Updates POP settings.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Updates POP settings.")]
        public Google.Apis.Gmail.v1.Data.PopSettings PopBody { get; set; }

        /// <summary>
        /// <para type="description">Updates vacation responder settings.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Updates vacation responder settings.")]
        public Google.Apis.Gmail.v1.Data.VacationSettings VacationBody { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail Settings", "Set-GGmailSettings"))
            {
                if ((AutoForwardingBody == null) && (ImapBody == null) && (PopBody == null) && (VacationBody == null))
                {
                    WriteError(new ErrorRecord(new Exception("You must provide at least one settings body object to update."),
                        "", ErrorCategory.InvalidData, UserId));
                }

                var results = new GGmailSettingsResult();

                if (AutoForwardingBody != null) results.AutoForwarding = users.settings.UpdateAutoForwarding(AutoForwardingBody, UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams);
                if (ImapBody != null) results.ImapSettings = users.settings.UpdateImap(ImapBody, UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams);
                if (PopBody != null) results.PopSettings = users.settings.UpdatePop(PopBody, UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams);
                if (VacationBody != null) results.VacationSettings = users.settings.UpdateVacation(VacationBody, UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams);

                WriteObject(results);
            }
        }
    }
}

namespace gShell.Cmdlets.Gmail.Users.Settings.Filters
{
    /// <summary>
    /// <para type="synopsis">Creates a filter.</para>
    /// <para type="description">Creates a filter.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Create-GGmailFilter -UserId $SomeUserIdString -FilterBody $SomeFilterObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GGmailFilter">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GGmailFilter",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/New-GGmailFilter")]
    public class NewGGmailFilterCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">User's email address. The special value "me" can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "User's email address. The special value \"me\" can be used to indicate the authenticated user.")]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">Resource definition for Gmail filters. Filters apply to specific messages instead of an entire email thread.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Resource definition for Gmail filters. Filters apply to specific messages instead of an entire email thread.")]
        public Google.Apis.Gmail.v1.Data.Filter FilterBody { get; set; }
        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Gmail Filters", "New-GGmailFilter"))
            {

                WriteObject(users.settings.filters.Create(FilterBody, UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
            }

        }
    }

    /// <summary>
    /// <para type="synopsis">Deletes a filter.</para>
    /// <para type="description">Deletes a filter.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GGmailFilter -UserId $SomeUserIdString -Id $SomeIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GGmailFilter">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GGmailFilter",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GGmailFilter")]
    public class RemoveGGmailFilterCommand : GmailBase
    {
        #region Properties


        /// <summary>
        /// <para type="description">User's email address. The special value "me" can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "User's email address. The special value \"me\" can be used to indicate the authenticated user.")]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the filter to be deleted.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The ID of the filter to be deleted.")]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting")]
        public SwitchParameter Force { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            string toRemoveTarget = "Gmail Filter";

            if (ShouldProcess(toRemoveTarget))
            {
                if (Force || ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
                {
                    try
                    {
                        WriteDebug("Attempting to remove " + toRemoveTarget + "...");

                        users.settings.filters.Delete(UserId, Id, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams);

                        WriteVerbose("Removal of " + toRemoveTarget + " completed without error.");
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, toRemoveTarget));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Deletion not confirmed"),
                        "", ErrorCategory.InvalidData, toRemoveTarget));
                }
            }

        }
    }

    /// <summary>
    /// <para type="synopsis">Gets one or all filters for the specified account.</para>
    /// <para type="description">Gets one or all filters for the specified account.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GGmailFilter -UserId $SomeUserIdString -Id $SomeIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GGmailFilter -UserId $SomeUserIdString -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GGmailFilter">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GGmailFilter",
    SupportsShouldProcess = true,
    DefaultParameterSetName = "One",
    HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GGmailFilter")]
    public class GetGGmailFilterCommand : GmailBase
    {
        #region Properties
    
        /// <summary>
        /// <para type="description">User's email address. The special value "me" can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "User's email address. The special value \"me\" can be used to indicate the authenticated user.")]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the filter to be fetched.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ParameterSetName = "One",
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The ID of the filter to be fetched.")]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ParameterSetName = "List",
        HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail Filters", "Get-GGmailFilter"))
            {
                if (ParameterSetName == "One")
                {
                    WriteObject(users.settings.filters.Get(UserId, Id, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
                }
                else
                {
                    WriteObject(users.settings.filters.List(UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
                }
            }

        }
    }
}

namespace gShell.Cmdlets.Gmail.Users.Settings.ForwardingAddresses
{
    /// <summary>
    /// <para type="synopsis">Creates a forwarding address. If ownership verification is required, a message will be sent to the recipient and the resource's verification status will be set to pending; otherwise, the resource will be created with verification status set to accepted.</para>
    /// <para type="description">Creates a forwarding address. If ownership verification is required, a message will be sent to the recipient and the resource's verification status will be set to pending; otherwise, the resource will be created with verification status set to accepted.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GGmailForwardingAddress -UserId $SomeUserIdString -ForwardingAddressBody $SomeForwardingAddressObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GGmailForwardingAddress">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GGmailForwardingAddress",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/New-GGmailForwardingAddress")]
    public class NewGGmailForwardingAddressCommand : GmailBase
    {
        #region Properties


        /// <summary>
        /// <para type="description">User's email address. The special value "me" can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "User's email address. The special value \"me\" can be used to indicate the authenticated user.")]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">An email address to which messages can be forwarded.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "An email address to which messages can be forwarded.")]
        public string ForwardingEmail { get; set; }

        /// <summary>
        /// <para type="description">Indicates whether this address has been verified and is usable for forwarding. Read-only.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Indicates whether this address has been verified and is usable for forwarding. Read-only.")]
        public string VerificationStatus { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var ForwardingAddressBody = new Google.Apis.Gmail.v1.Data.ForwardingAddress()
            {
                ForwardingEmail = this.ForwardingEmail
            };

            if (string.IsNullOrWhiteSpace(VerificationStatus))
                ForwardingAddressBody.VerificationStatus = this.VerificationStatus;

            if (ShouldProcess("Gmail ForwardingAddresses", "New-GGmailForwardingAddress"))
            {
                WriteObject(users.settings.forwardingAddresses.Create(ForwardingAddressBody, UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
            }

        }
    }

    /// <summary>
    /// <para type="synopsis">Deletes the specified forwarding address and revokes any verification that may have been required.</para>
    /// <para type="description">Deletes the specified forwarding address and revokes any verification that may have been required.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GGmailForwardingAddress -UserId $SomeUserIdString -ForwardingEmail $SomeForwardingEmailString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GGmailForwardingAddress">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GGmailForwardingAddress",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GGmailForwardingAddress")]
    public class RemoveGGmailForwardingAddressCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">User's email address. The special value "me" can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "User's email address. The special value \"me\" can be used to indicate the authenticated user.")]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The forwarding address to be deleted.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The forwarding address to be deleted.")]
        public string ForwardingEmail { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            string toRemoveTarget = "Gmail Forwarding Address";

            if (ShouldProcess(toRemoveTarget))
            {
                if (Force || ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
                {
                    try
                    {
                        WriteDebug("Attempting to remove " + toRemoveTarget + "...");

                        users.settings.forwardingAddresses.Delete(UserId, ForwardingEmail, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams);

                        WriteVerbose("Removal of " + toRemoveTarget + " completed without error.");
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, toRemoveTarget));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Deletion not confirmed"),
                        "", ErrorCategory.InvalidData, toRemoveTarget));
                }
            }

        }
    }

    /// <summary>
    /// <para type="synopsis">Gets one or all forwarding addresses for the specified account.</para>
    /// <para type="description">Gets one or all forwarding addresses for the specified account.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GGmailForwardingAddress -UserId $SomeUserIdString -ForwardingEmail $SomeForwardingEmailString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GGmailForwardingAddress -UserId $SomeUserIdString -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GGmailForwardingAddress">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GGmailForwardingAddress",
    SupportsShouldProcess = true,
    DefaultParameterSetName = "One",
    HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GGmailForwardingAddress")]
    public class GetGGmailForwardingAddressCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">User's email address. The special value "me" can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "User's email address. The special value \"me\" can be used to indicate the authenticated user.")]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The forwarding address to be retrieved.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ParameterSetName = "One",
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The forwarding address to be retrieved.")]
        public string ForwardingEmail { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ParameterSetName = "List",
        HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }
        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Gmail ForwardingAddresses", "Get-GGmailForwardingAddress"))
            {
                if (ParameterSetName == "One")
                {
                    WriteObject(users.settings.forwardingAddresses.Get(UserId, ForwardingEmail, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
                }
                else
                {
                    WriteObject(users.settings.forwardingAddresses.List(UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
                }
                
            }

        }
    }

}

namespace gShell.Cmdlets.Gmail.Users.Settings.SendAs
{
    /// <summary>
    /// <para type="synopsis">Creates a custom "from" send-as alias. If an SMTP MSA is specified, Gmail will attempt to connect to the SMTP service to validate the configuration before creating the alias. If ownership verification is required for the alias, a message will be sent to the email address and the resource's verification status will be set to pending; otherwise, the resource will be created with verification status set to accepted. If a signature is provided, Gmail will sanitize the HTML before saving it with the alias.</para>
    /// <para type="description">Creates a custom "from" send-as alias. If an SMTP MSA is specified, Gmail will attempt to connect to the SMTP service to validate the configuration before creating the alias. If ownership verification is required for the alias, a message will be sent to the email address and the resource's verification status will be set to pending; otherwise, the resource will be created with verification status set to accepted. If a signature is provided, Gmail will sanitize the HTML before saving it with the alias.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GGmailSendAs -UserId $SomeUserIdString -SendAsBody $SomeSendAsObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GGmailSendAs">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GGmailSendAs",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/New-GGmailSendAs")]
    public class NewGGmailSendAsCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">User's email address. The special value "me" can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "User's email address. The special value \"me\" can be used to indicate the authenticated user.")]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">Settings associated with a send-as alias, which can be either the primary login address associated with the account or a custom "from" address. Send-as aliases correspond to the "Send Mail As" feature in the web interface.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Settings associated with a send-as alias, which can be either the primary login address associated with the account or a custom \"from\" address. Send-as aliases correspond to the \"Send Mail As\" feature in the web interface.")]
        public Google.Apis.Gmail.v1.Data.SendAs SendAsBody { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail SendAs", "New-GGmailSendAs"))
            {
                WriteObject(users.settings.sendAs.Create(SendAsBody, UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
            }

        }
    }

    /// <summary>
    /// <para type="synopsis">Deletes the specified send-as alias. Revokes any verification that may have been required for using it.</para>
    /// <para type="description">Deletes the specified send-as alias. Revokes any verification that may have been required for using it.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GGmailSendAs -UserId $SomeUserIdString -SendAsEmail $SomeSendAsEmailString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GGmailSendAs">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GGmailSendAs",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GGmailSendAs")]
    public class RemoveGGmailSendAsCommand : GmailBase
    {
        #region Properties
        
        /// <summary>
        /// <para type="description">User's email address. The special value "me" can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "User's email address. The special value \"me\" can be used to indicate the authenticated user.")]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The send-as alias to be deleted.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The send-as alias to be deleted.")]
        public string SendAsEmail { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            string toRemoveTarget = "Gmail SendAs";

            if (ShouldProcess(toRemoveTarget))
            {
                if (Force || ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
                {
                    try
                    {
                        WriteDebug("Attempting to remove " + toRemoveTarget + "...");

                        users.settings.sendAs.Delete(UserId, SendAsEmail, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams);

                        WriteVerbose("Removal of " + toRemoveTarget + " completed without error.");
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, toRemoveTarget));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Deletion not confirmed"),
                        "", ErrorCategory.InvalidData, toRemoveTarget));
                }
            }
        }
    }
    
    /// <summary>
    /// <para type="synopsis">Gets one or all send-as aliases for the specified account. Fails with an HTTP 404 error if the specified address is not a member of the collection.</para>
    /// <para type="description">Gets one or all send-as aliases for the specified account. Fails with an HTTP 404 error if the specified address is not a member of the collection.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GGmailSendAs -UserId $SomeUserIdString -SendAsEmail $SomeSendAsEmailString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GGmailSendAs -UserId $SomeUserIdString -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GGmailSendAs">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GGmailSendAs",
    SupportsShouldProcess = true,
    DefaultParameterSetName = "One",
    HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GGmailSendAs")]
    public class GetGGmailSendAsCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">User's email address. The special value "me" can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "User's email address. The special value \"me\" can be used to indicate the authenticated user.")]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The send-as alias to be retrieved.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ParameterSetName = "One",
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The send-as alias to be retrieved.")]
        public string SendAsEmail { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ParameterSetName = "List",
        HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }
        #endregion

        protected override void ProcessRecord()
        {

            if (ShouldProcess("Gmail SendAs", "Get-GGmailSendAs"))
            {
                if (ParameterSetName == "One")
                {
                    WriteObject(users.settings.sendAs.Get(UserId, SendAsEmail, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
                }
                else
                {
                    WriteObject(users.settings.sendAs.List(UserId, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
                }
            }

        }
    }
    
    /// <summary>
    /// <para type="synopsis">Updates a send-as alias. If a signature is provided, Gmail will sanitize the HTML before saving it with the alias. This method supports patch semantics.</para>
    /// <para type="description">Updates a send-as alias. If a signature is provided, Gmail will sanitize the HTML before saving it with the alias. This method supports patch semantics.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GGmailSendAs -UserId $SomeUserIdString -SendAsEmail $SomeSendAsEmailString -SendAsBody $SomeSendAsObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GGmailSendAs">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GGmailSendAs",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GGmailSendAs")]
    public class SetGGmailSendAsCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">User's email address. The special value "me" can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "User's email address. The special value \"me\" can be used to indicate the authenticated user.")]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The send-as alias to be updated.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The send-as alias to be updated.")]
        public string SendAsEmail { get; set; }

        /// <summary>
        /// <para type="description">Settings associated with a send-as alias, which can be either the primary login address associated with the account or a custom "from" address. Send-as aliases correspond to the "Send Mail As" feature in the web interface.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Settings associated with a send-as alias, which can be either the primary login address associated with the account or a custom \"from\" address. Send-as aliases correspond to the \"Send Mail As\" feature in the web interface.")]
        public Google.Apis.Gmail.v1.Data.SendAs SendAsBody { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail SendAs", "Set-GGmailSendAs"))
            {
                WriteObject(users.settings.sendAs.Patch(SendAsBody, UserId, SendAsEmail, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams));
            }

        }
    }
    
    /// <summary>
    /// <para type="synopsis">Sends a verification email to the specified send-as alias address. The verification status must be pending.</para>
    /// <para type="description">Sends a verification email to the specified send-as alias address. The verification status must be pending.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Send-GGmailSendAsVerification -UserId $SomeUserIdString -SendAsEmail $SomeSendAsEmailString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Send-GGmailSendAsVerification">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommunications.Send, "GGmailSendAsVerification",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/Send-GGmailSendAsVerification")]
    public class SendGGmailSendAsVerificationCommand : GmailBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">User's email address. The special value "me" can be used to indicate the authenticated user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "User's email address. The special value \"me\" can be used to indicate the authenticated user.")]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">The send-as alias to be verified.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The send-as alias to be verified.")]
        public string SendAsEmail { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail SendAs", "Send-GGmailSendAsVerification"))
            {
                users.settings.sendAs.Verify(UserId, SendAsEmail, ServiceAccount: gShellServiceAccount, StandardQueryParams: StandardQueryParams);
            }
        }
    }

}