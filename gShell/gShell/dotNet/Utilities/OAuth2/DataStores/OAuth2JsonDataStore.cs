using System;
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
    class OAuth2JsonDataStore : IOAuth2DataStore
    {
        #region Parameters

        private static string destFolder = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData), @"gShell\");
        private static string destFile = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData), @"gShell\gShell_OAuth2.json");

        #endregion

        public OAuth2Info LoadInfo()
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

        public void SaveInfo(OAuth2Info infoToSave)
        {
            string json = JsonConvert.SerializeObject(infoToSave, Formatting.Indented);
            File.WriteAllText(destFile, json);
        }
    }
}
