using System;
using System.Collections.Generic;
using System.Management.Automation;
using gShell.dotNet.Utilities;
using gShell.dotNet.Utilities.OAuth2;

namespace gShell.Cmdlets.Utilities.GshellDomain
{
    #region Get-GshellDomain
    [Cmdlet(VerbsCommon.Get, "GshellDomain",
          SupportsShouldProcess = true,
          DefaultParameterSetName="All",
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GshellDomain")]
    public class GetGshellDomainCommand : UtilityBase
    {
        #region Parameters

        [Parameter(Position = 0,
            Mandatory = false,
            ParameterSetName="One")]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        [Parameter(Position = 0,
            Mandatory = false,
            ParameterSetName="Default")]
        public SwitchParameter Default { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Domain", "Get-GshellDomain"))
            {
                switch (ParameterSetName)
                {
                    case "All":
                        List<OAuth2Domain> domains = new List<OAuth2Domain>();
                        foreach (string dom in SavedFile.GetDomainList()) {
                            domains.Add(SavedFile.GetDomain(dom));
                        }
                        WriteObject(domains);
                        break;

                    case "One":
                        WriteObject(SavedFile.GetDomain(Domain));
                        break;

                    case "Default":
                        WriteObject(SavedFile.GetDefaultDomain());
                        break;
                }
            }
        }
    }
    #endregion

    #region Get-GshellUser
    [Cmdlet(VerbsCommon.Get, "GshellUser",
          SupportsShouldProcess = true,
          DefaultParameterSetName="All",
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GshellUser")]
    public class GetGshellUserCommand : UtilityBase
    {
        #region Parameters

        [Parameter(Position = 0,
            Mandatory = false,
            ParameterSetName="One")]
        [ValidateNotNullOrEmpty]
        public string UserEmail { get; set; }

        [Parameter(Position = 0,
            Mandatory = false,
            ParameterSetName = "Domain")]
        [Parameter(Position = 0,
            Mandatory = false,
            ParameterSetName="Default")]
        public SwitchParameter Default { get; set; }

        [Parameter(Position = 1,
            Mandatory = false,
            ParameterSetName = "Domain")]
        public string Domain { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Domain", "Get-GshellDomain"))
            {
                switch (ParameterSetName)
                {
                    case "All":
                        WriteObject(SavedFile.GetUsers());
                        break;

                    case "One":
                        WriteObject(SavedFile.GetUser(UserEmail));
                        break;

                    case "Default":
                        WriteObject(SavedFile.GetDomainDefaultUser(SavedFile.GetDefaultDomain()));
                        break;
                    case "Domain":
                        if (Default)
                        {
                            WriteObject(SavedFile.GetDomainDefaultUser(Domain));
                        }
                        else
                        {
                            WriteObject(SavedFile.GetUsers(Domain));
                        }
                        break;
                }
            }
        }
    }
    #endregion

    #region Set-GshellDomain
    [Cmdlet(VerbsCommon.Set, "GshellDomain",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GshellDomain")]
    public class SetGshellDomainCommand : UtilityBase
    {
        #region Parameters

        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        [Parameter(Position = 1,
            Mandatory = false)]
        public SwitchParameter SetAsDefault { get; set; }

        [Parameter(Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string DefaultUser { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (!string.IsNullOrWhiteSpace(DefaultUser) || SetAsDefault != null)
            {
                if (ShouldProcess("Domain", "Set-GshellDomain"))
                {
                    if (SetAsDefault)
                    {
                        SavedFile.SetDefaultDomain(Domain);
                        OAuth2Base.SetCurrentDomain(Domain);
                        OAuth2Base.SetDefaultDomain(OAuth2Base.currentDomain);
                    }

                    if (!string.IsNullOrWhiteSpace(DefaultUser))
                    {
                        SavedFile.SetDefaultUser(Utils.GetFullEmailAddress(DefaultUser, Domain));
                    }
                }
            }
        }
    }
    #endregion

    #region Remove-GshellDomain
    [Cmdlet(VerbsCommon.Remove, "GshellDomain",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GshellDomain")]
    public class RemoveGshellDomain : UtilityBase
    {
        [Parameter(Position = 0,
            Mandatory = true,
            HelpMessage = "The domain whose saved authentication data is to be removed, ex. contoso.com")]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        [Parameter(Position = 1)]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            if (ShouldProcess(Domain, "Remove-GshellDomain"))
            {
                if (Force || ShouldContinue((String.Format("Stored authentication information for domain {0} will be deleted.\nContinue?",
                    Domain)), "Confirm removal of stored authentication information"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove stored information for domain {0}...", Domain));

                        SavedFile.RemoveDomain(Domain);

                        WriteVerbose(string.Format("Removal of {0} completed without error.", Domain));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, Domain));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Deletion of stored authentication information not confirmed"),
                        "", ErrorCategory.InvalidData, Domain));
                }
            }
        }
    }
    #endregion

    #region Remove-GshellUser
    [Cmdlet(VerbsCommon.Remove, "GshellUser",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GshellUser")]
    public class RemoveGshellUser : UtilityBase
    {
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserEmail { get; set; }

        [Parameter(Position = 1)]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            if (ShouldProcess(UserEmail, "Remove-GshellDomain"))
            {
                if (Force || ShouldContinue((String.Format("Stored authentication information for user {0} will be deleted.\nContinue?",
                    UserEmail)), "Confirm removal of stored authentication information"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove stored information for domain {0}...", UserEmail));

                        SavedFile.RemoveUser(UserEmail);

                        WriteVerbose(string.Format("Removal of {0} completed without error.", UserEmail));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, UserEmail));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Deletion of stored authentication information not confirmed"),
                        "", ErrorCategory.InvalidData, UserEmail));
                }
            }
        }
    }
    #endregion

    #region GshellClientSecrets
    [Cmdlet(VerbsCommon.Get, "GshellClientSecrets",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GshellClientSecrets")]
    public class GetGshellClientSecretsCommand : UtilityBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("ClientSecrets", "Get-GshellClientSecrets"))
            {
                WriteObject(SavedFile.GetClientSecrets());
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GshellClientSecrets",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GshellClientSecrets")]
    public class SetGshellClientSecretsCommand : UtilityBase
    {
        #region Parameters

        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ClientId { get; set; }

        [Parameter(Position = 1,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ClientSecret { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("ClientSecrets", "Set-GshellClientSecrets"))
            {
                SavedFile.SetClientSecrets(new Google.Apis.Auth.OAuth2.ClientSecrets(){
                    ClientId = this.ClientId,
                    ClientSecret = this.ClientSecret
                });
            }
        }
    }

    [Cmdlet(VerbsCommon.Remove, "GshellClientSecrets",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GshellClientSecrets")]
    public class RemoveGshellClientSecretsCommand : UtilityBase
    {
        #region Properties
        [Parameter(Position = 0)]
        public SwitchParameter Force { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("ClientSecrets", "Remove-GshellDomain"))
            {
                if (Force || ShouldContinue((String.Format("Custom Client Secrets information for gShell will be deleted.\nContinue?"
                    )), "Confirm removal of custom Client Secrets"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove custom Client Secrets from gShell"));

                        SavedFile.RemoveClientSecrets();

                        WriteVerbose(string.Format("Removal of custom Client Secrets completed without error."));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, "Client Secrets"));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Deletion of stored authentication information not confirmed"),
                        "", ErrorCategory.InvalidData, "Client Secrets"));
                }
            }
        }
    }
    #endregion
}
