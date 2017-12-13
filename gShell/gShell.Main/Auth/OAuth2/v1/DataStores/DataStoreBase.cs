using System.IO;

namespace gShell.Main.Auth.OAuth2.v1.DataStores
{
    public abstract class DataStoreBase : IOAuth2DataStore
    {
        public abstract string fileName { get; set; }

        public string destFolder { get; set; }

        public string destFile { get { return Path.Combine(destFolder, fileName); } }

        public DataStoreBase(string DestinationFolder)
        {
            var attr = File.GetAttributes(DestinationFolder);

            if (!attr.HasFlag(FileAttributes.Directory))
            {
                destFolder = Path.GetDirectoryName(DestinationFolder);
                fileName = Path.GetFileName(DestinationFolder);
            }
            else
            {
                destFolder = DestinationFolder;
            }
        }

        protected void CheckOrCreateDirectory()
        {
            if (!System.IO.Directory.Exists(destFolder))
            {
                System.IO.Directory.CreateDirectory(destFolder);
            }
        }

        public abstract OAuth2Info LoadInfo();

        public abstract void SaveInfo(OAuth2Info infoToSave);
    }
}
