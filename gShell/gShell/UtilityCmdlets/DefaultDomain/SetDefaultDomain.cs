using System.Management.Automation;
using gShell.OAuth2;

namespace gShell.UtilityCmdlets.DefaultDomain
{
    [Cmdlet(VerbsCommon.Set, "GADefaultDomain",
        SupportsShouldProcess = true)]
    public class SetDefaultDomainCommand : DefaultDomainObject
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
            SetDefaultDomain();
        }

        private void SetDefaultDomain()
        {
            if (SavedFile.ContainsDomain(Domain))
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
