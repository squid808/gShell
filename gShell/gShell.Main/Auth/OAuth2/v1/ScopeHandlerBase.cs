using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using gShell.Main.PowerShell.Base.v1;
using gShell.Main.PowerShell.Cmdlets;
using Google.Apis.Auth.OAuth2;

namespace gShell.Main.Auth.OAuth2.v1
{
    public abstract class ScopeHandlerBase : OAuth2CmdletBase
    {
        #region Properties

        #endregion

        #region PowerShell Methods
        protected override void BeginProcessing() { }
        #endregion

        #region Authentication & Processing
        /// <summary>
        /// A method specific to each inherited object, called during authentication. Must be implemented.
        /// </summary>
        protected override AuthenticatedUserInfo Authenticate(AuthenticatedUserInfo AuthUserInfo, ClientSecrets Secrets) { return null; }
        #endregion

        #region SubClasses

        ///// <summary> A collection of the information representing an API. </summary>
        //public class ApiChoice
        //{
        //    public int Choice;
        //    /// <summary> The API in Name:Version format, eg. admin:discovery_v1 or calendar:v2 </summary>
        //    public string API
        //    {
        //        get
        //        {
        //            return string.Format("{0}:{1}", Name, Version);
        //        }
        //    }
        //    public string Version { get; set; }
        //    public string Name { get; set; }

        //    public ApiChoice(int choice, string version, string name)
        //    {
        //        Choice = choice;
        //        Version = version;
        //        Name = name;
        //    }

        //    public override string ToString()
        //    {
        //        return string.Format("[{0}]\t{1}", Choice, API);
        //    }
        //}

