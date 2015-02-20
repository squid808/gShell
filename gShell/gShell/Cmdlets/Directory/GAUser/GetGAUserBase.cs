using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.PowerShell.Commands;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using gShell.OAuth2;

namespace gShell.DirectoryCmdlets.GAUser
{
    /// <summary>
    /// This class serves as a base for any class that needs to return a google user object, and contains
    /// appropriate methods to return one or multiple users.
    /// </summary>
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
        protected List<User> RetrieveCachedUsers(bool forcedReload = false)
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

        /// <summary>
        /// Returns a GShell formatted user object. Use this if you want the entire user object.
        /// </summary>
        /// <returns></returns>
        protected GShellUserObject GetOneCustomUser(string userName)
        {
            return (new GShellUserObject(GetOneUser(userName)));
        }

        /// <summary>
        /// Returns a list of GShell formatted user objects. Use this if you want the entire user objects.
        /// </summary>
        /// <returns></returns>
        protected List<GShellUserObject> GetAllCustomUsers()
        {
            return (GShellUserObject.ConvertList(GetAllUsers()));
        }

        /// <summary>
        /// Returns all cached gShell formatted user objects. Use this if you want the entire user object.
        /// </summary>
        /// <param name="forceCacheReload"></param>
        /// <returns></returns>
        protected List<GShellUserObject> GetAllCustomCachedUsers(bool forceCacheReload)
        {
            return (GShellUserObject.ConvertList(RetrieveCachedUsers(forceCacheReload)));
        }

        /// <summary>
        /// This gets a raw user result from google.
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        protected User GetOneUser(string UserName)
        {
            string fullEmail = OAuth2Base.GetFullEmailAddress(UserName, Domain);

            User returnedUser = directoryServiceDict[Domain].
                        Users.Get(fullEmail).Execute();

            return (returnedUser);
        }

        /// <summary>
        /// Returns a list of raw users.
        /// </summary>
        /// <returns></returns>
        protected List<User> GetAllUsers()
        {
            //TODO: Figure out multi-domain accounts

            UsersResource.ListRequest request = directoryServiceDict[Domain].Users.List();

            if (MultiDomain)
            {
                request.Customer = OAuth2Base.currentUserInfo.Id;
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
                     (returnedList.Count + 1).ToString(),
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
        public DateTime? LastLoginTime;

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
        public static List<GShellUserObject> ConvertList(List<User> userList)
        {
            List<GShellUserObject> customList = new List<GShellUserObject>();

            foreach (User user in userList)
            {
                customList.Add(new GShellUserObject(user));
            }

            return (customList);
        }
    }
}
