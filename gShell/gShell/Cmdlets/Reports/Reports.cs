using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Xml;
using Data = Google.Apis.admin.Reports.reports_v1.Data;

namespace gShell.Cmdlets.Reports
{
    public enum ApplicationNameEnum
    {
        admin, calendar, drive, groups, login, token
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Reports API Channel object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a Channel object which may be required as a parameter for some other Cmdlets in the Reports API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.admin.Reports.reports_v1.Data.Channel</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reports API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GRepChannelObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GRepChannelObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GReportsChannelObj",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GRepChannelObj")]
    [OutputType(typeof(Google.Apis.admin.Reports.reports_v1.Data.Channel))]
    public class NewGReportsChannelObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">The address where notifications are delivered for this channel.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The address where notifications are delivered for this channel.")]
        public string Address { get; set; }

        /// <summary>
        /// <para type="description">Date and time of notification channel expiration, expressed as a Unix timestamp, in milliseconds. Optional.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Date and time of notification channel expiration, expressed as a Unix timestamp, in milliseconds. Optional.")]
        public System.Nullable<long> Expiration { get; set; }

        /// <summary>
        /// <para type="description">A UUID or similar unique string that identifies this channel.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "A UUID or similar unique string that identifies this channel.")]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">Additional parameters controlling delivery channel behavior. Optional.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Additional parameters controlling delivery channel behavior. Optional.")]
        public System.Collections.Generic.IDictionary<string, string> Params__ { get; set; }

        /// <summary>
        /// <para type="description">A Boolean value to indicate whether payload is wanted. Optional.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "A Boolean value to indicate whether payload is wanted. Optional.")]
        public System.Nullable<bool> Payload { get; set; }

        /// <summary>
        /// <para type="description">An opaque ID that identifies the resource being watched on this channel. Stable across different API versions.</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "An opaque ID that identifies the resource being watched on this channel. Stable across different API versions.")]
        public string ResourceId { get; set; }

        /// <summary>
        /// <para type="description">A version-specific identifier for the watched resource.</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "A version-specific identifier for the watched resource.")]
        public string ResourceUri { get; set; }

        /// <summary>
        /// <para type="description">An arbitrary string delivered to the target address with each notification delivered over this channel. Optional.</para>
        /// </summary>
        [Parameter(Position = 7,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "An arbitrary string delivered to the target address with each notification delivered over this channel. Optional.")]
        public string Token { get; set; }

        /// <summary>
        /// <para type="description">The type of delivery mechanism used for this channel.</para>
        /// </summary>
        [Parameter(Position = 8,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The type of delivery mechanism used for this channel.")]
        public string Type { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.admin.Reports.reports_v1.Data.Channel()
            {
                Address = this.Address,
                Expiration = this.Expiration,
                Id = this.Id,
                Params__ = this.Params__,
                Payload = this.Payload,
                ResourceId = this.ResourceId,
                ResourceUri = this.ResourceUri,
                Token = this.Token,
                Type = this.Type,
            };

            if (ShouldProcess("Channel"))
            {
                WriteObject(body);
            }
        }
    }   
}

namespace gShell.Cmdlets.Reports.GRepUserUsageReport
{
    /// <summary>
    /// <para type="synopsis">Retrieves a report which is a collection of properties / statistics for a set of users.</para>
    /// <para type="description">Retrieves a report which is a collection of properties / statistics for a set of users.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reports API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Get-GRepUserUsageReport -UserKey $SomeUserKeyString -Date $SomeDateString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GRepUserUsageReport">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GRepUserUsageReport",
          DefaultParameterSetName = "datetime",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GRepUserUsageReport")]
    public class GetGRepUserUsageReportCommand : ReportsBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Represents the date in yyyy-mm-dd format for which the data is to be fetched.</para>
        /// </summary>
        [Parameter(Position = 0,
            HelpMessage = "Represents the date in yyyy-mm-dd format for which the data is to be fetched.",
            ParameterSetName = "datestring",
            Mandatory = true)]
        public string DateString { get; set; }

