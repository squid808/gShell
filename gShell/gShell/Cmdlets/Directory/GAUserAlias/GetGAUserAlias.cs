using System.Collections.Generic;
using System.Management.Automation;
using Data = Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.Cmdlets.Directory.GAUserAlias
{
    [Cmdlet(VerbsCommon.Get, "GAUserAlias",
          DefaultParameterSetName = "OneUser",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAUserAlias")]
    public class GetGAUserAlias : DirectoryBase
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
                    if (ShouldProcess(UserName, "Get-GAUserAlias"))
                    {
                        WriteObject(GetOneUserAlias());
                    }
                    break;

                case "AllUserAliases":
                    if (ShouldProcess("All User Aliases", "Get-GAUserAlias"))
                    {
                        GetAllAliasesMain();
                    }
                    break;
            }

        }

        private List<Data.Alias> GetOneUserAlias()
        {
            string fullEmail = GetFullEmailAddress(UserName, Domain);

            List<Data.Alias> aliasList = gShell.dotNet.Directory.Users.Aliases.List(fullEmail);

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

        private List<GAUserAliasObject> GetAllCustomAliases()
        {
            List<GAUserAliasObject> customAliasList = new List<GAUserAliasObject>();

            List<Data.Alias> aliasList = GetAllAliases();

            foreach (Data.Alias alias in aliasList)
            {
                customAliasList.Add(new GAUserAliasObject(alias.PrimaryEmail, alias.AliasValue, alias));
            }

            return customAliasList;
        }

        /// <summary>
        /// Take a list of users who have an Data.Alias, and for each user get a list of their aliases. Makes potentially many API calls.
        /// </summary>
        private List<Data.Alias> GetAllAliases()
        {
            HashSet<Data.User> usersList = new HashSet<Data.User>();
            
            foreach (Data.User user in (Users.List(new dotNet.Directory.Users.UsersListProperties(){
                fields = "nextPageToken,users(aliases,primaryEmail)"
            }))){
                if (user.Aliases != null) {
                    usersList.Add(user);
                }
            }

            List<Data.Alias> aliasList = new List<Data.Alias>();

            int i = 1;

            foreach (Data.User user in usersList)
            {
                UpdateProgressBar(i, usersList.Count, "Gathering aliases",
                    string.Format("-Collecting alias for user {0} of {1}",
                    i, usersList.Count));
                aliasList.AddRange(Users.Aliases.List(user.PrimaryEmail));
                i++;
            }

            return aliasList;
        }
    }

    public class GAUserAliasObject
    {
        public string UserName;
        public string Alias;
        public Data.Alias BaseObject;

        public GAUserAliasObject(string _userName, string _alias, Data.Alias baseAlias)
        {
            UserName = _userName;
            Alias = _alias;
            BaseObject = baseAlias;
        }
    }
}
