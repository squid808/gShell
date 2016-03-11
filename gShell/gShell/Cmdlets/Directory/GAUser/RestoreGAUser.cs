using System.Management.Automation;
using Data = Google.Apis.admin.Directory.directory_v1.Data;

namespace gShell.Cmdlets.Directory.GAUser
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
            Data.UserUndelete undelete = new Data.UserUndelete();

            if (string.IsNullOrWhiteSpace(OrgUnitPath))
            {
                undelete.OrgUnitPath = @"/";
            }
            else
            {
                undelete.OrgUnitPath = OrgUnitPath;
            }

            users.Undelete(undelete, UserID);
        }
    }
}
