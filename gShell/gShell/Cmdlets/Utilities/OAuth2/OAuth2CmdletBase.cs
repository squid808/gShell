using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Reflection;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Util;

using gShell.Cmdlets.Utilities.ScopeHandler;
using gShell.dotNet.Utilities.OAuth2;
using gShell.dotNet.Utilities;
using Google.Apis.admin.Directory.directory_v1.Data;

namespace gShell.Cmdlets.Utilities.OAuth2
{
    /// <summary>
    /// The base from which all gShell cmdlet type classes must derive containing
    /// authentication and setup logic.
    /// </summary>
    public abstract class OAuth2CmdletBase : PSCmdlet, IModuleAssemblyInitializer
    {
        #region Properties

        protected static ProgressRecord progressBar { get; set; }

        /// <summary>Determine if the assemblies have already been resolved.</summary>
        public static bool assembliesResolved { get { return _assembliesResolved; } }
        private static bool _assembliesResolved;

        /// <summary>A delegate to allow the progress bar methods to be static. Assigned in Begin Processing.</summary>
        protected delegate void gWriteProgress(ProgressRecord progressBar);

        /// <summary>A static implementation of GWriteProgress.</summary>
        protected static gWriteProgress GWriteProgress { get; set; }

        protected abstract string apiNameAndVersion { get; }

        /// <summary>A copy of the OAuth2Base authUserInfo, able to be overwritten or discarded after each use.</summary>
        protected AuthenticatedUserInfo authUserInfo { get; set; }

        #endregion

        #region AssemblyResolution

        /// <summary>
        /// Required for the implementation of IModuleAssemblyInitializer - resolves the GAC and machine.config issues
        /// This gets fired for each cmdlet that inherits this base class when importing the module in PoSh
        /// </summary>
        public void OnImport()
        {
            if (!_assembliesResolved)
            { //use the static flag to only fire it once
                AppDomain currentDomain = AppDomain.CurrentDomain;
                currentDomain.AssemblyResolve += new ResolveEventHandler(ResolveSystemPrimitives);
                _assembliesResolved = true;
            }
        }

        /// <summary>
        /// Provide the appropriate path to the System.Net.Http.Primitives assembly.
        /// </summary>
        private static Assembly ResolveSystemPrimitives(object sender, ResolveEventArgs args)
        {
            if (args.Name.ToLower().StartsWith("system.net.http.primitives"))
            {
                string path = System.IO.Path.Combine(AssemblyDirectory, "System.Net.Http.Primitives.dll");

                return Assembly.LoadFrom(path);
            }
            else if (args.Name.ToLower().StartsWith("newtonsoft.json"))
            {
                string path = System.IO.Path.Combine(AssemblyDirectory, "Newtonsoft.Json.dll");

                return Assembly.LoadFrom(path);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Provides the location of the executing assembly. Typically %UserProfile%\My Documents\gShell\
        /// http://stackoverflow.com/questions/52797/how-do-i-get-the-path-of-the-assembly-the-code-is-in
        /// </summary>
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return System.IO.Path.GetDirectoryName(path);
            }
        }

        #endregion

        #region Constructors

        public OAuth2CmdletBase() 
        {
            GWriteProgress += WriteProgress; //set up the delegate so that the progress bar will work via static calls
        }

        #endregion

        #region Authentication & Processing

        /// <summary>A powershell specific method, called before the cmdlet is run. Must be implemented.</summary>
        protected override abstract void BeginProcessing();

        /// <summary>Load token and scope information for API call, and authenticate if necessary.</summary>
        protected abstract AuthenticatedUserInfo Authenticate(AuthenticatedUserInfo authUserInfo, ClientSecrets Secrets);

