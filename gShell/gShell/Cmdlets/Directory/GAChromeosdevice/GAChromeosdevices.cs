//using System.Management.Automation;
//using Data = Google.Apis.admin.Directory.directory_v1.Data;

//namespace gShell.Cmdlets.Directory.GAChromeosdevice
//{
//    [Cmdlet(VerbsCommon.Get, "GAChromeosdevice",
//          DefaultParameterSetName = "One",
//          SupportsShouldProcess = true,
//          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAChromeosdevice")]
//    public class GetGAChromeosdevice : DirectoryBase
//    {
//        #region Properties

//        [Parameter(Position = 0,
//            Mandatory = false, //can use 'my_customer'
//            ValueFromPipelineByPropertyName = true)]
//        [ValidateNotNullOrEmpty]
//        public string CustomerId { get; set; }

//        //Domain position = 1

//        [Parameter(Position = 2,
//            Mandatory = true,
//            ParameterSetName = "One",
//            ValueFromPipelineByPropertyName = true)]
//        [ValidateNotNullOrEmpty]
//        public string DeviceId  { get; set; }

//        [Parameter(Position = 3,
//            ParameterSetName = "List")]
//        public SwitchParameter All { get; set; }

//        [Parameter(Position = 4,
//            ParameterSetName = "List")]
//        public int MaxResults { get; set; }

//        #endregion

//        protected override void ProcessRecord()
//        {
//            CustomerId = string.IsNullOrWhiteSpace(CustomerId) ? "my_customer" : CustomerId;

//            if (ShouldProcess(CustomerId, "Get-GAChromeosdevice"))
//            {
//                switch (ParameterSetName)
//                {
//                    case "One":
//                        WriteObject(chromeosdevices.Get(CustomerId, DeviceId));
//                        break;
//                    case "List":
//                        WriteObject(chromeosdevices.List(CustomerId, new dotNet.Directory.Chromeosdevices.ChromeosdevicesListProperties(){
//                            TotalResults = MaxResults
//                        }));
//                        break;
//                }
//            }
//        }
//    }

//    [Cmdlet(VerbsCommon.Set, "GAChromeosdevice",
//          SupportsShouldProcess = true,
//          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAChromeosdevice")]
//    public class SetGAChromeosdevice : DirectoryBase
//    {
//        #region Properties
//        [Parameter(Position = 0,
//            Mandatory = false, //can use 'my_customer'
//            ValueFromPipelineByPropertyName = true)]
//        [ValidateNotNullOrEmpty]
//        public string CustomerId { get; set; }

//        //Domain position = 1

//        [Parameter(Position = 2,
//            Mandatory = true,
//            ValueFromPipelineByPropertyName = true)]
//        [ValidateNotNullOrEmpty]
//        public string DeviceId { get; set; }

//        [Parameter(Position = 3,
//            Mandatory = false,
//            ValueFromPipelineByPropertyName = true)]
//        [ValidateNotNullOrEmpty]
//        public string AnnotatedLocation { get; set; }

//        [Parameter(Position = 4,
//            Mandatory = false,
//            ValueFromPipelineByPropertyName = true)]
//        [ValidateNotNullOrEmpty]
//        public string AnnotatedUser { get; set; }

//        [Parameter(Position = 5,
//            Mandatory = false,
//            ValueFromPipelineByPropertyName = true)]
//        [ValidateNotNullOrEmpty]
//        public string Notes { get; set; }

//        [Parameter(Position = 6,
//            Mandatory = false,
//            ValueFromPipelineByPropertyName = true)]
//        [ValidateNotNullOrEmpty]
//        public string OrgUnitPath { get; set; }
//        #endregion

//        protected override void ProcessRecord()
//        {
//            CustomerId = string.IsNullOrWhiteSpace(CustomerId) ? "my_customer" : CustomerId;

//            if (ShouldProcess(CustomerId, "Set-GAChromeosdevice"))
//            {
//                Data.ChromeOsDevice body = new Data.ChromeOsDevice();

//                body.AnnotatedLocation = (!string.IsNullOrWhiteSpace(AnnotatedLocation)) ? AnnotatedLocation : null;
//                body.AnnotatedUser = (!string.IsNullOrWhiteSpace(AnnotatedUser)) ? AnnotatedUser : null;
//                body.Notes = (!string.IsNullOrWhiteSpace(Notes)) ? Notes : null;
//                body.OrgUnitPath = (!string.IsNullOrWhiteSpace(OrgUnitPath)) ? OrgUnitPath : null;

//                chromeosdevices.Patch(body, CustomerId, DeviceId);
//            }
//        }
//    }
//}
