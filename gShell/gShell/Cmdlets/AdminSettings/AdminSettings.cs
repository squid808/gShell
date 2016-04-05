using System;
using System.Management.Automation;
using System.Collections.Generic;

using Google.Apis.Auth.OAuth2;
using Data = Google.Apis.admin.Adminsettings.adminsettings_v1.Data;

using gAdminsettings = gShell.dotNet.Adminsettings;
using gShell.Cmdlets.Adminsettings;

namespace gShell.Cmdlets.Adminsettings
{
    public enum GatewaySmtpModeEnum
    { SMTP, SMTP_TLS }

    public enum RouteAccountHandlingEnum
    { allAccounts, provisionedAccounts, unknownAccounts }
}

namespace gShell.Cmdlets.Adminsettings.DefaultLanguage
{
    using gShell.Cmdlets.Emailsettings;
    using gShell.Cmdlets.Emailsettings.Language;

    [Cmdlet(VerbsCommon.Get, "GAdminSettingsDefaultLanguage",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGAdminSettingsDefaultLanguage : AdminsettingsBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Admin Settings DefaultLanguage", "-GAdminSettingsDefaultLanguage"))
            {
                WriteObject(defaultLanguage.Get(Domain));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GAdminSettingsDefaultLanguage",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGAdminSettingsDefaultLanguage : AdminsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName = "word")]
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName = "abbrev")]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 1,
            Mandatory = true,
            ParameterSetName = "word")]
        [ValidateNotNullOrEmpty]
        public LanguageLanguageEnum DefaultLanguage { get; set; }

        [Parameter(Position = 1,
           Mandatory = true,
           ParameterSetName = "abbrev")]
        [ValidateNotNullOrEmpty]
        public LanguageLanguageAbbrevEnum LanguageAbbreviation { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.DefaultLanguage();

            if (ParameterSetName == "word")
            {
                body.DefaultLanguageValue = SetGEmailSettingsLanguage.LookupLanguage(this.DefaultLanguage);
            }
            else
            {
                body.DefaultLanguageValue = SetGEmailSettingsLanguage.LookupLanguage(this.LanguageAbbreviation);
            }

            if (ShouldProcess("Admin Settings DefaultLanguage", "Get-GAdminSettingsDefaultLanguage"))
            {
                WriteObject(defaultLanguage.Update(body, Domain));
            }
        }
    }
}

namespace gShell.Cmdlets.Adminsettings.OrganizationName
{
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsOrganizationName",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGAdminSettingsOrganizationName : AdminsettingsBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Admin Settings OrganizationName", "Get-GAdminSettingsOrganizationName"))
            {
                WriteObject(organizationName.Get(Domain));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GAdminSettingsOrganizationName",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGAdminSettingsOrganizationName : AdminsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string OrganizationName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.OrganizationName()
            {
                OrganizationNameValue = this.OrganizationName
            };

            if (ShouldProcess("Admin Settings OrganizationName", "Set-GAdminSettingsOrganizationName"))
            {
                WriteObject(organizationName.Update(body, Domain));
            }
        }
    }
}

namespace gShell.Cmdlets.Adminsettings.MaximumUsers
{
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsMaximumUsers",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGAdminSettingsMaximumUsers : AdminsettingsBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Admin Settings MaximumUsers", "Get-GAdminSettingsMaximumUsers"))
            {
                WriteObject(maximumUsers.Get(Domain));
            }
        }
    }
}

namespace gShell.Cmdlets.Adminsettings.CurrentUsers
{
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsCurrentUsers",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGAdminSettingsCurrentUsers : AdminsettingsBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Admin Settings CurrentUsers", "Get-GAdminSettingsCurrentUsers"))
            {
                WriteObject(currentUsers.Get(Domain));
            }
        }
    }
}

namespace gShell.Cmdlets.Adminsettings.ProductVersion
{
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsProductVersion",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGAdminSettingsProductVersion : AdminsettingsBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Admin Settings ProductVersion", "Get-GAdminSettingsProductVersion"))
            {
                WriteObject(productVersion.Get(Domain));
            }
        }
    }
}

namespace gShell.Cmdlets.Adminsettings.CustomerPin
{
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsCustomerPin",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGAdminSettingsCustomerPin : AdminsettingsBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Admin Settings CustomerPin", "Get-GAdminSettingsCustomerPin"))
            {
                WriteObject(customerPin.Get(Domain));
            }
        }
    }
}

namespace gShell.Cmdlets.Adminsettings.CreationTime
{
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsCreationTime",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGAdminSettingsCreationTime : AdminsettingsBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Admin Settings CreationTime", "Get-GAdminSettingsCreationTime"))
            {
                WriteObject(creationTime.Get(Domain));
            }
        }
    }
}

namespace gShell.Cmdlets.Adminsettings.CountryCode
{
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsCountryCode",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGAdminSettingsCountryCode : AdminsettingsBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Admin Settings CountryCode", "Get-GAdminSettingsCountryCode"))
            {
                WriteObject(countryCode.Get(Domain));
            }
        }
    }
}

namespace gShell.Cmdlets.Adminsettings.AdminSecondaryEmail
{
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsAdminSecondaryEmail",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGAdminSettingsAdminSecondaryEmail : AdminsettingsBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Admin Settings AdminSecondaryEmail", "Get-GAdminSettingsAdminSecondaryEmail"))
            {
                WriteObject(adminSecondaryEmail.Get(Domain));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GAdminSettingAdminSecondaryEmails",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGAdminSettingsAdminSecondaryEmail : AdminsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string AdminSecondaryEmail { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.AdminSecondaryEmail()
            {
                AdminSecondaryEmailValue = this.AdminSecondaryEmail
            };

            if (ShouldProcess("Admin Settings AdminSecondaryEmail", "Set-GAdminSettingsAdminSecondaryEmail"))
            {

            }
        }
    }
}

