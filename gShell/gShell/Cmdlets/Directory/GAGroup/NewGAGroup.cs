using System;
using System.Collections.Generic;
using System.Management.Automation;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using gShell.OAuth2;

namespace gShell.DirectoryCmdlets.GAGroup
{
    [Cmdlet(VerbsCommon.New, "GAGroup",
          DefaultParameterSetName = "PasswordGenerated",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAGroup")]
    public class NewGAGroup : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The email name of the group to be created.")]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = false,
            HelpMessage = "The formatted name of the group to be created.")]
        public string FormattedName { get; set; }

        [Parameter(Position = 3,
            Mandatory = false,
            HelpMessage = "The description of the group to be created.")]
        public string Description { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(FormattedName, "New-GAGroup"))
            {
                CreateGroup();
            }
        }

        private void CreateGroup()
        {
            string fullEmail = OAuth2Base.GetFullEmailAddress(GroupName, Domain);

            Group groupAcct = new Group();

            groupAcct.Email = fullEmail;

            if (!string.IsNullOrWhiteSpace(FormattedName)) {
                groupAcct.Name = FormattedName;
            }

            if (!string.IsNullOrWhiteSpace(Description))
            {
                groupAcct.Description = Description;
            }

            directoryServiceDict[Domain].Groups.Insert(groupAcct).Execute();
        }

    }
}
