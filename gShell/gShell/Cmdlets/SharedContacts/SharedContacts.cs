using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

using Google.Apis.admin.Sharedcontacts.sharedcontacts_v3;
using Data = Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data;

using gSharedContacts = gShell.dotNet.Sharedcontacts;

namespace gShell.Cmdlets.Sharedcontacts
{
    [Cmdlet(VerbsCommon.Get, "GSharedContact",
        SupportsShouldProcess = true,
          HelpUri = @"",
          DefaultParameterSetName="all")]
    public class GetGSharedContact : SharedcontactsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName="one")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Position = 0,
            Mandatory = false,
            ParameterSetName="all")]
        [ValidateNotNullOrEmpty]
        public bool? ShowDeleted { get; set; }

        [Parameter(Position = 1,
            Mandatory = false,
            ParameterSetName="all")]
        [ValidateNotNullOrEmpty]
        public int? MaxResults { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Shared Contact", "Get-GSharedContact"))
            {
                if (ParameterSetName == "one")
                {
                    WriteObject(contact.Get(Domain, Id));
                }
                else
                {
                    var properties = new gSharedContacts.Contact.ContactListProperties();

                    if (ShowDeleted.HasValue) properties.showdeleted = this.ShowDeleted.Value.ToString();

                    if (MaxResults.HasValue) properties.maxResults = this.MaxResults.Value;

                    WriteObject(contact.List(Domain, properties).ContactsValue);
                }
            }
        }
    }

    #region ContactBuildingCmdlets
    [Cmdlet(VerbsCommon.New, "GSharedContact",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGSharedContact : SharedcontactsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Content { get; set; }

        [Parameter(Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public Data.Name Name { get; set; }

        [Parameter(Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public Data.PhoneNumber[] PhoneNumbers { get; set; }

        [Parameter(Position = 3,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public Data.Email[] Emails { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Contact() { Content = this.Content };

            if (Name != null) { body.Name = this.Name; }

            if (PhoneNumbers != null)
            {
                body.PhoneNumber = new List<Data.PhoneNumber>();
                foreach (var p in PhoneNumbers)
                    body.PhoneNumber.Add(p);
            }

            if (Emails != null)
            {
                body.Email = new List<Data.Email>();
                foreach (var e in Emails)
                    body.Email.Add(e);
            }

            if (ShouldProcess("Shared Contact", "New-GSharedContact"))
            {
                //WriteObject(contact.Get(Domain, Id));
                WriteObject(contact.Insert(body, Domain));
            }
        }
    }

    #region New Contact Objects
    [Cmdlet(VerbsCommon.New, "GSharedContactEmailObj",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGSharedContactEmailObj : PSCmdlet
    {
        public enum EmailRelEnum
        {
            home, other, work
        }

        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Address { get; set; }

        [Parameter(Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Label { get; set; }

        [Parameter(Position = 3,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public EmailRelEnum? Rel { get; set; }

        [Parameter(Position = 4,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? Primary { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Email() { Address = this.Address };

            if (!string.IsNullOrWhiteSpace(DisplayName)) body.DisplayName = this.DisplayName;

            if (!string.IsNullOrWhiteSpace(Label)) body.Label = this.Label;

            if (Rel.HasValue)
                body.Rel = "http://schemas.google.com/g/2005#" + this.Rel.Value.ToString();

            if (Primary.HasValue) body.Primary = this.Primary.Value;

            if (ShouldProcess("Shared Contact Email Object", "New-GSharedContactEmailObj"))
            {
                WriteObject(body);
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GSharedContactExtendedPropertyObj",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGSharedContactExtendedPropertyObj : PSCmdlet
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Value { get; set; }

        [Parameter(Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Realm { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.ExtendedProperty() { Name = this.Name };

            if (!string.IsNullOrWhiteSpace(Value)) body.Value = this.Value;

            if (!string.IsNullOrWhiteSpace(Realm)) body.Realm = this.Realm;

            if (ShouldProcess("Shared Contact ExtendedPropertyObj", "New-GSharedContactExtendedPropertyObj"))
            {
                WriteObject(body);
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GSharedContactImObj",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGSharedContactImObj : PSCmdlet
    {
        public enum ImRelEnum
        {
            home, netmeeting, other, work
        }

        public enum ImProtocolEnum
        {
            AIM, MSN, YAHOO, SKYPE, QQ, GOOGLE_TALK, ICQ, JABBER
        }

        #region Properties
        [Parameter(Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Address { get; set; }

        [Parameter(Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Label { get; set; }

        [Parameter(Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public ImRelEnum? Rel { get; set; }

        [Parameter(Position = 3,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public ImProtocolEnum? Protocol { get; set; }

        [Parameter(Position = 4,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? Primary { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Im() { Address = this.Address };

            if (!string.IsNullOrWhiteSpace(Label)) body.Label = this.Label;

            if (Rel.HasValue) body.Rel = "http://schemas.google.com/g/2005#" + this.Rel.Value.ToString();

            if (Protocol.HasValue) body.Protocol = this.Protocol.Value.ToString();

            if (Primary.HasValue) body.Primary = this.Primary.Value;

            if (ShouldProcess("Shared Contact ImObj", "New-GSharedContactImObj"))
            {
                WriteObject(body);
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GSharedContactNameObj",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGSharedContactNameObj : PSCmdlet
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string GivenName { get; set; }

        [Parameter(Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string AdditionalName { get; set; }

        [Parameter(Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string FamilyName { get; set; }

        [Parameter(Position = 3,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string NamePrefix { get; set; }

        [Parameter(Position = 4,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string NameSuffix { get; set; }

        [Parameter(Position = 5,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string FullName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Name();

            if (!string.IsNullOrWhiteSpace(GivenName))
                body.GivenName = this.GivenName;

            if (!string.IsNullOrWhiteSpace(AdditionalName))
                body.AdditionalName = this.AdditionalName;

            if (!string.IsNullOrWhiteSpace(FamilyName))
                body.FamilyName = this.FamilyName;

            if (!string.IsNullOrWhiteSpace(NamePrefix))
                body.NamePrefix = this.NamePrefix;

            if (!string.IsNullOrWhiteSpace(NameSuffix))
                body.NameSuffix = this.NameSuffix;

            if (!string.IsNullOrWhiteSpace(FullName))
                body.FullName = this.FullName;

            if (ShouldProcess("Shared Contact Name Obj", "New-GSharedContactNameObj"))
            {
                WriteObject(body);
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GSharedContactOrgObj",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGSharedContactOrgObj : PSCmdlet
    {
        public enum OrgRelEnum { other, work }

        #region Properties
        [Parameter(Position = 0,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Label { get; set; }

        [Parameter(Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string OrgDepartment { get; set; }

        [Parameter(Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string OrgJobDescription { get; set; }

        [Parameter(Position = 3,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string OrgName { get; set; }

        [Parameter(Position = 4,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string OrgSymbol { get; set; }

        [Parameter(Position = 5,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string OrgTitle { get; set; }

        [Parameter(Position = 6,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? Primary { get; set; }

        [Parameter(Position = 7,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public OrgRelEnum? Rel { get; set; }

        [Parameter(Position = 8,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public Data.Where Where { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Organization();

            if (!string.IsNullOrWhiteSpace(Label)) body.Label = this.Label;

            if (!string.IsNullOrWhiteSpace(OrgDepartment)) body.OrgDepartment = this.OrgDepartment;

            if (!string.IsNullOrWhiteSpace(OrgJobDescription)) body.OrgJobDescription = this.OrgJobDescription;

            if (!string.IsNullOrWhiteSpace(OrgName)) body.OrgName = this.OrgName;

            if (!string.IsNullOrWhiteSpace(OrgSymbol)) body.OrgSymbol = this.OrgSymbol;

            if (!string.IsNullOrWhiteSpace(OrgTitle)) body.OrgTitle = this.OrgTitle;

            if (Primary.HasValue) body.Primary = this.Primary.Value;

            if (Rel.HasValue) body.Rel = "http://schemas.google.com/g/2005#" + this.Rel.Value.ToString();

            if (Where != null) body.Where = this.Where;

            if (ShouldProcess("Shared Contact OrgObj", "New-GSharedContactOrgObj"))
            {
                WriteObject(body);
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GSharedContactPhoneNumberObj",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGSharedContactPhoneNumberObj : PSCmdlet
    {
        public enum PhoneNumberRelEnum
	    {
            assistant, callback, car, company_main, fax, home, home_fax, isdn, main, mobile, other, other_fax, pager, radio, telex, tty_tdd, work, work_fax, work_mobile, work_pager
	    }

        #region Properties
        [Parameter(Position = 0,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Label { get; set; }

        [Parameter(Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public PhoneNumberRelEnum? Rel { get; set; }

        [Parameter(Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Uri { get; set; }

        [Parameter(Position = 3,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? Primary { get; set; }

        [Parameter(Position = 4,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Text { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.PhoneNumber() { Text = this.Text };

            if (!string.IsNullOrWhiteSpace(Label)) body.Label = this.Label;

            if (Rel.HasValue) body.Rel = "http://schemas.google.com/g/2005#" + this.Rel.ToString();

            if (!string.IsNullOrWhiteSpace(Uri)) body.Uri = this.Uri;

            if (Primary.HasValue) body.Primary = this.Primary.Value;

            if (ShouldProcess("Shared Contact PhoneNumber Obj", "New-GSharedContactPhoneNumberObj"))
            {
                WriteObject(body);
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GSharedContactPostalAddressObj",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGSharedContactPostalAddressObj : PSCmdlet
    {
        public enum PostalRelEnum { work, home, other }

        #region Properties
        [Parameter(Position = 0,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public PostalRelEnum? Rel { get; set; }

        [Parameter(Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string MailClass { get; set; }

        [Parameter(Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Usage { get; set; }

        [Parameter(Position = 3,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Label { get; set; }

        [Parameter(Position = 4,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? Primary { get; set; }

        [Parameter(Position = 5,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Agent { get; set; }

        [Parameter(Position = 6,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Housename { get; set; }

        [Parameter(Position = 7,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Street { get; set; }

        [Parameter(Position = 8,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string PoBox { get; set; }

        [Parameter(Position = 9,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Neighborhood { get; set; }

        [Parameter(Position = 10,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string City { get; set; }

        [Parameter(Position = 11,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Subregion { get; set; }

        [Parameter(Position = 12,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Region { get; set; }

        [Parameter(Position = 13,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Postcode { get; set; }

        [Parameter(Position = 14,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Country { get; set; }

        [Parameter(Position = 15,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string FormattedAddress { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.StructuredPostalAddress();

            if (Rel.HasValue) body.Rel = "http://schemas.google.com/g/2005#" + this.Rel.ToString();

            if (!string.IsNullOrWhiteSpace(MailClass)) body.MailClass = this.MailClass;

            if (!string.IsNullOrWhiteSpace(Usage)) body.Usage = this.Usage;

            if (!string.IsNullOrWhiteSpace(Label)) body.Label = this.Label;

            if (Primary.HasValue) body.Primary = this.Primary.Value;

            if (!string.IsNullOrWhiteSpace(Agent)) body.Agent = this.Agent;

            if (!string.IsNullOrWhiteSpace(Housename)) body.Housename = this.Housename;

            if (!string.IsNullOrWhiteSpace(Street)) body.Street = this.Street;

            if (!string.IsNullOrWhiteSpace(PoBox)) body.Pobox = this.PoBox;

            if (!string.IsNullOrWhiteSpace(Neighborhood)) body.Neighborhood = this.Neighborhood;

            if (!string.IsNullOrWhiteSpace(City)) body.City = this.City;

            if (!string.IsNullOrWhiteSpace(Subregion)) body.Subregion = this.Subregion;

            if (!string.IsNullOrWhiteSpace(Region)) body.Region = this.Region;

            if (!string.IsNullOrWhiteSpace(Postcode)) body.Postcode = this.Postcode;

            if (!string.IsNullOrWhiteSpace(Country)) body.Country = this.Country;

            if (!string.IsNullOrWhiteSpace(FormattedAddress)) body.FormattedAddress = this.FormattedAddress;

            if (ShouldProcess("Shared Contact PostalAddressObj", "New-GSharedContactPostalAddressObj"))
            {
                WriteObject(body);
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GSharedContactWhereObj",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGSharedContactWhereObj : PSCmdlet
    {
        public enum WhereRelEnum { @event, alternate, parking}

        #region Properties
        [Parameter(Position = 0,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Label { get; set; }

        [Parameter(Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public WhereRelEnum? Rel { get; set; }

        [Parameter(Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string ValueString { get; set; }

        [Parameter(Position = 3,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public Data.EntryLink EntryLink { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Where();

            if (!string.IsNullOrWhiteSpace(Label)) body.Label = this.Label;

            if (Rel.HasValue)
                switch (Rel.Value)
                {
                    case WhereRelEnum.@event:
                        body.Rel = "http://schemas.google.com/g/2005#event";
                        break;
                    case WhereRelEnum.alternate:
                        body.Rel = "http://schemas.google.com/g/2005#event.alternate";
                        break;
                    case WhereRelEnum.parking:
                        body.Rel = "http://schemas.google.com/g/2005#event.parking";
                        break;
                }

            if (!string.IsNullOrWhiteSpace(ValueString)) body.ValueString = this.ValueString;

            if (EntryLink != null) body.EntryLink = this.EntryLink;

            if (ShouldProcess("Shared Contact WhereObj", "New-GSharedContactWhereObj"))
            {
                WriteObject(body);
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GSharedContactEntryLinkObj",
        SupportsShouldProcess = true,
          HelpUri = @"")]
    public class NewGSharedContactEntryLinkObj : PSCmdlet
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Href { get; set; }

        [Parameter(Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? ReadOnly { get; set; }

        [Parameter(Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Rel { get; set; }

        [Parameter(Position = 3,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public Data.Contact Entry { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.EntryLink();

            if (!string.IsNullOrWhiteSpace(Href)) body.Href = this.Href;

            if (ReadOnly.HasValue) body.ReadOnly__ = this.ReadOnly.Value;

            if (!string.IsNullOrWhiteSpace(Rel)) body.Rel = this.Rel;

            if (Entry != null) body.Entry = this.Entry;

            if (ShouldProcess("Shared Contact EntryLinkObj", "New-GSharedContactEntryLinkObj"))
            {
                WriteObject(body);
            }
        }
    }

    #endregion  
    #endregion

    [Cmdlet(VerbsCommon.Set, "GSharedContact",
        SupportsShouldProcess = true,
          HelpUri = @"",
          DefaultParameterSetName = "all")]
    public class SetGSharedContact : SharedcontactsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline=true)]
        [ValidateNotNullOrEmpty]
        public Data.Contact ContactObj { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            string editUrl = ContactObj.Links.Where(x => x.Rel == ("link_edit")).Select(x => x.Href).First();
            
            if (!string.IsNullOrWhiteSpace(editUrl) && !string.IsNullOrWhiteSpace(ContactObj.Id))
            {
                string id = ContactObj.Id.Split('/').Last();
                string version = editUrl.Split('/').Last();

                if (ShouldProcess("Shared Contact", "Set-GSharedContact"))
                {
                    WriteObject(contact.Update(this.ContactObj, Domain, id, version));
                }
            }
            else
            {
                WriteError(new ErrorRecord(null, (new Exception(
                    "Contact must have an edit URL."))));
            }
        }
    }

    [Cmdlet(VerbsCommon.Remove, "GSharedContact",
        SupportsShouldProcess = true,
          HelpUri = @"",
          DefaultParameterSetName = "all")]
    public class RemoveGSharedContact : SharedcontactsBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Data.Contact ContactObj { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            string editUrl = ContactObj.Links.Where(x => x.Rel == ("link_edit")).Select(x => x.Href).First();

            if (!string.IsNullOrWhiteSpace(editUrl) && !string.IsNullOrWhiteSpace(ContactObj.Id))
            {
                string id = ContactObj.Id.Split('/').Last();
                string version = editUrl.Split('/').Last();

                if (ShouldProcess("Shared Contact", "Remove-GSharedContact"))
                {
                    contact.Delete(Domain, id, version);
                }
            }
            else
            {
                WriteError(new ErrorRecord(null, (new Exception(
                    "Contact must have an edit URL."))));
            }
        }
    }
}