using System;
using System.Management.Automation;
using System.Collections.Generic;

using Google.Apis.Services;
using discovery_v1 = Google.Apis.Discovery.v1;
using Data = Google.Apis.Discovery.v1.Data;

using gShell.dotNet.Utilities;
using gShell.dotNet.Utilities.OAuth2;
using gDiscovery = gShell.dotNet.Discovery;

namespace gShell.Cmdlets.Discovery
{
    /// <summary>
    /// The base class for all Google Discovery API calls within the PowerShell Cmdlets.
    /// </summary>
    public class DiscoveryBase : OAuth2CmdletBase
    {
        #region Properties
        protected static gDiscovery gdiscovery = new gDiscovery();
        protected Apis apis = new Apis();

        protected override string apiNameAndVersion { get { return gdiscovery.apiNameAndVersion; } }
        #endregion

        #region PowerShell Methods
        protected override void BeginProcessing() { }
        #endregion

        #region Authentication & Processing
        /// <summary>
        /// A method specific to each inherited object, called during authentication. Must be implemented.
        /// </summary>
        protected override AuthenticationInfo Authenticate() { return null; }
        #endregion

        #region Apis
		public class Apis {
            public Data.DirectoryList List (gDiscovery.Apis.DiscoveryListProperties properties = null) 
            {
                return gdiscovery.apis.List(properties);
            }

            public Data.RestDescription RestData (string api, string version) 
            {
                return gdiscovery.apis.RestData(api, version);
            }
        }
    	#endregion
    }

    [Cmdlet(VerbsCommon.Get, "GDiscoveryList",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GDiscoveryList")]
    public class GetGDiscoveryList : DiscoveryBase
    {
        #region Properties
        [Parameter(Position=0,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1,
            Mandatory = false)]
        public SwitchParameter Preferred { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Report Activity", "Get-GRepActivity"))
            {
                var properties = new gDiscovery.Apis.DiscoveryListProperties();

                if (!string.IsNullOrWhiteSpace(Name))
                {
                    properties.name = Name;
                }

                if (Preferred)
                {
                    properties.preferred = true;
                }

                WriteObject(gdiscovery.apis.List(properties).Items);
            }
        }
    }

    [Cmdlet(VerbsCommon.Get, "GDiscoveryRestData",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GDiscoveryRestData")]
    public class GetGDiscoveryRestData : DiscoveryBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Api { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Report Activity", "Get-GRepActivity"))
            {
                WriteObject(gdiscovery.apis.RestData(Api, Version));
            }
        }
    }
}
