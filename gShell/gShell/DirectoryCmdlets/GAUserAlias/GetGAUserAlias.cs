using System.Collections.Generic;
using System.Management.Automation;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using gShell.DirectoryCmdlets.GAUser;

namespace gShell.DirectoryCmdlets.GAUserAlias
{
    [Cmdlet(VerbsCommon.Get, "GAUserAlias",
          DefaultParameterSetName = "OneUser",
          SupportsShouldProcess = true)]
    public class GetGAUserAlias : GetGAUserBase
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
            ParameterSetName = "AllUserAliases")]
        public SwitchParameter All { get; set; }

        [Parameter(Position = 3,
            ParameterSetName = "AllUserAliases")]
        public SwitchParameter Cache { get; set; }

        [Parameter(Position = 4,
            ParameterSetName = "AllUserAliases")]
        public SwitchParameter ForceCacheReload { get; set; }

        [Parameter(Position = 5,
            ParameterSetName = "AllUserAliases")]
        public SwitchParameter ReturnGoogleAPIObjects { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case "OneUser":
                    WriteObject(GetOneUserAlias());
                    break;

                case "AllUserAliases":
                    GetAllAliasesMain();
                    break;
            }

        }

        private List<Alias> GetOneUserAlias()
        {
            string fullEmail = GetFullEmailAddress(UserName, Domain);

            Aliases returnedUserAliases = directoryServiceDict[Domain].
                Users.Aliases.List(fullEmail).Execute();

            List<Alias> aliasList = new List<Alias>();

            aliasList.AddRange(returnedUserAliases.AliasesValue);

            return (aliasList);
        }

        private void GetAllAliasesMain()
        {
            if (ReturnGoogleAPIObjects)
            {
                WriteObject(GetAllAliases());
            }
            else
            {
                WriteObject(GetAllCustomAliases());
            }
        }

        private List<User> GetUsersWithAliases()
        {
            //TODO: figure out how to handle this with a batch call
            List<User> userList = new List<User>();

            userList = RetrieveCachedUsers(ForceCacheReload);

            List<User> usersWithAliases = new List<User>();

            foreach (User user in userList)
            {
                if (user.Aliases != null)
                {
                    usersWithAliases.Add(user);
                }
            }

            return (usersWithAliases);
        }

        private List<GAUserAliasObject> GetAllCustomAliases()
        {
            List<GAUserAliasObject> customAliasList = new List<GAUserAliasObject>();

            List<Alias> aliasList = GetAllAliases();

            foreach (Alias alias in aliasList)
            {
                customAliasList.Add(new GAUserAliasObject(alias.PrimaryEmail, alias.AliasValue));
            }

            return customAliasList;
        }

        private List<Alias> GetAllAliases()
        {
            if (Cache)
            {
                return (RetrieveCachedAliases());
            }
            else
            {
                return (ProcessGetAllAliasRequest());
            }
        }

        private List<Alias> ProcessGetAllAliasRequest()
        {
            List<User> usersList = GetUsersWithAliases();

            List<Alias> aliasList = new List<Alias>();

            int i = 1;

            foreach (User user in usersList)
            {
                UpdateProgressBar(i, usersList.Count, "Gathering aliases",
                    string.Format("-Collecting alias for user {0} of {1}",
                    i, usersList.Count));
                aliasList.AddRange(directoryServiceDict[Domain].
                    Users.Aliases.List(user.PrimaryEmail).Execute().AliasesValue);
                i++;
            }

            return aliasList;
        }

        private List<Alias> RetrieveCachedAliases () {
            List<Alias> aliasList = new List<Alias>();

            if (cachedDomainAliases.ContainsKey(Domain) && !ForceCacheReload)
            {
                aliasList = cachedDomainAliases[Domain];
            }
            else
            {
                aliasList = ProcessGetAllAliasRequest();
                cachedDomainAliases[Domain] = aliasList;
            }

            return (aliasList);
        }
    }

    public class GAUserAliasObject
    {
        public string UserName;
        public string Alias;

        public GAUserAliasObject(string _userName, string _alias)
        {
            UserName = _userName;
            Alias = _alias;
        }
    }
}
