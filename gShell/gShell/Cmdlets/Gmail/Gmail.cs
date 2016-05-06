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
    [Cmdlet(VerbsCommon.New, "GGmailUserMessagePayloadObj",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGGmailMessagePartObj : PSCmdlet
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string PartId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string MimeType { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Filename { get; set; }

        [Parameter(Position = 3,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public Hashtable Headers { get; set; } 
        
        [Parameter(Position = 4,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string BodyAttachmentId { get; set; }
        
        [Parameter(Position = 5,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string BodyData { get; set; }
        
        [Parameter(Position = 6,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public int? BodySize { get; set; }
        
        [Parameter(Position = 7,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public Data.MessagePart[] Parts { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.MessagePart {
                Filename = this.Filename,
                MimeType = this.MimeType,
                PartId = this.PartId,
                Parts = this.Parts
            };

            if (Headers != null) {
                foreach (DictionaryEntry entry in Headers){
                    body.Headers.Add(new Data.MessagePartHeader(){
                        Name = entry.Key.ToString(),
                        Value = entry.Value.ToString()
                    });
                }
            }

            if (!string.IsNullOrWhiteSpace(BodyAttachmentId) || 
                !string.IsNullOrWhiteSpace(BodyData) ||
                BodySize.HasValue){
                body.Body = new Data.MessagePartBody(){
                    AttachmentId = this.BodyAttachmentId,
                    Data = this.BodyData,
                    Size = this.BodySize.Value
                };
            }

            if (ShouldProcess("Gmail User Message Payload Obj", "New-GGmailUserMessagePayloadObj"))
            {
                WriteObject(body);
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GGmailUserMessageObj",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGGmailUserMessageObj : PSCmdlet
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string ThreadId { get; set; }

        [Parameter(Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string[] LabelIds { get; set; }

        [Parameter(Position = 3,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Snippet { get; set; }

        [Parameter(Position = 4,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public ulong? HistoryId { get; set; }

        [Parameter(Position = 5,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public long InternalDate { get; set; }

        [Parameter(Position = 6,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public Data.MessagePart Payload { get; set; }

        [Parameter(Position = 7,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public int SizeEstimate { get; set; }

        [Parameter(Position = 8,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Raw { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Message {
                Id = this.Id,
                ThreadId = this.ThreadId,
                LabelIds = this.LabelIds,
                Snippet = this.Snippet,
                HistoryId = this.HistoryId,
                InternalDate = this.InternalDate,
                Payload = this.Payload,
                SizeEstimate = this.SizeEstimate,
                Raw = this.Raw
            };

            if (ShouldProcess("Gmail User", "Watch-GGmailUser"))
            {
                WriteObject(body);
            }
        }
    }
}

namespace gShell.Cmdlets.Gmail.Users
{
    [Cmdlet(VerbsCommon.Get, "GGmailUserProfile",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGGmailUserProfile : GmailServiceAccountBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User", "Get-GGmailUserProfile"))
            {
                WriteObject(users.GetProfile(TargetUserEmail));
            }
        }
    }

    [Cmdlet(VerbsCommon.Watch, "GGmailUser",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class WatchGGmailUser : GmailServiceAccountBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string[] LabelIds { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string LabelFilterAction { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string TopicName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.WatchRequest()
            {
                LabelIds = this.LabelIds,
                LabelFilterAction = this.LabelFilterAction,
                TopicName = this.TopicName
            };

            if (ShouldProcess("Gmail User", "Watch-GGmailUser"))
            {
                WriteObject(users.Watch(body, TargetUserEmail));
            }
        }
    }

    [Cmdlet(VerbsLifecycle.Stop, "GGmailUser",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class StopGGmailUser : GmailServiceAccountBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User", "Stop-GGmailUser"))
            {
                users.Stop(TargetUserEmail);
            }
        }
    }
}

namespace gShell.Cmdlets.Gmail.Users.Drafts
{
    [Cmdlet(VerbsCommon.New, "GGmailUserDraft",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGGmailUserDraft : GmailServiceAccountBase
    {
        public enum DraftUploadTypeEnum { media, multipart, resumable }

        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public Data.Message DraftMessage { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Draft()
            {
                Id = this.Id,
                Message = this.DraftMessage
            };

            if (ShouldProcess("Gmail User", "New-GGmailUserDraft"))
            {
                WriteObject(users.drafts.Create(body, UserId));
            }
        }
    }

    [Cmdlet(VerbsCommon.Remove, "GGmailUserDraft",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class RemoveGGmailUserDraft : GmailServiceAccountBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User", "Remove-GGmailUserDraft"))
            {
                users.drafts.Delete(UserId, Id);
            }
        }
    }

    [Cmdlet(VerbsCommon.Get, "GGmailUserDraft",
        SupportsShouldProcess = true,
          HelpUri = @"",
          DefaultParameterSetName="all")]
    public class GetGGmailUserDraft : GmailServiceAccountBase
    {
        public enum GetDraftFormatEnum { full, metadata, minimal, raw }

        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName = "one")]
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName = "all")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true,
            ParameterSetName = "one")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }
        
        [Parameter(Position = 2,
            Mandatory = false,
            ParameterSetName = "one")]
        [ValidateNotNullOrEmpty]
        public UsersResource.DraftsResource.GetRequest.FormatEnum? Format { get; set; }

        [Parameter(Position = 1,
            Mandatory = false,
            ParameterSetName = "all")]
        [ValidateNotNullOrEmpty]
        public bool? IncludeSpamTrash { get; set; }

        [Parameter(Position = 2,
            Mandatory = false,
            ParameterSetName = "all")]
        [ValidateNotNullOrEmpty]
        public int? MaxResults { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User", "Get-GGmailUserDraft"))
            {
                if (ParameterSetName=="all") {
                    var properties = new gGmail.Users.Drafts.DraftsListProperties(){
                        includeSpamTrash = this.IncludeSpamTrash
                    };

                    if (MaxResults.HasValue) properties.totalResults = MaxResults.Value;

                    WriteObject(users.drafts.List(UserId, properties));
                } else {
                    var properties = new gGmail.Users.Drafts.DraftsGetProperties(){
                        format = this.Format
                    };

                    WriteObject(users.drafts.Get(UserId, Id, properties));
                }
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GGmailUserDraft",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGGmailUserDraft : GmailServiceAccountBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }
        
        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public Data.Message DraftMessage { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Draft()
            {
                Message = DraftMessage
            };

            if (ShouldProcess("Gmail User", "Set-GGmailUserDraft"))
            {
                WriteObject(users.drafts.Update(body, UserId, Id));
            }
        }
    }

    [Cmdlet(VerbsCommunications.Send, "GGmailUserDraft",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SendGGmailUserDraft : GmailServiceAccountBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public Data.Message DraftMessage { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Draft()
            {
                Message = this.DraftMessage
            };

            if (ShouldProcess("Gmail User", "Send-GGmailUserDraft"))
            {
                WriteObject(users.drafts.Send(body, TargetUserEmail));
            }
        }
    }
}

namespace gShell.Cmdlets.Gmail.Users.History
{
    [Cmdlet(VerbsCommon.Get, "GGmailUserHistory",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGGmailUserHistory : GmailServiceAccountBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }
        
        [Parameter(Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string LabelId { get; set; }

         [Parameter(Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public int? MaxResults { get; set; }

         [Parameter(Position = 3,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public ulong? StartHistoryId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var properties = new gGmail.Users.History.HistoryListProperties(){
                labelId = LabelId
            };

            if (MaxResults.HasValue) properties.totalResults = MaxResults.Value;

            if (StartHistoryId.HasValue) properties.startHistoryId = StartHistoryId.Value;

            if (ShouldProcess("Gmail User History", "Get-GGmailUserHistory"))
            {
                WriteObject(users.history.List(UserId, properties));
            }
        }
    }
}

namespace gShell.Cmdlets.Gmail.Users.Labels
{
    public enum LabelListVisibilityEnum { labelHide, labelShow, labelShowIfUnread }

    public enum MessageListVisibilityEnum { hide, show }

    [Cmdlet(VerbsCommon.New, "GGmailUserLabel",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGGmailUserLabel : GmailServiceAccountBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public LabelListVisibilityEnum LabelListVisibility { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public MessageListVisibilityEnum MessageListVisibility { get; set; }

        [Parameter(Position = 3,
            Mandatory = true)]
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

            if (ShouldProcess("Gmail User Label", "New-GGmailUserLabel"))
            {
                WriteObject(users.labels.Create(body, UserId));
            }
        }
    }

    [Cmdlet(VerbsCommon.Remove, "GGmailUserLabel",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class RemoveGGmailUserLabel : GmailServiceAccountBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User Label", "Remove-GGmailUserLabel"))
            {
                users.labels.Delete(UserId, Id);
            }
        }
    }

    [Cmdlet(VerbsCommon.Get, "GGmailUserLabel",
        SupportsShouldProcess = true,
          HelpUri = @"",
          DefaultParameterSetName="all")]
    public class GetGGmailUserLabel : GmailServiceAccountBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName="all")]
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName="one")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }
        
        [Parameter(Position = 1,
            Mandatory = true,
            ParameterSetName="one")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User Label", "Get-GGmailUserLabel"))
            {
                if (ParameterSetName=="all"){
                    WriteObject(users.labels.List(UserId));
                } else {
                    WriteObject(users.labels.Get(UserId, Id));
                }
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GGmailUserLabel",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGGmailUserLabel : GmailServiceAccountBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public LabelListVisibilityEnum? LabelListVisibility { get; set; }

        [Parameter(Position = 3,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public MessageListVisibilityEnum? MessageListVisibility { get; set; }

        [Parameter(Position = 4,
            Mandatory = true)]
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

            if (ShouldProcess("Gmail User Label", "Set-GGmailUserLabel"))
            {
                WriteObject(users.labels.Patch(body, UserId, Id));
            }
        }
    }
}

namespace gShell.Cmdlets.Gmail.Users.Messages
{
    [Cmdlet(VerbsCommon.Remove, "GGmailUserMessage",
        SupportsShouldProcess = true,
          HelpUri = @"",
          DefaultParameterSetName="one")]
    public class RemoveGGmailUserMessage : GmailServiceAccountBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName="one")]
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName="batch")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }
        
        [Parameter(Position = 1,
            Mandatory = true,
            ParameterSetName="one")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Position = 1,
            Mandatory = true,
            ParameterSetName="batch")]
        [ValidateNotNullOrEmpty]
        public string[] BatchDeleteIds { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User Message", "Remove-GGmailUserMessage"))
            {
                if (ParameterSetName == "one"){
                    users.messages.Delete(UserId, Id);
                } else {
                    var body = new Data.BatchDeleteMessagesRequest(){
                        Ids = BatchDeleteIds
                    };

                    users.messages.BatchDelete(body, UserId);
                }
            }
        }
    }

    [Cmdlet(VerbsCommon.Get, "GGmailUserMessage",
        SupportsShouldProcess = true,
          HelpUri = @"",
          DefaultParameterSetName="all")]
    public class GetGGmailUserMessage : GmailServiceAccountBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName="all")]
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName="one")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        [Parameter(Position = 1,
            Mandatory = false,
            ParameterSetName = "all")]
        [ValidateNotNullOrEmpty]
        public bool? IncludeSpamTrash { get; set; }

        [Parameter(Position = 2,
            Mandatory = false,
            ParameterSetName="all")]
        [ValidateNotNullOrEmpty]
        public string[] LabelIds { get; set; }

        [Parameter(Position = 3,
            Mandatory = false,
            ParameterSetName = "all")]
        [ValidateNotNullOrEmpty]
        public int? MaxResults { get; set; }

        [Parameter(Position = 4,
            Mandatory = true,
            ParameterSetName="all")]
        [ValidateNotNullOrEmpty]
        public string Query { get; set; }
        
        [Parameter(Position = 1,
            Mandatory = true,
            ParameterSetName="one")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Position = 2,
            Mandatory = false,
            ParameterSetName = "one")]
        [ValidateNotNullOrEmpty]
        public UsersResource.MessagesResource.GetRequest.FormatEnum? Format { get; set; }

        [Parameter(Position = 3,
            Mandatory = false,
            ParameterSetName="one")]
        [ValidateNotNullOrEmpty]
        public string MetadataHeaders { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User Message", "Get-GGmailUserMessage"))
            {
                if (ParameterSetName=="all"){
                    var properties = new gGmail.Users.Messages.MessagesListProperties()
                    {
                        includeSpamTrash = this.IncludeSpamTrash,
                        labelIds = this.LabelIds,
                        q = this.Query
                    };
                    if (MaxResults.HasValue) properties.totalResults = this.MaxResults.Value;
                    WriteObject(users.messages.List(UserId, properties));
                } else {
                    var properties = new gGmail.Users.Messages.MessagesGetProperties()
                    {
                        format = this.Format,
                        metadataHeaders = this.MetadataHeaders
                    };
                    WriteObject(users.messages.Get(UserId, Id, properties));
                }
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GGmailUserMessage",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGGmailUserMessage : GmailServiceAccountBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public Data.Message Message { get; set; }
        
        [Parameter(Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? Deleted { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public UsersResource.MessagesResource.InsertRequest.InternalDateSourceEnum? InternalDateSource { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var properties = new gGmail.Users.Messages.MessagesInsertProperties(){
                deleted = this.Deleted,
                internalDateSource = this.InternalDateSource
            };

            if (ShouldProcess("Gmail User Message", "New-GGmailUserMessage"))
            {
                WriteObject(users.messages.Insert(Message, UserId, properties));
            }
        }
    }

    [Cmdlet(VerbsCommunications.Send, "GGmailUserMessage",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SendGGmailUserMessage : GmailServiceAccountBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }
        
        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public Data.Message Message { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User Message", "Send-GGmailUserMessage"))
            {
                WriteObject(users.messages.Send(Message, UserId));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GGmailUserMessage",
        SupportsShouldProcess = true,
          HelpUri = @"",
          DefaultParameterSetName="modify")]
    public class SetGGmailUserMessage : GmailServiceAccountBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName="modify")]
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName="trash")]
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName="untrash")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true,
            ParameterSetName="modify")]
        [Parameter(Position = 1,
            Mandatory = true,
            ParameterSetName="trash")]
        [Parameter(Position = 1,
            Mandatory = true,
            ParameterSetName="untrash")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Position = 2,
            Mandatory = false,
            ParameterSetName="modify")]
        [ValidateNotNullOrEmpty]
        public string[] AddLabelIds { get; set; }

        [Parameter(Position = 3,
            Mandatory = false,
            ParameterSetName="modify")]
        [ValidateNotNullOrEmpty]
        public string[] RemoveLabelIds { get; set; }

        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName="trash")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Trash { get; set; }

        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName="untrash")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Untrash { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User Message", "Set-GGmailUserMessage"))
            {
                switch (ParameterSetName)
	            {
                    case "modify":
                        if (AddLabelIds == null && RemoveLabelIds== null)
                            throw(new Exception("Must supply at least a label to add or a label to remove."));

                        var body = new Data.ModifyMessageRequest(){
                            AddLabelIds = this.AddLabelIds,
                            RemoveLabelIds = this.RemoveLabelIds
                        };
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

    [Cmdlet(VerbsData.Import, "GGmailUserMessage",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class ImportGGmailUserMessage : GmailServiceAccountBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public Data.Message Message { get; set; }

        [Parameter(Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? Deleted { get; set; }
        
        [Parameter(Position = 3,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public UsersResource.MessagesResource.InsertRequest.InternalDateSourceEnum? InternalDateSource { get; set; }
        
        //[Parameter(Position = 4,
        //    Mandatory = false)]
        //[ValidateNotNullOrEmpty]
        //public bool? NeverMarkSpam { get; set; }

        //[Parameter(Position = 5,
        //    Mandatory = false)]
        //[ValidateNotNullOrEmpty]
        //public bool? ProcessForCalendar { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var properties = new gGmail.Users.Messages.MessagesInsertProperties(){
                deleted = this.Deleted,
                internalDateSource = this.InternalDateSource
            };

            if (ShouldProcess("Gmail User Message", "Import-GGmailUserMessage"))
            {
                WriteObject(users.messages.Insert(Message, UserId, properties));
            }
        }
    }
}

namespace gShell.Cmdlets.Gmail.Users.Messages.Attachments
{
    [Cmdlet(VerbsCommon.Get, "GGmailUserAttachments",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGGmailUserAttachments : GmailServiceAccountBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string AttachmentId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User", "Get-GGmailUserAttachments"))
            {
                WriteObject(users.messages.attachments.Get(UserId, Id, AttachmentId));
            }
        }
    }
}

namespace gShell.Cmdlets.Gmail.Users.Threads
{
    [Cmdlet(VerbsCommon.Get, "GGmailUserThread",
        SupportsShouldProcess = true,
          HelpUri = @"",
          DefaultParameterSetName="all")]
    public class GetGGmailUserThread : GmailServiceAccountBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName="all")]
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName="one")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        [Parameter(Position = 1,
            Mandatory = false,
            ParameterSetName="all")]
        [ValidateNotNullOrEmpty]
        public bool? IncludeSpamTrash { get; set; }

        [Parameter(Position = 2,
            Mandatory = false,
            ParameterSetName="all")]
        [ValidateNotNullOrEmpty]
        public string[] LabelIds { get; set; }

        [Parameter(Position = 3,
            Mandatory = false,
            ParameterSetName="all")]
        [ValidateNotNullOrEmpty]
        public int? MaxResults { get; set; }

        [Parameter(Position = 4,
            Mandatory = false,
            ParameterSetName="all")]
        [ValidateNotNullOrEmpty]
        public string Query { get; set; }

        [Parameter(Position = 1,
            Mandatory = true,
            ParameterSetName="one")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Position = 2,
            Mandatory = false,
            ParameterSetName="one")]
        [ValidateNotNullOrEmpty]
        public UsersResource.ThreadsResource.GetRequest.FormatEnum? Format { get; set; }

        [Parameter(Position = 3,
            Mandatory = false,
            ParameterSetName="one")]
        [ValidateNotNullOrEmpty]
        public string MetadataHeaders { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User Thread", "Get-GGmailUserThread"))
            {
                if (ParameterSetName=="all"){
                    var properties = new gGmail.Users.Threads.ThreadsListProperties(){
                        includeSpamTrash = this.IncludeSpamTrash,
                        labelIds = this.LabelIds,
                        q = this.Query
                    };

                    if (MaxResults.HasValue) properties.totalResults = MaxResults.Value;
                    WriteObject(users.threads.List(UserId, properties));

                } else {
                    var properties = new gGmail.Users.Threads.ThreadsGetProperties(){
                        format = this.Format,
                        metadataHeaders = this.MetadataHeaders
                    };

                    WriteObject(users.threads.Get(UserId, Id, properties));
                }
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GGmailUserThread",
        SupportsShouldProcess = true,
          HelpUri = @"",
          DefaultParameterSetName="modify")]
    public class SetGGmailUserThread : GmailServiceAccountBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName="modify")]
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName="trash")]
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName="untrash")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true,
            ParameterSetName="modify")]
        [Parameter(Position = 1,
            Mandatory = true,
            ParameterSetName="trash")]
        [Parameter(Position = 1,
            Mandatory = true,
            ParameterSetName="untrash")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Position = 2,
            Mandatory = false,
            ParameterSetName="modify")]
        [ValidateNotNullOrEmpty]
        public string[] AddLabelIds { get; set; }

        [Parameter(Position = 3,
            Mandatory = false,
            ParameterSetName="modify")]
        [ValidateNotNullOrEmpty]
        public string[] RemoveLabelIds { get; set; }

        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName="trash")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Trash { get; set; }

        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName="untrash")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Untrash { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User Thread", "Set-GGmailUserThread"))
            {
                switch (ParameterSetName)
	            {
                    case "modify":
                        var body = new Data.ModifyThreadRequest()
                        {
                            AddLabelIds = this.AddLabelIds,
                            RemoveLabelIds = this.RemoveLabelIds
                        };
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

    [Cmdlet(VerbsCommon.Remove, "GGmailUserThread",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class RemoveGGmailUserThread : GmailServiceAccountBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Gmail User Thread", "Remove-GGmailUserThread"))
            {
                users.threads.Delete(UserId, Id);
            }
        }
    }
}