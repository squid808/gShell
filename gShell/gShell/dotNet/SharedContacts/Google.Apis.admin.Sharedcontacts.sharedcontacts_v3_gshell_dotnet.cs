namespace gShell.Cmdlets.Sharedcontacts{

    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using sharedcontacts_v3 = Google.Apis.admin.Sharedcontacts.sharedcontacts_v3;
    using Data = Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data;

    using gShell.dotNet.Utilities;
    using gShell.dotNet.Utilities.OAuth2;
    using gSharedcontacts = gShell.dotNet.Sharedcontacts;

    public abstract class SharedcontactsBase : OAuth2CmdletBase
    {

        #region Properties
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        protected static gSharedcontacts mainBase { get; set; }

        public Contact contact { get; set; }
        public Photo photo { get; set; }

        protected override string apiNameAndVersion { get { return mainBase.apiNameAndVersion; } }

        HashSet<string> Scopes = new HashSet<string> {
            "http://www.google.com/m8/feeds/contacts/",
        };

        #endregion

        #region Constructors
        public SharedcontactsBase()
        {
            mainBase = new gSharedcontacts();

            contact = new Contact();
            photo = new Photo();
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



        #region Contact

        public class Contact
        {




            public void Delete (string

             domain, string

             id, string

             version)
            {

                mainBase.contact.Delete(domain, id, version);
            }


            public Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data.Contact Get (string

             domain, string

             id)
            {

                return mainBase.contact.Get(domain, id);
            }


            public Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data.Contact Insert (Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data.Contact body, string

             domain)
            {

                return mainBase.contact.Insert(body, domain);
            }


            public Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data.Contacts List (string

             domain, gSharedcontacts.Contact.ContactListProperties properties = null)
            {

                properties = (properties != null) ? properties : new gSharedcontacts.Contact.ContactListProperties();

                return mainBase.contact.List(domain, properties);
            }


            public Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data.Contact Update (Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data.Contact body, string

             domain, string

             id, string

             version)
            {

                return mainBase.contact.Update(body, domain, id, version);
            }
        }

        #endregion



        #region Photo

        public class Photo
        {




            public Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data.Photo Get (string

             domain, string

             id)
            {

                return mainBase.photo.Get(domain, id);
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

    using sharedcontacts_v3 = Google.Apis.admin.Sharedcontacts.sharedcontacts_v3;
    using Data = Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data;

    public class Sharedcontacts : ServiceWrapper<sharedcontacts_v3.SharedcontactsService>
    {

        protected override bool worksWithGmail { get { return false; } }

        protected override sharedcontacts_v3.SharedcontactsService CreateNewService(string domain)
        {
            return new sharedcontacts_v3.SharedcontactsService(OAuth2Base.GetGdataInitializer(domain));
        }

        public override string apiNameAndVersion { get { return "admin:sharedcontacts_v3"; } }

        public Contact contact{ get; set; }
        public Photo photo{ get; set; }

        public Sharedcontacts() //public Reports()
        {

            contact = new Contact();
            photo = new Photo();
        }




        public class Contact
        {



            public class ContactListProperties
            {
                public int maxResults = 0;
                public     System.Nullable<int>     startIndex = null; //test
                public     string     updatedMin = null; //test
                public     string     orderby = null; //test
                public     string     showdeleted = null; //test
                public     string     sortorder = null; //test
            }


            public void Delete
            (string domain, string id, string version)
            {
                GetService().Contact.Delete(domain, id, version).Execute();
            }

            public Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data.Contact Get
            (string domain, string id)
            {
                return GetService().Contact.Get(domain, id).Execute();
            }

            public Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data.Contact Insert
            (Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data.Contact body, string domain)
            {
                return GetService().Contact.Insert(body, domain).Execute();
            }

            public Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data.Contacts List
            (string domain, ContactListProperties properties = null)
            {
                return GetService().Contact.List(domain).Execute();
            }

            public Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data.Contact Update
            (Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data.Contact body, string domain, string id, string version)
            {
                return GetService().Contact.Update(body, domain, id, version).Execute();
            }

        }


        public class Photo
        {





            public Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data.Photo Get
            (string domain, string id)
            {
                return GetService().Photo.Get(domain, id).Execute();
            }

        }

    }
}