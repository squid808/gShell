using System;
using System.Collections.Generic;
using System.Management.Automation;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using gShell.dotNet.Utilities.OAuth2;

namespace gShell.Cmdlets.Directory.GAUserAlias
{
    [Cmdlet(VerbsCommon.New, "GAUserAlias",
          DefaultParameterSetName = "PasswordGenerated",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAUserAlias")]
    public class NewGAUserAlias : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The user's main username")]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = true)]
        public string Alias { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(UserName, "New-GAUserAlias"))
            {
                CreateUserAlias();
            }
        }

        private void CreateUserAlias()
        {
            string fullEmail = OAuth2Base.GetFullEmailAddress(UserName, Domain);

            Alias aliasBody = new Alias();

            aliasBody.AliasValue = OAuth2Base.GetFullEmailAddress(Alias, Domain);

            directoryServiceDict[Domain].Users.Aliases.Insert(aliasBody, fullEmail).Execute();
        }

    }
}
