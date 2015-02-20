using System;
using System.Collections.Generic;
using System.Management.Automation;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using gShell.OAuth2;

namespace gShell.DirectoryCmdlets.GAUser
{
    [Cmdlet(VerbsCommon.New, "GAUser",
          DefaultParameterSetName = "PasswordGenerated",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAUser")]
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
        public int? PasswordLength { get; set; }

        [Parameter(Position = 6,
            ParameterSetName = "PasswordGenerated")]
        public SwitchParameter ShowNewPassword { get; set; }

        [Parameter(Position = 7)]
        public bool? IncludeInDirectory { get; set; }

        [Parameter(Position = 8)]
        public bool? Suspended { get; set; }

        [Parameter(Position = 9)]
        public bool? IpWhiteListed { get; set; }

        [Parameter(Position = 10)]
        public bool? ChangePasswordAtNextLogin { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(UserName, "New-GAUser"))
            {
                CreateUser();
            }
        }

        private void CreateUser()
        {
            string fullEmail = OAuth2Base.GetFullEmailAddress(UserName, Domain);

            User userAcct = new User();

            userAcct.Name = new UserName();

            userAcct.Name.GivenName = GivenName;

            userAcct.Name.FamilyName = FamilyName;

            userAcct.PrimaryEmail = fullEmail;

            switch (ParameterSetName)
            {
                case "PasswordProvided":
                    userAcct.HashFunction = "MD5";
                    userAcct.Password = GetMd5Hash(Password);
                    break;

                case "PasswordGenerated":
                    //Console.WriteLine("Generated");
                    userAcct.HashFunction = "MD5";
                    userAcct.Password = GeneratePassword(PasswordLength, ShowNewPassword);
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

            if (ChangePasswordAtNextLogin.HasValue)
            {
                userAcct.ChangePasswordAtNextLogin = ChangePasswordAtNextLogin.Value;
            }

            directoryServiceDict[Domain].Users.Insert(userAcct).Execute();
        }
    }
}