        /// <summary>Determines if the user needs to be prompted to select the scopes.</summary>
        /// <remarks>
        /// Api is derived from the class that inherits this. User is the domain's default user. Returns null if scopes
        /// already exist since they'll be pulled up during authentication anyways.
        /// </remarks>
        public AuthenticatedUserInfo EnsureScopesExist(string GAuthId, HashSet<string> forcedScopes = null)
        {
            var results = new AuthenticatedUserInfo();

            string domain = null;
            string user = null;

            bool gauthProvided = false;

            if (!string.IsNullOrWhiteSpace(GAuthId))
            {
                gauthProvided = true;

                if (GAuthId.Contains("@")) //user probably specified a full email address
                {
                    string gauthUser = GetUserFromEmail(GAuthId);
                    results.originalUser = gauthUser;

                    string gauthDomain = GetDomainFromEmail(GAuthId);
                    results.originalDomain = gauthDomain;

                    if (OAuth2Base.infoConsumer.DomainExists(gauthDomain))
                    {
                        domain = gauthDomain;

                        if (OAuth2Base.infoConsumer.UserExists(gauthDomain, gauthUser))
                        {
                            user = gauthUser; //else leave null - make them auth for that user since they specified it
                        }
                    }
                }
                else //either just a domain, or a user
                {
                    //check if it is a domain
                    if (OAuth2Base.infoConsumer.DomainExists(GAuthId))
                    {
                        domain = GAuthId;
                        results.originalDomain = GAuthId;
                        user = OAuth2Base.infoConsumer.GetDefaultUser(GAuthId); //could be null
                    }
                    else //not a domain that is saved
                    {
                        //try the default domain's users first, as a matter of best practice
                        string defaultDomain = OAuth2Base.infoConsumer.GetDefaultDomain();

                        if (!string.IsNullOrWhiteSpace(defaultDomain))
                        {
                            var users = OAuth2Base.infoConsumer.GetAllUsers(defaultDomain);

                            if (users.Select(x => x.userName).Contains(GAuthId))
                            {
                                domain = defaultDomain;
                                user = GAuthId;
                                results.originalUser = GAuthId;
                            }
                            else //check other domains, if any
                            {
                                var domains = OAuth2Base.infoConsumer.GetAllDomains();

                                foreach (var domainObj in domains)
                                {
                                    users = OAuth2Base.infoConsumer.GetAllUsers(domainObj.domain);

                                    if (users.Select(x => x.userName).Contains(GAuthId))
                                    {
                                        domain = domainObj.domain;
                                        user = GAuthId;
                                        results.originalUser = GAuthId;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //****************//

            if (string.IsNullOrWhiteSpace(domain) && !gauthProvided)
            {
                //If the domain or user are missing, see if we can fill it in using the defaults
                domain = OAuth2Base.CheckDomain(domain);
                if (domain != null) user = OAuth2Base.CheckUser(domain, user);
            }

            //now find out if that domain has a parent domain if we don't have a user provided even by default
            if (!string.IsNullOrWhiteSpace(domain) && string.IsNullOrWhiteSpace(user) &&
                !string.IsNullOrWhiteSpace(OAuth2Base.infoConsumer.GetDomain(domain).parentDomain))
            {
                var domainParent = OAuth2Base.infoConsumer.GetDomainMainParent(domain);
                if (domainParent != domain)
                {
                    domain = domainParent;
                    user = OAuth2Base.infoConsumer.GetDefaultUser(domain);
                }
            }

            //****************//

            results.userName = user;
            results.domain = domain;

            //if no domain is returned, none was provided or none was found as default.
            if (string.IsNullOrWhiteSpace(domain) || string.IsNullOrWhiteSpace(user) || 
                !OAuth2Base.infoConsumer.TokenAndScopesExist(domain, user, apiNameAndVersion))
            {
                string domainText = null;

                if (!string.IsNullOrWhiteSpace(domain))
                {
                    domainText = "is for domain (" + domain + "), which ";
                }

                WriteWarning(string.Format("The Cmdlet you've just started {0}doesn't"
                    + " seem to have any saved authentication for this API ({1}). In order to continue you'll need to"
                    + " choose which permissions gShell can use for this API.", domainText, apiNameAndVersion));

                string chooseApiNowScript = "Read-Host '\nWould you like to choose your API scopes now? y or n'";
                Collection<PSObject> chooseApiNowResults = this.InvokeCommand.InvokeScript(chooseApiNowScript);
                string result = chooseApiNowResults[0].ToString().Substring(0, 1).ToLower();
                if (result == "y")
                {
                    ScopeHandlerBase scopeBase = new ScopeHandlerBase(this);

                    results.scopes = scopeBase.ChooseScopes(
                        apiNameAndVersion.Split(':')[0],
                        apiNameAndVersion.Split(':')[1],
                        forcedScopes);

                    return results;
                }
                else
                {
                    WriteWarning("No scopes were chosen. You can run this process manually with Invoke-ScopeManager later.");
                }
            }
            else
            {
                results.scopes = OAuth2Base.infoConsumer.GetTokenInfo(domain, user, apiNameAndVersion).scopes;
                return results;
            }

            return results;
        }

        /// <summary>Returns the default client secrets or null if they're missing or incomplete.</summary>
        /// <remarks>
        /// To be called before having run ShouldPromptForScopes to ensure the right secrets 
        /// are available to authenticate with.
        /// </remarks>
        public ClientSecrets CheckForClientSecrets()
        {
            ClientSecrets secrets = OAuth2Base.infoConsumer.GetDefaultClientSecrets();

            if (secrets != null && !string.IsNullOrWhiteSpace(secrets.ClientSecret) && 
                !string.IsNullOrWhiteSpace(secrets.ClientId))
            {
                return secrets;
            }

            return null;
        }
        #endregion

        #region ProgressBar Methods

        /// <summary>
        /// Set up the progress bar to display to the user.
        /// </summary>
        /// <param name="activityMessage"></param>
        /// <param name="statusMessage"></param>
        public static void StartProgressBar(string activityMessage,
            string statusMessage = " ")
        {
            if (string.IsNullOrWhiteSpace(statusMessage))
            {
                statusMessage = " ";
            }

            progressBar = new ProgressRecord(1, activityMessage, statusMessage);
            progressBar.PercentComplete = 0;
            progressBar.StatusDescription = "0";
            GWriteProgress(progressBar);
        }


        /// <summary>
        /// Update the displayed progress bar. Should first be initialized.
        /// </summary>
        /// <param name="activityMessage"></param>
        /// <param name="currentPercentage"></param>
        /// <param name="maxCount"></param>
        protected static void UpdateProgressBar(int currentCount,
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
            GWriteProgress(progressBar);
        }
        #endregion

        #region Generic Methods
        /// <summary>
        /// Creates a random password of length.
        /// </summary>
        /// <param name="length"></param>
        /// <see cref="http://stackoverflow.com/questions/54991/generating-random-passwords"/>
        protected string CreatePassword(int length)
        {
            string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!-%?";
            string res = "";
            Random rnd = new Random();
            while (0 < length--)
                res += valid[rnd.Next(valid.Length)];
            return res;
        }

        /// <summary>
        /// Generates a hashed password based on the input.
        /// </summary>
        /// <param name="PasswordLength">Min 8, max 100. Defaults to 8 if empty.</param>
        /// <param name="printPassword">Default false - prints the new password to screen.</param>
        /// <returns>New password in hex string format.</returns>
        protected string GeneratePassword(int? PasswordLength, bool ShowNewPassword)
        {
            int PasswordLengthInt;
            if (PasswordLength < 8 || !PasswordLength.HasValue)
            {
                PasswordLength = 8;
            }
            else if (PasswordLength > 100)
            {
                PasswordLength = 100;
            }
            PasswordLengthInt = PasswordLength.Value;
            string newPassword = CreatePassword(PasswordLengthInt);
            //Console.WriteLine(newPassword);

            if (ShowNewPassword == true)
            {
                Console.WriteLine(newPassword);
            }

            return GetMd5Hash(newPassword);
        }

        protected string GetMd5Hash(string s)
        {
            using (var md5Hasher = System.Security.Cryptography.MD5.Create())
            {
                var data = md5Hasher.ComputeHash(System.Text.Encoding.UTF8.GetBytes(s));
                return BitConverter.ToString(data, 0).Replace("-", string.Empty);
            }
        }

        /// <summary>Get a full email address, if not already provided.</summary>
        protected string GetFullEmailAddress(string account, AuthenticatedUserInfo authInfo)
        {
            if (string.IsNullOrWhiteSpace(account)) return null;

            //assume an address already containing the @ symbol is already a full email address
            if (account.Contains("@"))
            {
                return account;
            }
            else
            {
                var domain = string.Empty;

                //we don't have a domain. first try the originally provided domain
                if (!string.IsNullOrWhiteSpace(authInfo.originalDomain))
                {
                    domain = authInfo.originalDomain;
                }
                else if (!string.IsNullOrWhiteSpace(authInfo.domain))
                {
                    domain = authInfo.domain;
                }
                else
                {
                    domain = OAuth2Base.CheckDomain();
                }

                //will return null if acct or domain is blank
                return Utils.GetFullEmailAddress(account, domain);
            }
        }

        protected string GetFullEmailAddress(string account, string domain)
        {
            if (string.IsNullOrWhiteSpace(domain))
            {
                domain = OAuth2Base.CheckDomain();
                if (string.IsNullOrWhiteSpace(domain)) return null;
            }

            return Utils.GetFullEmailAddress(account, domain);
        }

        protected string GetUserFromEmail(string userName)
        {
            return Utils.GetUserFromEmail(userName);
        }

        protected string GetDomainFromEmail(string email)
        {
            return Utils.GetDomainFromEmail(email);
        }
        #endregion
    }

    /// <summary>
    /// Class required to check the expiration of a token. A bit silly if you ask me.
    /// </summary>
    public sealed class Clock : IClock 
    {
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }

        public DateTime UtcNow
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }
}
