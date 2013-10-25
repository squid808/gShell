using System;
using System.Collections.Generic;
using System.Management.Automation;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.DirectoryCmdlets.GAUser
{
    [Cmdlet(VerbsCommon.New, "GAUser",
          DefaultParameterSetName = "PasswordGenerated",
          SupportsShouldProcess = true)]
    public class NewGAUser : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Help Text")]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = true)]
        public string GivenName { get; set; }

        [Parameter(Position = 3,
            Mandatory = true)]
        public string FamilyName { get; set; }

        [Parameter(Position = 4,
            ParameterSetName = "PasswordProvided")]
        public string Password { get; set; }

        [Parameter(Position = 5,
            ParameterSetName = "PasswordGenerated")]
        public int PasswordLength { get; set; }

        [Parameter(Position = 6)]
        public bool? IncludeInDirectory { get; set; }

        [Parameter(Position = 7)]
        public bool? Suspended { get; set; }

        [Parameter(Position = 8)]
        public bool? IpWhiteListed { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            CreateUser();
        }

        private void CreateUser()
        {
            string fullEmail = GetFullEmailAddress(UserName, Domain);

            User userAcct = new User();

            userAcct.Name = new UserName();

            userAcct.Name.GivenName = GivenName;

            userAcct.Name.FamilyName = FamilyName;

            userAcct.PrimaryEmail = fullEmail;

            switch (ParameterSetName)
            {
                case "PasswordProvided":
                    userAcct.Password = Password;
                    break;

                case "PasswordGenerated":
                    Console.WriteLine("Genereated");
                    if (PasswordLength < 8)
                    {
                        PasswordLength = 8;
                    }
                    string newPassword = CreatePassword(PasswordLength);
                    Console.WriteLine(newPassword);
                    break;
            }

            if (IncludeInDirectory.HasValue)
            {
                userAcct.IncludeInGlobalAddressList = IncludeInDirectory;
            }

            if (Suspended.HasValue) {
                userAcct.Suspended = Suspended;
            }

            if (IpWhiteListed.HasValue) {
                userAcct.IpWhitelisted = IpWhiteListed;
            }

            
            directoryServiceDict[Domain].Users.Insert(userAcct).Execute();
        }

        /// <summary>
        /// Creates a random password of length.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        /// <see cref="http://stackoverflow.com/questions/54991/generating-random-passwords"/>
        public string CreatePassword(int length)
        {
            string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!-_.%?";
            string res = "";
            Random rnd = new Random();
            while (0 < length--)
                res += valid[rnd.Next(valid.Length)];
            return res;
        }
    }
}
