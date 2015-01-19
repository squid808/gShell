using System;
using System.Collections.Generic;
using System.Management.Automation;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;

namespace gShell.DirectoryCmdlets.GAUser.GAUserProperties
{
    [Cmdlet(VerbsCommon.New, "GAUserProperty",
          SupportsShouldProcess = true)]
    public class NewGAUserProperty : PSCmdlet, IDynamicParameters
    {
        #region Properties

        [Parameter(Position = 0,
            Mandatory = false,
            HelpMessage = "The property type to create. Once you choose one type more properties will show up, PoSh 3+. Allowed values are: address, email, externalid, im, organization, phone, relation")]
        public GAUserPropertyType PropertyType { get; set; }

        private IUserContextProperties context;

        #endregion

        // Implement GetDynamicParameters to
        // retrieve the dynamic parameter.
        public object GetDynamicParameters()
        {
            switch (PropertyType)
            {
                case GAUserPropertyType.address:
                    context = new UserAddressProperties();
                    return context;

                case GAUserPropertyType.email:
                    context = new UserEmailProperties();
                    return context;

                case GAUserPropertyType.externalid:
                    context = new UserExternalIdProperties();
                    return context;

                case GAUserPropertyType.im:
                    context = new UserImProperties();
                    return context;

                case GAUserPropertyType.organization:
                    context = new UserOrganizationProperties();
                    return context;

                case GAUserPropertyType.phone:
                    context = new UserPhoneProperties();
                    return context;

                case GAUserPropertyType.relation:
                    context = new UserRelationProperties();
                    return context;

                default:
                    context = null;
                    return context;
            }
        }

        protected override void ProcessRecord()
        {
            switch (PropertyType)
            {
                case GAUserPropertyType.address:
                    UserAddressProperties ap = context as UserAddressProperties;
                    WriteObject(GetUserAddress(ap));
                    break;

                case GAUserPropertyType.email:
                    UserEmailProperties emp = context as UserEmailProperties;
                    WriteObject(GetUserEmail(emp));
                    break;

                case GAUserPropertyType.externalid:
                    UserExternalIdProperties eip = context as UserExternalIdProperties;
                    WriteObject(GetUserExternalId(eip));
                    break;

                case GAUserPropertyType.im:
                    UserImProperties im = context as UserImProperties;
                    WriteObject(GetUserIm(im));
                    break;

                case GAUserPropertyType.organization:
                    UserOrganizationProperties op = context as UserOrganizationProperties;
                    WriteObject(GetUserOrganization(op));
                    break;

                case GAUserPropertyType.phone:
                    UserPhoneProperties pp = context as UserPhoneProperties;
                    WriteObject(GetUserPhone(pp));
                    break;

                case GAUserPropertyType.relation:
                    UserRelationProperties rp = context as UserRelationProperties;
                    WriteObject(GetUserRelation(rp));
                    break;
            }
        }


        #region ConversionMethods

        /// <summary>
        /// Turn a set of UserAddressProperties in to a UserAddress.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private UserAddress GetUserAddress(UserAddressProperties p)
        {
            //GAUserPropertyAddress address = new GAUserPropertyAddress();
            UserAddress address = new UserAddress();

            address.Type = p.Type.ToString();

            if (p.Type == GAUserAddressType.custom &&
                !String.IsNullOrWhiteSpace(p.CustomType))
            {
                address.CustomType = p.CustomType;
            }
            else if (p.Type == GAUserAddressType.custom &&
                String.IsNullOrWhiteSpace(p.CustomType))
            {
                WriteError(new ErrorRecord(new Exception(
                "No CustomType; it cannot be empty if the Type is Custom."),
                    "", ErrorCategory.InvalidData, p.CustomType));
            }

            if (p.SourceIsStructured.HasValue)
            {
                address.SourceIsStructured = p.SourceIsStructured.Value;
            }

            if (!String.IsNullOrWhiteSpace(p.Formatted))
            {
                address.Formatted = p.Formatted;
            }

            if (!String.IsNullOrWhiteSpace(p.PoBox))
            {
                address.PoBox = p.PoBox;
            }

            if (!String.IsNullOrWhiteSpace(p.ExtendedAddress))
            {
                address.ExtendedAddress = p.ExtendedAddress;
            }

            if (!String.IsNullOrWhiteSpace(p.StreetAddress))
            {
                address.StreetAddress = p.StreetAddress;
            }

            if (!String.IsNullOrWhiteSpace(p.Locality))
            {
                address.Locality = p.Locality;
            }

            if (!String.IsNullOrWhiteSpace(p.Region))
            {
                address.Region = p.Region;
            }

            if (!String.IsNullOrWhiteSpace(p.PostalCode))
            {
                address.PostalCode = p.PostalCode;
            }

            if (!String.IsNullOrWhiteSpace(p.Country))
            {
                address.Country = p.Country;
            }

            if (p.Primary.HasValue)
            {
                address.Primary = p.Primary.Value;
            }

            if (!String.IsNullOrWhiteSpace(p.CountryCode))
            {
                address.CountryCode = p.CountryCode;
            }

            return(address);
        }

