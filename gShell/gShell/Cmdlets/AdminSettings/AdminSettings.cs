using System;
using System.Management.Automation;
using gShell.Cmdlets.Emailsettings.Language;
using Data = Google.Apis.admin.Adminsettings.adminsettings_v1.Data;


namespace gShell.Cmdlets.Adminsettings
{
    /// <summary>The SMTP mode options for Gateway.</summary>
    public enum GatewaySmtpModeEnum
    { SMTP, SMTP_TLS }

    /// <summary>The account handling options for Route.</summary>
    public enum RouteAccountHandlingEnum
    { allAccounts, provisionedAccounts, unknownAccounts }
}

namespace gShell.Cmdlets.Adminsettings.DefaultLanguage
{
    using Emailsettings;

    /// <summary>
    /// <para type="synopsis">Retrieve the domain's default language</para>
    /// <para type="description">Retrieve the domain's default language</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAdminSettingsDefaultLanguage</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAdminSettingsDefaultLanguage">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsDefaultLanguage",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAdminSettingsDefaultLanguage")]
    public class GetGAdminSettingsDefaultLanguageCommand : AdminsettingsBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Admin Settings DefaultLanguage", "-GAdminSettingsDefaultLanguage"))
            {
                WriteObject(defaultLanguage.Get(Domain));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Update a domain's default language.</para>
    /// <para type="description">Update a domain's default language.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GAdminSettingsDefaultLanguage -DefaultLanguage English_United_States</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Set-GAdminSettingsDefaultLanguage -LanguageAbbreviation en_US</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GAdminSettingsDefaultLanguage">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GAdminSettingsDefaultLanguage",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAdminSettingsDefaultLanguage")]
    public class SetGAdminSettingsDefaultLanguageCommand : AdminsettingsBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The default language.</para>
        /// </summary>
        [Parameter(HelpMessage = "The default language.",
            Position = 0,
            Mandatory = true,
            ParameterSetName = "word")]
        [ValidateNotNullOrEmpty]
        public LanguageLanguageEnum DefaultLanguage { get; set; }

