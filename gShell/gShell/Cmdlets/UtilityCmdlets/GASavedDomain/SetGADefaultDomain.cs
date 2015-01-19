using System.Management.Automation;
using gShell.OAuth2;

namespace gShell.UtilityCmdlets.SavedDomain
{
    [Cmdlet(VerbsCommon.Set, "GADefaultDomain",
        SupportsShouldProcess = true)]
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
                currentDomain = Domain;
            }
            else
            {
                currentDomain = Authenticate(Domain);
            }

            defaultDomain = currentDomain;
        }
    }
}
