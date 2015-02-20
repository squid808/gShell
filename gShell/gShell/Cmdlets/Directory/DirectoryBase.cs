using System;
using System.Management.Automation;
using System.Collections.Generic;
using gShell.OAuth2;
using Google.Apis.Services;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using gShell.DirectoryCmdlets.GAUserAlias;

namespace gShell.DirectoryCmdlets
{
    public abstract class DirectoryBase : OAuth2CmdletBase
    {
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the Google Apps domain, ex contoso.com. If none is provided the gShell default domain will be used.")]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }


        protected static Dictionary<string, DirectoryService> directoryServiceDict; //a collection of directory services by domain

        //protected static Dictionary<string, DirectoryService> directoryServiceDict;
        protected static Dictionary<string, List<User>> cachedDomainUsers;
        protected static Dictionary<string, List<Group>> cachedDomainGroups;
        protected static Dictionary<string, List<Alias>> cachedDomainAliases;
        protected static Dictionary<string, Dictionary<string, List<Member>>> cachedDomainGroupMembers;

        public DirectoryBase()
        {
            if (null == directoryServiceDict)
            {
                directoryServiceDict = new Dictionary<string, DirectoryService>();
            }

            if (null == cachedDomainAliases)
            {
                cachedDomainAliases = new Dictionary<string, List<Alias>>();
            }

            if (null == cachedDomainGroupMembers)
            {
                cachedDomainGroupMembers = new Dictionary<string, Dictionary<string, List<Member>>>();
            }

            if (null == cachedDomainGroups)
            {
                cachedDomainGroups = new Dictionary<string, List<Group>>();
            }

            if (null == cachedDomainUsers)
            {
                cachedDomainUsers = new Dictionary<string, List<User>>();
            }
        }

        protected override void BeginProcessing()
        {
            Domain = Authenticate(Domain);
        }

        protected override string BuildService(string givenDomain)
        {
            if (string.IsNullOrWhiteSpace(givenDomain) ||
                !directoryServiceDict.ContainsKey(givenDomain))
            {
                DirectoryService service = BuildDirectoryService(givenDomain);

                if (OAuth2Base.currentDomain == "gmail.com")
                {
                    ThrowTerminatingError(new ErrorRecord(new Exception("This cmdlet is not available for a gmail account."),
                        "", ErrorCategory.InvalidData, OAuth2Base.currentDomain));
                }

                //current domain should be set at this point 
                directoryServiceDict.Add(OAuth2Base.currentDomain, service);

                return OAuth2Base.currentDomain;
            }
            else
            {
                return givenDomain;
            }
        }

        /// <summary>
        /// Create a directory service for the provided domain.
        /// </summary>
        protected DirectoryService BuildDirectoryService(string givenDomain)
        {
            return new DirectoryService(OAuth2Base.GetInitializer(givenDomain));
        }

        protected static string GetMd5Hash(string s)
        {
            using (var md5Hasher = System.Security.Cryptography.MD5.Create())
            {
                var data = md5Hasher.ComputeHash(System.Text.Encoding.UTF8.GetBytes(s));
                return BitConverter.ToString(data, 0).Replace("-", string.Empty);
            }
        }

        /// <summary>
        /// Generates a hashed password based on the input.
        /// </summary>
        /// <param name="PasswordLength">Min 8, max 100. Defaults to 8 if empty.</param>
        /// <param name="printPassword">Default false - prints the new password to screen.</param>
        /// <returns>New password in hex string format.</returns>
        protected static string GeneratePassword(int? PasswordLength, bool ShowNewPassword)
        {
            int PasswordLengthInt;
            if (PasswordLength < 8 || !PasswordLength.HasValue)
            {
                PasswordLength = 8;
            }
            else if (PasswordLength > 100)
            {
                PasswordLength = 100;
            }
            PasswordLengthInt = PasswordLength.Value;
            string newPassword = CreatePassword(PasswordLengthInt);
            //Console.WriteLine(newPassword);

            if (ShowNewPassword == true)
            {
                Console.WriteLine(newPassword);
            }

            return GetMd5Hash(newPassword);
        }

        /// <summary>
        /// Creates a random password of length.
        /// </summary>
        /// <param name="length"></param>
        /// <see cref="http://stackoverflow.com/questions/54991/generating-random-passwords"/>
        private static string CreatePassword(int length)
        {
            string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!-%?";
            string res = "";
            Random rnd = new Random();
            while (0 < length--)
                res += valid[rnd.Next(valid.Length)];
            return res;
        }
    }
}
