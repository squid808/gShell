namespace gShell.Cmdlets.Adminsettings{

    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using adminsettings_v1 = Google.Apis.admin.Adminsettings.adminsettings_v1;
    using Data = Google.Apis.admin.Adminsettings.adminsettings_v1.Data;

    using gShell.dotNet.Utilities;
    using gShell.dotNet.Utilities.OAuth2;
    using gAdminsettings = gShell.dotNet.Adminsettings;

    public abstract class AdminsettingsBase : OAuth2CmdletBase
    {

        #region Properties
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        protected static gAdminsettings mainBase { get; set; }

        public AdminSecondaryEmail adminSecondaryEmail { get; set; }
        public CountryCode countryCode { get; set; }
        public CreationTime creationTime { get; set; }
        public CurrentUsers currentUsers { get; set; }
        public CustomLogo customLogo { get; set; }
        public CustomerPin customerPin { get; set; }
        public DefaultLanguage defaultLanguage { get; set; }
        public EmailGateway emailGateway { get; set; }
        public EmailRouting emailRouting { get; set; }
        public MaximumUsers maximumUsers { get; set; }
        public MxVerificationStatus mxVerificationStatus { get; set; }
        public OrganizationName organizationName { get; set; }
        public ProductVersion productVersion { get; set; }
        public SsoSettings ssoSettings { get; set; }
        public SsoSigningKey ssoSigningKey { get; set; }

        protected override string apiNameAndVersion { get { return mainBase.apiNameAndVersion; } }

        HashSet<string> Scopes = new HashSet<string> {
            "https://apps-apis.google.com/a/feeds/domain/",
        };

        #endregion

        #region Constructors
        public AdminsettingsBase()
        {
            mainBase = new gAdminsettings();

            adminSecondaryEmail = new AdminSecondaryEmail();
            countryCode = new CountryCode();
            creationTime = new CreationTime();
            currentUsers = new CurrentUsers();
            customLogo = new CustomLogo();
            customerPin = new CustomerPin();
            defaultLanguage = new DefaultLanguage();
            emailGateway = new EmailGateway();
            emailRouting = new EmailRouting();
            maximumUsers = new MaximumUsers();
            mxVerificationStatus = new MxVerificationStatus();
            organizationName = new OrganizationName();
            productVersion = new ProductVersion();
            ssoSettings = new SsoSettings();
            ssoSigningKey = new SsoSigningKey();
        }
        #endregion

        #region PowerShell Methods
        protected override void BeginProcessing()
        {
            var secrets = CheckForClientSecrets();
            if (secrets != null)
            {
                IEnumerable<string> scopes = EnsureScopesExist(Domain, Scopes);
                Domain = mainBase.BuildService(Authenticate(scopes, secrets, Domain)).domain;

                GWriteProgress = new gWriteProgress(WriteProgress);
            }
            else
            {
                WriteError(new ErrorRecord(null, (new Exception(
                    "Client Secrets must be set before running cmdlets. Run 'Get-Help "
                    + "Set-gShellClientSecrets -online' for more information."))));
            }
        }
        #endregion

        #region Authentication & Processing
        protected override AuthenticatedUserInfo Authenticate(IEnumerable<string> Scopes, ClientSecrets Secrets, string Domain = null)
        {
            return mainBase.Authenticate(apiNameAndVersion, Scopes, Secrets, Domain);
        }
        #endregion

        #region Wrapped Methods



        #region AdminSecondaryEmail

        public class AdminSecondaryEmail
        {




            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.AdminSecondaryEmail Get (
            string

             domain)
            {

                return mainBase.adminSecondaryEmail.Get(
                domain);
            }


            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.AdminSecondaryEmail Update (
            Google.Apis.admin.Adminsettings.adminsettings_v1.Data.AdminSecondaryEmail body, string

             domain)
            {

                return mainBase.adminSecondaryEmail.Update(
                body, domain);
            }
        }

        #endregion



        #region CountryCode

        public class CountryCode
        {




            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.CountryCode Get (
            string

             domain)
            {

                return mainBase.countryCode.Get(
                domain);
            }
        }

        #endregion



        #region CreationTime

        public class CreationTime
        {




            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.CreationTime Get (
            string

             domain)
            {

                return mainBase.creationTime.Get(
                domain);
            }
        }

        #endregion



        #region CurrentUsers

        public class CurrentUsers
        {




            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.CurrentNumberOfUsers Get (
            string

             domain)
            {

                return mainBase.currentUsers.Get(
                domain);
            }
        }

        #endregion



        #region CustomLogo

        public class CustomLogo
        {




            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.CustomLogo Update (
            Google.Apis.admin.Adminsettings.adminsettings_v1.Data.CustomLogo body, string

             domain)
            {

                return mainBase.customLogo.Update(
                body, domain);
            }
        }

        #endregion



        #region CustomerPin

        public class CustomerPin
        {




            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.CustomerPin Get (
            string

             domain)
            {

                return mainBase.customerPin.Get(
                domain);
            }
        }

        #endregion



        #region DefaultLanguage

        public class DefaultLanguage
        {




            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.DefaultLanguage Get (
            string

             domain)
            {

                return mainBase.defaultLanguage.Get(
                domain);
            }


            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.DefaultLanguage Update (
            Google.Apis.admin.Adminsettings.adminsettings_v1.Data.DefaultLanguage body, string

             domain)
            {

                return mainBase.defaultLanguage.Update(
                body, domain);
            }
        }

        #endregion



        #region EmailGateway

        public class EmailGateway
        {




            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.Gateway Get (
            string

             domain)
            {

                return mainBase.emailGateway.Get(
                domain);
            }


            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.Gateway Update (
            Google.Apis.admin.Adminsettings.adminsettings_v1.Data.Gateway body, string

             domain)
            {

                return mainBase.emailGateway.Update(
                body, domain);
            }
        }

        #endregion



        #region EmailRouting

        public class EmailRouting
        {




            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.Routing Update (
            Google.Apis.admin.Adminsettings.adminsettings_v1.Data.Routing body, string

             domain)
            {

                return mainBase.emailRouting.Update(
                body, domain);
            }
        }

        #endregion



        #region MaximumUsers

        public class MaximumUsers
        {




            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.MaximumNumberOfUsers Get (
            string

             domain)
            {

                return mainBase.maximumUsers.Get(
                domain);
            }
        }

        #endregion



        #region MxVerificationStatus

        public class MxVerificationStatus
        {




            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.MXVerificationStatus Get (
            string

             domain)
            {

                return mainBase.mxVerificationStatus.Get(
                domain);
            }


            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.MXVerificationStatus Update (
            Google.Apis.admin.Adminsettings.adminsettings_v1.Data.MXVerificationStatus body, string

             domain)
            {

                return mainBase.mxVerificationStatus.Update(
                body, domain);
            }
        }

        #endregion



        #region OrganizationName

        public class OrganizationName
        {




            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.OrganizationName Get (
            string

             domain)
            {

                return mainBase.organizationName.Get(
                domain);
            }


            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.OrganizationName Update (
            Google.Apis.admin.Adminsettings.adminsettings_v1.Data.OrganizationName body, string

             domain)
            {

                return mainBase.organizationName.Update(
                body, domain);
            }
        }

        #endregion



        #region ProductVersion

        public class ProductVersion
        {




            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.Edition Get (
            string

             domain)
            {

                return mainBase.productVersion.Get(
                domain);
            }
        }

        #endregion



        #region SsoSettings

        public class SsoSettings
        {




            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.SsoSettings Get (
            string

             domain)
            {

                return mainBase.ssoSettings.Get(
                domain);
            }


            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.SsoSettings Update (
            Google.Apis.admin.Adminsettings.adminsettings_v1.Data.SsoSettings body, string

             domain)
            {

                return mainBase.ssoSettings.Update(
                body, domain);
            }
        }

        #endregion



        #region SsoSigningKey

        public class SsoSigningKey
        {




            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.SsoSigningKey Get (
            string

             domain)
            {

                return mainBase.ssoSigningKey.Get(
                domain);
            }


            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.SsoSigningKey Update (
            Google.Apis.admin.Adminsettings.adminsettings_v1.Data.SsoSigningKey body, string

             domain)
            {

                return mainBase.ssoSigningKey.Update(
                body, domain);
            }
        }

        #endregion

        #endregion

    }
}



