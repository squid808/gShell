//using System;
//using System.Collections.Generic;
//using IO = System.IO;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Security.Cryptography;
//using System.Security.Cryptography.X509Certificates;

//using Google.Apis.Oauth2.v2;
//using Google.Apis.Oauth2.v2.Data;
//using Google.Apis.Auth.OAuth2;

//using gShell.dotNet.Utilities.OAuth2;

//namespace gShell.dotNet.Utilities
//{
//    /// <summary>
//    /// A class dedicated to being the intermediate for the saving and loading of content from the saved information.
//    /// TODO: Update the whole friggin back-end system to work better with this file. Rather than
//    /// loading things from here in to memory, just use this as the basis - it's already in memory
//    /// </summary>
//    public sealed class SavedFile
//    {
//        #region Parameters
//        private static byte[] s_aditionalEntropy = { 8, 4, 5, 6, 6, 5, 6, 5, 9, 7, 2, 5, 9, 6, 1, 7, 3, 9 };
//        private static string destFolder = IO.Path.Combine(Environment.GetFolderPath(
//            Environment.SpecialFolder.LocalApplicationData), @"gShell\");
//        private static string destFile = IO.Path.Combine(Environment.GetFolderPath(
//            Environment.SpecialFolder.LocalApplicationData), @"gShell\gShell_OAuth2.bin");

//        public static OAuth2Info oAuth2Group {
//            get
//            {
//                if (_oAuth2GroupLoader == null)
//                {
//                    if (FileExists())
//                    {
//                        LoadGroup();
//                    }
//                    else
//                    {
//                        _oAuth2GroupLoader = new OAuth2Info();
//                    }
//                }

//                return _oAuth2GroupLoader;
//            }
//        }
//        private static OAuth2Info _oAuth2GroupLoader;
//        #endregion

//        #region Saving

//        /// <summary>
//        /// Saves the token to the group with the user email as the key.
//        /// </summary>
//        public static void SaveToken(Userinfoplus userInfo, string tokenInfo, HashSet<string> scopes)
//        {
//            //if (null == oAuth2Group)
//            //{
//            //    if (FileExists())
//            //    {
//            //        LoadGroup();
//            //    }
//            //    else
//            //    {
//            //        oAuth2Group = new OAuth2Group();
//            //    }
//            //}

//            oAuth2Group.SetUser(userInfo, tokenInfo, scopes);

//            SaveGroup();
//        }

//        private static void SaveGroup()
//        {
//            SaveGroup(oAuth2Group);
//        }

//        private static void SaveGroup(OAuth2Info group)
//        {
//            CheckOrCreateDirectory();

//            IO.MemoryStream memoryStream = new IO.MemoryStream();
//            IFormatter serializer = new BinaryFormatter();

//            serializer.Serialize(memoryStream, group);

//            byte[] byteArray = memoryStream.ToArray();
//            byte[] protectedArray = ProtectedData.Protect(byteArray, s_aditionalEntropy,
//                DataProtectionScope.CurrentUser);

//            System.IO.File.WriteAllBytes(destFile, protectedArray);

//            memoryStream.Close();

//            _oAuth2GroupLoader = group;
//        }

//        //public static void SetServiceAccountInfo(string accountEmail,
//        //    string certificatePath)
//        //{
//        //    LoadGroup();

//        //    oAuth2Group.AddCertificate(certificatePath);
//        //    oAuth2Group.AddServiceAccountEmail(accountEmail);

//        //    SaveGroup();
//        //}
//        #endregion

//        #region Loading
//        //public static string LoadTokenByDomain(string domain)
//        //{
//        //    LoadGroup();

//        //    try
//        //    {
//        //        oAuth2Info = oAuth2Group.LoadByDomain(domain);
//        //    }
//        //    catch
//        //    {
//        //        ThrowNoOauthSettingsError(domain);
//        //    }

//        //    return (oAuth2Info.storedToken);
//        //}