namespace gShell.Cmdlets.Adminsettings.CustomLogo
{
    using gShell.dotNet.Utilities;

    [Cmdlet(VerbsCommon.Set, "GAdminSettingsCustomLogo",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGAdminSettingsCustomLogo : AdminsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.CustomLogo()
            {
                LogoImage = Utils.LoadImageToBase64(Path)
            };

            if (ShouldProcess("Admin Settings CustomLogo", "Set-GAdminSettingsCustomLogo"))
            {
                WriteObject(customLogo.Update(body, Domain));
            }
        }
    }
}

namespace gShell.Cmdlets.Adminsettings.MxVerificationRecords
{
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsMxVerificationRecords",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGAdminSettingsMxVerificationRecords : AdminsettingsBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Admin Settings MxVerificationRecords", "Get-GAdminSettingsMxVerificationRecords"))
            {
                WriteObject(mxVerificationStatus.Get(Domain));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GAdminSettingsMxVerificationRecords",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGAdminSettingsMxVerificationRecords : AdminsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Verified { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (!Verified)
            {
                WriteError(new ErrorRecord(new Exception("Must select Verified to continue."), "", ErrorCategory.InvalidArgument, this));
            }

            var body = new Data.MXVerificationStatus()
            {
                Verified = true
            };

            if (ShouldProcess("Admin Settings MxVerificationRecords", "Set-GAdminSettingsMxVerificationRecords"))
            {
                WriteObject(mxVerificationStatus.Update(body, Domain));
            }
        }
    }
}

namespace gShell.Cmdlets.Adminsettings.SsoSettings
{
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsSsoSettings",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGAdminSettingsSsoSettings : AdminsettingsBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Admin Settings SsoSettings", "Get-GAdminSettingsSsoSettings"))
            {
                WriteObject(ssoSettings.Get(Domain));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GAdminSettingsSsoSettings",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGAdminSettingsSsoSettings : AdminsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SamlSignonUri { get; set; }

        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SamlLogoutUri { get; set; }

        [Parameter(Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ChangePasswordUri { get; set; }

        [Parameter(Position = 4,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public bool EnableSSO { get; set; }

        [Parameter(Position = 5,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SsoWhitelist { get; set; }

        [Parameter(Position = 6,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public bool UseDomainSpecificIssuer { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.SsoSettings()
            {
                ChangePasswordUri = this.ChangePasswordUri,
                EnableSSO = this.EnableSSO,
                SamlLogoutUri = this.SamlLogoutUri,
                SamlSignonUri = this.SamlSignonUri,
                SsoWhitelist = this.SsoWhitelist,
                UseDomainSpecificIssuer = this.UseDomainSpecificIssuer
            };

            if (ShouldProcess("Admin Settings SsoSettings", "Set-GAdminSettingsSsoSettings"))
            {
                WriteObject(ssoSettings.Update(body, Domain));
            }
        }
    }
}

namespace gShell.Cmdlets.Adminsettings.SsoSigningKey
{
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsSsoSigningKey",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGAdminSettingsSsoSigningKey : AdminsettingsBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Admin Settings SsoSigningKey", "Get-GAdminSettingsSsoSigningKey"))
            {
                WriteObject(ssoSigningKey.Get(Domain));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GAdminSettingsSsoSigningKey",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGAdminSettingsSsoSigningKey : AdminsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SigningKey { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.SsoSigningKey()
            {
                SigningKey = this.SigningKey
            };

            if (ShouldProcess("Admin Settings SsoSigningKey", "Set-GAdminSettingsSsoSigningKey"))
            {
                WriteObject(ssoSigningKey.Update(body, Domain));
            }
        }
    }
}

namespace gShell.Cmdlets.Adminsettings.EmailGateway
{
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsEmailGateway",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class GetGAdminSettingsEmailGateway : AdminsettingsBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Admin Settings EmailGateway", "Get-GAdminSettingsEmailGateway"))
            {
                WriteObject(emailGateway.Get(Domain));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "GAdminSettingsEmailGateway",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGAdminSettingsEmailGateway : AdminsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SmartHost { get; set; }

        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public GatewaySmtpModeEnum SmtpMode { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Gateway()
            {
                SmartHost = this.SmartHost,
                SmtpMode = this.SmtpMode.ToString()
            };

            if (ShouldProcess("Admin Settings EmailGateway", "Set-GAdminSettingsEmailGateway"))
            {
                WriteObject(emailGateway.Update(body, Domain));
            }
        }
    }
}

namespace gShell.Cmdlets.Adminsettings.EmailRouting
{
    [Cmdlet(VerbsCommon.Set, "GAdminSettingsEmailRouting",
          SupportsShouldProcess = true,
          HelpUri = @"")]
    public class SetGAdminSettingsEmailRouting : AdminsettingsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string RouteDestination { get; set; }

        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool RouteRewriteTo { get; set; }

        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool RouteEnabled { get; set; }

        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool BounceNotifications { get; set; }

        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public RouteAccountHandlingEnum AccountHandling { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Routing()
            {
                RouteDestination = this.RouteDestination,
                RouteRewriteTo = this.RouteRewriteTo,
                RouteEnabled = this.RouteEnabled,
                BounceNotification = this.BounceNotifications,
                AccountHandling = this.AccountHandling.ToString()
            };

            if (ShouldProcess("Admin Settings EmailRouting", "Set-GAdminSettingsEmailRouting"))
            {
                WriteObject(emailRouting.Update(body, Domain));
            }
        }
    }
}