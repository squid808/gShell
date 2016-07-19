using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Reflection;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Util;

using gShell.Cmdlets.Utilities.ScopeHandler;

namespace gShell.dotNet.Utilities.OAuth2
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

        //protected static AuthenticationInfo authInfo { get; set; }

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
        protected abstract AuthenticatedUserInfo Authenticate(IEnumerable<string> Scopes, ClientSecrets Secrets,
            string Domain=null);

        /// <summary>Determines if the user needs to be prompted to select the scopes.</summary>
        /// <remarks>
        /// Api is derived from the class that inherits this. User is the domain's default user. Returns null if scopes
        /// already exist since they'll be pulled up during authentication anyways.
        /// </remarks>
        public IEnumerable<string> EnsureScopesExist(string Domain, HashSet<string> forcedScopes = null)
        {
            //Since the domain could be null, see if we have a default ready or if the saved info contains this one
            Domain = OAuth2Base.CheckDomain(Domain);

            string defaultUser = null;

            if (Domain != null)
                 defaultUser = OAuth2Base.infoConsumer.GetDefaultUser(Domain);

            //if no domain is returned, none was provided or none was found as default.
            if (string.IsNullOrWhiteSpace(Domain) || string.IsNullOrWhiteSpace(defaultUser) || 
                !OAuth2Base.infoConsumer.TokenAndScopesExist(Domain, defaultUser, apiNameAndVersion))
            {
                if (string.IsNullOrWhiteSpace(Domain)) Domain = "no domain provided";

                WriteWarning(string.Format("The Cmdlet you've just started is for domain ({0}) doesn't"
                    + " seem to have any saved authentication for this API ({1}). In order to continue you'll need to"
                    + " choose which permissions gShell can use for this API.", Domain, apiNameAndVersion));

                string chooseApiNowScript = "Read-Host '\nWould you like to choose your API scopes now? y or n'";
                Collection<PSObject> chooseApiNowResults = this.InvokeCommand.InvokeScript(chooseApiNowScript);
                string result = chooseApiNowResults[0].ToString().Substring(0, 1).ToLower();
                if (result == "y")
                {
                    ScopeHandlerBase scopeBase = new ScopeHandlerBase(this);

                    return scopeBase.ChooseScopes(
                        apiNameAndVersion.Split(':')[0],
                        apiNameAndVersion.Split(':')[1],
                        forcedScopes);
                }
                else
                {
                    WriteWarning("No scopes were chosen. You can run this process manually with Invoke-ScopeManager later.");
                }
            }
            else
            {
                return OAuth2Base.infoConsumer.GetTokenInfo(Domain, defaultUser, apiNameAndVersion).scopes;
            }

            return null;
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
