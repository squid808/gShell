namespace gShell.Cmdlets.Calendar{

    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using v3 = Google.Apis.Calendar.v3;
    using Data = Google.Apis.Calendar.v3.Data;

    using gShell.dotNet.Utilities;
    using gShell.dotNet.Utilities.OAuth2;
    using gCalendar = gShell.dotNet.Calendar;

    public abstract class CalendarBase : OAuth2CmdletBase
    {

        #region Properties
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        protected static gCalendar mainBase { get; set; }

        public Acl acl { get; set; }
        public CalendarList calendarList { get; set; }
        public Calendars calendars { get; set; }
        public Channels channels { get; set; }
        public Colors colors { get; set; }
        public Events events { get; set; }
        public Freebusy freebusy { get; set; }
        public Settings settings { get; set; }

        protected override string apiNameAndVersion { get { return mainBase.apiNameAndVersion; } }

        protected static string gShellServiceAccount { get; set; }
        #endregion

        #region Constructors
        public CalendarBase()
        {
            mainBase = new gCalendar();

            acl = new Acl();
            calendarList = new CalendarList();
            calendars = new Calendars();
            channels = new Channels();
            colors = new Colors();
            events = new Events();
            freebusy = new Freebusy();
            settings = new Settings();
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



        #region Acl

        public class Acl
        {




            public void Delete (string

             calendarId, string

             ruleId)
            {

                mainBase.acl.Delete(calendarId, ruleId, gShellServiceAccount);
            }


            public Google.Apis.Calendar.v3.Data.AclRule Get (string

             calendarId, string

             ruleId)
            {

                return mainBase.acl.Get(calendarId, ruleId, gShellServiceAccount);
            }


            public Google.Apis.Calendar.v3.Data.AclRule Insert (Google.Apis.Calendar.v3.Data.AclRule body, string

             calendarId)
            {

                return mainBase.acl.Insert(body, calendarId, gShellServiceAccount);
            }


            public List<Google.Apis.Calendar.v3.Data.Acl> List(string

             calendarId, gCalendar.Acl.AclListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gCalendar.Acl.AclListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return mainBase.acl.List(calendarId, properties);
            }


            public Google.Apis.Calendar.v3.Data.AclRule Patch (Google.Apis.Calendar.v3.Data.AclRule body, string

             calendarId, string

             ruleId)
            {

                return mainBase.acl.Patch(body, calendarId, ruleId, gShellServiceAccount);
            }


            public Google.Apis.Calendar.v3.Data.AclRule Update (Google.Apis.Calendar.v3.Data.AclRule body, string

             calendarId, string

             ruleId)
            {

                return mainBase.acl.Update(body, calendarId, ruleId, gShellServiceAccount);
            }


            public Google.Apis.Calendar.v3.Data.Channel Watch (Google.Apis.Calendar.v3.Data.Channel body, string

             calendarId, gCalendar.Acl.AclWatchProperties properties = null)
            {

                properties = (properties != null) ? properties : new gCalendar.Acl.AclWatchProperties();

                return mainBase.acl.Watch(body, calendarId, properties, gShellServiceAccount);
            }
        }

        #endregion



        #region CalendarList

        public class CalendarList
        {




            public void Delete (string

             calendarId)
            {

                mainBase.calendarList.Delete(calendarId, gShellServiceAccount);
            }


            public Google.Apis.Calendar.v3.Data.CalendarListEntry Get (string

             calendarId)
            {

                return mainBase.calendarList.Get(calendarId, gShellServiceAccount);
            }


            public Google.Apis.Calendar.v3.Data.CalendarListEntry Insert (Google.Apis.Calendar.v3.Data.CalendarListEntry body, gCalendar.CalendarList.CalendarListInsertProperties properties = null)
            {

                properties = (properties != null) ? properties : new gCalendar.CalendarList.CalendarListInsertProperties();

                return mainBase.calendarList.Insert(body, properties, gShellServiceAccount);
            }


            public List<Google.Apis.Calendar.v3.Data.CalendarList> List(gCalendar.CalendarList.CalendarListListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gCalendar.CalendarList.CalendarListListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return mainBase.calendarList.List(properties);
            }


            public Google.Apis.Calendar.v3.Data.CalendarListEntry Patch (Google.Apis.Calendar.v3.Data.CalendarListEntry body, string

             calendarId, gCalendar.CalendarList.CalendarListPatchProperties properties = null)
            {

                properties = (properties != null) ? properties : new gCalendar.CalendarList.CalendarListPatchProperties();

                return mainBase.calendarList.Patch(body, calendarId, properties, gShellServiceAccount);
            }


            public Google.Apis.Calendar.v3.Data.CalendarListEntry Update (Google.Apis.Calendar.v3.Data.CalendarListEntry body, string

             calendarId, gCalendar.CalendarList.CalendarListUpdateProperties properties = null)
            {

                properties = (properties != null) ? properties : new gCalendar.CalendarList.CalendarListUpdateProperties();

                return mainBase.calendarList.Update(body, calendarId, properties, gShellServiceAccount);
            }


            public Google.Apis.Calendar.v3.Data.Channel Watch (Google.Apis.Calendar.v3.Data.Channel body, gCalendar.CalendarList.CalendarListWatchProperties properties = null)
            {

                properties = (properties != null) ? properties : new gCalendar.CalendarList.CalendarListWatchProperties();

                return mainBase.calendarList.Watch(body, properties, gShellServiceAccount);
            }
        }

        #endregion



        #region Calendars

        public class Calendars
        {




            public void Clear (string

             calendarId)
            {

                mainBase.calendars.Clear(calendarId, gShellServiceAccount);
            }


            public void Delete (string

             calendarId)
            {

                mainBase.calendars.Delete(calendarId, gShellServiceAccount);
            }


            public Google.Apis.Calendar.v3.Data.Calendar Get (string

             calendarId)
            {

                return mainBase.calendars.Get(calendarId, gShellServiceAccount);
            }


            public Google.Apis.Calendar.v3.Data.Calendar Insert (Google.Apis.Calendar.v3.Data.Calendar body)
            {

                return mainBase.calendars.Insert(body, gShellServiceAccount);
            }


            public Google.Apis.Calendar.v3.Data.Calendar Patch (Google.Apis.Calendar.v3.Data.Calendar body, string

             calendarId)
            {

                return mainBase.calendars.Patch(body, calendarId, gShellServiceAccount);
            }


            public Google.Apis.Calendar.v3.Data.Calendar Update (Google.Apis.Calendar.v3.Data.Calendar body, string

             calendarId)
            {

                return mainBase.calendars.Update(body, calendarId, gShellServiceAccount);
            }
        }

        #endregion



        #region Channels

        public class Channels
        {




            public void Stop (Google.Apis.Calendar.v3.Data.Channel body)
            {

                mainBase.channels.Stop(body, gShellServiceAccount);
            }
        }

        #endregion



        #region Colors

        public class Colors
        {




            public Google.Apis.Calendar.v3.Data.Colors Get ()
            {

                return mainBase.colors.Get(gShellServiceAccount);
            }
        }

        #endregion



        #region Events

        public class Events
        {




            public void Delete (string

             calendarId, string

             eventId, gCalendar.Events.EventsDeleteProperties properties = null)
            {

                properties = (properties != null) ? properties : new gCalendar.Events.EventsDeleteProperties();

                mainBase.events.Delete(calendarId, eventId, properties, gShellServiceAccount);
            }


            public Google.Apis.Calendar.v3.Data.Event Get (string

             calendarId, string

             eventId, gCalendar.Events.EventsGetProperties properties = null)
            {

                properties = (properties != null) ? properties : new gCalendar.Events.EventsGetProperties();

                return mainBase.events.Get(calendarId, eventId, properties, gShellServiceAccount);
            }


            public Google.Apis.Calendar.v3.Data.Event Import (Google.Apis.Calendar.v3.Data.Event body, string

             calendarId, gCalendar.Events.EventsImportProperties properties = null)
            {

                properties = (properties != null) ? properties : new gCalendar.Events.EventsImportProperties();

                return mainBase.events.Import(body, calendarId, properties, gShellServiceAccount);
            }


            public Google.Apis.Calendar.v3.Data.Event Insert (Google.Apis.Calendar.v3.Data.Event body, string

             calendarId, gCalendar.Events.EventsInsertProperties properties = null)
            {

                properties = (properties != null) ? properties : new gCalendar.Events.EventsInsertProperties();

                return mainBase.events.Insert(body, calendarId, properties, gShellServiceAccount);
            }


            public List<Google.Apis.Calendar.v3.Data.Events> Instances(string

             calendarId, string

             eventId, gCalendar.Events.EventsInstancesProperties properties = null)
            {

                properties = (properties != null) ? properties : new gCalendar.Events.EventsInstancesProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return mainBase.events.Instances(calendarId, eventId, properties);
            }


            public List<Google.Apis.Calendar.v3.Data.Events> List(string

             calendarId, gCalendar.Events.EventsListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gCalendar.Events.EventsListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return mainBase.events.List(calendarId, properties);
            }


            public Google.Apis.Calendar.v3.Data.Event Move (string

             calendarId, string

             eventId, string

             destination, gCalendar.Events.EventsMoveProperties properties = null)
            {

                properties = (properties != null) ? properties : new gCalendar.Events.EventsMoveProperties();

                return mainBase.events.Move(calendarId, eventId, destination, properties, gShellServiceAccount);
            }


            public Google.Apis.Calendar.v3.Data.Event Patch (Google.Apis.Calendar.v3.Data.Event body, string

             calendarId, string

             eventId, gCalendar.Events.EventsPatchProperties properties = null)
            {

                properties = (properties != null) ? properties : new gCalendar.Events.EventsPatchProperties();

                return mainBase.events.Patch(body, calendarId, eventId, properties, gShellServiceAccount);
            }


            public Google.Apis.Calendar.v3.Data.Event QuickAdd (string

             calendarId, string

             text, gCalendar.Events.EventsQuickAddProperties properties = null)
            {

                properties = (properties != null) ? properties : new gCalendar.Events.EventsQuickAddProperties();

                return mainBase.events.QuickAdd(calendarId, text, properties, gShellServiceAccount);
            }


            public Google.Apis.Calendar.v3.Data.Event Update (Google.Apis.Calendar.v3.Data.Event body, string

             calendarId, string

             eventId, gCalendar.Events.EventsUpdateProperties properties = null)
            {

                properties = (properties != null) ? properties : new gCalendar.Events.EventsUpdateProperties();

                return mainBase.events.Update(body, calendarId, eventId, properties, gShellServiceAccount);
            }


            public Google.Apis.Calendar.v3.Data.Channel Watch (Google.Apis.Calendar.v3.Data.Channel body, string

             calendarId, gCalendar.Events.EventsWatchProperties properties = null)
            {

                properties = (properties != null) ? properties : new gCalendar.Events.EventsWatchProperties();

                return mainBase.events.Watch(body, calendarId, properties, gShellServiceAccount);
            }
        }

        #endregion



        #region Freebusy

        public class Freebusy
        {




            public Google.Apis.Calendar.v3.Data.FreeBusyResponse Query (Google.Apis.Calendar.v3.Data.FreeBusyRequest body)
            {

                return mainBase.freebusy.Query(body, gShellServiceAccount);
            }
        }

        #endregion



        #region Settings

        public class Settings
        {




            public Google.Apis.Calendar.v3.Data.Setting Get (string

             setting)
            {

                return mainBase.settings.Get(setting, gShellServiceAccount);
            }


            public List<Google.Apis.Calendar.v3.Data.Settings> List(gCalendar.Settings.SettingsListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gCalendar.Settings.SettingsListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return mainBase.settings.List(properties);
            }


            public Google.Apis.Calendar.v3.Data.Channel Watch (Google.Apis.Calendar.v3.Data.Channel body, gCalendar.Settings.SettingsWatchProperties properties = null)
            {

                properties = (properties != null) ? properties : new gCalendar.Settings.SettingsWatchProperties();

                return mainBase.settings.Watch(body, properties, gShellServiceAccount);
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

    using v3 = Google.Apis.Calendar.v3;
    using Data = Google.Apis.Calendar.v3.Data;

    public class Calendar : ServiceWrapper<v3.CalendarService>
    {

        protected override bool worksWithGmail { get { return true; } }

        protected override v3.CalendarService CreateNewService(string domain, AuthenticatedUserInfo authInfo, string gShellServiceAccount = null)
        {
            return new v3.CalendarService(OAuth2Base.GetInitializer(domain, authInfo, gShellServiceAccount));
        }

        public override string apiNameAndVersion { get { return "calendar:v3"; } }

        public Acl acl{ get; set; }
        public CalendarList calendarList{ get; set; }
        public Calendars calendars{ get; set; }
        public Channels channels{ get; set; }
        public Colors colors{ get; set; }
        public Events events{ get; set; }
        public Freebusy freebusy{ get; set; }
        public Settings settings{ get; set; }

        public Calendar() //public Reports()
        {

            acl = new Acl();
            calendarList = new CalendarList();
            calendars = new Calendars();
            channels = new Channels();
            colors = new Colors();
            events = new Events();
            freebusy = new Freebusy();
            settings = new Settings();
        }




        public class Acl
        {



            public class AclListProperties
            {
                public int maxResults = 0;

                public     System.Nullable<bool>     showDeleted = null; //test
                public     string     syncToken = null; //test
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }

            public class AclWatchProperties
            {
                public int maxResults = 0;

                public     System.Nullable<bool>     showDeleted = null; //test
                public     string     syncToken = null; //test
            }


            public void Delete
            (string calendarId, string ruleId, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).Acl.Delete(calendarId, ruleId).Execute();
            }

            public Google.Apis.Calendar.v3.Data.AclRule Get
            (string calendarId, string ruleId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Acl.Get(calendarId, ruleId).Execute();
            }

            public Google.Apis.Calendar.v3.Data.AclRule Insert
            (Google.Apis.Calendar.v3.Data.AclRule body, string calendarId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Acl.Insert(body, calendarId).Execute();
            }

            public List<Google.Apis.Calendar.v3.Data.Acl> List(
                string     calendarId, AclListProperties properties = null, string gShellServiceAccount = null)
            {
                var results = new List<Google.Apis.Calendar.v3.Data.Acl>();

                v3.AclResource.ListRequest request = GetService(gShellServiceAccount).Acl.List(
            calendarId);

                if (properties != null)
                {
                    request.MaxResults = properties.maxResults;
                    request.ShowDeleted = properties.showDeleted;
                    request.SyncToken = properties.syncToken;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering Acl",
                        string.Format("-Collecting Acl 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.Calendar.v3.Data.Acl pagedResult = request.Execute();

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
                            properties.updateProgressBar(5, 10, "Gathering Acl",
                                    string.Format("-Collecting Acl {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering Acl",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            public Google.Apis.Calendar.v3.Data.AclRule Patch
            (Google.Apis.Calendar.v3.Data.AclRule body, string calendarId, string ruleId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Acl.Patch(body, calendarId, ruleId).Execute();
            }

            public Google.Apis.Calendar.v3.Data.AclRule Update
            (Google.Apis.Calendar.v3.Data.AclRule body, string calendarId, string ruleId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Acl.Update(body, calendarId, ruleId).Execute();
            }

            public Google.Apis.Calendar.v3.Data.Channel Watch
            (Google.Apis.Calendar.v3.Data.Channel body, string calendarId, AclWatchProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Acl.Watch(body, calendarId).Execute();
            }

        }


        public class CalendarList
        {



            public class CalendarListInsertProperties
            {
                public     System.Nullable<bool>     colorRgbFormat = null; //test
            }

            public class CalendarListListProperties
            {
                public int maxResults = 0;
                public    v3.CalendarListResource.ListRequest.MinAccessRoleEnum?     minAccessRole = null; //test

                public     System.Nullable<bool>     showDeleted = null; //test
                public     System.Nullable<bool>     showHidden = null; //test
                public     string     syncToken = null; //test
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }

            public class CalendarListPatchProperties
            {
                public     System.Nullable<bool>     colorRgbFormat = null; //test
            }

            public class CalendarListUpdateProperties
            {
                public     System.Nullable<bool>     colorRgbFormat = null; //test
            }

            public class CalendarListWatchProperties
            {
                public int maxResults = 0;
                public    v3.CalendarListResource.WatchRequest.MinAccessRoleEnum?     minAccessRole = null; //test

                public     System.Nullable<bool>     showDeleted = null; //test
                public     System.Nullable<bool>     showHidden = null; //test
                public     string     syncToken = null; //test
            }


            public void Delete
            (string calendarId, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).CalendarList.Delete(calendarId).Execute();
            }

            public Google.Apis.Calendar.v3.Data.CalendarListEntry Get
            (string calendarId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).CalendarList.Get(calendarId).Execute();
            }

            public Google.Apis.Calendar.v3.Data.CalendarListEntry Insert
            (Google.Apis.Calendar.v3.Data.CalendarListEntry body, CalendarListInsertProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).CalendarList.Insert(body).Execute();
            }

            public List<Google.Apis.Calendar.v3.Data.CalendarList> List(
                CalendarListListProperties properties = null, string gShellServiceAccount = null)
            {
                var results = new List<Google.Apis.Calendar.v3.Data.CalendarList>();

                v3.CalendarListResource.ListRequest request = GetService(gShellServiceAccount).CalendarList.List(
            );

                if (properties != null)
                {
                    request.MaxResults = properties.maxResults;
                    request.MinAccessRole = properties.minAccessRole;
                    request.ShowDeleted = properties.showDeleted;
                    request.ShowHidden = properties.showHidden;
                    request.SyncToken = properties.syncToken;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering CalendarList",
                        string.Format("-Collecting CalendarList 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.Calendar.v3.Data.CalendarList pagedResult = request.Execute();

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
                            properties.updateProgressBar(5, 10, "Gathering CalendarList",
                                    string.Format("-Collecting CalendarList {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering CalendarList",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            public Google.Apis.Calendar.v3.Data.CalendarListEntry Patch
            (Google.Apis.Calendar.v3.Data.CalendarListEntry body, string calendarId, CalendarListPatchProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).CalendarList.Patch(body, calendarId).Execute();
            }

            public Google.Apis.Calendar.v3.Data.CalendarListEntry Update
            (Google.Apis.Calendar.v3.Data.CalendarListEntry body, string calendarId, CalendarListUpdateProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).CalendarList.Update(body, calendarId).Execute();
            }

            public Google.Apis.Calendar.v3.Data.Channel Watch
            (Google.Apis.Calendar.v3.Data.Channel body, CalendarListWatchProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).CalendarList.Watch(body).Execute();
            }

        }


        public class Calendars
        {





            public void Clear
            (string calendarId, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).Calendars.Clear(calendarId).Execute();
            }

            public void Delete
            (string calendarId, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).Calendars.Delete(calendarId).Execute();
            }

            public Google.Apis.Calendar.v3.Data.Calendar Get
            (string calendarId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Calendars.Get(calendarId).Execute();
            }

            public Google.Apis.Calendar.v3.Data.Calendar Insert
            (Google.Apis.Calendar.v3.Data.Calendar body, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Calendars.Insert(body).Execute();
            }

            public Google.Apis.Calendar.v3.Data.Calendar Patch
            (Google.Apis.Calendar.v3.Data.Calendar body, string calendarId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Calendars.Patch(body, calendarId).Execute();
            }

            public Google.Apis.Calendar.v3.Data.Calendar Update
            (Google.Apis.Calendar.v3.Data.Calendar body, string calendarId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Calendars.Update(body, calendarId).Execute();
            }

        }


        public class Channels
        {





            public void Stop
            (Google.Apis.Calendar.v3.Data.Channel body, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).Channels.Stop(body).Execute();
            }

        }


        public class Colors
        {





            public Google.Apis.Calendar.v3.Data.Colors Get
            (string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Colors.Get().Execute();
            }

        }


        public class Events
        {



            public class EventsDeleteProperties
            {
                public     System.Nullable<bool>     sendNotifications = null; //test
            }

            public class EventsGetProperties
            {
                public     System.Nullable<bool>     alwaysIncludeEmail = null; //test
                public     System.Nullable<int>     maxAttendees = null; //test
                public     string     timeZone = null; //test
            }

            public class EventsImportProperties
            {
                public     System.Nullable<bool>     supportsAttachments = null; //test
            }

            public class EventsInsertProperties
            {
                public     System.Nullable<int>     maxAttendees = null; //test
                public     System.Nullable<bool>     sendNotifications = null; //test
                public     System.Nullable<bool>     supportsAttachments = null; //test
            }

            public class EventsInstancesProperties
            {
                public     System.Nullable<bool>     alwaysIncludeEmail = null; //test
                public     System.Nullable<int>     maxAttendees = null; //test
                public int maxResults = 0;
                public     string     originalStart = null; //test

                public     System.Nullable<bool>     showDeleted = null; //test
                public     System.Nullable<System.DateTime>     timeMax = null; //test
                public     System.Nullable<System.DateTime>     timeMin = null; //test
                public     string     timeZone = null; //test
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }

            public class EventsListProperties
            {
                public     System.Nullable<bool>     alwaysIncludeEmail = null; //test
                public     string     iCalUID = null; //test
                public     System.Nullable<int>     maxAttendees = null; //test
                public int maxResults = 0;
                public    v3.EventsResource.ListRequest.OrderByEnum?     orderBy = null; //test

                public    Google.Apis.Util.Repeatable<string>     privateExtendedProperty = null; //test
                public     string     q = null; //test
                public    Google.Apis.Util.Repeatable<string>     sharedExtendedProperty = null; //test
                public     System.Nullable<bool>     showDeleted = null; //test
                public     System.Nullable<bool>     showHiddenInvitations = null; //test
                public     System.Nullable<bool>     singleEvents = null; //test
                public     string     syncToken = null; //test
                public     System.Nullable<System.DateTime>     timeMax = null; //test
                public     System.Nullable<System.DateTime>     timeMin = null; //test
                public     string     timeZone = null; //test
                public     System.Nullable<System.DateTime>     updatedMin = null; //test
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }

            public class EventsMoveProperties
            {
                public     System.Nullable<bool>     sendNotifications = null; //test
            }

            public class EventsPatchProperties
            {
                public     System.Nullable<bool>     alwaysIncludeEmail = null; //test
                public     System.Nullable<int>     maxAttendees = null; //test
                public     System.Nullable<bool>     sendNotifications = null; //test
                public     System.Nullable<bool>     supportsAttachments = null; //test
            }

            public class EventsQuickAddProperties
            {
                public     System.Nullable<bool>     sendNotifications = null; //test
            }

            public class EventsUpdateProperties
            {
                public     System.Nullable<bool>     alwaysIncludeEmail = null; //test
                public     System.Nullable<int>     maxAttendees = null; //test
                public     System.Nullable<bool>     sendNotifications = null; //test
                public     System.Nullable<bool>     supportsAttachments = null; //test
            }

            public class EventsWatchProperties
            {
                public     System.Nullable<bool>     alwaysIncludeEmail = null; //test
                public     string     iCalUID = null; //test
                public     System.Nullable<int>     maxAttendees = null; //test
                public int maxResults = 0;
                public    v3.EventsResource.WatchRequest.OrderByEnum?     orderBy = null; //test

                public    Google.Apis.Util.Repeatable<string>     privateExtendedProperty = null; //test
                public     string     q = null; //test
                public    Google.Apis.Util.Repeatable<string>     sharedExtendedProperty = null; //test
                public     System.Nullable<bool>     showDeleted = null; //test
                public     System.Nullable<bool>     showHiddenInvitations = null; //test
                public     System.Nullable<bool>     singleEvents = null; //test
                public     string     syncToken = null; //test
                public     System.Nullable<System.DateTime>     timeMax = null; //test
                public     System.Nullable<System.DateTime>     timeMin = null; //test
                public     string     timeZone = null; //test
                public     System.Nullable<System.DateTime>     updatedMin = null; //test
            }


            public void Delete
            (string calendarId, string eventId, EventsDeleteProperties properties = null, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).Events.Delete(calendarId, eventId).Execute();
            }

            public Google.Apis.Calendar.v3.Data.Event Get
            (string calendarId, string eventId, EventsGetProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Events.Get(calendarId, eventId).Execute();
            }

            public Google.Apis.Calendar.v3.Data.Event Import
            (Google.Apis.Calendar.v3.Data.Event body, string calendarId, EventsImportProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Events.Import(body, calendarId).Execute();
            }

            public Google.Apis.Calendar.v3.Data.Event Insert
            (Google.Apis.Calendar.v3.Data.Event body, string calendarId, EventsInsertProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Events.Insert(body, calendarId).Execute();
            }

            public List<Google.Apis.Calendar.v3.Data.Events> Instances(
                string     calendarId, string     eventId, EventsInstancesProperties properties = null, string gShellServiceAccount = null)
            {
                var results = new List<Google.Apis.Calendar.v3.Data.Events>();

                v3.EventsResource.InstancesRequest request = GetService(gShellServiceAccount).Events.Instances(
            calendarId, eventId);

                if (properties != null)
                {
                    request.AlwaysIncludeEmail = properties.alwaysIncludeEmail;
                    request.MaxAttendees = properties.maxAttendees;
                    request.MaxResults = properties.maxResults;
                    request.OriginalStart = properties.originalStart;
                    request.ShowDeleted = properties.showDeleted;
                    request.TimeMax = properties.timeMax;
                    request.TimeMin = properties.timeMin;
                    request.TimeZone = properties.timeZone;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering Events",
                        string.Format("-Collecting Events 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.Calendar.v3.Data.Events pagedResult = request.Execute();

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
                            properties.updateProgressBar(5, 10, "Gathering Events",
                                    string.Format("-Collecting Events {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering Events",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            public List<Google.Apis.Calendar.v3.Data.Events> List(
                string     calendarId, EventsListProperties properties = null, string gShellServiceAccount = null)
            {
                var results = new List<Google.Apis.Calendar.v3.Data.Events>();

                v3.EventsResource.ListRequest request = GetService(gShellServiceAccount).Events.List(
            calendarId);

                if (properties != null)
                {
                    request.AlwaysIncludeEmail = properties.alwaysIncludeEmail;
                    request.ICalUID = properties.iCalUID;
                    request.MaxAttendees = properties.maxAttendees;
                    request.MaxResults = properties.maxResults;
                    request.OrderBy = properties.orderBy;
                    request.PrivateExtendedProperty = properties.privateExtendedProperty;
                    request.Q = properties.q;
                    request.SharedExtendedProperty = properties.sharedExtendedProperty;
                    request.ShowDeleted = properties.showDeleted;
                    request.ShowHiddenInvitations = properties.showHiddenInvitations;
                    request.SingleEvents = properties.singleEvents;
                    request.SyncToken = properties.syncToken;
                    request.TimeMax = properties.timeMax;
                    request.TimeMin = properties.timeMin;
                    request.TimeZone = properties.timeZone;
                    request.UpdatedMin = properties.updatedMin;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering Events",
                        string.Format("-Collecting Events 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.Calendar.v3.Data.Events pagedResult = request.Execute();

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
                            properties.updateProgressBar(5, 10, "Gathering Events",
                                    string.Format("-Collecting Events {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering Events",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            public Google.Apis.Calendar.v3.Data.Event Move
            (string calendarId, string eventId, string destination, EventsMoveProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Events.Move(calendarId, eventId, destination).Execute();
            }

            public Google.Apis.Calendar.v3.Data.Event Patch
            (Google.Apis.Calendar.v3.Data.Event body, string calendarId, string eventId, EventsPatchProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Events.Patch(body, calendarId, eventId).Execute();
            }

            public Google.Apis.Calendar.v3.Data.Event QuickAdd
            (string calendarId, string text, EventsQuickAddProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Events.QuickAdd(calendarId, text).Execute();
            }

            public Google.Apis.Calendar.v3.Data.Event Update
            (Google.Apis.Calendar.v3.Data.Event body, string calendarId, string eventId, EventsUpdateProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Events.Update(body, calendarId, eventId).Execute();
            }

            public Google.Apis.Calendar.v3.Data.Channel Watch
            (Google.Apis.Calendar.v3.Data.Channel body, string calendarId, EventsWatchProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Events.Watch(body, calendarId).Execute();
            }

        }


        public class Freebusy
        {





            public Google.Apis.Calendar.v3.Data.FreeBusyResponse Query
            (Google.Apis.Calendar.v3.Data.FreeBusyRequest body, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Freebusy.Query(body).Execute();
            }

        }


        public class Settings
        {



            public class SettingsListProperties
            {
                public int maxResults = 0;

                public     string     syncToken = null; //test
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }

            public class SettingsWatchProperties
            {
                public int maxResults = 0;

                public     string     syncToken = null; //test
            }


            public Google.Apis.Calendar.v3.Data.Setting Get
            (string setting, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Settings.Get(setting).Execute();
            }

            public List<Google.Apis.Calendar.v3.Data.Settings> List(
                SettingsListProperties properties = null, string gShellServiceAccount = null)
            {
                var results = new List<Google.Apis.Calendar.v3.Data.Settings>();

                v3.SettingsResource.ListRequest request = GetService(gShellServiceAccount).Settings.List(
            );

                if (properties != null)
                {
                    request.MaxResults = properties.maxResults;
                    request.SyncToken = properties.syncToken;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering Settings",
                        string.Format("-Collecting Settings 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.Calendar.v3.Data.Settings pagedResult = request.Execute();

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
                            properties.updateProgressBar(5, 10, "Gathering Settings",
                                    string.Format("-Collecting Settings {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering Settings",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            public Google.Apis.Calendar.v3.Data.Channel Watch
            (Google.Apis.Calendar.v3.Data.Channel body, SettingsWatchProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Settings.Watch(body).Execute();
            }

        }

    }
}