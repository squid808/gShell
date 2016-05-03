using System;
using System.Collections.Generic;
using discovery_v1 = Google.Apis.Discovery.v1;
using Data = Google.Apis.Discovery.v1.Data;
using gShell.dotNet;
using gShell.dotNet.Utilities.OAuth2;

namespace gShell.dotNet
{
    public class Discovery : ServiceWrapper<discovery_v1.DiscoveryService>
    {
        #region Inherited Members
        
        /// <summary>
        /// Indicates if this set of services will work with Gmail (as opposed to Google Apps). 
        /// This will cause authentication to fail if false and the user attempts to authenticate with
        /// a gmail address.
        /// </summary>
        protected override bool worksWithGmail { get { return true; } }
        
        /// <summary>
        /// Initialize and return a new DiscoveryService
        /// </summary>
        protected override discovery_v1.DiscoveryService CreateNewService(string domain, AuthenticatedUserInfo authInfo, string serviceAcctUser)
        {
            return new discovery_v1.DiscoveryService(OAuth2Base.GetInitializer());
        }

        public override string apiNameAndVersion { get { return "discovery:v1"; } }

        #endregion

        #region Properties
        
        public Apis apis = new Apis();

        public static discovery_v1.DiscoveryService service
        {
            get
            {
                if (_service == null)
                {
                    _service = new discovery_v1.DiscoveryService(
                        new gShell.dotNet.CustomSerializer.Json.gJsonInitializer());
                }

                return _service;
            }
        }

        private static discovery_v1.DiscoveryService _service;

        #endregion

        #region Wrapped Methods

        public class Apis
        {
            public class DiscoveryListProperties
            {
                public string name = null;
                public bool preferred = false;
            }

            public Data.DirectoryList List (DiscoveryListProperties properties = null)
            {
                discovery_v1.ApisResource.ListRequest request = service.Apis.List();

                if (properties != null)
                {
                    request.Name = properties.name;
                    request.Preferred = properties.preferred;
                }

                return request.Execute();
            }

            public Data.RestDescription RestData(string api, string version)
            {
                return service.Apis.GetRest(api, version).Execute();
            }
        }

        #endregion

    }
}
