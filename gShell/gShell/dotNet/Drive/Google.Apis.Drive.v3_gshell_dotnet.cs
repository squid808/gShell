namespace gShell.Cmdlets.Drive{

    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using v3 = Google.Apis.Drive.v3;
    using Data = Google.Apis.Drive.v3.Data;

    using gShell.dotNet.Utilities;
    using gShell.dotNet.Utilities.OAuth2;
    using gDrive = gShell.dotNet.Drive;

    public abstract class DriveBase : OAuth2CmdletBase
    {

        #region Properties
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        protected static gDrive mainBase { get; set; }

        public About about { get; set; }
        public Changes changes { get; set; }
        public Channels channels { get; set; }
        public Comments comments { get; set; }
        public Files files { get; set; }
        public Permissions permissions { get; set; }
        public Replies replies { get; set; }
        public Revisions revisions { get; set; }

        protected override string apiNameAndVersion { get { return mainBase.apiNameAndVersion; } }

        protected static string gShellServiceAccount { get; set; }
        #endregion

        #region Constructors
        public DriveBase()
        {
            mainBase = new gDrive();

            about = new About();
            changes = new Changes();
            channels = new Channels();
            comments = new Comments();
            files = new Files();
            permissions = new Permissions();
            replies = new Replies();
            revisions = new Revisions();
        }
        #endregion

        #region PowerShell Methods
        protected override void BeginProcessing()
        {
            var secrets = CheckForClientSecrets();
            if (secrets != null)
            {
                IEnumerable<string> scopes = EnsureScopesExist(Domain);
                Domain = mainBase.BuildService(Authenticate(scopes, secrets, Domain), gShellServiceAccount).domain;

                GWriteProgress = new gWriteProgress(WriteProgress);
            }
            else
            {
                WriteError(new ErrorRecord(null, (new Exception(
                    "Client Secrets must be set before running cmdlets. Run 'Get-Help "
                    + "Set-gShellClientSecrets -online' for more information."))));
            }
        }

        protected override void EndProcessing()
        {
            gShellServiceAccount = string.Empty;
        }

        protected override void StopProcessing()
        {
            gShellServiceAccount = string.Empty;
        }
        #endregion

        #region Authentication & Processing
        protected override AuthenticatedUserInfo Authenticate(IEnumerable<string> Scopes, ClientSecrets Secrets, string Domain = null)
        {
            return mainBase.Authenticate(apiNameAndVersion, Scopes, Secrets, Domain);
        }
        #endregion

        #region Wrapped Methods



        #region About

        public class About
        {




            public Google.Apis.Drive.v3.Data.About Get ()
            {

                return mainBase.about.Get(gShellServiceAccount);
            }
        }

        #endregion



        #region Changes

        public class Changes
        {




            public Google.Apis.Drive.v3.Data.StartPageToken GetStartPageToken ()
            {

                return mainBase.changes.GetStartPageToken(gShellServiceAccount);
            }


            public Google.Apis.Drive.v3.Data.ChangeList List (string

             pageToken, gDrive.Changes.ChangesListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDrive.Changes.ChangesListProperties();

                return mainBase.changes.List(pageToken, properties, gShellServiceAccount);
            }


            public Google.Apis.Drive.v3.Data.Channel Watch (Google.Apis.Drive.v3.Data.Channel body, string

             pageToken, gDrive.Changes.ChangesWatchProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDrive.Changes.ChangesWatchProperties();

                return mainBase.changes.Watch(body, pageToken, properties, gShellServiceAccount);
            }
        }

        #endregion



        #region Channels

        public class Channels
        {




            public void Stop (Google.Apis.Drive.v3.Data.Channel body)
            {

                mainBase.channels.Stop(body, gShellServiceAccount);
            }
        }

        #endregion



        #region Comments

        public class Comments
        {




            public Google.Apis.Drive.v3.Data.Comment Create (Google.Apis.Drive.v3.Data.Comment body, string

             fileId)
            {

                return mainBase.comments.Create(body, fileId, gShellServiceAccount);
            }


            public void Delete (string

             fileId, string

             commentId)
            {

                mainBase.comments.Delete(fileId, commentId, gShellServiceAccount);
            }


            public Google.Apis.Drive.v3.Data.Comment Get (string

             fileId, string

             commentId, gDrive.Comments.CommentsGetProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDrive.Comments.CommentsGetProperties();

                return mainBase.comments.Get(fileId, commentId, properties, gShellServiceAccount);
            }


            public List<Google.Apis.Drive.v3.Data.CommentList> List(string

             fileId, gDrive.Comments.CommentsListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDrive.Comments.CommentsListProperties();


                return mainBase.comments.List(fileId, properties);
            }


            public Google.Apis.Drive.v3.Data.Comment Update (Google.Apis.Drive.v3.Data.Comment body, string

             fileId, string

             commentId)
            {

                return mainBase.comments.Update(body, fileId, commentId, gShellServiceAccount);
            }
        }

        #endregion



        #region Files

        public class Files
        {




            public Google.Apis.Drive.v3.Data.File Copy (Google.Apis.Drive.v3.Data.File body, string

             fileId, gDrive.Files.FilesCopyProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDrive.Files.FilesCopyProperties();

                return mainBase.files.Copy(body, fileId, properties, gShellServiceAccount);
            }


            public void Create (Google.Apis.Drive.v3.Data.File body, System.IO.Stream stream, string contentType, gDrive.Files.FilesCreateProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDrive.Files.FilesCreateProperties();

                mainBase.files.Create(body, stream, contentType, properties, gShellServiceAccount);
            }


            public void Delete (string

             fileId)
            {

                mainBase.files.Delete(fileId, gShellServiceAccount);
            }


            public void EmptyTrash ()
            {

                mainBase.files.EmptyTrash(gShellServiceAccount);
            }


            public void Export (string

             fileId, string

             mimeType)
            {

                mainBase.files.Export(fileId, mimeType, gShellServiceAccount);
            }


            public Google.Apis.Drive.v3.Data.GeneratedIds GenerateIds (gDrive.Files.FilesGenerateIdsProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDrive.Files.FilesGenerateIdsProperties();

                return mainBase.files.GenerateIds(properties, gShellServiceAccount);
            }


            public Google.Apis.Drive.v3.Data.File Get (string

             fileId, gDrive.Files.FilesGetProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDrive.Files.FilesGetProperties();

                return mainBase.files.Get(fileId, properties, gShellServiceAccount);
            }


            public List<Google.Apis.Drive.v3.Data.FileList> List(gDrive.Files.FilesListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDrive.Files.FilesListProperties();


                return mainBase.files.List(properties);
            }


            public void Update (Google.Apis.Drive.v3.Data.File body, string
             fileId, System.IO.Stream stream, string contentType, gDrive.Files.FilesUpdateProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDrive.Files.FilesUpdateProperties();

                mainBase.files.Update(body, fileId, stream, contentType, properties, gShellServiceAccount);
            }


            public Google.Apis.Drive.v3.Data.Channel Watch (Google.Apis.Drive.v3.Data.Channel body, string

             fileId, gDrive.Files.FilesWatchProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDrive.Files.FilesWatchProperties();

                return mainBase.files.Watch(body, fileId, properties, gShellServiceAccount);
            }
        }

        #endregion



        #region Permissions

        public class Permissions
        {




            public Google.Apis.Drive.v3.Data.Permission Create (Google.Apis.Drive.v3.Data.Permission body, string

             fileId, gDrive.Permissions.PermissionsCreateProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDrive.Permissions.PermissionsCreateProperties();

                return mainBase.permissions.Create(body, fileId, properties, gShellServiceAccount);
            }


            public void Delete (string

             fileId, string

             permissionId)
            {

                mainBase.permissions.Delete(fileId, permissionId, gShellServiceAccount);
            }


            public Google.Apis.Drive.v3.Data.Permission Get (string

             fileId, string

             permissionId)
            {

                return mainBase.permissions.Get(fileId, permissionId, gShellServiceAccount);
            }


            public Google.Apis.Drive.v3.Data.PermissionList List (string

             fileId)
            {

                return mainBase.permissions.List(fileId, gShellServiceAccount);
            }


            public Google.Apis.Drive.v3.Data.Permission Update (Google.Apis.Drive.v3.Data.Permission body, string

             fileId, string

             permissionId, gDrive.Permissions.PermissionsUpdateProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDrive.Permissions.PermissionsUpdateProperties();

                return mainBase.permissions.Update(body, fileId, permissionId, properties, gShellServiceAccount);
            }
        }

        #endregion



        #region Replies

        public class Replies
        {




            public Google.Apis.Drive.v3.Data.Reply Create (Google.Apis.Drive.v3.Data.Reply body, string

             fileId, string

             commentId)
            {

                return mainBase.replies.Create(body, fileId, commentId, gShellServiceAccount);
            }


            public void Delete (string

             fileId, string

             commentId, string

             replyId)
            {

                mainBase.replies.Delete(fileId, commentId, replyId, gShellServiceAccount);
            }


            public Google.Apis.Drive.v3.Data.Reply Get (string

             fileId, string

             commentId, string

             replyId, gDrive.Replies.RepliesGetProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDrive.Replies.RepliesGetProperties();

                return mainBase.replies.Get(fileId, commentId, replyId, properties, gShellServiceAccount);
            }


            public List<Google.Apis.Drive.v3.Data.ReplyList> List(string

             fileId, string

             commentId, gDrive.Replies.RepliesListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDrive.Replies.RepliesListProperties();


                return mainBase.replies.List(fileId, commentId, properties);
            }


            public Google.Apis.Drive.v3.Data.Reply Update (Google.Apis.Drive.v3.Data.Reply body, string

             fileId, string

             commentId, string

             replyId)
            {

                return mainBase.replies.Update(body, fileId, commentId, replyId, gShellServiceAccount);
            }
        }

        #endregion



        #region Revisions

        public class Revisions
        {




            public void Delete (string

             fileId, string

             revisionId)
            {

                mainBase.revisions.Delete(fileId, revisionId, gShellServiceAccount);
            }


            public Google.Apis.Drive.v3.Data.Revision Get (string

             fileId, string

             revisionId, gDrive.Revisions.RevisionsGetProperties properties = null)
            {

                properties = (properties != null) ? properties : new gDrive.Revisions.RevisionsGetProperties();

                return mainBase.revisions.Get(fileId, revisionId, properties, gShellServiceAccount);
            }


            public Google.Apis.Drive.v3.Data.RevisionList List (string

             fileId)
            {

                return mainBase.revisions.List(fileId, gShellServiceAccount);
            }


            public Google.Apis.Drive.v3.Data.Revision Update (Google.Apis.Drive.v3.Data.Revision body, string

             fileId, string

             revisionId)
            {

                return mainBase.revisions.Update(body, fileId, revisionId, gShellServiceAccount);
            }
        }

        #endregion

        #endregion

    }
}



