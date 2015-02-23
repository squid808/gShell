using System.Management.Automation;
using gShell.Cmdlets.Utilities;

namespace gShell.Cmdlets.Utilities.GASavedDomain
{
    [Cmdlet(VerbsCommon.Set, "GADefaultDomain",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GADefaultDomain")]
    public class SetGADefaultDomainCommand : UtilityBase
    {
        #region Parameters

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Domain", "Set-GADefaultDomain"))
            {
                SetDefaultDomain();
            }
        }

        private void SetDefaultDomain()
        {
            if (SavedFile.ContainsUserOrDomain(Domain))
            {
                SavedFile.SetDefaultDomain(Domain);
                OAuth2Base.SetCurrentDomain(Domain);
            }
            else
            {
                OAuth2Base.SetCurrentDomain(Authenticate(Domain));
            }

            OAuth2Base.SetDefaultDomain(OAuth2Base.currentDomain);
        }
    }
}
