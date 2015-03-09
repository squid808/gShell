//using System;
//using System.Management.Automation;
//using System.Collections.Generic;
//using gShell.dotNet.Utilities.OAuth2;
////using Google.Apis.Services;
//using Google.Apis.Admin.Reports.reports_v1;
//using Google.Apis.Admin.Reports.reports_v1.Data;

//using gShell.dotNet;

//namespace gShell.Cmdlets.Reports
//{
//    public abstract class ReportsBase : OAuth2CmdletBase
//    {
//        [Parameter(Position = 1,
//            Mandatory = false,
//            ValueFromPipelineByPropertyName = true,
//            HelpMessage = "The name of the Google Apps domain, ex contoso.com. If none is provided the gShell default domain will be used.")]
//        [ValidateNotNullOrEmpty]
//        public string Domain { get; set; }

//        protected override void BeginProcessing()
//        {
//            Domain = Authenticate(Domain);
//        }

//        protected override string BuildService(string givenDomain)
//        {
//            if (string.IsNullOrWhiteSpace(givenDomain) ||
//                !directoryServiceDict.ContainsKey(givenDomain))
//            {
//                DirectoryService service = BuildDirectoryService(givenDomain);

//                if (OAuth2Base.currentDomain == "gmail.com")
//                {
//                    ThrowTerminatingError(new ErrorRecord(new Exception("This cmdlet is not available for a gmail account."),
//                        "", ErrorCategory.InvalidData, OAuth2Base.currentDomain));
//                }

//                //current domain should be set at this point 
//                directoryServiceDict.Add(OAuth2Base.currentDomain, service);

//                return OAuth2Base.currentDomain;
//            }
//            else
//            {
//                return givenDomain;
//            }
//        }

//        /// <summary>
//        /// Create a directory service for the provided domain.
//        /// </summary>
//        protected DirectoryService BuildDirectoryService(string givenDomain)
//        {
//            return new DirectoryService(OAuth2Base.GetInitializer(givenDomain));
//        }
//    }
//}
