using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Text;

using Google.Apis.Auth.OAuth2;
using Data = Google.Apis.GroupsMigration.v1.Data;

using gGroupssettings = gShell.dotNet.GroupsMigration;

namespace gShell.Cmdlets.GroupsMigration
{
    public enum UploadTypeEnum
    {
        media, resumable
    }

    [Cmdlet(VerbsCommon.New, "GGroupsMigration",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGGroupsMigration : GroupsMigrationBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string GroupId { get; set; }

        [Parameter(Position = 2,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FilePath { get; set; }

        [Parameter(Position = 3,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public UploadTypeEnum UploadType { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("GroupsMigration", "New-GGroupsMigration"))
            {
                using (FileStream stream = File.OpenRead(FilePath))
                {
                    archive.Insert(GroupId, stream, UploadType.ToString());
                }
            }
        }
    }
}
