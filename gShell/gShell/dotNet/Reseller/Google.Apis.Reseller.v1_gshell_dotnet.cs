namespace gShell.Cmdlets.Reseller{

    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using v1 = Google.Apis.Reseller.v1;
    using Data = Google.Apis.Reseller.v1.Data;

    using gShell.dotNet.Utilities;
    using gShell.dotNet.Utilities.OAuth2;
    using gReseller = gShell.dotNet.Reseller;

    public abstract class ResellerBase : OAuth2CmdletBase
    {

        #region Properties
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        protected static gReseller mainBase { get; set; }

        public Customers customers { get; set; }
        public Subscriptions subscriptions { get; set; }

        protected override string apiNameAndVersion { get { return mainBase.apiNameAndVersion; } }

        protected static string gShellServiceAccount { get; set; }
        #endregion

        #region Constructors
        public ResellerBase()
        {
            mainBase = new gReseller();

            customers = new Customers();
            subscriptions = new Subscriptions();
        }
        #endregion

        #region PowerShell Methods
        protected override void BeginProcessing()
        {
            var secrets = CheckForClientSecrets();
            if (secrets != null)
            {
                IEnumerable<string> scopes = EnsureScopesExist(Domain);
                Domain = mainBase.BuildService(Authenticate(scopes, secrets, Domain), gShellServiceAccount).domain;

                GWriteProgress = new gWriteProgress(WriteProgress);
            }
            else
            {
                WriteError(new ErrorRecord(null, (new Exception(
                    "Client Secrets must be set before running cmdlets. Run 'Get-Help "
                    + "Set-gShellClientSecrets -online' for more information."))));
            }
        }

        protected override void EndProcessing()
        {
            gShellServiceAccount = string.Empty;
        }

        protected override void StopProcessing()
        {
            gShellServiceAccount = string.Empty;
        }
        #endregion

        #region Authentication & Processing
        protected override AuthenticatedUserInfo Authenticate(IEnumerable<string> Scopes, ClientSecrets Secrets, string Domain = null)
        {
            return mainBase.Authenticate(apiNameAndVersion, Scopes, Secrets, Domain);
        }
        #endregion

        #region Wrapped Methods



        #region Customers

        public class Customers
        {




            public Google.Apis.Reseller.v1.Data.Customer Get (string

             customerId)
            {

                return mainBase.customers.Get(customerId, gShellServiceAccount);
            }


            public Google.Apis.Reseller.v1.Data.Customer Insert (Google.Apis.Reseller.v1.Data.Customer body, gReseller.Customers.CustomersInsertProperties properties = null)
            {

                properties = (properties != null) ? properties : new gReseller.Customers.CustomersInsertProperties();

                return mainBase.customers.Insert(body, properties, gShellServiceAccount);
            }


            public Google.Apis.Reseller.v1.Data.Customer Patch (Google.Apis.Reseller.v1.Data.Customer body, string

             customerId)
            {

                return mainBase.customers.Patch(body, customerId, gShellServiceAccount);
            }


            public Google.Apis.Reseller.v1.Data.Customer Update (Google.Apis.Reseller.v1.Data.Customer body, string

             customerId)
            {

                return mainBase.customers.Update(body, customerId, gShellServiceAccount);
            }
        }

        #endregion



        #region Subscriptions

        public class Subscriptions
        {




            public Google.Apis.Reseller.v1.Data.Subscription Activate (string

             customerId, string

             subscriptionId)
            {

                return mainBase.subscriptions.Activate(customerId, subscriptionId, gShellServiceAccount);
            }


            public Google.Apis.Reseller.v1.Data.Subscription ChangePlan (Google.Apis.Reseller.v1.Data.ChangePlanRequest body, string

             customerId, string

             subscriptionId)
            {

                return mainBase.subscriptions.ChangePlan(body, customerId, subscriptionId, gShellServiceAccount);
            }


            public Google.Apis.Reseller.v1.Data.Subscription ChangeRenewalSettings (Google.Apis.Reseller.v1.Data.RenewalSettings body, string

             customerId, string

             subscriptionId)
            {

                return mainBase.subscriptions.ChangeRenewalSettings(body, customerId, subscriptionId, gShellServiceAccount);
            }


            public Google.Apis.Reseller.v1.Data.Subscription ChangeSeats (Google.Apis.Reseller.v1.Data.Seats body, string

             customerId, string

             subscriptionId)
            {

                return mainBase.subscriptions.ChangeSeats(body, customerId, subscriptionId, gShellServiceAccount);
            }


            public void Delete (string

             customerId, string

             subscriptionId, v1.SubscriptionsResource.DeleteRequest.DeletionTypeEnum

             deletionType)
            {

                mainBase.subscriptions.Delete(customerId, subscriptionId, deletionType, gShellServiceAccount);
            }


            public Google.Apis.Reseller.v1.Data.Subscription Get (string

             customerId, string

             subscriptionId)
            {

                return mainBase.subscriptions.Get(customerId, subscriptionId, gShellServiceAccount);
            }


            public Google.Apis.Reseller.v1.Data.Subscription Insert (Google.Apis.Reseller.v1.Data.Subscription body, string

             customerId, gReseller.Subscriptions.SubscriptionsInsertProperties properties = null)
            {

                properties = (properties != null) ? properties : new gReseller.Subscriptions.SubscriptionsInsertProperties();

                return mainBase.subscriptions.Insert(body, customerId, properties, gShellServiceAccount);
            }


            public List<Google.Apis.Reseller.v1.Data.Subscriptions> List(gReseller.Subscriptions.SubscriptionsListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gReseller.Subscriptions.SubscriptionsListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return mainBase.subscriptions.List(properties);
            }


            public Google.Apis.Reseller.v1.Data.Subscription StartPaidService (string

             customerId, string

             subscriptionId)
            {

                return mainBase.subscriptions.StartPaidService(customerId, subscriptionId, gShellServiceAccount);
            }


            public Google.Apis.Reseller.v1.Data.Subscription Suspend (string

             customerId, string

             subscriptionId)
            {

                return mainBase.subscriptions.Suspend(customerId, subscriptionId, gShellServiceAccount);
            }
        }

        #endregion

        #endregion

    }
}



