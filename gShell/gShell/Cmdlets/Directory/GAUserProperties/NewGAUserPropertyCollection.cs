using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.PowerShell.Commands;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.DirectoryCmdlets.GAUser
{
    [Cmdlet(VerbsCommon.New, "GAUserPropertyCollection",
          SupportsShouldProcess = true)]
    public class NewGAUserPropertyCollection : PSCmdlet
    {
        
        protected override void ProcessRecord()
        {
            WriteObject(new GAUserPropertyCollection());
        }

    }

    /// <summary>
    /// An object to contain all UserProperties that are not the 'normal' types. Supports += syntax and add/addrange.
    /// </summary>
    public class GAUserPropertyCollection
    {
        #region Properties
        //public bool addressesUpdated { get { return _addressesUpdated; } }
        //public bool emailsUpdated { get { return _emailsUpdated; } }
        //public bool exIdsUpdated { get { return _exIdsUpdated; } }
        //public bool imsUpdated { get { return _imsUpdated; } }
        //public bool orgsUpdated { get { return _orgsUpdated; } }
        //public bool phonesUpdated { get { return _phonesUpdated; } }
        //public bool relationsUpdated { get { return _relationsUpdated; } }

        private bool _addressesUpdated;
        private bool _emailsUpdated;
        private bool _exIdsUpdated;
        private bool _imsUpdated;
        private bool _orgsUpdated;
        private bool _phonesUpdated;
        private bool _relationsUpdated;

        public List<UserAddress> addresses { get { return _addresses; } }
        public List<UserEmail> emails { get { return _emails; } }
        public List<UserExternalId> externalIds { get { return _externalIds; } }
        public List<UserIm> ims { get { return _ims; } }
        public List<UserOrganization> organizations { get { return _organizations; } }
        public List<UserPhone> phones { get { return _phones; } }
        public List<UserRelation> relations { get { return _relations; } }

        private List<UserAddress> _addresses;
        private List<UserEmail> _emails;
        private List<UserExternalId> _externalIds;
        private List<UserIm> _ims;
        private List<UserOrganization> _organizations;
        private List<UserPhone> _phones;
        private List<UserRelation> _relations;
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
        public List<UserAddress> GetAddresses()
        {
            return _addresses;
        }

        public List<UserEmail> GetEmails()
        {
            return _emails;
        }

        public List<UserExternalId> GetExternalIds()
        {
            return _externalIds;
        }

        public List<UserIm> GetIms()
        {
            return _ims;
        }

        public List<UserOrganization> GetOrganizations()
        {
            return _organizations;
        }

        public List<UserPhone> GetPhones()
        {
            return _phones;
        }

        public List<UserRelation> GetRelations()
        {
            return _relations;
        }
        #endregion

        #region Constructors
        public GAUserPropertyCollection()
        {
            _addresses = new List<UserAddress>();
            _emails = new List<UserEmail>();
            _externalIds = new List<UserExternalId>();
            _ims = new List<UserIm>();
            _organizations = new List<UserOrganization>();
            _phones = new List<UserPhone>();
            _relations = new List<UserRelation>();
        }

        public GAUserPropertyCollection(User u)
        {
            _addresses = new List<UserAddress>();
            _emails = new List<UserEmail>();
            _externalIds = new List<UserExternalId>();
            _ims = new List<UserIm>();
            _organizations = new List<UserOrganization>();
            _phones = new List<UserPhone>();
            _relations = new List<UserRelation>();

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
        public void Add(UserAddress uAdd)
        {
            _addresses.Add(uAdd);
            _addressesUpdated = true;
        }

        public void Add(UserEmail uEmail)
        {
            _emails.Add(uEmail);
            _emailsUpdated = true;
        }

        public void Add(UserExternalId uExId)
        {
            _externalIds.Add(uExId);
            _exIdsUpdated = true;
        }

        public void Add(UserIm uIm)
        {
            _ims.Add(uIm);
            _imsUpdated = true;
        }

        public void Add(UserOrganization uOrg)
        {
            _organizations.Add(uOrg);
            _orgsUpdated = true;
        }

        public void Add(UserPhone uPhone)
        {
            _phones.Add(uPhone);
            _phonesUpdated = true;
        }

        public void Add(UserRelation uRelation)
        {
            _relations.Add(uRelation);
            _relationsUpdated = true;
        }
        #endregion

        #region AddRange
        public void AddRange(IEnumerable<UserAddress> pList)
        {
            foreach (UserAddress uP in pList)
            {
                _addresses.Add(uP);
            }
        }

        public void AddRange(IEnumerable<UserEmail> pList)
        {
            foreach (UserEmail uP in pList)
            {
                _emails.Add(uP);
            }
        }

        public void AddRange(IEnumerable<UserExternalId> pList)
        {
            foreach (UserExternalId uP in pList)
            {
                _externalIds.Add(uP);
            }
        }

        public void AddRange(IEnumerable<UserIm> pList)
        {
            foreach (UserIm uP in pList)
            {
                _ims.Add(uP);
            }
        }

        public void AddRange(IEnumerable<UserOrganization> pList)
        {
            foreach (UserOrganization uP in pList)
            {
                _organizations.Add(uP);
            }
        }

        public void AddRange(IEnumerable<UserPhone> pList)
        {
            foreach (UserPhone uP in pList)
            {
                _phones.Add(uP);
            }
        }

        public void AddRange(IEnumerable<UserRelation> pList)
        {
            foreach (UserRelation uP in pList)
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

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, UserAddress p2)
        {
            coll1.Add(p2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, List<UserAddress> coll2)
        {
            coll1.AddRange(coll2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, UserEmail p2)
        {
            coll1.Add(p2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, List<UserEmail> coll2)
        {
            coll1.AddRange(coll2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, UserExternalId p2)
        {
            coll1.Add(p2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, List<UserExternalId> coll2)
        {
            coll1.AddRange(coll2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, UserIm p2)
        {
            coll1.Add(p2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, List<UserIm> coll2)
        {
            coll1.AddRange(coll2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, UserOrganization p2)
        {
            coll1.Add(p2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, List<UserOrganization> coll2)
        {
            coll1.AddRange(coll2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, UserPhone p2)
        {
            coll1.Add(p2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, List<UserPhone> coll2)
        {
            coll1.AddRange(coll2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, UserRelation p2)
        {
            coll1.Add(p2);
            return coll1;
        }

        public static GAUserPropertyCollection operator +(GAUserPropertyCollection coll1, List<UserRelation> coll2)
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