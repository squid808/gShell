using System;
using System.Collections.Generic;
using System.Management.Automation;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using Google.Apis.Requests;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace gShell.DirectoryCmdlets.GAUser
{
    public class GAUserPropertyBase : GetGAUserBase
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
        /// Given one JObject, convert it to a UserAddress
        /// </summary>
        /// <param name="jsonObj"></param>
        /// <returns></returns>
        protected static UserAddress JsonToAddress(JObject o)
        {
            return new UserAddress()
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
        /// Given one JObject, convert it to a UserEmail
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected static UserEmail JsonToEmail(JObject o)
        {
            return new UserEmail()
            {
                Address = (string)o["address"],
                CustomType = (string)o["customType"],
                ETag = (string)o["etag"],
                Primary = (bool?)o["primary"],
                Type = (string)o["type"]
            };
        }

        /// <summary>
        /// Given one JObject, convert it to a UserExternalId
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected static UserExternalId JsonToExternalId(JObject o)
        {
            return new UserExternalId()
            {
                CustomType = (string)o["customType"],
                ETag = (string)o["etag"],
                Type = (string)o["type"],
                Value = (string)o["value"]
            };
        }

        /// <summary>
        /// Given one JObject, convert it to a UserIm
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected static UserIm JsonToIm(JObject o)
        {
            return new UserIm()
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
        /// Given one JObject, convert it to a UserOrganization
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected static UserOrganization JsonToOrganization(JObject o)
        {
            return new UserOrganization()
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
        /// Given one JObject, convert it to a UserPhone
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected static UserPhone JsonToPhone(JObject o)
        {
            return new UserPhone()
            {
                CustomType = (string)o["customType"],
                ETag = (string)o["etag"],
                Primary = (bool?)o["primary"],
                Type = (string)o["type"],
                Value = (string)o["value"]
            };
        }

        /// <summary>
        /// Given one JObject, convert it to a UserRelation
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected static UserRelation JsonToRelation(JObject o)
        {
            return new UserRelation()
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

        //public static GAUserPropertyCollection GetAllPropertiesFromUser(User u)
        //{
        //    GAUserPropertyCollection results = new GAUserPropertyCollection();

        //    results += GetAddressFromUser(u);
        //    results += GetEmailFromUser(u);
        //    results += GetExIdFromUser(u);
        //    results += GetImFromUser(u);
        //    results += GetOrgFromUser(u);
        //    results += GetPhoneFromUser(u);
        //    results += GetRelationFromUser(u);

        //    return results;
        //}

        public static List<UserAddress> GetAddressFromUser(User u)
        {
            List<UserAddress> results = new List<UserAddress>();

            foreach (JObject j in GetJObjectsFromUser(u, GAUserPropertyType.address))
            {
                results.Add(JsonToAddress(j));
            }

            return results;
        }
               
        public static List<UserEmail> GetEmailFromUser(User u)
        {
            List<UserEmail> results = new List<UserEmail>();

            foreach (JObject j in GetJObjectsFromUser(u, GAUserPropertyType.email))
            {
                results.Add(JsonToEmail(j));
            }

            return results;
        }
               
        public static List<UserExternalId> GetExIdFromUser(User u)
        {
            List<UserExternalId> results = new List<UserExternalId>();

            foreach (JObject j in GetJObjectsFromUser(u, GAUserPropertyType.externalid))
            {
                results.Add(JsonToExternalId(j));
            }

            return results;
        }
               
        public static List<UserIm> GetImFromUser(User u)
        {
            List<UserIm> results = new List<UserIm>();

            foreach (JObject j in GetJObjectsFromUser(u, GAUserPropertyType.im))
            {
                results.Add(JsonToIm(j));
            }

            return results;
        }
               
        public static List<UserOrganization> GetOrgFromUser(User u)
        {
            List<UserOrganization> results = new List<UserOrganization>();

            foreach (JObject j in GetJObjectsFromUser(u, GAUserPropertyType.organization))
            {
                results.Add(JsonToOrganization(j));
            }

            return results;
        }
               
        public static List<UserPhone> GetPhoneFromUser(User u)
        {
            List<UserPhone> results = new List<UserPhone>();

            foreach (JObject j in GetJObjectsFromUser(u, GAUserPropertyType.phone))
            {
                results.Add(JsonToPhone(j));
            }

            return results;
        }
               
        public static List<UserRelation> GetRelationFromUser(User u)
        {
            List<UserRelation> results = new List<UserRelation>();

            foreach (JObject j in GetJObjectsFromUser(u, GAUserPropertyType.relation))
            {
                results.Add(JsonToRelation(j));
            }

            return results;
        }

        /// <summary>
        /// Returns a List of JObjects from a given user object.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="pType"></param>
        /// <returns></returns>
        protected static List<JObject> GetJObjectsFromUser(User u, GAUserPropertyType pType) 
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
}