        //public class ApiInfo
        //{
        //    public string description;
        //    public string id;
        //    public string name
        //    {
        //        get
        //        {
        //            return id.Split(':')[0];
        //        }
        //    }
        //    public string version
        //    {
        //        get
        //        {
        //            return id.Split(':')[1];
        //        }
        //    }
        //}

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
            }
        }

        #endregion

        #region User Input Loops

        ///// <summary> Part of a loop that will return an Api Choice </summary>
        //public ApiChoice ChooseApiLoop()
        //{
        //    bool success = false;
        //    int result = -1;

        //    while (!success)
        //    {
        //        PrintPretty("Please choose an API to explore its scope options:\n", "Green");

        //        foreach (var choice in apiChoices)
        //        {
        //            PrintPretty(choice.ToString(), "Yellow");
        //        }

        //        string script = "Read-Host '\nEnter the number of your choice'";
        //        Collection<PSObject> results = invokablePSInstance.InvokeCommand.InvokeScript(script);
        //        int temp;
        //        try
        //        {
        //            temp = int.Parse(results[0].ToString());
        //            if (temp > 0 && temp <= apiChoices.Length)
        //            {
        //                result = temp;
        //                success = true;
        //            }
        //            else
        //            {
        //                PrintPretty("\nSelection not within bounds. Please try again.\n", "Red");
        //            }
        //        }
        //        catch
        //        {
        //            PrintPretty("\nInvalid Selection, try again\n", "Red");
        //        }
        //    }

        //    return apiChoices[result - 1];
        //}


        //public List<ScopeInfo> GetScopesForAPI(string api, string version, out string description,
        //    bool? readOnly = null)
        //{
            
        //}

        /// <summary>
        /// Part of a loop that will return a chosen subset of scopes from an Api's list.
        /// </summary>
        public static HashSet<string> ChooseApiScopesLoop(PSCmdlet invokableInstance, string api, string version, ScopeInfo[] scopeInfos = null)
        {
            bool? useReadOnlyScopes = null;
            bool isReadOnlyChosen = false;

            //string description;
            List<ScopeInfo> possibleScopes = new List<ScopeInfo>();
            possibleScopes.AddRange(scopeInfos);
            List<ScopeInfo> readOnlyScopes = possibleScopes.Where(x => x.Uri.Contains("readonly")).ToList();
            List<ScopeInfo> actionOnlyScopes = possibleScopes.Where(x => !x.Uri.Contains("readonly")).ToList();

            if (readOnlyScopes.Count > 0 && actionOnlyScopes.Count > 0)
            {
                #region ReadOnly Choice
                while (!isReadOnlyChosen)
                {
                    PrintPretty(invokableInstance, string.Format("\nWould you like to view all {0} scopes [a], " +
                                              "the {1} read-only scopes [r] or {2} all other scopes [o]?",
                        possibleScopes.Count.ToString(), readOnlyScopes.Count.ToString(),
                        actionOnlyScopes.Count.ToString()), "Green");

                    string readOnlyResultScript = "Read-Host '\nEnter your choice'";

                    Collection<PSObject> readOnlyResultResults =
                        invokableInstance.InvokeCommand.InvokeScript(readOnlyResultScript);

                    string readOnlyResultResult = readOnlyResultResults[0].ToString().Substring(0, 1).ToLower();

                    switch (readOnlyResultResult)
                    {
                        case "a":
                            useReadOnlyScopes = null;
                            isReadOnlyChosen = true;
                            break;
                        case "r":
                            useReadOnlyScopes = true;
                            isReadOnlyChosen = true;
                            break;
                        case "o":
                            useReadOnlyScopes = false;
                            isReadOnlyChosen = true;
                            break;
                        default:
                            PrintPretty(invokableInstance, "\nInvalid choice, please try again.", "Red");
                            break;
                    }
                }
            }

            #endregion

            #region Selecting Scopes
            bool properlySelected = false;
            bool hasSelectedOnce = false;
            HashSet<int> intChoices = new HashSet<int>();
            List<ScopeChoice> allPossibleChoices = null;
            bool allChoicesSelected = false;

            if (useReadOnlyScopes.HasValue)
            {
                if (useReadOnlyScopes.Value == true)
                {
                    possibleScopes = readOnlyScopes;
                }
                else
                {
                    possibleScopes = actionOnlyScopes;
                }
            }

            while (!properlySelected)
            {
                //intChoices = new HashSet<int>(); //in case we loop, reset it

                #region Print Choices
                PrintPretty(invokableInstance, "\n" + api + ":" + version + " - " + "\n", "Green");
                if (!hasSelectedOnce)
                {
                    PrintPretty(invokableInstance, "\nPlease select the scope(s) you'd like to grant gShell permission to:\n", "Green");
                }
                else
                {
                    PrintPretty(invokableInstance, "\nPlease confirm the scope(s) you'd like to grant gShell permission to:\n", "Green");
                }

                if (allPossibleChoices == null)
                {
                    allPossibleChoices = new List<ScopeChoice>();

                    allPossibleChoices.Add(new ScopeChoice(0, "All", "All scopes in this list."));

                    for (int i = 0; i < possibleScopes.Count; i++)
                    {
                        bool isChecked = possibleScopes[i].Uri == "https://www.googleapis.com/auth/userinfo.email";

                        allPossibleChoices.Add(new ScopeChoice(i + 1, possibleScopes[i].Uri, possibleScopes[i].Description, isChecked));
                    }
                }

                foreach (var choice in allPossibleChoices)
                {
                    string color = "Yellow";
                    if (choice.IsChecked) color = "DarkYellow";
                    PrintPretty(invokableInstance, choice.ToString(), color);
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

                Collection<PSObject> results = invokableInstance.InvokeCommand.InvokeScript(script);
                string rList = results[0].ToString().Replace(" ", "");

                List<string> stringChoices = new List<string>(rList.Split(','));

                //Make sure something was chosen
                if (stringChoices.Count == 1 && hasSelectedOnce)
                {
                    if (stringChoices[0] == "")
                    {
                        var checkedCount = allPossibleChoices.Where(x => x.IsChecked).Count();

                        if (checkedCount > 20)
                        {
                            invokableInstance.WriteWarning(
                                string.Format(
                                    "You have chosen {0} scopes. Scope counts greater than 20 may cause some scopes to be ignored by Google. To proceed anyways, enter Y. Otherwise, enter N to go back and choose your scopes again.",
                                    checkedCount));
                            var bigScopeScript = "Read-Host";
                            Collection<PSObject> bigScopesResult =
                                invokableInstance.InvokeCommand.InvokeScript(bigScopeScript);
                            string bigScopesResultOne = bigScopesResult[0].ToString();

                            if (!string.IsNullOrWhiteSpace(bigScopesResultOne)
                                && bigScopesResultOne.ToLower()[0] == 'y')
                            {
                                properlySelected = true;
                                break;
                            }
                        }
                        else
                        {
                            properlySelected = true;
                            break;
                        }
                    }
                }
                else if (stringChoices.Count == 0 && !hasSelectedOnce)
                {
                    PrintPretty(invokableInstance, "\nPlease choose one or more scopes to authenticate", "Red");
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
                            if (!intChoices.Contains(temp))
                            {
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
                            PrintPretty(invokableInstance, "\nOne or more selections not within bounds. Please try again.\n", "Red");
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
                    PrintPretty(invokableInstance, "\nInvalid Selection, try again\n", "Red");
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
        }

        public static IEnumerable<string> ChooseScopes(PSCmdlet invokableInstance, string api, string version, HashSet<string> providedScopes = null, ScopeInfo[] scopeInfos = null)
        {

            HashSet<string> scopes;

            if (providedScopes == null)
            {
                scopes = ChooseApiScopesLoop(invokableInstance, api, version, scopeInfos);
            }
            else
            {
                scopes = providedScopes;
            }

            scopes = CheckForRequiredScope(scopes);
            PrintPretty(invokableInstance, "Scopes have been chosen, thank you.", "green");
            return scopes;
        }

        public static AuthenticatedUserInfo ChooseScopesAndAuthenticate(PSCmdlet invokableInstance, string api, string version, ClientSecrets secrets, ScopeInfo[] scopeInfos = null)
        {
            var info = new AuthenticatedUserInfo()
            {
                apiNameAndVersion = api + ":" + version,
                scopes = ChooseScopes(invokableInstance, api, version, scopeInfos: scopeInfos)
            };

            string script = "Read-Host '\nYou will now authenticate for this API. Press any key to continue'";
            Collection<PSObject> results = invokableInstance.InvokeCommand.InvokeScript(script);

            //Now, authenticate.
            info = OAuth2Base.GetAuthTokenFlow(info, secrets, force: true);

            PrintPretty(invokableInstance, string.Format("{0}:{1} has been authenticated and saved.", api, version), "green");

            return info;
        }

        public enum ScopeSelectionTypes { None, All, ReadOnly, ReadWrite }

        //public AuthenticatedUserInfo AuthenticatePreChosenScopes(string api, string version, ClientSecrets secrets,
        //    ScopeSelectionTypes PreSelectScopes = ScopeSelectionTypes.None)
        //{
        //    if (PreSelectScopes == ScopeSelectionTypes.None)
        //    {
        //        return ChooseScopesAndAuthenticate(api, version, secrets);
        //    }
        //    else
        //    {
        //        //Google.Apis.Discovery.v1.Data.RestDescription restDescription = apis.RestData(api, version);

        //        HashSet<string> scopes = new HashSet<string>();

        //        List<ScopeInfo> possibleScopes = new List<ScopeInfo>();
        //        possibleScopes.AddRange(scopeInfos);

        //        switch (PreSelectScopes)
        //        {
        //            case ScopeSelectionTypes.ReadOnly:
        //                scopes.UnionWith(possibleScopes.Where(x => x.Uri.Contains("readonly")).Select(x => x.Uri));
        //                break;

        //            case ScopeSelectionTypes.ReadWrite:
        //                scopes.UnionWith(possibleScopes.Where(x => !x.Uri.Contains("readonly")).Select(x => x.Uri));
        //                break;

        //            default:
        //                scopes.UnionWith(possibleScopes.Select(x => x.Uri));
        //                break;
        //        }

        //        var authUserInfo = new AuthenticatedUserInfo()
        //        {
        //            apiNameAndVersion = api + ":" + version,
        //            scopes = CheckForRequiredScope(scopes)
        //        };

        //        AuthenticatedUserInfo info = OAuth2Base.GetAuthTokenFlow(authUserInfo, secrets, force: true);

        //        return info;
        //    }
        //}

        #endregion

        #region Helper Methods

        /// <summary>Ensures the required scopes (email) are in the scopes hash.</summary>
        public static HashSet<string> CheckForRequiredScope(HashSet<string> scopes)
        {
            if (!scopes.Contains("https://www.googleapis.com/auth/userinfo.email"))
            {
                scopes.Add("https://www.googleapis.com/auth/userinfo.email");
            }

            return scopes;
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

        ///// <summary>Return a list of scopes with both their scope and description.</summary>
        //public List<ScopeInfo> GetScopesForAPI(string api, string version, out string description, bool? readOnly = null)
        //{
        //    Google.Apis.Discovery.v1.Data.RestDescription restDescription = apis.RestData(api, version);

        //    var scopesDict = (Dictionary<string, Google.Apis.Discovery.v1.Data.RestDescription.AuthData.Oauth2Data.ScopesDataElement>)restDescription.Auth.Oauth2.Scopes;

        //    var scopesList = new List<ScopeInfo>();

        //    foreach (string key in scopesDict.Keys)
        //    {
        //        scopesList.Add(new ScopeInfo() { scope = key, description = scopesDict[key].Description });
        //    }

        //    description = restDescription.Description;

        //    return scopesList;
        //}

        /// <summary>Get a list of ApiInfo.</summary>
        //public List<ApiInfo> GetAPIList(bool preferred = true)
        //{
        //    Google.Apis.Discovery.v1.Data.DirectoryList dirList = apis.List(new Discovery.Apis.DiscoveryListProperties() { preferred = preferred });

        //    List<ApiInfo> info = new List<ApiInfo>();

        //    foreach (Google.Apis.Discovery.v1.Data.DirectoryList.ItemsData dir in dirList.Items)
        //    {
        //        info.Add(new ApiInfo() { description = dir.Description, id = dir.Id });
        //    }

        //    return info;
        //}

        #endregion

    }
}
