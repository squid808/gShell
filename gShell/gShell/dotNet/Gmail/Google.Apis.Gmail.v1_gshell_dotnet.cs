namespace gShell.Cmdlets.Gmail{

    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using v1 = Google.Apis.Gmail.v1;
    using Data = Google.Apis.Gmail.v1.Data;

    using gShell.dotNet.Utilities;
    using gShell.dotNet.Utilities.OAuth2;
    using gGmail = gShell.dotNet.Gmail;

    public abstract class GmailBase : OAuth2CmdletBase
    {

        #region Properties
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        protected static gGmail mainBase { get; set; }

        public Users users { get; set; }

        protected override string apiNameAndVersion { get { return mainBase.apiNameAndVersion; } }

        protected static string gShellServiceAccount { get; set; }
        #endregion

        #region Constructors
        public GmailBase()
        {
            mainBase = new gGmail();

            users = new Users();
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



        #region Users

        public class Users
        {

            public Drafts drafts{ get; set; }
            public History history{ get; set; }
            public Labels labels{ get; set; }
            public Messages messages{ get; set; }
            public Threads threads{ get; set; }

            public Users() //public Reports()
            {

                drafts = new Drafts();
                history = new History();
                labels = new Labels();
                messages = new Messages();
                threads = new Threads();
            }

            #region Drafts

            public class Drafts
            {




                public void Create (Google.Apis.Gmail.v1.Data.Draft body, string

                 userId)
                {

                    mainBase.users.drafts.Create(body, userId, gShellServiceAccount);
                }


                public void Delete (string

                 userId, string

                 id)
                {

                    mainBase.users.drafts.Delete(userId, id, gShellServiceAccount);
                }


                public Google.Apis.Gmail.v1.Data.Draft Get (string

                 userId, string

                 id, gGmail.Users.Drafts.DraftsGetProperties properties = null)
                {

                    properties = (properties != null) ? properties : new gGmail.Users.Drafts.DraftsGetProperties();

                    return mainBase.users.drafts.Get(userId, id, properties, gShellServiceAccount);
                }


                public List<Google.Apis.Gmail.v1.Data.ListDraftsResponse> List(string

                 userId, gGmail.Users.Drafts.DraftsListProperties properties = null)
                {

                    properties = (properties != null) ? properties : new gGmail.Users.Drafts.DraftsListProperties();
                    properties.startProgressBar = StartProgressBar;
                    properties.updateProgressBar = UpdateProgressBar;

                    return mainBase.users.drafts.List(userId, properties);
                }


                public void Send (Google.Apis.Gmail.v1.Data.Draft body, string

                 userId)
                {

                    mainBase.users.drafts.Send(body, userId, gShellServiceAccount);
                }


                public void Update (Google.Apis.Gmail.v1.Data.Draft body, string

                 userId, string

                 id)
                {

                    mainBase.users.drafts.Update(body, userId, id, gShellServiceAccount);
                }
            }

            #endregion
            #region History

            public class History
            {




                public List<Google.Apis.Gmail.v1.Data.ListHistoryResponse> List(string

                 userId, gGmail.Users.History.HistoryListProperties properties = null)
                {

                    properties = (properties != null) ? properties : new gGmail.Users.History.HistoryListProperties();
                    properties.startProgressBar = StartProgressBar;
                    properties.updateProgressBar = UpdateProgressBar;

                    return mainBase.users.history.List(userId, properties);
                }
            }

            #endregion
            #region Labels

            public class Labels
            {




                public Google.Apis.Gmail.v1.Data.Label Create (Google.Apis.Gmail.v1.Data.Label body, string

                 userId)
                {

                    return mainBase.users.labels.Create(body, userId, gShellServiceAccount);
                }


                public void Delete (string

                 userId, string

                 id)
                {

                    mainBase.users.labels.Delete(userId, id, gShellServiceAccount);
                }


                public Google.Apis.Gmail.v1.Data.Label Get (string

                 userId, string

                 id)
                {

                    return mainBase.users.labels.Get(userId, id, gShellServiceAccount);
                }


                public Google.Apis.Gmail.v1.Data.ListLabelsResponse List (string

                 userId)
                {

                    return mainBase.users.labels.List(userId, gShellServiceAccount);
                }


                public Google.Apis.Gmail.v1.Data.Label Patch (Google.Apis.Gmail.v1.Data.Label body, string

                 userId, string

                 id)
                {

                    return mainBase.users.labels.Patch(body, userId, id, gShellServiceAccount);
                }


                public Google.Apis.Gmail.v1.Data.Label Update (Google.Apis.Gmail.v1.Data.Label body, string

                 userId, string

                 id)
                {

                    return mainBase.users.labels.Update(body, userId, id, gShellServiceAccount);
                }
            }

            #endregion
            #region Messages

            public class Messages
            {

                public Attachments attachments{ get; set; }

                public Messages() //public Reports()
                {

                    attachments = new Attachments();
                }

                #region Attachments

                public class Attachments
                {




                    public Google.Apis.Gmail.v1.Data.MessagePartBody Get (string

                     userId, string

                     messageId, string

                     id)
                    {

                        return mainBase.users.messages.attachments.Get(userId, messageId, id, gShellServiceAccount);
                    }
                }

                #endregion


                public void BatchDelete (Google.Apis.Gmail.v1.Data.BatchDeleteMessagesRequest body, string

                 userId)
                {

                    mainBase.users.messages.BatchDelete(body, userId, gShellServiceAccount);
                }


                public void Delete (string

                 userId, string

                 id)
                {

                    mainBase.users.messages.Delete(userId, id, gShellServiceAccount);
                }


                public Google.Apis.Gmail.v1.Data.Message Get (string

                 userId, string

                 id, gGmail.Users.Messages.MessagesGetProperties properties = null)
                {

                    properties = (properties != null) ? properties : new gGmail.Users.Messages.MessagesGetProperties();

                    return mainBase.users.messages.Get(userId, id, properties, gShellServiceAccount);
                }


                public void Import (Google.Apis.Gmail.v1.Data.Message body, string

                 userId, gGmail.Users.Messages.MessagesImportProperties properties = null)
                {

                    properties = (properties != null) ? properties : new gGmail.Users.Messages.MessagesImportProperties();

                    mainBase.users.messages.Import(body, userId, properties, gShellServiceAccount);
                }


                public void Insert (Google.Apis.Gmail.v1.Data.Message body, string

                 userId, gGmail.Users.Messages.MessagesInsertProperties properties = null)
                {

                    properties = (properties != null) ? properties : new gGmail.Users.Messages.MessagesInsertProperties();

                    mainBase.users.messages.Insert(body, userId, properties, gShellServiceAccount);
                }


                public List<Google.Apis.Gmail.v1.Data.ListMessagesResponse> List(string

                 userId, gGmail.Users.Messages.MessagesListProperties properties = null)
                {

                    properties = (properties != null) ? properties : new gGmail.Users.Messages.MessagesListProperties();
                    properties.startProgressBar = StartProgressBar;
                    properties.updateProgressBar = UpdateProgressBar;

                    return mainBase.users.messages.List(userId, properties);
                }


                public Google.Apis.Gmail.v1.Data.Message Modify (Google.Apis.Gmail.v1.Data.ModifyMessageRequest body, string

                 userId, string

                 id)
                {

                    return mainBase.users.messages.Modify(body, userId, id, gShellServiceAccount);
                }


                public void Send (Google.Apis.Gmail.v1.Data.Message body, string

                 userId)
                {

                    mainBase.users.messages.Send(body, userId, gShellServiceAccount);
                }


                public Google.Apis.Gmail.v1.Data.Message Trash (string

                 userId, string

                 id)
                {

                    return mainBase.users.messages.Trash(userId, id, gShellServiceAccount);
                }


                public Google.Apis.Gmail.v1.Data.Message Untrash (string

                 userId, string

                 id)
                {

                    return mainBase.users.messages.Untrash(userId, id, gShellServiceAccount);
                }
            }

            #endregion
            #region Threads

            public class Threads
            {




                public void Delete (string

                 userId, string

                 id)
                {

                    mainBase.users.threads.Delete(userId, id, gShellServiceAccount);
                }


                public Google.Apis.Gmail.v1.Data.Thread Get (string

                 userId, string

                 id, gGmail.Users.Threads.ThreadsGetProperties properties = null)
                {

                    properties = (properties != null) ? properties : new gGmail.Users.Threads.ThreadsGetProperties();

                    return mainBase.users.threads.Get(userId, id, properties, gShellServiceAccount);
                }


                public List<Google.Apis.Gmail.v1.Data.ListThreadsResponse> List(string

                 userId, gGmail.Users.Threads.ThreadsListProperties properties = null)
                {

                    properties = (properties != null) ? properties : new gGmail.Users.Threads.ThreadsListProperties();
                    properties.startProgressBar = StartProgressBar;
                    properties.updateProgressBar = UpdateProgressBar;

                    return mainBase.users.threads.List(userId, properties);
                }


                public Google.Apis.Gmail.v1.Data.Thread Modify (Google.Apis.Gmail.v1.Data.ModifyThreadRequest body, string

                 userId, string

                 id)
                {

                    return mainBase.users.threads.Modify(body, userId, id, gShellServiceAccount);
                }


                public Google.Apis.Gmail.v1.Data.Thread Trash (string

                 userId, string

                 id)
                {

                    return mainBase.users.threads.Trash(userId, id, gShellServiceAccount);
                }


                public Google.Apis.Gmail.v1.Data.Thread Untrash (string

                 userId, string

                 id)
                {

                    return mainBase.users.threads.Untrash(userId, id, gShellServiceAccount);
                }
            }

            #endregion


            public Google.Apis.Gmail.v1.Data.Profile GetProfile (string

             userId)
            {

                return mainBase.users.GetProfile(userId, gShellServiceAccount);
            }


            public void Stop (string

             userId)
            {

                mainBase.users.Stop(userId, gShellServiceAccount);
            }


            public Google.Apis.Gmail.v1.Data.WatchResponse Watch (Google.Apis.Gmail.v1.Data.WatchRequest body, string

             userId)
            {

                return mainBase.users.Watch(body, userId, gShellServiceAccount);
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

    using v1 = Google.Apis.Gmail.v1;
    using Data = Google.Apis.Gmail.v1.Data;

    public class Gmail : ServiceWrapper<v1.GmailService>
    {

        protected override bool worksWithGmail { get { return true; } }

        protected override v1.GmailService CreateNewService(string domain, AuthenticatedUserInfo authInfo, string gShellServiceAccount = null)
        {
            return new v1.GmailService(OAuth2Base.GetInitializer(domain, authInfo, gShellServiceAccount));
        }

        public override string apiNameAndVersion { get { return "gmail:v1"; } }

        public Users users{ get; set; }

        public Gmail() //public Reports()
        {

            users = new Users();
        }




        public class Users
        {

        public Drafts drafts{ get; set; }
        public History history{ get; set; }
        public Labels labels{ get; set; }
        public Messages messages{ get; set; }
        public Threads threads{ get; set; }

        public Users() //public Reports()
        {

            drafts = new Drafts();
            history = new History();
            labels = new Labels();
            messages = new Messages();
            threads = new Threads();
        }




            public Google.Apis.Gmail.v1.Data.Profile GetProfile (string

             userId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Users.GetProfile(userId).Execute();
            }

            public void Stop (string

             userId, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).Users.Stop(userId).Execute();
            }

            public Google.Apis.Gmail.v1.Data.WatchResponse Watch (Google.Apis.Gmail.v1.Data.WatchRequest body, string

             userId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Users.Watch(body, userId).Execute();
            }


            public class Drafts
            {



                public class DraftsGetProperties
                {
                    public    v1.UsersResource.DraftsResource.GetRequest.FormatEnum?     format = null; //test
                }

                public class DraftsListProperties
                {
                    public     System.Nullable<bool>     includeSpamTrash = null; //test
                    public int maxResults = 0;

                    public Action<string, string> startProgressBar = null;
                    public Action<int, int, string, string> updateProgressBar = null;
                    public int totalResults = 0;
                }


                public Google.Apis.Gmail.v1.Data.Draft Create (Google.Apis.Gmail.v1.Data.Draft body, string

                 userId, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Users.Drafts.Create(body, userId).Execute();
                }

                public void Create (Google.Apis.Gmail.v1.Data.Draft body, string
                 userId, System.IO.Stream stream, string contentType, string gShellServiceAccount = null)
                {
                    GetService(gShellServiceAccount).Users.Drafts.Create(body, userId, stream, contentType).Upload();
                }

                public void Delete (string

                 userId, string

                 id, string gShellServiceAccount = null)
                {
                    GetService(gShellServiceAccount).Users.Drafts.Delete(userId, id).Execute();
                }

                public Google.Apis.Gmail.v1.Data.Draft Get (string

                 userId, string

                 id, DraftsGetProperties properties = null, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Users.Drafts.Get(userId, id).Execute();
                }

                public List<Google.Apis.Gmail.v1.Data.ListDraftsResponse> List(
                    string     userId, DraftsListProperties properties = null, string gShellServiceAccount = null)
                {
                    var results = new List<Google.Apis.Gmail.v1.Data.ListDraftsResponse>();

                    v1.UsersResource.DraftsResource.ListRequest request = GetService(gShellServiceAccount).Users.Drafts.List(
                userId);

                    if (properties != null)
                    {
                        request.IncludeSpamTrash = properties.includeSpamTrash;
                        request.MaxResults = properties.maxResults;

                    }

                    if (null != properties.startProgressBar)
                    {
                        properties.startProgressBar("Gathering Drafts",
                            string.Format("-Collecting Drafts 1 to {0}", request.MaxResults.ToString()));
                    }

                    Google.Apis.Gmail.v1.Data.ListDraftsResponse pagedResult = request.Execute();

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
                                properties.updateProgressBar(5, 10, "Gathering Drafts",
                                        string.Format("-Collecting Drafts {0} to {1}",
                                            (results.Count + 1).ToString(),
                                            (results.Count + request.MaxResults).ToString()));
                            }
                            pagedResult = request.Execute();
                            results.Add(pagedResult);
                        }

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(1, 2, "Gathering Drafts",
                                    string.Format("-Returning {0} results.", results.Count.ToString()));
                        }
                    }

                    return results;
                }

                public Google.Apis.Gmail.v1.Data.Message Send (Google.Apis.Gmail.v1.Data.Draft body, string

                 userId, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Users.Drafts.Send(body, userId).Execute();
                }

                public void Send (Google.Apis.Gmail.v1.Data.Draft body, string
                 userId, System.IO.Stream stream, string contentType, string gShellServiceAccount = null)
                {
                    GetService(gShellServiceAccount).Users.Drafts.Send(body, userId, stream, contentType).Upload();
                }

                public Google.Apis.Gmail.v1.Data.Draft Update (Google.Apis.Gmail.v1.Data.Draft body, string

                 userId, string

                 id, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Users.Drafts.Update(body, userId, id).Execute();
                }

                public void Update (Google.Apis.Gmail.v1.Data.Draft body, string
                 userId, string
                 id, System.IO.Stream stream, string contentType, string gShellServiceAccount = null)
                {
                    GetService(gShellServiceAccount).Users.Drafts.Update(body, userId, id, stream, contentType).Upload();
                }

            }


            public class History
            {



                public class HistoryListProperties
                {
                    public     string     labelId = null; //test
                    public int maxResults = 0;

                    public     System.Nullable<ulong>     startHistoryId = null; //test
                    public Action<string, string> startProgressBar = null;
                    public Action<int, int, string, string> updateProgressBar = null;
                    public int totalResults = 0;
                }


                public List<Google.Apis.Gmail.v1.Data.ListHistoryResponse> List(
                    string     userId, HistoryListProperties properties = null, string gShellServiceAccount = null)
                {
                    var results = new List<Google.Apis.Gmail.v1.Data.ListHistoryResponse>();

                    v1.UsersResource.HistoryResource.ListRequest request = GetService(gShellServiceAccount).Users.History.List(
                userId);

                    if (properties != null)
                    {
                        request.LabelId = properties.labelId;
                        request.MaxResults = properties.maxResults;
                        request.StartHistoryId = properties.startHistoryId;

                    }

                    if (null != properties.startProgressBar)
                    {
                        properties.startProgressBar("Gathering History",
                            string.Format("-Collecting History 1 to {0}", request.MaxResults.ToString()));
                    }

                    Google.Apis.Gmail.v1.Data.ListHistoryResponse pagedResult = request.Execute();

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
                                properties.updateProgressBar(5, 10, "Gathering History",
                                        string.Format("-Collecting History {0} to {1}",
                                            (results.Count + 1).ToString(),
                                            (results.Count + request.MaxResults).ToString()));
                            }
                            pagedResult = request.Execute();
                            results.Add(pagedResult);
                        }

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(1, 2, "Gathering History",
                                    string.Format("-Returning {0} results.", results.Count.ToString()));
                        }
                    }

                    return results;
                }

            }


            public class Labels
            {





                public Google.Apis.Gmail.v1.Data.Label Create (Google.Apis.Gmail.v1.Data.Label body, string

                 userId, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Users.Labels.Create(body, userId).Execute();
                }

                public void Delete (string

                 userId, string

                 id, string gShellServiceAccount = null)
                {
                    GetService(gShellServiceAccount).Users.Labels.Delete(userId, id).Execute();
                }

                public Google.Apis.Gmail.v1.Data.Label Get (string

                 userId, string

                 id, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Users.Labels.Get(userId, id).Execute();
                }

                public Google.Apis.Gmail.v1.Data.ListLabelsResponse List (string

                 userId, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Users.Labels.List(userId).Execute();
                }

                public Google.Apis.Gmail.v1.Data.Label Patch (Google.Apis.Gmail.v1.Data.Label body, string

                 userId, string

                 id, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Users.Labels.Patch(body, userId, id).Execute();
                }

                public Google.Apis.Gmail.v1.Data.Label Update (Google.Apis.Gmail.v1.Data.Label body, string

                 userId, string

                 id, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Users.Labels.Update(body, userId, id).Execute();
                }

            }


            public class Messages
            {

            public Attachments attachments{ get; set; }

            public Messages() //public Reports()
            {

                attachments = new Attachments();
            }


                public class MessagesGetProperties
                {
                    public    v1.UsersResource.MessagesResource.GetRequest.FormatEnum?     format = null; //test
                    public    Google.Apis.Util.Repeatable<string>     metadataHeaders = null; //test
                }

                public class MessagesImportProperties
                {
                    public     System.Nullable<bool>     deleted = null; //test
                    public    v1.UsersResource.MessagesResource.ImportRequest.InternalDateSourceEnum?     internalDateSource = null; //test
                    public     System.Nullable<bool>     neverMarkSpam = null; //test
                    public     System.Nullable<bool>     processForCalendar = null; //test
                }

                public class MessagesInsertProperties
                {
                    public     System.Nullable<bool>     deleted = null; //test
                    public    v1.UsersResource.MessagesResource.InsertRequest.InternalDateSourceEnum?     internalDateSource = null; //test
                }

                public class MessagesListProperties
                {
                    public     System.Nullable<bool>     includeSpamTrash = null; //test
                    public    Google.Apis.Util.Repeatable<string>     labelIds = null; //test
                    public int maxResults = 0;

                    public     string     q = null; //test
                    public Action<string, string> startProgressBar = null;
                    public Action<int, int, string, string> updateProgressBar = null;
                    public int totalResults = 0;
                }


                public void BatchDelete (Google.Apis.Gmail.v1.Data.BatchDeleteMessagesRequest body, string

                 userId, string gShellServiceAccount = null)
                {
                    GetService(gShellServiceAccount).Users.Messages.BatchDelete(body, userId).Execute();
                }

                public void Delete (string

                 userId, string

                 id, string gShellServiceAccount = null)
                {
                    GetService(gShellServiceAccount).Users.Messages.Delete(userId, id).Execute();
                }

                public Google.Apis.Gmail.v1.Data.Message Get (string

                 userId, string

                 id, MessagesGetProperties properties = null, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Users.Messages.Get(userId, id).Execute();
                }

                public Google.Apis.Gmail.v1.Data.Message Import (Google.Apis.Gmail.v1.Data.Message body, string

                 userId, MessagesImportProperties properties = null, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Users.Messages.Import(body, userId).Execute();
                }

                public void Import (Google.Apis.Gmail.v1.Data.Message body, string
                 userId, System.IO.Stream stream, string contentType, MessagesImportProperties properties = null, string gShellServiceAccount = null)
                {
                    GetService(gShellServiceAccount).Users.Messages.Import(body, userId, stream, contentType).Upload();
                }

                public Google.Apis.Gmail.v1.Data.Message Insert (Google.Apis.Gmail.v1.Data.Message body, string

                 userId, MessagesInsertProperties properties = null, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Users.Messages.Insert(body, userId).Execute();
                }

                public void Insert (Google.Apis.Gmail.v1.Data.Message body, string
                 userId, System.IO.Stream stream, string contentType, MessagesInsertProperties properties = null, string gShellServiceAccount = null)
                {
                    GetService(gShellServiceAccount).Users.Messages.Insert(body, userId, stream, contentType).Upload();
                }

                public List<Google.Apis.Gmail.v1.Data.ListMessagesResponse> List(
                    string     userId, MessagesListProperties properties = null, string gShellServiceAccount = null)
                {
                    var results = new List<Google.Apis.Gmail.v1.Data.ListMessagesResponse>();

                    v1.UsersResource.MessagesResource.ListRequest request = GetService(gShellServiceAccount).Users.Messages.List(
                userId);

                    if (properties != null)
                    {
                        request.IncludeSpamTrash = properties.includeSpamTrash;
                        request.LabelIds = properties.labelIds;
                        request.MaxResults = properties.maxResults;
                        request.Q = properties.q;

                    }

                    if (null != properties.startProgressBar)
                    {
                        properties.startProgressBar("Gathering Messages",
                            string.Format("-Collecting Messages 1 to {0}", request.MaxResults.ToString()));
                    }

                    Google.Apis.Gmail.v1.Data.ListMessagesResponse pagedResult = request.Execute();

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
                                properties.updateProgressBar(5, 10, "Gathering Messages",
                                        string.Format("-Collecting Messages {0} to {1}",
                                            (results.Count + 1).ToString(),
                                            (results.Count + request.MaxResults).ToString()));
                            }
                            pagedResult = request.Execute();
                            results.Add(pagedResult);
                        }

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(1, 2, "Gathering Messages",
                                    string.Format("-Returning {0} results.", results.Count.ToString()));
                        }
                    }

                    return results;
                }

                public Google.Apis.Gmail.v1.Data.Message Modify (Google.Apis.Gmail.v1.Data.ModifyMessageRequest body, string

                 userId, string

                 id, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Users.Messages.Modify(body, userId, id).Execute();
                }

                public Google.Apis.Gmail.v1.Data.Message Send (Google.Apis.Gmail.v1.Data.Message body, string

                 userId, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Users.Messages.Send(body, userId).Execute();
                }

                public void Send (Google.Apis.Gmail.v1.Data.Message body, string
                 userId, System.IO.Stream stream, string contentType, string gShellServiceAccount = null)
                {
                    GetService(gShellServiceAccount).Users.Messages.Send(body, userId, stream, contentType).Upload();
                }

                public Google.Apis.Gmail.v1.Data.Message Trash (string

                 userId, string

                 id, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Users.Messages.Trash(userId, id).Execute();
                }

                public Google.Apis.Gmail.v1.Data.Message Untrash (string

                 userId, string

                 id, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Users.Messages.Untrash(userId, id).Execute();
                }


                public class Attachments
                {





                    public Google.Apis.Gmail.v1.Data.MessagePartBody Get (string

                     userId, string

                     messageId, string

                     id, string gShellServiceAccount = null)
                    {
                        return GetService(gShellServiceAccount).Users.Messages.Attachments.Get(userId, messageId, id).Execute();
                    }

                }

            }


            public class Threads
            {



                public class ThreadsGetProperties
                {
                    public    v1.UsersResource.ThreadsResource.GetRequest.FormatEnum?     format = null; //test
                    public    Google.Apis.Util.Repeatable<string>     metadataHeaders = null; //test
                }

                public class ThreadsListProperties
                {
                    public     System.Nullable<bool>     includeSpamTrash = null; //test
                    public    Google.Apis.Util.Repeatable<string>     labelIds = null; //test
                    public int maxResults = 0;

                    public     string     q = null; //test
                    public Action<string, string> startProgressBar = null;
                    public Action<int, int, string, string> updateProgressBar = null;
                    public int totalResults = 0;
                }


                public void Delete (string

                 userId, string

                 id, string gShellServiceAccount = null)
                {
                    GetService(gShellServiceAccount).Users.Threads.Delete(userId, id).Execute();
                }

                public Google.Apis.Gmail.v1.Data.Thread Get (string

                 userId, string

                 id, ThreadsGetProperties properties = null, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Users.Threads.Get(userId, id).Execute();
                }

                public List<Google.Apis.Gmail.v1.Data.ListThreadsResponse> List(
                    string     userId, ThreadsListProperties properties = null, string gShellServiceAccount = null)
                {
                    var results = new List<Google.Apis.Gmail.v1.Data.ListThreadsResponse>();

                    v1.UsersResource.ThreadsResource.ListRequest request = GetService(gShellServiceAccount).Users.Threads.List(
                userId);

                    if (properties != null)
                    {
                        request.IncludeSpamTrash = properties.includeSpamTrash;
                        request.LabelIds = properties.labelIds;
                        request.MaxResults = properties.maxResults;
                        request.Q = properties.q;

                    }

                    if (null != properties.startProgressBar)
                    {
                        properties.startProgressBar("Gathering Threads",
                            string.Format("-Collecting Threads 1 to {0}", request.MaxResults.ToString()));
                    }

                    Google.Apis.Gmail.v1.Data.ListThreadsResponse pagedResult = request.Execute();

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
                                properties.updateProgressBar(5, 10, "Gathering Threads",
                                        string.Format("-Collecting Threads {0} to {1}",
                                            (results.Count + 1).ToString(),
                                            (results.Count + request.MaxResults).ToString()));
                            }
                            pagedResult = request.Execute();
                            results.Add(pagedResult);
                        }

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(1, 2, "Gathering Threads",
                                    string.Format("-Returning {0} results.", results.Count.ToString()));
                        }
                    }

                    return results;
                }

                public Google.Apis.Gmail.v1.Data.Thread Modify (Google.Apis.Gmail.v1.Data.ModifyThreadRequest body, string

                 userId, string

                 id, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Users.Threads.Modify(body, userId, id).Execute();
                }

                public Google.Apis.Gmail.v1.Data.Thread Trash (string

                 userId, string

                 id, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Users.Threads.Trash(userId, id).Execute();
                }

                public Google.Apis.Gmail.v1.Data.Thread Untrash (string

                 userId, string

                 id, string gShellServiceAccount = null)
                {
                    return GetService(gShellServiceAccount).Users.Threads.Untrash(userId, id).Execute();
                }

            }

        }

    }
}