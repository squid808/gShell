using System;
using System.Management.Automation;
using gShell.Main.Auth.OAuth2.v1;

namespace gShell.Main.PowerShell.Base.v1
{
    public abstract class ServiceAccountCmdletBase : AuthenticatedCmdletBase
    {
        /// <summary>Gets or sets the email account the gShell Service Account should impersonate.</summary>
        protected static string gShellServiceAccount { get; set; }

        #region Properties

        /// <summary>
        /// <para type="description">The email account to be targeted by the service account.</para>
        /// </summary>
        [Alias("ServiceAccountTarget")]
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string TargetUserEmail { get; set; }

        #endregion

        protected override void BeginProcessing()
        {
            var secrets = CheckForClientSecrets() ?? PromptForClientSecrets();

            //TODO: figure out the correct ordering of these requests, and add the service account email to the build service
            authUserInfo = EnsureScopesExist(GAuthId);
            //need the gauthID first anyways to ensure that they have permissions, and to look up the service account
            ServiceWrapperDictionary[serviceWrapperType].BuildService(Authenticate(authUserInfo, secrets));

            if (!string.IsNullOrWhiteSpace(TargetUserEmail))
            {
                if (!OAuth2Base.infoConsumer.ServiceAccountExists(authUserInfo.domain))
                {
                    WriteWarning("No service account was found for domain " + authUserInfo.domain +
                                    ". Please set a service" +
                                    " account with Set-GShellServiceAccount, or see https://github.com/squid808/gShell/wiki/Service-Accounts" +
                                    " for more information.");
                }

                gShellServiceAccount = GetFullEmailAddress(TargetUserEmail, authUserInfo.domain);
                ServiceWrapperDictionary[serviceWrapperType].BuildService(Authenticate(authUserInfo, secrets),
                    gShellServiceAccount);
            }
            else
            {
                gShellServiceAccount = null;
            }

            GWriteProgress = new gWriteProgress(WriteProgress);
        }

        /// <summary>The gShell base implementation of the PowerShell EndProcessing method.</summary>
        /// <remarks>We need to reset the service account after every Cmdlet call to prevent the next
        /// Cmdlet from inheriting it as well.</remarks>
        protected override void EndProcessing()
        {
            gShellServiceAccount = null;
        }

        /// <summary>The gShell base implementation of the PowerShell StopProcessing method.</summary>
        /// <remarks>We need to reset the service account after every Cmdlet call to prevent the next
        /// Cmdlet from inheriting it as well.</remarks>
        protected override void StopProcessing()
        {
            gShellServiceAccount = null;
        }

    }
}
