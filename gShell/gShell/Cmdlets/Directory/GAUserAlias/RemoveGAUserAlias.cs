//using System;
//using System.Management.Automation;

//namespace gShell.Cmdlets.Directory.GAUserAlias
//{
//    [Cmdlet(VerbsCommon.Remove, "GAUserAlias",
//          SupportsShouldProcess = true,
//          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GAUserAlias")]
//    public class RemoveGAUserAlias : DirectoryBase
//    {
//        #region Properties

//        [Parameter(Position = 0,
//            ParameterSetName = "UserAliasName",
//            Mandatory = true,
//            ValueFromPipeline = true,
//            ValueFromPipelineByPropertyName = true,
//            HelpMessage = "The user alias account to remove")]
//        [ValidateNotNullOrEmpty]
//        public string UserAliasName { get; set; }

//        //Domain position = 1

//        [Parameter(Position = 2,
//            ParameterSetName = "UserAliasName",
//            Mandatory = false,
//            HelpMessage = "The user account to which the alias belongs")]
//        [ValidateNotNullOrEmpty]
//        public string UserName { get; set; }

//        [Parameter(Position = 3)]
//        public SwitchParameter Force { get; set; }

//        #endregion

//        protected override void ProcessRecord()
//        {
//            UserAliasName = GetFullEmailAddress(UserAliasName, Domain);

//            if (ShouldProcess(UserAliasName, "Remove-GAUserAlias"))
//            {
//                if (Force || ShouldContinue((String.Format("User alias {0} will be removed from the {1} Google Apps domain.\nContinue?",
//                    UserAliasName, Domain)), "Confirm Google Apps user alias Removal"))
//                {
//                    try
//                    {
//                        WriteDebug(string.Format("Attempting to remove user alias {0}@{1}...",
//                            UserAliasName, Domain));
                        
//                        if (string.IsNullOrWhiteSpace(UserName))
//                        {
//                            UserName = users.Get(UserAliasName).PrimaryEmail;
//                        }

//                        users.aliases.Delete(UserName, UserAliasName);

//                        WriteVerbose(string.Format("Removal of {0}@{1} completed without error.",
//                            UserAliasName, Domain));
//                    }
//                    catch (Exception e)
//                    {
//                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, UserAliasName));
//                    }
//                }
//                else
//                {
//                    WriteError(new ErrorRecord(new Exception("Alias deletion not confirmed"),
//                        "", ErrorCategory.InvalidData, UserAliasName));
//                }
//            }
//        }

//        private void RemoveUserAlias()
//        {
            
//        }
//    }
//}
