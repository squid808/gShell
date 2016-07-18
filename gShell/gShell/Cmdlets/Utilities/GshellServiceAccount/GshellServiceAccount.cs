using System.Management.Automation;

using gShell.dotNet.Utilities.OAuth2;

namespace gShell.Cmdlets.Utilities.GShellServiceAccount
{
    /// <summary>
    /// <para type="synopsis">Set a service account for a Google Apps domain.</para>
    /// <para type="description">Set a service account for a Google Apps domain. A service account lets you run Cmdlets (that would otherwise be only for your own user) on behalf of a user in your domain. You must have domain administrator rights to use a service account. This will not work with Gmail accounts (unless maybe you work for Google).</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GShellServiceAccount -Domain $SomeDomainString -Email $SomeEmailString</code>
    ///   <para>This example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GShellServiceAccount">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GShellServiceAccount",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAServiceAccount")]
    public class SetGShellServiceAccount : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">The domain the service account will represent and act upon. Do not include the @ symbol.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The domain the service account will represent and act upon. Do not include the @ symbol.")]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        /// <summary>
        /// <para type="description">The full service account ID provided for the service account. This ID may look like an email address for a domain like 'gserviceaccount.com'.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The full service account ID provided for the service account. This ID may look like an email address for a domain like 'gserviceaccount.com'.")]
        [ValidateNotNullOrEmpty]
        public string ServiceAccountId { get; set; }

        /// <summary>
        /// <para type="description">The full system path to the service account key in json or P12 format. You were given this file when you created the service account.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The full system path to the service account key in json or P12 format. You were given this file when you created the service account.")]
        [ValidateNotNullOrEmpty]
        public string CertificatePath { get; set; }

        /// <summary>
        /// <para type="description">The password for the key. If not provided defaults to 'notasecret' which is usually the case.</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The password for the key. If not provided defaults to 'notasecret' which is usually the case.")]
        [ValidateNotNullOrEmpty]
        public string KeyPassword { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(ServiceAccountId, "Set-GShellServiceAccount"))
            {
                OAuth2Base.SetServiceAccount(Domain, ServiceAccountId, CertificatePath, KeyPassword);
            }
        }

    }
}