        private UserEmail GetUserEmail(UserEmailProperties p)
        {
            UserEmail email = new UserEmail();

            email.Type = p.Type.ToString();

            if (p.Type == GAUserEmailType.custom &&
                !String.IsNullOrWhiteSpace(p.CustomType))
            {
                email.CustomType = p.CustomType;
            }
            else if (p.Type == GAUserEmailType.custom &&
                String.IsNullOrWhiteSpace(p.CustomType))
            {
                WriteError(new ErrorRecord(new Exception(
                "No CustomType; it cannot be empty if the Type is Custom."),
                    "", ErrorCategory.InvalidData, p.CustomType));
            }

            
            if (!String.IsNullOrWhiteSpace(p.Address))
            {
                email.Address = p.Address;
            }

            if (p.Primary.HasValue) 
            {
                email.Primary = p.Primary.Value;
            }

            return email;
        }

        private UserExternalId GetUserExternalId(UserExternalIdProperties p)
        {
            UserExternalId externalId = new UserExternalId();

            externalId.Type = p.Type.ToString();

            if (p.Type == GAUserExternalIdType.custom &&
                !String.IsNullOrWhiteSpace(p.CustomType))
            {
                externalId.CustomType = p.CustomType;
            }
            else if (p.Type == GAUserExternalIdType.custom &&
                String.IsNullOrWhiteSpace(p.CustomType))
            {
                WriteError(new ErrorRecord(new Exception(
                "No CustomType; it cannot be empty if the Type is Custom."),
                    "", ErrorCategory.InvalidData, p.CustomType));
            }

            if (!String.IsNullOrWhiteSpace(p.Value))
            {
                externalId.Value = p.Value;
            }
            
            return externalId;
        }

        private UserIm GetUserIm(UserImProperties p)
        {
            UserIm im = new UserIm();

            im.Type = p.Type.ToString();

            if (p.Type == GAUserIMType.custom &&
                !String.IsNullOrWhiteSpace(p.CustomType))
            {
                im.CustomType = p.CustomType;
            }
            else if (p.Type == GAUserIMType.custom &&
                String.IsNullOrWhiteSpace(p.CustomType))
            {
                WriteError(new ErrorRecord(new Exception(
                "No CustomType; it cannot be empty if the Type is Custom."),
                    "", ErrorCategory.InvalidData, p.CustomType));
            }

            im.Protocol = p.Protocol.ToString();

            if (p.Protocol == GAUserImProtocol.custom_protocol &&
                !String.IsNullOrWhiteSpace(p.CustomProtocol))
            {
                im.CustomProtocol = p.CustomProtocol;
            }
            else if (p.Protocol == GAUserImProtocol.custom_protocol &&
                String.IsNullOrWhiteSpace(p.CustomProtocol))
            {
                WriteError(new ErrorRecord(new Exception(
                "No CustomType; it cannot be empty if the Type is Custom."),
                    "", ErrorCategory.InvalidData, p.CustomType));
            }

            if (p.Primary.HasValue)
            {
                im.Primary = p.Primary.Value;
            }

            if (!String.IsNullOrWhiteSpace(p.Im))
            {
                im.Im = p.Im;
            }

            return im;
        }