//        /// <summary>
//        /// Called by the async process from google that requests the token. Could pass an email address or a domain.
//        /// </summary>
//        public static string LoadToken(string emailAddress)
//        {
//            //assume the key is the email address until i document better. if this is still here, it didn't fail and i didn't have to troubleshoot, which means i'm right.
//            try
//            {
//                LoadGroup();
//            }
//            catch
//            {
//                ThrowNoOauthSettingsError(emailAddress);
//            }

//            if (!emailAddress.Contains("@"))
//            {
//                emailAddress = oAuth2Group.GetDefaultUser(emailAddress);
//            }

//            return oAuth2Group.GetUser(emailAddress).storedToken;
//        }

//        /// <summary>
//        /// Loads the group in to the static member.
//        /// </summary>
//        /// <param name="force"></param>
//        /// <returns></returns>
//        private static OAuth2Info LoadGroup(bool force=false)
//        {
//            if (null == _oAuth2GroupLoader || force)
//            {
//                if (FileExists())
//                {
//                    byte[] protectedArray = System.IO.File.ReadAllBytes(destFile);

//                    byte[] byteArray = ProtectedData.Unprotect(protectedArray, s_aditionalEntropy,
//                        DataProtectionScope.CurrentUser);

//                    IO.MemoryStream memoryStream = new IO.MemoryStream(byteArray);

//                    BinaryFormatter deserializer = new BinaryFormatter();

//                    OAuth2Info group;

//                    try
//                    {
//                        group = (OAuth2Info)deserializer.Deserialize(memoryStream);
//                    }
//                    catch
//                    {
//                        throw new System.InvalidOperationException(
//                                string.Format("Saved authentication out of date. Please delete {0} and try again. (see Remove-Item)", destFile));
//                    }

//                    memoryStream.Close();

//                    _oAuth2GroupLoader = group;

//                    return group;
//                }
//                else
//                {
//                    ThrowNoOauthSettingsError();
//                    return null; //to prevent compiler warnings
//                }
//            }
//            else
//            {
//                return oAuth2Group;
//            }
//        }

//        //public static string GetServiceAccountEmail()
//        //{
//        //    LoadGroup();

//        //    if (oAuth2Group.ContainsServiceAccountInfo()){
//        //        return oAuth2Group.serviceAccountEmail;
//        //    } else {
//        //        throw new System.InvalidOperationException(
//        //            "No Service Account Information exists.");
//        //    }
//        //}

//        //public static X509Certificate2 GetServiceAccountCert()
//        //{
//        //    LoadGroup();

//        //    if (oAuth2Group.ContainsServiceAccountInfo()){
//        //        return oAuth2Group.serviceAccountCertificate;
//        //    } else {
//        //        throw new System.InvalidOperationException(
//        //            "No Service Account Information exists.");
//        //    }
//        //}

        
//        #endregion

//        #region Deleting
//        public static void RemoveUser(string userEmail)
//        {
//            //LoadGroup();

//            if (ContainsUserOrDomain(userEmail))
//            {
//                oAuth2Group.RemoveUser(userEmail);
//            }

//            SaveGroup();
//        }

//        public static void RemoveDomain(string domain)
//        {
//            //LoadGroup();
            
//            if (ContainsUserOrDomain(domain))
//            {
//                oAuth2Group.RemoveDomain(domain);
//            }

//            SaveGroup();
//        }

//        public static void ClearAllTokens()
//        {
//            //LoadGroup();

//            oAuth2Group.ClearAll();
//        }
//        #endregion

//        #region Helpers
//        private static bool FileExists()
//        {
//            return (IO.File.Exists(destFile));
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public static bool ContainsUserOrDomain(string key)
//        {
//            if (!FileExists()) { return false; }

//            //LoadGroup();

//            return (oAuth2Group.ContainsUser(key) ||
//                oAuth2Group.ContainsDomain(key));
//        }

//        public static bool ContainsDomainDefaultUser(string domain)
//        {
//            if (!FileExists()) { return false; }

//            //LoadGroup();

//            return (oAuth2Group.ContainsDomain(domain));
//        }

