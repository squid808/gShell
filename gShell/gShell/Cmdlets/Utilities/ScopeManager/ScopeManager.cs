using System;
using System.Linq;
using System.Xml;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Management.Automation;

using discovery_v1 = Google.Apis.Discovery.v1;
using Data = Google.Apis.Discovery.v1.Data;

using gShell.dotNet.Utilities;
using gShell.dotNet.Utilities.OAuth2;
using gShell.Cmdlets.Discovery;
using gReports = gShell.dotNet.Reports;

using Microsoft.PowerShell.Commands; //for invoking ReadHost

namespace gShell.Cmdlets.Utilities.ScopeHandler
{
    [Cmdlet(VerbsLifecycle.Invoke, "ScopeManager",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Invoke-ScopeManager")]
    public class InvokeScopeManager : ScopeHandlerBase
    {
        #region Properties
        public static discovery_v1.DiscoveryService service;

        [Parameter(Position = 0,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string ApiName { get; set; }

        [Parameter(Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string ApiVersion { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            //Gather the information from the user.
            ApiChoice choice = ChooseApiLoop();
            ChooseApiScopesLoop(choice.Name, choice.Version);

            string script = "Read-Host '\nYou will now authenticate for this API. Press any key to continue.'";
            Collection<PSObject> results = this.InvokeCommand.InvokeScript(script);

            //now, take the list of OAuth just gathered and add it to the main OAuth List
            //OAuth2Base.SetScopes(CheckForRequiredScope(ScopesDictToHash()));

            HashSet<string> scopes = CheckForRequiredScope(ScopesDictToHash());

            //Now, authenticate.
            OAuth2Base.AuthorizeUser(choice.API, scopes);

            PrintPretty("Scopes have been authenticated and saved.", "green");
        }
    }

    public class ScopeHandlerBase : DiscoveryBase
    {
        #region SubClasses

        /// <summary>
        /// A collection of the information representing an API.
        /// </summary>
        public class ApiChoice
        {
            public int Choice;
            /// <summary>
            /// The API in Name:Version format, eg. admin:discovery_v1 or calendar:v2
            /// </summary>
            public string API
            {
                get
                {
                    return string.Format("{0}:{1}", Name, Version);
                    ;
                }
            }
            public string Version { get; set; }
            public string Name { get; set; }

            public ApiChoice(int choice, string version, string name)
            {
                Choice = choice;
                Version = version;
                Name = name;
            }

            public override string ToString()
            {
                return string.Format("[{0}]\t{1}", Choice, API);
            }
        }

        public class ApiInfo
        {
            public string description;
            public string id;
            public string name
            {
                get
                {
                    return id.Split(':')[0];
                }
            }
            public string version
            {
                get
                {
                    return id.Split(':')[1];
                }
            }
        }

        /// <summary>An easier-to-use version of the returned class of scope information.</summary>
        public class ScopeInfo
        {
            public string scope;
            public string description;
        }

        public class ScopeChoice
        {
            public int Choice;
            public string Scope;
            public string Description;

            public ScopeChoice(int choice, string scope, string description)
            {
                Choice = choice;
                Scope = scope;
                Description = description;
            }

            public override string ToString()
            {

                if (Scope != "https://www.googleapis.com/auth/userinfo.email")
                {
                    return string.Format("[{0}]\t{1} - {2}", Choice, Scope, Description);
                }
                else
                {
                    return string.Format("[-]\t{0} (Required for gShell) - {1}", Scope, Description);
                }
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// A list of APIs that are used in gShell. Needs to be maintained.
        /// </summary>
        private ApiChoice[] apiChoices = new ApiChoice[]{
            new ApiChoice(1, "v2", "oauth2"),
            new ApiChoice(2, "directory_v1","admin"),
            new ApiChoice(3, "reports_v1","admin")
        };

        /// <summary>
        /// A collection of scope results where the key is the scope id in name:version format and the List is the ScopeInfos
        /// </summary>
        private Dictionary<string, List<ScopeInfo>> scopesByApiDict = new Dictionary<string, List<ScopeInfo>>();


        #endregion

        #region User Input Loops

        /// <summary>
        /// Start the scope logic loop fomr the beginning where the user is asked to start by selecting an API.
        /// Results in the scopesByApiDict being set up.
        /// </summary>
        public void StartFromScratchLoop()
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                ApiChoice choice = ChooseApiLoop();
                ChooseApiScopesLoop(choice.Name, choice.Version);

                //string script = "Read-Host '\nWould you like to choose or update additional API scopes? y or n'";
                string script = "Read-Host '\nYou will now authenticate for this API. Press any key to continue.'";
                Collection<PSObject> results = this.InvokeCommand.InvokeScript(script);
                //string result = results[0].ToString().Substring(0, 1).ToLower();
                //if (result == "n")
                //{
                //    keepGoing = false;
                //    break;
                //}
                keepGoing = false;
            }
        }

        /// <summary>
        /// Part of a loop that will return an Api Choice
        /// </summary>
        public ApiChoice ChooseApiLoop()
        {
            bool success = false;
            int result = -1;

            while (!success)
            {
                PrintPretty("Please choose an API to explore its scope options:\n", "Green");

                foreach (var choice in apiChoices)
                {
                    PrintPretty(choice.ToString(), "Yellow");
                }

                string script = "Read-Host '\nEnter the number of your choice'";
                Collection<PSObject> results = this.InvokeCommand.InvokeScript(script);
                int temp;
                try
                {
                    temp = int.Parse(results[0].ToString());
                    if (temp > 0 && temp <= apiChoices.Length)
                    {
                        result = temp;
                        success = true;
                    }
                    else
                    {
                        PrintPretty("\nSelection not within bounds. Please try again.\n", "Red");
                    }
                }
                catch
                {
                    PrintPretty("\nInvalid Selection, try again\n", "Red");
                }
            }

            return apiChoices[result - 1];
        }

        public void StartFromInCmdletLoop(string domain)
        {
            //WriteWarning(string.Format("The Cmdlet you've just started is running against a domain ({0}) that doesn't seem to have any authenticated users saved. In order to continue you'll need to choose which permissions gShell can use.", domain));

            string script = "Read-Host '\nWould you like to choose or your API scopes now? y or n'";
            Collection<PSObject> results = this.InvokeCommand.InvokeScript(script);
            string result = results[0].ToString().Substring(0, 1).ToLower();
            if (result == "y")
            {
                StartFromScratchLoop();
            }
            else
            {
                PrintPretty(string.Format("No scopes will be chosen at this time. You can run this process manually with Invoke-ScopeManager later."), "Red");
            }
        }
        
        /// <summary>
        /// Part of a loop that will return a chosen subset of scopes from an Api's list.
        /// </summary>
        public void ChooseApiScopesLoop(string api, string version)
        {
            bool? readOnlyScopes = null;

            bool readOnlyChosen = false;

            while (!readOnlyChosen)
            {
                PrintPretty("\nWould you like to view all scopes [a], read-only scopes [r] or non read-only scopes [n]?", "Green");

                string readOnlyResultScript = "Read-Host '\nEnter your choice: '";

                Collection<PSObject> readOnlyResultResults = this.InvokeCommand.InvokeScript(readOnlyResultScript);

                string readOnlyResultResult = readOnlyResultResults[0].ToString().Substring(0, 1).ToLower();

                switch (readOnlyResultResult)
                {
                    case "a":
                        readOnlyScopes = null;
                        readOnlyChosen = true;
                        break;
                    case "r":
                        readOnlyScopes = true;
                        readOnlyChosen = true;
                        break;
                    case "n":
                        readOnlyScopes = false;
                        readOnlyChosen = true;
                        break;
                    default:
                        PrintPretty("\nInvalid choice, please try again.", "Red");
                        break;
                }
            }



            bool success = false;

            string description;

            List<ScopeInfo> scopes = GetScopesForAPI(api, version, out description);

            if (readOnlyScopes.HasValue)
            {
                if (readOnlyScopes.Value == true)
                {
                    scopes = scopes.Where(x => x.scope.Contains("readonly")).ToList();
                }
                else
                {
                    scopes = scopes.Where(x => !x.scope.Contains("readonly")).ToList();
                }
            }

            List<int> intChoices = new List<int>();

            bool all = false;

            while (!success)
            {
                intChoices = new List<int>(); //in case we loop, reset it

                PrintPretty("\n" + api + ":" + version + " - " + description + "\n", "Green");

                PrintPretty("\nPlease select the scope(s) you'd like to grant gShell permission to:\n", "Green");

                List<ScopeChoice> choices = new List<ScopeChoice>();

                choices.Add(new ScopeChoice(0, "All", "All scopes in this list."));

                for (int i = 0; i < scopes.Count; i++)
                {
                    choices.Add(new ScopeChoice(i + 1, scopes[i].scope, scopes[i].description));
                }

                foreach (var choice in choices)
                {
                    PrintPretty(choice.ToString(), "Yellow");
                }

                string script = "Read-Host '\nEnter your choices, separated by commas'";
                Collection<PSObject> results = this.InvokeCommand.InvokeScript(script);
                string rList = results[0].ToString();

                rList = rList.Replace(" ", "");

                List<string> stringChoices = new List<string>(rList.Split(','));

                int temp;

                try
                {
                    foreach (string sChoice in stringChoices)
                    {
                        temp = int.Parse(sChoice);

                        if (temp > 0 && temp <= scopes.Count)
                        {
                            intChoices.Add(temp);
                            success = true;
                        }
                        else if (temp == 0)
                        {
                            all = true;
                            success = true;
                            break;
                        }
                        else
                        {
                            PrintPretty("\nOne or more selections not within bounds. Please try again.\n", "Red");
                            success = false;
                            break;
                        }
                    }
                }
                catch
                {
                    PrintPretty("\nInvalid Selection, try again\n", "Red");
                }
            }

            if (all)
            {
                scopesByApiDict[api + ":" + version] = scopes;
            }
            else
            {
                if (intChoices.Count != 0)
                {
                    List<ScopeInfo> results = new List<ScopeInfo>();
                    foreach (int choice in intChoices)
                    {
                        results.Add(scopes[choice - 1]);
                    }

                    scopesByApiDict[api + ":" + version] = results;
                }
                else
                {
                    scopesByApiDict[api + ":" + version] = new List<ScopeInfo>();
                }
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>Ensures the required scopes (email) are in the scopes hash.</summary>
        public HashSet<string> CheckForRequiredScope(HashSet<string> scopes)
        {
            if (!scopes.Contains("https://www.googleapis.com/auth/userinfo.email"))
            {
                scopes.Add("https://www.googleapis.com/auth/userinfo.email");
            }

            return scopes;
        }

        /// <summary>
        /// Print to PowerShell using invoke and write-host so as not to return any types via WriteObject
        /// </summary>
        public void PrintPretty(string message, string color)
        {
            string script = "Write-Host (\"" + message + "\") -ForegroundColor " + color;
            this.InvokeCommand.InvokeScript(script);
        }

        /// <summary>Returns the contents of the ScopesByApiDict in to a single hashset.</summary>
        public HashSet<string> ScopesDictToHash()
        {
            HashSet<string> scopesHash = new HashSet<string>();

            foreach (string key in scopesByApiDict.Keys)
            {
                foreach (ScopeInfo scopeInfo in scopesByApiDict[key])
                {
                    scopesHash.Add(scopeInfo.scope);
                }
            }

            return scopesHash;
        }

        #endregion

        #region Api Calls

        /// <summary>Return a list of scopes with both their scope and description.</summary>
        public List<ScopeInfo> GetScopesForAPI(string api, string version, out string description, bool? readOnly = null)
        {
            Data.RestDescription restDescription = apis.RestData(api, version);

            var scopesDict = (Dictionary<string, Data.RestDescription.AuthData.Oauth2Data.ScopesDataElement>)restDescription.Auth.Oauth2.Scopes;

            var scopesList = new List<ScopeInfo>();

            foreach (string key in scopesDict.Keys)
            {
                scopesList.Add(new ScopeInfo() { scope = key, description = scopesDict[key].Description });
            }

            description = restDescription.Description;

            return scopesList;
        }

        /// <summary>Get a list of ApiInfo.</summary>
        public List<ApiInfo> GetAPIList(bool preferred = true)
        {
            Data.DirectoryList dirList = apis.List(new gShell.dotNet.Discovery.Apis.DiscoveryListProperties() { preferred = preferred });

            List<ApiInfo> info = new List<ApiInfo>();

            foreach (Data.DirectoryList.ItemsData dir in dirList.Items)
            {
                info.Add(new ApiInfo() { description = dir.Description, id = dir.Id });
            }

            return info;
        }

        #endregion

    }
}
