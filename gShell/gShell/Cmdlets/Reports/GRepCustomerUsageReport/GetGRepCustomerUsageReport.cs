using System;
using System.Collections.Generic;
using System.Management.Automation;
using Data = Google.Apis.admin.Reports.reports_v1.Data;

namespace gShell.Cmdlets.Reports.GRepCustomerUsageReport
{
    [Cmdlet(VerbsCommon.Get, "GRepCustomerUsageReport",
          DefaultParameterSetName = "datetime",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GRepCustomerUsageReport")]
    public class GetGRepCustomerUsageReport : ReportsBase
    {
        #region Properties

        [Parameter(Position = 0,
            ParameterSetName="datestring",
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DateString { get; set; }

        [Parameter(Position = 0,
            ParameterSetName = "datetime",
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public DateTime Date { get; set; }

        [Parameter(Position = 1,
            Mandatory = false)]
        public string CustomerId { get; set; }

        [Parameter(Position = 2,
            Mandatory = false)]
        public string Parameters { get; set; }

        [Parameter(Position = 3,
            Mandatory = false)]
        public int MaxResults { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Customer Usage Report", "Get-GRepCustomerUsageReport"))
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
                    dotNet.Reports.CustomerUsageReports.CustomerUsageReportsGetProperties()
                    {
                        customerId = CustomerId,
                        parameters = Parameters
                    };
                
                if (MaxResults != 0)
                {
                    properties.totalResults = MaxResults;
                }

                WriteObject(customerUsageReports.Get(_datestring, properties));
            }
        }
    }
}