namespace gShell.dotNet
{
    using System;
    using System.Collections.Generic;

    using gShell.dotNet;
    using gShell.dotNet.Utilities.OAuth2;

    using adminsettings_v1 = Google.Apis.admin.Adminsettings.adminsettings_v1;
    using Data = Google.Apis.admin.Adminsettings.adminsettings_v1.Data;

    public class Adminsettings : ServiceWrapper<adminsettings_v1.AdminsettingsService>
    {

        protected override bool worksWithGmail { get { return false; } }

        protected override adminsettings_v1.AdminsettingsService CreateNewService(string domain)
        {
            return new adminsettings_v1.AdminsettingsService(OAuth2Base.GetGdataInitializer(domain));
        }

        public override string apiNameAndVersion { get { return "admin:adminsettings_v1"; } }

        public AdminSecondaryEmail adminSecondaryEmail{ get; set; }
        public CountryCode countryCode{ get; set; }
        public CreationTime creationTime{ get; set; }
        public CurrentUsers currentUsers{ get; set; }
        public CustomLogo customLogo{ get; set; }
        public CustomerPin customerPin{ get; set; }
        public DefaultLanguage defaultLanguage{ get; set; }
        public EmailGateway emailGateway{ get; set; }
        public EmailRouting emailRouting{ get; set; }
        public MaximumUsers maximumUsers{ get; set; }
        public MxVerificationStatus mxVerificationStatus{ get; set; }
        public OrganizationName organizationName{ get; set; }
        public ProductVersion productVersion{ get; set; }
        public SsoSettings ssoSettings{ get; set; }
        public SsoSigningKey ssoSigningKey{ get; set; }

