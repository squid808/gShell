using System;
using System.IO;
using System.Management.Automation;
using Data = Google.Apis.admin.Directory.directory_v1.Data;
using gShell.dotNet.Utilities;

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

        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string FilePath { get; set; }

        [Parameter(Position = 3,
            Mandatory = false)]
        public SwitchParameter NoClobber { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            UserKey = GetFullEmailAddress(UserKey, Domain);

            if (ShouldProcess(UserKey, "Get-GAUserPhoto"))
            {
                try {
                    Data.UserPhoto result = users.photos.Get(UserKey);

                    if (FilePath != null)
                    {
                        FilePath = Path.Combine(Path.GetDirectoryName(FilePath),string.Format("{0}.{1}",Path.GetFileNameWithoutExtension(FilePath),result.MimeType.Split('/')[1]));

                        Utils.SaveImageFromBase64(result.PhotoData, FilePath, NoClobber.IsPresent);
                    }
                    else
                    {
                        WriteObject(result);
                    }
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
            UserKey = GetFullEmailAddress(UserKey, Domain);

            if (ShouldProcess(UserKey, "Remove-GAUserPhoto"))
            {
                if (Force || ShouldContinue((String.Format("Photo for User {0} will be removed from the {1} Google Apps domain.\nContinue?",
                    UserKey, Domain)), "Confirm Google Apps User Photo Removal"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove Photo for User {0}...",
                            UserKey));
                        users.photos.Delete(UserKey);
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
        public string Path { get; set; }

        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public int? Height { get; set; }

        [Parameter(Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public MimeTypeEnum? MimeType { get; set; }

        [Parameter(Position = 5,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public int? Width { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            UserKey = GetFullEmailAddress(UserKey, Domain);

            if (ShouldProcess(UserKey, "Set-GAUserPhoto"))
            {
                Data.UserPhoto body = new Data.UserPhoto();

                if (MimeType.HasValue)
                {
                    body.MimeType = MimeType.Value.ToString();
                }

                if (Height.HasValue)
                {
                    body.Height = Height.Value;
                }

                if (Width.HasValue)
                {
                    body.Width = Width.Value;
                }

                body.PhotoData = Utils.LoadImageToBase64(Path);

                WriteObject(users.photos.Update(body, UserKey));
            }
        }
    }

    public enum MimeTypeEnum
    {
        JPEG, PNG, GIF, BMP, TIFF
    }   
}
