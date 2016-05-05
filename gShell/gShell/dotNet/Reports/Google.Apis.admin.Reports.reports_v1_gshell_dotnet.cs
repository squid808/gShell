namespace gShell.Cmdlets.Reports{

    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using reports_v1 = Google.Apis.admin.Reports.reports_v1;
    using Data = Google.Apis.admin.Reports.reports_v1.Data;

    using gShell.dotNet.Utilities;
    using gShell.dotNet.Utilities.OAuth2;
    using gReports = gShell.dotNet.Reports;

    public abstract class ReportsBase : OAuth2CmdletBase
    {

        #region Properties
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        protected static gReports mainBase { get; set; }

        public Activities activities { get; set; }
        public Channels channels { get; set; }
        public CustomerUsageReports customerUsageReports { get; set; }
        public UserUsageReport userUsageReport { get; set; }

        protected override string apiNameAndVersion { get { return mainBase.apiNameAndVersion; } }

        protected static string gShellServiceAccount { get; set; }
        #endregion

        #region Constructors
        public ReportsBase()
        {
            mainBase = new gReports();

            activities = new Activities();
            channels = new Channels();
            customerUsageReports = new CustomerUsageReports();
            userUsageReport = new UserUsageReport();
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



        #region Activities

        public class Activities
        {




            public List<Google.Apis.admin.Reports.reports_v1.Data.Activities> List(string

             userKey, string

             applicationName, gReports.Activities.ActivitiesListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gReports.Activities.ActivitiesListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return mainBase.activities.List(userKey, applicationName, properties);
            }


            public Google.Apis.admin.Reports.reports_v1.Data.Channel Watch (Google.Apis.admin.Reports.reports_v1.Data.Channel body, string

             userKey, string

             applicationName, gReports.Activities.ActivitiesWatchProperties properties = null)
            {

                properties = (properties != null) ? properties : new gReports.Activities.ActivitiesWatchProperties();

                return mainBase.activities.Watch(body, userKey, applicationName, properties, gShellServiceAccount);
            }
        }

        #endregion



        #region Channels

        public class Channels
        {




            public void Stop (Google.Apis.admin.Reports.reports_v1.Data.Channel body)
            {

                mainBase.channels.Stop(body, gShellServiceAccount);
            }
        }

        #endregion



        #region CustomerUsageReports

        public class CustomerUsageReports
        {




            public List<Google.Apis.admin.Reports.reports_v1.Data.UsageReports> Get(string

             date, gReports.CustomerUsageReports.CustomerUsageReportsGetProperties properties = null)
            {

                properties = (properties != null) ? properties : new gReports.CustomerUsageReports.CustomerUsageReportsGetProperties();


                return mainBase.customerUsageReports.Get(date, properties);
            }
        }

        #endregion



        #region UserUsageReport

        public class UserUsageReport
        {




            public List<Google.Apis.admin.Reports.reports_v1.Data.UsageReports> Get(string

             userKey, string

             date, gReports.UserUsageReport.UserUsageReportGetProperties properties = null)
            {

                properties = (properties != null) ? properties : new gReports.UserUsageReport.UserUsageReportGetProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return mainBase.userUsageReport.Get(userKey, date, properties);
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

    using reports_v1 = Google.Apis.admin.Reports.reports_v1;
    using Data = Google.Apis.admin.Reports.reports_v1.Data;

    public class Reports : ServiceWrapper<reports_v1.ReportsService>
    {

        protected override bool worksWithGmail { get { return false; } }

        protected override reports_v1.ReportsService CreateNewService(string domain, AuthenticatedUserInfo authInfo, string gShellServiceAccount = null)
        {
            return new reports_v1.ReportsService(OAuth2Base.GetInitializer(domain, authInfo, gShellServiceAccount));
        }

        public override string apiNameAndVersion { get { return "admin:reports_v1"; } }

        public Activities activities{ get; set; }
        public Channels channels{ get; set; }
        public CustomerUsageReports customerUsageReports{ get; set; }
        public UserUsageReport userUsageReport{ get; set; }

        public Reports() //public Reports()
        {

            activities = new Activities();
            channels = new Channels();
            customerUsageReports = new CustomerUsageReports();
            userUsageReport = new UserUsageReport();
        }




        public class Activities
        {



            public class ActivitiesListProperties
            {
                public     string     actorIpAddress = null; //test
                public     string     customerId = null; //test
                public     string     endTime = null; //test
                public     string     eventName = null; //test
                public     string     filters = null; //test
                public int maxResults = 1000;

                public     string     startTime = null; //test
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }

            public class ActivitiesWatchProperties
            {
                public     string     actorIpAddress = null; //test
                public     string     customerId = null; //test
                public     string     endTime = null; //test
                public     string     eventName = null; //test
                public     string     filters = null; //test
                public int maxResults = 1000;

                public     string     startTime = null; //test
            }


            public List<Google.Apis.admin.Reports.reports_v1.Data.Activities> List(
                string     userKey, string     applicationName, ActivitiesListProperties properties = null, string gShellServiceAccount = null)
            {
                var results = new List<Google.Apis.admin.Reports.reports_v1.Data.Activities>();

                reports_v1.ActivitiesResource.ListRequest request = GetService(gShellServiceAccount).Activities.List(
            userKey, applicationName);

                if (properties != null)
                {
                    request.ActorIpAddress = properties.actorIpAddress;
                    request.CustomerId = properties.customerId;
                    request.EndTime = properties.endTime;
                    request.EventName = properties.eventName;
                    request.Filters = properties.filters;
                    request.MaxResults = properties.maxResults;
                    request.StartTime = properties.startTime;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering Activities",
                        string.Format("-Collecting Activities 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.admin.Reports.reports_v1.Data.Activities pagedResult = request.Execute();

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
                            properties.updateProgressBar(5, 10, "Gathering Activities",
                                    string.Format("-Collecting Activities {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering Activities",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            public Google.Apis.admin.Reports.reports_v1.Data.Channel Watch (Google.Apis.admin.Reports.reports_v1.Data.Channel body, string

             userKey, string

             applicationName, ActivitiesWatchProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Activities.Watch(body, userKey, applicationName).Execute();
            }

        }


        public class Channels
        {





            public void Stop (Google.Apis.admin.Reports.reports_v1.Data.Channel body, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).Channels.Stop(body).Execute();
            }

        }


        public class CustomerUsageReports
        {



            public class CustomerUsageReportsGetProperties
            {
                public     string     customerId = null; //test

                public     string     parameters = null; //test
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }


            public List<Google.Apis.admin.Reports.reports_v1.Data.UsageReports> Get(
                string     date, CustomerUsageReportsGetProperties properties = null, string gShellServiceAccount = null)
            {
                var results = new List<Google.Apis.admin.Reports.reports_v1.Data.UsageReports>();

                reports_v1.CustomerUsageReportsResource.GetRequest request = GetService(gShellServiceAccount).CustomerUsageReports.Get(
            date);

                if (properties != null)
                {
                    request.CustomerId = properties.customerId;
                    request.Parameters = properties.parameters;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering CustomerUsageReports",
                        string.Format("-Collecting CustomerUsageReports 1 to {0}", "unknown"));
                }

                Google.Apis.admin.Reports.reports_v1.Data.UsageReports pagedResult = request.Execute();

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
                            properties.updateProgressBar(5, 10, "Gathering CustomerUsageReports",
                                    string.Format("-Collecting CustomerUsageReports {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        "unknown"));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering CustomerUsageReports",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

        }


        public class UserUsageReport
        {



            public class UserUsageReportGetProperties
            {
                public     string     customerId = null; //test
                public     string     filters = null; //test
                public int maxResults = 1000;

                public     string     parameters = null; //test
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }


            public List<Google.Apis.admin.Reports.reports_v1.Data.UsageReports> Get(
                string     userKey, string     date, UserUsageReportGetProperties properties = null, string gShellServiceAccount = null)
            {
                var results = new List<Google.Apis.admin.Reports.reports_v1.Data.UsageReports>();

                reports_v1.UserUsageReportResource.GetRequest request = GetService(gShellServiceAccount).UserUsageReport.Get(
            userKey, date);

                if (properties != null)
                {
                    request.CustomerId = properties.customerId;
                    request.Filters = properties.filters;
                    request.MaxResults = properties.maxResults;
                    request.Parameters = properties.parameters;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering UserUsageReport",
                        string.Format("-Collecting UserUsageReport 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.admin.Reports.reports_v1.Data.UsageReports pagedResult = request.Execute();

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
                            properties.updateProgressBar(5, 10, "Gathering UserUsageReport",
                                    string.Format("-Collecting UserUsageReport {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering UserUsageReport",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

        }

    }
}