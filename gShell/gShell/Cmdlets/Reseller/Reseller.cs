using System;
using System.Management.Automation;

using Google.Apis.Reseller.v1;
using Data = Google.Apis.Reseller.v1.Data;

using gReseller = gShell.dotNet.Reseller;

namespace gShell.Cmdlets.Reseller.Customers
{
    [Cmdlet(VerbsCommon.Get, "GResellerCustomer",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGResellerCustomer : ResellerBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Reseller Customer", "Get-GResellerCustomer"))
            {
                WriteObject(customers.Get(CustomerId));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GResellerCustomer",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGResellerCustomer : ResellerBase
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

            if (ShouldProcess("Reseller Customer", "Set-GResellerCustomer"))
            {
                WriteObject(customers.Patch(body, CustomerId));
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GResellerCustomer",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGResellerCustomer : ResellerBase
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

            if (ShouldProcess("Reseller Customer", "New-GResellerCustomer"))
            {
                WriteObject(customers.Insert(body, properties));
            }
        }
    }
    
}

namespace gShell.Cmdlets.Reseller.Subscription
{
    [Cmdlet(VerbsLifecycle.Enable, "GResellerSubscription",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class EnableGResellerSubscription : ResellerBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Reseller Subscription", "Enable-GResellerSubscription"))
            {
                WriteObject(subscriptions.Activate(CustomerId, SubscriptionId));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GResellerSubscriptionPlan",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGResellerSubscriptionPlan : ResellerBase
    {
        public enum PlanNameEnum
        {
            ANNUAL_MONTHLY_PAY, ANNUAL_YEARLY_PAY, FLEXIBLE, TRIAL
        }

        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public PlanNameEnum PlanName { get; set; }

        [Parameter(Position = 3,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public int NumberOfSeats { get; set; }

        [Parameter(Position = 4,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public int MaximumNumberOfSeats { get; set; }

        [Parameter(Position = 5,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string PurchaseOrderId { get; set; }

        [Parameter(Position = 6,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public int LicensedNumberOfSeats { get; set; }

        [Parameter(Position = 7,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string DealCode { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.ChangePlanRequest()
            {
                Kind = "subscriptions#changePlanRequest",
                PlanName = this.PlanName.ToString(),
                Seats = new Data.Seats()
                {
                    Kind = "subscriptions#seats",
                    NumberOfSeats = this.NumberOfSeats,
                    MaximumNumberOfSeats = this.MaximumNumberOfSeats,
                    LicensedNumberOfSeats = this.LicensedNumberOfSeats
                }
            };

            if (!string.IsNullOrWhiteSpace(PurchaseOrderId)) { PurchaseOrderId = this.PurchaseOrderId; }
            if (!string.IsNullOrWhiteSpace(DealCode)) { DealCode = this.DealCode; }

            if (ShouldProcess("Reseller Subscription Plan", "Set-GResellerSubscriptionPlan"))
            {
                WriteObject(subscriptions.ChangePlan(body, CustomerId, SubscriptionId));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GResellerSubscriptionRenewal",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGResellerSubscriptionRenewal : ResellerBase
    {
        public enum RenewalTypeEnum
        {
            AUTO_RENEW_MONTHLY_PAY, AUTO_RENEW_YEARLY_PAY, CANCEL, RENEW_CURRENT_USERS_MONTHLY_PAY, RENEW_CURRENT_USERS_YEARLY_PAY, SWITCH_TO_PAY_AS_YOU_GO
        }

        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public RenewalTypeEnum RenewalType { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.RenewalSettings()
            {
                Kind = "subscriptions#renewalSettings",
                RenewalType = this.RenewalType.ToString()
            };

            if (ShouldProcess("Reseller Subscription Renewal", "Set-GResellerSubscriptionRenewal"))
            {
                WriteObject(subscriptions.ChangeRenewalSettings(body, CustomerId, SubscriptionId));
            }
        }
    }

    [Cmdlet(VerbsCommon.Get, "GResellerSubscriptionSeats",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGResellerSubscriptionSeats : ResellerBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public int NumberOfSeats { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public int MaximumNumberOfSeats { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Seats()
            {
                Kind = "subscriptions#seats",
                NumberOfSeats = this.NumberOfSeats,
                MaximumNumberOfSeats = this.MaximumNumberOfSeats
            };

            if (ShouldProcess("Reseller Subscription Seats", "Get-GResellerSubscriptionSeats"))
            {
                WriteObject(subscriptions.ChangeSeats(body, CustomerId, SubscriptionId));
            }
        }
    }

    [Cmdlet(VerbsCommon.Remove, "GResellerSubscription",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class RemoveGResellerSubscription : ResellerBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public SubscriptionsResource.DeleteRequest.DeletionTypeEnum DeletionType { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Reseller Subscription", "Remove-GResellerSubscription"))
            {
                subscriptions.Delete(CustomerId, SubscriptionId, DeletionType);
            }
        }
    }

    [Cmdlet(VerbsCommon.Get, "GResellerSubscription",
        SupportsShouldProcess = true,
          HelpUri = @"",
          DefaultParameterSetName="one")]
    public class GetGResellerSubscription : ResellerBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = false,
            ParameterSetName = "all")]
        [ValidateNotNullOrEmpty]
        public string CustomerAuthToken { get; set; }
        
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName="one")]
        [Parameter(Position = 1,
            Mandatory = false,
            ParameterSetName = "all")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true,
            ParameterSetName = "one")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(Position = 2,
            Mandatory = false,
            ParameterSetName = "all")]
        [ValidateNotNullOrEmpty]
        public string CustomerNamePrefix { get; set; }

        [Parameter(Position = 3,
            Mandatory = false,
            ParameterSetName = "all")]
        [ValidateNotNullOrEmpty]
        public int? MaxResults { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            
            if (ParameterSetName == "one")
            {
                if (ShouldProcess("Reseller Subscription", "Get-GResellerSubscription"))
                {
                    WriteObject(subscriptions.Get(CustomerId, SubscriptionId));
                }
            }
            else
            {
                var properties = new gReseller.Subscriptions.SubscriptionsListProperties()
                {
                    maxResults = 100
                };

                if (!string.IsNullOrWhiteSpace(CustomerAuthToken)) { properties.customerAuthToken = this.CustomerAuthToken; }
                if (!string.IsNullOrWhiteSpace(CustomerId)) { properties.customerId = this.CustomerId; }
                if (!string.IsNullOrWhiteSpace(CustomerNamePrefix)) { properties.customerNamePrefix = this.CustomerNamePrefix; }
                if (MaxResults.HasValue) { properties.totalResults = this.MaxResults.Value; }

                if (ShouldProcess("Reseller Subscription", "Get-GResellerSubscription"))
                {
                    WriteObject(subscriptions.List(properties));
                }
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GResellerSubscription",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGResellerSubscription : ResellerBase
    {
        public enum StatusEnum
        {
            ACTIVE, BILLING_ACTIVATION_PENDING, CANCELLED, PENDING
        }

        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string TargetCustomerId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string BillingMethod { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public long CreationTime { get; set; }

        [Parameter(Position = 3,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerDomain { get; set; }

        [Parameter(Position = 4,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        [Parameter(Position = 5,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string DealCode { get; set; }

        [Parameter(Position = 6,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public long PlanCommitmentIntervalEndTime { get; set; }

        [Parameter(Position = 7,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public long PlanCommitmentIntervalStartTime { get; set; }

        [Parameter(Position = 8,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool IsCommitmentPlan { get; set; }

        [Parameter(Position = 9,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string PlanName { get; set; }

        [Parameter(Position = 10,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string PurchaseOrderId { get; set; }

        [Parameter(Position = 11,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string RenewalType { get; set; }

        [Parameter(Position = 12,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceUiUrl { get; set; }

        [Parameter(Position = 13,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public int NumberOfSeats { get; set; }

        [Parameter(Position = 14,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public int MaximumNumberOfSeats { get; set; }

        [Parameter(Position = 15,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public int LicensedNumberOfSeats { get; set; }

        [Parameter(Position = 16,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SkuId { get; set; }

        [Parameter(Position = 17,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public StatusEnum Status { get; set; }

        [Parameter(Position = 18,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(Position = 19,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public int MinimumTransferableSeats { get; set; }

        [Parameter(Position = 20,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public long TransferabilityExpirationTime { get; set; }

        [Parameter(Position = 21,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool IsInTrial { get; set; }

        [Parameter(Position = 22,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public long TrialEndTime { get; set; }

        [Parameter(Position = 23,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string CustomerAuthToken { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Subscription()
            {
                BillingMethod = this.BillingMethod,
                CreationTime = this.CreationTime,
                CustomerDomain = this.CustomerDomain,
                CustomerId = this.CustomerId,
                DealCode = this.DealCode,
                Kind = "reseller#subscription",
                Plan = new Data.Subscription.PlanData(){
                    CommitmentInterval = new Data.Subscription.PlanData.CommitmentIntervalData(){
                        EndTime = this.PlanCommitmentIntervalEndTime,
                        StartTime = this.PlanCommitmentIntervalStartTime
                    },
                    IsCommitmentPlan = this.IsCommitmentPlan,
                    PlanName = this.PlanName
                },
                PurchaseOrderId = this.PurchaseOrderId,
                RenewalSettings = new Data.RenewalSettings()
                {
                    Kind = "subscriptions#renewalSettings",
                    RenewalType = this.RenewalType
                },
                ResourceUiUrl = this.ResourceUiUrl,
                Seats = new Data.Seats(){
                    NumberOfSeats = this.NumberOfSeats,
                    MaximumNumberOfSeats = this.MaximumNumberOfSeats,
                    LicensedNumberOfSeats = this.LicensedNumberOfSeats
                },
                SkuId = this.SkuId,
                Status = this.Status.ToString(),
                SubscriptionId = this.SubscriptionId,
                TransferInfo = new Data.Subscription.TransferInfoData(){
                    MinimumTransferableSeats = this.MinimumTransferableSeats,
                    TransferabilityExpirationTime = this.TransferabilityExpirationTime
                },
                TrialSettings = new Data.Subscription.TrialSettingsData(){
                    IsInTrial = this.IsInTrial,
                    TrialEndTime = this.TrialEndTime
                }                
            };

            var properties = new gReseller.Subscriptions.SubscriptionsInsertProperties(){
                customerAuthToken = CustomerAuthToken
            };

            if (ShouldProcess("Reseller Subscription", "New-GResellerSubscription"))
            {
                WriteObject(subscriptions.Insert(body, TargetCustomerId, properties));
            }
        }
    }

    [Cmdlet(VerbsLifecycle.Start, "GResellerSubscriptionPaidService",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class StartGResellerSubscriptionPaidService : ResellerBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Reseller Subscription Paid Service", "Start-GResellerSubscriptionPaidService"))
            {
                WriteObject(subscriptions.StartPaidService(CustomerId, SubscriptionId));
            }
        }
    }

    [Cmdlet(VerbsLifecycle.Suspend, "GResellerSubscription",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SuspendGResellerSubscription : ResellerBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Reseller Subscription", "Suspend-GResellerSubscription"))
            {
                WriteObject(subscriptions.Suspend(CustomerId, SubscriptionId));
            }
        }
    }
}