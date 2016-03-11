using System.Collections.Generic;
using System.Management.Automation;
using Data = Google.Apis.admin.Directory.directory_v1.Data;

using Newtonsoft.Json.Linq;

namespace gShell.Cmdlets.Directory.GAUserProperty
{
    public class GAUserPropertyBase : DirectoryBase
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Help Text")]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        //Domain position = 1

        #endregion

        #region JsonConversions
        /// <summary>
        /// Given one JObject, convert it to a Data.UserAddress
        /// </summary>
        /// <param name="jsonObj"></param>
        /// <returns></returns>
        protected static Data.UserAddress JsonToAddress(JObject o)
        {
            return new Data.UserAddress()
            {
                Country = (string)o["country"],
                CountryCode = (string)o["countryCode"],
                CustomType = (string)o["customType"],
                ETag = (string)o["etag"],
                ExtendedAddress = (string)o["extendedAddress"],
                Formatted = (string)o["formatted"],
                Locality = (string)o["locality"],
                PoBox = (string)o["poBox"],
                PostalCode = (string)o["postalCode"],
                Primary = (bool?)o["primary"],
                Region = (string)o["region"],
                SourceIsStructured = (bool?)o["sourceIsStructured"],
                StreetAddress = (string)o["streetAddress"],
                Type = (string)o["type"]

            };
        }

        /// <summary>
        /// Given one JObject, convert it to a Data.UserEmail
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected static Data.UserEmail JsonToEmail(JObject o)
        {
            return new Data.UserEmail()
            {
                Address = (string)o["address"],
                CustomType = (string)o["customType"],
                ETag = (string)o["etag"],
                Primary = (bool?)o["primary"],
                Type = (string)o["type"]
            };
        }

        /// <summary>
        /// Given one JObject, convert it to a Data.UserExternalId
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected static Data.UserExternalId JsonToExternalId(JObject o)
        {
            return new Data.UserExternalId()
            {
                CustomType = (string)o["customType"],
                ETag = (string)o["etag"],
                Type = (string)o["type"],
                Value = (string)o["value"]
            };
        }

        /// <summary>
        /// Given one JObject, convert it to a Data.UserIm
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected static Data.UserIm JsonToIm(JObject o)
        {
            return new Data.UserIm()
            {
                CustomProtocol = (string)o["customProtocol"],
                CustomType = (string)o["customType"],
                ETag = (string)o["etag"],
                Im = (string)o["im"],
                Primary = (bool?)o["primary"],
                Protocol = (string)o["protocol"],
                Type = (string)o["type"]
            };
        }

        /// <summary>
        /// Given one JObject, convert it to a Data.UserOrganization
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected static Data.UserOrganization JsonToOrganization(JObject o)
        {
            return new Data.UserOrganization()
            {
                CostCenter = (string)o["costCenter"],
                CustomType = (string)o["customType"],
                Department = (string)o["department"],
                Description = (string)o["description"],
                Domain = (string)o["domain"],
                ETag = (string)o["etag"],
                Location = (string)o["location"],
                Name = (string)o["name"],
                Primary = (bool?)o["primary"],
                Symbol = (string)o["symbol"],
                Title = (string)o["title"],
                Type = (string)o["type"]
            };
        }

        /// <summary>
        /// Given one JObject, convert it to a Data.UserPhone
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected static Data.UserPhone JsonToPhone(JObject o)
        {
            return new Data.UserPhone()
            {
                CustomType = (string)o["customType"],
                ETag = (string)o["etag"],
                Primary = (bool?)o["primary"],
                Type = (string)o["type"],
                Value = (string)o["value"]
            };
        }

        /// <summary>
        /// Given one JObject, convert it to a Data.UserRelation
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected static Data.UserRelation JsonToRelation(JObject o)
        {
            return new Data.UserRelation()
            {
                CustomType = (string)o["customType"],
                ETag = (string)o["etag"],
                Type = (string)o["type"],
                Value = (string)o["value"]
            };
        }

        //protected UserCustomSchema JsonToAddress(JObject o)
        //{

        //}

        #endregion

        #region GetProperties

        public static List<Data.UserAddress> GetAddressFromUser(Data.User u)
        {
            List<Data.UserAddress> results = new List<Data.UserAddress>();

            foreach (JObject j in GetJObjectsFromUser(u, GAUserPropertyType.address))
            {
                results.Add(JsonToAddress(j));
            }

            return results;
        }
               
        public static List<Data.UserEmail> GetEmailFromUser(Data.User u)
        {
            List<Data.UserEmail> results = new List<Data.UserEmail>();

            foreach (JObject j in GetJObjectsFromUser(u, GAUserPropertyType.email))
            {
                results.Add(JsonToEmail(j));
            }

            return results;
        }
               
