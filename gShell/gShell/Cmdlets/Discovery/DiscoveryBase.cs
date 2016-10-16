using System.Management.Automation;
using System.Collections.Generic;
using gShell.Cmdlets.Utilities.OAuth2;
using Google.Apis.Auth.OAuth2;
using Data = Google.Apis.Discovery.v1.Data;

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
        protected override AuthenticatedUserInfo Authenticate(IEnumerable<string> Scopes, ClientSecrets Secrets, string Domain=null) { return null; }
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

    /// <summary>
    /// <para type="synopsis">Retrieve the list of APIs supported at this endpoint.</para>
    /// <para type="description">Retrieve the list of APIs supported at this endpoint.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Discovery API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GDiscoveryList</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GDiscoveryList">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GDiscoveryList",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GDiscoveryList")]
    public class GetGDiscoveryBaseListCommand : DiscoveryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Only include APIs with the given name.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Only include APIs with the given name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// <para type="description">Return only the preferred version of an API.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Return only the preferred version of an API.")]
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
    /// <summary>
    /// <para type="synopsis">Retrieve the description of a particular version of an api.</para>
    /// <para type="description">Retrieve the description of a particular version of an api.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Discovery API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GDiscoveryRestData -Api $SomeApiString -Version $SomeVersionString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GDiscoveryRestData">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>

    [Cmdlet(VerbsCommon.Get, "GDiscoveryRestData",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GDiscoveryRestData")]
    public class GetGDiscoveryBaseRestDataCommand : DiscoveryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The name of the API.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The name of the API.")]
        [ValidateNotNullOrEmpty]
        public string Api { get; set; }

        /// <summary>
        /// <para type="description">The version of the API.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The version of the API.")]
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
