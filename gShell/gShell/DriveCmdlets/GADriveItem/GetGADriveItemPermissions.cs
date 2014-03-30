using System;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using System.Management.Automation;
using gShell.DriveCmdlets;

namespace gShell.DriveCmdlets.GADriveItem
{
    [Cmdlet(VerbsCommon.Get, "GADriveItemPermissions",
          SupportsShouldProcess = true)]
    public class GetGADriveItemPermissions : DriveBase
    {
        [Parameter(Mandatory = false,
            ParameterSetName = "gShellFile",
            ValueFromPipeline = true,
            //ValueFromPipelineByPropertyName = true,
            HelpMessage = "The target user to control.")]
        [ValidateNotNullOrEmpty]
        public GShellDriveItemObject GShellFile { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = "DriveFile",
            ValueFromPipeline = true,
            //ValueFromPipelineByPropertyName = true,
            HelpMessage = "The target user to control.")]
        [ValidateNotNullOrEmpty]
        public File GoogleDriveFile { get; set; }

        [Parameter(Position = 2,
            Mandatory = false,
            ParameterSetName = "StringID",
            ValueFromPipeline = true,
            //ValueFromPipelineByPropertyName = true,
            HelpMessage = "The target user to control.")]
        [ValidateNotNullOrEmpty]
        public string FileId { get; set; }

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Drive Object", "Get-GADriveItemPermissions"))
            {
                GetItemPermissions();
            }
        }

        private void GetItemPermissions()
        {
            string _fileID = "";

            switch (ParameterSetName)
            {
                case ("gShellFile"):
                    _fileID = GShellFile.driveItemObject.Id;
                    break;

                case ("DriveFile"):
                    _fileID = GoogleDriveFile.Id;
                    break;

                case ("StringID"):
                    _fileID = FileId;
                    break;
            }

            PermissionsResource.ListRequest request = driveServiceDict[Domain][User].Permissions.List(_fileID);

            WriteObject(request.Execute());
        }
    }
}
