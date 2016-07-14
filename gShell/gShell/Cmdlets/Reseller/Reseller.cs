using System;
using System.Management.Automation;

using Google.Apis.Reseller.v1;
using Data = Google.Apis.Reseller.v1.Data;

using gReseller = gShell.dotNet.Reseller;

namespace gShell.Cmdlets.Reseller
{
    /// <summary>
    /// <para type="synopsis">Creates a new Reseller API Customer object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a Customer object which may be required as a parameter for some other Cmdlets in the Reseller API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Reseller.v1.Data.Customer</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reseller API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GResellerCustomerObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GResellerCustomerObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GResellerCustomerObj",
    SupportsShouldProcess = true)]
    [OutputType(typeof(Google.Apis.Reseller.v1.Data.Customer))]
    public class NewGResellerCustomerObj : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">The alternate email of the customer.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The alternate email of the customer.")]
        public string AlternateEmail { get; set; }

        /// <summary>
        /// <para type="description">The domain name of the customer.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The domain name of the customer.")]
        public string CustomerDomain { get; set; }

        /// <summary>
        /// <para type="description">Whether the customer's primary domain has been verified.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Whether the customer's primary domain has been verified.")]
        public System.Nullable<bool> CustomerDomainVerified { get; set; }

        /// <summary>
        /// <para type="description">The id of the customer.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The id of the customer.")]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">The phone number of the customer.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The phone number of the customer.")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// <para type="description">The postal address of the customer.</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The postal address of the customer.")]
        public Data.Address PostalAddress { get; set; }

        /// <summary>
        /// <para type="description">Ui url for customer resource.</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Ui url for customer resource.")]
        public string ResourceUiUrl { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.Reseller.v1.Data.Customer()
            {
                AlternateEmail = this.AlternateEmail,
                CustomerDomain = this.CustomerDomain,
                CustomerDomainVerified = this.CustomerDomainVerified,
                CustomerId = this.CustomerId,
                PhoneNumber = this.PhoneNumber,
                PostalAddress = this.PostalAddress,
                ResourceUiUrl = this.ResourceUiUrl,
            };

            if (ShouldProcess("Customer"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Reseller API Subscription.PlanData object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a Subscription.PlanData object which may be required as a parameter for some other Cmdlets in the Reseller API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Reseller.v1.Data.Subscription.PlanData</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reseller API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GResellerSubscriptionPlanDataObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GResellerSubscription.PlanDataObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GResellerSubscriptionPlanDataObj",
    SupportsShouldProcess = true)]
    [OutputType(typeof(Google.Apis.Reseller.v1.Data.Subscription.PlanData))]
    public class NewGResellerSubscriptionPlanDataObj : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">Interval of the commitment if it is a commitment plan.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Interval of the commitment if it is a commitment plan.")]
        public Data.Subscription.PlanData.CommitmentIntervalData CommitmentInterval { get; set; }

        /// <summary>
        /// <para type="description">Whether the plan is a commitment plan or not.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Whether the plan is a commitment plan or not.")]
        public System.Nullable<bool> IsCommitmentPlan { get; set; }

        /// <summary>
        /// <para type="description">The plan name of this subscription's plan.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The plan name of this subscription's plan.")]
        public string PlanName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.Reseller.v1.Data.Subscription.PlanData()
            {
                CommitmentInterval = this.CommitmentInterval,
                IsCommitmentPlan = this.IsCommitmentPlan,
                PlanName = this.PlanName,
            };

            if (ShouldProcess("Subscription.PlanData"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Reseller API Subscription object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a Subscription object which may be required as a parameter for some other Cmdlets in the Reseller API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Reseller.v1.Data.Subscription</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reseller API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GResellerSubscriptionObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GResellerSubscriptionObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GResellerSubscriptionObj",
    SupportsShouldProcess = true)]
    [OutputType(typeof(Google.Apis.Reseller.v1.Data.Subscription))]
    public class NewGResellerSubscriptionObj : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">Billing method of this subscription.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Billing method of this subscription.")]
        public string BillingMethod { get; set; }

        /// <summary>
        /// <para type="description">Creation time of this subscription in milliseconds since Unix epoch.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Creation time of this subscription in milliseconds since Unix epoch.")]
        public System.Nullable<long> CreationTime { get; set; }

        /// <summary>
        /// <para type="description">Primary domain name of the customer</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Primary domain name of the customer")]
        public string CustomerDomain { get; set; }

        /// <summary>
        /// <para type="description">The id of the customer to whom the subscription belongs.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The id of the customer to whom the subscription belongs.")]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">External name of the deal, if this subscription was provisioned under one. Otherwise this field will be empty.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "External name of the deal, if this subscription was provisioned under one. Otherwise this field will be empty.")]
        public string DealCode { get; set; }

        /// <summary>
        /// <para type="description">Plan details of the subscription</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Plan details of the subscription")]
        public Data.Subscription.PlanData Plan { get; set; }

        /// <summary>
        /// <para type="description">Purchase order id for your order tracking purposes.</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Purchase order id for your order tracking purposes.")]
        public string PurchaseOrderId { get; set; }

        /// <summary>
        /// <para type="description">Renewal settings of the subscription.</para>
        /// </summary>
        [Parameter(Position = 7,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Renewal settings of the subscription.")]
        public Data.RenewalSettings RenewalSettings { get; set; }

        /// <summary>
        /// <para type="description">Ui url for subscription resource.</para>
        /// </summary>
        [Parameter(Position = 8,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Ui url for subscription resource.")]
        public string ResourceUiUrl { get; set; }

        /// <summary>
        /// <para type="description">Number/Limit of seats in the new plan.</para>
        /// </summary>
        [Parameter(Position = 9,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Number/Limit of seats in the new plan.")]
        public Data.Seats Seats { get; set; }

        /// <summary>
        /// <para type="description">Name of the sku for which this subscription is purchased.</para>
        /// </summary>
        [Parameter(Position = 10,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of the sku for which this subscription is purchased.")]
        public string SkuId { get; set; }

        /// <summary>
        /// <para type="description">Status of the subscription.</para>
        /// </summary>
        [Parameter(Position = 11,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Status of the subscription.")]
        public string Status { get; set; }

        /// <summary>
        /// <para type="description">The id of the subscription.</para>
        /// </summary>
        [Parameter(Position = 12,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The id of the subscription.")]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// <para type="description">Read-only field containing an enumerable of all the current suspension reasons for a subscription. It is possible for a subscription to have many concurrent, overlapping suspension reasons. A subscription's STATUS is SUSPENDED until all pending suspensions are removed. Possible options include:- PENDING_TOS_ACCEPTANCE - The customer has not logged in and accepted the Google Apps Resold Terms of Services.- RENEWAL_WITH_TYPE_CANCEL - The customer's commitment ended and their service was cancelled at the end of their term.- RESELLER_INITIATED - A manual suspension invoked by a Reseller.- TRIAL_ENDED - The customer's trial expired without a plan selected.- OTHER - The customer is suspended for an internal Google reason (e.g. abuse or otherwise).</para>
        /// </summary>
        [Parameter(Position = 13,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Read-only field containing an enumerable of all the current suspension reasons for a subscription. It is possible for a subscription to have many concurrent, overlapping suspension reasons. A subscription's STATUS is SUSPENDED until all pending suspensions are removed. Possible options include:  \n- PENDING_TOS_ACCEPTANCE - The customer has not logged in and accepted the Google Apps Resold Terms of Services.  \n- RENEWAL_WITH_TYPE_CANCEL - The customer's commitment ended and their service was cancelled at the end of their term.  \n- RESELLER_INITIATED - A manual suspension invoked by a Reseller.  \n- TRIAL_ENDED - The customer's trial expired without a plan selected.  \n- OTHER - The customer is suspended for an internal Google reason (e.g. abuse or otherwise).")]
        public System.Collections.Generic.IList<string> SuspensionReasons { get; set; }

        /// <summary>
        /// <para type="description">Transfer related information for the subscription.</para>
        /// </summary>
        [Parameter(Position = 14,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Transfer related information for the subscription.")]
        public Data.Subscription.TransferInfoData TransferInfo { get; set; }

        /// <summary>
        /// <para type="description">Trial Settings of the subscription.</para>
        /// </summary>
        [Parameter(Position = 15,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Trial Settings of the subscription.")]
        public Data.Subscription.TrialSettingsData TrialSettings { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.Reseller.v1.Data.Subscription()
            {
                BillingMethod = this.BillingMethod,
                CreationTime = this.CreationTime,
                CustomerDomain = this.CustomerDomain,
                CustomerId = this.CustomerId,
                DealCode = this.DealCode,
                Plan = this.Plan,
                PurchaseOrderId = this.PurchaseOrderId,
                RenewalSettings = this.RenewalSettings,
                ResourceUiUrl = this.ResourceUiUrl,
                Seats = this.Seats,
                SkuId = this.SkuId,
                Status = this.Status,
                SubscriptionId = this.SubscriptionId,
                SuspensionReasons = this.SuspensionReasons,
                TransferInfo = this.TransferInfo,
                TrialSettings = this.TrialSettings,
            };

            if (ShouldProcess("Subscription"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Reseller API Subscription.TransferInfoData object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a Subscription.TransferInfoData object which may be required as a parameter for some other Cmdlets in the Reseller API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Reseller.v1.Data.Subscription.TransferInfoData</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reseller API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GResellerSubscriptionTransferInfoDataObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GResellerSubscription.TransferInfoDataObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GResellerSubscriptionTransferInfoDataObj",
    SupportsShouldProcess = true)]
    [OutputType(typeof(Google.Apis.Reseller.v1.Data.Subscription.TransferInfoData))]
    public class NewGResellerSubscriptionTransferInfoDataObj : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">Minimum number of seats listed in the transfer order for this product. For example, if the customer has 20 users, the reseller cannot place a transfer order of 15 seats. The minimum is 20 seats.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Minimum number of seats listed in the transfer order for this product. For example, if the customer has 20 users, the reseller cannot place a transfer order of 15 seats. The minimum is 20 seats.")]
        public System.Nullable<int> MinimumTransferableSeats { get; set; }

        /// <summary>
        /// <para type="description">Time when transfer token or intent to transfer will expire.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Time when transfer token or intent to transfer will expire.")]
        public System.Nullable<long> TransferabilityExpirationTime { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.Reseller.v1.Data.Subscription.TransferInfoData()
            {
                MinimumTransferableSeats = this.MinimumTransferableSeats,
                TransferabilityExpirationTime = this.TransferabilityExpirationTime,
            };

            if (ShouldProcess("Subscription.TransferInfoData"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Reseller API RenewalSettings object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a RenewalSettings object which may be required as a parameter for some other Cmdlets in the Reseller API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Reseller.v1.Data.RenewalSettings</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reseller API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GResellerRenewalSettingsObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GResellerRenewalSettingsObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GResellerRenewalSettingsObj",
    SupportsShouldProcess = true)]
    [OutputType(typeof(Google.Apis.Reseller.v1.Data.RenewalSettings))]
    public class NewGResellerRenewalSettingsObj : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">Subscription renewal type.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Subscription renewal type.")]
        public string RenewalType { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.Reseller.v1.Data.RenewalSettings()
            {
                RenewalType = this.RenewalType,
            };

            if (ShouldProcess("RenewalSettings"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Reseller API Subscription.TrialSettingsData object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a Subscription.TrialSettingsData object which may be required as a parameter for some other Cmdlets in the Reseller API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Reseller.v1.Data.Subscription.TrialSettingsData</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reseller API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GResellerSubscriptionTrialSettingsDataObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GResellerSubscription.TrialSettingsDataObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GResellerSubscriptionTrialSettingsDataObj",
    SupportsShouldProcess = true)]
    [OutputType(typeof(Google.Apis.Reseller.v1.Data.Subscription.TrialSettingsData))]
    public class NewGResellerSubscriptionTrialSettingsDataObj : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">Whether the subscription is in trial.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Whether the subscription is in trial.")]
        public System.Nullable<bool> IsInTrial { get; set; }

        /// <summary>
        /// <para type="description">End time of the trial in milliseconds since Unix epoch.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "End time of the trial in milliseconds since Unix epoch.")]
        public System.Nullable<long> TrialEndTime { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.Reseller.v1.Data.Subscription.TrialSettingsData()
            {
                IsInTrial = this.IsInTrial,
                TrialEndTime = this.TrialEndTime,
            };

            if (ShouldProcess("Subscription.TrialSettingsData"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Reseller API Seats object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a Seats object which may be required as a parameter for some other Cmdlets in the Reseller API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.Reseller.v1.Data.Seats</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reseller API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GResellerSeatsObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GResellerSeatsObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GResellerSeatsObj",
    SupportsShouldProcess = true)]
    [OutputType(typeof(Google.Apis.Reseller.v1.Data.Seats))]
    public class NewGResellerSeatsObj : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">Read-only field containing the current number of licensed seats for FLEXIBLE Google-Apps subscriptions and secondary subscriptions such as Google-Vault and Drive-storage.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Read-only field containing the current number of licensed seats for FLEXIBLE Google-Apps subscriptions and secondary subscriptions such as Google-Vault and Drive-storage.")]
        public System.Nullable<int> LicensedNumberOfSeats { get; set; }

        /// <summary>
        /// <para type="description">Maximum number of seats that can be purchased. This needs to be provided only for a non-commitment plan. For a commitment plan it is decided by the contract.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Maximum number of seats that can be purchased. This needs to be provided only for a non-commitment plan. For a commitment plan it is decided by the contract.")]
        public System.Nullable<int> MaximumNumberOfSeats { get; set; }

        /// <summary>
        /// <para type="description">Number of seats to purchase. This is applicable only for a commitment plan.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Number of seats to purchase. This is applicable only for a commitment plan.")]
        public System.Nullable<int> NumberOfSeats { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.Reseller.v1.Data.Seats()
            {
                LicensedNumberOfSeats = this.LicensedNumberOfSeats,
                MaximumNumberOfSeats = this.MaximumNumberOfSeats,
                NumberOfSeats = this.NumberOfSeats,
            };

            if (ShouldProcess("Seats"))
            {
                WriteObject(body);
            }
        }
    }
}

namespace gShell.Cmdlets.Reseller.Customers
{
    /// <summary>
    /// <para type="synopsis">Gets a customer resource if one exists and is owned by the reseller.</para>
    /// <para type="description">Gets a customer resource if one exists and is owned by the reseller.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reseller API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GResellerCustomer -CustomerId $SomeCustomerIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GResellerCustomer">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GResellerCustomer",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GResellerCustomer",
          DefaultParameterSetName = "Params")]
    public class GetGResellerCustomer : ResellerBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Id of the Customer</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Id of the Customer")]
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

    /// <summary>
    /// <para type="synopsis">Update a customer resource if one it exists and is owned by the reseller. This method supports Set semantics.</para>
    /// <para type="description">Update a customer resource if one it exists and is owned by the reseller. This method supports Set semantics.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reseller API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GResellerCustomer -CustomerId $SomeCustomerIdString -CustomerBody $SomeCustomerObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GResellerCustomer">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GResellerCustomer",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GResellerCustomer",
          DefaultParameterSetName = "Params")]
    public class SetGResellerCustomer : ResellerBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Id of the Customer</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Id of the Customer")]
        [ValidateNotNullOrEmpty]
        public string TargetCustomerId { get; set; }

        /// <summary>
        /// <para type="description">The alternate email of the customer.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The alternate email of the customer.")]
        [ValidateNotNullOrEmpty]
        public string AlternateEmail { get; set; }

        /// <summary>
        /// <para type="description">The domain name of the customer.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The domain name of the customer.")]
        [ValidateNotNullOrEmpty]
        public string CustomerDomain { get; set; }

        /// <summary>
        /// <para type="description">Whether the customer's primary domain has been verified.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Whether the customer's primary domain has been verified.")]
        public bool? CustomerDomainVerified { get; set; }

        /// <summary>
        /// <para type="description">The id of the customer.</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The id of the customer.")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">The phone number of the customer.</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The phone number of the customer.")]
        [ValidateNotNullOrEmpty]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// <para type="description">The postal address of the customer.</para>
        /// </summary>
        [Parameter(Position = 7,
        ParameterSetName = "Body",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The postal address of the customer.")]
        public Data.Address PostalAddress { get; set; }

        /// <summary>
        /// <para type="description">The postal address of the customer.</para>
        /// </summary>
        [Parameter(Position = 7,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The postal address of the customer.")]
        [ValidateNotNullOrEmpty]
        public string PostalAddress1 { get; set; }

        /// <summary>
        /// <para type="description">The second postal address of the customer.</para>
        /// </summary>
        [Parameter(Position = 8,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The postal address of the customer.")]
        [ValidateNotNullOrEmpty]
        public string PostalAddress2 { get; set; }

        /// <summary>
        /// <para type="description">The third postal address of the customer.</para>
        /// </summary>
        [Parameter(Position = 9,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The postal address of the customer.")]
        [ValidateNotNullOrEmpty]
        public string PostalAddress3 { get; set; }

        /// <summary>
        /// <para type="description">Name of the contact person.</para>
        /// </summary>
        [Parameter(Position = 10,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of the contact person.")]
        [ValidateNotNullOrEmpty]
        public string PostalContactName { get; set; }

        /// <summary>
        /// <para type="description">ISO 3166 country code.</para>
        /// </summary>
        [Parameter(Position = 11,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "ISO 3166 country code.")]
        [ValidateNotNullOrEmpty]
        public string PostalCountryCode { get; set; }

        /// <summary>
        /// <para type="description">Name of the locality. This is in accordance with - http://portablecontacts.net/draft-spec.html#address_element.</para>
        /// </summary>
        [Parameter(Position = 12,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of the locality. This is in accordance with - http://portablecontacts.net/draft-spec.html#address_element.")]
        [ValidateNotNullOrEmpty]
        public string PostalLocality { get; set; }

        /// <summary>
        /// <para type="description">Name of the organization.</para>
        /// </summary>
        [Parameter(Position = 13,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of the organization.")]
        [ValidateNotNullOrEmpty]
        public string PostalOrgName { get; set; }

        /// <summary>
        /// <para type="description">The postal code. This is in accordance with - http://portablecontacts.net/draft-spec.html#address_element.</para>
        /// </summary>
        [Parameter(Position = 14,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The postal code. This is in accordance with - http://portablecontacts.net/draft-spec.html#address_element.")]
        [ValidateNotNullOrEmpty]
        public string PostalCode { get; set; }

        /// <summary>
        /// <para type="description">Name of the region. This is in accordance with - http://portablecontacts.net/draft-spec.html#address_element.</para>
        /// </summary>
        [Parameter(Position = 15,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of the region. This is in accordance with - http://portablecontacts.net/draft-spec.html#address_element.")]
        [ValidateNotNullOrEmpty]
        public string PostalRegion { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Customer()
            {
                Kind = "reseller#customer",
            };

            if (ParameterSetName == "Params")
            {
                body.PostalAddress = new Data.Address()
                {
                    ContactName = this.PostalContactName,
                    OrganizationName = this.PostalOrgName,
                    Kind = "customer#address"
                };

                if (!string.IsNullOrWhiteSpace(PostalAddress1)) body.PostalAddress.AddressLine1 = this.PostalAddress1;
                if (!string.IsNullOrWhiteSpace(PostalAddress2)) body.PostalAddress.AddressLine2 = this.PostalAddress2;
                if (!string.IsNullOrWhiteSpace(PostalAddress3)) body.PostalAddress.AddressLine3 = this.PostalAddress3;
                if (!string.IsNullOrWhiteSpace(PostalCountryCode)) body.PostalAddress.CountryCode = this.PostalCountryCode;
                if (!string.IsNullOrWhiteSpace(PostalLocality)) body.PostalAddress.Locality = this.PostalLocality;
                if (!string.IsNullOrWhiteSpace(PostalCode)) body.PostalAddress.PostalCode = this.PostalCode;
                if (!string.IsNullOrWhiteSpace(PostalRegion)) body.PostalAddress.Region = this.PostalRegion;
            }
            else
            {
                body.PostalAddress = PostalAddress;
            }

            if (!string.IsNullOrWhiteSpace(AlternateEmail)) body.AlternateEmail = this.AlternateEmail;
            if (!string.IsNullOrWhiteSpace(CustomerDomain)) body.CustomerDomain = this.CustomerDomain;
            if (CustomerDomainVerified.HasValue) body.CustomerDomainVerified = this.CustomerDomainVerified;
            if (!string.IsNullOrWhiteSpace(CustomerId)) body.CustomerId = this.CustomerId;
            if (!string.IsNullOrWhiteSpace(PhoneNumber)) body.PhoneNumber = this.PhoneNumber;
            

            if (ShouldProcess("Reseller Customer", "Set-GResellerCustomer"))
                WriteObject(customers.Patch(body, CustomerId));
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a customer resource if one does not already exist.</para>
    /// <para type="description">Creates a customer resource if one does not already exist.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reseller API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GResellerCustomer -CustomerBody $SomeCustomerObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GResellerCustomer">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GResellerCustomer",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GResellerCustomer",
          DefaultParameterSetName = "Params")]
    public class NewGResellerCustomer : ResellerBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">An auth token needed for Newing a customer for which domain already exists. Can be generated at https://admin.google.com/TransferToken. Optional.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "An auth token needed for Newing a customer for which domain already exists. Can be generated at https://admin.google.com/TransferToken. Optional.")]
        [ValidateNotNullOrEmpty]
        public string CustomerAuthToken { get; set; }

        /// <summary>
        /// <para type="description">JSON template for a customer.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "JSON template for a customer.")]
        public Data.Customer CustomerBody { get; set; }

        /// <summary>
        /// <para type="description">The alternate email of the customer.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The alternate email of the customer.")]
        [ValidateNotNullOrEmpty]
        public string AlternateEmail { get; set; }

        /// <summary>
        /// <para type="description">The domain name of the customer.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The domain name of the customer.")]
        [ValidateNotNullOrEmpty]
        public string CustomerDomain { get; set; }

        /// <summary>
        /// <para type="description">Whether the customer's primary domain has been verified.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Whether the customer's primary domain has been verified.")]
        public bool? CustomerDomainVerified { get; set; }

        /// <summary>
        /// <para type="description">The id of the customer.</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The id of the customer.")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">The phone number of the customer.</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The phone number of the customer.")]
        [ValidateNotNullOrEmpty]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// <para type="description">The postal address of the customer.</para>
        /// </summary>
        [Parameter(Position = 7,
        ParameterSetName = "Body",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The postal address of the customer.")]
        public Data.Address PostalAddress { get; set; }

        /// <summary>
        /// <para type="description">The postal address of the customer.</para>
        /// </summary>
        [Parameter(Position = 7,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The postal address of the customer.")]
        [ValidateNotNullOrEmpty]
        public string PostalAddress1 { get; set; }

        /// <summary>
        /// <para type="description">The second postal address of the customer.</para>
        /// </summary>
        [Parameter(Position = 8,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The postal address of the customer.")]
        [ValidateNotNullOrEmpty]
        public string PostalAddress2 { get; set; }

        /// <summary>
        /// <para type="description">The third postal address of the customer.</para>
        /// </summary>
        [Parameter(Position = 9,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The postal address of the customer.")]
        [ValidateNotNullOrEmpty]
        public string PostalAddress3 { get; set; }

        /// <summary>
        /// <para type="description">Name of the contact person.</para>
        /// </summary>
        [Parameter(Position = 10,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of the contact person.")]
        [ValidateNotNullOrEmpty]
        public string PostalContactName { get; set; }

        /// <summary>
        /// <para type="description">ISO 3166 country code.</para>
        /// </summary>
        [Parameter(Position = 11,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "ISO 3166 country code.")]
        [ValidateNotNullOrEmpty]
        public string PostalCountryCode { get; set; }

        /// <summary>
        /// <para type="description">Name of the locality. This is in accordance with - http://portablecontacts.net/draft-spec.html#address_element.</para>
        /// </summary>
        [Parameter(Position = 12,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of the locality. This is in accordance with - http://portablecontacts.net/draft-spec.html#address_element.")]
        [ValidateNotNullOrEmpty]
        public string PostalLocality { get; set; }

        /// <summary>
        /// <para type="description">Name of the organization.</para>
        /// </summary>
        [Parameter(Position = 13,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of the organization.")]
        [ValidateNotNullOrEmpty]
        public string PostalOrgName { get; set; }

        /// <summary>
        /// <para type="description">The postal code. This is in accordance with - http://portablecontacts.net/draft-spec.html#address_element.</para>
        /// </summary>
        [Parameter(Position = 14,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The postal code. This is in accordance with - http://portablecontacts.net/draft-spec.html#address_element.")]
        [ValidateNotNullOrEmpty]
        public string PostalCode { get; set; }

        /// <summary>
        /// <para type="description">Name of the region. This is in accordance with - http://portablecontacts.net/draft-spec.html#address_element.</para>
        /// </summary>
        [Parameter(Position = 15,
        ParameterSetName = "Params",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of the region. This is in accordance with - http://portablecontacts.net/draft-spec.html#address_element.")]
        [ValidateNotNullOrEmpty]
        public string PostalRegion { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Customer()
            {
                AlternateEmail = this.AlternateEmail,
                CustomerDomain = this.CustomerDomain,
                Kind = "reseller#customer"
            };

            if (ParameterSetName == "Params")
            {
                body.PostalAddress = new Data.Address()
                {
                    ContactName = this.PostalContactName,
                    CountryCode = this.PostalCountryCode,
                    OrganizationName = this.PostalOrgName,
                    PostalCode = this.PostalCode,
                    Kind = "customer#address"
                };

                if (!string.IsNullOrWhiteSpace(PostalAddress1)) body.PostalAddress.AddressLine1 = this.PostalAddress1;
                if (!string.IsNullOrWhiteSpace(PostalAddress2)) body.PostalAddress.AddressLine2 = this.PostalAddress2;
                if (!string.IsNullOrWhiteSpace(PostalAddress3)) body.PostalAddress.AddressLine3 = this.PostalAddress3;
                if (!string.IsNullOrWhiteSpace(PostalLocality)) body.PostalAddress.Locality = this.PostalLocality;
                if (!string.IsNullOrWhiteSpace(PostalRegion)) body.PostalAddress.Region = this.PostalRegion;
            }
            else
            {
                body.PostalAddress = this.PostalAddress;
            }

            if (CustomerDomainVerified.HasValue) body.CustomerDomainVerified = this.CustomerDomainVerified;
            if (!string.IsNullOrWhiteSpace(CustomerId)) body.CustomerId = this.CustomerId;
            if (!string.IsNullOrWhiteSpace(PhoneNumber)) body.PhoneNumber = this.PhoneNumber;

            var properties = new gReseller.Customers.CustomersInsertProperties();

            if (!string.IsNullOrWhiteSpace(CustomerAuthToken)) properties.CustomerAuthToken = this.CustomerAuthToken;

            if (ShouldProcess("Reseller Customer", "New-GResellerCustomer"))
                WriteObject(customers.Insert(body, properties));
        }
    }
}

namespace gShell.Cmdlets.Reseller.Subscription
{
    /// <summary>
    /// <para type="synopsis">Activates a subscription previously suspended by the reseller</para>
    /// <para type="description">Activates a subscription previously suspended by the reseller</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reseller API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Enable-GResellerSubscription -CustomerId $SomeCustomerIdString -SubscriptionId $SomeSubscriptionIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Enable-GResellerSubscription">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsLifecycle.Enable, "GResellerSubscription",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Enable-GResellerSubscription")]
    public class EnableGResellerSubscription : ResellerBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Id of the Customer</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Id of the Customer")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Id of the subscription, which is unique for a customer</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Id of the subscription, which is unique for a customer")]
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

    /// <summary>
    /// <para type="synopsis">Changes the plan of a subscription</para>
    /// <para type="description">Changes the plan of a subscription</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reseller API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GResellerSubscriptionPlan -CustomerId $SomeCustomerIdString -SubscriptionId $SomeSubscriptionIdString -PlanName $SomePlanName -NumberOfSeats $SomeNumberOfSeatsInt -MaximumNumberOfSeats $SomeMaximumNumberOfSeatsInt -LicensedNumberOfSeats $SomeLicensedNumberOfSeatsInt</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GResellerSubscriptionPlan">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GResellerSubscriptionPlan",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GResellerSubscriptionPlan")]
    public class SetGResellerSubscriptionPlan : ResellerBase
    {
        public enum PlanNameEnum
        {
            ANNUAL_MONTHLY_PAY, ANNUAL_YEARLY_PAY, FLEXIBLE, TRIAL
        }

        #region Properties

        /// <summary>
        /// <para type="description">Id of the Customer</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Id of the Customer")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Id of the subscription, which is unique for a customer</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Id of the subscription, which is unique for a customer")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// <para type="description">Name of the plan to change to.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of the plan to change to.")]
        public PlanNameEnum PlanName { get; set; }

        /// <summary>
        /// <para type="description">Number of seats to purchase. This is applicable only for a commitment plan.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Number of seats to purchase. This is applicable only for a commitment plan.")]
        public int NumberOfSeats { get; set; }

        /// <summary>
        /// <para type="description">Maximum number of seats that can be purchased. This needs to be provided only for a non-commitment plan. For a commitment plan it is decided by the contract.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Maximum number of seats that can be purchased. This needs to be provided only for a non-commitment plan. For a commitment plan it is decided by the contract.")]
        public int MaximumNumberOfSeats { get; set; }

        /// <summary>
        /// <para type="description">Purchase order id for your order tracking purposes.</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Purchase order id for your order tracking purposes.")]
        [ValidateNotNullOrEmpty]
        public string PurchaseOrderId { get; set; }

        /// <summary>
        /// <para type="description">Read-only field containing the current number of licensed seats for FLEXIBLE Google-Apps subscriptions and secondary subscriptions such as Google-Vault and Drive-storage.</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Read-only field containing the current number of licensed seats for FLEXIBLE Google-Apps subscriptions and secondary subscriptions such as Google-Vault and Drive-storage.")]
        public int LicensedNumberOfSeats { get; set; }

        /// <summary>
        /// <para type="description">External name of the deal code applicable for the subscription. This field is optional. If missing, the deal price plan won't be used.</para>
        /// </summary>
        [Parameter(Position = 7,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "External name of the deal code applicable for the subscription. This field is optional. If missing, the deal price plan won't be used.")]
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

    /// <summary>
    /// <para type="synopsis">Changes the renewal settings of a subscription</para>
    /// <para type="description">Changes the renewal settings of a subscription</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reseller API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GResellerSubscriptionRenewal -CustomerId $SomeCustomerIdString -SubscriptionId $SomeSubscriptionIdString -RenewalSettingsBody $SomeRenewalSettingsObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GResellerSubscriptionRenewal">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GResellerSubscriptionRenewal",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GResellerSubscriptionRenewal")]
    public class SetGResellerSubscriptionRenewal : ResellerBase
    {
        public enum RenewalTypeEnum
        {
            AUTO_RENEW_MONTHLY_PAY, AUTO_RENEW_YEARLY_PAY, CANCEL, RENEW_CURRENT_USERS_MONTHLY_PAY, RENEW_CURRENT_USERS_YEARLY_PAY, SWITCH_TO_PAY_AS_YOU_GO
        }

        #region Properties

        /// <summary>
        /// <para type="description">Id of the Customer</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Id of the Customer")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Id of the subscription, which is unique for a customer</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Id of the subscription, which is unique for a customer")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// <para type="description">Subscription renewal settings.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Subscription renewal settings.")]
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

    /// <summary>
    /// <para type="synopsis">Changes the seats configuration of a subscription</para>
    /// <para type="description">Changes the seats configuration of a subscription</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reseller API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GResellerSubscriptionSeats -CustomerId $SomeCustomerIdString -SubscriptionId $SomeSubscriptionIdString -NumberOfSeats $SomeNumberOfSeatsInt -MaximumNumberOfSeats $SomeMaximumNumberOfSeatsInt</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GResellerSubscriptionSeats">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GResellerSubscriptionSeats",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GResellerSubscriptionSeats")]
    public class SetGResellerSubscriptionSeats : ResellerBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Id of the Customer</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Id of the Customer")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Id of the subscription, which is unique for a customer</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Id of the subscription, which is unique for a customer")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// <para type="description">Number of seats to purchase. This is applicable only for a commitment plan.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Number of seats to purchase. This is applicable only for a commitment plan.")]
        public int NumberOfSeats { get; set; }

        /// <summary>
        /// <para type="description">Maximum number of seats that can be purchased. This needs to be provided only for a non-commitment plan. For a commitment plan it is decided by the contract.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Maximum number of seats that can be purchased. This needs to be provided only for a non-commitment plan. For a commitment plan it is decided by the contract.")]
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

            if (ShouldProcess("Reseller Subscription Seats", "Set-GResellerSubscriptionSeats"))
            {
                WriteObject(subscriptions.ChangeSeats(body, CustomerId, SubscriptionId));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Cancels/Downgrades a subscription.</para>
    /// <para type="description">Cancels/Downgrades a subscription.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reseller API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GResellerSubscription -CustomerId $SomeCustomerIdString -SubscriptionId $SomeSubscriptionIdString -DeletionType Cancel</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GResellerSubscription">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GResellerSubscription",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GResellerSubscription")]
    public class RemoveGResellerSubscription : ResellerBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Id of the Customer</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Id of the Customer")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Id of the subscription, which is unique for a customer</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Id of the subscription, which is unique for a customer")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// <para type="description">Whether the subscription is to be fully cancelled or downgraded</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Whether the subscription is to be fully cancelled or downgraded")]
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

    /// <summary>
    /// <para type="synopsis">Gets a subscription of the customer.</para>
    /// <para type="description">Gets a subscription of the customer.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reseller API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GResellerSubscription -CustomerId $SomeCustomerIdString -SubscriptionId $SomeSubscriptionIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GResellerSubscription -CustomerAuthToken $SomeCustomerAuthTokenString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GResellerSubscription">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GResellerSubscription",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GResellerSubscription",
          DefaultParameterSetName="one")]
    public class GetGResellerSubscription : ResellerBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">An auth token needed if the customer is not a resold customer of this reseller. Can be generated at https://www.google.com/a/cpanel/customer-domain/TransferToken.Optional.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "all",
            HelpMessage = "An auth token needed if the customer is not a resold customer of this reseller. Can be generated at https://www.google.com/a/cpanel/customer-domain/TransferToken.Optional.")]
        [ValidateNotNullOrEmpty]
        public string CustomerAuthToken { get; set; }

        /// <summary>
        /// <para type="description">Id of the Customer</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName="one",
            HelpMessage = "Id of the Customer")]
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "all",
            HelpMessage = "Id of the Customer")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Id of the subscription, which is unique for a customer</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "one",
            HelpMessage = "Id of the subscription, which is unique for a customer")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// <para type="description">Prefix of the customer's domain name by which the subscriptions should be filtered. Optional</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ParameterSetName = "all",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Prefix of the customer's domain name by which the subscriptions should be filtered. Optional")]
        [ValidateNotNullOrEmpty]
        public string CustomerNamePrefix { get; set; }

        /// <summary>
        /// <para type="description">Maximum number of results to return</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = false,
            ParameterSetName = "all",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Maximum number of results to return")]
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
                    MaxResults = 100
                };

                if (!string.IsNullOrWhiteSpace(CustomerAuthToken)) { properties.CustomerAuthToken = this.CustomerAuthToken; }
                if (!string.IsNullOrWhiteSpace(CustomerId)) { properties.CustomerId = this.CustomerId; }
                if (!string.IsNullOrWhiteSpace(CustomerNamePrefix)) { properties.CustomerNamePrefix = this.CustomerNamePrefix; }
                if (MaxResults.HasValue) { properties.TotalResults = this.MaxResults.Value; }

                if (ShouldProcess("Reseller Subscription", "Get-GResellerSubscription"))
                {
                    WriteObject(subscriptions.List(properties));
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates/Transfers a subscription for the customer.</para>
    /// <para type="description">Creates/Transfers a subscription for the customer.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reseller API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GResellerSubscription -CustomerId $SomeCustomerIdString -SubscriptionBody $SomeSubscriptionObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GResellerSubscription">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GResellerSubscription",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GResellerSubscription")]
    public class NewGResellerSubscription : ResellerBase
    {
        public enum StatusEnum
        {
            ACTIVE, BILLING_ACTIVATION_PENDING, CANCELLED, PENDING
        }

        #region Properties

        /// <summary>
        /// <para type="description">Id of the Customer</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Id of the Customer")]
        [ValidateNotNullOrEmpty]
        public string TargetCustomerId { get; set; }

        /// <summary>
        /// <para type="description">JSON template for a subscription.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "JSON template for a subscription.")]
        public Data.Subscription SubscriptionBody { get; set; }

        /// <summary>
        /// <para type="description">Billing method of this subscription.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Billing method of this subscription.")]
        [ValidateNotNullOrEmpty]
        public string BillingMethod { get; set; }

        /// <summary>
        /// <para type="description">Creation time of this subscription in milliseconds since Unix epoch.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Creation time of this subscription in milliseconds since Unix epoch.")]
        public long CreationTime { get; set; }

        /// <summary>
        /// <para type="description">Primary domain name of the customer</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Primary domain name of the customer")]
        [ValidateNotNullOrEmpty]
        public string CustomerDomain { get; set; }

        /// <summary>
        /// <para type="description">The id of the customer to whom the subscription belongs.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The id of the customer to whom the subscription belongs.")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">External name of the deal, if this subscription was provisioned under one. Otherwise this field will be empty.</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "External name of the deal, if this subscription was provisioned under one. Otherwise this field will be empty.")]
        [ValidateNotNullOrEmpty]
        public string DealCode { get; set; }

        /// <summary>
        /// <para type="description">End time of the commitment interval in milliseconds since Unix epoch.</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "End time of the commitment interval in milliseconds since Unix epoch.")]
        public long PlanCommitmentIntervalEndTime { get; set; }

        /// <summary>
        /// <para type="description">Start time of the commitment interval in milliseconds since Unix epoch.</para>
        /// </summary>
        [Parameter(Position = 7,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Start time of the commitment interval in milliseconds since Unix epoch.")]
        public long PlanCommitmentIntervalStartTime { get; set; }

        /// <summary>
        /// <para type="description">Whether the plan is a commitment plan or not.</para>
        /// </summary>
        [Parameter(Position = 8,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Whether the plan is a commitment plan or not.")]
        public bool IsCommitmentPlan { get; set; }

        /// <summary>
        /// <para type="description">The plan name of this subscription's plan.</para>
        /// </summary>
        [Parameter(Position = 9,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The plan name of this subscription's plan.")]
        [ValidateNotNullOrEmpty]
        public string PlanName { get; set; }

        /// <summary>
        /// <para type="description">Purchase order id for your order tracking purposes.</para>
        /// </summary>
        [Parameter(Position = 10,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Purchase order id for your order tracking purposes.")]
        [ValidateNotNullOrEmpty]
        public string PurchaseOrderId { get; set; }

        /// <summary>
        /// <para type="description">Subscription renewal type.</para>
        /// </summary>
        [Parameter(Position = 11,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Subscription renewal type.")]
        [ValidateNotNullOrEmpty]
        public string RenewalType { get; set; }

        /// <summary>
        /// <para type="description">Ui url for subscription resource.</para>
        /// </summary>
        [Parameter(Position = 12,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Ui url for subscription resource.")]
        [ValidateNotNullOrEmpty]
        public string ResourceUiUrl { get; set; }

        /// <summary>
        /// <para type="description">Number of seats to purchase. This is applicable only for a commitment plan.</para>
        /// </summary>
        [Parameter(Position = 13,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Number of seats to purchase. This is applicable only for a commitment plan.")]
        public int NumberOfSeats { get; set; }

        /// <summary>
        /// <para type="description">Maximum number of seats that can be purchased. This needs to be provided only for a non-commitment plan. For a commitment plan it is decided by the contract.</para>
        /// </summary>
        [Parameter(Position = 14,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Maximum number of seats that can be purchased. This needs to be provided only for a non-commitment plan. For a commitment plan it is decided by the contract.")]
        public int MaximumNumberOfSeats { get; set; }

        /// <summary>
        /// <para type="description">Read-only field containing the current number of licensed seats for FLEXIBLE Google-Apps subscriptions and secondary subscriptions such as Google-Vault and Drive-storage.</para>
        /// </summary>
        [Parameter(Position = 15,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Read-only field containing the current number of licensed seats for FLEXIBLE Google-Apps subscriptions and secondary subscriptions such as Google-Vault and Drive-storage.")]
        public int LicensedNumberOfSeats { get; set; }

        /// <summary>
        /// <para type="description">Name of the sku for which this subscription is purchased.</para>
        /// </summary>
        [Parameter(Position = 16,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of the sku for which this subscription is purchased.")]
        [ValidateNotNullOrEmpty]
        public string SkuId { get; set; }

        /// <summary>
        /// <para type="description">Status of the subscription.</para>
        /// </summary>
        [Parameter(Position = 17,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Status of the subscription.")]
        [ValidateNotNullOrEmpty]
        public StatusEnum Status { get; set; }

        /// <summary>
        /// <para type="description">The id of the subscription.</para>
        /// </summary>
        [Parameter(Position = 18,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The id of the subscription.")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// <para type="description">Minimum number of seats listed in the transfer order for this product. For example, if the customer has 20 users, the reseller cannot place a transfer order of 15 seats. The minimum is 20 seats.</para>
        /// </summary>
        [Parameter(Position = 19,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Minimum number of seats listed in the transfer order for this product. For example, if the customer has 20 users, the reseller cannot place a transfer order of 15 seats. The minimum is 20 seats.")]
        public int MinimumTransferableSeats { get; set; }

        /// <summary>
        /// <para type="description">Time when transfer token or intent to transfer will expire.</para>
        /// </summary>
        [Parameter(Position = 20,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Time when transfer token or intent to transfer will expire.")]
        public long TransferabilityExpirationTime { get; set; }

        /// <summary>
        /// <para type="description">Whether the subscription is in trial.</para>
        /// </summary>
        [Parameter(Position = 21,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Whether the subscription is in trial.")]
        public bool IsInTrial { get; set; }

        /// <summary>
        /// <para type="description">End time of the trial in milliseconds since Unix epoch.</para>
        /// </summary>
        [Parameter(Position = 22,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "End time of the trial in milliseconds since Unix epoch.")]
        public long TrialEndTime { get; set; }

        /// <summary>
        /// <para type="description">An auth token needed for transferring a subscription. Can be generated at https://www.google.com/a/cpanel/customer-domain/TransferToken. Optional.</para>
        /// </summary>
        [Parameter(Position = 23,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "An auth token needed for transferring a subscription. Can be generated at https://www.google.com/a/cpanel/customer-domain/TransferToken. Optional.")]
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
                CustomerAuthToken = CustomerAuthToken
            };

            if (ShouldProcess("Reseller Subscription", "New-GResellerSubscription"))
            {
                WriteObject(subscriptions.Insert(body, TargetCustomerId, properties));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Starts paid service of a trial subscription</para>
    /// <para type="description">Starts paid service of a trial subscription</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reseller API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\Start-GResellerSubscriptionPaidService -CustomerId $SomeCustomerIdString -SubscriptionId $SomeSubscriptionIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Start-GResellerSubscriptionPaidService">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "GResellerSubscriptionPaidService",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Start-GResellerSubscriptionPaidService")]
    public class StartGResellerSubscriptionPaidService : ResellerBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Id of the Customer</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Id of the Customer")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Id of the subscription, which is unique for a customer</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Id of the subscription, which is unique for a customer")]
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

    /// <summary>
    /// <para type="synopsis">Suspends an active subscription</para>
    /// <para type="description">Suspends an active subscription</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reseller API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Suspend-GResellerSubscription -CustomerId $SomeCustomerIdString -SubscriptionId $SomeSubscriptionIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Suspend-GResellerSubscription">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsLifecycle.Suspend, "GResellerSubscription",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Suspend-GResellerSubscription")]
    public class SuspendGResellerSubscription : ResellerBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Id of the Customer</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Id of the Customer")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Id of the subscription, which is unique for a customer</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Id of the subscription, which is unique for a customer")]
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