using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using DotNetOpenAuth.OAuth2;

namespace gShell.OAuth2
{
    public sealed class SavedFile
    {

        #region Parameters
        private static byte[] s_aditionalEntropy = { 8, 4, 5, 6, 6, 5, 6, 5, 9, 7, 2, 5, 9, 6, 1, 7, 3, 9 };
        private static string destFolder = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData), @"gShell\");
        private static string destFile = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData), @"gShell\gShell_OAuth2.bin");

        private static OAuth2Group oAuth2Group;
        #endregion

        #region Saving

        public static void SaveAuthState(string domain, IAuthorizationState authState)
        {
            OAuth2Info info = new OAuth2Info(domain, authState);

            OAuth2Group group = new OAuth2Group(info);

            if (null != oAuth2Group)
            {
                group = oAuth2Group;
            }
            else
            {
                if (FileExists())
                {
                    group = LoadGroup();
                }
                else
                {
                    CheckOrCreateFile();
                }
            }

            group.Add(info);

            oAuth2Group = group;

            SaveGroup(group);
        }

        private static void SaveGroup()
        {
            SaveGroup(oAuth2Group);
        }

        private static void SaveGroup(OAuth2Group group)
        {
            CheckOrCreateDirectory();

            MemoryStream memoryStream = new MemoryStream();
            IFormatter serializer = new BinaryFormatter();

            serializer.Serialize(memoryStream, group);

            byte[] byteArray = memoryStream.ToArray();
            byte[] protectedArray = ProtectedData.Protect(byteArray, s_aditionalEntropy,
                DataProtectionScope.CurrentUser);
            

            System.IO.File.WriteAllBytes(destFile, protectedArray);

            memoryStream.Close();

            oAuth2Group = group;
        }

        #endregion

        #region Loading
        public static IAuthorizationState LoadAuthState(string domain)
        {
            LoadGroup();
            OAuth2Info info = new OAuth2Info();

            try
            {
                info = oAuth2Group.Load(domain);
            }
            catch
            {
                ThrowNoOauthSettingsError(domain);
            }

            //Console.Write(info.domain + " \n");

            return (info.authState);
        }
        
        private static OAuth2Group LoadGroup(bool force=false)
        {
            if (null == oAuth2Group || force)
            {
                if (FileExists())
                {
                    byte[] protectedArray = System.IO.File.ReadAllBytes(destFile);

                    byte[] byteArray = ProtectedData.Unprotect(protectedArray, s_aditionalEntropy,
                        DataProtectionScope.CurrentUser);

                    MemoryStream memoryStream = new MemoryStream(byteArray);

                    BinaryFormatter deserializer = new BinaryFormatter();

                    OAuth2Group group = (OAuth2Group)deserializer.Deserialize(memoryStream);

                    memoryStream.Close();

                    oAuth2Group = group;

                    return group;
                }
                else
                {
                    ThrowNoOauthSettingsError();
                    return null; //to prevent compiler warnings
                }
            }
            else
            {
                return oAuth2Group;
            }
        }
        #endregion

        #region Deleting

        #endregion

        #region Helpers
        private static void RefreshToken()
        {

        }

        private static bool FileExists()
        {
            return (File.Exists(destFile));
        }

        public static bool ContainsDomain(string domain)
        {
            if (!FileExists()) { return false; }

            LoadGroup();

            return (oAuth2Group.Contains(domain));
        }

        public static bool ContainsDefaultDomain()
        {
            if (!FileExists()) { return false; }

            LoadGroup();

            return (!string.IsNullOrWhiteSpace(oAuth2Group.defaultDomain));
        }

        public static string GetDefaultDomain()
        {
            return oAuth2Group.defaultDomain;
        }

        public static void SetDefaultDomain(string domain)
        {
            oAuth2Group.defaultDomain = domain;

            SaveGroup();
        }

        private static void CheckOrCreateDirectory()
        {
            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }
        }

        private static bool CheckOrCreateFile()
        {
            if (System.IO.File.Exists(destFile))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region ByteManagement
        //found at http://stackoverflow.com/questions/472906/net-string-to-byte-array-c-sharp
        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
        #endregion

        #region ErrorMethods

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
