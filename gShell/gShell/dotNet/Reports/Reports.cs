using System;
using System.Collections.Generic;
using reports_v1 = Google.Apis.Admin.Reports.reports_v1;
using Data = Google.Apis.Admin.Reports.reports_v1.Data;
using gShell.dotNet;
using gShell.dotNet.Utilities.OAuth2;

namespace gShell.dotNet.Reports
{
    /// <summary>
    /// A consumer of the Reports Service that includes the gShell authentication.
    /// </summary>
    public class Reports : ServiceWrapper<reports_v1.ReportsService>
    {
        #region Properties
        private static string activeDomain;
        #endregion

        #region Inherited Members
        private static override bool worksWithGmail = false;

        private static override reports_v1.ReportsService CreateNewService(string domain)
        {
            return new reports_v1.ReportsService(OAuth2Base.GetInitializer(domain));
        }
        #endregion

        #region Wrapped Methods
        //the following methods assume that the service has been authenticated first.
        
        #region Activity
        public class Activities
        {
            public static List<Data.Activity> List(string applicationName, string userKey, int maxResults = 1000,
                string customerId = null, string actorIpAddress = null, string endTime = null,
                string eventName = null, string filters = null, string startTime = null)
            {
                List<Data.Activity> results = new List<Data.Activity>();

                reports_v1.ActivitiesResource.ListRequest request =
                    services[activeDomain].Activities.List(userKey, applicationName);

                request.MaxResults = maxResults;
                request.CustomerId = customerId;
                request.ActorIpAddress = actorIpAddress;
                request.EndTime = endTime;
                request.EventName = eventName;
                request.Filters = filters;
                request.StartTime = startTime;

                Data.Activities pagedResult = request.Execute();

                results.AddRange(pagedResult.Items);

                while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                    pagedResult.NextPageToken != request.PageToken)
                {
                    request.PageToken = pagedResult.NextPageToken;
                    pagedResult = request.Execute();
                    results.AddRange(pagedResult.Items);
                }

                return results;
            }

            public static Data.Channel Watch(
                string domain, Data.Channel body, string userKey, string applicationName)
            {
                return services[activeDomain].Activities.Watch(body, userKey, applicationName).Execute();
            }
        }
        #endregion

        #region Channels
        public class Channels
        {
            public static string Stop(Data.Channel body)
            {
                return services[activeDomain].Channels.Stop(body).Execute();
            }
        }
        #endregion

        #region CustomerUsageReports
        public class CustomerUsageReports
        {
            public static Data.UsageReports Get(string date,
                string customerId = null, string parameters = null)
            {
                Data.UsageReports usageResults = new Data.UsageReports();

                List<Data.UsageReport> results = new List<Data.UsageReport>();

                reports_v1.CustomerUsageReportsResource.GetRequest request=
                    services[activeDomain].CustomerUsageReports.Get(date);

                request.CustomerId = customerId;
                request.Parameters = parameters;

                Data.UsageReports pagedResult = request.Execute();

                usageResults.Kind = pagedResult.Kind;

                foreach (Data.UsageReports.WarningsData warning in pagedResult.Warnings)
                {
                    usageResults.Warnings.Add(warning);
                }

                results.AddRange(pagedResult.UsageReportsValue);

                while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                    pagedResult.NextPageToken != request.PageToken)
                {
                    request.PageToken = pagedResult.NextPageToken;
                    pagedResult = request.Execute();
                    results.AddRange(pagedResult.UsageReportsValue);
                    foreach (Data.UsageReports.WarningsData warning in pagedResult.Warnings)
                    {
                        usageResults.Warnings.Add(warning);
                    }
                }

                foreach (Data.UsageReport usageReport in results)
                {
                    usageResults.UsageReportsValue.Add(usageReport);
                }

                return usageResults;
            }
        }

        #endregion

        #region UserUsageReports
        public class UserUsageReports
        {
            public static Data.UsageReports Get(string userKey, string date,
                int maxResults = 1000, string customerId = null, string filters = null,
                string parameters = null)
            {
                Data.UsageReports usageResults = new Data.UsageReports();

                List<Data.UsageReport> results = new List<Data.UsageReport>();

                reports_v1.UserUsageReportResource.GetRequest request = 
                    services[activeDomain].UserUsageReport.Get(userKey, date);

                request.MaxResults = maxResults;
                request.CustomerId = customerId;
                request.Filters = filters;
                request.Parameters = parameters;

                Data.UsageReports pagedResult = request.Execute();

                usageResults.Kind = pagedResult.Kind;

                foreach (Data.UsageReports.WarningsData warning in pagedResult.Warnings)
                {
                    usageResults.Warnings.Add(warning);
                }

                results.AddRange(pagedResult.UsageReportsValue);

                while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                    pagedResult.NextPageToken != request.PageToken)
                {
                    request.PageToken = pagedResult.NextPageToken;
                    pagedResult = request.Execute();
                    results.AddRange(pagedResult.UsageReportsValue);
                    foreach (Data.UsageReports.WarningsData warning in pagedResult.Warnings)
                    {
                        usageResults.Warnings.Add(warning);
                    }
                }

                foreach (Data.UsageReport usageReport in results)
                {
                    usageResults.UsageReportsValue.Add(usageReport);
                }

                return usageResults;
            }
        }
        #endregion
        #endregion
    }
}
