using System;
using System.Management.Automation;

using Data = Google.Apis.Reseller.v1.Data;

using gReseller = gShell.dotNet.Reseller;

namespace gShell.Cmdlets.Reseller.Customers
{
    [Cmdlet(VerbsCommon.Get, "GReseller",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGReseller : ResellerBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Reseller", "Get-GReseller"))
            {
                WriteObject(customers.Get(CustomerId));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GReseller",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGReseller : ResellerBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string TargetCustomerId { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string AlternateEmail { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string CustomerDomain { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? CustomerDomainVerified { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string PhoneNumber { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string PostalAddress1 { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string PostalAddress2 { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string PostalAddress3 { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string PostalContactName { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string PostalCountryCode { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string PostalLocality { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string PostalOrgName { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string PostalCode { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string PostalRegion { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Customer()
            {
                Kind = "reseller#customer",
                PostalAddress = new Data.Address()
                {
                    ContactName = this.PostalContactName,
                    OrganizationName = this.PostalOrgName,
                    Kind = "customer#address"
                }
            };

            if (!string.IsNullOrWhiteSpace(AlternateEmail)) { body.AlternateEmail = this.AlternateEmail; }
            if (!string.IsNullOrWhiteSpace(CustomerDomain)) { body.CustomerDomain = this.CustomerDomain; }
            if (CustomerDomainVerified.HasValue) { body.CustomerDomainVerified = this.CustomerDomainVerified; }
            if (!string.IsNullOrWhiteSpace(CustomerId)) { body.CustomerId = this.CustomerId; }
            if (!string.IsNullOrWhiteSpace(PhoneNumber)) { body.PhoneNumber = this.PhoneNumber; }
            if (!string.IsNullOrWhiteSpace(PostalAddress1)) { body.PostalAddress.AddressLine1 = this.PostalAddress1; }
            if (!string.IsNullOrWhiteSpace(PostalAddress2)) { body.PostalAddress.AddressLine2 = this.PostalAddress2; }
            if (!string.IsNullOrWhiteSpace(PostalAddress3)) { body.PostalAddress.AddressLine3 = this.PostalAddress3; }
            if (!string.IsNullOrWhiteSpace(PostalCountryCode)) { body.PostalAddress.CountryCode = this.PostalCountryCode; }
            if (!string.IsNullOrWhiteSpace(PostalLocality)) { body.PostalAddress.Locality = this.PostalLocality; }
            if (!string.IsNullOrWhiteSpace(PostalCode)) { body.PostalAddress.PostalCode = this.PostalCode; }
            if (!string.IsNullOrWhiteSpace(PostalRegion)) { body.PostalAddress.Region = this.PostalRegion; }

            if (ShouldProcess("Reseller", "Set-GReseller"))
            {
                WriteObject(customers.Patch(body, CustomerId));
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GReseller",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGReseller : ResellerBase
    {
        #region Properties
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string CustomerAuthToken { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string AlternateEmail { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerDomain { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? CustomerDomainVerified { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string PhoneNumber { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string PostalAddress1 { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string PostalAddress2 { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string PostalAddress3 { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string PostalContactName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string PostalCountryCode { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string PostalLocality { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string PostalOrgName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string PostalCode { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string PostalRegion { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Customer()
            {
                AlternateEmail = this.AlternateEmail,
                CustomerDomain = this.CustomerDomain,
                Kind = "reseller#customer",
                PostalAddress = new Data.Address()
                {
                    ContactName = this.PostalContactName,
                    CountryCode = this.PostalCountryCode,
                    OrganizationName = this.PostalOrgName,
                    PostalCode = this.PostalCode,
                    Kind = "customer#address"
                }
            };

            if (CustomerDomainVerified.HasValue) { body.CustomerDomainVerified = this.CustomerDomainVerified; }
            if (!string.IsNullOrWhiteSpace(CustomerId)) { body.CustomerId = this.CustomerId; }
            if (!string.IsNullOrWhiteSpace(PhoneNumber)) { body.PhoneNumber = this.PhoneNumber; }
            if (!string.IsNullOrWhiteSpace(PostalAddress1)) { body.PostalAddress.AddressLine1 = this.PostalAddress1; }
            if (!string.IsNullOrWhiteSpace(PostalAddress2)) { body.PostalAddress.AddressLine2 = this.PostalAddress2; }
            if (!string.IsNullOrWhiteSpace(PostalAddress3)) { body.PostalAddress.AddressLine3 = this.PostalAddress3; }
            if (!string.IsNullOrWhiteSpace(PostalLocality)) { body.PostalAddress.Locality = this.PostalLocality; }
            if (!string.IsNullOrWhiteSpace(PostalRegion)) { body.PostalAddress.Region = this.PostalRegion; }

            var properties = new gReseller.Customers.CustomersInsertProperties();

            if (!string.IsNullOrWhiteSpace(CustomerAuthToken)) { properties.customerAuthToken = this.CustomerAuthToken; }

            if (ShouldProcess("Reseller", "New-GReseller"))
            {
                WriteObject(customers.Insert(body, properties));
            }
        }
    }
    
}