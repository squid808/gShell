using System;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace gShell.dotNet.Utilities.OAuth2.DataStores
{
    /// <summary>
    /// Responsible solely for the saving and loading of the OAuth2 information from a local serialized file.
    /// </summary>
    /// <remarks>
    /// This file is saved with encryption based on the user currently executing the assembly.
    /// </remarks>
    class OAuth2SerializerDataStore : IOAuth2DataStore
    {
        #region Parameters
        
        private static byte[] s_aditionalEntropy = { 8, 4, 5, 6, 6, 5, 6, 5, 9, 7, 2, 5, 9, 6, 1, 7, 3, 9 };
        private static string destFolder = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData), @"gShell\");
        private static string destFile = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData), @"gShell\gShell_OAuth2.bin");

        #endregion

        #region Interface Implementation
        public OAuth2Info LoadInfo()
        {
            OAuth2Info savedInfo = null;

            if (FileExists())
            {
                byte[] protectedArray = System.IO.File.ReadAllBytes(destFile);

                byte[] byteArray = ProtectedData.Unprotect(protectedArray, s_aditionalEntropy,
                    DataProtectionScope.CurrentUser);

                using (MemoryStream memoryStream = new MemoryStream(byteArray))
                {

                    BinaryFormatter deserializer = new BinaryFormatter();

                    try
                    {
                        savedInfo = (OAuth2Info)deserializer.Deserialize(memoryStream);
                    }
                    catch
                    {
                        throw new System.InvalidOperationException(
                            string.Format(
                            "Saved authentication out of date. Please delete {0} and try again. (see Remove-Item)",
                            destFile));
                    }
                }
            }

            //ThrowNoOauthSettingsError();
            return savedInfo;
        }

        public void SaveInfo(OAuth2Info infoToSave)
        {
            CheckOrCreateDirectory();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                IFormatter serializer = new BinaryFormatter();

                serializer.Serialize(memoryStream, infoToSave);

                byte[] byteArray = memoryStream.ToArray();
                byte[] protectedArray = ProtectedData.Protect(byteArray, s_aditionalEntropy,
                    DataProtectionScope.CurrentUser);

                System.IO.File.WriteAllBytes(destFile, protectedArray);
            }
        }

        #endregion

        #region Helpers

        /// <summary>Checks if the file exists.</summary>
        private static bool FileExists()
        {
            return (File.Exists(destFile));
        }

        /// <summary>Creates the target directory if it does not already exist.</summary>
        private static void CheckOrCreateDirectory()
        {
            if (!System.IO.Directory.Exists(destFolder))
            {
                System.IO.Directory.CreateDirectory(destFolder);
            }
        }

        #endregion

        #region Custom Exceptions

        private static void ThrowNoOauthSettingsError(string Domain = null)
        {
            if (Domain == null)
            {
                throw new System.InvalidOperationException(
                    "No Oauth settings file found");
            }
            else
            {
                throw new System.InvalidOperationException(
                     "No Oauth domain settings exist for " + Domain);
            }
        }

        #endregion
    }
}
