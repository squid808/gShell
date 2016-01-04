using System;
using System.Collections.Generic;
using System.Management.Automation;
using gShell.dotNet.Utilities;
using gShell.dotNet.Utilities.OAuth2;
using gShell.dotNet.Utilities.Settings;

namespace gShell.Cmdlets.Utilities.gShellDomain
{
    #region Get-gShellDomain
    [Cmdlet(VerbsCommon.Get, "gShellDomain",
          SupportsShouldProcess = true,
          DefaultParameterSetName = "All",
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-gShellDomain")]
    public class GetgShellDomainCommand : UtilityBase
    {
        #region Parameters

        [Parameter(Position = 0,
            Mandatory = false,
            ParameterSetName = "One")]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        [Parameter(Position = 0,
            Mandatory = false,
            ParameterSetName = "Default")]
        public SwitchParameter Default { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Domain", "Get-gShellDomain"))
            {
                switch (ParameterSetName)
                {
                    case "One":
                        WriteObject(OAuth2Base.infoConsumer.GetDomain(Domain));
                        break;

                    case "Default":
                        WriteObject(OAuth2Base.infoConsumer.GetDomain(OAuth2Base.infoConsumer.GetDefaultDomain()));
                        break;

                    default:
                        WriteObject(OAuth2Base.infoConsumer.GetAllDomains());
                        break;
                }
            }
        }
    }
    #endregion

    #region Get-gShellUser
    [Cmdlet(VerbsCommon.Get, "gShellUser",
          SupportsShouldProcess = true,
          DefaultParameterSetName = "All",
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-gShellUser")]
    public class GetgShellUserCommand : UtilityBase
    {
        #region Parameters

        [Parameter(Position = 0,
            Mandatory = false,
            ParameterSetName = "One")]
        [ValidateNotNullOrEmpty]
        public string UserEmail { get; set; }

        [Parameter(Position = 0,
            Mandatory = false,
            ParameterSetName = "Default")]
        public SwitchParameter Default { get; set; }

        [Parameter(Position = 1,
            Mandatory = false,
            ParameterSetName = "Domain")]
        public string Domain { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Domain", "Get-gShellDomain"))
            {
                switch (ParameterSetName)
                {
                    case "All":
                        WriteObject(OAuth2Base.infoConsumer.GetAllUsers());
                        break;

                    case "One":
                        WriteObject(OAuth2Base.infoConsumer.GetUser(
                            Utils.GetUserFromEmail(UserEmail), 
                            Utils.GetDomainFromEmail(UserEmail)));
                        break;

                    case "Default":
                        WriteObject(OAuth2Base.infoConsumer.GetUser(
                            OAuth2Base.infoConsumer.GetDefaultDomain()));
                        break;
                    case "Domain":
                        WriteObject(OAuth2Base.infoConsumer.GetAllUsers(Domain));
                        break;
                }
            }
        }
    }
    #endregion

    #region Set-gShellDomain
    
    [Cmdlet(VerbsCommon.Set, "gShellDomain",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-gShellDomain")]
    public class SetgShellDomainCommand : UtilityBase
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
                if (ShouldProcess("Domain", "Set-gShellDomain"))
                {
                    if (SetAsDefault)
                    {
                        OAuth2Base.infoConsumer.SetDefaultDomain(Domain);
                        //In theory, no need to do anything else since before our next API call we'll authenticate.
                    }

                    if (!string.IsNullOrWhiteSpace(DefaultUser))
                    {
                        OAuth2Base.infoConsumer.SetDefaultUser(Domain, DefaultUser);
                    }
                }
            }
        }
    }

    #endregion

    #region Remove-gShellDomain
    [Cmdlet(VerbsCommon.Remove, "gShellDomain",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-gShellDomain")]
    public class RemovegShellDomain : UtilityBase
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
            if (ShouldProcess(Domain, "Remove-gShellDomain"))
            {
                if (Force || ShouldContinue((String.Format("Stored authentication information for domain {0} will be deleted.\nContinue?",
                    Domain)), "Confirm removal of stored authentication information"))
                {
                    if (OAuth2Base.infoConsumer.GetDefaultDomain() == Domain)
                    {
                        WriteError(new ErrorRecord(new Exception("This domain is the default domain. Please change "+
                            "the default domain before removing it."),
                            "", ErrorCategory.InvalidData, Domain));
                    }
                    else
                    {

                        try
                        {
                            WriteDebug(string.Format("Attempting to remove stored information for domain {0}...", Domain));

                            OAuth2Base.infoConsumer.RemoveDomain(Domain);

                            WriteVerbose(string.Format("Removal of {0} completed without error.", Domain));
                        }
                        catch (Exception e)
                        {
                            WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, Domain));
                        }
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

    #region Remove-gShellUser
    [Cmdlet(VerbsCommon.Remove, "gShellUser",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-gShellUser")]
    public class RemovegShellUser : UtilityBase
    {
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserEmail { get; set; }

        [Parameter(Position = 1)]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            if (ShouldProcess(UserEmail, "Remove-gShellUser"))
            {
                if (Force || ShouldContinue((String.Format("Stored authentication information for user {0} will be deleted.\nContinue?",
                    UserEmail)), "Confirm removal of stored authentication information"))
                {
                    string user = Utils.GetUserFromEmail(UserEmail);
                    string domain = Utils.GetDomainFromEmail(UserEmail);

                    if (OAuth2Base.infoConsumer.GetDefaultUser(domain) == user)
                    {
                        WriteError(new ErrorRecord(new Exception("This user is the default user for its domain. " +
                            "Please change the default user before removing it."),
                            "", ErrorCategory.InvalidData, domain));
                    }

                    try
                    {
                        WriteDebug(string.Format("Attempting to remove stored information for domain {0}...", UserEmail));

                        OAuth2Base.infoConsumer.RemoveUser(domain, user);

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

    #region gShellClientSecrets

    [Cmdlet(VerbsCommon.Get, "gShellClientSecrets",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-gShellClientSecrets")]
    public class GetgShellClientSecretsCommand : UtilityBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("ClientSecrets", "Get-gShellClientSecrets"))
            {
                WriteObject(OAuth2Base.infoConsumer.GetClientSecrets());
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "gShellClientSecrets",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-gShellClientSecrets")]
    public class SetgShellClientSecretsCommand : UtilityBase
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
            if (ShouldProcess("ClientSecrets", "Set-gShellClientSecrets"))
            {
                OAuth2Base.infoConsumer.SetDefaultClientSecrets(new Google.Apis.Auth.OAuth2.ClientSecrets()
                {
                    ClientId = this.ClientId,
                    ClientSecret = this.ClientSecret
                });
            }
        }
    }

    [Cmdlet(VerbsCommon.Remove, "gShellClientSecrets",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-gShellClientSecrets")]
    public class RemovegShellClientSecretsCommand : UtilityBase
    {
        #region Properties
        [Parameter(Position = 0)]
        public SwitchParameter Force { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("ClientSecrets", "Remove-gShellDomain"))
            {
                if (Force || ShouldContinue((String.Format("Custom Client Secrets information for gShell will be deleted.\nContinue?"
                    )), "Confirm removal of custom Client Secrets"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove custom Client Secrets from gShell"));

                        OAuth2Base.infoConsumer.RemoveClientSecrets();

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

    #region gShellSettings

    [Cmdlet(VerbsCommon.Set, "gShellSettings",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-gShellSettings")]
    public class SetgShellSettingsCommand : UtilityBase
    {
        #region Parameters

        [Parameter(Position = 0)]
        public gShellSettings.SerializeTypes? SerializedFileType { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Domain", "Set-gShellDomain"))
            {
                if (SerializedFileType.HasValue)
                {
                    gShellSettings settings = gShellSettingsLoader.Load();

                    if (settings == null) settings = new gShellSettings();

                    settings.SerializeType = SerializedFileType.Value;

                    gShellSettingsLoader.Save(settings);
                }
            }
        }
    }

    #endregion
}