        private UserOrganization GetUserOrganization(UserOrganizationProperties p)
        {
            UserOrganization org = new UserOrganization();

            org.Type = p.Type.ToString();

            if (p.Type == GAUserOrganizationType.custom &&
                !String.IsNullOrWhiteSpace(p.CustomType))
            {
                org.CustomType = p.CustomType;
            }
            else if (p.Type == GAUserOrganizationType.custom &&
                String.IsNullOrWhiteSpace(p.CustomType))
            {
                WriteError(new ErrorRecord(new Exception(
                "No CustomType; it cannot be empty if the Type is Custom."),
                    "", ErrorCategory.InvalidData, p.CustomType));
            }

            if (!String.IsNullOrWhiteSpace(p.CostCenter))
            {
                org.CostCenter = p.CostCenter;
            }

            if (!String.IsNullOrWhiteSpace(p.Department))
            {
                org.Department = p.Department;
            }

            if (!String.IsNullOrWhiteSpace(p.Description))
            {
                org.Description = p.Description;
            }

            if (!String.IsNullOrWhiteSpace(p.Domain))
            {
                org.Domain = p.Domain;
            }

            if (!String.IsNullOrWhiteSpace(p.Location))
            {
                org.Location = p.Location;
            }

            if (!String.IsNullOrWhiteSpace(p.Name))
            {
                org.Name = p.Name;
            }

            if (p.Primary.HasValue)
            {
                org.Primary = p.Primary.Value;
            }

            if (!String.IsNullOrWhiteSpace(p.Symbol))
            {
                org.Symbol = p.Symbol;
            }

            if (!String.IsNullOrWhiteSpace(p.Title))
            {
                org.Title = p.Title;
            }

            return org;
        }

        private UserPhone GetUserPhone(UserPhoneProperties p)
        {
            UserPhone phone = new UserPhone();

            phone.Type = p.Type.ToString();

            if (p.Type == GAUserPhoneType.custom &&
                !String.IsNullOrWhiteSpace(p.CustomType))
            {
                phone.CustomType = p.CustomType;
            }
            else if (p.Type == GAUserPhoneType.custom &&
                String.IsNullOrWhiteSpace(p.CustomType))
            {
                WriteError(new ErrorRecord(new Exception(
                "No CustomType; it cannot be empty if the Type is Custom."),
                    "", ErrorCategory.InvalidData, p.CustomType));
            }

            if (!String.IsNullOrWhiteSpace(p.Value))
            {
                phone.Value = p.Value;
            }

            if (p.Primary.HasValue)
            {
                phone.Primary = p.Primary.Value;
            }

            return phone;
        }

        private UserRelation GetUserRelation(UserRelationProperties p)
        {
            UserRelation e = new UserRelation();

            e.Type = p.Type.ToString();

            if (p.Type == GAUserRelationType.custom &&
                !String.IsNullOrWhiteSpace(p.CustomType))
            {
                e.CustomType = p.CustomType;
            }
            else if (p.Type == GAUserRelationType.custom &&
                String.IsNullOrWhiteSpace(p.CustomType))
            {
                WriteError(new ErrorRecord(new Exception(
                "No CustomType; it cannot be empty if the Type is Custom."),
                    "", ErrorCategory.InvalidData, p.CustomType));
            }

            if (!String.IsNullOrWhiteSpace(p.Value))
            {
                e.Value = p.Value;
            }

            return e;
        }

        //private UserCustomSchemaProperties GetUserCustomSchema(UserCustomSchemaProperties p)
        //{
        //    UserCustomSchemaProperties e = new UserCustomSchemaProperties();

        //    //I have no idea what to do here right now. I'm open to ideas.

        //    return e;
        //}

        #endregion
    }


    #region UserPropertyContextClasses
    public interface IUserContextProperties { }