namespace gShell.dotNet
{
    using System;
    using System.Collections.Generic;

    using gShell.dotNet;
    using gShell.dotNet.Utilities.OAuth2;

    using v1 = Google.Apis.Reseller.v1;
    using Data = Google.Apis.Reseller.v1.Data;

    public class Reseller : ServiceWrapper<v1.ResellerService>
    {

        protected override bool worksWithGmail { get { return true; } }

        protected override v1.ResellerService CreateNewService(string domain, AuthenticatedUserInfo authInfo, string gShellServiceAccount = null)
        {
            return new v1.ResellerService(OAuth2Base.GetInitializer(domain, authInfo, gShellServiceAccount));
        }

        public override string apiNameAndVersion { get { return "reseller:v1"; } }

        public Customers customers{ get; set; }
        public Subscriptions subscriptions{ get; set; }

        public Reseller() //public Reports()
        {

            customers = new Customers();
            subscriptions = new Subscriptions();
        }




        public class Customers
        {



            public class CustomersInsertProperties
            {
                public     string     customerAuthToken = null; //test
            }


            public Google.Apis.Reseller.v1.Data.Customer Get (string

             customerId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Customers.Get(customerId).Execute();
            }

            public Google.Apis.Reseller.v1.Data.Customer Insert (Google.Apis.Reseller.v1.Data.Customer body, CustomersInsertProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Customers.Insert(body).Execute();
            }

            public Google.Apis.Reseller.v1.Data.Customer Patch (Google.Apis.Reseller.v1.Data.Customer body, string

             customerId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Customers.Patch(body, customerId).Execute();
            }

