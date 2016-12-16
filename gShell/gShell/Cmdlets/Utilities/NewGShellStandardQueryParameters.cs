using System.Management.Automation;
using gShell.dotNet.Utilities.OAuth2;

namespace gShell.Cmdlets.Utilities.GShellServiceAccount
{
    /// <summary>
    /// <para type="synopsis">Creates a new Standard Query Parameters object.</para>
    /// <para type="description">Creates a new Standard Query Parameters object.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Reports API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GShellStandardQueryParameters</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GShellStandardQueryParameters">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GShellStandardQueryParameters",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GShellStandardQueryParameters")]
    [OutputType(typeof(Google.Apis.admin.Reports.reports_v1.Data.Channel))]
    public class NewGShellStandardQueryParametersCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">Selector specifying a subset of fields to include in the response.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Selector specifying a subset of fields to include in the response.")]
        public string Fields { get; set; }

        /// <summary>
        /// <para type="description">Alternative to userIp.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Alternative to userIp.")]
        public string QuotaUser { get; set; }

        /// <summary>
        /// <para type="description">IP address of the end user for whom the API call is being made.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "IP address of the end user for whom the API call is being made.")]
        public string UserIp { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new StandardQueryParameters()
            {
                fields = this.Fields,
                quotaUser = this.QuotaUser,
                userIp = this.UserIp,
            };

            if (ShouldProcess("Standard Query Parameters"))
            {
                WriteObject(body);
            }
        }
    }  
}
