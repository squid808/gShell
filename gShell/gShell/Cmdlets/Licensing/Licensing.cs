using System;
using System.Management.Automation;
using System.Collections.Generic;
using System.Linq;

using Google.Apis.Auth.OAuth2;
using Data = Google.Apis.Licensing.v1.Data;

using GLicenseAssignment = gShell.dotNet.Licensing;
using gShell.Cmdlets.Licensing;

namespace gShell.Cmdlets.Licensing
{
    [Cmdlet(VerbsCommon.Get, "GLicenseAssignment",
        SupportsShouldProcess = true,
          HelpUri = @"",
          DefaultParameterSetName = "one")]
    public class GetGLicenseAssignment : LicensingBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName = "one")]
        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName = "product")]
        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName = "sku")]
        [ValidateNotNullOrEmpty]
        public string ProductId { get; set; }

        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName = "one")]
        [Parameter(Position = 3,
            Mandatory = true,
            ParameterSetName = "sku")]
        [ValidateNotNullOrEmpty]
        public string SkuId { get; set; }

        [Parameter(Position = 3,
            Mandatory = true,
            ParameterSetName = "one")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName = "product")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ListForProduct { get; set; }

        [Parameter(Position = 3,
            Mandatory = true,
            ParameterSetName = "product")]
        [Parameter(Position = 4,
            Mandatory = true,
            ParameterSetName = "sku")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName = "sku")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ListForProductAndSku { get; set; }

        [Parameter(Position = 4,
            Mandatory = false,
            ParameterSetName = "product")]
        [Parameter(Position = 5,
            Mandatory = false,
            ParameterSetName = "sku")]
        [ValidateNotNullOrEmpty]
        public int? MaxResults { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Licensing", "Get-GLicenseAssignment"))
            {
                if (ParameterSetName == "one")
                {
                    WriteObject(licenseAssignments.Get(ProductId, SkuId, UserId));
                }
                else if (ParameterSetName == "product")
                {
                    var properties = new GLicenseAssignment.LicenseAssignments.LicenseAssignmentsListForProductProperties()
                    {
                        maxResults = 1000
                    };

                    if (MaxResults.HasValue) { properties.totalResults = this.MaxResults.Value; }

                    WriteObject(licenseAssignments.ListForProduct(ProductId, CustomerId, properties));
                }
                else
                {
                    var properties = new GLicenseAssignment.LicenseAssignments.LicenseAssignmentsListForProductAndSkuProperties()
                    {
                        maxResults = 1000
                    };

                    if (MaxResults.HasValue) { properties.totalResults = this.MaxResults.Value; }

                    WriteObject(licenseAssignments.ListForProductAndSku(ProductId, SkuId, CustomerId, properties));
                }
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GLicenseAssignment",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGLicenseAssignment : LicensingBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ProductId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SkuId { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string NewProductId { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string NewSkuId { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string NewUserId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (!string.IsNullOrWhiteSpace(NewProductId)
                && !string.IsNullOrWhiteSpace(NewSkuId)
                && !string.IsNullOrWhiteSpace(NewUserId))
            {
                WriteError(new ErrorRecord(new Exception(
                    "Must supply at least one parameter for Set-GLicenseAssignment"),
                    "", ErrorCategory.InvalidOperation, "GLicenseAssignment"));
            }

            var body = new Data.LicenseAssignment(){
                ProductId = NewProductId,
                SkuId = NewSkuId,
                UserId = NewUserId
            };

            if (ShouldProcess("Licensing", "Set-GLicenseAssignment"))
            {
                WriteObject(licenseAssignments.Patch(body, ProductId, SkuId, UserId));
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GLicenseAssignment",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGLicenseAssignment : LicensingBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ProductId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SkuId { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.LicenseAssignmentInsert()
            {
                UserId = this.UserId
            };

            if (ShouldProcess("Licensing", "New-GLicenseAssignment"))
            {
                WriteObject(licenseAssignments.Insert(body, ProductId, SkuId));
            }
        }
    }

    [Cmdlet(VerbsCommon.Remove, "GLicenseAssignment",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class RemoveGLicenseAssignment : LicensingBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ProductId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SkuId { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Licensing", "Remove-GLicenseAssignment"))
            {
                licenseAssignments.Delete(ProductId, SkuId, UserId);
            }
        }
    }
}
