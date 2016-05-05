namespace gShell.Cmdlets.Licensing{

    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using v1 = Google.Apis.Licensing.v1;
    using Data = Google.Apis.Licensing.v1.Data;

    using gShell.dotNet.Utilities;
    using gShell.dotNet.Utilities.OAuth2;
    using gLicensing = gShell.dotNet.Licensing;

    public abstract class LicensingBase : OAuth2CmdletBase
    {

        #region Properties
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        protected static gLicensing mainBase { get; set; }

        public LicenseAssignments licenseAssignments { get; set; }

        protected override string apiNameAndVersion { get { return mainBase.apiNameAndVersion; } }

        protected static string gShellServiceAccount { get; set; }
        #endregion

        #region Constructors
        public LicensingBase()
        {
            mainBase = new gLicensing();

            licenseAssignments = new LicenseAssignments();
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



        #region LicenseAssignments

        public class LicenseAssignments
        {




            public void Delete (string

             productId, string

             skuId, string

             userId)
            {

                mainBase.licenseAssignments.Delete(productId, skuId, userId, gShellServiceAccount);
            }


            public Google.Apis.Licensing.v1.Data.LicenseAssignment Get (string

             productId, string

             skuId, string

             userId)
            {

                return mainBase.licenseAssignments.Get(productId, skuId, userId, gShellServiceAccount);
            }


            public Google.Apis.Licensing.v1.Data.LicenseAssignment Insert (Google.Apis.Licensing.v1.Data.LicenseAssignmentInsert body, string

             productId, string

             skuId)
            {

                return mainBase.licenseAssignments.Insert(body, productId, skuId, gShellServiceAccount);
            }


            public List<Google.Apis.Licensing.v1.Data.LicenseAssignmentList> ListForProduct(string

             productId, string

             customerId, gLicensing.LicenseAssignments.LicenseAssignmentsListForProductProperties properties = null)
            {

                properties = (properties != null) ? properties : new gLicensing.LicenseAssignments.LicenseAssignmentsListForProductProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return mainBase.licenseAssignments.ListForProduct(productId, customerId, properties);
            }


            public List<Google.Apis.Licensing.v1.Data.LicenseAssignmentList> ListForProductAndSku(string

             productId, string

             skuId, string

             customerId, gLicensing.LicenseAssignments.LicenseAssignmentsListForProductAndSkuProperties properties = null)
            {

                properties = (properties != null) ? properties : new gLicensing.LicenseAssignments.LicenseAssignmentsListForProductAndSkuProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return mainBase.licenseAssignments.ListForProductAndSku(productId, skuId, customerId, properties);
            }


            public Google.Apis.Licensing.v1.Data.LicenseAssignment Patch (Google.Apis.Licensing.v1.Data.LicenseAssignment body, string

             productId, string

             skuId, string

             userId)
            {

                return mainBase.licenseAssignments.Patch(body, productId, skuId, userId, gShellServiceAccount);
            }


            public Google.Apis.Licensing.v1.Data.LicenseAssignment Update (Google.Apis.Licensing.v1.Data.LicenseAssignment body, string

             productId, string

             skuId, string

             userId)
            {

                return mainBase.licenseAssignments.Update(body, productId, skuId, userId, gShellServiceAccount);
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

    using v1 = Google.Apis.Licensing.v1;
    using Data = Google.Apis.Licensing.v1.Data;

    public class Licensing : ServiceWrapper<v1.LicensingService>
    {

        protected override bool worksWithGmail { get { return true; } }

        protected override v1.LicensingService CreateNewService(string domain, AuthenticatedUserInfo authInfo, string gShellServiceAccount = null)
        {
            return new v1.LicensingService(OAuth2Base.GetInitializer(domain, authInfo, gShellServiceAccount));
        }

        public override string apiNameAndVersion { get { return "licensing:v1"; } }

        public LicenseAssignments licenseAssignments{ get; set; }

        public Licensing() //public Reports()
        {

            licenseAssignments = new LicenseAssignments();
        }




        public class LicenseAssignments
        {



            public class LicenseAssignmentsListForProductProperties
            {
                public int maxResults = 1000;

                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }

            public class LicenseAssignmentsListForProductAndSkuProperties
            {
                public int maxResults = 1000;

                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }


            public void Delete (string

             productId, string

             skuId, string

             userId, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).LicenseAssignments.Delete(productId, skuId, userId).Execute();
            }

            public Google.Apis.Licensing.v1.Data.LicenseAssignment Get (string

             productId, string

             skuId, string

             userId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).LicenseAssignments.Get(productId, skuId, userId).Execute();
            }

            public Google.Apis.Licensing.v1.Data.LicenseAssignment Insert (Google.Apis.Licensing.v1.Data.LicenseAssignmentInsert body, string

             productId, string

             skuId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).LicenseAssignments.Insert(body, productId, skuId).Execute();
            }

            public List<Google.Apis.Licensing.v1.Data.LicenseAssignmentList> ListForProduct(
                string     productId, string     customerId, LicenseAssignmentsListForProductProperties properties = null, string gShellServiceAccount = null)
            {
                var results = new List<Google.Apis.Licensing.v1.Data.LicenseAssignmentList>();

                v1.LicenseAssignmentsResource.ListForProductRequest request = GetService(gShellServiceAccount).LicenseAssignments.ListForProduct(
            productId, customerId);

                if (properties != null)
                {
                    request.MaxResults = properties.maxResults;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering LicenseAssignments",
                        string.Format("-Collecting LicenseAssignments 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.Licensing.v1.Data.LicenseAssignmentList pagedResult = request.Execute();

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
                            properties.updateProgressBar(5, 10, "Gathering LicenseAssignments",
                                    string.Format("-Collecting LicenseAssignments {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering LicenseAssignments",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            public List<Google.Apis.Licensing.v1.Data.LicenseAssignmentList> ListForProductAndSku(
                string     productId, string     skuId, string     customerId, LicenseAssignmentsListForProductAndSkuProperties properties = null, string gShellServiceAccount = null)
            {
                var results = new List<Google.Apis.Licensing.v1.Data.LicenseAssignmentList>();

                v1.LicenseAssignmentsResource.ListForProductAndSkuRequest request = GetService(gShellServiceAccount).LicenseAssignments.ListForProductAndSku(
            productId, skuId, customerId);

                if (properties != null)
                {
                    request.MaxResults = properties.maxResults;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering LicenseAssignments",
                        string.Format("-Collecting LicenseAssignments 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.Licensing.v1.Data.LicenseAssignmentList pagedResult = request.Execute();

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
                            properties.updateProgressBar(5, 10, "Gathering LicenseAssignments",
                                    string.Format("-Collecting LicenseAssignments {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering LicenseAssignments",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            public Google.Apis.Licensing.v1.Data.LicenseAssignment Patch (Google.Apis.Licensing.v1.Data.LicenseAssignment body, string

             productId, string

             skuId, string

             userId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).LicenseAssignments.Patch(body, productId, skuId, userId).Execute();
            }

            public Google.Apis.Licensing.v1.Data.LicenseAssignment Update (Google.Apis.Licensing.v1.Data.LicenseAssignment body, string

             productId, string

             skuId, string

             userId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).LicenseAssignments.Update(body, productId, skuId, userId).Execute();
            }

        }

    }
}