        public static List<Data.UserExternalId> GetExIdFromUser(Data.User u)
        {
            List<Data.UserExternalId> results = new List<Data.UserExternalId>();

            foreach (JObject j in GetJObjectsFromUser(u, GAUserPropertyType.externalid))
            {
                results.Add(JsonToExternalId(j));
            }

            return results;
        }
               
        public static List<Data.UserIm> GetImFromUser(Data.User u)
        {
            List<Data.UserIm> results = new List<Data.UserIm>();

            foreach (JObject j in GetJObjectsFromUser(u, GAUserPropertyType.im))
            {
                results.Add(JsonToIm(j));
            }

            return results;
        }
               
        public static List<Data.UserOrganization> GetOrgFromUser(Data.User u)
        {
            List<Data.UserOrganization> results = new List<Data.UserOrganization>();

            foreach (JObject j in GetJObjectsFromUser(u, GAUserPropertyType.organization))
            {
                results.Add(JsonToOrganization(j));
            }

            return results;
        }
               
        public static List<Data.UserPhone> GetPhoneFromUser(Data.User u)
        {
            List<Data.UserPhone> results = new List<Data.UserPhone>();

            foreach (JObject j in GetJObjectsFromUser(u, GAUserPropertyType.phone))
            {
                results.Add(JsonToPhone(j));
            }

            return results;
        }
               
        public static List<Data.UserRelation> GetRelationFromUser(Data.User u)
        {
            List<Data.UserRelation> results = new List<Data.UserRelation>();

            foreach (JObject j in GetJObjectsFromUser(u, GAUserPropertyType.relation))
            {
                results.Add(JsonToRelation(j));
            }

            return results;
        }

        /// <summary>
        /// Returns a List of JObjects from a given Data.User object.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="pType"></param>
        /// <returns></returns>
        protected static List<JObject> GetJObjectsFromUser(Data.User u, GAUserPropertyType pType) 
        {

            List<JObject> jobjects = new List<JObject>();
            JArray a = new JArray();

            switch (pType)
            {
                case GAUserPropertyType.address:
                    if (null != u.Addresses)
                    {
                        a = JArray.Parse(u.Addresses.ToString());
                    }
                    break;

                case GAUserPropertyType.email:
                    if (null != u.Emails)
                    {
                        a = JArray.Parse(u.Emails.ToString());
                    }
                    break;

                case GAUserPropertyType.externalid:
                    if (null != u.ExternalIds)
                    {
                        a = JArray.Parse(u.ExternalIds.ToString());
                    }
                    break;

                case GAUserPropertyType.im:
                    if (null != u.Ims)
                    {
                        a = JArray.Parse(u.Ims.ToString());
                    }
                    break;

                case GAUserPropertyType.organization:
                    if (null != u.Organizations)
                    {
                        a = JArray.Parse(u.Organizations.ToString());
                    }
                    break;

                case GAUserPropertyType.phone:
                    if (null != u.Phones)
                    {
                        a = JArray.Parse(u.Phones.ToString());
                    }
                    break;

                case GAUserPropertyType.relation:
                    if (null != u.Relations)
                    {
                        a = JArray.Parse(u.Relations.ToString());
                    }
                    break;
            }

            foreach (object s in a)
            {
                JObject j = JObject.Parse(s.ToString());
                jobjects.Add(j);
            }

            return jobjects;

        }