        /// <summary>
        /// <para type="description">A DateTime object for which the data is to be fetched.</para>
        /// </summary>
        [Parameter(Position = 0,
            HelpMessage = "A DateTime object for which the data is to be fetched.",
            ParameterSetName = "datetime",
            Mandatory = true)]
        public DateTime Date { get; set; }

        /// <summary>
        /// <para type="description">Represents the profile id or the user email for which the data should be filtered.</para>
        /// </summary>
        [Parameter(Position = 1,
            HelpMessage = "Represents the profile id or the user email for which the data should be filtered.",
            Mandatory = true)]
        public string UserKey { get; set; }

        /// <summary>
        /// <para type="description">Represents the customer for which the data is to be fetched.</para>
        /// </summary>
        [Parameter(Position = 2,
            HelpMessage = "Represents the customer for which the data is to be fetched.",
            Mandatory = false)]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Represents the set of filters including parameter operator value.</para>
        /// </summary>
        [Parameter(Position = 3,
            HelpMessage = "Represents the set of filters including parameter operator value.",
            Mandatory = false)]
        public string Filters { get; set; }

        /// <summary>
        /// <para type="description">Represents the application name, parameter name pairs to fetch in csv as app_name1:param_name1, app_name2:param_name2.</para>
        /// </summary>
        [Parameter(Position = 4,
            HelpMessage = "Represents the application name, parameter name pairs to fetch in csv as app_name1:param_name1, app_name2:param_name2.",
            Mandatory = false)]
        public string Parameters { get; set; }

        /// <summary>
        /// <para type="description">Maximum number of results to return. Maximum allowed is 1000</para>
        /// </summary>
        [Parameter(Position = 5,
            HelpMessage = "Maximum number of results to return. Maximum allowed is 1000",
            Mandatory = false)]
        public int? MaxResults { get; set; }

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
                    CustomerId = CustomerId,
                    Filters = Filters,
                    Parameters = Parameters
                };

                if (MaxResults.HasValue) properties.TotalResults = MaxResults.Value;

                //Allow for the use of 'all'
                string _userKey = (UserKey == "all") ? "all" : GetFullEmailAddress(UserKey, GAuthId);

                WriteObject(userUsageReport.Get(_userKey, _datestring, properties, StandardQueryParams: StandardQueryParams));
            }
        }
    }
}

namespace gShell.Cmdlets.Reports.GRepCustomerUsageReport
{
    /// <summary>
    /// <para type="synopsis">Retrieves a report which is a collection of properties / statistics for a specific customer.</para>
    /// <para type="description">Retrieves a report which is a collection of properties / statistics for a specific customer.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reports API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Get-GRepCustomerUsageReport -Date $SomeDateString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GRepCustomerUsageReport">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GRepCustomerUsageReport",
          DefaultParameterSetName = "datetime",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GRepCustomerUsageReport")]
    public class GetGRepCustomerUsageReportCommand : ReportsBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Represents the date in yyyy-mm-dd format for which the data is to be fetched.</para>
        /// </summary>
        [Parameter(Position = 0,
            ParameterSetName = "datestring",
            Mandatory = true,
            HelpMessage = "Represents the date in yyyy-mm-dd format for which the data is to be fetched.")]
        [ValidateNotNullOrEmpty]
        public string DateString { get; set; }

        /// <summary>
        /// <para type="description">DateTime object for which the data is to be fetched.</para>
        /// </summary>
        [Parameter(Position = 0,
            ParameterSetName = "datetime",
            Mandatory = true,
            HelpMessage = "Represents the date in yyyy-mm-dd format for which the data is to be fetched.")]
        [ValidateNotNullOrEmpty]
        public DateTime Date { get; set; }

