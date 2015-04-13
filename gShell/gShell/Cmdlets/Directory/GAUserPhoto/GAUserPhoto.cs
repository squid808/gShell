using System;
using System.Collections.Generic;
using System.Drawing;
using System.Management.Automation;
using Data = Google.Apis.Admin.Directory.directory_v1.Data;
using Utils = gShell.dotNet.Utilities.Utils;

namespace gShell.Cmdlets.Directory.GAUserPhoto
{
    [Cmdlet(VerbsCommon.Get, "GAUserPhoto",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAUserPhoto")]
    public class GetGAUserPhoto : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string UserKey { get; set; }

        //Domain position = 1

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(UserKey, "Get-GAUserPhoto"))
            {
                try {
                    Data.UserPhoto photo = users.photos.Get(UserKey, Domain);
                    Image image = Utils.Base64StringToImage(photo.PhotoData);
                    image.Save(Path);
                } catch (Exception e) {
                    WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, UserKey));
                }
            }
        }
    }

    [Cmdlet(VerbsCommon.Remove, "GAUserPhoto",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GAUserPhoto")]
    public class RemoveGAUserPhoto : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string UserKey { get; set; }

        //Domain position = 1

        [Parameter(Position = 2)]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(UserKey, "Remove-GAUserPhoto"))
            {
                if (Force || ShouldContinue((String.Format("Photo for User {0} will be removed from the {1} Google Apps domain.\nContinue?",
                    UserKey, Domain)), "Confirm Google Apps User Photo Removal"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove Photo for User {0}...",
                            UserKey));
                        WriteObject(users.photos.Delete(UserKey, Domain));
                        WriteVerbose(string.Format("Removal of User {0}'s photo completed without error.",
                            UserKey));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, UserKey));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("User Photo deletion not confirmed"),
                        "", ErrorCategory.InvalidData, UserKey));
                }
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GAUserPhoto",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAUserPhoto")]
    public class SetGAUserPhoto : DirectoryBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string UserKey { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string UserPhotoPath { get; set; }

        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public int Height { get; set; }

        [Parameter(Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public MimeTypeEnum MimeType { get; set; }

        [Parameter(Position = 5,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public int Width { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(UserKey, "Set-GAUserPhoto"))
            {
                Data.UserPhoto body = new Data.UserPhoto();

                if (MimeType != null)
                {
                    body.MimeType = MimeType.ToString();
                }

                if (Height != 0)
                {
                    body.Height = Height;
                }

                if (Width != 0)
                {
                    body.Width = Width;
                }

                body.PhotoData = Utils.ImageToBase64String(UserPhotoPath);

                WriteObject(users.photos.Patch(body, UserKey, Domain));
            }
        }
    }

    public enum MimeTypeEnum
    {
        JPEG, PNG, GIF, BMP, TIFF
    }   
}