        #endregion
    }

    #region PropertyEnumTypes

    public enum GAUserPropertyType
    {
        address, email, externalid, im, organization, phone, relation//, customschema
    }

    public enum GAUserAddressType
    {
        custom, home, work, other
    }

    public enum GAUserEmailType
    {
        custom, home, other, work
    }

    public enum GAUserExternalIdType
    {
        account, custom, customer, network, organization
    }

    public enum GAUserIMType
    {
        custom, home, other, work
    }

    public enum GAUserImProtocol
    {
        custom_protocol, aim, gtalk, icq, jabber, msn, net_meeting, qq, skype, yahoo
    }

    public enum GAUserOrganizationType
    {
        unknown, school, work, domain_only, custom
    }

    public enum GAUserPhoneType
    {
        custom, home, work, other, home_fax, work_fax, mobile, pager, other_fax, compain_main,
        assistant, car, radio, isdn, callback, telex, tty_tdd, work_mobile, work_pager, main, grand_central
    }

    public enum GAUserRelationType
    {
        custom, spouse, child, mother, father, parent, brother, sister, friend, relative,
        domestic_partner, manager, assistant, referred_by, partner
    }

    #endregion

    /// <summary>
    /// An object to contain all UserProperties that are not the 'normal' types. Supports += syntax and add/addrange.
    /// </summary>
    public class GAUserPropertyCollection
    {
        #region Properties

        private bool _addressesUpdated;
        private bool _emailsUpdated;
        private bool _exIdsUpdated;
        private bool _imsUpdated;
        private bool _orgsUpdated;
        private bool _phonesUpdated;
        private bool _relationsUpdated;

        public List<Data.UserAddress> addresses { get { return _addresses; } }
        public List<Data.UserEmail> emails { get { return _emails; } }
        public List<Data.UserExternalId> externalIds { get { return _externalIds; } }
        public List<Data.UserIm> ims { get { return _ims; } }
        public List<Data.UserOrganization> organizations { get { return _organizations; } }
        public List<Data.UserPhone> phones { get { return _phones; } }
        public List<Data.UserRelation> relations { get { return _relations; } }

        private List<Data.UserAddress> _addresses = new List<Data.UserAddress>();
        private List<Data.UserEmail> _emails = new List<Data.UserEmail>();
        private List<Data.UserExternalId> _externalIds = new List<Data.UserExternalId>();
        private List<Data.UserIm> _ims = new List<Data.UserIm>();
        private List<Data.UserOrganization> _organizations = new List<Data.UserOrganization>();
        private List<Data.UserPhone> _phones = new List<Data.UserPhone>();
        private List<Data.UserRelation> _relations = new List<Data.UserRelation>();
        #endregion

        #region IsUpdated
        public bool IsUpdated(GAUserPropertyType pType)
        {
            switch (pType)
            {
                case GAUserPropertyType.address:
                    return _addressesUpdated;
                case GAUserPropertyType.email:
                    return _emailsUpdated;
                case GAUserPropertyType.externalid:
                    return _exIdsUpdated;
                case GAUserPropertyType.im:
                    return _imsUpdated;
                case GAUserPropertyType.organization:
                    return _orgsUpdated;
                case GAUserPropertyType.phone:
                    return _phonesUpdated;
                case GAUserPropertyType.relation:
                    return _relationsUpdated;
            }

            return false;
        }
        #endregion

        #region Getters
        public List<Data.UserAddress> GetAddresses()
        {
            return _addresses;
        }

        public List<Data.UserEmail> GetEmails()
        {
            return _emails;
        }

        public List<Data.UserExternalId> GetExternalIds()
        {
            return _externalIds;
        }

        public List<Data.UserIm> GetIms()
        {
            return _ims;
        }

        public List<Data.UserOrganization> GetOrganizations()
        {
            return _organizations;
        }

        public List<Data.UserPhone> GetPhones()
        {
            return _phones;
        }

        public List<Data.UserRelation> GetRelations()
        {
            return _relations;
        }
        #endregion

        #region Constructors
        public GAUserPropertyCollection() { }

        public GAUserPropertyCollection(Data.User u)
        {
            AddRange(GAUserPropertyBase.GetAddressFromUser(u));
            AddRange(GAUserPropertyBase.GetEmailFromUser(u));
            AddRange(GAUserPropertyBase.GetExIdFromUser(u));
            AddRange(GAUserPropertyBase.GetImFromUser(u));
            AddRange(GAUserPropertyBase.GetOrgFromUser(u));
            AddRange(GAUserPropertyBase.GetPhoneFromUser(u));
            AddRange(GAUserPropertyBase.GetRelationFromUser(u));
        }
        #endregion

        #region Add
        public void Add(Data.UserAddress uAdd)
        {
            _addresses.Add(uAdd);
            _addressesUpdated = true;
        }

        public void Add(Data.UserEmail uEmail)
        {
            _emails.Add(uEmail);
            _emailsUpdated = true;
        }

        public void Add(Data.UserExternalId uExId)
        {
            _externalIds.Add(uExId);
            _exIdsUpdated = true;
        }

        public void Add(Data.UserIm uIm)
        {
            _ims.Add(uIm);
            _imsUpdated = true;
        }

        public void Add(Data.UserOrganization uOrg)
        {
            _organizations.Add(uOrg);
            _orgsUpdated = true;
        }

        public void Add(Data.UserPhone uPhone)
        {
            _phones.Add(uPhone);
            _phonesUpdated = true;
        }

        public void Add(Data.UserRelation uRelation)
        {
            _relations.Add(uRelation);
            _relationsUpdated = true;
        }
        #endregion

        #region AddRange
        public void AddRange(IEnumerable<Data.UserAddress> pList)
        {
            foreach (Data.UserAddress uP in pList)
            {
                _addresses.Add(uP);
            }
        }

        public void AddRange(IEnumerable<Data.UserEmail> pList)
        {
            foreach (Data.UserEmail uP in pList)
            {
                _emails.Add(uP);
            }
        }

        public void AddRange(IEnumerable<Data.UserExternalId> pList)
        {
            foreach (Data.UserExternalId uP in pList)
            {
                _externalIds.Add(uP);
            }
        }

        public void AddRange(IEnumerable<Data.UserIm> pList)
        {
            foreach (Data.UserIm uP in pList)
            {
                _ims.Add(uP);
            }
        }

        public void AddRange(IEnumerable<Data.UserOrganization> pList)
        {
            foreach (Data.UserOrganization uP in pList)
            {
                _organizations.Add(uP);
            }
        }

        public void AddRange(IEnumerable<Data.UserPhone> pList)
        {
            foreach (Data.UserPhone uP in pList)
            {
                _phones.Add(uP);
            }
        }

        public void AddRange(IEnumerable<Data.UserRelation> pList)
        {
            foreach (Data.UserRelation uP in pList)
            {
                _relations.Add(uP);
            }
        }
        #endregion

        #region OperatorPlusOverload
        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, GAUserPropertyCollection coll2)
        {
            coll1.AddRange(coll2._addresses);
            coll1.AddRange(coll2._emails);
            coll1.AddRange(coll2._externalIds);
            coll1.AddRange(coll2._ims);
            coll1.AddRange(coll2._organizations);
            coll1.AddRange(coll2._phones);
            coll1.AddRange(coll2._relations);

            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, Data.UserAddress p2)
        {
            coll1.Add(p2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, List<Data.UserAddress> coll2)
        {
            coll1.AddRange(coll2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, Data.UserEmail p2)
        {
            coll1.Add(p2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, List<Data.UserEmail> coll2)
        {
            coll1.AddRange(coll2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, Data.UserExternalId p2)
        {
            coll1.Add(p2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, List<Data.UserExternalId> coll2)
        {
            coll1.AddRange(coll2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, Data.UserIm p2)
        {
            coll1.Add(p2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, List<Data.UserIm> coll2)
        {
            coll1.AddRange(coll2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, Data.UserOrganization p2)
        {
            coll1.Add(p2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, List<Data.UserOrganization> coll2)
        {
            coll1.AddRange(coll2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, Data.UserPhone p2)
        {
            coll1.Add(p2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, List<Data.UserPhone> coll2)
        {
            coll1.AddRange(coll2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, Data.UserRelation p2)
        {
            coll1.Add(p2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, List<Data.UserRelation> coll2)
        {
            coll1.AddRange(coll2);
            return coll1;
        }
        #endregion

        #region RemoveAt
        public void RemoveAt(GAUserPropertyType pType, int index)
        {
            if (index >= 0)
            {

                switch (pType)
                {
                    case GAUserPropertyType.address:
                        if (_addresses.Count > index)
                        {
                            _addresses.RemoveAt(index);
                            _addressesUpdated = true;
                        }
                        break;
                    case GAUserPropertyType.email:
                        if (_emails.Count > index)
                        {
                            _emails.RemoveAt(index);
                            _emailsUpdated = true;
                        }
                        break;
                    case GAUserPropertyType.externalid:
                        if (_externalIds.Count > index)
                        {
                            _externalIds.RemoveAt(index);
                            _exIdsUpdated = true;
                        }
                        break;
                    case GAUserPropertyType.im:
                        if (_ims.Count > index)
                        {
                            _ims.RemoveAt(index);
                            _imsUpdated = true;
                        }
                        break;
                    case GAUserPropertyType.organization:
                        if (_organizations.Count > index)
                        {
                            _organizations.RemoveAt(index);
                            _orgsUpdated = true;
                        }
                        break;
                    case GAUserPropertyType.phone:
                        if (_phones.Count > index)
                        {
                            _phones.RemoveAt(index);
                            _phonesUpdated = true;
                        }
                        break;
                    case GAUserPropertyType.relation:
                        if (_relations.Count > index)
                        {
                            _relations.RemoveAt(index);
                            _relationsUpdated = true;
                        }
                        break;
                }
            }
        }
        #endregion

        #region Clear
        public void Clear(GAUserPropertyType pType)
        {
            switch (pType)
            {
                case GAUserPropertyType.address:
                    _addresses.Clear();
                    _addressesUpdated = true;
                    break;
                case GAUserPropertyType.email:
                    _emails.Clear();
                    _emailsUpdated = true;
                    break;
                case GAUserPropertyType.externalid:
                    _externalIds.Clear();
                    _exIdsUpdated = true;
                    break;
                case GAUserPropertyType.im:
                    _ims.Clear();
                    _imsUpdated = true;
                    break;
                case GAUserPropertyType.organization:
                    _organizations.Clear();
                    _orgsUpdated = true;
                    break;
                case GAUserPropertyType.phone:
                    _phones.Clear();
                    _phonesUpdated = true;
                    break;
                case GAUserPropertyType.relation:
                    _relations.Clear();
                    _relationsUpdated = true;
                    break;
            }
        }
        #endregion
    }
}