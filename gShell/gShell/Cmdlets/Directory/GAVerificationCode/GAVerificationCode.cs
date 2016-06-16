//using System;
//using System.Management.Automation;

//namespace gShell.Cmdlets.Directory.GAVerificationCode
//{
//    [Cmdlet(VerbsCommon.Get, "GAVerificationCode",
//          SupportsShouldProcess = true,
//          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAVerificationCode")]
//    public class GetGAVerificationCode : DirectoryBase
//    {
//        #region Properties

//        [Parameter(Position = 0,
//            Mandatory = true,
//            ValueFromPipelineByPropertyName = true)]
//        [ValidateNotNullOrEmpty]
//        public string UserKey { get; set; }

//        //Domain position = 1

//        #endregion

//        protected override void ProcessRecord()
//        {
//            UserKey = GetFullEmailAddress(UserKey, Domain);

//            if (ShouldProcess(UserKey, "Get-GAVerificationCode"))
//            {
//                WriteObject(verificationCodes.List(UserKey));
//            }
//        }
//    }

//    [Cmdlet(VerbsSecurity.Revoke, "GAVerificationCode",
//          SupportsShouldProcess = true,
//          HelpUri = @"https://github.com/squid808/gShell/wiki/Revoke-GAVerificationCode")]
//    public class RemoveGAVerificationCode : DirectoryBase
//    {
//        #region Properties

//        [Parameter(Position = 0,
//            Mandatory = true,
//            ValueFromPipelineByPropertyName = true)]
//        [ValidateNotNullOrEmpty]
//        public string UserKey { get; set; }

//        //Domain position = 1

//        [Parameter(Position = 2)]
//        public SwitchParameter Force { get; set; }

//        #endregion

//        protected override void ProcessRecord()
//        {
//            if (ShouldProcess(UserKey, "Revoke-GAVerificationCode"))
//            {
//                if (Force || ShouldContinue((String.Format("Verification Codes for user {0} will be invalidated on the {1} Google Apps domain.\nContinue?",
//                    UserKey, Domain)), "Confirm Google Apps Verification Code Invalidation"))
//                {
//                    try
//                    {
//                        WriteDebug(string.Format("Attempting to revoke Verification Codes {0}...",
//                            UserKey));
//                        verificationCodes.Invalidate(UserKey);
//                        WriteVerbose(string.Format("Invalidation of Verification Codes for user {0} completed without error.",
//                            UserKey));
//                    }
//                    catch (Exception e)
//                    {
//                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, UserKey));
//                    }
//                }
//                else
//                {
//                    WriteError(new ErrorRecord(new Exception("Verification Codes invalidation not confirmed"),
//                        "", ErrorCategory.InvalidData, UserKey));
//                }
//            }
//        }
//    }

//    [Cmdlet(VerbsCommon.New, "GAVerificationCode",
//          SupportsShouldProcess = true,
//          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAVerificationCode")]
//    public class NewGAVerificationCode : DirectoryBase
//    {
//        #region Properties
//        [Parameter(Position = 0,
//            Mandatory = true,
//            ValueFromPipelineByPropertyName = true)]
//        [ValidateNotNullOrEmpty]
//        public string UserKey { get; set; }

//        //Domain position = 1
//        #endregion

//        protected override void ProcessRecord()
//        {
//            UserKey = GetFullEmailAddress(UserKey, Domain);

//            if (ShouldProcess(UserKey, "New-GAVerificationCode"))
//            {
//                verificationCodes.Generate(UserKey);
//            }
//        }
//    }
//}
