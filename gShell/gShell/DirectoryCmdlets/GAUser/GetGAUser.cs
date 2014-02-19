using System.Collections.Generic;
using System.Management.Automation;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.DirectoryCmdlets.GAUser
{
    [Cmdlet(VerbsCommon.Get, "GAUser",
          DefaultParameterSetName = "OneUser",
          SupportsShouldProcess = true)]
    public class GetGAUser : GetGAUserBase
    {
        #region Properties

        [Parameter(Position = 0,
            ParameterSetName = "OneUser",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Help Text")]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            ParameterSetName = "AllUsers")]
        public SwitchParameter All { get; set; }

        [Parameter(Position = 3,
            ParameterSetName = "AllUsers")]
        public SwitchParameter Cache { get; set; }

        [Parameter(Position = 4,
            ParameterSetName = "AllUsers")]
        public SwitchParameter ForceCacheReload { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case "OneUser":
                    WriteObject(GetOneCustomUser());
                    break;

                case "AllUsers":
                    if (Cache)
                    {
                        WriteObject(GetAllCustomCachedUsers());
                    } else {
                        WriteObject(GetAllCustomUsers());
                    }
                    break;
            }
        }

        private GShellUserObject GetOneCustomUser()
        {
            return (new GShellUserObject(GetOneUser(UserName)));
        }

        private List<GShellUserObject> GetAllCustomUsers()
        {
            return (GShellUserObject.ConvertList(GetAllUsers()));
        }

        private List<GShellUserObject> GetAllCustomCachedUsers()
        {
            return (GShellUserObject.ConvertList(RetrieveCachedUsers(ForceCacheReload)));
        }
    }

    public class GetGAUserBase : DirectoryBase
    {
        [Parameter(ParameterSetName = "AllUsers")]
        public int MaxResults { get; set; }

        [Parameter(ParameterSetName = "AllUsers")]
        public SwitchParameter MultiDomain { get; set; }

        /// <summary>
        /// Retrieve a list of all users from the cache or, if it doesn't exist, the internet.
        /// </summary>
        /// <returns></returns>
        protected List<User> RetrieveCachedUsers(bool forcedReload=false)
        {
            List<User> usersList = new List<User>();

            if (cachedDomainUsers.ContainsKey(Domain) && !forcedReload)
            {
                usersList = cachedDomainUsers[Domain];
            }
            else
            {
                usersList = GetAllUsers();
                cachedDomainUsers[Domain] = usersList;
            }

            return usersList;
        }

        protected User GetOneUser(string UserName)
        {
            string fullEmail = GetFullEmailAddress(UserName, Domain);

            User returnedUser = directoryServiceDict[Domain].
                        Users.Get(fullEmail).Execute();

            return (returnedUser);
        }

        protected List<User> GetAllUsers()
        {
            //TODO: Figure out multi-domain accounts
            
            UsersResource.ListRequest request = directoryServiceDict[Domain].Users.List();

            if (MultiDomain)
            {
                request.Customer = currentUserInfo.Id;
            }
            else
            {
                request.Domain = Domain;
            }

            if (0 != MaxResults && 500 > MaxResults)
            {
                request.MaxResults = MaxResults;
            }
            else
            {
                request.MaxResults = 500;
            }

            StartProgressBar("Gathering accounts",
                "-Collecting accounts 1 to " + request.MaxResults.ToString());

            UpdateProgressBar(1, 2, "Gathering accounts", 
                "-Collecting accounts 1 to " + request.MaxResults.ToString());

            Users execution = request.Execute();

            List<User> returnedList = new List<User>();

            returnedList.AddRange(execution.UsersValue);

            while (!string.IsNullOrWhiteSpace(execution.NextPageToken) &&
                execution.NextPageToken != request.PageToken &&
                (0 == MaxResults || returnedList.Count < MaxResults))
            {
                request.PageToken = execution.NextPageToken;
                UpdateProgressBar(5, 10,
                    "Gathering accounts",
                    string.Format("-Collecting users {0} to {1}",
                     (returnedList.Count + 1 ).ToString(),
                     (returnedList.Count + request.MaxResults).ToString()));
                execution = request.Execute();
                returnedList.AddRange(execution.UsersValue);
            }

            UpdateProgressBar(1, 2, "Gathering accounts",
                "-Returning " + returnedList.Count.ToString() + " results.");

            return (returnedList);
        }
    }

    /// <summary>
    /// A custom class to more easily expose common attribtues for viewing
    /// </summary>
    public class GShellUserObject
    {
        public string GivenName;
        public string FamilyName;
        public string PrimaryEmail;
        public List<string> Aliases;
        public bool Suspended;
        public string OrgUnitPath;
        public string LastLoginTime;

        public User userObject;

        public GShellUserObject(User userObj)
        {
            Aliases = new List<string>();

            FamilyName = userObj.Name.FamilyName;
            GivenName = userObj.Name.GivenName;
            PrimaryEmail = userObj.PrimaryEmail;
            if (null != userObj.Aliases)
            {
                Aliases.AddRange(userObj.Aliases);
            }
            if (userObj.Suspended.HasValue)
            {
                Suspended = userObj.Suspended.Value;
            }
            OrgUnitPath = userObj.OrgUnitPath;
            LastLoginTime = userObj.LastLoginTime;

            userObject = userObj;
        }

        //TODO make this inherit from a superclass with a generic function
        public static List<GShellUserObject> ConvertList(List<User> userList) {
            List<GShellUserObject> customList = new List<GShellUserObject>();

            foreach (User user in userList)
            {
                customList.Add(new GShellUserObject(user));
            }

            return (customList);
        }
    }
}