        /// <summary>
        /// <para type="description">The default language's abbreviation.</para>
        /// </summary>
        [Parameter(HelpMessage = "The default language's abbreviation.",
            Position = 0,
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
                body.DefaultLanguageValue = SetGEmailSettingsLanguageCommand.LookupLanguage(this.DefaultLanguage);
            }
            else
            {
                body.DefaultLanguageValue = SetGEmailSettingsLanguageCommand.LookupLanguage(this.LanguageAbbreviation);
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
    /// <summary>
    /// <para type="synopsis">Retrieve the domain's organization name.</para>
    /// <para type="description">Retrieve the domain's organization name.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAdminSettingsOrganizationName</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAdminSettingsOrganizationName">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsOrganizationName",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAdminSettingsOrganizationName")]
    public class GetGAdminSettingsOrganizationNameCommand : AdminsettingsBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Admin Settings OrganizationName", "Get-GAdminSettingsOrganizationName"))
            {
                WriteObject(organizationName.Get(Domain));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Update the domain's organization name.</para>
    /// <para type="description">Update the domain's organization name.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GAdminSettingsOrganizationName -OrganizationName $SomeOrganizationNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GAdminSettingsOrganizationName">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GAdminSettingsOrganizationName",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAdminSettingsOrganizationName")]
    public class SetGAdminSettingsOrganizationNameCommand : AdminsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The name of the organization.</para>
        /// </summary>
        [Parameter(HelpMessage = "The name of the organization.",
            Position = 0,
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
    /// <summary>
    /// <para type="synopsis">Retrieve a domain's maximum number of users.</para>
    /// <para type="description">Retrieve a domain's maximum number of users.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAdminSettingsMaximumUsers</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAdminSettingsMaximumUsers">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsMaximumUsers",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAdminSettingsMaximumUsers")]
    public class GetGAdminSettingsMaximumUsersCommand : AdminsettingsBase
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
    /// <summary>
    /// <para type="synopsis">Retrieve a domain's current number of users.</para>
    /// <para type="description">Retrieve a domain's current number of users.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAdminSettingsCurrentUsers</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAdminSettingsCurrentUsers">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsCurrentUsers",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAdminSettingsCurrentUsers")]
    public class GetGAdminSettingsCurrentUsersCommand : AdminsettingsBase
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
    /// <summary>
    /// <para type="synopsis">Retrieve a domain's product version.</para>
    /// <para type="description">Retrieve a domain's product version.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAdminSettingsProductVersion</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAdminSettingsProductVersion">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsProductVersion",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAdminSettingsProductVersion")]
    public class GetGAdminSettingsProductVersionCommand : AdminsettingsBase
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
    /// <summary>
    /// <para type="synopsis">Retrieve a customer's PIN.</para>
    /// <para type="description">Retrieve a customer's PIN.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAdminSettingsCustomerPin</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAdminSettingsCustomerPin">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsCustomerPin",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAdminSettingsCustomerPin")]
    public class GetGAdminSettingsCustomerPinCommand : AdminsettingsBase
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
    /// <summary>
    /// <para type="synopsis">Retrieve the domain's creation time.</para>
    /// <para type="description">Retrieve the domain's creation time.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAdminSettingsCreationTime</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAdminSettingsCreationTime">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsCreationTime",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAdminSettingsCreationTime")]
    public class GetGAdminSettingsCreationTimeCommand : AdminsettingsBase
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
    /// <summary>
    /// <para type="synopsis">Retrieve the domain's country code.</para>
    /// <para type="description">Retrieve the domain's country code.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAdminSettingsCountryCode</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAdminSettingsCountryCode">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsCountryCode",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAdminSettingsCountryCode")]
    public class GetGAdminSettingsCountryCodeCommand : AdminsettingsBase
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
    /// <summary>
    /// <para type="synopsis">Retrieve the domain administrator's secondary email address.</para>
    /// <para type="description">Retrieve the domain administrator's secondary email address.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAdminSettingsAdminSecondaryEmail</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAdminSettingsAdminSecondaryEmail">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsAdminSecondaryEmail",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAdminSettingsAdminSecondaryEmail")]
    public class GetGAdminSettingsAdminSecondaryEmailCommand : AdminsettingsBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Admin Settings AdminSecondaryEmail", "Get-GAdminSettingsAdminSecondaryEmail"))
            {
                WriteObject(adminSecondaryEmail.Get(Domain));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Update the domain administrator's secondary email address.</para>
    /// <para type="description">Update the domain administrator's secondary email address.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GAdminSettingsAdminSecondaryEmail -AdminSecondaryEmail $SomeSecondaryEmailString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GAdminSettingsAdminSecondaryEmail">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GAdminSettingAdminSecondaryEmails",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAdminSettingsAdminSecondaryEmail")]
    public class SetGAdminSettingsAdminSecondaryEmailCommand : AdminsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The admin's secondary email.</para>
        /// </summary>
        [Parameter(HelpMessage = "The admin's secondary email.",
            Position = 0,
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

    /// <summary>
    /// <para type="synopsis">Change the domain's logo.</para>
    /// <para type="description">Change the domain's logo. The image file type can be in JPEG, PNG, or a GIF format. The recommended size is 143 x 59 pixels and the file should be smaller than 20Kb. When using custom logos, remember to stay within the Google Terms of Service. Refrain from using the Google logo, Gmail logo, or any other Google logos.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GAdminSettingsCustomLogo -Path $SomeFilePath</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GAdminSettingsCustomLogo">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GAdminSettingsCustomLogo",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAdminSettingsCustomLogo")]
    public class SetGAdminSettingsCustomLogoCommand : AdminsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The path to the new logo file.</para>
        /// </summary>
        [Parameter(HelpMessage = "The path to the new logo file.",
            Position = 0,
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
    /// <summary>
    /// <para type="synopsis">Retrieve the domain's MX record verification status.</para>
    /// <para type="description">Retrieve the domain's MX record verification status.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAdminSettingsMxVerificationRecords</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAdminSettingsMxVerificationRecords">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsMxVerificationRecords",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAdminSettingsMxVerificationRecords")]
    public class GetGAdminSettingsMxVerificationRecordsCommand : AdminsettingsBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Admin Settings MxVerificationRecords", "Get-GAdminSettingsMxVerificationRecords"))
            {
                WriteObject(mxVerificationStatus.Get(Domain));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Confirm and test your domain's MX record configuration.</para>
    /// <para type="description">Confirm and test your domain's MX record configuration. Use this operation to test your MX record edit and to reset the Google status of your MX record configuration.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GAdminSettingsMxVerificationRecords -Verified</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GAdminSettingsMxVerificationRecords">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GAdminSettingsMxVerificationRecords",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAdminSettingsMxVerificationRecords")]
    public class SetGAdminSettingsMxVerificationRecordsCommand : AdminsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">Sets the verified property's value to true.</para>
        /// </summary>
        [Parameter(HelpMessage = "Sets the verified property's value to true.",
            Position = 0,
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
    /// <summary>
    /// <para type="synopsis">Retrieve Single Sign-On settings.</para>
    /// <para type="description">Retrieve Single Sign-On settings.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAdminSettingsSsoSettings</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAdminSettingsSsoSettings">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsSsoSettings",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAdminSettingsSsoSettings")]
    public class GetGAdminSettingsSsoSettingsCommand : AdminsettingsBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Admin Settings SsoSettings", "Get-GAdminSettingsSsoSettings"))
            {
                WriteObject(ssoSettings.Get(Domain));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Update the Single Sign-On settings.</para>
    /// <para type="description">Update the Single Sign-On settings.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GAdminSettingsSsoSettings -SamlSignonUri $SomeSamlSignonUriString -SamlLogoutUri $SomeSamlLogoutUriString
    ///     -UseDomainSpecificIssuer $SomeUseDomainSpecificIssuerBool -ChangePasswordUri $SomeChangePasswordUriString -EnableSSO
    ///     $SomeEnableSSOBool -SsoWhitelist $SomeSsoWhitelistString -UseDomainSpecificIssuer $SomeUseDomainSpecificIssuerBool</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GAdminSettingsSsoSettings">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GAdminSettingsSsoSettings",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAdminSettingsSsoSettings")]
    public class SetGAdminSettingsSsoSettingsCommand : AdminsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The identity provider's URL where Google Apps sends the SAML request for user authentication.</para>
        /// </summary>
        [Parameter(HelpMessage = "The identity provider's URL where Google Apps sends the SAML request for user authentication.",
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SamlSignonUri { get; set; }

        /// <summary>
        /// <para type="description">The address that users will be sent to when they log out of the web application.</para>
        /// </summary>
        [Parameter(HelpMessage = "The address that users will be sent to when they log out of the web application.",
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SamlLogoutUri { get; set; }

        /// <summary>
        /// <para type="description">The address that users will be sent to when they want to change their SSO password for the web application.</para>
        /// </summary>
        [Parameter(HelpMessage = "The address that users will be sent to when they want to change their SSO password for the web application.",
            Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ChangePasswordUri { get; set; }

        /// <summary>
        /// <para type="description">Enable SAML-based SSO for this domain.</para>
        /// </summary>
        [Parameter(HelpMessage = "Enable SAML-based SSO for this domain.",
            Position = 4,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public bool EnableSSO { get; set; }

        /// <summary>
        /// <para type="description">A network mask IP address in Classless Inter-Domain Routing (CIDR) format.</para>
        /// </summary>
        [Parameter(HelpMessage = "A network mask IP address in Classless Inter-Domain Routing (CIDR) format.",
            Position = 5,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SsoWhitelist { get; set; }

        /// <summary>
        /// <para type="description">A domain specific issuer used in the SAML request to the identity provider.</para>
        /// </summary>
        [Parameter(HelpMessage = "A domain specific issuer used in the SAML request to the identity provider.",
            Position = 6,
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
    /// <summary>
    /// <para type="synopsis">Retrieve the Single Sign-On signing key.</para>
    /// <para type="description">Retrieve the Single Sign-On signing key.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAdminSettingsSsoSigningKey</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAdminSettingsSsoSigningKey">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsSsoSigningKey",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAdminSettingsSsoSigningKey")]
    public class GetGAdminSettingsSsoSigningKeyCommand : AdminsettingsBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Admin Settings SsoSigningKey", "Get-GAdminSettingsSsoSigningKey"))
            {
                WriteObject(ssoSigningKey.Get(Domain));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Update the Single Sign-On signing key.</para>
    /// <para type="description">Update the Single Sign-On signing key.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GAdminSettingsSsoSigningKey -SigningKey $SomeSigningKeyString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GAdminSettingsSsoSigningKey">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GAdminSettingsSsoSigningKey",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAdminSettingsSsoSigningKey")]
    public class SetGAdminSettingsSsoSigningKeyCommand : AdminsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">Your Base64-Encoded Public Key.</para>
        /// </summary>
        [Parameter(HelpMessage = "Your Base64-Encoded Public Key.",
            Position = 0,
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
    /// <summary>
    /// <para type="synopsis">Retrieve outbound email gateway settings.</para>
    /// <para type="description">Retrieve outbound email gateway settings.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAdminSettingsEmailGateway</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAdminSettingsEmailGateway">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAdminSettingsEmailGateway",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAdminSettingsEmailGateway")]
    public class GetGAdminSettingsEmailGatewayCommand : AdminsettingsBase
    {
        protected override void ProcessRecord()
        {
            if (ShouldProcess("Admin Settings EmailGateway", "Get-GAdminSettingsEmailGateway"))
            {
                WriteObject(emailGateway.Get(Domain));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Update outbound email gateway settings.</para>
    /// <para type="description">Update outbound email gateway settings.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GAdminSettingsEmailGateway -SmartHost $SomeSmartHostString -SmtpMode SMTP</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GAdminSettingsEmailGateway">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GAdminSettingsEmailGateway",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAdminSettingsEmailGateway")]
    public class SetGAdminSettingsEmailGatewayCommand : AdminsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">Either the IP address or hostname of your SMTP server. Google Apps routes outgoing mail to this server.</para>
        /// </summary>
        [Parameter(HelpMessage = "Either the IP address or hostname of your SMTP server. Google Apps routes outgoing mail to this server.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SmartHost { get; set; }

        /// <summary>
        /// <para type="description">The default value is SMTP. Another value, SMTP_TLS, secures a connection with TLS when delivering the message.</para>
        /// </summary>
        [Parameter(HelpMessage = "The default value is SMTP. Another value, SMTP_TLS, secures a connection with TLS when delivering the message.",
            Position = 0,
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
    /// <summary>
    /// <para type="synopsis">Update the Email Routing Settings.</para>
    /// <para type="description">Update the Email Routing Settings.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Admin Settings API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GAdminSettingsEmailRouting -RouteDestination $SomeRouteDestinationString -RouteRewriteTo $SomeRouteRewriteToBool
    ///     -RouteEnabled $SomeRouteEnabledBool -BounceNotifications $SomeBounceNotificationsBool -AccountHandling allAccounts</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GAdminSettingsEmailRouting">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GAdminSettingsEmailRouting",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAdminSettingsEmailRouting")]
    public class SetGAdminSettingsEmailRoutingCommand : AdminsettingsBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">This destination is the hostname or IP address of the SMTP-In mail server where the email is being routed. The hostname or IP address must resolve for Google.</para>
        /// </summary>
        [Parameter(HelpMessage = "This destination is the hostname or IP address of the SMTP-In mail server where the email is being routed. The hostname or IP address must resolve for Google.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string RouteDestination { get; set; }

        /// <summary>
        /// <para type="description">If true, the message's SMTP envelope's to: field is changed to the destination hostname (user@destination's hostname), and the message is delivered to this user address on the destination mail server. If false, the email is delivered to the original message's to: email address (user@original hostname) on the destination mail server. This is similar to the Admin console's 'Change SMTP envelope' setting.</para>
        /// </summary>
        [Parameter(HelpMessage = "If true, the message's SMTP envelope's to: field is changed to the destination hostname (user@destination's hostname), and the message is delivered to this user address on the destination mail server. If false, the email is delivered to the original message's to: email address (user@original hostname) on the destination mail server. This is similar to the Admin console's 'Change SMTP envelope' setting.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool RouteRewriteTo { get; set; }

        /// <summary>
        /// <para type="description">If true, the email routing functionality is enabled. If false, the functionality is disabled.</para>
        /// </summary>
        [Parameter(HelpMessage = "If true, the email routing functionality is enabled. If false, the functionality is disabled.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool RouteEnabled { get; set; }

        /// <summary>
        /// <para type="description">If true, Google Apps is enabled to send bounce notifications to the sender when a delivery fails.</para>
        /// </summary>
        [Parameter(HelpMessage = "If true, Google Apps is enabled to send bounce notifications to the sender when a delivery fails.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool BounceNotifications { get; set; }

        /// <summary>
        /// <para type="description">This setting determines how different types of users in the domain are affected by email routing: * allAccounts -- Deliver all email to this destination. * provisionedAccounts -- Deliver mail to this destination if the user exists in Google Apps. * unknownAccounts -- Deliver mail to this destination if the user does not exist in Google Apps. This is similar to the Admin console's 'Delivery email for' setting.</para>
        /// </summary>
        [Parameter(HelpMessage = "This setting determines how different types of users in the domain are affected by email routing: * allAccounts -- Deliver all email to this destination. * provisionedAccounts -- Deliver mail to this destination if the user exists in Google Apps. * unknownAccounts -- Deliver mail to this destination if the user does not exist in Google Apps. This is similar to the Admin console's 'Delivery email for' setting.",
            Position = 0,
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