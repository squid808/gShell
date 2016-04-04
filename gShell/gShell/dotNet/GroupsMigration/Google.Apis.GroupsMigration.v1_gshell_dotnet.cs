namespace gShell.Cmdlets.GroupsMigration{

    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using v1 = Google.Apis.GroupsMigration.v1;
    using Data = Google.Apis.GroupsMigration.v1.Data;

    using gShell.dotNet.Utilities;
    using gShell.dotNet.Utilities.OAuth2;
    using gGroupsMigration = gShell.dotNet.GroupsMigration;

    public abstract class GroupsMigrationBase : OAuth2CmdletBase
    {

        #region Properties
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        protected static gGroupsMigration mainBase { get; set; }

        public Archive archive { get; set; }

        protected override string apiNameAndVersion { get { return mainBase.apiNameAndVersion; } }
        #endregion

        #region Constructors
        public GroupsMigrationBase()
        {
            mainBase = new gGroupsMigration();

            archive = new Archive();
        }
        #endregion

        #region PowerShell Methods
        protected override void BeginProcessing()
        {
            var secrets = CheckForClientSecrets();
            if (secrets != null)
            {
                IEnumerable<string> scopes = EnsureScopesExist(Domain);
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



        #region Archive

        public class Archive
        {




            public Google.Apis.GroupsMigration.v1.Data.Groups Insert (
            string

             groupId)
            {

                return mainBase.archive.Insert(
                groupId);
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

    using v1 = Google.Apis.GroupsMigration.v1;
    using Data = Google.Apis.GroupsMigration.v1.Data;

    public class GroupsMigration : ServiceWrapper<v1.GroupsMigrationService>
    {

        protected override bool worksWithGmail { get { return true; } }

        protected override v1.GroupsMigrationService CreateNewService(string domain)
        {
            return new v1.GroupsMigrationService(OAuth2Base.GetInitializer(domain));
        }

        public override string apiNameAndVersion { get { return "groupsmigration:v1"; } }

        public Archive archive{ get; set; }

        public GroupsMigration() //public Reports()
        {

            archive = new Archive();
        }




        public class Archive
        {





            public Google.Apis.GroupsMigration.v1.Data.Groups Insert
            (string groupId)
            {
                return GetService().Archive.Insert(    groupId).Execute();
            }

        }

    }
}