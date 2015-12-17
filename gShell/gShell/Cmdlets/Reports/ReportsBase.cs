using System;
using System.Management.Automation;
using System.Collections.Generic;

using Google.Apis.Services;
using reports_v1 = Google.Apis.Admin.Reports.reports_v1;
using Data = Google.Apis.Admin.Reports.reports_v1.Data;

using gShell.dotNet.Utilities;
using gShell.dotNet.Utilities.OAuth2;
using gReports = gShell.dotNet.Reports;

namespace gShell.Cmdlets.Reports
{
    /// <summary>
    /// /// The base class for all Google Reports API calls within the PowerShell Cmdlets.
    /// </summary>
    public abstract class ReportsBase : OAuth2CmdletBase
    {
        #region Properties
        protected static gReports greports = new gReports();
        protected Activities activities = new Activities();
        protected Channels channels = new Channels();
        protected CustomerUsageReports customerUsageReports = new CustomerUsageReports();
        protected UserUsageReports userUsageReports = new UserUsageReports();

        [Parameter(
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        protected override string apiNameAndVersion { get { return greports.apiNameAndVersion; } }
        #endregion

        #region PowerShell Methods
        protected override void BeginProcessing()
        {
            if (null == greports) { greports = new gReports(); }
            ShouldPromptForScopes(Domain);
            Domain = Authenticate().authenticatedDomain;

            GWriteProgress = new gWriteProgress(WriteProgress);
        }
        #endregion

        #region Authentication & Processing
        /// <summary>
        /// A method specific to each inherited object, called during authentication. Must be implemented.
        /// </summary>
        protected override AuthenticationInfo Authenticate()
        {
            return greports.Authenticate(apiNameAndVersion);
        }
        #endregion

        #region Wrapped Methods
        //the following methods assume that the service has been authenticated first.

        #region Activity
        public class Activities
        {
            public List<Data.Activity> List(gReports.Activities.ApplicationName applicationName, string userKey,
                gReports.Activities.ActivitiesListProperties properties = null)
            {
                properties = (properties != null) ? properties : new gReports.Activities.ActivitiesListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return greports.activities.List(applicationName, userKey, properties);
            }

            public Data.Channel Watch(
                Data.Channel body, string userKey, gReports.Activities.ApplicationName applicationName)
            {
                return greports.activities.Watch(body, userKey, applicationName);
            }
        }
        #endregion

        #region Channels
        public class Channels
        {
            public string Stop(Data.Channel body)
            {
                return greports.channels.Stop(body);
            }
        }
        #endregion

        #region CustomerUsageReports
        public class CustomerUsageReports
        {
            public gUsageReport Get(string date,
                gReports.CustomerUsageReports.CustomerUsageReportsGetProperties properties = null)
            {
                properties = (properties != null) ? properties : new
                    gReports.CustomerUsageReports.CustomerUsageReportsGetProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return new gUsageReport(greports.customerUsageReports.Get(date, properties));
            }
        }

        #endregion

        #region UserUsageReports
        public class UserUsageReports
        {
            public gUsageReport Get(string userKey, string date,
                gReports.UserUsageReports.UserUsageReportsGetProperties properties = null)
            {
                properties = (properties != null) ? properties : new
                    gReports.UserUsageReports.UserUsageReportsGetProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return new gUsageReport(greports.userUsageReports.Get(userKey, date, properties));
            }
        }
        #endregion
        #endregion
    }

    /// <summary>
    /// A powershell friendly representation of the UsageReport class.
    /// </summary>
    public class gUsageReport
    {
        public string Kind;
        public Dictionary<string, List<Data.UsageReport.ParametersData>> properties =
            new Dictionary<string, List<Data.UsageReport.ParametersData>>();
        public List<Data.UsageReports.WarningsData> Warnings = new List<Data.UsageReports.WarningsData>();

        public gUsageReport(Data.UsageReports reports)
        {
            Kind = reports.Kind;

            if (reports.Warnings != null && reports.Warnings.Count != 0)
            {
                Warnings.AddRange(reports.Warnings);
            }

            foreach (Data.UsageReport.ParametersData result in reports.UsageReportsValue[0].Parameters)
            {
                //sites:num_sites, for example
                string[] names = result.Name.Split(':');
                if (!properties.ContainsKey(names[0])) {
                    properties[names[0]] = new List<Data.UsageReport.ParametersData>();
                }

                properties[names[0]].Add(result);
            }
        }

        public List<Data.UsageReport.ParametersData> this[string key]
        {
            get
            {
                return properties[key];
            }
            set
            {
                properties[key] = value;
            }
        }
    }
}
