namespace gShell.Cmdlets.Groupssettings{

    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using v1 = Google.Apis.Groupssettings.v1;
    using Data = Google.Apis.Groupssettings.v1.Data;

    using gShell.dotNet.Utilities;
    using gShell.dotNet.Utilities.OAuth2;
    using gGroupssettings = gShell.dotNet.Groupssettings;

    public abstract class GroupssettingsBase : OAuth2CmdletBase
    {

        #region Properties
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        protected static gGroupssettings mainBase { get; set; }

        public Groups groups { get; set; }

        protected override string apiNameAndVersion { get { return mainBase.apiNameAndVersion; } }

        protected static string gShellServiceAccount { get; set; }
        #endregion

        #region Constructors
        public GroupssettingsBase()
        {
            mainBase = new gGroupssettings();

            groups = new Groups();
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



        #region Groups

        public class Groups
        {




            public Google.Apis.Groupssettings.v1.Data.Groups Get (string

             groupUniqueId)
            {

                return mainBase.groups.Get(groupUniqueId, gShellServiceAccount);
            }


            public Google.Apis.Groupssettings.v1.Data.Groups Patch (Google.Apis.Groupssettings.v1.Data.Groups body, string

             groupUniqueId)
            {

                return mainBase.groups.Patch(body, groupUniqueId, gShellServiceAccount);
            }


            public Google.Apis.Groupssettings.v1.Data.Groups Update (Google.Apis.Groupssettings.v1.Data.Groups body, string

             groupUniqueId)
            {

                return mainBase.groups.Update(body, groupUniqueId, gShellServiceAccount);
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

    using v1 = Google.Apis.Groupssettings.v1;
    using Data = Google.Apis.Groupssettings.v1.Data;

    public class Groupssettings : ServiceWrapper<v1.GroupssettingsService>
    {

        protected override bool worksWithGmail { get { return true; } }

        protected override v1.GroupssettingsService CreateNewService(string domain, AuthenticatedUserInfo authInfo, string gShellServiceAccount = null)
        {
            return new v1.GroupssettingsService(OAuth2Base.GetInitializer(domain, authInfo, gShellServiceAccount));
        }

        public override string apiNameAndVersion { get { return "groupssettings:v1"; } }

        public Groups groups{ get; set; }

        public Groupssettings() //public Reports()
        {

            groups = new Groups();
        }




        public class Groups
        {





            public Google.Apis.Groupssettings.v1.Data.Groups Get (string

             groupUniqueId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Groups.Get(groupUniqueId).Execute();
            }

            public Google.Apis.Groupssettings.v1.Data.Groups Patch (Google.Apis.Groupssettings.v1.Data.Groups body, string

             groupUniqueId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Groups.Patch(body, groupUniqueId).Execute();
            }

            public Google.Apis.Groupssettings.v1.Data.Groups Update (Google.Apis.Groupssettings.v1.Data.Groups body, string

             groupUniqueId, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Groups.Update(body, groupUniqueId).Execute();
            }

        }

    }
}