//        public static bool ContainsDefaultDomain()
//        {
//            if (!FileExists()) { return false; }

//            //LoadGroup();

//            return (!string.IsNullOrWhiteSpace(oAuth2Group.defaultDomain));
//        }

//        public static string GetDefaultDomain()
//        {
//            //LoadGroup();

//            return oAuth2Group.GetDefaultDomain();
//        }

//        public static ICollection<string> GetDomainList()
//        {
//            //LoadGroup();

//            return (oAuth2Group.GetDomains());
//        }

//        public static OAuth2Domain GetDomain(string domain)
//        {
//            //LoadGroup();

//            return oAuth2Group.GetDomain(domain);
//        }

//        public static OAuth2DomainUser GetUser(string userEmail)
//        {
//            //LoadGroup();

//            return oAuth2Group.GetUser(userEmail);
//        }

//        /// <summary>
//        /// Returns all saved users for one domain.
//        /// </summary>
//        public static List<OAuth2DomainUser> GetUsers(string domain)
//        {
//            //LoadGroup();

//            List<OAuth2DomainUser> users = (List<OAuth2DomainUser>)oAuth2Group.GetUsers(domain);

//            return users;
//        }

//        /// <summary>
//        /// Returns all saved users.
//        /// </summary>
//        public static List<String>  GetUsers()
//        {
//            //LoadGroup();

//            List<string> users = (List<string>)oAuth2Group.GetUsers();

//            return users;
//        }

//        /// <summary>
//        /// Return the user email address who is the default user of the domain.
//        /// </summary>
//        public static string GetDomainDefaultUser(string domain)
//        {
//            //LoadGroup();

//            return (oAuth2Group.GetDefaultUser(domain));
//        }

//        /// <summary>
//        /// Compares a username (with no domain) to the domain's default user.
//        /// </summary>
//        public bool IsDomainDefaultUser(string user, string domain)
//        {
//            if (user == GetDomainDefaultUser(domain))
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }

//        public static void SetDefaultDomain(string domain)
//        {
//            //LoadGroup();

//            oAuth2Group.SetDefaultDomain(domain);

//            SaveGroup();
//        }

//        public static void SetDefaultUser(string userEmail)
//        {
//            //LoadGroup();

//            oAuth2Group.SetDefaultUser(userEmail);

//            SaveGroup();
//        }

//        private static void CheckOrCreateDirectory()
//        {
//            if (!IO.Directory.Exists(destFolder))
//            {
//                IO.Directory.CreateDirectory(destFolder);
//            }
//        }

//        /// <summary>
//        /// Returns the custom client secrets, if any.
//        /// </summary>
//        public static ClientSecrets GetClientSecrets()
//        {
//            //LoadGroup();

//            return oAuth2Group.GetClientSecrets();
//        }

//        public static void SetClientSecrets(ClientSecrets secrets)
//        {
//            //LoadGroup();

//            oAuth2Group.SetClientSecrets(secrets);

//            SaveGroup();
//        }

//        public static void RemoveClientSecrets()
//        {
//            //LoadGroup();

//            oAuth2Group.RemoveClientSecrets();

//            SaveGroup();
//        }
//        #endregion

//        #region ByteManagement
//        //found at http://stackoverflow.com/questions/472906/net-string-to-byte-array-c-sharp
//        static byte[] GetBytes(string str)
//        {
//            byte[] bytes = new byte[str.Length * sizeof(char)];
//            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
//            return bytes;
//        }

//        static string GetString(byte[] bytes)
//        {
//            char[] chars = new char[bytes.Length / sizeof(char)];
//            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
//            return new string(chars);
//        }
//        #endregion

//        #region ErrorMethods

//        private static void ThrowNoOauthSettingsError(string Domain = null)
//        {
//            if (Domain == null)
//            {
//                throw new System.InvalidOperationException(
//                    "No Oauth settings file found");
//            }
//            else
//            {
//                throw new System.InvalidOperationException(
//                     "No Oauth domain settings exist for " + Domain);
//            }
//        }

//        #endregion
//    }
//}
