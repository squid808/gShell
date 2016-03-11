using System;
using System.Collections.Generic;
using System.Management.Automation;
using Data = Google.Apis.admin.Reports.reports_v1.Data;

namespace gShell.Cmdlets.Reports.GRepUserUsageReport
{
    [Cmdlet(VerbsCommon.Get, "GRepUserUsageReport",
          DefaultParameterSetName = "datetime",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GRepUserUsageReport")]
    public class GetGRepUserUsageReport : ReportsBase
    {
        #region Properties

        [Parameter(Position = 0,
            ParameterSetName="datestring",
            Mandatory = true)]
        public string DateString { get; set; }

        [Parameter(Position = 0,
            ParameterSetName = "datetime",
            Mandatory = true)]
        public DateTime Date { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        public string UserKey { get; set; }

        [Parameter(Position = 2,
            Mandatory = false)]
        public string CustomerId { get; set; }

        [Parameter(Position = 3,
            Mandatory = false)]
        public string Filters { get; set; }

        [Parameter(Position = 4,
            Mandatory = false)]
        public string Parameters { get; set; }

        [Parameter(Position = 5,
            Mandatory = false)]
        public int MaxResults { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("User Usage Report", "Get-GRepUserUsageReport"))
            {
                string _datestring = string.Empty;

                switch (ParameterSetName)
                {
                    case "datestring":
                        _datestring = DateString;
                        break;

                    case "datetime":
                        _datestring = Date.ToString("yyyy-MM-dd");
                        break;
                }

                var properties = new
                    dotNet.Reports.UserUsageReport.UserUsageReportGetProperties()
                    {
                        customerId = CustomerId,
                        filters = Filters,
                        parameters = Parameters
                    };
                
                if (MaxResults != 0)
                {
                    properties.totalResults = MaxResults;
                }

                //Allow for the use of 'all'
                string _userKey = (UserKey == "all") ? "all" : GetFullEmailAddress(UserKey, Domain);

                WriteObject(userUsageReport.Get(_userKey, _datestring, properties));
            }
        }
    }
}
