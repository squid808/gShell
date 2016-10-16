using gShell.Cmdlets.Utilities.OAuth2;

namespace gShell.Cmdlets.DataTransfer{

    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using datatransfer_v1 = Google.Apis.admin.DataTransfer.datatransfer_v1;
    using Data = Google.Apis.admin.DataTransfer.datatransfer_v1.Data;

    using gShell.dotNet.Utilities;
    using gShell.dotNet.Utilities.OAuth2;
    using gDataTransfer = gShell.dotNet.DataTransfer;

    public abstract class DataTransferBase : AuthenticatedCmdletBase
    {

        #region Properties

        protected static gDataTransfer mainBase { get; set; }

        public Applications applications { get; set; }

        public Transfers transfers { get; set; }

        /// <summary>
        /// Required to be able to store and retrieve the mainBase from the ServiceWrapperDictionary
        /// </summary>
        protected override Type mainBaseType { get { return typeof(gDataTransfer); } }
        #endregion

        #region Constructors
        public DataTransferBase()
        {
            mainBase = new gDataTransfer();

            ServiceWrapperDictionary[mainBaseType] = mainBase;

            applications = new Applications();
            transfers = new Transfers();
        }
        #endregion

        #region Wrapped Methods



        #region Applications

        public class Applications
        {

            public Google.Apis.admin.DataTransfer.datatransfer_v1.Data.Application Get (long ApplicationId)
            {

                return mainBase.applications.Get(ApplicationId);
            }




            public List<Google.Apis.admin.DataTransfer.datatransfer_v1.Data.ApplicationsListResponse> List(gDataTransfer.Applications.ApplicationsListProperties properties= null)
            {

                properties = (properties != null) ? properties : new gDataTransfer.Applications.ApplicationsListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return mainBase.applications.List(properties);
            }
        }
        #endregion



        #region Transfers

        public class Transfers
        {






            public Google.Apis.admin.DataTransfer.datatransfer_v1.Data.DataTransfer Get (string DataTransferId)
            {

                return mainBase.transfers.Get(DataTransferId);
            }





            public Google.Apis.admin.DataTransfer.datatransfer_v1.Data.DataTransfer Insert (Google.Apis.admin.DataTransfer.datatransfer_v1.Data.DataTransfer DataTransferBody)
            {

                return mainBase.transfers.Insert(DataTransferBody);
            }




            public List<Google.Apis.admin.DataTransfer.datatransfer_v1.Data.DataTransfersListResponse> List(gDataTransfer.Transfers.TransfersListProperties properties= null)
            {

                properties = (properties != null) ? properties : new gDataTransfer.Transfers.TransfersListProperties();
                properties.startProgressBar = StartProgressBar;
                properties.updateProgressBar = UpdateProgressBar;

                return mainBase.transfers.List(properties);
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

    using datatransfer_v1 = Google.Apis.admin.DataTransfer.datatransfer_v1;
    using Data = Google.Apis.admin.DataTransfer.datatransfer_v1.Data;

    public class DataTransfer : ServiceWrapper<datatransfer_v1.DataTransferService>, IServiceWrapper<Google.Apis.Services.IClientService>
    {

        protected override bool worksWithGmail { get { return false; } }

        protected override datatransfer_v1.DataTransferService CreateNewService(string domain, AuthenticatedUserInfo authInfo, string serviceAccountUser = null)
        {
            return new datatransfer_v1.DataTransferService(OAuth2Base.GetInitializer(domain, authInfo));
        }

        public override string apiNameAndVersion { get { return "admin:datatransfer_v1"; } }

        public Applications applications{ get; set; }
        public Transfers transfers{ get; set; }

        public DataTransfer() //public Reports()
        {

            applications = new Applications();
            transfers = new Transfers();
        }




        public class Applications
        {



            public class ApplicationsListProperties
            {
                public     string     customerId = null; //test
                public int maxResults = 500;

                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }


            public Google.Apis.admin.DataTransfer.datatransfer_v1.Data.Application Get (long ApplicationId)
            {
                return GetService().Applications.Get(ApplicationId).Execute();
            }

            public List<Google.Apis.admin.DataTransfer.datatransfer_v1.Data.ApplicationsListResponse> List(
                ApplicationsListProperties properties= null)
            {
                var results = new List<Google.Apis.admin.DataTransfer.datatransfer_v1.Data.ApplicationsListResponse>();

                datatransfer_v1.ApplicationsResource.ListRequest request = GetService().Applications.List(
            );

                if (properties != null)
                {
                    request.CustomerId = properties.customerId;
                    request.MaxResults = properties.maxResults;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering Applications",
                        string.Format("-Collecting Applications 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.admin.DataTransfer.datatransfer_v1.Data.ApplicationsListResponse pagedResult = request.Execute();

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
                            properties.updateProgressBar(5, 10, "Gathering Applications",
                                    string.Format("-Collecting Applications {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering Applications",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

        }


        public class Transfers
        {



            public class TransfersListProperties
            {
                public     string     customerId = null; //test
                public int maxResults = 500;
                public     string     newOwnerUserId = null; //test
                public     string     oldOwnerUserId = null; //test

                public     string     status = null; //test
                public Action<string, string> startProgressBar = null;
                public Action<int, int, string, string> updateProgressBar = null;
                public int totalResults = 0;
            }


            public Google.Apis.admin.DataTransfer.datatransfer_v1.Data.DataTransfer Get (string DataTransferId)
            {
                return GetService().Transfers.Get(DataTransferId).Execute();
            }

            public Google.Apis.admin.DataTransfer.datatransfer_v1.Data.DataTransfer Insert (Google.Apis.admin.DataTransfer.datatransfer_v1.Data.DataTransfer DataTransferBody)
            {
                return GetService().Transfers.Insert(DataTransferBody).Execute();
            }

            public List<Google.Apis.admin.DataTransfer.datatransfer_v1.Data.DataTransfersListResponse> List(
                TransfersListProperties properties= null)
            {
                var results = new List<Google.Apis.admin.DataTransfer.datatransfer_v1.Data.DataTransfersListResponse>();

                datatransfer_v1.TransfersResource.ListRequest request = GetService().Transfers.List(
            );

                if (properties != null)
                {
                    request.CustomerId = properties.customerId;
                    request.MaxResults = properties.maxResults;
                    request.NewOwnerUserId = properties.newOwnerUserId;
                    request.OldOwnerUserId = properties.oldOwnerUserId;
                    request.Status = properties.status;

                }

                if (null != properties.startProgressBar)
                {
                    properties.startProgressBar("Gathering Transfers",
                        string.Format("-Collecting Transfers 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.admin.DataTransfer.datatransfer_v1.Data.DataTransfersListResponse pagedResult = request.Execute();

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
                            properties.updateProgressBar(5, 10, "Gathering Transfers",
                                    string.Format("-Collecting Transfers {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.updateProgressBar)
                    {
                        properties.updateProgressBar(1, 2, "Gathering Transfers",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

        }

    }
}