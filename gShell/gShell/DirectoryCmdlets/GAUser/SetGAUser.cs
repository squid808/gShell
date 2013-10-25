using System;
using System.Collections.Generic;
using System.Management.Automation;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.DirectoryCmdlets.GAUser
{
    [Cmdlet(VerbsCommon.Set, "GAUser",
          SupportsShouldProcess = true)]
    public class SetGAUser : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Help Text")]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        //Domain position = 1

        [Parameter(Position = 2)]
        public string NewGivenName { get; set; }

        [Parameter(Position = 3)]
        public string NewFamilyName { get; set; }

        [Parameter(Position = 4)]
        public string NewUserName { get; set; }

        [Parameter(Position = 5)]
        public bool? Suspended { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            UpdateUser();
        }

        private void UpdateUser()
        {
            string fullEmail = GetFullEmailAddress(UserName, Domain);

            //User userAcct = directoryServiceDict[Domain].Users.Get(fullEmail).Execute();
            User userAcct = new User();

            if (null == userAcct)
            {
                WriteError(new ErrorRecord(new Exception(
                    string.Format("No user {0} was found to update.",fullEmail)),
                        "", ErrorCategory.InvalidData, UserName));
            }

            if (String.IsNullOrWhiteSpace(NewGivenName) &&
                String.IsNullOrWhiteSpace(NewFamilyName) &&
                String.IsNullOrWhiteSpace(NewUserName) &&
                !Suspended.HasValue)
            {
                WriteError(new ErrorRecord(new Exception(
                    string.Format("No data was enetered to update {0}.", fullEmail)),
                        "", ErrorCategory.InvalidData, UserName));
            }

            if (Suspended.HasValue)
            {
                userAcct.Suspended = Suspended;
            }

            if (!String.IsNullOrWhiteSpace(NewGivenName))
            {
                userAcct.Name.GivenName = NewGivenName;
            }

            if (!String.IsNullOrWhiteSpace(NewFamilyName))
            {
                userAcct.Name.FamilyName = NewFamilyName;
            }

            if (!String.IsNullOrWhiteSpace(NewUserName))
            {
                NewUserName = GetFullEmailAddress(NewUserName, Domain);

                userAcct.PrimaryEmail = NewUserName;
            }

            directoryServiceDict[Domain].Users.Patch(userAcct, fullEmail).Execute();
        }
    }
}
