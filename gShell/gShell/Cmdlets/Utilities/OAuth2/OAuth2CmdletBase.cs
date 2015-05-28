using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Drive.v2;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Json;
using Google.Apis.Util;
using Google.Apis.Oauth2.v2;
using Google.Apis.Oauth2.v2.Data;
using Google.Apis.Services;
using Google.Apis.Admin.Reports.reports_v1;
using Google.Apis.Admin.Reports.reports_v1.Data;

//using gShell.Serialization;

namespace gShell.dotNet.Utilities.OAuth2
{
    /// <summary>
    /// The base from which all gShell cmdlet type classes must derive containing
    /// authentication and setup logic.
    /// </summary>
    public abstract class OAuth2CmdletBase : PSCmdlet, IModuleAssemblyInitializer
    {
        #region Properties
        protected static ProgressRecord progressBar;

        /// <summary>
        /// A flag to determine if the assemblies have already been resolved.
        /// </summary>
        public static bool assembliesResolved { get { return _assembliesResolved; } }
        private static bool _assembliesResolved;


        /// <summary>
        /// A delegate to allow the progress bar methods to be static. Assigned in Begin Processing.
        /// </summary>
        protected delegate void gWriteProgress(ProgressRecord progressBar);

        /// <summary>
        /// A static implementation of GWriteProgress
        /// </summary>
        protected static gWriteProgress GWriteProgress;
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
        ///// <summary>
        ///// A method specific to each inherited object, called during authentication. Must be implemented.
        ///// </summary>
        //protected abstract string BuildService(string givenDomain);

        /// <summary>
        /// A powershell specific method, called before the cmdlet is run. Must be implemented. 
        /// </summary>
        protected override abstract void BeginProcessing();

        /// <summary>
        /// Called each time a new cmdlet is fired.
        /// </summary>
        protected abstract string Authenticate(string domain);

        public void CheckForScopes(string domain)
        {
            domain = OAuth2Base.DetermineDomain(domain); //this is likely going to be called again, can't avoid it for now.

            //if no domain is returned, none was provided or none was found as default.
            if (string.IsNullOrWhiteSpace(domain) || !gShell.dotNet.Utilities.SavedFile.ContainsUserOrDomain(domain))
            {
                if (string.IsNullOrWhiteSpace(domain)) { domain = "none provided"; }

                WriteWarning(string.Format("The Cmdlet you've just started is running against a domain ({0}) that doesn't seem to have any authenticated users saved. In order to continue you'll need to choose which permissions gShell can use.", domain));

                string script = "Read-Host '\nWould you like to choose or your API scopes now? y or n'";
                Collection<PSObject> results = this.InvokeCommand.InvokeScript(script);
                string result = results[0].ToString().Substring(0, 1).ToLower();
                if (result == "y")
                {
                    results = this.InvokeCommand.InvokeScript(string.Format("Invoke-ScopeManager -Domain {0}", domain));
                }
                else
                {
                    script = "Write-Host (\"No scopes will be chosen at this time. You can run this process manually with Invoke-ScopeManager later.\") -ForegroundColor \"Red\"";
                    this.InvokeCommand.InvokeScript(script);

                }
            }
            else
            {
                OAuth2Base.LoadScopes(domain);
            }
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
            return Utils.GetFullEmailAddress(account, domain);
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
