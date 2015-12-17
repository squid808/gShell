using System;
using System.Collections.Generic;
using reports_v1 = Google.Apis.Admin.Reports.reports_v1;
using Data = Google.Apis.Admin.Reports.reports_v1.Data;
using gShell.dotNet;
using gShell.dotNet.Utilities.OAuth2;

namespace gShell.dotNet
{
    /// <summary>
    /// A consumer of the Reports Service that includes the gShell authentication.
    /// </summary>
    public class Reports : ServiceWrapper<reports_v1.ReportsService>
    {
        #region Inherited Members
        
        /// <summary>
        /// Indicates if this set of services will work with Gmail (as opposed to Google Apps). 
        /// This will cause authentication to fail if false and the user attempts to authenticate with
        /// a gmail address.
        /// </summary>
        protected override bool worksWithGmail { get { return false; } }

        /// <summary>
        /// Initialize and return a new ReportsService
        /// </summary>
        protected override reports_v1.ReportsService CreateNewService(string domain)
        {
            return new reports_v1.ReportsService(OAuth2Base.GetInitializer(domain));
        }

        public override string apiNameAndVersion { get { return "admin:reports_v1"; } }

        #endregion

        #region Properties
        
        public Activities activities { get; set; }
        public Channels channels { get; set; }
        public CustomerUsageReports customerUsageReports { get; set; }
        public UserUsageReports userUsageReports { get; set; }

        #endregion

        #region Constructors

        public Reports()
        {
            activities = new Activities();
            channels = new Channels();
            customerUsageReports = new CustomerUsageReports();
            userUsageReports = new UserUsageReports();
        }

        #endregion

        #region Wrapped Methods
        //the following methods assume that the service has been authenticated first.

        #region Activity

        public class Activities
        {
            public class ActivitiesListProperties
            {
                public int maxResults = 1000;
                public string customerId = null;
                public string actorIpAddress = null;
                public string endTime = null;
                public string eventName = null;
                public string filters = null;
                public string startTime = null;
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }

            public enum ApplicationName
            {
                admin, calendar, drive, login, token
            }

            public List<Data.Activity> List(ApplicationName applicationName, string userKey,
                ActivitiesListProperties properties = null)
            {
                return List(applicationName.ToString(), userKey, properties);
            }

            public List<Data.Activity> List(string applicationName, string userKey,
                ActivitiesListProperties properties = null)
            {
                List<Data.Activity> results = new List<Data.Activity>();

                reports_v1.ActivitiesResource.ListRequest request =
                    services[activeDomain].Activities.List(userKey, applicationName);

                if (properties != null)
                {
                    request.MaxResults = properties.maxResults;
                    request.CustomerId = properties.customerId;
                    request.ActorIpAddress = properties.actorIpAddress;
                    request.EndTime = properties.endTime;
                    request.EventName = properties.eventName;
                    request.Filters = properties.filters;
                    request.StartTime = properties.startTime;
                }

                string resultObjType = "Activities";

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering " + resultObjType,
                        string.Format("-Collecting {0} {1} to {2}", resultObjType, "1", request.MaxResults.ToString()));
                }

                Data.Activities pagedResult = request.Execute();

