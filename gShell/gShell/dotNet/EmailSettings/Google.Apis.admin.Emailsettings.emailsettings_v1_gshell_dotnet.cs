using gShell.Cmdlets.Utilities.OAuth2;

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

    public abstract class EmailsettingsBase : AuthenticatedCmdletBase
    {

        #region Properties

        protected static gEmailsettings mainBase { get; set; }

        public Delegation delegation { get; set; }
        public Filters filters { get; set; }
        public Forwarding forwarding { get; set; }
        public General general { get; set; }
        public Imap imap { get; set; }
        public Labels labels { get; set; }
        public Language language { get; set; }
        public Pop pop { get; set; }
        public SendasAliases sendasAliases { get; set; }
        public Signature signature { get; set; }
        public VacationResponder vacationResponder { get; set; }
        public WebClip webClip { get; set; }

        HashSet<string> Scopes = new HashSet<string> {
            "https://apps-apis.google.com/a/feeds/emailsettings/2.0/",
        };

        /// <summary>
        /// Required to be able to store and retrieve the mainBase from the ServiceWrapperDictionary
        /// </summary>
        protected override Type mainBaseType { get { return typeof(gEmailsettings); } }

        #endregion

        #region Constructors
        public EmailsettingsBase()
        {
            mainBase = new gEmailsettings();

            ServiceWrapperDictionary[mainBaseType] = mainBase;

            delegation = new Delegation();
            filters = new Filters();
            forwarding = new Forwarding();
            general = new General();
            imap = new Imap();
            labels = new Labels();
            language = new Language();
            pop = new Pop();
            sendasAliases = new SendasAliases();
            signature = new Signature();
            vacationResponder = new VacationResponder();
            webClip = new WebClip();
        }
        #endregion

        #region Wrapped Methods



        #region Delegation

        public class Delegation
        {






            public void Delete (string

             domain, string

             userKey, string

             delegateEmail)
            {

                mainBase.delegation.Delete(domain, userKey, delegateEmail);
            }





            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Delegates Get (string

             domain, string

             userKey)
            {

                return mainBase.delegation.Get(domain, userKey);
            }





            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Delegate Insert (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Delegate body, string

             domain, string

             userKey)
            {

                return mainBase.delegation.Insert(body, domain, userKey);
            }


        }
        #endregion



        #region Filters

        public class Filters
        {






            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Filter Insert (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Filter body, string

             domain, string

             userKey)
            {

                return mainBase.filters.Insert(body, domain, userKey);
            }


        }
        #endregion



        #region Forwarding

        public class Forwarding
        {






            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Forwarding Get (string

             domain, string

             userKey)
            {

                return mainBase.forwarding.Get(domain, userKey);
            }





            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Forwarding Update (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Forwarding body, string

             domain, string

             userKey)
            {

                return mainBase.forwarding.Update(body, domain, userKey);
            }


        }
        #endregion



        #region General

        public class General
        {






            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.General Update (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.General body, string

             domain, string

             userKey)
            {

                return mainBase.general.Update(body, domain, userKey);
            }


        }
        #endregion



        #region Imap

        public class Imap
        {






            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Imap Get (string

             domain, string

             userKey)
            {

                return mainBase.imap.Get(domain, userKey);
            }





            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Imap Update (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Imap body, string

             domain, string

             userKey)
            {

                return mainBase.imap.Update(body, domain, userKey);
            }


        }
        #endregion



        #region Labels

        public class Labels
        {






            public void Delete (string

             domain, string

             userKey, string

             labelName)
            {

                mainBase.labels.Delete(domain, userKey, labelName);
            }





            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Labels Get (string

             domain, string

             userKey)
            {

                return mainBase.labels.Get(domain, userKey);
            }





            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Label Insert (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Label body, string

             domain, string

             userKey)
            {

                return mainBase.labels.Insert(body, domain, userKey);
            }


        }
        #endregion



        #region Language

        public class Language
        {






            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Language Update (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Language body, string

             domain, string

             userKey)
            {

                return mainBase.language.Update(body, domain, userKey);
            }


        }
        #endregion



        #region Pop

        public class Pop
        {






            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Pop Get (string

             domain, string

             userKey)
            {

                return mainBase.pop.Get(domain, userKey);
            }





            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Pop Update (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Pop body, string

             domain, string

             userKey)
            {

                return mainBase.pop.Update(body, domain, userKey);
            }


        }
        #endregion



        #region SendasAliases

        public class SendasAliases
        {






            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.SendAsAliases Get (string

             domain, string

             userKey)
            {

                return mainBase.sendasAliases.Get(domain, userKey);
            }





            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.SendasAlias Insert (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.SendasAlias body, string

             domain, string

             userKey)
            {

                return mainBase.sendasAliases.Insert(body, domain, userKey);
            }


        }
        #endregion



        #region Signature

        public class Signature
        {






            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Signature Get (string

             domain, string

             userKey)
            {

                return mainBase.signature.Get(domain, userKey);
            }





            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Signature Update (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Signature body, string

             domain, string

             userKey)
            {

                return mainBase.signature.Update(body, domain, userKey);
            }


        }
        #endregion



        #region VacationResponder

        public class VacationResponder
        {






            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.VacationResponder Get (string

             domain, string

             userKey)
            {

                return mainBase.vacationResponder.Get(domain, userKey);
            }





            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.VacationResponder Update (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.VacationResponder body, string

             domain, string

             userKey)
            {

                return mainBase.vacationResponder.Update(body, domain, userKey);
            }


        }
        #endregion



        #region WebClip

        public class WebClip
        {






            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.WebClip Update (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.WebClip body, string

             domain, string

             userKey)
            {

                return mainBase.webClip.Update(body, domain, userKey);
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

    public class Emailsettings : ServiceWrapper<emailsettings_v1.EmailsettingsService>, IServiceWrapper<Google.Apis.Services.IClientService>
    {

        protected override bool worksWithGmail { get { return false; } }

        protected override emailsettings_v1.EmailsettingsService CreateNewService(string domain, AuthenticatedUserInfo authInfo, string gShellServiceAccount = null)
        {
            return new emailsettings_v1.EmailsettingsService(OAuth2Base.GetGdataInitializer(domain, authInfo));
        }

        public override string apiNameAndVersion { get { return "admin:emailsettings_v1"; } }

        public Delegation delegation{ get; set; }
        public Filters filters{ get; set; }
        public Forwarding forwarding{ get; set; }
        public General general{ get; set; }
        public Imap imap{ get; set; }
        public Labels labels{ get; set; }
        public Language language{ get; set; }
        public Pop pop{ get; set; }
        public SendasAliases sendasAliases{ get; set; }
        public Signature signature{ get; set; }
        public VacationResponder vacationResponder{ get; set; }
        public WebClip webClip{ get; set; }

        public Emailsettings() //public Reports()
        {

            delegation = new Delegation();
            filters = new Filters();
            forwarding = new Forwarding();
            general = new General();
            imap = new Imap();
            labels = new Labels();
            language = new Language();
            pop = new Pop();
            sendasAliases = new SendasAliases();
            signature = new Signature();
            vacationResponder = new VacationResponder();
            webClip = new WebClip();
        }




        public class Delegation
        {





            public void Delete (string

             domain, string

             userKey, string

             delegateEmail)
            {
                GetService().Delegation.Delete(domain, userKey, delegateEmail).Execute();
            }

            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Delegates Get (string

             domain, string

             userKey)
            {
                return GetService().Delegation.Get(domain, userKey).Execute();
            }

            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Delegate Insert (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Delegate body, string

             domain, string

             userKey)
            {
                return GetService().Delegation.Insert(body, domain, userKey).Execute();
            }

        }


        public class Filters
        {





            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Filter Insert (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Filter body, string

             domain, string

             userKey)
            {
                return GetService().Filters.Insert(body, domain, userKey).Execute();
            }

        }


        public class Forwarding
        {





            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Forwarding Get (string

             domain, string

             userKey)
            {
                return GetService().Forwarding.Get(domain, userKey).Execute();
            }

            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Forwarding Update (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Forwarding body, string

             domain, string

             userKey)
            {
                return GetService().Forwarding.Update(body, domain, userKey).Execute();
            }

        }


        public class General
        {





            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.General Update (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.General body, string

             domain, string

             userKey)
            {
                return GetService().General.Update(body, domain, userKey).Execute();
            }

        }


        public class Imap
        {





            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Imap Get (string

             domain, string

             userKey)
            {
                return GetService().Imap.Get(domain, userKey).Execute();
            }

            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Imap Update (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Imap body, string

             domain, string

             userKey)
            {
                return GetService().Imap.Update(body, domain, userKey).Execute();
            }

        }


        public class Labels
        {





            public void Delete (string

             domain, string

             userKey, string

             labelName)
            {
                GetService().Labels.Delete(domain, userKey, labelName).Execute();
            }

            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Labels Get (string

             domain, string

             userKey)
            {
                return GetService().Labels.Get(domain, userKey).Execute();
            }

            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Label Insert (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Label body, string

             domain, string

             userKey)
            {
                return GetService().Labels.Insert(body, domain, userKey).Execute();
            }

        }


        public class Language
        {





            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Language Update (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Language body, string

             domain, string

             userKey)
            {
                return GetService().Language.Update(body, domain, userKey).Execute();
            }

        }


        public class Pop
        {





            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Pop Get (string

             domain, string

             userKey)
            {
                return GetService().Pop.Get(domain, userKey).Execute();
            }

            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Pop Update (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Pop body, string

             domain, string

             userKey)
            {
                return GetService().Pop.Update(body, domain, userKey).Execute();
            }

        }


        public class SendasAliases
        {





            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.SendAsAliases Get (string

             domain, string

             userKey)
            {
                return GetService().SendasAliases.Get(domain, userKey).Execute();
            }

            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.SendasAlias Insert (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.SendasAlias body, string

             domain, string

             userKey)
            {
                return GetService().SendasAliases.Insert(body, domain, userKey).Execute();
            }

        }


        public class Signature
        {





            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Signature Get (string

             domain, string

             userKey)
            {
                return GetService().Signature.Get(domain, userKey).Execute();
            }

            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Signature Update (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.Signature body, string

             domain, string

             userKey)
            {
                return GetService().Signature.Update(body, domain, userKey).Execute();
            }

        }


        public class VacationResponder
        {





            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.VacationResponder Get (string

             domain, string

             userKey)
            {
                return GetService().VacationResponder.Get(domain, userKey).Execute();
            }

            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.VacationResponder Update (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.VacationResponder body, string

             domain, string

             userKey)
            {
                return GetService().VacationResponder.Update(body, domain, userKey).Execute();
            }

        }


        public class WebClip
        {





            public Google.Apis.admin.Emailsettings.emailsettings_v1.Data.WebClip Update (Google.Apis.admin.Emailsettings.emailsettings_v1.Data.WebClip body, string

             domain, string

             userKey)
            {
                return GetService().WebClip.Update(body, domain, userKey).Execute();
            }

        }

    }
}