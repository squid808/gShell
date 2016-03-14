namespace gShell.Cmdlets.Emailsettings{

    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using emailsettings_v1 = Google.Apis.admin.Emailsettings.emailsettings_v1;
    using Data = Google.Apis.admin.Emailsettings.emailsettings_v1.Data;

    using gShell.dotNet.Utilities;
    using gShell.dotNet.Utilities.OAuth2;
    using gEmailsettings = gShell.dotNet.Emailsettings;

    public abstract class EmailsettingsBase : OAuth2CmdletBase
    {

        #region Properties
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        protected static gEmailsettings mainBase { get; set; }

        public Labels labels { get; set; }

        protected override string apiNameAndVersion { get { return mainBase.apiNameAndVersion; } }

        protected HashSet<string> forcedScopes = new HashSet<string>(){
            "https://apps-apis.google.com/a/feeds/emailsettings/2.0/"
        };
        #endregion

        #region Constructors
        public EmailsettingsBase()
        {
            mainBase = new gEmailsettings();

            labels = new Labels();
        }
        #endregion

        #region PowerShell Methods
        protected override void BeginProcessing()
        {
            var secrets = CheckForClientSecrets();
            if (secrets != null)
            {
                IEnumerable<string> scopes = EnsureScopesExist(Domain, forcedScopes);
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



        #region Labels

        public class Labels
        {




            public void Delete (
            string

             domain, string

             labelName, string

             userKey)
            {

                mainBase.labels.Delete(
                domain, labelName, userKey);
            }


            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Labels Get (
            string

             domain, string

             userKey)
            {

                return mainBase.labels.Get(
                domain, userKey);
            }


            public void Insert (
            string

             domain, string

             userKey)
            {

                mainBase.labels.Insert(
                domain, userKey);
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

    using emailsettings_v1 = Google.Apis.admin.Emailsettings.emailsettings_v1;
    using Data = Google.Apis.admin.Emailsettings.emailsettings_v1.Data;

    public class Emailsettings : ServiceWrapper<emailsettings_v1.EmailsettingsService>
    {

        protected override bool worksWithGmail { get { return false; } }

        protected override emailsettings_v1.EmailsettingsService CreateNewService(string domain)
        {
            return new emailsettings_v1.EmailsettingsService(OAuth2Base.GetInitializer(domain));
        }

        public override string apiNameAndVersion { get { return "admin:emailsettings_v1"; } }

        public Labels labels{ get; set; }

        public Emailsettings() //public Reports()
        {

            labels = new Labels();
        }




        public class Labels
        {





            public void Delete
            (string domain, string labelName, string userKey)
            {
                GetService().Labels.Delete(    domain, labelName, userKey).Execute();
            }

            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Labels Get
            (string domain, string userKey)
            {
                return GetService().Labels.Get(    domain, userKey).Execute();
            }

            public void Insert
            (string domain, string userKey)
            {
                GetService().Labels.Insert(    domain, userKey).Execute();
            }

        }

    }
}