    public class UserAddressProperties : IUserContextProperties
    {
        [Parameter(Position = 1,
            Mandatory = true,
            HelpMessage = "The address type. Allowed values are: custom, home, other, work")]
        public GAUserAddressType Type { get; set; }

        [Parameter(Position = 2,
            HelpMessage = "If the address type is custom, this property contains the custom value.")]
        public string CustomType { get; set; }

        [Parameter(Position = 3,
            HelpMessage = "Indicates if the user-supplied address was formatted. Formatted addresses are not currently supported.")]
        public bool? SourceIsStructured { get; set; }

        [Parameter(Position = 4,
            HelpMessage = "A full and unstructured postal address.")]
        public string Formatted { get; set; }

        [Parameter(Position = 5,
            HelpMessage = "The post office box, if present.")]
        public string PoBox { get; set; }

        [Parameter(Position = 6,
            HelpMessage = "For extended addresses, such as an address that includes a sub-region.")]
        public string ExtendedAddress { get; set; }

        [Parameter(Position = 7,
            HelpMessage = "The street address, such as 1600 Amphitheatre Parkway. Whitespace within the string is ignored; however, newlines are significant.")]
        public string StreetAddress { get; set; }

        [Parameter(Position = 8,
            HelpMessage = "The town or city of the address.")]
        public string Locality { get; set; }

        [Parameter(Position = 9,
            HelpMessage = "The abbreviated province or state.")]
        public string Region { get; set; }

        [Parameter(Position = 10,
            HelpMessage = "The ZIP or postal code, if applicable.")]
        public string PostalCode { get; set; }

        [Parameter(Position = 11,
            HelpMessage = "Country.")]
        public string Country { get; set; }

        [Parameter(Position = 12,
            HelpMessage = "If this is the user's primary address. The addresses list may contain only one primary address.")]
        public bool? Primary { get; set; }

        [Parameter(Position = 13,
            HelpMessage = "The country code. Uses the ISO 3166-1 standard.")]
        public string CountryCode { get; set; }
    }

    public class UserEmailProperties : IUserContextProperties
    {
        [Parameter(Position = 1,
            HelpMessage = "The user's email address. Also serves as the email ID. This value can be the user's primary email address or an alias.")]
        public string Address { get; set; }

        [Parameter(Position = 2,
            HelpMessage = "If the value of type is custom, this property contains the custom type string.")]
        public string CustomType { get; set; }

        [Parameter(Position = 3,
            HelpMessage = "Idicates if this is the user's primary email. Only one entry can be marked as primary.")]
        public bool? Primary { get; set; }

        [Parameter(Position = 4,
            Mandatory = true,
            HelpMessage = "The type of the email account. Valid values are: custom, home, other, work")]
        public GAUserEmailType Type { get; set; }
    }

    public class UserExternalIdProperties : IUserContextProperties
    {
        [Parameter(Position = 1,
            HelpMessage = "If the external ID type is custom, this property holds the custom type.")]
        public string CustomType { get; set; }

        [Parameter(Position = 2,
            Mandatory = true,
            HelpMessage = "The type of the ID. Allowed values are: account, custom, customer, network, organization")]
        public GAUserExternalIdType Type { get; set; }

        [Parameter(Position = 3,
            HelpMessage = "The value of the ID.")]
        public string Value { get; set; }
    }

    public class UserImProperties : IUserContextProperties
    {
        [Parameter(Position = 1,
            HelpMessage = "If the protocol value is custom_protocol, this property holds the custom protocol's string.")]
        public string CustomProtocol { get; set; }

        [Parameter(Position = 2,
            HelpMessage = "If the IM type is custom, this property holds the custom type string.")]
        public string CustomType { get; set; }

        [Parameter(Position = 3,
            HelpMessage = "The user's IM network ID.")]
        public string Im { get; set; }

        [Parameter(Position = 4,
            HelpMessage = "If this is the user's primary IM. Only one entry in the IM list can have a value of true.")]
        public bool? Primary { get; set; }