        /// <summary>
        /// <para type="description">Represents the customer for which the data is to be fetched.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Represents the customer for which the data is to be fetched.")]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Represents the application name, parameter name pairs to fetch in csv as app_name1:param_name1, app_name2:param_name2.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Represents the application name, parameter name pairs to fetch in csv as app_name1:param_name1, app_name2:param_name2.")]
        public string Parameters { get; set; }

        /// <summary>
        /// <para type="description">Maximum number of results to return. Maximum allowed is 1000</para>
        /// </summary>
        [Parameter(Position = 3,
            HelpMessage = "Maximum number of results to return. Maximum allowed is 1000",
            Mandatory = false)]
        public int? MaxResults { get; set; }

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
                    CustomerId = CustomerId,
                    Parameters = Parameters
                };

                if (MaxResults.HasValue) properties.TotalResults = MaxResults.Value;

                WriteObject(customerUsageReports.Get(_datestring, properties, StandardQueryParams: StandardQueryParams));
            }
        }
    }
}

namespace gShell.Cmdlets.Reports.GRepChannel
{
    /// <summary>
    /// <para type="synopsis">Stop watching resources through this channel</para>
    /// <para type="description">Stop watching resources through this channel</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reports API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Stop-GRepChannel -ChannelBody $SomeChannelObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Stop-GRepChannel">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "GRepChannel",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Stop-GRepChannel")]
    public class StopGRepChannelCommand : ReportsBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">A UUID or similar unique string that identifies this channel.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "A UUID or similar unique string that identifies this channel.")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">An opaque ID that identifies the resource being watched on this channel. Stable across different API versions.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "An opaque ID that identifies the resource being watched on this channel. Stable across different API versions.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Report Channel", "Stop-GRepChannel"))
            {
                if (Force || ShouldContinue((String.Format("Resource with Id {0} will be stopped on channel with Id {1}\nContinue?",
                    ResourceId, Id)), "Confirm Channel Stop"))
                {
                    try
                    {
                        WriteDebug("Attempting to stop Channel Resource...");
                        channels.Stop(new Data.Channel()
                        {
                            Id = Id,
                            ResourceId = ResourceId
                        }, StandardQueryParams: StandardQueryParams);
                        WriteVerbose("Channel Resource stopped without error.");
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, "Stop-GRepChannel"));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Stopping of Channel Resource failed"),
                        "", ErrorCategory.InvalidData, "Stop-GRepChannel"));
                }
            }
        }
    }
}

