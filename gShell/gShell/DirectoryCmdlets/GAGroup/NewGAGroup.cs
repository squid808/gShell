using System;
using System.Collections.Generic;
using System.Management.Automation;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.DirectoryCmdlets.GAGroup
{
    [Cmdlet(VerbsCommon.New, "GAGroup",
          DefaultParameterSetName = "PasswordGenerated",
          SupportsShouldProcess = true)]
    public class NewGAGroup : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The email address of the group to be created")]
        [ValidateNotNullOrEmpty]
        public string EmailAddress { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = false)]
        public string GroupName { get; set; }

        [Parameter(Position = 3,
            Mandatory = false)]
        public string Description { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            CreateGroup();
        }

        private void CreateGroup()
        {
            string fullEmail = GetFullEmailAddress(EmailAddress, Domain);

            Group groupAcct = new Group();

            groupAcct.Email = fullEmail;

            if (!string.IsNullOrWhiteSpace(GroupName)) {
                groupAcct.Name = GroupName;
            }

            if (!string.IsNullOrWhiteSpace(Description))
            {
                groupAcct.Description = Description;
            }

            directoryServiceDict[Domain].Groups.Insert(groupAcct).Execute();
        }

    }
}
