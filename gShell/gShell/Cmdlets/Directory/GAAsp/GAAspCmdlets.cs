using System;
using System.Collections.Generic;
using System.Management.Automation;
using Data = Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.Cmdlets.Directory.GAAsp
{
    [Cmdlet(VerbsCommon.Get, "GAAsp",
          DefaultParameterSetName = "One",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAAsp")]
    public class GetGAAsp : DirectoryBase
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
        public int CodeId { get; set; }

        [Parameter(Position = 3,
            Mandatory = true,
            ParameterSetName = "List",
            ValueFromPipelineByPropertyName = true)]
        public SwitchParameter All { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(UserKey, "Get-GAAsp"))
            {
                switch (ParameterSetName)
                {
                    case "One":
                        WriteObject(asps.Get(UserKey, Domain, CodeId));
                        break;
                    case "List":
                        WriteObject(asps.List(UserKey, Domain));
                        break;
                }
            }
        }
    }


    [Cmdlet(VerbsCommon.Remove, "GAAsp",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GAAsp")]
    public class RemoveGAAsp : DirectoryBase
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
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public int CodeId { get; set; }

        [Parameter(Position = 2)]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(UserKey, "Remove-GAAsp"))
            {
                if (Force || ShouldContinue((String.Format("Asp {0} with CodeID {2} will be removed from the {1} Google Apps domain.\nContinue?",
                    UserKey, Domain, CodeId)), "Confirm Google Apps Asp Removal"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove Asp {0}...",
                            UserKey));
                        WriteObject(asps.Delete(UserKey, Domain, CodeId));
                        WriteVerbose(string.Format("Removal of Asp {0} completed without error.",
                            UserKey));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, UserKey));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Asp deletion not confirmed"),
                        "", ErrorCategory.InvalidData, UserKey));
                }
            }
        }
    }
}
