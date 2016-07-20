using System;
using System.Management.Automation;
using gShell.dotNet.Utilities;
using gShell.dotNet.Utilities.OAuth2;
using gShell.dotNet.Utilities.Settings;

namespace gShell.Cmdlets.Utilities.gShellDomain
{
    /// <summary>
    /// <para type="synopsis">Retrieve one or all domains for which gShell has information saved.</para>
    /// <para type="description">Retrieve one or all domains for which gShell has information saved.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GShellDomain</code>
    ///   <para>Show all domains with information saved.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GShellDomain -Domain "example.com"</code>
    ///   <para>Retrieve the information for the domain example.com</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GShellDomain -Default</code>
    ///   <para>Show the information for only the default domain. This is the domain used when you omit the -Domain parameter on most Cmdlets.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GShellDomain">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GShellDomain",
          SupportsShouldProcess = true,
          DefaultParameterSetName = "All",
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GShellDomain")]
    public class GetGShellDomainCommand : UtilityBase
    {
        #region Parameters

        /// <summary>
        /// <para type="description">The domain to retrieve saved information.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ParameterSetName = "One",
            HelpMessage = "The domain to retrieve saved information.")]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        /// <summary>
        /// <para type="description">Retrieve only the default domain for gShell.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ParameterSetName = "Default",
            HelpMessage = "Retrieve only the default domain for gShell.")]
        public SwitchParameter Default { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Domain", "Get-GShellDomain"))
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
    
    /// <summary>
    /// <para type="synopsis">Retrieve information on users for which gShell has saved (authentication) information.</para>
    /// <para type="description">Retrieve information on users for which gShell has saved (authentication) information.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GShellUser</code>
    ///   <para>Return all users that have saved information.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GShellUser -Default</code>
    ///   <para>Return only the default user (for the default domain).</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GShellUser -Domain "example.com"</code>
    ///   <para>Return users only for a particular domain.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GShellUser -UserEmail "someuser@example.com"</code>
    ///   <para>Return information for a specific user.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GShellUser">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GShellUser",
          SupportsShouldProcess = true,
          DefaultParameterSetName = "All",
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GShellUser")]
    public class GetGShellUserCommand : UtilityBase
    {
        #region Parameters

        /// <summary>
        /// <para type="description">The email address for a specific user account.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ParameterSetName = "One",
            HelpMessage = "The email address for a specific user account.")]
        [ValidateNotNullOrEmpty]
        public string UserEmail { get; set; }

        /// <summary>
        /// <para type="description">Return only the default user.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ParameterSetName = "Default",
            HelpMessage = "Return only the default user.")]
        public SwitchParameter Default { get; set; }

        /// <summary>
        /// <para type="description">A domain to return all users for.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ParameterSetName = "Domain",
            HelpMessage = "A domain to return all users for.")]
        public string Domain { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Domain", "Get-GShellDomain"))
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
                        string defaultDomain = OAuth2Base.infoConsumer.GetDefaultDomain();
                        WriteObject(OAuth2Base.infoConsumer.GetUser(defaultDomain,
                            OAuth2Base.infoConsumer.GetDefaultUser(Domain)));
                        break;
                    case "Domain":
                        WriteObject(OAuth2Base.infoConsumer.GetAllUsers(Domain));
                        break;
                }
            }
        }
    }
    
    /// <summary>
    /// <para type="synopsis">Update a saved domain's default user or mark it as the default domain.</para>
    /// <para type="description">Update a saved domain's default user or mark it as the default domain.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GShellDomain -Domain "example.com" -SetAsDefault</code>
    ///   <para>Set this domain as the default domain.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GShellDomain">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GShellDomain",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GShellDomain")]
    public class SetGShellDomainCommand : UtilityBase
    {
        #region Parameters

        /// <summary>
        /// <para type="description">The target domain.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            HelpMessage = "The target domain.")]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        /// <summary>
        /// <para type="description">Indicate that this should be the default domain.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            HelpMessage = "Indicate that this should be the default domain.")]
        public SwitchParameter SetAsDefault { get; set; }

        /// <summary>
        /// <para type="description">The user in the domain that should be used as the default user.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            HelpMessage = "The user in the domain that should be used as the default user.")]
        [ValidateNotNullOrEmpty]
        public string DefaultUser { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (!string.IsNullOrWhiteSpace(DefaultUser) || SetAsDefault != null)
            {
                if (ShouldProcess("Domain", "Set-GShellDomain"))
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

    /// <summary>
    /// <para type="synopsis">Remove a domain's saved information from gShell.</para>
    /// <para type="description">Remove a domain's saved information from gShell.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GShellDomain -Domain "example.com" -Force</code>
    ///   <para>This example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GShellDomain">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GShellDomain",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GShellDomain")]
    public class RemoveGShellDomainCommand : UtilityBase
    {
        /// <summary>
        /// <para type="description">The domain whose saved authentication data is to be removed, ex. contoso.com"</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            HelpMessage = "The domain whose saved authentication data is to be removed, ex. contoso.com")]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting")]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            if (ShouldProcess(Domain, "Remove-GShellDomain"))
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
    
    /// <summary>
    /// <para type="synopsis">Remove a domain user's saved information from gShell.</para>
    /// <para type="description">Remove a domain user's saved information from gShell.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GShellUser -UserEmail "someuser@domain.com" -Force</code>
    ///   <para>This example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GShellUser">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GShellUser",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GShellUser")]
    public class RemoveGShellUserCommand : UtilityBase
    {
        /// <summary>
        /// <para type="description">The full email address of the user to remove.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            HelpMessage = "The full email address of the user to remove.")]
        [ValidateNotNullOrEmpty]
        public string UserEmail { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting")]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            if (ShouldProcess(UserEmail, "Remove-GShellUser"))
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

    #region gShellClientSecrets

    /// <summary>
    /// <para type="synopsis">Retrieve and display the client secrets saved in gShell.</para>
    /// <para type="description">Retrieve and display the client secrets saved in gShell.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GShellClientSecrets</code>
    ///   <para>Return the default client secrets used in gShell.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GShellClientSecrets">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GShellClientSecrets",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GShellClientSecrets")]
    public class GetGShellClientSecretsCommand : UtilityBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("ClientSecrets", "Get-GShellClientSecrets"))
            {
                WriteObject(OAuth2Base.infoConsumer.GetDefaultClientSecrets());
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Set or update the client secrets used by gShell.</para>
    /// <para type="description">Set or update the client secrets used by gShell.
    /// Before you can use gShell, you must create your own project in the Google Developers Console and get a Client ID and Secret. This allows you to tell Google which APIs you will be using with gShell, and allows them to keep track of your quotas. If you're unsure of how to proceed, please see a brief description below:
    /// Step 1) Create a new project. Name it something that makes sense to you, like 'gShell Toolkit for My Domain'. Step 2) Choose and enable which APIs you'd like to access. If you don't enable an API here, gShell won't be able to access that API on your behalf. Step 3) Create new credentials. On step 6, choose 'Other' as the Application Type.
    /// Following the above steps provides you with a Client ID and Secret, which you can save for use in gShell by using this Cmdlet.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-gShellClientSecrets -ClientId "sfalskdhflaksdf23234-adsfpkasdgalskjdf.apps.googleusercontent.com" -ClientSecret "a235fbdosidhf3f8dSDfwefo"</code>
    ///   <para>The clientID and clientSecret in this example are gibberish used for the sake of the example.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GShellClientSecrets">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// <para type="link" uri="https://console.developers.google.com/">[The Google Developer's Console]</para>
    /// <para type="link" uri="https://support.google.com/cloud/answer/6251787">[Create, shut down, and restore projects]</para>
    /// <para type="link" uri="https://support.google.com/cloud/answer/6158841">[Enable and disable APIs]</para>
    /// <para type="link" uri="https://support.google.com/cloud/answer/6158849">[Setting Up Oauth 2.0]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GShellClientSecrets",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GShellClientSecrets")]
    public class SetGShellClientSecretsCommand : UtilityBase
    {
        #region Parameters

        /// <summary>
        /// <para type="description">The ClientID provided in the project's APIs & auth section in the Google Developer's Console.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            HelpMessage = "The ClientID provided in the project's APIs & auth section in the Google Developer's Console.")]
        [ValidateNotNullOrEmpty]
        public string ClientId { get; set; }

        /// <summary>
        /// <para type="description">The ClientSecret provided in the project's APIs & auth section in the Google Developer's Console.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = true,
            HelpMessage = "The ClientSecret provided in the project's APIs & auth section in the Google Developer's Console.")]
        [ValidateNotNullOrEmpty]
        public string ClientSecret { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("ClientSecrets", "Set-GShellClientSecrets"))
            {
                OAuth2Base.infoConsumer.SetDefaultClientSecrets(new Google.Apis.Auth.OAuth2.ClientSecrets()
                {
                    ClientId = this.ClientId,
                    ClientSecret = this.ClientSecret
                });
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Remove the default client secrets stored for gShell.</para>
    /// <para type="description">Remove the default client secrets stored for gShell.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GShellClientSecrets -Force</code>
    ///   <para>Remove the default client secrets stored without being prompted to continue.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GShellClientSecrets">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GShellClientSecrets",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GShellClientSecrets")]
    public class RemoveGShellClientSecretsCommand : UtilityBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("ClientSecrets", "Remove-GShellDomain"))
            {
                if (Force || ShouldContinue((String.Format("Custom Client Secrets information for gShell will be deleted.\nContinue?"
                    )), "Confirm removal of custom Client Secrets"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove custom Client Secrets from gShell"));

                        OAuth2Base.infoConsumer.RemoveDefaultClientSecrets();

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

    /// <summary>
    /// <para type="synopsis">Update one or more settings specific to gShell itself.</para>
    /// <para type="description">Update one or more settings specific to gShell itself.
    /// Currently you can change the file type that gShell will use when serializing the authentication information and the location where the authentication information is stored.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Drive API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GShellSettings</code>
    ///   <para>This example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GShellSettings">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GShellSettings",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GShellSettings")]
    public class SetGShellSettingsCommand : UtilityBase
    {
        #region Parameters

        /// <summary>
        /// <para type="description">The type of file gShell should save the serialization information in to. Options are Bin or Json.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            HelpMessage = "The type of file gShell should save the serialization information in to. Options are Bin or Json.")]
        public gShellSettings.SerializeTypes? SerializedFileType { get; set; }

        /// <summary>
        /// <para type="description">The directory path for where gShell looks for the authentication information file.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            HelpMessage = "The directory path for where gShell looks for the authentication information file.")]
        [ValidateNotNullOrEmpty]
        public string AuthInfoPath { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Domain", "Set-GShellDomain"))
            {
                gShellSettings settings = gShellSettingsLoader.Load();

                if (SerializedFileType.HasValue) settings.SerializeType = SerializedFileType.Value;

                if (!string.IsNullOrWhiteSpace(AuthInfoPath))
                {
                    settings.AuthInfoPath = AuthInfoPath;
                    OAuth2InfoConsumer.UpdateSettings(settings);
                }

                gShellSettingsLoader.Save(settings);
            }
        }
    }

    #endregion
}
