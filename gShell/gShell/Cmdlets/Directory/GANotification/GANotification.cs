using System;
using System.Collections.Generic;
using System.Management.Automation;
using Data = Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.Cmdlets.Directory.GAMobileDevice
{
    [Cmdlet(VerbsCommon.Get, "GANotification",
          DefaultParameterSetName = "One",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GANotification")]
    public class GetGANotification : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "")]
        [ValidateNotNullOrEmpty]
        public string Customer { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName = "One",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "")]
        [ValidateNotNullOrEmpty]
        public string NotificationId { get; set; }

        [Parameter(Position = 3,
            ParameterSetName = "List",
            HelpMessage = "")]
        public SwitchParameter All { get; set; }

        [Parameter(Position = 4,
            Mandatory = true,
            ParameterSetName = "List",
            HelpMessage = "")]
        public int MaxResults { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(Customer, "Get-GANotification"))
            {
                switch (ParameterSetName)
                {
                    case "One":
                        WriteObject(notifications.Get(Customer, NotificationId));
                        break;
                    case "List":
                        WriteObject(notifications.List(Customer, new dotNet.Directory.Notifications.NotificationsListProperties()
                        {
                            totalResults = MaxResults
                        }));
                        break;
                }
            }
        }
    }

    [Cmdlet(VerbsCommon.Remove, "GANotification",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GANotification")]
    public class RemoveGANotification : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "")]
        [ValidateNotNullOrEmpty]
        public string Customer { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "")]
        [ValidateNotNullOrEmpty]
        public string NotificationId { get; set; }

        [Parameter(Position = 2)]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(Customer, "Remove-GANotification"))
            {
                if (Force || ShouldContinue((String.Format("Notification {0} with NotificationId {2} will be removed from the {1} Google Apps domain.\nContinue?",
                    Customer, Domain, NotificationId)), "Confirm Google Apps Notification Removal"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove Notification {0}...",
                            Customer));
                        WriteObject(notifications.Delete(Customer, NotificationId));
                        WriteVerbose(string.Format("Removal of Notification {0} completed without error.",
                            Customer));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, Customer));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Notification deletion not confirmed"),
                        "", ErrorCategory.InvalidData, Customer));
                }
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GANotification",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GANotification")]
    public class SetGANotification : DirectoryBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "")]
        [ValidateNotNullOrEmpty]
        public string Customer { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "")]
        [ValidateNotNullOrEmpty]
        public string NotificationId { get; set; }

        [Parameter(Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "")]
        [ValidateNotNullOrEmpty]
        public bool IsUnread { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(Customer, "Use-Notification"))
            {
                Data.Notification body = new Data.Notification();

                body.IsUnread = IsUnread;

                WriteObject(notifications.Patch(body, Customer, NotificationId));
            }
        }
    }
}
