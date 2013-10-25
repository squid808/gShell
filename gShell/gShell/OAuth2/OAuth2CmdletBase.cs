using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Util;
using Google.Apis.Oauth2.v2;
using DotNetOpenAuth.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;

namespace gShell.OAuth2
{
    /// <summary>
    /// The base from which all gShell cmdlet type classes must derive containing
    /// authentication and setup logic.
    /// </summary>
    public abstract class OAuth2CmdletBase : PSCmdlet
    {
        #region Properties
        protected string[] scopes = {
            DirectoryService.Scopes.AdminDirectoryUser.GetStringValue(),
            DirectoryService.Scopes.AdminDirectoryUserAlias.GetStringValue(),
            DirectoryService.Scopes.AdminDirectoryUserAlias.GetStringValue(),
            DirectoryService.Scopes.AdminDirectoryOrgunit.GetStringValue(),
            DirectoryService.Scopes.AdminDirectoryGroup.GetStringValue(),
            DirectoryService.Scopes.AdminDirectoryGroupMember.GetStringValue(),
            Oauth2Service.Scopes.UserinfoEmail.GetStringValue()
                                  };

        protected static Dictionary<string, IAuthorizationState> AuthStatesDict;
        protected static string defaultDomain;
        protected static string currentDomain;

        protected static Dictionary<string, OAuth2SetupPackage> packageDict;

        protected static ProgressRecord progressBar;
        #endregion

        #region Constructors
        public OAuth2CmdletBase()
        {
            AuthStatesDict = new Dictionary<string, IAuthorizationState>();
            packageDict = new Dictionary<string, OAuth2SetupPackage>();
        }
        #endregion

        #region AuthenticationAndProcessing
        /// <summary>
        /// Called each time a new cmdlet is fired.
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        protected string Authenticate(string domain)
        {
            domain = ManageDomainAndAuthStates(domain);
            currentDomain = domain;

            BuildService();

            return domain;
        }

        /// <summary>
        /// A method specific to each inherited object, called during authentication. Must be implemented.
        /// </summary>
        protected abstract void BuildService();

        /// <summary>
        /// A powershell specific method, called before the cmdlet is run. Must be implemented. 
        /// </summary>
        protected override abstract void BeginProcessing();

        /// <summary>
        /// Makes sure an Auth State is set for a domain.
        /// </summary>
        /// <param name="domain">The domain to use. If unsupplied use default.</param>
        /// <returns>The domain being used.</returns>
        protected string ManageDomainAndAuthStates(string domain = null)
        {
            if (string.IsNullOrWhiteSpace(domain))
            {
                if (string.IsNullOrWhiteSpace(defaultDomain))
                {
                    string _domain = string.Empty;

                    if (SavedFile.ContainsDefaultDomain())
                    {
                        _domain = SavedFile.GetDefaultDomain();
                        LoadAndSetState(_domain);
                    }
                    else
                    {
                        _domain = AuthenticateAndSetState();
                    }

                    defaultDomain = _domain;
                    return _domain;

                }
                else
                {
                    return LoadAndSetState(defaultDomain);
                }
            }
            else
            {
                if (AuthStatesDict.ContainsKey(domain))
                {
                    return domain;
                }
                else if (SavedFile.ContainsDomain(domain))
                {
                    return LoadAndSetState(domain);
                }
                else
                {
                    return AuthenticateAndSetState();
                }
            }
        }

        /// <summary>
        /// Loads the AuthState either from memory or from the file. Also sets up the package.
        /// </summary>
        /// <param name="_domain"></param>
        /// <returns></returns>
        private string LoadAndSetState(string _domain)
        {
            OAuth2SetupPackage package = OAuth2SetupPackage.CreatePackage();
            package.domain = _domain;
            package.authState = SavedFile.LoadAuthState(_domain);

            if (!AuthStatesDict.ContainsKey(_domain))
            {
                AuthStatesDict.Add(_domain, package.authState);
            }
            else
            {
                AuthStatesDict[_domain] = package.authState;
            }

            if (DateTime.Compare((DateTime)package.authState.AccessTokenExpirationUtc, DateTime.UtcNow) <= 0)
            {
                package.provider.RefreshToken(package.authState);
            }

            if (!packageDict.ContainsKey(_domain))
            {
                packageDict.Add(_domain, package);
            }
            else
            {
                packageDict[_domain] = package;
            }

            return _domain;
        }

        /// <summary>
        /// Loads an AuthState from the web. Also sets up the package.
        /// </summary>
        /// <returns></returns>
        private string AuthenticateAndSetState()
        {
            OAuth2SetupPackage package = OAuth2SetupPackage.CreatePackage();

            package.authState = new AuthorizationState(scopes);
            package.authState.Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl);
            Uri authUri = package.provider.RequestUserAuthorization(package.authState);

            Process.Start(authUri.ToString());
            string authCode;
            do
            {
                Collection<PSObject> results = this.InvokeCommand.InvokeScript("Read-Host -Prompt 'Enter Access Code'");
                authCode = results[0].ToString();
                authCode.Trim();
            } while (authCode == null || authCode == string.Empty);

            package.provider.ProcessUserAuthorization(authCode, package.authState);

            Oauth2Service oService = new Oauth2Service(package.initializer);
            string _domain = oService.Userinfo.Get().Execute().Hd;

            package.domain = _domain;

            if (!packageDict.ContainsKey(_domain))
            {
                packageDict.Add(_domain, package);
            }
            else
            {
                packageDict[_domain] = package;
            }

            SavedFile.SaveAuthState(_domain, package.authState);

            AuthStatesDict.Add(_domain, package.authState);

            return _domain;
        }
        #endregion

        #region ProgressBarMethods

        /// <summary>
        /// Set up the progress bar to display to the user.
        /// </summary>
        /// <param name="activityMessage"></param>
        /// <param name="statusMessage"></param>
        protected void StartProgressBar(string activityMessage,
            string statusMessage = " ")
        {
            if (string.IsNullOrWhiteSpace(statusMessage))
            {
                statusMessage = " ";
            }

            progressBar = new ProgressRecord(1, activityMessage, statusMessage);
            progressBar.PercentComplete = 0;
            progressBar.StatusDescription = "0";
            WriteProgress(progressBar);
        }


        /// <summary>
        /// Update the displayed progress bar. Should first be initialized.
        /// </summary>
        /// <param name="activityMessage"></param>
        /// <param name="currentPercentage"></param>
        /// <param name="maxCount"></param>
        protected void UpdateProgressBar(int currentCount,
            int maxCount, string activityMessage = "", string statusDescription = "")
        {
            if (!string.IsNullOrWhiteSpace(activityMessage))
            {
                progressBar.Activity = activityMessage;
            }

            progressBar.PercentComplete = Convert.ToInt32((
                (double)currentCount / maxCount) * 100);
            if (string.IsNullOrWhiteSpace(statusDescription))
            {
                progressBar.StatusDescription = currentCount + "/" + maxCount;
            }
            else
            {
                progressBar.StatusDescription = statusDescription;
            }
            WriteProgress(progressBar);
        }
        #endregion

        #region Errors

        #endregion
    }
}
