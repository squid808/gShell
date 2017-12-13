using System;
using System.IO;

namespace gShell.dotNet.Utilities.OAuth2.DataStores
{
    public abstract class DataStoreBase : IOAuth2DataStore
    {
        public abstract string fileName { get; }

        public string destFolder { get; set; }

        public string destFile { get { return Path.Combine(destFolder, fileName); } }

        public DataStoreBase(string DestinationFolder)
        {
            destFolder = DestinationFolder;
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
