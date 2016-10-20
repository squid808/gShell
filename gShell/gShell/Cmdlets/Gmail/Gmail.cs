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
    /// <para type="synopsis">Creates a new Gmail API MessagePart object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a MessagePart object which may be required as a parameter for some other Cmdlets in the Gmail API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Gmail.v1.Data.MessagePart</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GGmailMessagePartObj</code>
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
    /// <para type="synopsis">Creates a new Gmail API Message object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a Message object which may be required as a parameter for some other Cmdlets in the Gmail API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Gmail.v1.Data.Message</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Gmail API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GGmailMessageObj</code>
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
        public IList<string> LabelIds { get; set; }

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
    ///   <code>PS C:\>Get-GGmailProfile -UserId $SomeUserIdString</code>
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
                WriteObject(users.GetProfile(UserId));
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
    ///   <code>PS C:\>Watch-GGmail -UserId $SomeUserIdString -WatchRequestBody $SomeWatchRequestObj</code>
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
                WriteObject(users.Watch(WatchRequestBody, UserId));
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
    ///   <code>PS C:\>Stop-GGmail -UserId $SomeUserIdString</code>
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

                users.Stop(UserId);
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
    ///   <code>PS C:\>New-GGmailDraft -UserId $SomeUserIdString -DraftBody $SomeDraftObj</code>
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
                WriteObject(users.drafts.Create(body, UserId));
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
    ///   <code>PS C:\>Remove-GGmailDraft -UserId $SomeUserIdString -Id $SomeIdString</code>
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

                        users.drafts.Delete(UserId, Id);
							
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
    ///   <code>PS C:\>Get-GGmailDraft -UserId $SomeUserIdString -Id $SomeIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GGmailDraft -UserId $SomeUserIdString -All</code>
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

                    WriteObject(users.drafts.List(UserId, properties).SelectMany(x => x.Drafts).ToList());
                }
                else
                {
                    var properties = new gGmail.Users.Drafts.DraftsGetProperties()
                    {
                        Format = this.Format
                    };

                    WriteObject(users.drafts.Get(UserId, Id, properties));
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
    ///   <code>PS C:\>Set-GGmailDraft -UserId $SomeUserIdString -Id $SomeIdString -DraftBody $SomeDraftObj</code>
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
                WriteObject(users.drafts.Update(body, UserId, Id));
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
    ///   <code>PS C:\>Send-GGmailDraft -UserId $SomeUserIdString -DraftBody $SomeDraftObj</code>
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
                WriteObject(users.drafts.Send(body, TargetUserEmail));
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
    ///   <code>PS C:\>Get-GGmailHistory -UserId $SomeUserIdString</code>
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
                WriteObject(users.history.List(UserId, properties).SelectMany(x => x.History).ToList());
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
    ///   <code>PS C:\>New-GGmailLabel -UserId $SomeUserIdString -LabelBody $SomeLabelObj</code>
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
                WriteObject(users.labels.Create(body, UserId));
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
    ///   <code>PS C:\>Remove-GGmailLabel -UserId $SomeUserIdString -Id $SomeIdString</code>
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

                        users.labels.Delete(UserId, Id);
							
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
    ///   <code>PS C:\>Get-GGmailLabel -UserId $SomeUserIdString -Id $SomeIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GGmailLabel -UserId $SomeUserIdString -All</code>
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
                    WriteObject(users.labels.List(UserId).Labels);
                }
                else
                {
                    WriteObject(users.labels.Get(UserId, Id));
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
    ///   <code>PS C:\>Set-GGmailLabel -UserId $SomeUserIdString -Id $SomeIdString -LabelBody $SomeLabelObj</code>
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
                WriteObject(users.labels.Patch(body, UserId, Id));
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
    ///   <code>PS C:\>Remove-GGmailMessage -UserId $SomeUserIdString -Id $SomeIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Remove-GGmailMessage -UserId $SomeUserIdString -BatchDeleteMessagesRequestBody $SomeBatchDeleteMessagesRequestObj</code>
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
                            users.messages.Delete(UserId, Id);
                        }
                        else
                        {
                            var body = new Data.BatchDeleteMessagesRequest();

                            if (this.BatchDeleteIds != null) body.Ids = BatchDeleteIds;

                            users.messages.BatchDelete(body, UserId);
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
    ///   <code>PS C:\>Get-GGmailMessage -UserId $SomeUserIdString -Id $SomeIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GGmailMessage -UserId $SomeUserIdString -All</code>
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
                    WriteObject(users.messages.List(UserId, properties).SelectMany(x => x.Messages).ToList());
                }
                else
                {
                    var properties = new gGmail.Users.Messages.MessagesGetProperties()
                    {
                        Format = this.Format
                    };

                    if (this.MetadataHeaders != null) properties.MetadataHeaders = this.MetadataHeaders;
                    WriteObject(users.messages.Get(UserId, Id, properties));
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
    ///   <code>PS C:\>New-GGmailMessage -UserId $SomeUserIdString -MessageBody $SomeMessageObj</code>
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
                WriteObject(users.messages.Insert(MessageBody, UserId, properties));
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
    ///   <code>PS C:\>Send-GGmailMessage -UserId $SomeUserIdString -MessageBody $SomeMessageObj</code>
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
                WriteObject(users.messages.Send(Message, UserId));
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
    ///   <code>PS C:\>Set-GGmailMessage -UserId $SomeUserIdString -Id $SomeIdString -AddLabelIds $SomeAddLabelIds{ get; set; }
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Set-GGmailMessage -UserId $SomeUserIdString -Id $SomeIdString -Trash</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Set-GGmailMessage -UserId $SomeUserIdString -Id $SomeIdString -Untrash</code>
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

                        WriteObject(users.messages.Modify(body, UserId, Id));
                        break;

                    case "trash":
                        WriteObject(users.messages.Trash(UserId, Id));
                        break;

                    case "untrash":
                        WriteObject(users.messages.Untrash(UserId, Id));
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
    ///   <code>PS C:\>Import-GGmailMessage -UserId $SomeUserIdString -MessageBody $SomeMessageObj</code>
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

                WriteObject(users.messages.Import(MessageBody, UserId, properties));
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
    ///   <code>PS C:\>Get-GGmailAttachment -UserId $SomeUserIdString -MessageId $SomeMessageIdString -Id $SomeIdString</code>
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

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User", "Get-GGmailAttachments"))
            {
                WriteObject(users.messages.attachments.Get(UserId, MessageId, Id));
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
    ///   <code>PS C:\>Get-GGmailThread -UserId $SomeUserIdString -Id $SomeIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GGmailThread -UserId $SomeUserIdString -All</code>
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
                    WriteObject(users.threads.List(UserId, properties).SelectMany(x => x.Threads).ToList());

                }
                else
                {
                    var properties = new gGmail.Users.Threads.ThreadsGetProperties()
                    {
                        Format = this.Format,
                        MetadataHeaders = this.MetadataHeaders
                    };

                    if (this.MetadataHeaders != null) properties.MetadataHeaders = this.MetadataHeaders;

                    WriteObject(users.threads.Get(UserId, Id, properties));
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
    ///   <code>PS C:\>Set-GGmailThread -UserId $SomeUserIdString -Id $SomeIdString -ModifyThreadRequestBody $SomeModifyThreadRequestObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Set-GGmailThread -UserId $SomeUserIdString -Id $SomeIdString -Trash</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Set-GGmailThread -UserId $SomeUserIdString -Id $SomeIdString -Untrash</code>
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
                        WriteObject(users.threads.Modify(body, UserId, Id));
                        break;

                    case "trash":
                        WriteObject(users.threads.Trash(UserId, Id));
                        break;

                    case "untrash":
                        WriteObject(users.threads.Untrash(UserId, Id));
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
    ///   <code>PS C:\>Remove-GGmailThread -UserId $SomeUserIdString -Id $SomeIdString</code>
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

                        users.threads.Delete(UserId, Id);

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