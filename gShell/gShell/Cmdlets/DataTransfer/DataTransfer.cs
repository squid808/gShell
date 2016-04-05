using System;
using System.Management.Automation;
using System.Collections.Generic;
using System.Linq;

using Google.Apis.Auth.OAuth2;
using Data = Google.Apis.admin.DataTransfer.datatransfer_v1.Data;

using gDataTransfer = gShell.dotNet.DataTransfer;
using gShell.Cmdlets.DataTransfer;

namespace gShell.Cmdlets.DataTransfer.Applications
{
    [Cmdlet(VerbsCommon.Get, "DataTransferApplication",
        SupportsShouldProcess = true,
          HelpUri = @"",
          DefaultParameterSetName = "one")]
    public class GetGDataTransferApplication : DataTransferBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName="one")]
        [ValidateNotNullOrEmpty]
        public long ApplicationId { get; set; }

        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName = "all")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter All { get; set; }

        [Parameter(Position = 2,
            Mandatory = false,
            ParameterSetName = "all")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        [Parameter(Position = 3,
            Mandatory = false,
            ParameterSetName = "all")]
        [ValidateNotNullOrEmpty]
        public int? MaxResults { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ParameterSetName == "one") {
                if (ShouldProcess("DataTransfer Applicaiton", "Get-GDataTransferApplication"))
                {
                    WriteObject(mainBase.applications.Get(ApplicationId));
                }
            } else {
                var properties = new gDataTransfer.Applications.ApplicationsListProperties(){
                    maxResults = 500
                };

                if (!string.IsNullOrWhiteSpace(CustomerId)) { properties.customerId = this.CustomerId; }
                if (MaxResults.HasValue) { properties.totalResults = MaxResults.Value; }

                if (ShouldProcess("DataTransfer Applicaiton", "Get-GDataTransferApplication"))
                {
                    List<Data.Application> results = mainBase.applications.List(properties).SelectMany(x => x.Applications).ToList();

                    WriteObject(results);
                }
            }
        }
    }
}

namespace gShell.Cmdlets.DataTransfer
{
    enum ApplicationTransferStatusEnum
    {
        completed, failed, inProgress, pending
    }

    //User ID must be numeric - http://stackoverflow.com/questions/35589475/using-the-insert-method-of-the-google-data-transfer-api-to-start-a-transfer
    [Cmdlet(VerbsCommon.Get, "DataTransfer",
        SupportsShouldProcess = true,
          HelpUri = @"",
          DefaultParameterSetName = "one")]
    public class GetGDataTransfer : DataTransferBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName = "one")]
        [ValidateNotNullOrEmpty]
        public string DataTransferId { get; set; }

        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName = "all")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter All { get; set; }

        [Parameter(Position = 2,
            Mandatory = false,
            ParameterSetName = "all")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        [Parameter(Position = 3,
            Mandatory = false,
            ParameterSetName = "all")]
        [ValidateNotNullOrEmpty]
        public string NewOwnerUserId { get; set; }

        [Parameter(Position = 4,
            Mandatory = false,
            ParameterSetName = "all")]
        [ValidateNotNullOrEmpty]
        public string OldOwnerUserId { get; set; }

        [Parameter(Position = 5,
            Mandatory = false,
            ParameterSetName = "all")]
        [ValidateNotNullOrEmpty]
        public string Status { get; set; }

        [Parameter(Position = 6,
            Mandatory = false,
            ParameterSetName = "all")]
        [ValidateNotNullOrEmpty]
        public int? MaxResults { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ParameterSetName == "one")
            {
                if (ShouldProcess("DataTransfer", "Get-GDataTransfer"))
                {
                    WriteObject(mainBase.transfers.Get(DataTransferId));
                }
            }
            else
            {
                var properties = new gDataTransfer.Transfers.TransfersListProperties
                {
                    maxResults = 500
                };

                if (!string.IsNullOrWhiteSpace(CustomerId)) { properties.customerId = this.CustomerId; }
                if (!string.IsNullOrWhiteSpace(NewOwnerUserId)) { properties.newOwnerUserId = this.NewOwnerUserId; }
                if (!string.IsNullOrWhiteSpace(OldOwnerUserId)) { properties.oldOwnerUserId= this.OldOwnerUserId; }
                if (!string.IsNullOrWhiteSpace(Status)) { properties.status = this.Status; }
                if (MaxResults.HasValue) { properties.totalResults = MaxResults.Value; }

                if (ShouldProcess("Email Settings Forwarding", "Set-GEmailSettingsForwarding"))
                {
                    List<Data.DataTransfer> results = mainBase.transfers.List(properties).SelectMany(x => x.DataTransfers).ToList();

                    WriteObject(results);
                }
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "DataTransferParamsObject",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGDataTransferParamsObject : PSCmdlet
    {
        [Parameter(Position = 0,
           Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        [Parameter(Position = 0,
           Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ICollection<string> Value { get; set; }

        protected override void ProcessRecord()
        {
            var app = new Data.ApplicationTransferParam()
            {
                Key = this.Key,
                Value = this.Value.ToList()
            };

            if (ShouldProcess("DataTransfer Params Object", "New-GDataTransferParamsObject"))
            {
                WriteObject(app);
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "DataTransferApplicationObject",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGDataTransferApplicationObject : PSCmdlet
    {
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public long ApplicationId { get; set; }

        [Parameter(Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public ICollection<Data.ApplicationTransferParam> TransferParams { get; set; }

        [Parameter(Position = 0,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public ApplicationTransferStatusEnum? ApplicationTransferStatus { get; set; }

        protected override void ProcessRecord()
        {
            var ohMyGodImTired = new Data.ApplicationDataTransfer()
            {
                ApplicationId = this.ApplicationId
            };

            if (TransferParams != null) { ohMyGodImTired.ApplicationTransferParams = this.TransferParams.ToList(); }
            if (ApplicationTransferStatus != null) { ohMyGodImTired.ApplicationTransferStatus 
                = this.ApplicationTransferStatus.Value.ToString(); }

            if (ShouldProcess("DataTransfer Application Object", "New-GDataTransferApplicaitonObject"))
            {
                WriteObject(ohMyGodImTired);
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "DataTransfer",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGDataTransfer : DataTransferBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string NewOwnerUserId { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string OldOwnerUserId { get; set; }

        [Parameter(Position = 3,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public ICollection<Data.ApplicationDataTransfer> Applications { get; set; }

        [Parameter(Position = 4,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public DateTime? RequestTime { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.DataTransfer()
            {
                Kind = "admin#datatransfer#DataTransfer",
                NewOwnerUserId = this.NewOwnerUserId,
                OldOwnerUserId = this.OldOwnerUserId
            };

            if (this.Applications != null) { body.ApplicationDataTransfers = this.Applications.ToList(); }
            if (this.RequestTime.HasValue) { body.RequestTime = this.RequestTime.Value; }

            if (ShouldProcess("DataTransfer", "New-GDataTransfer"))
            {
                WriteObject(mainBase.transfers.Insert(body));
            }
        }
    }
}