        public Adminsettings() //public Reports()
        {

            adminSecondaryEmail = new AdminSecondaryEmail();
            countryCode = new CountryCode();
            creationTime = new CreationTime();
            currentUsers = new CurrentUsers();
            customLogo = new CustomLogo();
            customerPin = new CustomerPin();
            defaultLanguage = new DefaultLanguage();
            emailGateway = new EmailGateway();
            emailRouting = new EmailRouting();
            maximumUsers = new MaximumUsers();
            mxVerificationStatus = new MxVerificationStatus();
            organizationName = new OrganizationName();
            productVersion = new ProductVersion();
            ssoSettings = new SsoSettings();
            ssoSigningKey = new SsoSigningKey();
        }




        public class AdminSecondaryEmail
        {





            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.AdminSecondaryEmail Get
            (string domain)
            {
                return GetService().AdminSecondaryEmail.Get(    domain).Execute();
            }

            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.AdminSecondaryEmail Update
            (Google.Apis.admin.Adminsettings.adminsettings_v1.Data.AdminSecondaryEmail body, string domain)
            {
                return GetService().AdminSecondaryEmail.Update(    body, domain).Execute();
            }

        }


        public class CountryCode
        {





            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.CountryCode Get
            (string domain)
            {
                return GetService().CountryCode.Get(    domain).Execute();
            }

        }


        public class CreationTime
        {





            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.CreationTime Get
            (string domain)
            {
                return GetService().CreationTime.Get(    domain).Execute();
            }

        }


        public class CurrentUsers
        {





            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.CurrentNumberOfUsers Get
            (string domain)
            {
                return GetService().CurrentUsers.Get(    domain).Execute();
            }

        }


        public class CustomLogo
        {





            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.CustomLogo Update
            (Google.Apis.admin.Adminsettings.adminsettings_v1.Data.CustomLogo body, string domain)
            {
                return GetService().CustomLogo.Update(    body, domain).Execute();
            }

        }


        public class CustomerPin
        {





            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.CustomerPin Get
            (string domain)
            {
                return GetService().CustomerPin.Get(    domain).Execute();
            }

        }


        public class DefaultLanguage
        {





            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.DefaultLanguage Get
            (string domain)
            {
                return GetService().DefaultLanguage.Get(    domain).Execute();
            }

            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.DefaultLanguage Update
            (Google.Apis.admin.Adminsettings.adminsettings_v1.Data.DefaultLanguage body, string domain)
            {
                return GetService().DefaultLanguage.Update(    body, domain).Execute();
            }

        }


        public class EmailGateway
        {





            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.Gateway Get
            (string domain)
            {
                return GetService().EmailGateway.Get(    domain).Execute();
            }

            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.Gateway Update
            (Google.Apis.admin.Adminsettings.adminsettings_v1.Data.Gateway body, string domain)
            {
                return GetService().EmailGateway.Update(    body, domain).Execute();
            }

        }


        public class EmailRouting
        {





            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.Routing Update
            (Google.Apis.admin.Adminsettings.adminsettings_v1.Data.Routing body, string domain)
            {
                return GetService().EmailRouting.Update(    body, domain).Execute();
            }

        }


        public class MaximumUsers
        {





            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.MaximumNumberOfUsers Get
            (string domain)
            {
                return GetService().MaximumUsers.Get(    domain).Execute();
            }

        }


        public class MxVerificationStatus
        {





            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.MXVerificationStatus Get
            (string domain)
            {
                return GetService().MxVerificationStatus.Get(    domain).Execute();
            }

            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.MXVerificationStatus Update
            (Google.Apis.admin.Adminsettings.adminsettings_v1.Data.MXVerificationStatus body, string domain)
            {
                return GetService().MxVerificationStatus.Update(    body, domain).Execute();
            }

        }


        public class OrganizationName
        {





            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.OrganizationName Get
            (string domain)
            {
                return GetService().OrganizationName.Get(    domain).Execute();
            }

            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.OrganizationName Update
            (Google.Apis.admin.Adminsettings.adminsettings_v1.Data.OrganizationName body, string domain)
            {
                return GetService().OrganizationName.Update(    body, domain).Execute();
            }

        }


        public class ProductVersion
        {





            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.Edition Get
            (string domain)
            {
                return GetService().ProductVersion.Get(    domain).Execute();
            }

        }


        public class SsoSettings
        {





            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.SsoSettings Get
            (string domain)
            {
                return GetService().SsoSettings.Get(    domain).Execute();
            }

            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.SsoSettings Update
            (Google.Apis.admin.Adminsettings.adminsettings_v1.Data.SsoSettings body, string domain)
            {
                return GetService().SsoSettings.Update(    body, domain).Execute();
            }

        }


        public class SsoSigningKey
        {





            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.SsoSigningKey Get
            (string domain)
            {
                return GetService().SsoSigningKey.Get(    domain).Execute();
            }

            public Google.Apis.admin.Adminsettings.adminsettings_v1.Data.SsoSigningKey Update
            (Google.Apis.admin.Adminsettings.adminsettings_v1.Data.SsoSigningKey body, string domain)
            {
                return GetService().SsoSigningKey.Update(    body, domain).Execute();
            }

        }

    }
}