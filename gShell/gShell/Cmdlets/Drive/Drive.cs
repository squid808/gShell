using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using gShell.dotNet.Utilities.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using gDrive = gShell.dotNet.Drive;

namespace gShell.Cmdlets.Drive
{
    public enum DriveIdSpaceEnum { drive, appDataFolder }

    /// <summary>
    /// <para type="synopsis">Creates a new Drive API File.CapabilitiesData object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a File.CapabilitiesData object which may be required as a parameter for some other Cmdlets in the Drive API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Drive.v3.Data.File.CapabilitiesData</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GDriveFileCapabilitiesDataObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GDriveFile.CapabilitiesDataObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GDriveFileCapabilitiesDataObj",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GDriveFile.CapabilitiesDataObj")]
    [OutputType(typeof(File.CapabilitiesData))]
    public class NewGDriveFileCapabilitiesDataObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">Whether the user can comment on the file.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether the user can comment on the file.")]
        public bool? CanComment { get; set; }

        /// <summary>
        /// <para type="description">Whether the user can copy the file.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether the user can copy the file.")]
        public bool? CanCopy { get; set; }

        /// <summary>
        /// <para type="description">Whether the user can edit the file's content.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether the user can edit the file's content.")]
        public bool? CanEdit { get; set; }

        /// <summary>
        /// <para type="description">Whether the current user has read access to the Revisions resource of the file.</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether the current user has read access to the Revisions resource of the file.")]
        public bool? CanReadRevisions { get; set; }

        /// <summary>
        /// <para type="description">Whether the user can modify the file's permissions and sharing settings.</para>
        /// </summary>
        [Parameter(Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether the user can modify the file's permissions and sharing settings.")]
        public bool? CanShare { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            var body = new File.CapabilitiesData
            {
                CanComment = CanComment,
                CanCopy = CanCopy,
                CanEdit = CanEdit,
                CanReadRevisions = CanReadRevisions,
                CanShare = CanShare
            };

            if (ShouldProcess("File.CapabilitiesData"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Drive API File.ContentHintsData object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a File.ContentHintsData object which may be required as a parameter for some other Cmdlets in the Drive API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Drive.v3.Data.File.ContentHintsData</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GDriveFileContentHintsDataObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GDriveFile.ContentHintsDataObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GDriveFileContentHintsDataObj",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GDriveFile.ContentHintsDataObj")]
    [OutputType(typeof(File.ContentHintsData))]
    public class NewGDriveFileContentHintsDataObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">Text to be indexed for the file to improve fullText queries. This is limited to 128KB in length and may contain HTML elements.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Text to be indexed for the file to improve fullText queries. This is limited to 128KB in length and may contain HTML elements."
            )]
        public string IndexableText { get; set; }

        /// <summary>
        /// <para type="description">A thumbnail for the file. This will only be used if Drive cannot generate a standard thumbnail.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "A thumbnail for the file. This will only be used if Drive cannot generate a standard thumbnail.")]
        public File.ContentHintsData.ThumbnailData Thumbnail { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            var body = new File.ContentHintsData
            {
                IndexableText = IndexableText,
                Thumbnail = Thumbnail
            };

            if (ShouldProcess("File.ContentHintsData"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Drive API File.VideoMediaMetadataData object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a File.VideoMediaMetadataData object which may be required as a parameter for some other Cmdlets in the Drive API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Drive.v3.Data.File.VideoMediaMetadataData</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GDriveFileVideoMediaMetadataDataObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GDriveFile.VideoMediaMetadataDataObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GDriveFileVideoMediaMetadataDataObj",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GDriveFile.VideoMediaMetadataDataObj")]
    [OutputType(typeof(File.VideoMediaMetadataData))]
    public class NewGDriveFileVideoMediaMetadataDataObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">The duration of the video in milliseconds.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The duration of the video in milliseconds.")]
        public long? DurationMillis { get; set; }

        /// <summary>
        /// <para type="description">The height of the video in pixels.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The height of the video in pixels.")]
        public int? Height { get; set; }

        /// <summary>
        /// <para type="description">The width of the video in pixels.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The width of the video in pixels.")]
        public int? Width { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            var body = new File.VideoMediaMetadataData
            {
                DurationMillis = DurationMillis,
                Height = Height,
                Width = Width
            };

            if (ShouldProcess("File.VideoMediaMetadataData"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Drive API Reply object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a Reply object which may be required as a parameter for some other Cmdlets in the Drive API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Drive.v3.Data.Reply</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GDriveReplyObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GDriveReplyObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GDriveReplyObj",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GDriveReplyObj")]
    [OutputType(typeof(Reply))]
    public class NewGDriveReplyObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">The action the reply performed to the parent comment. Valid values are:- resolve- reopen</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The action the reply performed to the parent comment. Valid values are:  \n- resolve \n- reopen")]
        public string Action { get; set; }

        /// <summary>
        /// <para type="description">The user who created the reply.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The user who created the reply.")]
        public User Author { get; set; }

        /// <summary>
        /// <para type="description">The plain text content of the reply. This field is used for setting the content, while htmlContent should be displayed. This is required on creates if no action is specified.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The plain text content of the reply. This field is used for setting the content, while htmlContent should be displayed. This is required on creates if no action is specified."
            )]
        public string Content { get; set; }

        /// <summary>
        /// <para type="description">The time at which the reply was created (RFC 3339 date-time).</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The time at which the reply was created (RFC 3339 date-time).")]
        public DateTime? CreatedTime { get; set; }

        /// <summary>
        /// <para type="description">Whether the reply has been deleted. A deleted reply has no content.</para>
        /// </summary>
        [Parameter(Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether the reply has been deleted. A deleted reply has no content.")]
        public bool? Deleted { get; set; }

        /// <summary>
        /// <para type="description">The content of the reply with HTML formatting.</para>
        /// </summary>
        [Parameter(Position = 5,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The content of the reply with HTML formatting.")]
        public string HtmlContent { get; set; }

        /// <summary>
        /// <para type="description">The ID of the reply.</para>
        /// </summary>
        [Parameter(Position = 6,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the reply.")]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">The last time the reply was modified (RFC 3339 date-time).</para>
        /// </summary>
        [Parameter(Position = 7,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The last time the reply was modified (RFC 3339 date-time).")]
        public DateTime? ModifiedTime { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            var body = new Reply
            {
                Action = Action,
                Author = Author,
                Content = Content,
                CreatedTime = CreatedTime,
                Deleted = Deleted,
                HtmlContent = HtmlContent,
                Id = Id,
                ModifiedTime = ModifiedTime
            };

            if (ShouldProcess("Reply"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Drive API Comment.QuotedFileContentData object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a Comment.QuotedFileContentData object which may be required as a parameter for some other Cmdlets in the Drive API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Drive.v3.Data.Comment.QuotedFileContentData</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GDriveCommentQuotedFileContentDataObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GDriveComment.QuotedFileContentDataObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GDriveCommentQuotedFileContentDataObj",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GDriveComment.QuotedFileContentDataObj")]
    [OutputType(typeof(Comment.QuotedFileContentData))]
    public class NewGDriveCommentQuotedFileContentDataObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">The MIME type of the quoted content.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The MIME type of the quoted content.")]
        public string MimeType { get; set; }

        /// <summary>
        /// <para type="description">The quoted content itself. This is interpreted as plain text if set through the API.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The quoted content itself. This is interpreted as plain text if set through the API.")]
        public string Value { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            var body = new Comment.QuotedFileContentData
            {
                MimeType = MimeType,
                Value = Value
            };

            if (ShouldProcess("Comment.QuotedFileContentData"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Drive API ContentHintsData.ThumbnailData object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a ContentHintsData.ThumbnailData object which may be required as a parameter for some other Cmdlets in the Drive API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Drive.v3.Data.ContentHintsData.ThumbnailData</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GDriveContentHintsDataThumbnailDataObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GDriveContentHintsData.ThumbnailDataObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GDriveContentHintsDataThumbnailDataObj",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GDriveContentHintsData.ThumbnailDataObj")]
    [OutputType(typeof(File.ContentHintsData.ThumbnailData))]
    public class NewGDriveContentHintsDataThumbnailDataObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">The thumbnail data encoded with URL-safe Base64 (RFC 4648 section 5).</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The thumbnail data encoded with URL-safe Base64 (RFC 4648 section 5).")]
        public string Image { get; set; }

        /// <summary>
        /// <para type="description">The MIME type of the thumbnail.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The MIME type of the thumbnail.")]
        public string MimeType { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.Drive.v3.Data.File.ContentHintsData.ThumbnailData
            {
                Image = Image,
                MimeType = MimeType
            };

            if (ShouldProcess("ContentHintsData.ThumbnailData"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Drive API Permission object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a Permission object which may be required as a parameter for some other Cmdlets in the Drive API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Drive.v3.Data.Permission</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GDrivePermissionObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GDrivePermissionObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GDrivePermissionObj",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GDrivePermissionObj")]
    [OutputType(typeof(Permission))]
    public class NewGDrivePermissionObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">Whether the permission allows the file to be discovered through search. This is only applicable for permissions of type domain or anyone.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Whether the permission allows the file to be discovered through search. This is only applicable for permissions of type domain or anyone."
            )]
        public bool? AllowFileDiscovery { get; set; }

        /// <summary>
        /// <para type="description">A displayable name for users, groups or domains.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A displayable name for users, groups or domains.")]
        public string DisplayName { get; set; }

        /// <summary>
        /// <para type="description">The domain to which this permission refers.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The domain to which this permission refers.")]
        public string Domain { get; set; }

        /// <summary>
        /// <para type="description">The email address of the user or group to which this permission refers.</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The email address of the user or group to which this permission refers.")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// <para type="description">The ID of this permission. This is a unique identifier for the grantee, and is published in User resources as permissionId.</para>
        /// </summary>
        [Parameter(Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The ID of this permission. This is a unique identifier for the grantee, and is published in User resources as permissionId."
            )]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">A link to the user's profile photo, if available.</para>
        /// </summary>
        [Parameter(Position = 5,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A link to the user's profile photo, if available.")]
        public string PhotoLink { get; set; }

        /// <summary>
        /// <para type="description">The role granted by this permission. Valid values are:- owner- writer- commenter- reader</para>
        /// </summary>
        [Parameter(Position = 6,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The role granted by this permission. Valid values are:  \n- owner \n- writer \n- commenter \n- reader")
        ]
        public string Role { get; set; }

        /// <summary>
        /// <para type="description">The type of the grantee. Valid values are:- user- group- domain- anyone</para>
        /// </summary>
        [Parameter(Position = 7,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The type of the grantee. Valid values are:  \n- user \n- group \n- domain \n- anyone")]
        public string Type { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            var body = new Permission
            {
                AllowFileDiscovery = AllowFileDiscovery,
                DisplayName = DisplayName,
                Domain = Domain,
                EmailAddress = EmailAddress,
                Id = Id,
                PhotoLink = PhotoLink,
                Role = Role,
                Type = Type
            };

            if (ShouldProcess("Permission"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Drive API User object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a User object which may be required as a parameter for some other Cmdlets in the Drive API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Drive.v3.Data.User</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GDriveUserObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GDriveUserObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GDriveUserObj",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GDriveUserObj")]
    [OutputType(typeof(User))]
    public class NewGDriveUserObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">A plain text displayable name for this user.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A plain text displayable name for this user.")]
        public string DisplayName { get; set; }

        /// <summary>
        /// <para type="description">The email address of the user. This may not be present in certain contexts if the user has not made their email address visible to the requester.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The email address of the user. This may not be present in certain contexts if the user has not made their email address visible to the requester."
            )]
        public string EmailAddress { get; set; }

        /// <summary>
        /// <para type="description">Whether this user is the requesting user.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether this user is the requesting user.")]
        public bool? Me { get; set; }

        /// <summary>
        /// <para type="description">The user's ID as visible in Permission resources.</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The user's ID as visible in Permission resources.")]
        public string PermissionId { get; set; }

        /// <summary>
        /// <para type="description">A link to the user's profile photo, if available.</para>
        /// </summary>
        [Parameter(Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A link to the user's profile photo, if available.")]
        public string PhotoLink { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            var body = new User
            {
                DisplayName = DisplayName,
                EmailAddress = EmailAddress,
                Me = Me,
                PermissionId = PermissionId,
                PhotoLink = PhotoLink
            };

            if (ShouldProcess("User"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Drive API File.ImageMediaMetadataData object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a File.ImageMediaMetadataData object which may be required as a parameter for some other Cmdlets in the Drive API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Drive.v3.Data.File.ImageMediaMetadataData</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GDriveFileImageMediaMetadataDataObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GDriveFile.ImageMediaMetadataDataObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GDriveFileImageMediaMetadataDataObj",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GDriveFile.ImageMediaMetadataDataObj")]
    [OutputType(typeof(File.ImageMediaMetadataData))]
    public class NewGDriveFileImageMediaMetadataDataObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">The aperture used to create the photo (f-number).</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The aperture used to create the photo (f-number).")]
        public float? Aperture { get; set; }

        /// <summary>
        /// <para type="description">The make of the camera used to create the photo.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The make of the camera used to create the photo.")]
        public string CameraMake { get; set; }

        /// <summary>
        /// <para type="description">The model of the camera used to create the photo.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The model of the camera used to create the photo.")]
        public string CameraModel { get; set; }

        /// <summary>
        /// <para type="description">The color space of the photo.</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The color space of the photo.")]
        public string ColorSpace { get; set; }

        /// <summary>
        /// <para type="description">The exposure bias of the photo (APEX value).</para>
        /// </summary>
        [Parameter(Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The exposure bias of the photo (APEX value).")]
        public float? ExposureBias { get; set; }

        /// <summary>
        /// <para type="description">The exposure mode used to create the photo.</para>
        /// </summary>
        [Parameter(Position = 5,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The exposure mode used to create the photo.")]
        public string ExposureMode { get; set; }

        /// <summary>
        /// <para type="description">The length of the exposure, in seconds.</para>
        /// </summary>
        [Parameter(Position = 6,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The length of the exposure, in seconds.")]
        public float? ExposureTime { get; set; }

        /// <summary>
        /// <para type="description">Whether a flash was used to create the photo.</para>
        /// </summary>
        [Parameter(Position = 7,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether a flash was used to create the photo.")]
        public bool? FlashUsed { get; set; }

        /// <summary>
        /// <para type="description">The focal length used to create the photo, in millimeters.</para>
        /// </summary>
        [Parameter(Position = 8,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The focal length used to create the photo, in millimeters.")]
        public float? FocalLength { get; set; }

        /// <summary>
        /// <para type="description">The height of the image in pixels.</para>
        /// </summary>
        [Parameter(Position = 9,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The height of the image in pixels.")]
        public int? Height { get; set; }

        /// <summary>
        /// <para type="description">The ISO speed used to create the photo.</para>
        /// </summary>
        [Parameter(Position = 10,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ISO speed used to create the photo.")]
        public int? IsoSpeed { get; set; }

        /// <summary>
        /// <para type="description">The lens used to create the photo.</para>
        /// </summary>
        [Parameter(Position = 11,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The lens used to create the photo.")]
        public string Lens { get; set; }

        /// <summary>
        /// <para type="description">Geographic location information stored in the image.</para>
        /// </summary>
        [Parameter(Position = 12,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Geographic location information stored in the image.")]
        public File.ImageMediaMetadataData.LocationData Location { get; set; }

        /// <summary>
        /// <para type="description">The smallest f-number of the lens at the focal length used to create the photo (APEX value).</para>
        /// </summary>
        [Parameter(Position = 13,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The smallest f-number of the lens at the focal length used to create the photo (APEX value)."
            )]
        public float? MaxApertureValue { get; set; }

        /// <summary>
        /// <para type="description">The metering mode used to create the photo.</para>
        /// </summary>
        [Parameter(Position = 14,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The metering mode used to create the photo.")]
        public string MeteringMode { get; set; }

        /// <summary>
        /// <para type="description">The rotation in clockwise degrees from the image's original orientation.</para>
        /// </summary>
        [Parameter(Position = 15,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The rotation in clockwise degrees from the image's original orientation.")]
        public int? Rotation { get; set; }

        /// <summary>
        /// <para type="description">The type of sensor used to create the photo.</para>
        /// </summary>
        [Parameter(Position = 16,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The type of sensor used to create the photo.")]
        public string Sensor { get; set; }

        /// <summary>
        /// <para type="description">The distance to the subject of the photo, in meters.</para>
        /// </summary>
        [Parameter(Position = 17,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The distance to the subject of the photo, in meters.")]
        public int? SubjectDistance { get; set; }

        /// <summary>
        /// <para type="description">The date and time the photo was taken (EXIF DateTime).</para>
        /// </summary>
        [Parameter(Position = 18,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The date and time the photo was taken (EXIF DateTime).")]
        public string Time { get; set; }

        /// <summary>
        /// <para type="description">The white balance mode used to create the photo.</para>
        /// </summary>
        [Parameter(Position = 19,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The white balance mode used to create the photo.")]
        public string WhiteBalance { get; set; }

        /// <summary>
        /// <para type="description">The width of the image in pixels.</para>
        /// </summary>
        [Parameter(Position = 20,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The width of the image in pixels.")]
        public int? Width { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            var body = new File.ImageMediaMetadataData
            {
                Aperture = Aperture,
                CameraMake = CameraMake,
                CameraModel = CameraModel,
                ColorSpace = ColorSpace,
                ExposureBias = ExposureBias,
                ExposureMode = ExposureMode,
                ExposureTime = ExposureTime,
                FlashUsed = FlashUsed,
                FocalLength = FocalLength,
                Height = Height,
                IsoSpeed = IsoSpeed,
                Lens = Lens,
                Location = Location,
                MaxApertureValue = MaxApertureValue,
                MeteringMode = MeteringMode,
                Rotation = Rotation,
                Sensor = Sensor,
                SubjectDistance = SubjectDistance,
                Time = Time,
                WhiteBalance = WhiteBalance,
                Width = Width
            };

            if (ShouldProcess("File.ImageMediaMetadataData"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Drive API Comment object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a Comment object which may be required as a parameter for some other Cmdlets in the Drive API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Drive.v3.Data.Comment</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GDriveCommentObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GDriveCommentObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GDriveCommentObj",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GDriveCommentObj")]
    [OutputType(typeof(Comment))]
    public class NewGDriveCommentObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">A region of the document represented as a JSON string. See anchor documentation for details on how to define and interpret anchor properties.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "A region of the document represented as a JSON string. See anchor documentation for details on how to define and interpret anchor properties."
            )]
        public string Anchor { get; set; }

        /// <summary>
        /// <para type="description">The user who created the comment.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The user who created the comment.")]
        public User Author { get; set; }

        /// <summary>
        /// <para type="description">The plain text content of the comment. This field is used for setting the content, while htmlContent should be displayed.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The plain text content of the comment. This field is used for setting the content, while htmlContent should be displayed."
            )]
        public string Content { get; set; }

        /// <summary>
        /// <para type="description">The time at which the comment was created (RFC 3339 date-time).</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The time at which the comment was created (RFC 3339 date-time).")]
        public DateTime? CreatedTime { get; set; }

        /// <summary>
        /// <para type="description">Whether the comment has been deleted. A deleted comment has no content.</para>
        /// </summary>
        [Parameter(Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether the comment has been deleted. A deleted comment has no content.")]
        public bool? Deleted { get; set; }

        /// <summary>
        /// <para type="description">The content of the comment with HTML formatting.</para>
        /// </summary>
        [Parameter(Position = 5,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The content of the comment with HTML formatting.")]
        public string HtmlContent { get; set; }

        /// <summary>
        /// <para type="description">The ID of the comment.</para>
        /// </summary>
        [Parameter(Position = 6,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the comment.")]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">The last time the comment or any of its replies was modified (RFC 3339 date-time).</para>
        /// </summary>
        [Parameter(Position = 7,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The last time the comment or any of its replies was modified (RFC 3339 date-time).")]
        public DateTime? ModifiedTime { get; set; }

        /// <summary>
        /// <para type="description">The file content to which the comment refers, typically within the anchor region. For a text file, for example, this would be the text at the location of the comment.</para>
        /// </summary>
        [Parameter(Position = 8,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The file content to which the comment refers, typically within the anchor region. For a text file, for example, this would be the text at the location of the comment."
            )]
        public Comment.QuotedFileContentData QuotedFileContent { get; set; }

        /// <summary>
        /// <para type="description">The full list of replies to the comment in chronological order.</para>
        /// </summary>
        [Parameter(Position = 9,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The full list of replies to the comment in chronological order.")]
        public Reply[] Replies { get; set; }

        /// <summary>
        /// <para type="description">Whether the comment has been resolved by one of its replies.</para>
        /// </summary>
        [Parameter(Position = 10,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether the comment has been resolved by one of its replies.")]
        public bool? Resolved { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            var body = new Comment
            {
                Anchor = Anchor,
                Author = Author,
                Content = Content,
                CreatedTime = CreatedTime,
                Deleted = Deleted,
                HtmlContent = HtmlContent,
                Id = Id,
                ModifiedTime = ModifiedTime,
                QuotedFileContent = QuotedFileContent,
                Replies = Replies,
                Resolved = Resolved
            };

            if (ShouldProcess("Comment"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Drive API File object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a File object which may be required as a parameter for some other Cmdlets in the Drive API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Drive.v3.Data.File</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GDriveFileObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GDriveFileObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GDriveFileObj",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GDriveFileObj")]
    [OutputType(typeof(File))]
    public class NewGDriveFileObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">A collection of arbitrary key-value pairs which are private to the requesting app.Entries with null values are cleared in update and copy requests.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "A collection of arbitrary key-value pairs which are private to the requesting app.\nEntries with null values are cleared in update and copy requests."
            )]
        public IDictionary<string, string> AppProperties { get; set; }

        /// <summary>
        /// <para type="description">Capabilities the current user has on the file.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Capabilities the current user has on the file.")]
        public File.CapabilitiesData Capabilities { get; set; }

        /// <summary>
        /// <para type="description">Additional information about the content of the file. These fields are never populated in responses.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Additional information about the content of the file. These fields are never populated in responses.")]
        public File.ContentHintsData ContentHints { get; set; }

        /// <summary>
        /// <para type="description">The time at which the file was created (RFC 3339 date-time).</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The time at which the file was created (RFC 3339 date-time).")]
        public DateTime? CreatedTime { get; set; }

        /// <summary>
        /// <para type="description">A short description of the file.</para>
        /// </summary>
        [Parameter(Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A short description of the file.")]
        public string Description { get; set; }

        /// <summary>
        /// <para type="description">Whether the file has been explicitly trashed, as opposed to recursively trashed from a parent folder.</para>
        /// </summary>
        [Parameter(Position = 5,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Whether the file has been explicitly trashed, as opposed to recursively trashed from a parent folder.")
        ]
        public bool? ExplicitlyTrashed { get; set; }

        /// <summary>
        /// <para type="description">The final component of fullFileExtension. This is only available for files with binary content in Drive.</para>
        /// </summary>
        [Parameter(Position = 6,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The final component of fullFileExtension. This is only available for files with binary content in Drive."
            )]
        public string FileExtension { get; set; }

        /// <summary>
        /// <para type="description">The color for a folder as an RGB hex string. The supported colors are published in the folderColorPalette field of the About resource.If an unsupported color is specified, the closest color in the palette will be used instead.</para>
        /// </summary>
        [Parameter(Position = 7,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The color for a folder as an RGB hex string. The supported colors are published in the folderColorPalette field of the About resource.\nIf an unsupported color is specified, the closest color in the palette will be used instead."
            )]
        public string FolderColorRgb { get; set; }

        /// <summary>
        /// <para type="description">The full file extension extracted from the name field. May contain multiple concatenated extensions, such as "tar.gz". This is only available for files with binary content in Drive.This is automatically updated when the name field changes, however it is not cleared if the new name does not contain a valid extension.</para>
        /// </summary>
        [Parameter(Position = 8,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The full file extension extracted from the name field. May contain multiple concatenated extensions, such as \"tar.gz\". This is only available for files with binary content in Drive.\nThis is automatically updated when the name field changes, however it is not cleared if the new name does not contain a valid extension."
            )]
        public string FullFileExtension { get; set; }

        /// <summary>
        /// <para type="description">The ID of the file's head revision. This is currently only available for files with binary content in Drive.</para>
        /// </summary>
        [Parameter(Position = 9,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The ID of the file's head revision. This is currently only available for files with binary content in Drive."
            )]
        public string HeadRevisionId { get; set; }

        /// <summary>
        /// <para type="description">A static, unauthenticated link to the file's icon.</para>
        /// </summary>
        [Parameter(Position = 10,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A static, unauthenticated link to the file's icon.")]
        public string IconLink { get; set; }

        /// <summary>
        /// <para type="description">The ID of the file.</para>
        /// </summary>
        [Parameter(Position = 11,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the file.")]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">Additional metadata about image media, if available.</para>
        /// </summary>
        [Parameter(Position = 12,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Additional metadata about image media, if available.")]
        public File.ImageMediaMetadataData ImageMediaMetadata { get; set; }

        /// <summary>
        /// <para type="description">Whether the file was created or opened by the requesting app.</para>
        /// </summary>
        [Parameter(Position = 13,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether the file was created or opened by the requesting app.")]
        public bool? IsAppAuthorized { get; set; }

        /// <summary>
        /// <para type="description">The last user to modify the file.</para>
        /// </summary>
        [Parameter(Position = 14,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The last user to modify the file.")]
        public User LastModifyingUser { get; set; }

        /// <summary>
        /// <para type="description">The MD5 checksum for the content of the file. This is only applicable to files with binary content in Drive.</para>
        /// </summary>
        [Parameter(Position = 15,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The MD5 checksum for the content of the file. This is only applicable to files with binary content in Drive."
            )]
        public string Md5Checksum { get; set; }

        /// <summary>
        /// <para type="description">The MIME type of the file.Drive will attempt to automatically detect an appropriate value from uploaded content if no value is provided. The value cannot be changed unless a new revision is uploaded.If a file is created with a Google Doc MIME type, the uploaded content will be imported if possible. The supported import formats are published in the About resource.</para>
        /// </summary>
        [Parameter(Position = 16,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The MIME type of the file.\nDrive will attempt to automatically detect an appropriate value from uploaded content if no value is provided. The value cannot be changed unless a new revision is uploaded.\nIf a file is created with a Google Doc MIME type, the uploaded content will be imported if possible. The supported import formats are published in the About resource."
            )]
        public string MimeType { get; set; }

        /// <summary>
        /// <para type="description">The last time the file was modified by the user (RFC 3339 date-time).</para>
        /// </summary>
        [Parameter(Position = 17,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The last time the file was modified by the user (RFC 3339 date-time).")]
        public DateTime? ModifiedByMeTime { get; set; }

        /// <summary>
        /// <para type="description">The last time the file was modified by anyone (RFC 3339 date-time).Note that setting modifiedTime will also update modifiedByMeTime for the user.</para>
        /// </summary>
        [Parameter(Position = 18,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The last time the file was modified by anyone (RFC 3339 date-time).\nNote that setting modifiedTime will also update modifiedByMeTime for the user."
            )]
        public DateTime? ModifiedTime { get; set; }

        /// <summary>
        /// <para type="description">The name of the file. This is not necessarily unique within a folder.</para>
        /// </summary>
        [Parameter(Position = 19,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the file. This is not necessarily unique within a folder.")]
        public string Name { get; set; }

        /// <summary>
        /// <para type="description">The original filename of the uploaded content if available, or else the original value of the name field. This is only available for files with binary content in Drive.</para>
        /// </summary>
        [Parameter(Position = 20,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The original filename of the uploaded content if available, or else the original value of the name field. This is only available for files with binary content in Drive."
            )]
        public string OriginalFilename { get; set; }

        /// <summary>
        /// <para type="description">Whether the user owns the file.</para>
        /// </summary>
        [Parameter(Position = 21,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether the user owns the file.")]
        public bool? OwnedByMe { get; set; }

        /// <summary>
        /// <para type="description">The owners of the file. Currently, only certain legacy files may have more than one owner.</para>
        /// </summary>
        [Parameter(Position = 22,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The owners of the file. Currently, only certain legacy files may have more than one owner.")]
        public User[] Owners { get; set; }

        /// <summary>
        /// <para type="description">The IDs of the parent folders which contain the file.If not specified as part of a create request, the file will be placed directly in the My Drive folder. Update requests must use the addParents and removeParents parameters to modify the values.</para>
        /// </summary>
        [Parameter(Position = 23,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The IDs of the parent folders which contain the file.\nIf not specified as part of a create request, the file will be placed directly in the My Drive folder. Update requests must use the addParents and removeParents parameters to modify the values."
            )]
        public string[] Parents { get; set; }

        /// <summary>
        /// <para type="description">The full list of permissions for the file. This is only available if the requesting user can share the file.</para>
        /// </summary>
        [Parameter(Position = 24,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The full list of permissions for the file. This is only available if the requesting user can share the file."
            )]
        public Permission[] Permissions { get; set; }

        /// <summary>
        /// <para type="description">A collection of arbitrary key-value pairs which are visible to all apps.Entries with null values are cleared in update and copy requests.</para>
        /// </summary>
        [Parameter(Position = 25,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "A collection of arbitrary key-value pairs which are visible to all apps.\nEntries with null values are cleared in update and copy requests."
            )]
        public IDictionary<string, string> Properties { get; set; }

        /// <summary>
        /// <para type="description">The number of storage quota bytes used by the file. This includes the head revision as well as previous revisions with keepForever enabled.</para>
        /// </summary>
        [Parameter(Position = 26,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The number of storage quota bytes used by the file. This includes the head revision as well as previous revisions with keepForever enabled."
            )]
        public long? QuotaBytesUsed { get; set; }

        /// <summary>
        /// <para type="description">Whether the file has been shared.</para>
        /// </summary>
        [Parameter(Position = 27,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether the file has been shared.")]
        public bool? Shared { get; set; }

        /// <summary>
        /// <para type="description">The time at which the file was shared with the user, if applicable (RFC 3339 date-time).</para>
        /// </summary>
        [Parameter(Position = 28,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The time at which the file was shared with the user, if applicable (RFC 3339 date-time).")]
        public DateTime? SharedWithMeTime { get; set; }

        /// <summary>
        /// <para type="description">The user who shared the file with the requesting user, if applicable.</para>
        /// </summary>
        [Parameter(Position = 29,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The user who shared the file with the requesting user, if applicable.")]
        public User SharingUser { get; set; }

        /// <summary>
        /// <para type="description">The size of the file's content in bytes. This is only applicable to files with binary content in Drive.</para>
        /// </summary>
        [Parameter(Position = 30,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The size of the file's content in bytes. This is only applicable to files with binary content in Drive."
            )]
        public long? Size { get; set; }

        /// <summary>
        /// <para type="description">The list of spaces which contain the file. The currently supported values are 'drive', 'appDataFolder' and 'photos'.</para>
        /// </summary>
        [Parameter(Position = 31,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The list of spaces which contain the file. The currently supported values are 'drive', 'appDataFolder' and 'photos'."
            )]
        public string[] Spaces { get; set; }

        /// <summary>
        /// <para type="description">Whether the user has starred the file.</para>
        /// </summary>
        [Parameter(Position = 32,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether the user has starred the file.")]
        public bool? Starred { get; set; }

        /// <summary>
        /// <para type="description">A short-lived link to the file's thumbnail, if available. Typically lasts on the order of hours.</para>
        /// </summary>
        [Parameter(Position = 33,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "A short-lived link to the file's thumbnail, if available. Typically lasts on the order of hours.")]
        public string ThumbnailLink { get; set; }

        /// <summary>
        /// <para type="description">Whether the file has been trashed, either explicitly or from a trashed parent folder. Only the owner may trash a file, and other users cannot see files in the owner's trash.</para>
        /// </summary>
        [Parameter(Position = 34,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Whether the file has been trashed, either explicitly or from a trashed parent folder. Only the owner may trash a file, and other users cannot see files in the owner's trash."
            )]
        public bool? Trashed { get; set; }

        /// <summary>
        /// <para type="description">A monotonically increasing version number for the file. This reflects every change made to the file on the server, even those not visible to the user.</para>
        /// </summary>
        [Parameter(Position = 35,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "A monotonically increasing version number for the file. This reflects every change made to the file on the server, even those not visible to the user."
            )]
        public long? Version { get; set; }

        /// <summary>
        /// <para type="description">Additional metadata about video media. This may not be available immediately upon upload.</para>
        /// </summary>
        [Parameter(Position = 36,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Additional metadata about video media. This may not be available immediately upon upload.")]
        public File.VideoMediaMetadataData VideoMediaMetadata { get; set; }

        /// <summary>
        /// <para type="description">Whether the file has been viewed by this user.</para>
        /// </summary>
        [Parameter(Position = 37,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether the file has been viewed by this user.")]
        public bool? ViewedByMe { get; set; }

        /// <summary>
        /// <para type="description">The last time the file was viewed by the user (RFC 3339 date-time).</para>
        /// </summary>
        [Parameter(Position = 38,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The last time the file was viewed by the user (RFC 3339 date-time).")]
        public DateTime? ViewedByMeTime { get; set; }

        /// <summary>
        /// <para type="description">Whether users with only reader or commenter permission can copy the file's content. This affects copy, download, and print operations.</para>
        /// </summary>
        [Parameter(Position = 39,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Whether users with only reader or commenter permission can copy the file's content. This affects copy, download, and print operations."
            )]
        public bool? ViewersCanCopyContent { get; set; }

        /// <summary>
        /// <para type="description">A link for downloading the content of the file in a browser. This is only available for files with binary content in Drive.</para>
        /// </summary>
        [Parameter(Position = 40,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "A link for downloading the content of the file in a browser. This is only available for files with binary content in Drive."
            )]
        public string WebContentLink { get; set; }

        /// <summary>
        /// <para type="description">A link for opening the file in a relevant Google editor or viewer in a browser.</para>
        /// </summary>
        [Parameter(Position = 41,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A link for opening the file in a relevant Google editor or viewer in a browser.")]
        public string WebViewLink { get; set; }

        /// <summary>
        /// <para type="description">Whether users with only writer permission can modify the file's permissions.</para>
        /// </summary>
        [Parameter(Position = 42,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether users with only writer permission can modify the file's permissions.")]
        public bool? WritersCanShare { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            var body = new File
            {
                AppProperties = AppProperties,
                Capabilities = Capabilities,
                ContentHints = ContentHints,
                CreatedTime = CreatedTime,
                Description = Description,
                ExplicitlyTrashed = ExplicitlyTrashed,
                FileExtension = FileExtension,
                FolderColorRgb = FolderColorRgb,
                FullFileExtension = FullFileExtension,
                HeadRevisionId = HeadRevisionId,
                IconLink = IconLink,
                Id = Id,
                ImageMediaMetadata = ImageMediaMetadata,
                IsAppAuthorized = IsAppAuthorized,
                LastModifyingUser = LastModifyingUser,
                Md5Checksum = Md5Checksum,
                MimeType = MimeType,
                ModifiedByMeTime = ModifiedByMeTime,
                ModifiedTime = ModifiedTime,
                Name = Name,
                OriginalFilename = OriginalFilename,
                OwnedByMe = OwnedByMe,
                Owners = Owners,
                Parents = Parents,
                Permissions = Permissions,
                Properties = Properties,
                QuotaBytesUsed = QuotaBytesUsed,
                Shared = Shared,
                SharedWithMeTime = SharedWithMeTime,
                SharingUser = SharingUser,
                Size = Size,
                Spaces = Spaces,
                Starred = Starred,
                ThumbnailLink = ThumbnailLink,
                Trashed = Trashed,
                Version = Version,
                VideoMediaMetadata = VideoMediaMetadata,
                ViewedByMe = ViewedByMe,
                ViewedByMeTime = ViewedByMeTime,
                ViewersCanCopyContent = ViewersCanCopyContent,
                WebContentLink = WebContentLink,
                WebViewLink = WebViewLink,
                WritersCanShare = WritersCanShare
            };

            if (ShouldProcess("File"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Drive API ImageMediaMetadataData.LocationData object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a ImageMediaMetadataData.LocationData object which may be required as a parameter for some other Cmdlets in the Drive API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Drive.v3.Data.ImageMediaMetadataData.LocationData</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GDriveImageMediaMetadataDataLocationDataObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GDriveImageMediaMetadataData.LocationDataObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GDriveImageMediaMetadataDataLocationDataObj",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GDriveImageMediaMetadataData.LocationDataObj")]
    [OutputType(typeof(Google.Apis.Drive.v3.Data.File.ImageMediaMetadataData.LocationData))]
    public class NewGDriveImageMediaMetadataDataLocationDataObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">The altitude stored in the image.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The altitude stored in the image.")]
        public double? Altitude { get; set; }

        /// <summary>
        /// <para type="description">The latitude stored in the image.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The latitude stored in the image.")]
        public double? Latitude { get; set; }

        /// <summary>
        /// <para type="description">The longitude stored in the image.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The longitude stored in the image.")]
        public double? Longitude { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.Drive.v3.Data.File.ImageMediaMetadataData.LocationData
            {
                Altitude = Altitude,
                Latitude = Latitude,
                Longitude = Longitude
            };

            if (ShouldProcess("ImageMediaMetadataData.LocationData"))
            {
                WriteObject(body);
            }
        }
    }
}

namespace gShell.Cmdlets.Drive.About
{
    /// <summary>
    /// <para type="synopsis">Gets information about the user, the user's Drive, and system capabilities.</para>
    /// <para type="description">Gets information about the user, the user's Drive, and system capabilities.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Get-GDriveAbout</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GDriveAbout">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GDriveAbout",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GDriveAbout")]
    public class GetGDriveAboutCommand : DriveBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Drive About", "Get-GDriveAbout"))
            {
                WriteObject(about.Get(StandardQueryParams:StandardQueryParams));
            }
        }
    }
}

namespace gShell.Cmdlets.Drive.Changes
{
    /// <summary>
    /// <para type="synopsis">Gets the starting pageToken for listing future changes.</para>
    /// <para type="description">Gets the starting pageToken for listing future changes.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Get-GDriveChangeStartPageToken</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GDriveChangeStartPageToken">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GDriveChangeStartPageToken",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GDriveChangeStartPageToken")]
    public class GetGDriveChangeStartPageTokenCommand : DriveBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Drive Changes", "Get-GDriveChangeStartPageToken"))
            {
                WriteObject(changes.GetStartPageToken(StandardQueryParams:StandardQueryParams));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Lists changes for a user.</para>
    /// <para type="description">Lists changes for a user.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Get-GDriveChange -PageToken $SomePageTokenString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GDriveChange">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GDriveChange",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GDriveChange")]
    public class GetGDriveChangeCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The token for continuing a previous list request on the next page. This should be set to the value of 'nextPageToken' from the previous response or to the response from the getStartPageToken method.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The token for continuing a previous list request on the next page. This should be set to the value of 'nextPageToken' from the previous response or to the response from the getStartPageToken method."
            )]
        public string PageToken { get; set; }

        /// <summary>
        /// <para type="description">Whether to include changes indicating that items have left the view of the changes list, for example by deletion or lost access.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Whether to include changes indicating that items have left the view of the changes list, for example by deletion or lost access."
            )]
        public bool? IncludeRemoved { get; set; }

        /// <summary>
        /// <para type="description">The maximum number of changes to return per page.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The maximum number of changes to return per page.")]
        public int? PageSize { get; set; }

        /// <summary>
        /// <para type="description">Whether to restrict the results to changes inside the My Drive hierarchy. This omits changes to files such as those in the Application Data folder or shared files which have not been added to My Drive.</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Whether to restrict the results to changes inside the My Drive hierarchy. This omits changes to files such as those in the Application Data folder or shared files which have not been added to My Drive."
            )]
        public bool? RestrictToMyDrive { get; set; }

        /// <summary>
        /// <para type="description">A comma-separated list of spaces to query within the user corpus. Supported values are 'drive', 'appDataFolder' and 'photos'.</para>
        /// </summary>
        [Parameter(Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "A comma-separated list of spaces to query within the user corpus. Supported values are 'drive', 'appDataFolder' and 'photos'."
            )]
        public string Spaces { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Drive Changes", "Get-GDriveChange"))
            {
                var properties = new gDrive.Changes.ChangesListProperties
                {
                    IncludeRemoved = IncludeRemoved,
                    PageSize = PageSize,
                    RestrictToMyDrive = RestrictToMyDrive,
                    Spaces = Spaces
                };


                WriteObject(changes.List(PageToken, properties, StandardQueryParams: StandardQueryParams).Changes);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Subscribes to changes for a user.</para>
    /// <para type="description">Subscribes to changes for a user.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Watch-GDriveChange -PageToken $SomePageTokenString -ChannelBody $SomeChannelObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Watch-GDriveChange">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Watch, "GDriveChange",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Watch-GDriveChange")]
    public class WatchGDriveChangeCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The token for continuing a previous list request on the next page. This should be set to the value of 'nextPageToken' from the previous response or to the response from the getStartPageToken method.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The token for continuing a previous list request on the next page. This should be set to the value of 'nextPageToken' from the previous response or to the response from the getStartPageToken method."
            )]
        public string PageToken { get; set; }

        /// <summary>
        /// <para type="description">An notification channel used to watch for resource changes.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "An notification channel used to watch for resource changes.")]
        public Channel ChannelBody { get; set; }

        /// <summary>
        /// <para type="description">Whether to include changes indicating that items have left the view of the changes list, for example by deletion or lost access.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Whether to include changes indicating that items have left the view of the changes list, for example by deletion or lost access."
            )]
        public bool? IncludeRemoved { get; set; }

        /// <summary>
        /// <para type="description">The maximum number of changes to return per page.</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The maximum number of changes to return per page.")]
        public int? PageSize { get; set; }

        /// <summary>
        /// <para type="description">Whether to restrict the results to changes inside the My Drive hierarchy. This omits changes to files such as those in the Application Data folder or shared files which have not been added to My Drive.</para>
        /// </summary>
        [Parameter(Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Whether to restrict the results to changes inside the My Drive hierarchy. This omits changes to files such as those in the Application Data folder or shared files which have not been added to My Drive."
            )]
        public bool? RestrictToMyDrive { get; set; }

        /// <summary>
        /// <para type="description">A comma-separated list of spaces to query within the user corpus. Supported values are 'drive', 'appDataFolder' and 'photos'.</para>
        /// </summary>
        [Parameter(Position = 5,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "A comma-separated list of spaces to query within the user corpus. Supported values are 'drive', 'appDataFolder' and 'photos'."
            )]
        public string Spaces { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Drive Changes", "Watch-GDriveChange"))
            {
                var properties = new gDrive.Changes.ChangesWatchProperties
                {
                    IncludeRemoved = IncludeRemoved,
                    PageSize = PageSize,
                    RestrictToMyDrive = RestrictToMyDrive,
                    Spaces = Spaces
                };


                WriteObject(changes.Watch(ChannelBody, PageToken, properties, StandardQueryParams: StandardQueryParams));
            }
        }
    }
}

namespace gShell.Cmdlets.Drive.Channels
{
    /// <summary>
    /// <para type="synopsis">Stop watching resources through this channel</para>
    /// <para type="description">Stop watching resources through this channel</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Stop-GDriveChannel -ChannelBody $SomeChannelObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Stop-GDriveChannel">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "GDriveChannel",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Stop-GDriveChannel")]
    public class StopGDriveChannelCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">An notification channel used to watch for resource changes.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "An notification channel used to watch for resource changes.")]
        public Channel ChannelBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Drive Channels", "Stop-GDriveChannel"))
            {
                channels.Stop(ChannelBody, StandardQueryParams: StandardQueryParams);
            }
        }
    }
}

namespace gShell.Cmdlets.Drive.Comments
{
    /// <summary>
    /// <para type="synopsis">Creates a new comment on a file.</para>
    /// <para type="description">Creates a new comment on a file.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GDriveComment -FileId $SomeFileIdString -CommentBody $SomeCommentObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GDriveComment">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GDriveComment",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GDriveComment")]
    public class NewGDriveCommentCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The ID of the file.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the file.")]
        public string FileId { get; set; }

        /// <summary>
        /// <para type="description">A comment on a file.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A comment on a file.")]
        public Comment CommentBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Drive Comments", "New-GDriveComment"))
            {
                WriteObject(comments.Create(CommentBody, FileId, StandardQueryParams: StandardQueryParams));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Deletes a comment.</para>
    /// <para type="description">Deletes a comment.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Remove-GDriveComment -FileId $SomeFileIdString -CommentId $SomeCommentIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GDriveComment">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GDriveComment",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GDriveComment")]
    public class RemoveGDriveCommentCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The ID of the file.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the file.")]
        public string FileId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the comment.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the comment.")]
        public string CommentId { get; set; }

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
            if (ShouldProcess("Drive Comments", "Remove-GDriveComment"))
            {
                
            }

            string toRemoveTarget = "Drive Comment";

			if (ShouldProcess(toRemoveTarget))
			{	
				if (Force || ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
				{
					try
					{
						WriteDebug("Attempting to remove " + toRemoveTarget + "...");

                        comments.Delete(FileId, CommentId, StandardQueryParams: StandardQueryParams);
							
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
    /// <para type="synopsis">Gets a comment by ID.</para>
    /// <para type="description">Gets a comment by ID.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Get-GDriveComment -FileId $SomeFileIdString -CommentId $SomeCommentIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\> Get-GDriveComment -FileId $SomeFileIdString -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GDriveComment">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GDriveComment",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GDriveComment")]
    public class GetGDriveCommentCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The ID of the file.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the file.")]
        public string FileId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the comment.</para>
        /// </summary>
        [Parameter(Position = 1,
            ParameterSetName = "one",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the comment.")]
        public string CommentId { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results</para>
        /// </summary>
        [Parameter(Position = 1,
            ParameterSetName = "list",
            Mandatory = true,
            HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }

        /// <summary>
        /// <para type="description">Whether to return deleted comments. Deleted comments will not include their original content.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Whether to return deleted comments. Deleted comments will not include their original content.")]
        public bool? IncludeDeleted { get; set; }

        /// <summary>
        /// <para type="description">The maximum number of comments to return per page.</para>
        /// </summary>
        [Parameter(Position = 3,
            ParameterSetName="list",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The maximum number of comments to return per page.")]
        public int? PageSize { get; set; }

        /// <summary>
        /// <para type="description">The minimum value of 'modifiedTime' for the result comments (RFC 3339 date-time).</para>
        /// </summary>
        [Parameter(Position = 4,
            ParameterSetName = "list",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The minimum value of 'modifiedTime' for the result comments (RFC 3339 date-time).")]
        public string StartModifiedTime { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Drive Comments", "Get-GDriveComment"))
            {
                if (ParameterSetName == "one")
                {
                    var properties = new gDrive.Comments.CommentsGetProperties
                    {
                        IncludeDeleted = IncludeDeleted
                    };

                    WriteObject(comments.Get(FileId, CommentId, properties, StandardQueryParams: StandardQueryParams));
                }
                else
                {
                    var properties = new gDrive.Comments.CommentsListProperties
                    {
                        IncludeDeleted = IncludeDeleted,
                        PageSize = PageSize,
                        StartModifiedTime = StartModifiedTime
                    };

                    WriteObject(comments.List(FileId, properties, StandardQueryParams: StandardQueryParams).SelectMany(x => x.Comments).ToList());
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Updates a comment with patch semantics.</para>
    /// <para type="description">Updates a comment with patch semantics.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Update-GDriveComment -FileId $SomeFileIdString -CommentId $SomeCommentIdString -CommentBody $SomeCommentObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Update-GDriveComment">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsData.Update, "GDriveComment",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Update-GDriveComment")]
    public class UpdateGDriveCommentCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The ID of the file.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the file.")]
        public string FileId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the comment.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the comment.")]
        public string CommentId { get; set; }

        /// <summary>
        /// <para type="description">A comment on a file.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A comment on a file.")]
        public Comment CommentBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Drive Comments", "Update-GDriveComment"))
            {
                WriteObject(comments.Update(CommentBody, FileId, CommentId, StandardQueryParams: StandardQueryParams));
            }
        }
    }
}

namespace gShell.Cmdlets.Drive.Files
{
    /// <summary>
    /// <para type="synopsis">Creates a copy of a file and applies any requested updates with patch semantics.</para>
    /// <para type="description">Creates a copy of a file and applies any requested updates with patch semantics.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Copy-GDriveFile -FileId $SomeFileIdString -FileBody $SomeFileObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Copy-GDriveFile">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Copy, "GDriveFile",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Copy-GDriveFile")]
    public class CopyGDriveFileCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The ID of the file.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the file.")]
        public string FileId { get; set; }

        /// <summary>
        /// <para type="description">The metadata for a file.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The metadata for a file.")]
        public File FileBody { get; set; }

        /// <summary>
        /// <para type="description">Whether to ignore the domain's default visibility settings for the created file. Domain administrators can choose to make all uploaded files visible to the domain by default; this parameter bypasses that behavior for the request. Permissions are still inherited from parent folders.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Whether to ignore the domain's default visibility settings for the created file. Domain administrators can choose to make all uploaded files visible to the domain by default; this parameter bypasses that behavior for the request. Permissions are still inherited from parent folders."
            )]
        public bool? IgnoreDefaultVisibility { get; set; }

        /// <summary>
        /// <para type="description">Whether to set the 'keepForever' field in the new head revision. This is only applicable to files with binary content in Drive.</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Whether to set the 'keepForever' field in the new head revision. This is only applicable to files with binary content in Drive."
            )]
        public bool? KeepRevisionForever { get; set; }

        /// <summary>
        /// <para type="description">A language hint for OCR processing during image import (ISO 639-1 code).</para>
        /// </summary>
        [Parameter(Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A language hint for OCR processing during image import (ISO 639-1 code).")]
        public string OcrLanguage { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Drive Files", "Copy-GDriveFile"))
            {
                var properties = new gDrive.Files.FilesCopyProperties
                {
                    IgnoreDefaultVisibility = IgnoreDefaultVisibility,
                    KeepRevisionForever = KeepRevisionForever,
                    OcrLanguage = OcrLanguage
                };


                WriteObject(files.Copy(FileBody, FileId, properties, StandardQueryParams: StandardQueryParams));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new file.</para>
    /// <para type="description">Creates a new file.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GDriveFile -FileBody $SomeFileObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GDriveFile">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GDriveFile",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GDriveFile")]
    public class NewGDriveFileCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The metadata for a file.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The metadata for a file.")]
        public File FileBody { get; set; }

        /// <summary>
        /// <para type="description">Whether to ignore the domain's default visibility settings for the created file. Domain administrators can choose to make all uploaded files visible to the domain by default; this parameter bypasses that behavior for the request. Permissions are still inherited from parent folders.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Whether to ignore the domain's default visibility settings for the created file. Domain administrators can choose to make all uploaded files visible to the domain by default; this parameter bypasses that behavior for the request. Permissions are still inherited from parent folders."
            )]
        public bool? IgnoreDefaultVisibility { get; set; }

        /// <summary>
        /// <para type="description">Whether to set the 'keepForever' field in the new head revision. This is only applicable to files with binary content in Drive.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Whether to set the 'keepForever' field in the new head revision. This is only applicable to files with binary content in Drive."
            )]
        public bool? KeepRevisionForever { get; set; }

        /// <summary>
        /// <para type="description">A language hint for OCR processing during image import (ISO 639-1 code).</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A language hint for OCR processing during image import (ISO 639-1 code).")]
        public string OcrLanguage { get; set; }

        /// <summary>
        /// <para type="description">Whether to use the uploaded content as indexable text.</para>
        /// </summary>
        [Parameter(Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether to use the uploaded content as indexable text.")]
        public bool? UseContentAsIndexableText { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Drive Files", "New-GDriveFile"))
            {
                var properties = new gDrive.Files.FilesCreateProperties
                {
                    IgnoreDefaultVisibility = IgnoreDefaultVisibility,
                    KeepRevisionForever = KeepRevisionForever,
                    OcrLanguage = OcrLanguage,
                    UseContentAsIndexableText = UseContentAsIndexableText
                };


                WriteObject(files.Create(FileBody, properties, StandardQueryParams: StandardQueryParams));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Permanently deletes a file owned by the user without moving it to the trash. If the target is a folder, all descendants owned by the user are also deleted.</para>
    /// <para type="description">Permanently deletes a file owned by the user without moving it to the trash. If the target is a folder, all descendants owned by the user are also deleted.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Remove-GDriveFile -FileId $SomeFileIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GDriveFile">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GDriveFile",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GDriveFile")]
    public class RemoveGDriveFileCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The ID of the file.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the file.")]
        public string FileId { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            string toRemoveTarget = "Drive Files";

			if (ShouldProcess(toRemoveTarget))
			{	
				if (Force || ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
				{
					try
					{
						WriteDebug("Attempting to remove " + toRemoveTarget + "...");

                        files.Delete(FileId, StandardQueryParams: StandardQueryParams);
							
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
    /// <para type="synopsis">Permanently deletes all of the user's trashed files.</para>
    /// <para type="description">Permanently deletes all of the user's trashed files.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Clear-GDriveTrash</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Clear-GDriveTrash">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Clear, "GDriveTrash",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Clear-GDriveTrash")]
    public class ClearGDriveTrashCommand : DriveBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting")]
        public SwitchParameter Force { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            string toRemoveTarget = "Files in Drive Trash";

			if (ShouldProcess(toRemoveTarget))
			{	
				if (Force || ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
				{
					try
					{
						WriteDebug("Attempting to remove " + toRemoveTarget + "...");

                        files.EmptyTrash(StandardQueryParams:StandardQueryParams);
							
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
    /// <para type="synopsis">Exports a Google Doc to the requested MIME type and returns the exported content.</para>
    /// <para type="description">Exports a Google Doc to the requested MIME type and returns the exported content.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Export-GDriveFile -FileId $SomeFileIdString -MimeType $SomeMimeTypeString -DownloadPath $SomeDownloadPath</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Export-GDriveFile">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsData.Export, "GDriveFile",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Export-GDriveFile")]
    public class ExportGDriveFileCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The ID of the file.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the file.")]
        public string FileId { get; set; }

        /// <summary>
        /// <para type="description">The MIME type of the format requested for this export. For details on the acceptable MIME types, please see uri="https://developers.google.com/drive/v3/web/manage-downloads">[DownloadFiles]</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The MIME type of the format requested for this export. For details on the acceptable MIME types, please see uri=\"https://developers.google.com/drive/v3/web/manage-downloads\">[DownloadFiles]")]
        public string MimeType { get; set; }

        /// <summary>
        /// <para type="description">The target download path of the file, including filename and extension.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The target download path of the file, including filename and extension.")]
        public string DownloadPath { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Drive Files", "Export-GDriveFile"))
            {
                files.Export(FileId, MimeType, DownloadPath, StandardQueryParams: StandardQueryParams);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Generates a set of file IDs which can be provided in create requests.</para>
    /// <para type="description">Generates a set of file IDs which can be provided in create requests.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GDriveFileId</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GDriveFileId">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet("New", "GDriveFileId",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GDriveFileId")]
    public class NewGDriveFileIdCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The number of IDs to return.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The number of IDs to return.")]
        public int? Count { get; set; }

        /// <summary>
        /// <para type="description">The space in which the IDs can be used to create new files. Supported values are 'drive' and 'appDataFolder'.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The space in which the IDs can be used to create new files. Supported values are 'drive' and 'appDataFolder'."
            )]
        public DriveIdSpaceEnum? Space { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Drive Files", "New-GDriveFileId"))
            {
                var properties = new gDrive.Files.FilesGenerateIdsProperties
                {
                    Count = Count
                };

                if (Space.HasValue) properties.Space = Space.Value.ToString();

                WriteObject(files.GenerateIds(properties, StandardQueryParams: StandardQueryParams));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Gets a file's metadata or content by ID.</para>
    /// <para type="description">Gets a file's metadata or content by ID.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Get-GDriveFile -FileId $SomeFileIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\> List-GDriveFile -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GDriveFile">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GDriveFile",
        SupportsShouldProcess = true,
        DefaultParameterSetName = "one",
        HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GDriveFile")]
    public class GetGDriveFileCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The ID of the file.</para>
        /// </summary>
        [Parameter(Position = 0,
            ParameterSetName = "one",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the file.")]
        public string FileId { get; set; }

        /// <summary>
        /// <para type="description">Whether the user is acknowledging the risk of downloading known malware or other abusive files. This is only applicable when alt=media.</para>
        /// </summary>
        [Parameter(Position = 1,
            ParameterSetName = "one",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Whether the user is acknowledging the risk of downloading known malware or other abusive files. This is only applicable when alt=media."
            )]
        public bool? AcknowledgeAbuse { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results</para>
        /// </summary>
        [Parameter(Position = 0,
            ParameterSetName = "list",
            Mandatory = true,
            HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }

        /// <summary>
        /// <para type="description">The source of files to list.</para>
        /// </summary>
        [Parameter(Position = 1,
            ParameterSetName = "list",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The source of files to list.")]
        public FilesResource.ListRequest.CorpusEnum? Corpus { get; set; }

        /// <summary>
        /// <para type="description">A comma-separated list of sort keys. Valid keys are 'createdTime', 'folder', 'modifiedByMeTime', 'modifiedTime', 'name', 'quotaBytesUsed', 'recency', 'sharedWithMeTime', 'starred', and 'viewedByMeTime'. Each key sorts ascending by default, but may be reversed with the 'desc' modifier. Example usage: ?orderBy=folder,modifiedTime desc,name. Please note that there is a current limitation for users with approximately one million files in which the requested sort order is ignored.</para>
        /// </summary>
        [Parameter(Position = 2,
            ParameterSetName = "list",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "A comma-separated list of sort keys. Valid keys are 'createdTime', 'folder', 'modifiedByMeTime', 'modifiedTime', 'name', 'quotaBytesUsed', 'recency', 'sharedWithMeTime', 'starred', and 'viewedByMeTime'. Each key sorts ascending by default, but may be reversed with the 'desc' modifier. Example usage: ?orderBy=folder,modifiedTime desc,name. Please note that there is a current limitation for users with approximately one million files in which the requested sort order is ignored."
            )]
        public string OrderBy { get; set; }

        /// <summary>
        /// <para type="description">The maximum number of files to return per page.</para>
        /// </summary>
        [Parameter(Position = 3,
            ParameterSetName = "list",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The maximum number of files to return per page.")]
        public int? PageSize { get; set; }

        /// <summary>
        /// <para type="description">A query for filtering the file results. See the "Search for Files" guide for supported syntax.</para>
        /// </summary>
        [Parameter(Position = 4,
            ParameterSetName = "list",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "A query for filtering the file results. See the \"Search for Files\" guide for supported syntax.")]
        public string Q { get; set; }

        /// <summary>
        /// <para type="description">A comma-separated list of spaces to query within the corpus. Supported values are 'drive', 'appDataFolder' and 'photos'.</para>
        /// </summary>
        [Parameter(Position = 5,
            ParameterSetName = "list",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "A comma-separated list of spaces to query within the corpus. Supported values are 'drive', 'appDataFolder' and 'photos'."
            )]
        public string Spaces { get; set; }

        /// <summary>
        /// <para type="description">Maximum number of results to return.</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = "list",
        HelpMessage = "Maximum number of results to return.")]
        public int? MaxResults { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Drive Files", "Get-GDriveFile"))
            {
                if (ParameterSetName == "one")
                {
                    var properties = new gDrive.Files.FilesGetProperties
                    {
                        AcknowledgeAbuse = AcknowledgeAbuse
                    };

                    WriteObject(files.Get(FileId, properties, StandardQueryParams: StandardQueryParams));
                }
                else
                {
                    var properties = new gDrive.Files.FilesListProperties
                    {
                        Corpus = Corpus,
                        OrderBy = OrderBy,
                        PageSize = PageSize,
                        Q = Q,
                        Spaces = Spaces
                    };

                    if (MaxResults.HasValue) properties.TotalResults = MaxResults.Value;

                    WriteObject(files.List(properties, StandardQueryParams: StandardQueryParams).SelectMany(x => x.Files).ToList());
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Updates a file's metadata and/or content with patch semantics.</para>
    /// <para type="description">Updates a file's metadata and/or content with patch semantics.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Update-GDriveFile -FileId $SomeFileIdString -FileBody $SomeFileObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Update-GDriveFile">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsData.Update, "GDriveFile",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Update-GDriveFile")]
    public class UpdateGDriveFileCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The ID of the file.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the file.")]
        public string FileId { get; set; }

        /// <summary>
        /// <para type="description">The metadata for a file.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The metadata for a file.")]
        public File FileBody { get; set; }

        /// <summary>
        /// <para type="description">A comma-separated list of parent IDs to add.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A comma-separated list of parent IDs to add.")]
        public string AddParents { get; set; }

        /// <summary>
        /// <para type="description">Whether to set the 'keepForever' field in the new head revision. This is only applicable to files with binary content in Drive.</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Whether to set the 'keepForever' field in the new head revision. This is only applicable to files with binary content in Drive."
            )]
        public bool? KeepRevisionForever { get; set; }

        /// <summary>
        /// <para type="description">A language hint for OCR processing during image import (ISO 639-1 code).</para>
        /// </summary>
        [Parameter(Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A language hint for OCR processing during image import (ISO 639-1 code).")]
        public string OcrLanguage { get; set; }

        /// <summary>
        /// <para type="description">A comma-separated list of parent IDs to remove.</para>
        /// </summary>
        [Parameter(Position = 5,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A comma-separated list of parent IDs to remove.")]
        public string RemoveParents { get; set; }

        /// <summary>
        /// <para type="description">Whether to use the uploaded content as indexable text.</para>
        /// </summary>
        [Parameter(Position = 6,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether to use the uploaded content as indexable text.")]
        public bool? UseContentAsIndexableText { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Drive Files", "Update-GDriveFile"))
            {
                var properties = new gDrive.Files.FilesUpdateProperties
                {
                    AddParents = AddParents,
                    KeepRevisionForever = KeepRevisionForever,
                    OcrLanguage = OcrLanguage,
                    RemoveParents = RemoveParents,
                    UseContentAsIndexableText = UseContentAsIndexableText
                };


                WriteObject(files.Update(FileBody, FileId, properties, StandardQueryParams: StandardQueryParams));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Subscribes to changes to a file</para>
    /// <para type="description">Subscribes to changes to a file</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Watch-GDriveFile -FileId $SomeFileIdString -ChannelBody $SomeChannelObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Watch-GDriveFile">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Watch, "GDriveFile",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Watch-GDriveFile")]
    public class WatchGDriveFileCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The ID of the file.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the file.")]
        public string FileId { get; set; }

        /// <summary>
        /// <para type="description">An notification channel used to watch for resource changes.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "An notification channel used to watch for resource changes.")]
        public Channel ChannelBody { get; set; }

        /// <summary>
        /// <para type="description">Whether the user is acknowledging the risk of downloading known malware or other abusive files. This is only applicable when alt=media.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Whether the user is acknowledging the risk of downloading known malware or other abusive files. This is only applicable when alt=media."
            )]
        public bool? AcknowledgeAbuse { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Drive Files", "Watch-GDriveFile"))
            {
                var properties = new gDrive.Files.FilesWatchProperties
                {
                    AcknowledgeAbuse = AcknowledgeAbuse
                };


                WriteObject(files.Watch(ChannelBody, FileId, properties, StandardQueryParams: StandardQueryParams));
            }
        }
    }
}

namespace gShell.Cmdlets.Drive.Permissions
{
    /// <summary>
    /// <para type="synopsis">Creates a permission for a file.</para>
    /// <para type="description">Creates a permission for a file.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GDrivePermission -FileId $SomeFileIdString -PermissionBody $SomePermissionObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GDrivePermission">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GDrivePermission",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GDrivePermission")]
    public class NewGDrivePermissionCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The ID of the file.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the file.")]
        public string FileId { get; set; }

        /// <summary>
        /// <para type="description">A permission for a file. A permission grants a user, group, domain or the world access to a file or a folder hierarchy.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "A permission for a file. A permission grants a user, group, domain or the world access to a file or a folder hierarchy."
            )]
        public Permission PermissionBody { get; set; }

        /// <summary>
        /// <para type="description">A custom message to include in the notification email.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A custom message to include in the notification email.")]
        public string EmailMessage { get; set; }

        /// <summary>
        /// <para type="description">Whether to send a notification email when sharing to users or groups. This defaults to true for users and groups, and is not allowed for other requests. It must not be disabled for ownership transfers.</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Whether to send a notification email when sharing to users or groups. This defaults to true for users and groups, and is not allowed for other requests. It must not be disabled for ownership transfers."
            )]
        public bool? SendNotificationEmail { get; set; }

        /// <summary>
        /// <para type="description">Whether to transfer ownership to the specified user and downgrade the current owner to a writer. This parameter is required as an acknowledgement of the side effect.</para>
        /// </summary>
        [Parameter(Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Whether to transfer ownership to the specified user and downgrade the current owner to a writer. This parameter is required as an acknowledgement of the side effect."
            )]
        public bool? TransferOwnership { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Drive Permissions", "New-GDrivePermission"))
            {
                var properties = new gDrive.Permissions.PermissionsCreateProperties
                {
                    EmailMessage = EmailMessage,
                    SendNotificationEmail = SendNotificationEmail,
                    TransferOwnership = TransferOwnership
                };


                WriteObject(permissions.Create(PermissionBody, FileId, properties, StandardQueryParams: StandardQueryParams));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Deletes a permission.</para>
    /// <para type="description">Deletes a permission.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Remove-GDrivePermission -FileId $SomeFileIdString -PermissionId $SomePermissionIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GDrivePermission">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GDrivePermission",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GDrivePermission")]
    public class RemoveGDrivePermissionCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The ID of the file.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the file.")]
        public string FileId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the permission.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the permission.")]
        public string PermissionId { get; set; }

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
            string toRemoveTarget = "Drive Permissions";

			if (ShouldProcess(toRemoveTarget))
			{	
				if (Force || ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
				{
					try
					{
						WriteDebug("Attempting to remove " + toRemoveTarget + "...");

                        permissions.Delete(FileId, PermissionId, StandardQueryParams: StandardQueryParams);
							
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
    /// <para type="synopsis">Gets a permission by ID.</para>
    /// <para type="description">Gets a permission by ID.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Get-GDrivePermission -FileId $SomeFileIdString -PermissionId $SomePermissionIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\> Get-GDrivePermission -FileId $SomeFileIdString -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GDrivePermission">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GDrivePermission",
        SupportsShouldProcess = true,
        DefaultParameterSetName = "one",
        HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GDrivePermission")]
    public class GetGDrivePermissionCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The ID of the file.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the file.")]
        public string FileId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the permission.</para>
        /// </summary>
        [Parameter(Position = 1,
            ParameterSetName = "one",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the permission.")]
        public string PermissionId { get; set; }

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
            if (ShouldProcess("Drive Permissions", "Get-GDrivePermission"))
            {
                if (ParameterSetName == "one")
                {
                    WriteObject(permissions.Get(FileId, PermissionId, StandardQueryParams: StandardQueryParams));
                }
                else
                {
                    WriteObject(permissions.List(FileId, StandardQueryParams: StandardQueryParams).Permissions);
                }
            }
        }
    }
}

namespace gShell.Cmdlets.Drive.Replies
{
    /// <summary>
    /// <para type="synopsis">Creates a new reply to a comment.</para>
    /// <para type="description">Creates a new reply to a comment.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GDriveReply -FileId $SomeFileIdString -CommentId $SomeCommentIdString -ReplyBody $SomeReplyObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GDriveReply">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GDriveReply",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GDriveReply")]
    public class NewGDriveReplyCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The ID of the file.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the file.")]
        public string FileId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the comment.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the comment.")]
        public string CommentId { get; set; }

        /// <summary>
        /// <para type="description">A reply to a comment on a file.</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A reply to a comment on a file.")]
        public Reply ReplyBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Drive Replies", "New-GDriveReply"))
            {
                WriteObject(replies.Create(ReplyBody, FileId, CommentId, StandardQueryParams: StandardQueryParams));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Deletes a reply.</para>
    /// <para type="description">Deletes a reply.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Remove-GDriveReply -FileId $SomeFileIdString -CommentId $SomeCommentIdString -ReplyId $SomeReplyIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GDriveReply">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GDriveReply",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GDriveReply")]
    public class RemoveGDriveReplyCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The ID of the file.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the file.")]
        public string FileId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the comment.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the comment.")]
        public string CommentId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the reply.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the reply.")]
        public string ReplyId { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            string toRemoveTarget = "Drive Replies";

			if (ShouldProcess(toRemoveTarget))
			{	
				if (Force || ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
				{
					try
					{
						WriteDebug("Attempting to remove " + toRemoveTarget + "...");

                        replies.Delete(FileId, CommentId, ReplyId, StandardQueryParams: StandardQueryParams);
							
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
    /// <para type="synopsis">Gets a reply by ID.</para>
    /// <para type="description">Gets a reply by ID.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Get-GDriveReply -FileId $SomeFileIdString -CommentId $SomeCommentIdString -ReplyId $SomeReplyIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\> Get-GDriveReply -FileId $SomeFileIdString -CommentId $SomeCommentIdString -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GDriveReply">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GDriveReply",
        SupportsShouldProcess = true,
        DefaultParameterSetName = "one",
        HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GDriveReply")]
    public class GetGDriveReplyCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The ID of the file.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the file.")]
        public string FileId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the comment.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the comment.")]
        public string CommentId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the reply.</para>
        /// </summary>
        [Parameter(Position = 2,
            ParameterSetName = "one",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the reply.")]
        public string ReplyId { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results</para>
        /// </summary>
        [Parameter(Position = 2,
            ParameterSetName = "list",
            Mandatory = true,
            HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }

        /// <summary>
        /// <para type="description">Whether to return deleted replies. Deleted replies will not include their original content.</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether to return deleted replies. Deleted replies will not include their original content.")
        ]
        public bool? IncludeDeleted { get; set; }

        /// <summary>
        /// <para type="description">The maximum number of replies to return per page.</para>
        /// </summary>
        [Parameter(Position = 4,
            ParameterSetName = "list",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The maximum number of replies to return per page.")]
        public int? PageSize { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Drive Replies", "Get-GDriveReply"))
            {
                if (ParameterSetName == "one")
                {
                    var properties = new gDrive.Replies.RepliesGetProperties
                    {
                        IncludeDeleted = IncludeDeleted
                    };

                    WriteObject(replies.Get(FileId, CommentId, ReplyId, properties, StandardQueryParams: StandardQueryParams));
                }
                else
                {
                    var properties = new gDrive.Replies.RepliesListProperties
                    {
                        IncludeDeleted = IncludeDeleted,
                        PageSize = PageSize
                    };

                    WriteObject(replies.List(FileId, CommentId, properties, StandardQueryParams: StandardQueryParams).SelectMany(x => x.Replies).ToList());
                }
            }
        }
    }
}

namespace gShell.Cmdlets.Drive.Revisions
{
    /// <summary>
    /// <para type="synopsis">Permanently deletes a revision. This method is only applicable to files with binary content in Drive.</para>
    /// <para type="description">Permanently deletes a revision. This method is only applicable to files with binary content in Drive.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Remove-GDriveRevision -FileId $SomeFileIdString -RevisionId $SomeRevisionIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GDriveRevision">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GDriveRevision",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GDriveRevision")]
    public class RemoveGDriveRevisionCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The ID of the file.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the file.")]
        public string FileId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the revision.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the revision.")]
        public string RevisionId { get; set; }

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
            string toRemoveTarget = "Drive Revisions";

			if (ShouldProcess(toRemoveTarget))
			{	
				if (Force || ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
				{
					try
					{
						WriteDebug("Attempting to remove " + toRemoveTarget + "...");

                        revisions.Delete(FileId, RevisionId, StandardQueryParams: StandardQueryParams);
							
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
    /// <para type="synopsis">Gets a revision's metadata or content by ID.</para>
    /// <para type="description">Gets a revision's metadata or content by ID.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Get-GDriveRevision -FileId $SomeFileIdString -RevisionId $SomeRevisionIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\> Get-GDriveRevision -FileId $SomeFileIdString -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GDriveRevision">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GDriveRevision",
        SupportsShouldProcess = true,
        DefaultParameterSetName = "one",
        HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GDriveRevision")]
    public class GetGDriveRevisionCommand : DriveBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The ID of the file.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the file.")]
        public string FileId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the revision.</para>
        /// </summary>
        [Parameter(Position = 1,
            ParameterSetName = "one",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the revision.")]
        public string RevisionId { get; set; }

        /// <summary>
        /// <para type="description">Whether the user is acknowledging the risk of downloading known malware or other abusive files. This is only applicable when alt=media.</para>
        /// </summary>
        [Parameter(Position = 2,
            ParameterSetName = "one",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Whether the user is acknowledging the risk of downloading known malware or other abusive files. This is only applicable when alt=media."
            )]
        public bool? AcknowledgeAbuse { get; set; }

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
            if (ShouldProcess("Drive Revisions", "Get-GDriveRevision"))
            {
                if (ParameterSetName == "one")
                {
                    var properties = new gDrive.Revisions.RevisionsGetProperties
                    {
                        AcknowledgeAbuse = AcknowledgeAbuse
                    };

                    WriteObject(revisions.Get(FileId, RevisionId, properties, StandardQueryParams: StandardQueryParams));
                }
                else
                {
                    WriteObject(revisions.List(FileId, StandardQueryParams: StandardQueryParams).SelectMany(x => x.Revisions).ToList());
                }
            }
        }
    }
}