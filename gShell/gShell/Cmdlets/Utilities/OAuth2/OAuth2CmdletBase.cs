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

using gShell.Serialization;

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
            Assembly accurate = Assembly.LoadFrom(System.IO.Path.Combine(AssemblyDirectory, "System.Net.Http.Primitives.dll"));
            return accurate;
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
        public OAuth2CmdletBase() { }
        #endregion

        #region Authentication & Processing
        /// <summary>
        /// A method specific to each inherited object, called during authentication. Must be implemented.
        /// </summary>
        protected abstract string BuildService(string givenDomain);

        /// <summary>
        /// A powershell specific method, called before the cmdlet is run. Must be implemented. 
        /// </summary>
        protected override abstract void BeginProcessing();

        /// <summary>
        /// Called each time a new cmdlet is fired.
        /// </summary>
        protected string Authenticate(string domain)
        {
            return OAuth2Base.Authenticate(domain, BuildService);
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
