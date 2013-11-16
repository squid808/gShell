using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Oauth2.v2.Data;

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

        public static OAuth2Group oAuth2Group;
        private static OAuth2Info oAuth2Info;
        #endregion

        #region Saving

        /// <summary>
        /// Saves the token to the group with the user email as the key.
        /// </summary>
        public static void SaveToken(Userinfo userInfo, string tokenInfo)
        {
            OAuth2Info info = new OAuth2Info(userInfo, tokenInfo);

            if (null == oAuth2Group)
            {
                if (FileExists())
                {
                    LoadGroup();
                }
                else
                {
                    oAuth2Group = new OAuth2Group();
                }
            }

            oAuth2Group.Add(info);

            SaveGroup();
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

        public static void SetServiceAccountInfo(string accountEmail,
            string certificatePath)
        {
            LoadGroup();

            oAuth2Group.AddCertificate(certificatePath);
            oAuth2Group.AddServiceAccountEmail(accountEmail);

            SaveGroup();
        }
        #endregion

        #region Loading
        public static string LoadTokenByDomain(string domain)
        {
            LoadGroup();

            try
            {
                oAuth2Info = oAuth2Group.LoadByDomain(domain);
            }
            catch
            {
                ThrowNoOauthSettingsError(domain);
            }

            return (oAuth2Info.storedToken);
        }

        public static string LoadToken(string key)
        {
            try
            {
                oAuth2Info = oAuth2Group.Load(key);
            }
            catch
            {
                ThrowNoOauthSettingsError(key);
            }

            return (oAuth2Info.storedToken);
        }

        /// <summary>
        /// Loads the group in to the static member.
        /// </summary>
        /// <param name="force"></param>
        /// <returns></returns>
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

                    OAuth2Group group;

                    try
                    {
                        group = (OAuth2Group)deserializer.Deserialize(memoryStream);
                    }
                    catch
                    {
                        throw new System.InvalidOperationException(
                                string.Format("Saved authentication out of date. Please delete {0} and try again. (see Remove-Item)", destFile));
                    }

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

        public static string GetServiceAccountEmail()
        {
            LoadGroup();

            if (oAuth2Group.ContainsServiceAccountInfo()){
                return oAuth2Group.serviceAccountEmail;
            } else {
                throw new System.InvalidOperationException(
                    "No Service Account Information exists.");
            }
        }

        public static X509Certificate2 GetServiceAccountCert()
        {
            LoadGroup();

            if (oAuth2Group.ContainsServiceAccountInfo()){
                return oAuth2Group.serviceAccountCertificate;
            } else {
                throw new System.InvalidOperationException(
                    "No Service Account Information exists.");
            }
        }

        
        #endregion

        #region Deleting
        public static void DeleteToken(string domain)
        {
            LoadGroup();
            
            if (ContainsUserOrDomain(domain))
            {
                oAuth2Group.RemoveDomain(domain);
            }

            SaveGroup();
        }

        public static void ClearAllTokens()
        {
            LoadGroup();

            oAuth2Group.ClearAll();
        }
        #endregion

        #region Helpers
        private static bool FileExists()
        {
            return (File.Exists(destFile));
        }

        public static bool ContainsUserOrDomain(string key)
        {
            if (!FileExists()) { return false; }

            LoadGroup();

            return (oAuth2Group.ContainsUser(key) ||
                oAuth2Group.ContainsDomain(key));
        }

        public static bool ContainsDomainDefaultUser(string domain)
        {
            if (!FileExists()) { return false; }

            LoadGroup();

            return (oAuth2Group.ContainsDomain(domain));
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

        public static List<string> GetDomainList()
        {
            LoadGroup();

            return (oAuth2Group.GetAllDomains());
        }

        /// <summary>
        /// Return the user email address who is the default user of the domain.
        /// </summary>
        public static string GetDomainDefaultUser(string domain)
        {
            LoadGroup();

            return (oAuth2Group.GetDomainDefaultUser(domain));
        }

        /// <summary>
        /// Compares a username (with no domain) to the domain's default user.
        /// </summary>
        public bool IsDomainDefaultUser(string user, string domain)
        {
            if (user == GetDomainDefaultUser(domain))
            {
                return true;
            }
            else
            {
                return false;
            }
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
