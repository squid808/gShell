using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using System.Reflection;
using gShell.dotNet;
using gShell.dotNet.Utilities.OAuth2;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;

namespace gShell.Cmdlets.Utilities.OAuth2
{
    public abstract class AuthenticatedCmdletBase : OAuth2CmdletBase
    {
        /// <summary>
        /// A collection of the service wrapper objects (mainBase) necessary to call the Authenticate and BuildService methods.
        /// </summary>
        protected static Dictionary<Type, IServiceWrapper<IClientService>> ServiceWrapperDictionary
            = new Dictionary<Type, IServiceWrapper<IClientService>>();

        /// <summary>
        /// Required to be able to store and retrieve the mainBase from the ServiceWrapperDictionary
        /// </summary>
        protected abstract Type mainBaseType { get; }

        /// <summary>The gShell dotNet class wrapper base.</summary>
        public IServiceWrapper<BaseClientService> mainBase { get; set; }

        /// <summary>Returns the api name and version in {name}:{version} format.</summary>
        protected override string apiNameAndVersion {
            get
            {
                return ServiceWrapperDictionary[mainBaseType].apiNameAndVersion;
            }
        }

        /// <summary>
        /// <para type="description">The GAuthId representing the gShell auth credentials this cmdlet should use to run.</para>
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string GAuthId { get; set; }

        /// <summary>The gShell base implementation of the PowerShell BeginProcessing method.</summary>
        /// <remarks>If a service account needs to be identified, it should be in a child class that overrides
        /// and calls this method.</remarks>
        protected override void BeginProcessing()
        {
            var secrets = CheckForClientSecrets();
            if (secrets != null)
            {
                authUserInfo = EnsureScopesExist(GAuthId);
                ServiceWrapperDictionary[mainBaseType].BuildService(Authenticate(authUserInfo, secrets));

                GWriteProgress = new gWriteProgress(WriteProgress);
            }
            else
            {
                WriteError(new ErrorRecord(new Exception(
                    "Client Secrets must be set before running cmdlets. Run 'Get-Help "
                    + "Set-gShellClientSecrets -online' for more information."), "", ErrorCategory.AuthenticationError, null));
            }
        }

        #region Authentication & Processing
        /// <summary>Ensure the user, domain and client secret combination work with an authenticated user.</summary>
        /// <param name="Scopes">The scopes that need to be passed through to the user authentication to Google.</param>
        /// <param name="Secrets">The client secrets.`</param>
        /// <param name="Domain">The domain for which this authentication is intended.</param>
        /// <returns>The AuthenticatedUserInfo for the authenticated user.</returns>
        protected override AuthenticatedUserInfo Authenticate(AuthenticatedUserInfo authUserInfo, ClientSecrets Secrets)
        {
            authUserInfo.apiNameAndVersion = apiNameAndVersion;

            return ServiceWrapperDictionary[mainBaseType].Authenticate(authUserInfo, Secrets);
        }
        #endregion
    }
}
