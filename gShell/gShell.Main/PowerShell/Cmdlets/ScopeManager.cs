//using System;
//using System.Management.Automation;
//using gShell.Main.Auth.OAuth2.v1;

//namespace gShell.Main.PowerShell.Cmdlets
//{
//    public enum ScopeSelectionTypes { None, All, ReadOnly, ReadWrite }

//    /// <summary>
//    /// <para type="synopsis">Run the interactive wizard for choosing an API's scopes.</para>
//    /// <para type="description">Run the interactive wizard for choosing an API's scopes. GShell is a collection of tools (Cmdlets) that are used by a specific email account. In addition to authenticating with that account, you also have to tell gShell what it is allowed to do for this account. This is what the scopes are for, and why you need to select them.</para>
//    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
//    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
//    /// </description></item></list>
//    /// <example>
//    ///   <code>PS C:\> Invoke-GShellScopeManager</code>
//    ///   <para>This example serves to show the bare minimum required to call this Cmdlet.</para>
//    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
//    /// </example>
//    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Invoke-GShellScopeManager">[Wiki page for this Cmdlet]</para>
//    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
//    /// </summary>
//    [Cmdlet(VerbsLifecycle.Invoke, "GShellScopeManager",
//          SupportsShouldProcess = true,
//          HelpUri = @"https://github.com/squid808/gShell/wiki/Invoke-GShellScopeManager")]
//    public class InvokeGShellScopeManager : ScopeHandlerBase
//    {
//        #region Properties

//        /// <summary>
//        /// <para type="description">The API for which you would like to set or update the scopes.</para>
//        /// </summary>
//        [Parameter(Position = 0,
//            Mandatory = false,
//            ParameterSetName = "ApiProvided",
//            HelpMessage = "The API for which you would like to set or update the scopes.")]
//        [ValidateNotNullOrEmpty]
//        public string ApiName { get; set; }

//        /// <summary>
//        /// <para type="description">The API version for which you would like to set or update the scopes.</para>
//        /// </summary>
//        [Parameter(Position = 1,
//            Mandatory = false,
//            ParameterSetName = "ApiProvided",
//            HelpMessage = "The API version for which you would like to set or update the scopes.")]
//        [ValidateNotNullOrEmpty]
//        public string ApiVersion { get; set; }

//        /// <summary>
//        /// <para type="description">The type of scopes you would like to preselect. Options are None, All, ReadOnly, or ReadWrite</para>
//        /// </summary>
//        [Parameter(Position = 2,
//            Mandatory = false,
//            ParameterSetName = "ApiProvided",
//            HelpMessage = "The type of scopes you would like to preselect. Options are None, All, ReadOnly, or ReadWrite")]
//        public ScopeSelectionTypes PreSelectScopes { get; set; }

//        #endregion

//        protected override void ProcessRecord()
//        {
//            var secrets = CheckForClientSecrets();
//            if (secrets != null)
//            {
//                if (ParameterSetName != "ApiProvided")
//                {
//                    ApiChoice choice = ChooseApiLoop();
//                    ApiName = choice.Name;
//                    ApiVersion = choice.Version;
//                }

//                if (PreSelectScopes != ScopeSelectionTypes.None)
//                {
//                    AuthenticatePreChosenScopes(ApiName, ApiVersion, secrets, PreSelectScopes);
//                }
//                else
//                {
//                    ChooseScopesAndAuthenticate(ApiName, ApiVersion, secrets);
//                }
//            }
//            else
//            {
//                throw new Exception(
//                    "Client Secrets must be set before running cmdlets. Run 'Get-Help "
//                    + "Set-gShellClientSecrets -online' for more information.");
//            }
//        }
//    }

    
//}