                if (pagedResult.Items != null)
                {
                    results.AddRange(pagedResult.Items);

                    while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                        pagedResult.NextPageToken != request.PageToken &&
                    (properties.totalResults == 0 || results.Count < properties.totalResults))
                    {
                        request.PageToken = pagedResult.NextPageToken;
                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(5, 10, "Gathering " + resultObjType,
                                    string.Format("-Collecting {0} {1} to {2}",
                                        resultObjType,
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.AddRange(pagedResult.Items);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering " + resultObjType,
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            public Data.Channel Watch(
                Data.Channel body, string userKey, ApplicationName applicationName)
            {
                return Watch(body, userKey, applicationName.ToString());
            }

            public Data.Channel Watch(
                Data.Channel body, string userKey, string applicationName)
            {
                return services[activeDomain].Activities.Watch(body, userKey, applicationName).Execute();
            }
        }

        #endregion

        #region Channels
        
        public class Channels
        {
            public string Stop(Data.Channel body)
            {
                return services[activeDomain].Channels.Stop(body).Execute();
            }
        }
        
        #endregion

        #region CustomerUsageReports
        
        public class CustomerUsageReports
        {
            public class CustomerUsageReportsGetProperties
            {
                public string customerId = null;
                public string parameters = null;
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }

            public Data.UsageReports Get(string date,
                CustomerUsageReportsGetProperties properties = null)
            {
                //Here we return the UsageReports object instead of a List so that 
                //we can retain the Kind member
                Data.UsageReports usageResults = new Data.UsageReports();

                List<Data.UsageReport> results = new List<Data.UsageReport>();
                List<Data.UsageReports.WarningsData> warnings = new List<Data.UsageReports.WarningsData>();

                reports_v1.CustomerUsageReportsResource.GetRequest request =
                    services[activeDomain].CustomerUsageReports.Get(date);

                if (properties != null)
                {
                    request.CustomerId = properties.customerId;
                    request.Parameters = properties.parameters;
                }

                string resultObjType = "Customer Usage Reports";

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering " + resultObjType,
                        string.Format("-Collecting {0} {1} to unknown", resultObjType, "1"));
                }

                Data.UsageReports pagedResult = request.Execute();

                usageResults.Kind = pagedResult.Kind;

                if (pagedResult.Warnings != null)
                {
                    warnings.AddRange(pagedResult.Warnings);
                }

                if (pagedResult.UsageReportsValue != null)
                {
                    results.AddRange(pagedResult.UsageReportsValue);

                    while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                        pagedResult.NextPageToken != request.PageToken &&
                    (properties.totalResults == 0 || results.Count < properties.totalResults))
                    {
                        request.PageToken = pagedResult.NextPageToken;
                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(5, 10, "Gathering " + resultObjType,
                                    string.Format("-Collecting {0} {1} to unknown",
                                        resultObjType,
                                        (results.Count + 1).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.AddRange(pagedResult.UsageReportsValue);
                        if (pagedResult.Warnings != null)
                        {
                            warnings.AddRange(pagedResult.Warnings);
                        }
                    }

                    usageResults.UsageReportsValue = results;

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering " + resultObjType,
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return usageResults;
            }
        }

        #endregion

        #region UserUsageReports

        public class UserUsageReports
        {
            public class UserUsageReportsGetProperties
            {
                public int maxResults = 1000;
                public string customerId = null;
                public string filters = null;
                public string parameters = null;
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }

            public Data.UsageReports Get(string userKey, string date,
                UserUsageReportsGetProperties properties = null)
            {
                Data.UsageReports usageResults = new Data.UsageReports();

                List<Data.UsageReport> results = new List<Data.UsageReport>();
                List<Data.UsageReports.WarningsData> warnings = new List<Data.UsageReports.WarningsData>();

                reports_v1.UserUsageReportResource.GetRequest request =
                    services[activeDomain].UserUsageReport.Get(userKey, date);

                if (properties != null)
                {
                    request.MaxResults = properties.maxResults;
                    request.CustomerId = properties.customerId;
                    request.Filters = properties.filters;
                    request.Parameters = properties.parameters;
                }

                string resultObjType = "User Usage Reports";

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering " + resultObjType,
                        string.Format("-Collecting {0} {1} to {2}", resultObjType, "1", request.MaxResults.ToString()));
                }

                Data.UsageReports pagedResult = request.Execute();

                usageResults.Kind = pagedResult.Kind;

                if (pagedResult.Warnings != null)
                {
                    warnings.AddRange(pagedResult.Warnings);
                }

                if (pagedResult.UsageReportsValue != null)
                {
                    results.AddRange(pagedResult.UsageReportsValue);

                    while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                        pagedResult.NextPageToken != request.PageToken &&
                    (properties.totalResults == 0 || results.Count < properties.totalResults))
                    {
                        request.PageToken = pagedResult.NextPageToken;
                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(5, 10, "Gathering " + resultObjType,
                                    string.Format("-Collecting {0} {1} to {2}",
                                        resultObjType,
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.AddRange(pagedResult.UsageReportsValue);
                        if (pagedResult.Warnings != null)
                        {
                            warnings.AddRange(pagedResult.Warnings);
                        }
                    }

                    usageResults.UsageReportsValue = results;

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering " + resultObjType,
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return usageResults;
            }
        }

        #endregion

        #endregion
    }
}