        [Parameter(Position = 5,
            Mandatory = true,
            HelpMessage = "An IM protocol identifies the IM network. The value can be a custom network or the standard network. The values are: custom_protocol: A custom IM network protocol, aim: AOL Instant Messenger protocol, gtalk: Google Talk protocol, icq: ICQ protocol, jabber: Jabber protocol, msn: MSN Messenger protocol, net_meeting: Net Meeting protocol, qq: QQ protocol, skype: Skype protocol, yahoo: Yahoo Messenger protocol")]
        public GAUserImProtocol Protocol { get; set; }

        [Parameter(Position = 6,
            Mandatory = true,
            HelpMessage = "The type must be one of these values: custom, home, other, work")]
        public GAUserIMType Type { get; set; }
    }

    public class UserOrganizationProperties : IUserContextProperties
    {
        [Parameter(Position = 1,
            HelpMessage = "The cost center of the user's organization.")]
        public string CostCenter { get; set; }

        [Parameter(Position = 2,
            HelpMessage = "If the value of type is custom, this property contains the custom type.")]
        public string CustomType { get; set; }

        [Parameter(Position = 3,
            HelpMessage = "Specifies the department within the organization, such as 'sales' or 'engineering'.")]
        public string Department { get; set; }

        [Parameter(Position = 4,
            HelpMessage = "The description of the organization.")]
        public string Description { get; set; }

        [Parameter(Position = 5,
            HelpMessage = "The domain the organization belongs to.")]
        public string Domain { get; set; }

        [Parameter(Position = 6,
            HelpMessage = "The physical location of the organization. This does not need to be a fully qualified address.")]
        public string Location { get; set; }

        [Parameter(Position = 7,
            HelpMessage = "The name of the organization.")]
        public string Name { get; set; }

        [Parameter(Position = 8,
            HelpMessage = "Indicates if this is the user's primary organization. A user may only have one primary organization.")]
        public bool? Primary { get; set; }

        [Parameter(Position = 9,
            HelpMessage = "Text string symbol of the organization. For example, the text symbol for Google is GOOG.")]
        public string Symbol { get; set; }

        [Parameter(Position = 10,
            HelpMessage = "The user's title within the organization, for example 'member' or 'engineer'.")]
        public string Title { get; set; }

        [Parameter(Position = 11,
            Mandatory = true,
            HelpMessage = "The type of organization. Possible values are: unknown, school, work, domain_only, custom")]
        public GAUserOrganizationType Type { get; set; }
    }

    public class UserPhoneProperties : IUserContextProperties
    {
        [Parameter(Position = 1,
            HelpMessage = "A human-readable phone number. It may be in any telephone number format.")]
        public string Value { get; set; }

        [Parameter(Position = 2,
            HelpMessage = "Indicates if this is the user's primary phone number. A user may only have one primary phone number.")]
        public bool? Primary { get; set; }

        [Parameter(Position = 3,
            Mandatory = true,
            HelpMessage = "The type of phone number. Allowed values are: custom, home, work, other, home_fax, work_fax, mobile, pager, other_fax, compain_main, assistant, car, radio, isdn, callback, telex, tty_tdd, work_mobile, work_pager, main, grand_central")]
        public GAUserPhoneType Type { get; set; }

        [Parameter(Position = 4,
            HelpMessage = "If the value of type is custom, this property contains the custom type.")]
        public string CustomType { get; set; }
    }

    public class UserRelationProperties : IUserContextProperties
    {
        [Parameter(Position = 1,
            HelpMessage = "If the value of type is custom, this property contains the custom type.")]
        public string CustomType { get; set; }

        [Parameter(Position = 2,
            Mandatory = true,
            HelpMessage = "The type of relation. Possible values are: custom, spouse, child, mother, father, parent, brother, sister, friend, relative, domestic_partner, manager, assistant, referred_by, partner")]
        public GAUserRelationType Type { get; set; }

        [Parameter(Position = 3,
            HelpMessage = "The name of the person the user is related to.")]
        public string Value { get; set; }
    }

    //public class UserCustomSchemaProperties : IUserContextProperties
    //{

    //}
    #endregion
}