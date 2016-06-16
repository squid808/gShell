//using System;
//using System.Management.Automation;

//using Data = Google.Apis.admin.Directory.directory_v1.Data;

//using gShell.Cmdlets.Directory.GAUserProperty;

//namespace gShell.Cmdlets.Directory.GAUser
//{
//    [Cmdlet(VerbsCommon.Set, "GAUser",
//          DefaultParameterSetName = "NoPasswordProvided",
//          SupportsShouldProcess = true,
//          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAUser")]
//    public class SetGAUser : DirectoryBase
//    {
//        #region Properties

//        [Parameter(Position = 0,
//            Mandatory = true,
//            ValueFromPipeline = true,
//            ValueFromPipelineByPropertyName = true,
//            HelpMessage = "The username of the user to update.")]
//        [ValidateNotNullOrEmpty]
//        public string UserName { get; set; }

//        //Domain position = 1

//        [Parameter(Position = 2,
//            HelpMessage = "The user's first name. Required when creating a user account.")]
//        public string NewGivenName { get; set; }

//        [Parameter(Position = 3,
//            HelpMessage = "The user's last name. Required when creating a user account.")]
//        public string NewFamilyName { get; set; }

//        [Parameter(Position = 4,
//            HelpMessage = "The user's username, post-update.")]
//        public string NewUserName { get; set; }

//        [Parameter(Position = 5,
//            HelpMessage = "Indicates if the user is suspended.")]
//        public bool? Suspended { get; set; }

//        [Parameter(Position = 6,
//            HelpMessage = "Stores the password for the user account. A password can contain any combination of ASCII characters. A minimum of 8 characters is required. The maximum length is 100 characters.",
//            ParameterSetName = "PasswordProvided")]
//        public string NewPassword { get; set; }

//        [Parameter(Position = 7,
//            HelpMessage = "Indicates the length of the password desired if it is to be automatically generated.",
//            ParameterSetName = "PasswordGenerated")]
//        public int? PasswordLength { get; set; }

//        [Parameter(Position = 8,
//            HelpMessage = "Indicates if the new password should be shown after it is to be automatically generated.",
//            ParameterSetName = "PasswordGenerated")]
//        public SwitchParameter ShowNewPassword { get; set; }

//        [Parameter(Position = 9,
//            HelpMessage = "Indicates if the user is forced to change their password at next login.")]
//        public bool? ChangePasswordAtNextLogin { get; set; }

//        [Parameter(
//            HelpMessage = "The full path of the parent organization associated with the user. If the parent organization is the top-level, it is represented as a forward slash (/).")]
//        public string OrgUnitPath { get; set; }

//        [Parameter(
//            HelpMessage="A supplied property collection to update the user with. Create with New/Get-GAUserPropertyCollection and update with New/Remove-GauserProperty")]
//        public GAUserPropertyCollection PropertyCollection { get; set; }

//        #endregion

//        protected override void ProcessRecord()
//        {
//            UserName = GetFullEmailAddress(UserName, Domain);

//            if (ShouldProcess(UserName, "Set-GAUser"))
//            {
//                UpdateUser();
//            }
//        }

//        private void UpdateUser()
//        {
//            Data.User userAcct = new Data.User();

//            if (String.IsNullOrWhiteSpace(NewGivenName) &&
//                String.IsNullOrWhiteSpace(NewFamilyName) &&
//                String.IsNullOrWhiteSpace(NewUserName) &&
//                String.IsNullOrWhiteSpace(NewPassword) &&
//                !PasswordLength.HasValue &&
//                ShowNewPassword == false &&
//                !Suspended.HasValue &&
//                !ChangePasswordAtNextLogin.HasValue &&
//                null == PropertyCollection)
//            {
//                WriteError(new ErrorRecord(new Exception(
//                    string.Format("No data was entered to update {0}.", UserName)),
//                        "", ErrorCategory.InvalidData, UserName));
//            }

//            if (Suspended.HasValue)
//            {
//                userAcct.Suspended = Suspended.Value;
//            }

//            if (!String.IsNullOrWhiteSpace(NewGivenName))
//            {
//                if (userAcct.Name == null)
//                {
//                    userAcct.Name = new Data.UserName();
//                }
//                userAcct.Name.GivenName = NewGivenName;
//            }

//            if (!String.IsNullOrWhiteSpace(NewFamilyName))
//            {
//                if (userAcct.Name == null)
//                {
//                    userAcct.Name = new Data.UserName();
//                }
//                userAcct.Name.FamilyName = NewFamilyName;
//            }

//            if (!String.IsNullOrWhiteSpace(NewUserName))
//            {
//                NewUserName = GetFullEmailAddress(NewUserName, Domain);

//                userAcct.PrimaryEmail = NewUserName;
//            }

//            switch (ParameterSetName)
//            {
//                case "PasswordProvided":
//                    userAcct.HashFunction = "MD5";
//                    userAcct.Password = GetMd5Hash(NewPassword);
//                    break;

//                case "PasswordGenerated":
//                    userAcct.HashFunction = "MD5";
//                    userAcct.Password = GeneratePassword(PasswordLength, ShowNewPassword);
//                    break;
//            }

//            if (ChangePasswordAtNextLogin.HasValue)
//            {
//                userAcct.ChangePasswordAtNextLogin = ChangePasswordAtNextLogin.Value;
//            }

//            if (!string.IsNullOrWhiteSpace(OrgUnitPath))
//            {
//                userAcct.OrgUnitPath = OrgUnitPath;
//            }

//            if (null != PropertyCollection)
//            {
//                //here we don't check if it's an empty list since that may be on purpose - we check it that list had been updated.
//                if (PropertyCollection.IsUpdated(GAUserPropertyType.address))
//                {
//                    userAcct.Addresses = PropertyCollection.GetAddresses();
//                }

//                if (PropertyCollection.IsUpdated(GAUserPropertyType.email))
//                {
//                    userAcct.Emails = PropertyCollection.GetEmails();
//                }

//                if (PropertyCollection.IsUpdated(GAUserPropertyType.externalid))
//                {
//                    userAcct.ExternalIds = PropertyCollection.GetExternalIds();
//                }

//                if (PropertyCollection.IsUpdated(GAUserPropertyType.im))
//                {
//                    userAcct.Ims = PropertyCollection.GetIms();
//                }

//                if (PropertyCollection.IsUpdated(GAUserPropertyType.organization))
//                {
//                    userAcct.Organizations = PropertyCollection.GetOrganizations();
//                }

//                if (PropertyCollection.IsUpdated(GAUserPropertyType.phone))
//                {
//                    userAcct.Phones = PropertyCollection.GetPhones();
//                }

//                if (PropertyCollection.IsUpdated(GAUserPropertyType.relation))
//                {
//                    userAcct.Relations = PropertyCollection.GetRelations();
//                }
//            }

//            users.Patch(userAcct, UserName);
//        }
//    }
//}
