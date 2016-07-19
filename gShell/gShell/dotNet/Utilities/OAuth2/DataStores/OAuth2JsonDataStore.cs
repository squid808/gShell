using System.IO;
using Newtonsoft.Json;

namespace gShell.dotNet.Utilities.OAuth2.DataStores
{
    /// <summary>
    /// Responsible solely for the saving and loading of the OAuth2 information from a local serialized file.
    /// </summary>
    /// <remarks>
    /// This file is saved without encryption.
    /// </remarks>
    class OAuth2JsonDataStore : DataStoreBase, IOAuth2DataStore
    {
        #region Parameters

        public override string fileName { get { return "gShell_OAuth2.json"; } }

        #endregion

        #region Interface Implementation

        public OAuth2JsonDataStore(string DestinationFolder) : base(DestinationFolder) {}

        public override OAuth2Info LoadInfo()
        {
            OAuth2Info info = null;

            if (File.Exists(destFile))
            {
                using (StreamReader file = File.OpenText(destFile))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    info = (OAuth2Info)serializer.Deserialize(file, typeof(OAuth2Info));
                }
            }

            return info;
        }

        public override void SaveInfo(OAuth2Info infoToSave)
        {
            string json = JsonConvert.SerializeObject(infoToSave, Formatting.Indented);
            File.WriteAllText(destFile, json);
        }

        #endregion
    }
}
