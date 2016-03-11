using System;
using System.Management.Automation;

namespace gShell.Cmdlets.Directory.GAToken
{
    [Cmdlet(VerbsCommon.Get, "GAToken",
          DefaultParameterSetName = "One",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAToken")]
    public class GetGAToken : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string UserKey { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName = "One",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ClientId { get; set; }

        [Parameter(Position = 3,
            ParameterSetName = "List")]
        public SwitchParameter All { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            UserKey = GetFullEmailAddress(UserKey, Domain);

            if (ShouldProcess(UserKey, "Get-GAToken"))
            {
                switch (ParameterSetName)
                {
                    case "One":
                        WriteObject(tokens.Get(UserKey, ClientId));
                        break;
                    case "List":
                        WriteObject(tokens.List(UserKey));
                        break;
                }
            }
        }
    }

    [Cmdlet(VerbsCommon.Remove, "GAToken",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GAToken")]
    public class RemoveGAToken : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ClientId { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string UserKey { get; set; }

        [Parameter(Position = 3)]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            UserKey = GetFullEmailAddress(UserKey, Domain);

            if (ShouldProcess(ClientId, "Remove-GAToken"))
            {
                if (Force || ShouldContinue((String.Format("Token for application with Client ID of {0} will be removed for user {2} from the {1} Google Apps domain.\nContinue?",
                    ClientId, Domain, UserKey)), "Confirm Google Apps Token Removal"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove Token for application {0}...",
                            ClientId));
                        tokens.Delete(UserKey, ClientId);
                        WriteVerbose(string.Format("Removal of Token for application {0} completed without error.",
                            ClientId));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, ClientId));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Token deletion not confirmed"),
                        "", ErrorCategory.InvalidData, ClientId));
                }
            }
        }
    }
}