            public Google.Apis.Reseller.v1.Data.Customer Update (Google.Apis.Reseller.v1.Data.Customer body, string

             customerId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Customers.Update(body, customerId).Execute();
            }

        }


        public class Subscriptions
        {



            public class SubscriptionsInsertProperties
            {
                public     string     customerAuthToken = null; //test
            }

            public class SubscriptionsListProperties
            {
                public     string     customerAuthToken = null; //test
                public     string     customerId = null; //test
                public     string     customerNamePrefix = null; //test
                public int maxResults = 100;

                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }


            public Google.Apis.Reseller.v1.Data.Subscription Activate (string

             customerId, string

             subscriptionId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Subscriptions.Activate(customerId, subscriptionId).Execute();
            }

            public Google.Apis.Reseller.v1.Data.Subscription ChangePlan (Google.Apis.Reseller.v1.Data.ChangePlanRequest body, string

             customerId, string

             subscriptionId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Subscriptions.ChangePlan(body, customerId, subscriptionId).Execute();
            }

            public Google.Apis.Reseller.v1.Data.Subscription ChangeRenewalSettings (Google.Apis.Reseller.v1.Data.RenewalSettings body, string

             customerId, string

             subscriptionId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Subscriptions.ChangeRenewalSettings(body, customerId, subscriptionId).Execute();
            }

            public Google.Apis.Reseller.v1.Data.Subscription ChangeSeats (Google.Apis.Reseller.v1.Data.Seats body, string

             customerId, string

             subscriptionId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Subscriptions.ChangeSeats(body, customerId, subscriptionId).Execute();
            }

            public void Delete (string

             customerId, string

             subscriptionId, v1.SubscriptionsResource.DeleteRequest.DeletionTypeEnum

             deletionType, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).Subscriptions.Delete(customerId, subscriptionId, deletionType).Execute();
            }

            public Google.Apis.Reseller.v1.Data.Subscription Get (string

             customerId, string

             subscriptionId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Subscriptions.Get(customerId, subscriptionId).Execute();
            }

            public Google.Apis.Reseller.v1.Data.Subscription Insert (Google.Apis.Reseller.v1.Data.Subscription body, string

             customerId, SubscriptionsInsertProperties properties = null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Subscriptions.Insert(body, customerId).Execute();
            }

            public List<Google.Apis.Reseller.v1.Data.Subscriptions> List(
                SubscriptionsListProperties properties = null, string gShellServiceAccount = null)
            {
                var results = new List<Google.Apis.Reseller.v1.Data.Subscriptions>();

                v1.SubscriptionsResource.ListRequest request = GetService(gShellServiceAccount).Subscriptions.List(
            );

                if (properties != null)
                {
                    request.CustomerAuthToken = properties.customerAuthToken;
                    request.CustomerId = properties.customerId;
                    request.CustomerNamePrefix = properties.customerNamePrefix;
                    request.MaxResults = properties.maxResults;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering Subscriptions",
                        string.Format("-Collecting Subscriptions 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.Reseller.v1.Data.Subscriptions pagedResult = request.Execute();

                if (pagedResult != null)
                {
                    results.Add(pagedResult);

                    while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                        pagedResult.NextPageToken != request.PageToken &&
                    (properties.totalResults == 0 || results.Count < properties.totalResults))
                    {
                        request.PageToken = pagedResult.NextPageToken;

                        if (null != properties.updateProgressBar)
                        {
                            properties.updateProgressBar(5, 10, "Gathering Subscriptions",
                                    string.Format("-Collecting Subscriptions {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering Subscriptions",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            public Google.Apis.Reseller.v1.Data.Subscription StartPaidService (string

             customerId, string

             subscriptionId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Subscriptions.StartPaidService(customerId, subscriptionId).Execute();
            }

            public Google.Apis.Reseller.v1.Data.Subscription Suspend (string

             customerId, string

             subscriptionId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Subscriptions.Suspend(customerId, subscriptionId).Execute();
            }

        }

    }
}