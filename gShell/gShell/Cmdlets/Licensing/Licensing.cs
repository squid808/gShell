using System;
using System.Management.Automation;

using Data = Google.Apis.Licensing.v1.Data;

using gLicensing = gShell.dotNet.Licensing;

namespace gShell.Cmdlets.Licensing
{

    /// <summary>
    /// <para type="synopsis">Get license assignment of a particular product and sku for a user</para>
    /// <para type="description">Get license assignment of a particular product and sku for a user</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Licensing API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GLicenseAssignment -ProductId $SomeProductIdString -SkuId $SomeSkuIdString -UserId $SomeUserIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GLicenseAssignment -ListForProduct -ProductId $SomeProductIdString -CustomerId $SomeCustomerIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GLicenseAssignment -ListForProductAndSku -ProductId $SomeProductIdString -SkuId $SomeSkuIdString -CustomerId $SomeCustomerIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GLicenseAssignment">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GLicenseAssignment",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GLicenseAssignment",
          DefaultParameterSetName = "one")]
    public class GetGLicenseAssignmentCommand : LicensingBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Name for product</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name for product",
            ParameterSetName = "one")]
        [Parameter(Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name for product",
            Mandatory = true,
            ParameterSetName = "product")]
        [Parameter(Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name for product",
            Mandatory = true,
            ParameterSetName = "sku")]
        [ValidateNotNullOrEmpty]
        public string ProductId { get; set; }

        /// <summary>
        /// <para type="description">Name for sku</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name for sku",
            ParameterSetName = "one")]
        [Parameter(Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name for sku",
            ParameterSetName = "sku")]
        [ValidateNotNullOrEmpty]
        public string SkuId { get; set; }

        /// <summary>
        /// <para type="description">email id or unique Id of the user</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "email id or unique Id of the user",
            ParameterSetName = "one")]
        [ValidateNotNullOrEmpty]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">List license assignments for given product of the customer.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            HelpMessage = "List license assignments for given product of the customer.",
            ParameterSetName = "product")]
        public SwitchParameter ListForProduct { get; set; }

        /// <summary>
        /// <para type="description">CustomerId represents the customer for whom licenseassignments are queried</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "CustomerId represents the customer for whom licenseassignments are queried",
            ParameterSetName = "product")]
        [Parameter(Position = 4,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "CustomerId represents the customer for whom licenseassignments are queried",
            ParameterSetName = "sku")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">List license assignments for given product and sku of the customer.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            HelpMessage = "List license assignments for given product and sku of the customer.",
            ParameterSetName = "sku")]
        public SwitchParameter ListForProductAndSku { get; set; }

        /// <summary>
        /// <para type="description">Maximum number of campaigns to return at one time. Must be positive. Optional. Default value is 100.</para>
        /// </summary>
        [Parameter(Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Maximum number of campaigns to return at one time. Must be positive. Optional. Default value is 100.",
            ParameterSetName = "product")]
        [Parameter(Position = 5,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Maximum number of campaigns to return at one time. Must be positive. Optional. Default value is 100.",
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
                    var properties = new gLicensing.LicenseAssignments.LicenseAssignmentsListForProductProperties()
                    {
                        MaxResults = 1000
                    };

                    if (MaxResults.HasValue) { properties.TotalResults = this.MaxResults.Value; }

                    WriteObject(licenseAssignments.ListForProduct(ProductId, CustomerId, properties));
                }
                else
                {
                    var properties = new gLicensing.LicenseAssignments.LicenseAssignmentsListForProductAndSkuProperties()
                    {
                        MaxResults = 1000
                    };

                    if (MaxResults.HasValue) { properties.TotalResults = this.MaxResults.Value; }

                    WriteObject(licenseAssignments.ListForProductAndSku(ProductId, SkuId, CustomerId, properties));
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Assign License. This method supports Set semantics.</para>
    /// <para type="description">Assign License. This method supports Set semantics.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Licensing API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GLicenseAssignment -ProductId $SomeProductIdString -SkuId $SomeSkuIdString -UserId $SomeUserIdString -LicenseAssignmentBody $SomeLicenseAssignmentObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GLicenseAssignment">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GLicenseAssignment",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GLicenseAssignment")]
    public class SetGLicenseAssignmentCommand : LicensingBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Name for product</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name for product")]
        public string ProductId { get; set; }

        /// <summary>
        /// <para type="description">Name for sku for which license would be revoked</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name for sku for which license would be revoked")]
        public string SkuId { get; set; }

        /// <summary>
        /// <para type="description">email id or unique Id of the user</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "email id or unique Id of the user")]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">Name for product</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "New name for product")]
        [ValidateNotNullOrEmpty]
        public string NewProductId { get; set; }

        /// <summary>
        /// <para type="description">Name for sku for which license would be revoked</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "New name for sku for which license would be revoked")]
        [ValidateNotNullOrEmpty]
        public string NewSkuId { get; set; }

        /// <summary>
        /// <para type="description">email id or unique Id of the user</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "New email id or unique Id of the user")]
        [ValidateNotNullOrEmpty]
        public string NewUserId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (string.IsNullOrWhiteSpace(NewProductId)
                && string.IsNullOrWhiteSpace(NewSkuId)
                && string.IsNullOrWhiteSpace(NewUserId))
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

    /// <summary>
    /// <para type="synopsis">Assign License.</para>
    /// <para type="description">Assign License.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Licensing API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GLicenseAssignment -ProductId $SomeProductIdString -SkuId $SomeSkuIdString -UserId $SomeUserId</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GLicenseAssignment">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GLicenseAssignment",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GLicenseAssignment")]
    public class NewGLicenseAssignmentCommand : LicensingBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Name for product</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name for product")]
        public string ProductId { get; set; }

        /// <summary>
        /// <para type="description">Name for sku</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name for sku")]
        public string SkuId { get; set; }

        /// <summary>
        /// <para type="description">Email id of the user</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Email id of the user")]
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

    /// <summary>
    /// <para type="synopsis">Revoke License.</para>
    /// <para type="description">Revoke License.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Licensing API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GLicenseAssignment -ProductId $SomeProductIdString -SkuId $SomeSkuIdString -UserId $SomeUserIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GLicenseAssignment">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GLicenseAssignment",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GLicenseAssignment")]
    public class RemoveGLicenseAssignmentCommand : LicensingBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Name for product</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name for product")]
        public string ProductId { get; set; }

        /// <summary>
        /// <para type="description">Name for sku</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name for sku")]
        public string SkuId { get; set; }

        /// <summary>
        /// <para type="description">email id or unique Id of the user</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "email id or unique Id of the user")]
        public string UserId { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            string toRemoveTarget = "License Assignment";

			if (ShouldProcess(toRemoveTarget))
			{	
				if (Force || ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
				{
					try
					{
						WriteDebug("Attempting to remove " + toRemoveTarget + "...");

                        licenseAssignments.Delete(ProductId, SkuId, UserId);
							
						WriteVerbose("Removal of " + toRemoveTarget + " completed without error.");
					}
					catch (Exception e)
					{
						WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, toRemoveTarget));
					}
				}
				else
				{
					WriteError(new ErrorRecord(new Exception("Deletion not confirmed"),
						"", ErrorCategory.InvalidData, toRemoveTarget));
				}
			}
        }
    }
}
