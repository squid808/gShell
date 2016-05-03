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

        protected static string gShellServiceAccount { get; set; }
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
                Domain = mainBase.BuildService(Authenticate(scopes, secrets, Domain), gShellServiceAccount).domain;

                GWriteProgress = new gWriteProgress(WriteProgress);
            }
            else
            {
                WriteError(new ErrorRecord(null, (new Exception(
                    "Client Secrets must be set before running cmdlets. Run 'Get-Help "
                    + "Set-gShellClientSecrets -online' for more information."))));
            }
        }

        protected override void EndProcessing()
        {
            gShellServiceAccount = string.Empty;
        }

        protected override void StopProcessing()
        {
            gShellServiceAccount = string.Empty;
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




            public void Insert (string
             groupId, System.IO.Stream stream, string contentType)
            {

                mainBase.archive.Insert(groupId, stream, contentType, gShellServiceAccount);
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

        protected override v1.GroupsMigrationService CreateNewService(string domain, AuthenticatedUserInfo authInfo, string gShellServiceAccount = null)
        {
            return new v1.GroupsMigrationService(OAuth2Base.GetInitializer(domain, authInfo, gShellServiceAccount));
        }

        public override string apiNameAndVersion { get { return "groupsmigration:v1"; } }

        public Archive archive{ get; set; }

        public GroupsMigration() //public Reports()
        {

            archive = new Archive();
        }




        public class Archive
        {





            public void Insert
            (string groupId, System.IO.Stream stream, string contentType, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).Archive.Insert(groupId, stream, contentType).Upload();
            }

        }

    }
}