namespace gShell.dotNet
{
    using System;
    using System.Collections.Generic;

    using gShell.dotNet;
    using gShell.dotNet.Utilities.OAuth2;

    using v3 = Google.Apis.Drive.v3;
    using Data = Google.Apis.Drive.v3.Data;

    public class Drive : ServiceWrapper<v3.DriveService>
    {

        protected override bool worksWithGmail { get { return true; } }

        protected override v3.DriveService CreateNewService(string domain, AuthenticatedUserInfo authInfo, string gShellServiceAccount = null)
        {
            return new v3.DriveService(OAuth2Base.GetInitializer(domain, authInfo, gShellServiceAccount));
        }

        public override string apiNameAndVersion { get { return "drive:v3"; } }

        public About about{ get; set; }
        public Changes changes{ get; set; }
        public Channels channels{ get; set; }
        public Comments comments{ get; set; }
        public Files files{ get; set; }
        public Permissions permissions{ get; set; }
        public Replies replies{ get; set; }
        public Revisions revisions{ get; set; }

        public Drive() //public Reports()
        {

            about = new About();
            changes = new Changes();
            channels = new Channels();
            comments = new Comments();
            files = new Files();
            permissions = new Permissions();
            replies = new Replies();
            revisions = new Revisions();
        }




        public class About
        {





