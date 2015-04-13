using System;
using System.Collections.Generic;
using System.Management.Automation;
using Data = Google.Apis.Admin.Directory.directory_v1.Data; 
using gDirectory = gShell.dotNet.Directory;

namespace gShell.Cmdlets.Directory.GAMobileDevice
{
    [Cmdlet(VerbsCommon.Get, "GAMobiledevice",
          DefaultParameterSetName = "One",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAMobiledevice")]
    public class GetGAMobiledevice : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName = "One",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Position = 3,
            ParameterSetName = "List")]
        public SwitchParameter All { get; set; }

        [Parameter(Position = 4,
            Mandatory = true,
            ParameterSetName = "List")]
        public int MaxResults { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(CustomerId, "Get-GAMobiledevice"))
            {
                switch (ParameterSetName)
                {
                    case "One":
                        WriteObject(mobileDevices.Get(CustomerId, ResourceId));
                        break;
                    case "List":
                        WriteObject(mobileDevices.List(CustomerId, new dotNet.Directory.MobileDevices.MobileDevicesPropertiesList()
                        {
                            totalResults = MaxResults
                        }));
                        break;
                }
            }
        }
    }

    [Cmdlet(VerbsCommon.Remove, "GAMobiledevice",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GAMobiledevice")]
    public class RemoveGAMobiledevice : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Position = 2)]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(CustomerId, "Remove-GAMobiledevice"))
            {
                if (Force || ShouldContinue((String.Format("Mobile Device {0} with ResourceId {2} will be removed from the {1} Google Apps domain.\nContinue?",
                    CustomerId, Domain, ResourceId)), "Confirm Google Apps Mobile Device Removal"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove Mobile Device {0}...",
                            CustomerId));
                        WriteObject(mobileDevices.Delete(CustomerId, ResourceId));
                        WriteVerbose(string.Format("Removal of Mobile Device {0} completed without error.",
                            CustomerId));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, CustomerId));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Mobile Device deletion not confirmed"),
                        "", ErrorCategory.InvalidData, CustomerId));
                }
            }
        }
    }

    [Cmdlet(VerbsLifecycle.Invoke, "GAMobiledevice",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Invoke-GAMobiledevice")]
    public class SetGAMobiledevice : DirectoryBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public gDirectory.MobileDevices.MobileDeviceAction Action { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(CustomerId, "Invoke-GAMobiledevice"))
            {
                WriteObject(mobileDevices.Action(Action, CustomerId, ResourceId));
            }
        }
    }
}