namespace gShell.Cmdlets.Reports.GRepActivity
{
    /// <summary>
    /// <para type="synopsis">Push changes to activities</para>
    /// <para type="description">Push changes to activities</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reports API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Watch-GRepActivity -UserKey $SomeUserKeyString -ApplicationName $SomeApplicationNameString -ChannelBody $SomeChannelObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Watch-GRepActivity">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Watch, "GRepActivity",
        DefaultParameterSetName = "Params",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Watch-GRepActivity")]
    public class WatchGRepActivityCommand : ReportsBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Application name for which the events are to be retrieved.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        HelpMessage = "Application name for which the events are to be retrieved.")]
        [ValidateNotNullOrEmpty]
        public ApplicationNameEnum ApplicationName { get; set; }

        /// <summary>
        /// <para type="description">Represents the profile id or the user email for which the data should be filtered. When 'all' is specified as the userKey, it returns usageReports for all users.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        HelpMessage = "Represents the profile id or the user email for which the data should be filtered. When 'all' is specified as the userKey, it returns usageReports for all users.")]
        [ValidateNotNullOrEmpty]
        public string UserKey { get; set; }

        /// <summary>
        /// <para type="description">Name of the event being queried.</para>
        /// </summary>
        [Parameter(Position = 2,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of the event being queried.")]
        public string EventName { get; set; }

        /// <summary>
        /// <para type="description">Event parameters in the form [parameter1 name][operator][parameter1 value],[parameter2 name][operator][parameter2 value],...</para>
        /// </summary>
        [Parameter(Position = 3,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Event parameters in the form [parameter1 name][operator][parameter1 value],[parameter2 name][operator][parameter2 value],...")]
        public string Filters { get; set; }

        /// <summary>
        /// <para type="description">A UUID or similar unique string that identifies this channel.</para>
        /// </summary>
        [Parameter(Position = 4,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "A UUID or similar unique string that identifies this channel.")]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">An arbitrary string delivered to the target address with each notification delivered over this channel. Optional.</para>
        /// </summary>
        [Parameter(Position = 5,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "An arbitrary string delivered to the target address with each notification delivered over this channel. Optional.")]
        public string Token { get; set; }

        /// <summary>
        /// <para type="description">Date and time of notification channel expiration, expressed as a Unix timestamp, in milliseconds. Optional.</para>
        /// </summary>
        [Parameter(Position = 6,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Date and time of notification channel expiration, expressed as a Unix timestamp, in milliseconds. Optional.")]
        public System.Nullable<long> Expiration { get; set; }

        /// <summary>
        /// <para type="description">The type of delivery mechanism used for this channel.</para>
        /// </summary>
        [Parameter(Position = 7,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The type of delivery mechanism used for this channel.")]
        public string Type { get; set; }

        /// <summary>
        /// <para type="description">The address where notifications are delivered for this channel.</para>
        /// </summary>
        [Parameter(Position = 8,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The address where notifications are delivered for this channel.")]
        public string Address { get; set; }

        /// <summary>
        /// <para type="description">A Boolean value to indicate whether payload is wanted. Optional.</para>
        /// </summary>
        [Parameter(Position = 9,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "A Boolean value to indicate whether payload is wanted. Optional.")]
        public System.Nullable<bool> Payload { get; set; }

        /// <summary>
        /// <para type="description">Specifies the time-to-live in seconds for the notification channel. The default is 21,600 seconds.</para>
        /// </summary>
        [Parameter(Position=10,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Specifies the time-to-live in seconds for the notification channel. The default is 21,600 seconds.")]
        public string Ttl { get; set; }

        /// <summary>
        /// <para type="description">An notification channel used to watch for resource changes.</para>
        /// </summary>
        [Parameter(Position = 0,
        ParameterSetName = "Body",
        Mandatory = false,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "An notification channel used to watch for resource changes.")]
        public Data.Channel ChannelBody { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("User Usage Report", "Get-GAUser"))
            {
                if (ParameterSetName == "Params")
                {
                    var body = new Data.Channel()
                    {
                        Id = Id,
                        Token = Token,
                        Type = Type,
                        Address = Address
                    };

                    if (Expiration.HasValue)
                    {
                        body.Expiration = Expiration.Value;
                    }

                    if (Payload.HasValue)
                    {
                        body.Payload = Payload.Value;
                    }

                    if (!string.IsNullOrWhiteSpace(Ttl))
                    {
                        body.Params__ = new Dictionary<string, string>();
                        body.Params__["ttl"] = Ttl;
                    }
                    WriteObject(activities.Watch(body, GetFullEmailAddress(UserKey, GAuthId), ApplicationName.ToString(), StandardQueryParams: StandardQueryParams));
                }
                else
                {
                    WriteObject(activities.Watch(ChannelBody, GetFullEmailAddress(UserKey, GAuthId), ApplicationName.ToString(), StandardQueryParams: StandardQueryParams));
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Retrieves a list of activities for a specific customer and application.</para>
    /// <para type="description">Retrieves a list of activities for a specific customer and application.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reports API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Get-GRepActivity -UserKey $SomeUserKeyString -ApplicationName $SomeApplicationNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GRepActivity">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GRepActivity",
          DefaultParameterSetName = "datetime",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GRepActivity")]
    public class GetGRepActivityCommand : ReportsBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Represents the profile id or the user email for which the data should be filtered. When 'all' is specified as the userKey, it returns usageReports for all users.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Represents the profile id or the user email for which the data should be filtered. When 'all' is specified as the userKey, it returns usageReports for all users.")]
        public string UserKey { get; set; }

        /// <summary>
        /// <para type="description">Application name for which the events are to be retrieved.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Application name for which the events are to be retrieved.")]
        public ApplicationNameEnum ApplicationName { get; set; }

        /// <summary>
        /// <para type="description">IP Address of host where the event was performed. Supports both IPv4 and IPv6 addresses.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "IP Address of host where the event was performed. Supports both IPv4 and IPv6 addresses.")]
        public string ActorIpAddress { get; set; }

        /// <summary>
        /// <para type="description">Represents the customer for which the data is to be fetched.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Represents the customer for which the data is to be fetched.")]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Return events which occured at or after this time.</para>
        /// </summary>
        [Parameter(Position = 4,
        ParameterSetName = "string",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Return events which occured at or after this time.")]
        public string StartTime { get; set; }

        /// <summary>
        /// <para type="description">Return events which occured at or before this time.</para>
        /// </summary>
        [Parameter(Position = 5,
        ParameterSetName = "string",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Return events which occured at or before this time.")]
        public string EndTime { get; set; }

        /// <summary>
        /// <para type="description">Return events which occured at or after this time.</para>
        /// </summary>
        [Parameter(Position = 4,
        ParameterSetName = "datetime",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Return events which occured at or after this time.")]
        public DateTime? StartDateTime { get; set; }

        /// <summary>
        /// <para type="description">Return events which occured at or before this time.</para>
        /// </summary>
        [Parameter(Position = 5,
        ParameterSetName = "datetime",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Return events which occured at or before this time.")]
        public DateTime? EndDateTime { get; set; }

        /// <summary>
        /// <para type="description">Name of the event being queried.</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of the event being queried.")]
        public string EventName { get; set; }

        /// <summary>
        /// <para type="description">Event parameters in the form [parameter1 name][operator][parameter1 value],[parameter2 name][operator][parameter2 value],...</para>
        /// </summary>
        [Parameter(Position = 7,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Event parameters in the form [parameter1 name][operator][parameter1 value],[parameter2 name][operator][parameter2 value],...")]
        public string Filters { get; set; }

        /// <summary>
        /// <para type="description">Number of activity records to be shown in each page.</para>
        /// </summary>
        [Parameter(Position = 8,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Number of activity records to be shown in each page.")]
        public int? MaxResults { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Report Activity", "Get-GRepActivity"))
            {
                string _dateStartString = string.Empty;
                string _dateEndString = string.Empty;

                switch (ParameterSetName)
                {
                    case "string":
                        _dateStartString = StartTime;
                        _dateEndString = EndTime;
                        break;

                    case "datetime":
                        _dateStartString = StartDateTime.HasValue ? 
                            XmlConvert.ToString(StartDateTime.Value, XmlDateTimeSerializationMode.Local) : null;

                        _dateEndString = EndDateTime.HasValue ? 
                            XmlConvert.ToString(EndDateTime.Value, XmlDateTimeSerializationMode.Local) : null;
                        break;
                }

                var properties = new dotNet.Reports.Activities.ActivitiesListProperties()
                {
                    StartTime = _dateStartString,
                    EndTime = _dateEndString,
                    CustomerId = CustomerId,
                    ActorIpAddress = ActorIpAddress,
                    EventName = EventName,
                    Filters = Filters
                };

                if (MaxResults.HasValue)
                    properties.TotalResults = MaxResults.Value;

                //Allow for the use of 'all'
                string _userKey = (UserKey == "all") ? "all" : GetFullEmailAddress(UserKey, GAuthId);

                WriteObject(activities.List(_userKey, ApplicationName.ToString(), properties, StandardQueryParams: StandardQueryParams).SelectMany(x => x.Items).ToList());
            }
        }
    }
}