//TODO: Consider using an SQLite DB to store ETags/UserID on demand when getting users or deleting users

using System.Collections.Generic;
using System.Management.Automation;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.DirectoryCmdlets.GAUser
{
    [Cmdlet("Restore", "GAUser",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Restore-GAUser")]
    public class RestoreGAUser : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The unique UserID")]
        [ValidateNotNullOrEmpty]
        public string UserID { get; set; }

        //Domain position = 1

        //[Parameter(Position = 2,
        //    Mandatory = true)]
        //public string ETag { get; set; }

        [Parameter(Position = 3,
            Mandatory = false,
            HelpMessage = "The OrgUnitPath")]
        public string OrgUnitPath { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(UserID, "Restore-GAUser"))
            {
                RestoreUser();
            }
        }

        private void RestoreUser()
        {
            UserUndelete undelete = new UserUndelete();

            if (string.IsNullOrWhiteSpace(OrgUnitPath))
            {
                undelete.OrgUnitPath = @"/";
            }
            else
            {
                undelete.OrgUnitPath = OrgUnitPath;
            }

            directoryServiceDict[Domain].Users.Undelete(undelete, UserID).Execute();
        }
    }
}