            public Google.Apis.Drive.v3.Data.About Get
            (string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).About.Get().Execute();
            }

        }


        public class Changes
        {



            public class ChangesListProperties
            {
                public     System.Nullable<bool>     includeRemoved = null; //test
                public     System.Nullable<int>     pageSize = null; //test
                public     System.Nullable<bool>     restrictToMyDrive = null; //test
                public     string     spaces = null; //test
            }

            public class ChangesWatchProperties
            {
                public     System.Nullable<bool>     includeRemoved = null; //test
                public     System.Nullable<int>     pageSize = null; //test
                public     System.Nullable<bool>     restrictToMyDrive = null; //test
                public     string     spaces = null; //test
            }


            public Google.Apis.Drive.v3.Data.StartPageToken GetStartPageToken
            (string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Changes.GetStartPageToken().Execute();
            }

            public Google.Apis.Drive.v3.Data.ChangeList List
            (string pageToken, ChangesListProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Changes.List(pageToken).Execute();
            }

            public Google.Apis.Drive.v3.Data.Channel Watch
            (Google.Apis.Drive.v3.Data.Channel body, string pageToken, ChangesWatchProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Changes.Watch(body, pageToken).Execute();
            }

        }


        public class Channels
        {





            public void Stop
            (Google.Apis.Drive.v3.Data.Channel body, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).Channels.Stop(body).Execute();
            }

        }


        public class Comments
        {



            public class CommentsGetProperties
            {
                public     System.Nullable<bool>     includeDeleted = null; //test
            }

            public class CommentsListProperties
            {
                public     System.Nullable<bool>     includeDeleted = null; //test
                public     System.Nullable<int>     pageSize = null; //test

                public     string     startModifiedTime = null; //test
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }


            public Google.Apis.Drive.v3.Data.Comment Create
            (Google.Apis.Drive.v3.Data.Comment body, string fileId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Comments.Create(body, fileId).Execute();
            }

            public void Delete
            (string fileId, string commentId, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).Comments.Delete(fileId, commentId).Execute();
            }

            public Google.Apis.Drive.v3.Data.Comment Get
            (string fileId, string commentId, CommentsGetProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Comments.Get(fileId, commentId).Execute();
            }

            public List<Google.Apis.Drive.v3.Data.CommentList> List(
                string     fileId, CommentsListProperties properties = null, string gShellServiceAccount = null)
            {
                var results = new List<Google.Apis.Drive.v3.Data.CommentList>();

                v3.CommentsResource.ListRequest request = GetService(gShellServiceAccount).Comments.List(
            fileId);

                if (properties != null)
                {
                    request.IncludeDeleted = properties.includeDeleted;
                    request.PageSize = properties.pageSize;
                    request.StartModifiedTime = properties.startModifiedTime;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering Comments",
                        string.Format("-Collecting Comments 1 to {0}", "unknown"));
                }

                Google.Apis.Drive.v3.Data.CommentList pagedResult = request.Execute();

                if (pagedResult != null)
                {
                    results.Add(pagedResult);

                    while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                        pagedResult.NextPageToken != request.PageToken &&
                    (properties.totalResults == 0 || results.Count < properties.totalResults))
                    {
                        request.PageToken = pagedResult.NextPageToken;

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(5, 10, "Gathering Comments",
                                    string.Format("-Collecting Comments {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        "unknown"));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering Comments",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            public Google.Apis.Drive.v3.Data.Comment Update
            (Google.Apis.Drive.v3.Data.Comment body, string fileId, string commentId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Comments.Update(body, fileId, commentId).Execute();
            }

        }


        public class Files
        {



            public class FilesCopyProperties
            {
                public     System.Nullable<bool>     ignoreDefaultVisibility = null; //test
                public     System.Nullable<bool>     keepRevisionForever = null; //test
                public     string     ocrLanguage = null; //test
            }

            public class FilesCreateProperties
            {
                public     System.Nullable<bool>     ignoreDefaultVisibility = null; //test
                public     System.Nullable<bool>     keepRevisionForever = null; //test
                public     string     ocrLanguage = null; //test
                public     System.Nullable<bool>     useContentAsIndexableText = null; //test
            }

            public class FilesGenerateIdsProperties
            {
                public     System.Nullable<int>     count = null; //test
                public     string     space = null; //test
            }

            public class FilesGetProperties
            {
                public     System.Nullable<bool>     acknowledgeAbuse = null; //test
            }

            public class FilesListProperties
            {
                public    v3.FilesResource.ListRequest.CorpusEnum?     corpus = null; //test
                public     string     orderBy = null; //test
                public     System.Nullable<int>     pageSize = null; //test

                public     string     q = null; //test
                public     string     spaces = null; //test
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }

            public class FilesUpdateProperties
            {
                public     string     addParents = null; //test
                public     System.Nullable<bool>     keepRevisionForever = null; //test
                public     string     ocrLanguage = null; //test
                public     string     removeParents = null; //test
                public     System.Nullable<bool>     useContentAsIndexableText = null; //test
            }

            public class FilesWatchProperties
            {
                public     System.Nullable<bool>     acknowledgeAbuse = null; //test
            }


            public Google.Apis.Drive.v3.Data.File Copy
            (Google.Apis.Drive.v3.Data.File body, string fileId, FilesCopyProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Files.Copy(body, fileId).Execute();
            }

            public void Create
            (Google.Apis.Drive.v3.Data.File body, System.IO.Stream stream, string contentType, FilesCreateProperties properties = null, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).Files.Create(body, stream, contentType).Upload();
            }

            public void Delete
            (string fileId, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).Files.Delete(fileId).Execute();
            }

            public void EmptyTrash
            (string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).Files.EmptyTrash().Execute();
            }

            public void Export
            (string fileId, string mimeType, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).Files.Export(fileId, mimeType).Execute();
            }

            public Google.Apis.Drive.v3.Data.GeneratedIds GenerateIds
            (FilesGenerateIdsProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Files.GenerateIds().Execute();
            }

            public Google.Apis.Drive.v3.Data.File Get
            (string fileId, FilesGetProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Files.Get(fileId).Execute();
            }

            public List<Google.Apis.Drive.v3.Data.FileList> List(
                FilesListProperties properties = null, string gShellServiceAccount = null)
            {
                var results = new List<Google.Apis.Drive.v3.Data.FileList>();

                v3.FilesResource.ListRequest request = GetService(gShellServiceAccount).Files.List(
            );

                if (properties != null)
                {
                    request.Corpus = properties.corpus;
                    request.OrderBy = properties.orderBy;
                    request.PageSize = properties.pageSize;
                    request.Q = properties.q;
                    request.Spaces = properties.spaces;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering Files",
                        string.Format("-Collecting Files 1 to {0}", "unknown"));
                }

                Google.Apis.Drive.v3.Data.FileList pagedResult = request.Execute();

                if (pagedResult != null)
                {
                    results.Add(pagedResult);

                    while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                        pagedResult.NextPageToken != request.PageToken &&
                    (properties.totalResults == 0 || results.Count < properties.totalResults))
                    {
                        request.PageToken = pagedResult.NextPageToken;

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(5, 10, "Gathering Files",
                                    string.Format("-Collecting Files {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        "unknown"));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering Files",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            public void Update
            (Google.Apis.Drive.v3.Data.File body, string fileId, System.IO.Stream stream, string contentType, FilesUpdateProperties properties = null, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).Files.Update(body, fileId, stream, contentType).Upload();
            }

            public Google.Apis.Drive.v3.Data.Channel Watch
            (Google.Apis.Drive.v3.Data.Channel body, string fileId, FilesWatchProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Files.Watch(body, fileId).Execute();
            }

        }


        public class Permissions
        {



            public class PermissionsCreateProperties
            {
                public     string     emailMessage = null; //test
                public     System.Nullable<bool>     sendNotificationEmail = null; //test
                public     System.Nullable<bool>     transferOwnership = null; //test
            }

            public class PermissionsUpdateProperties
            {
                public     System.Nullable<bool>     transferOwnership = null; //test
            }


            public Google.Apis.Drive.v3.Data.Permission Create
            (Google.Apis.Drive.v3.Data.Permission body, string fileId, PermissionsCreateProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Permissions.Create(body, fileId).Execute();
            }

            public void Delete
            (string fileId, string permissionId, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).Permissions.Delete(fileId, permissionId).Execute();
            }

            public Google.Apis.Drive.v3.Data.Permission Get
            (string fileId, string permissionId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Permissions.Get(fileId, permissionId).Execute();
            }

            public Google.Apis.Drive.v3.Data.PermissionList List
            (string fileId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Permissions.List(fileId).Execute();
            }

            public Google.Apis.Drive.v3.Data.Permission Update
            (Google.Apis.Drive.v3.Data.Permission body, string fileId, string permissionId, PermissionsUpdateProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Permissions.Update(body, fileId, permissionId).Execute();
            }

        }


        public class Replies
        {



            public class RepliesGetProperties
            {
                public     System.Nullable<bool>     includeDeleted = null; //test
            }

            public class RepliesListProperties
            {
                public     System.Nullable<bool>     includeDeleted = null; //test
                public     System.Nullable<int>     pageSize = null; //test

                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }


            public Google.Apis.Drive.v3.Data.Reply Create
            (Google.Apis.Drive.v3.Data.Reply body, string fileId, string commentId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Replies.Create(body, fileId, commentId).Execute();
            }

            public void Delete
            (string fileId, string commentId, string replyId, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).Replies.Delete(fileId, commentId, replyId).Execute();
            }

            public Google.Apis.Drive.v3.Data.Reply Get
            (string fileId, string commentId, string replyId, RepliesGetProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Replies.Get(fileId, commentId, replyId).Execute();
            }

            public List<Google.Apis.Drive.v3.Data.ReplyList> List(
                string     fileId, string     commentId, RepliesListProperties properties = null, string gShellServiceAccount = null)
            {
                var results = new List<Google.Apis.Drive.v3.Data.ReplyList>();

                v3.RepliesResource.ListRequest request = GetService(gShellServiceAccount).Replies.List(
            fileId, commentId);

                if (properties != null)
                {
                    request.IncludeDeleted = properties.includeDeleted;
                    request.PageSize = properties.pageSize;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering Replies",
                        string.Format("-Collecting Replies 1 to {0}", "unknown"));
                }

                Google.Apis.Drive.v3.Data.ReplyList pagedResult = request.Execute();

                if (pagedResult != null)
                {
                    results.Add(pagedResult);

                    while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                        pagedResult.NextPageToken != request.PageToken &&
                    (properties.totalResults == 0 || results.Count < properties.totalResults))
                    {
                        request.PageToken = pagedResult.NextPageToken;

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(5, 10, "Gathering Replies",
                                    string.Format("-Collecting Replies {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        "unknown"));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering Replies",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            public Google.Apis.Drive.v3.Data.Reply Update
            (Google.Apis.Drive.v3.Data.Reply body, string fileId, string commentId, string replyId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Replies.Update(body, fileId, commentId, replyId).Execute();
            }

        }


        public class Revisions
        {



            public class RevisionsGetProperties
            {
                public     System.Nullable<bool>     acknowledgeAbuse = null; //test
            }


            public void Delete
            (string fileId, string revisionId, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).Revisions.Delete(fileId, revisionId).Execute();
            }

            public Google.Apis.Drive.v3.Data.Revision Get
            (string fileId, string revisionId, RevisionsGetProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Revisions.Get(fileId, revisionId).Execute();
            }

            public Google.Apis.Drive.v3.Data.RevisionList List
            (string fileId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Revisions.List(fileId).Execute();
            }

            public Google.Apis.Drive.v3.Data.Revision Update
            (Google.Apis.Drive.v3.Data.Revision body, string fileId, string revisionId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Revisions.Update(body, fileId, revisionId).Execute();
            }

        }

    }
}