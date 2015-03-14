using System;
using System.Xml;
using System.Collections.Generic;
using System.Management.Automation;
using Data = Google.Apis.Admin.Reports.reports_v1.Data;

namespace gShell.Cmdlets.Reports.GRepActivity
{
    [Cmdlet(VerbsCommon.Get, "GRepActivity",
          DefaultParameterSetName = "datetime",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GRepActivity")]
    public class GetGRepActivity : ReportsBase
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public gShell.dotNet.Reports.Activities.ApplicationName ApplicationName { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserKey { get; set; }

        [Parameter(
            Mandatory = false)]
        public string CustomerId { get; set; }

        [Parameter(
            Mandatory = false)]
        public string ActorIpAddress { get; set; }

        [Parameter(
            ParameterSetName = "string",
            Mandatory = false)]
        public string StartTime { get; set; }

        [Parameter(
            ParameterSetName = "string",
            Mandatory = false)]
        public string EndTime { get; set; }

        [Parameter(
            ParameterSetName = "datetime",
            Mandatory = false)]
        public DateTime? StartDateTime { get; set; }

        [Parameter(
            ParameterSetName = "datetime",
            Mandatory = false)]
        public DateTime? EndDateTime { get; set; }

        [Parameter(
            Mandatory = false)]
        public string EventName { get; set; }

        [Parameter(
            Mandatory = false)]
        public string Filters { get; set; }

        [Parameter(Position = 5,
            Mandatory = false)]
        public int MaxResults { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Report Activity", "Get-GRepActivity"))
            {
                string _dateStartString = string.Empty;
                string _dateEndString = string.Empty;

                switch (ParameterSetName)
                {
                    case "datestring":
                        _dateStartString = StartTime;
                        _dateEndString = EndTime;
                        break;

                    case "datetime":
                        if (StartDateTime.HasValue)
                        {
                            _dateStartString = XmlConvert.ToString(StartDateTime.Value, XmlDateTimeSerializationMode.Local);
                        }
                        else
                        {
                            _dateStartString = null;
                        }

                        if (EndDateTime.HasValue)
                        {
                            _dateEndString = XmlConvert.ToString(EndDateTime.Value, XmlDateTimeSerializationMode.Local);
                        }
                        else
                        {
                            _dateEndString = null;
                        }
                        break;
                }

                var properties = new gShell.dotNet.Reports.Activities.ActivitiesListProperties()
                {
                    startTime = _dateStartString,
                    endTime = _dateEndString,
                    customerId = CustomerId,
                    actorIpAddress = ActorIpAddress,
                    eventName = EventName,
                    filters = Filters
                };

                if (0 != MaxResults) {
                    properties.totalResults = MaxResults;
                }

                //Allow for the use of 'all'
                string _userKey = (UserKey == "all") ? "all" : GetFullEmailAddress(UserKey, Domain);

                WriteObject(activities.List(ApplicationName, _userKey, properties));
            }
        }
    }
}
