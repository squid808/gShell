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
            Mandatory = false,
            ParameterSetName="ApiProvided")]
        [ValidateNotNullOrEmpty]
        public string ApiName { get; set; }

        [Parameter(Position = 1,
            Mandatory = false,
            ParameterSetName = "ApiProvided")]
        [ValidateNotNullOrEmpty]
        public string ApiVersion { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ParameterSetName != "ApiProvided")
            {
                ApiChoice choice = ChooseApiLoop();
                ApiName = choice.API;
                ApiVersion = choice.Version;
            }

            ChooseScopesAndAuthenticate(ApiName, ApiVersion);
        }
    }

    public class ScopeHandlerBase : DiscoveryBase
    {
        #region SubClasses

        /// <summary> A collection of the information representing an API. </summary>
        public class ApiChoice
        {
            public int Choice;
            /// <summary> The API in Name:Version format, eg. admin:discovery_v1 or calendar:v2 </summary>
            public string API
            {
                get
                {
                    return string.Format("{0}:{1}", Name, Version);
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
            public int Choice { get; set; }
            public string Scope { get; set; }
            public string Description { get; set; }
            public bool IsChecked { get; set; }
            private static string CheckMark = "\u221A"; 

            public ScopeChoice(int choice, string scope, string description, bool isChecked = false)
            {
                Choice = choice;
                Scope = scope;
                Description = description;
                IsChecked = isChecked;

            }

            public override string ToString()
            {
                return string.Format("[{0}] {1}\t{2} - {3}", IsChecked ? CheckMark : " ", Choice, Scope, Description);


                //if (Scope != "https://www.googleapis.com/auth/userinfo.email")
                //{
                //    return string.Format("[{0}]\t{1} - {2}", Choice, Scope, Description);
                //}
                //else
                //{
                //    return string.Format("[{2}]\t{0} (Required for gShell) - {1}", 
                //        Scope, Description, "\u221A");
                //}
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// An invokable instance of the PSCmdlet class or a descendent.
        /// </summary>
        /// <remarks>
        /// In some cases where this class isn't called as part of it's own cmdlet, when we have to create it as a
        /// separate class to work with another cmdlet, we need to supply that class as the instance to work with.
        /// </remarks>
        private PSCmdlet invokablePSInstance { get; set; }

        /// <summary>
        /// A list of APIs that are used in gShell. Needs to be curated manually.
        /// </summary>
        private ApiChoice[] apiChoices = new ApiChoice[]{
            new ApiChoice(1, "v2", "oauth2"),
            new ApiChoice(2, "directory_v1","admin"),
            new ApiChoice(3, "reports_v1","admin")
        };

        public ScopeHandlerBase() 
        {
            invokablePSInstance = this;
        }
        public ScopeHandlerBase(PSCmdlet instance)
        {
            invokablePSInstance = instance;
        }

        ///// <summary>
        ///// A collection of scope results where the key is the scope id in name:version format and the List is the ScopeInfos
        ///// </summary>
        //private Dictionary<string, List<ScopeInfo>> scopesByApiDict { get; set; }


        #endregion

        #region User Input Loops

        ///// <summary>
        ///// Start the scope logic loop fomr the beginning where the user is asked to start by selecting an API.
        ///// Results in the scopesByApiDict being set up.
        ///// </summary>
        //public void StartFromScratchLoop()
        //{
        //    bool keepGoing = true;

        //    while (keepGoing)
        //    {
        //        ApiChoice choice = ChooseApiLoop();
        //        ChooseApiScopesLoop(choice.Name, choice.Version);

        //        //string script = "Read-Host '\nWould you like to choose or update additional API scopes? y or n'";
        //        string script = "Read-Host '\nYou will now authenticate for this API. Press any key to continue.'";
        //        Collection<PSObject> results = this.InvokeCommand.InvokeScript(script);
        //        //string result = results[0].ToString().Substring(0, 1).ToLower();
        //        //if (result == "n")
        //        //{
        //        //    keepGoing = false;
        //        //    break;
        //        //}
        //        keepGoing = false;
        //    }
        //}

        /// <summary> Part of a loop that will return an Api Choice </summary>
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
                Collection<PSObject> results = invokablePSInstance.InvokeCommand.InvokeScript(script);
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

        //public void StartFromInCmdletLoop(string domain)
        //{
        //    //WriteWarning(string.Format("The Cmdlet you've just started is running against a domain ({0}) that doesn't seem to have any authenticated users saved. In order to continue you'll need to choose which permissions gShell can use.", domain));

        //    string script = "Read-Host '\nWould you like to choose or your API scopes now? y or n'";
        //    Collection<PSObject> results = this.InvokeCommand.InvokeScript(script);
        //    string result = results[0].ToString().Substring(0, 1).ToLower();
        //    if (result == "y")
        //    {
        //        StartFromScratchLoop();
        //    }
        //    else
        //    {
        //        PrintPretty(string.Format("No scopes will be chosen at this time. You can run this process manually with Invoke-ScopeManager later."), "Red");
        //    }
        //}
        
        /// <summary>
        /// Part of a loop that will return a chosen subset of scopes from an Api's list.
        /// </summary>
        public HashSet<string> ChooseApiScopesLoop(string api, string version)
        {
            bool? readOnlyScopes = null;
            bool readOnlyChosen = false;
            bool choicesConfirmed = false;

            string description;
            List<ScopeInfo> possibleScopes = GetScopesForAPI(api, version, out description);

            //while (!choicesConfirmed)
            //{
                #region ReadOnly Choice
                while (!readOnlyChosen)
                {
                    PrintPretty("\nWould you like to view all scopes [a], read-only scopes [r] or non read-only scopes [n]?", "Green");

                    string readOnlyResultScript = "Read-Host '\nEnter your choice: '";

                    Collection<PSObject> readOnlyResultResults = invokablePSInstance.InvokeCommand.InvokeScript(readOnlyResultScript);

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
                #endregion

                #region Selecting Scopes
                bool properlySelected = false;
                bool hasSelectedOnce = false;
                HashSet<int> intChoices = new HashSet<int>();
                List<ScopeChoice> allPossibleChoices = null;
                bool allChoicesSelected = false;

                if (readOnlyScopes.HasValue)
                {
                    if (readOnlyScopes.Value == true)
                    {
                        possibleScopes = possibleScopes.Where(x => x.scope.Contains("readonly")).ToList();
                    }
                    else
                    {
                        possibleScopes = possibleScopes.Where(x => !x.scope.Contains("readonly")).ToList();
                    }
                }

                while (!properlySelected)
                {
                    //intChoices = new HashSet<int>(); //in case we loop, reset it

                    #region Print Choices
                    PrintPretty("\n" + api + ":" + version + " - " + description + "\n", "Green");
                    if (!hasSelectedOnce)
                    {
                        PrintPretty("\nPlease select the scope(s) you'd like to grant gShell permission to:\n", "Green");
                    }
                    else
                    {
                        PrintPretty("\nPlease confirm the scope(s) you'd like to grant gShell permission to:\n", "Green");
                    }

                    if (allPossibleChoices == null)
                    {
                        allPossibleChoices = new List<ScopeChoice>();

                        allPossibleChoices.Add(new ScopeChoice(0, "All", "All scopes in this list."));

                        for (int i = 0; i < possibleScopes.Count; i++)
                        {
                            bool isChecked = false;

                            if (possibleScopes[i].scope == "https://www.googleapis.com/auth/userinfo.email")
                            {
                                isChecked = true;
                            }

                            allPossibleChoices.Add(new ScopeChoice(i + 1, possibleScopes[i].scope, possibleScopes[i].description, isChecked));
                        }
                    }

                    foreach (var choice in allPossibleChoices)
                    {
                        PrintPretty(choice.ToString(), "Yellow");
                    }
                    #endregion

                    string script = string.Empty;

                    if (!hasSelectedOnce)
                    {
                        script = "Read-Host '\nEnter your choices, separated by commas'";
                    }
                    else
                    {
                        script = "Read-Host '\nToggle your choices separated by commas or hit [enter] to finish and authenticate'";
                    }
                    Collection<PSObject> results = invokablePSInstance.InvokeCommand.InvokeScript(script);
                    string rList = results[0].ToString().Replace(" ", "");

                    List<string> stringChoices = new List<string>(rList.Split(','));

                    //Make sure something was chosen
                    if (stringChoices.Count == 1 && hasSelectedOnce)
                    {
                        if (stringChoices[0] == "")
                        {
                            properlySelected = true;
                            break;
                        }
                    }
                    else if (stringChoices.Count == 0 && !hasSelectedOnce)
                    {
                        PrintPretty("\nPlease choose one or more scopes to authenticate", "Red");
                        properlySelected = false;
                        hasSelectedOnce = false;
                        break;
                    }

                    int temp;

                    //Parse the scope choices from the user
                    try
                    {
                        foreach (string sChoice in stringChoices)
                        {
                            temp = int.Parse(sChoice);

                            if (temp > 0 && temp <= possibleScopes.Count)
                            {
                                if (!intChoices.Contains(temp)) {
                                    intChoices.Add(temp);
                                }
                                else
                                {
                                    intChoices.Remove(temp);
                                    allChoicesSelected = false; //just in case we had all selected and removed one
                                }
                            }
                            else if (temp == 0)
                            {
                                if (allChoicesSelected)
                                {
                                    //they were all selected before, and now they're being toggled
                                    intChoices = new HashSet<int>();
                                    hasSelectedOnce = false;
                                }
                                else
                                {   
                                    foreach (var choice in allPossibleChoices)
                                    {
                                        if (choice.Choice != 0)
                                        {
                                            intChoices.Add(choice.Choice);
                                        }
                                    }
                                }

                                allChoicesSelected = !allChoicesSelected;
                            }
                            else
                            {
                                PrintPretty("\nOne or more selections not within bounds. Please try again.\n", "Red");
                                properlySelected = false;
                                break;
                            }

                            if (intChoices.Count > 0) hasSelectedOnce = true;
                        }

                        //No errors found in the input, replace the numbers with checkmarks or remove them as needed
                        foreach (var choice in allPossibleChoices)
                        {
                            choice.IsChecked = (intChoices.Contains(choice.Choice)) ? true : false;
                        }
                    }
                    catch
                    {
                        PrintPretty("\nInvalid Selection, try again\n", "Red");
                        properlySelected = false;
                        hasSelectedOnce = false;
                    }
                }
                #endregion


                HashSet<string> scopesResult = new HashSet<string>();

                foreach (var intChoice in intChoices)
                {
                    scopesResult.Add(allPossibleChoices[intChoice].Scope);
                }

                return scopesResult;

                //List<ScopeInfo> results = new List<ScopeInfo>();

                ////Selections have been confirmed and validated, move on.
                //if (all)
                //{
                //    scopesByApiDict[api + ":" + version] = scopes;
                //}
                //else
                //{
                //    if (intChoices.Count != 0)
                //    {
                //        List<ScopeInfo> results = new List<ScopeInfo>();
                //        foreach (int choice in intChoices)
                //        {
                //            results.Add(scopes[choice - 1]);
                //        }

                //        scopesByApiDict[api + ":" + version] = results;
                //    }
                //    else
                //    {
                //        scopesByApiDict[api + ":" + version] = new List<ScopeInfo>();
                //    }
                //}

                //Now verify the selection of scopes
                //PrintPretty("\nPlease review the following scopes")

            //}
        }

        public AuthenticationInfo ChooseScopesAndAuthenticate(string api, string version)
        {
            HashSet<string> scopes = ChooseApiScopesLoop(api, version);

            scopes = CheckForRequiredScope(scopes);

            string script = "Read-Host '\nYou will now authenticate for this API. Press any key to continue'";
            Collection<PSObject> results = invokablePSInstance.InvokeCommand.InvokeScript(script);

            //Now, authenticate.
            AuthenticationInfo info = OAuth2Base.AuthorizeUser(api + ":" + version, scopes);

            PrintPretty("Scopes have been authenticated and saved.", "green");

            return info;
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
            invokablePSInstance.InvokeCommand.InvokeScript(script);
        }

        ///// <summary>Returns the contents of the ScopesByApiDict in to a single hashset.</summary>
        //public HashSet<string> ScopesDictToHash()
        //{
        //    HashSet<string> scopesHash = new HashSet<string>();

        //    foreach (string key in scopesByApiDict.Keys)
        //    {
        //        foreach (ScopeInfo scopeInfo in scopesByApiDict[key])
        //        {
        //            scopesHash.Add(scopeInfo.scope);
        //        }
        //    }

        //    return scopesHash;
        //}

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
