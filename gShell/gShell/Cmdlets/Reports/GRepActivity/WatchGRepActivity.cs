//using System.Collections.Generic;
//using System.Management.Automation;
//using Data = Google.Apis.admin.Reports.reports_v1.Data;

//namespace gShell.Cmdlets.Reports.GRepActivity
//{
//    [Cmdlet(VerbsCommon.Watch, "GRepActivity",
//          SupportsShouldProcess = true,
//          HelpUri = @"https://github.com/squid808/gShell/wiki/Watch-GRepActivity")]
//    public class WatchGRepActivity : ReportsBase
//    {
//        #region Properties

//        [Parameter(Position = 0,
//            Mandatory = true)]
//        [ValidateNotNullOrEmpty]
//        public ApplicationNameEnum ApplicationName { get; set; }

//        [Parameter(Position = 1,
//            Mandatory = true)]
//        [ValidateNotNullOrEmpty]
//        public string UserKey { get; set; }

//        [Parameter(
//            Mandatory = false)]
//        public string EventName { get; set; }

//        [Parameter(
//            Mandatory = false)]
//        public string Filters { get; set; }

//        [Parameter(
//            Mandatory = false)]
//        public string Id { get; set; }

//        [Parameter(
//            Mandatory = false)]
//        public string Token { get; set; }

//        [Parameter(
//            Mandatory = false)]
//        public long? Expiration { get; set; }

//        [Parameter(
//            Mandatory = false)]
//        public string Type { get; set; }

//        [Parameter(
//            Mandatory = false)]
//        public string Address { get; set; }

//        [Parameter(
//            Mandatory = false)]
//        public bool? Payload { get; set; }

//        [Parameter(
//            Mandatory = false)]
//        public string Ttl { get; set; }
//        #endregion

//        protected override void ProcessRecord()
//        {
//            if (ShouldProcess("User Usage Report", "Get-GAUser"))
//            {
//                var body = new Data.Channel()
//                {
//                    Id = Id,
//                    Token = Token,
//                    Type = Type,
//                    Address = Address
//                };

//                if (Expiration.HasValue)
//                {
//                    body.Expiration = Expiration.Value;
//                }

//                if (Payload.HasValue)
//                {
//                    body.Payload = Payload.Value;
//                }

//                if (!string.IsNullOrWhiteSpace(Ttl))
//                {
//                    body.Params__ = new Dictionary<string, string>();
//                    body.Params__["ttl"] = Ttl;
//                }
//                WriteObject(activities.Watch(body, GetFullEmailAddress(UserKey, Domain), ApplicationName.ToString()));
//            }
//        }
//    }
//}
