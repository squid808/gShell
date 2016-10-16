using gShell.Cmdlets.Utilities.OAuth2;

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

    public abstract class SharedcontactsBase : AuthenticatedCmdletBase
    {

        #region Properties

        protected static gSharedcontacts mainBase { get; set; }

        public Contact contact { get; set; }
        public Photo photo { get; set; }

        HashSet<string> Scopes = new HashSet<string> {
            "http://www.google.com/m8/feeds/contacts/",
        };

        /// <summary>
        /// Required to be able to store and retrieve the mainBase from the ServiceWrapperDictionary
        /// </summary>
        protected override Type mainBaseType { get { return typeof(gSharedcontacts); } }

        #endregion

        #region Constructors
        public SharedcontactsBase()
        {
            mainBase = new gSharedcontacts();

            ServiceWrapperDictionary[mainBaseType] = mainBase;

            contact = new Contact();
            photo = new Photo();
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

    public class Sharedcontacts : ServiceWrapper<sharedcontacts_v3.SharedcontactsService>, IServiceWrapper<Google.Apis.Services.IClientService>
    {

        protected override bool worksWithGmail { get { return false; } }

        protected override sharedcontacts_v3.SharedcontactsService CreateNewService(string domain, AuthenticatedUserInfo authInfo, string gShellServiceAccount = null)
        {
            return new sharedcontacts_v3.SharedcontactsService(OAuth2Base.GetGdataInitializer(domain, authInfo));
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
                public int? MaxResults = null;
                public     System.Nullable<int>     startIndex = null; //test
                public     string     updatedMin = null; //test
                public     string     orderby = null; //test
                public     string     showdeleted = null; //test
                public     string     sortorder = null; //test
            }


            public void Delete (string

             domain, string

             id, string

             version)
            {
                GetService().Contact.Delete(domain, id, version).Execute();
            }

            public Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data.Contact Get (string

             domain, string

             id)
            {
                return GetService().Contact.Get(domain, id).Execute();
            }

            public Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data.Contact Insert (Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data.Contact body, string

             domain)
            {
                return GetService().Contact.Insert(body, domain).Execute();
            }

            public Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data.Contacts List (string

             domain, ContactListProperties properties = null)
            {
                return GetService().Contact.List(domain).Execute();
            }

            public Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data.Contact Update (Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data.Contact body, string

             domain, string

             id, string

             version)
            {
                return GetService().Contact.Update(body, domain, id, version).Execute();
            }

        }


        public class Photo
        {





            public Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data.Photo Get (string

             domain, string

             id)
            {
                return GetService().Photo.Get(domain, id).Execute();
            }

        }

    }
}