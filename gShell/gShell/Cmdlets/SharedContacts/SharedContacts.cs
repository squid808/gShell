using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

using Google.Apis.admin.Sharedcontacts.sharedcontacts_v3;
using Data = Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data;

using gSharedContacts = gShell.dotNet.Sharedcontacts;

namespace gShell.Cmdlets.Sharedcontacts
{
    public abstract class SharedcontactsCmdletBase : SharedcontactsBase
    {
        #region Parameters
        /// <summary>
        /// <para type="description">The target domain for this shared contacts cmdlet.</para>
        /// </summary>
        [Parameter(
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The target domain for this shared contacts cmdlet.")]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }
        #endregion

        protected override void BeginProcessing()
        {
            var secrets = CheckForClientSecrets();
            if (secrets != null)
            {
                var scopeAuthObj = EnsureScopesExist(GAuthId, Scopes);
                ServiceWrapperDictionary[mainBaseType].BuildService(Authenticate(scopeAuthObj, secrets));

                GWriteProgress = new gWriteProgress(WriteProgress);
            }
            else
            {
                WriteError(new ErrorRecord(null, (new Exception(
                    "Client Secrets must be set before running cmdlets. Run 'Get-Help "
                    + "Set-gShellClientSecrets -online' for more information."))));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Create a new shared contact email object.</para>
    /// <para type="description">Create a new shared contact email object.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Shared Contacts API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GSharedContactEmailObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GSharedContactEmailObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GSharedContactEmailObj",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GSharedContactEmailObj")]
    public class NewGSharedContactEmailObjCommand : PSCmdlet
    {
        public enum EmailRelEnum
        {
            home, other, work
        }

        #region Properties
        /// <summary>
        /// <para type="description">Email address.</para>
        /// </summary>
        [Parameter(HelpMessage = "Email address.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Address { get; set; }

        /// <summary>
        /// <para type="description">A display name of the entity (e.g. a person) the email address belongs to.</para>
        /// </summary>
        [Parameter(HelpMessage = "A display name of the entity (e.g. a person) the email address belongs to.",
            Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        /// <summary>
        /// <para type="description">A simple string value used to name this email address. It allows UIs to display a label such as "Work", "Personal", "Preferred", etc.</para>
        /// </summary>
        [Parameter(HelpMessage = "A simple string value used to name this email address. It allows UIs to display a label such as \"Work\", \"Personal\", \"Preferred\", etc.",
            Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Label { get; set; }

        /// <summary>
        /// <para type="description">A programmatic value that identifies the type of email.</para>
        /// </summary>
        [Parameter(HelpMessage = "A programmatic value that identifies the type of email.",
            Position = 3,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public EmailRelEnum? Rel { get; set; }

        /// <summary>
        /// <para type="description">When multiple email extensions appear in a contact kind, indicates which is primary. At most one email may be primary. Default value is "false".</para>
        /// </summary>
        [Parameter(HelpMessage = "When multiple email extensions appear in a contact kind, indicates which is primary. At most one email may be primary. Default value is \"false\".",
            Position = 4,
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

    /// <summary>
    /// <para type="synopsis">Create a new shared contact extended property object.</para>
    /// <para type="description">Create a new shared contact extended property object.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Shared Contacts API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GSharedContactExtendedPropertyObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GSharedContactExtendedPropertyObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GSharedContactExtendedPropertyObj",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GSharedContactExtendedPropertyObj")]
    public class NewGSharedContactExtendedPropertyObjCommand : PSCmdlet
    {
        #region Properties
        /// <summary>
        /// <para type="description">Specifies the name of the property expressed as a URI. Extended property URIs usually follow the {schema}#{local-name} convention.</para>
        /// </summary>
        [Parameter(HelpMessage = "Specifies the name of the property expressed as a URI. Extended property URIs usually follow the {schema}#{local-name} convention.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// <para type="description">Property value.</para>
        /// </summary>
        [Parameter(HelpMessage = "Property value.",
            Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Value { get; set; }

        /// <summary>
        /// <para type="description">Used by some APIs to specify where the extended property applies.</para>
        /// </summary>
        [Parameter(HelpMessage = "Used by some APIs to specify where the extended property applies.",
            Position = 2,
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

    /// <summary>
    /// <para type="synopsis">Create a new shared contact im object.</para>
    /// <para type="description">Create a new shared contact im object.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Shared Contacts API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GSharedContactImObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GSharedContactImObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GSharedContactImObj",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GSharedContactImObj")]
    public class NewGSharedContactImObjCommand : PSCmdlet
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
        /// <summary>
        /// <para type="description">IM address.</para>
        /// </summary>
        [Parameter(HelpMessage = "IM address.",
            Position = 0,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Address { get; set; }

        /// <summary>
        /// <para type="description">A simple string value used to name this IM address. It allows UIs to display a label such as "Work", "Personal", "Preferred", etc.</para>
        /// </summary>
        [Parameter(HelpMessage = "A simple string value used to name this IM address. It allows UIs to display a label such as \"Work\", \"Personal\", \"Preferred\", etc.",
            Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Label { get; set; }

        /// <summary>
        /// <para type="description">A programmatic value that identifies the type of IM.</para>
        /// </summary>
        [Parameter(HelpMessage = "A programmatic value that identifies the type of IM.",
            Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public ImRelEnum? Rel { get; set; }

        /// <summary>
        /// <para type="description">Identifies the IM network. The value may be either one of the standard values or a URI identifying a proprietary IM network.</para>
        /// </summary>
        [Parameter(HelpMessage = "Identifies the IM network. The value may be either one of the standard values or a URI identifying a proprietary IM network.",
            Position = 3,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public ImProtocolEnum? Protocol { get; set; }

        /// <summary>
        /// <para type="description">When multiple IM extensions appear in a contact kind, indicates which is primary. At most one IM may be primary. Default value is "false".</para>
        /// </summary>
        [Parameter(HelpMessage = "When multiple IM extensions appear in a contact kind, indicates which is primary. At most one IM may be primary. Default value is \"false\".",
            Position = 4,
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

    /// <summary>
    /// <para type="synopsis">Create a new shared contact name object.</para>
    /// <para type="description">Create a new shared contact name object.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Shared Contacts API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GSharedContactNameObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GSharedContactNameObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GSharedContactNameObj",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GSharedContactNameObj")]
    public class NewGSharedContactNameObjCommand : PSCmdlet
    {
        #region Properties
        /// <summary>
        /// <para type="description">Person's given name.</para>
        /// </summary>
        [Parameter(HelpMessage = "Person's given name.",
            Position = 0,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string GivenName { get; set; }

        /// <summary>
        /// <para type="description">Additional name of the person, eg. middle name.</para>
        /// </summary>
        [Parameter(HelpMessage = "Additional name of the person, eg. middle name.",
            Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string AdditionalName { get; set; }

        /// <summary>
        /// <para type="description">Person's family name.</para>
        /// </summary>
        [Parameter(HelpMessage = "Person's family name.",
            Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string FamilyName { get; set; }

        /// <summary>
        /// <para type="description">Honorific prefix, eg. 'Mr' or 'Mrs'.</para>
        /// </summary>
        [Parameter(HelpMessage = "Honorific prefix, eg. 'Mr' or 'Mrs'.",
            Position = 3,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string NamePrefix { get; set; }

        /// <summary>
        /// <para type="description">Honorific suffix, eg. 'san' or 'III'.</para>
        /// </summary>
        [Parameter(HelpMessage = "Honorific suffix, eg. 'san' or 'III'.",
            Position = 4,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string NameSuffix { get; set; }

        /// <summary>
        /// <para type="description">Unstructured representation of the name.</para>
        /// </summary>
        [Parameter(HelpMessage = "Unstructured representation of the name.",
            Position = 5,
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

    /// <summary>
    /// <para type="synopsis">Create a new shared contact org object.</para>
    /// <para type="description">Create a new shared contact org object.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Shared Contacts API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GSharedContactOrgObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GSharedContactOrgObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GSharedContactOrgObj",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GSharedContactOrgObj")]
    public class NewGSharedContactOrgObjCommand : PSCmdlet
    {
        public enum OrgRelEnum { other, work }

        #region Properties
        /// <summary>
        /// <para type="description">A simple string value used to name this organization. It allows UIs to display a label such as "Work", "Volunteer", "Professional Society", etc.</para>
        /// </summary>
        [Parameter(HelpMessage = "A simple string value used to name this organization. It allows UIs to display a label such as \"Work\", \"Volunteer\", \"Professional Society\", etc.",
            Position = 0,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Label { get; set; }

        /// <summary>
        /// <para type="description">Specifies a department within the organization.</para>
        /// </summary>
        [Parameter(HelpMessage = "Specifies a department within the organization.",
            Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string OrgDepartment { get; set; }

        /// <summary>
        /// <para type="description">Description of a job within the organization.</para>
        /// </summary>
        [Parameter(HelpMessage = "Description of a job within the organization.",
            Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string OrgJobDescription { get; set; }

        /// <summary>
        /// <para type="description">The name of the organization.</para>
        /// </summary>
        [Parameter(HelpMessage = "The name of the organization.",
            Position = 3,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string OrgName { get; set; }

        /// <summary>
        /// <para type="description">Symbol of the organization.</para>
        /// </summary>
        [Parameter(HelpMessage = "Symbol of the organization.",
            Position = 4,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string OrgSymbol { get; set; }

        /// <summary>
        /// <para type="description">The title of a person within the organization.</para>
        /// </summary>
        [Parameter(HelpMessage = "The title of a person within the organization.",
            Position = 5,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string OrgTitle { get; set; }

        /// <summary>
        /// <para type="description">When multiple organizations extensions appear in a contact kind, indicates which is primary. At most one organization may be primary. Default value is "false".</para>
        /// </summary>
        [Parameter(HelpMessage = "When multiple organizations extensions appear in a contact kind, indicates which is primary. At most one organization may be primary. Default value is \"false\".",
            Position = 6,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? Primary { get; set; }

        /// <summary>
        /// <para type="description">A programmatic value that identifies the type of organization.</para>
        /// </summary>
        [Parameter(HelpMessage = "A programmatic value that identifies the type of organization.",
            Position = 7,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public OrgRelEnum? Rel { get; set; }

        /// <summary>
        /// <para type="description">A place associated with the organization, e.g. office location.</para>
        /// </summary>
        [Parameter(HelpMessage = "A place associated with the organization, e.g. office location.",
            Position = 8,
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

    /// <summary>
    /// <para type="synopsis">Create a new shared contact phone number object.</para>
    /// <para type="description">Create a new shared contact phone number object.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Shared Contacts API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GSharedContactPhoneNumberObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GSharedContactPhoneNumberObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GSharedContactPhoneNumberObj",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GSharedContactPhoneNumberObj")]
    public class NewGSharedContactPhoneNumberObjCommand : PSCmdlet
    {
        public enum PhoneNumberRelEnum
        {
            assistant, callback, car, company_main, fax, home, home_fax, isdn, main, mobile, other, other_fax, pager, radio, telex, tty_tdd, work, work_fax, work_mobile, work_pager
        }

        #region Properties
        /// <summary>
        /// <para type="description">A simple string value used to name this phone number. In most cases, @label is not necessary as @rel uniquely identifies a number and allows UIs to display a proper label such as "Mobile", "Home", "Work", etc. However, in the case where one person has (for example) multiple mobile phones, this property can be used to disambiguate them.</para>
        /// </summary>
        [Parameter(HelpMessage = "A simple string value used to name this phone number. In most cases, @label is not necessary as @rel uniquely identifies a number and allows UIs to display a proper label such as \"Mobile\", \"Home\", \"Work\", etc. However, in the case where one person has (for example) multiple mobile phones, this property can be used to disambiguate them.",
            Position = 0,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Label { get; set; }

        /// <summary>
        /// <para type="description">A programmatic value that identifies the type of phone number</para>
        /// </summary>
        [Parameter(HelpMessage = "A programmatic value that identifies the type of phone number",
            Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public PhoneNumberRelEnum? Rel { get; set; }

        /// <summary>
        /// <para type="description">An optional "tel URI" used to represent the number in a formal way, useful for programmatic access, such as a VoIP/PSTN bridge. See RFC 3966 for more information on tel URIs.</para>
        /// </summary>
        [Parameter(HelpMessage = "An optional \"tel URI\" used to represent the number in a formal way, useful for programmatic access, such as a VoIP/PSTN bridge. See RFC 3966 for more information on tel URIs.",
            Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Uri { get; set; }

        /// <summary>
        /// <para type="description">When multiple phone number extensions appear in a contact kind, indicates which is primary. At most one phone number may be primary. Default value is "false".</para>
        /// </summary>
        [Parameter(HelpMessage = "When multiple phone number extensions appear in a contact kind, indicates which is primary. At most one phone number may be primary. Default value is \"false\".",
            Position = 3,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? Primary { get; set; }

        /// <summary>
        /// <para type="description">Human-readable phone number; may be in any telephone number format. Leading and trailing whitespace is insignificant. Newlines within the string are also insignificant, and may be removed or flattened out to a single space.</para>
        /// </summary>
        [Parameter(HelpMessage = "Human-readable phone number; may be in any telephone number format. Leading and trailing whitespace is insignificant. Newlines within the string are also insignificant, and may be removed or flattened out to a single space.",
            Position = 4,
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

    /// <summary>
    /// <para type="synopsis">Create a new shared contact postal address object.</para>
    /// <para type="description">Create a new shared contact postal address object.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Shared Contacts API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GSharedContactPostalAddressObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GSharedContactPostalAddressObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GSharedContactPostalAddressObj",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GSharedContactPostalAddressObj")]
    public class NewGSharedContactPostalAddressObjCommand : PSCmdlet
    {
        /// <summary>Type of the address.</summary>
        public enum PostalRelEnum
        {
            /// <summary>Work address. Unless other provided this is the default value.</summary>
            work,

            /// <summary>Home address.</summary>
            home,

            /// <summary>Any other type of address.</summary>
            other
        }

        #region Properties
        /// <summary>
        /// <para type="description">Type of the address. Unless specified work type is assumed.</para>
        /// </summary>
        [Parameter(HelpMessage = "Type of the address. Unless specified work type is assumed.",
            Position = 0,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public PostalRelEnum? Rel { get; set; }

        /// <summary>
        /// <para type="description">Classes of mail accepted at the address. Unless specified both is assumed.</para>
        /// </summary>
        [Parameter(HelpMessage = "Classes of mail accepted at the address. Unless specified both is assumed.",
            Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string MailClass { get; set; }

        /// <summary>
        /// <para type="description">The context in which this addess can be used. Local addresses may differ in layout from general addresses, and frequently use local script (as opposed to Latin script) as well, though local script is allowed in general addresses. Unless specified general usage is assumed.</para>
        /// </summary>
        [Parameter(HelpMessage = "The context in which this addess can be used. Local addresses may differ in layout from general addresses, and frequently use local script (as opposed to Latin script) as well, though local script is allowed in general addresses. Unless specified general usage is assumed.",
            Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Usage { get; set; }

        /// <summary>
        /// <para type="description">A general label for the address.</para>
        /// </summary>
        [Parameter(HelpMessage = "A general label for the address.",
            Position = 3,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Label { get; set; }

        /// <summary>
        /// <para type="description">Specifies the address as primary. Default value is false.</para>
        /// </summary>
        [Parameter(HelpMessage = "Specifies the address as primary. Default value is false.",
            Position = 4,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? Primary { get; set; }

        /// <summary>
        /// <para type="description">The agent who actually receives the mail. Used in work addresses. Also for 'in care of' or 'c/o'.</para>
        /// </summary>
        [Parameter(HelpMessage = "The agent who actually receives the mail. Used in work addresses. Also for 'in care of' or 'c/o'.",
            Position = 5,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Agent { get; set; }

        /// <summary>
        /// <para type="description">Used in places where houses or buildings have names (and not necessarily numbers), eg. "The Pillars".</para>
        /// </summary>
        [Parameter(HelpMessage = "Used in places where houses or buildings have names (and not necessarily numbers), eg. \"The Pillars\".",
            Position = 6,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Housename { get; set; }

        /// <summary>
        /// <para type="description">Can be street, avenue, road, etc. This element also includes the house number and room/apartment/flat/floor number.</para>
        /// </summary>
        [Parameter(HelpMessage = "Can be street, avenue, road, etc. This element also includes the house number and room/apartment/flat/floor number.",
            Position = 7,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Street { get; set; }

        /// <summary>
        /// <para type="description">Covers actual P.O. boxes, drawers, locked bags, etc. This is usually but not always mutually exclusive with street.</para>
        /// </summary>
        [Parameter(HelpMessage = "Covers actual P.O. boxes, drawers, locked bags, etc. This is usually but not always mutually exclusive with street.",
            Position = 8,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string PoBox { get; set; }

        /// <summary>
        /// <para type="description">This is used to disambiguate a street address when a city contains more than one street with the same name, or to specify a small place whose mail is routed through a larger postal town. In China it could be a county or a minor city.</para>
        /// </summary>
        [Parameter(HelpMessage = "This is used to disambiguate a street address when a city contains more than one street with the same name, or to specify a small place whose mail is routed through a larger postal town. In China it could be a county or a minor city.",
            Position = 9,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Neighborhood { get; set; }

        /// <summary>
        /// <para type="description">Can be city, village, town, borough, etc. This is the postal town and not necessarily the place of residence or place of business.</para>
        /// </summary>
        [Parameter(HelpMessage = "Can be city, village, town, borough, etc. This is the postal town and not necessarily the place of residence or place of business.",
            Position = 10,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string City { get; set; }

        /// <summary>
        /// <para type="description">Handles administrative districts such as U.S. or U.K. counties that are not used for mail addressing purposes. Subregion is not intended for delivery addresses.</para>
        /// </summary>
        [Parameter(HelpMessage = "Handles administrative districts such as U.S. or U.K. counties that are not used for mail addressing purposes. Subregion is not intended for delivery addresses.",
            Position = 11,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Subregion { get; set; }

        /// <summary>
        /// <para type="description">A state, province, county (in Ireland), Land (in Germany), departement (in France), etc.</para>
        /// </summary>
        [Parameter(HelpMessage = "A state, province, county (in Ireland), Land (in Germany), departement (in France), etc.",
            Position = 12,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Region { get; set; }

        /// <summary>
        /// <para type="description">Postal code. Usually country-wide, but sometimes specific to the city (e.g. "2" in "Dublin 2, Ireland" addresses).</para>
        /// </summary>
        [Parameter(HelpMessage = "Postal code. Usually country-wide, but sometimes specific to the city (e.g. \"2\" in \"Dublin 2, Ireland\" addresses).",
            Position = 13,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Postcode { get; set; }

        /// <summary>
        /// <para type="description">The name or code of the country.</para>
        /// </summary>
        [Parameter(HelpMessage = "The name or code of the country.",
            Position = 14,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Country { get; set; }

        /// <summary>
        /// <para type="description">The full, unstructured postal address.</para>
        /// </summary>
        [Parameter(HelpMessage = "The full, unstructured postal address.",
            Position = 15,
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

    /// <summary>
    /// <para type="synopsis">Create a new shared contact where object.</para>
    /// <para type="description">Create a new shared contact where object.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Shared Contacts API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GSharedContactWhereObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GSharedContactWhereObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GSharedContactWhereObj",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GSharedContactWhereObj")]
    public class NewGSharedContactWhereObjCommand : PSCmdlet
    {
        public enum WhereRelEnum { @event, alternate, parking }

        #region Properties
        /// <summary>
        /// <para type="description">Specifies a user-readable label to distinguish this location from other locations.</para>
        /// </summary>
        [Parameter(HelpMessage = "Specifies a user-readable label to distinguish this location from other locations.",
            Position = 0,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Label { get; set; }

        /// <summary>
        /// <para type="description">Specifies the relationship between the containing entity and the contained location.</para>
        /// </summary>
        [Parameter(HelpMessage = "Specifies the relationship between the containing entity and the contained location.",
            Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public WhereRelEnum? Rel { get; set; }

        /// <summary>
        /// <para type="description">A simple string value that can be used as a representation of this location.</para>
        /// </summary>
        [Parameter(HelpMessage = "A simple string value that can be used as a representation of this location.",
            Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string ValueString { get; set; }

        /// <summary>
        /// <para type="description">Entry representing location details. This entry should implement the Contact kind.</para>
        /// </summary>
        [Parameter(HelpMessage = "Entry representing location details. This entry should implement the Contact kind.",
            Position = 3,
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

    /// <summary>
    /// <para type="synopsis">Create a new shared contact entry link object.</para>
    /// <para type="description">Create a new shared contact entry link object.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Shared Contacts API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GSharedContactEntryLinkObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GSharedContactEntryLinkObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GSharedContactEntryLinkObj",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GSharedContactEntryLinkObj")]
    public class NewGSharedContactEntryLinkObjCommand : PSCmdlet
    {
        #region Properties
        /// <summary>
        /// <para type="description">Specifies the entry URI. If the nested entry is embedded and not linked, this attribute may be omitted.</para>
        /// </summary>
        [Parameter(HelpMessage = "Specifies the entry URI. If the nested entry is embedded and not linked, this attribute may be omitted.",
            Position = 0,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Href { get; set; }

        /// <summary>
        /// <para type="description">Specifies whether the contained entry is read-only. The default value is "false".</para>
        /// </summary>
        [Parameter(HelpMessage = "Specifies whether the contained entry is read-only. The default value is \"false\".",
            Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public bool? ReadOnly { get; set; }

        /// <summary>
        /// <para type="description">Specifies the link relation; allows the service to provide multiple types of entry links for a single entity.</para>
        /// </summary>
        [Parameter(HelpMessage = "Specifies the link relation; allows the service to provide multiple types of entry links for a single entity.",
            Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Rel { get; set; }

        /// <summary>
        /// <para type="description">Contents of the entry.</para>
        /// </summary>
        [Parameter(HelpMessage = "Contents of the entry.",
            Position = 3,
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
}

namespace gShell.Cmdlets.Sharedcontacts
{
    /// <summary>
    /// <para type="synopsis">Retrieve one or all shared contacts.</para>
    /// <para type="description">Retrieve one or all shared contacts.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Shared Contacts API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Get-GSharedContact -Id $SomeIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\> Get-GSharedContact -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GSharedContact">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GSharedContact",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GSharedContact",
          DefaultParameterSetName = "all")]
    public class GetGSharedContact : SharedcontactsCmdletBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">The id uri for a shared contact, e.g. https://www.google.com/m8/feeds/contacts/example.com/base/c9012de</para>
        /// </summary>
        [Parameter(HelpMessage = "The id uri for a shared contact, e.g. https://www.google.com/m8/feeds/contacts/example.com/base/c9012de",
            Position = 0,
            Mandatory = true,
            ParameterSetName = "one")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ParameterSetName = "all",
        HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }

        /// <summary>
        /// <para type="description">Include deleted contacts.</para>
        /// </summary>
        [Parameter(HelpMessage = "Include deleted contacts.",
            Position = 1,
            Mandatory = false,
            ParameterSetName = "all")]
        [ValidateNotNullOrEmpty]
        public bool? ShowDeleted { get; set; }

        /// <summary>
        /// <para type="description">The maximum results to retrieve.</para>
        /// </summary>
        [Parameter(HelpMessage = "The maximum results to retrieve.",
            Position = 2,
            Mandatory = false,
            ParameterSetName = "all")]
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

                    if (MaxResults.HasValue) properties.MaxResults = this.MaxResults.Value;

                    WriteObject(contact.List(Domain, properties).ContactsValue);
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Create a new shared contact.</para>
    /// <para type="description">Create a new shared contact.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Shared Contacts API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> New-GSharedContact</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GSharedContact">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GSharedContact",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GSharedContact")]
    public class NewGSharedContact : SharedcontactsCmdletBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">Notes about the contact.</para>
        /// </summary>
        [Parameter(HelpMessage = "Notes about the contact.",
            Position = 0,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Content { get; set; }

        /// <summary>
        /// <para type="description">A Shared Contact name object.</para>
        /// </summary>
        [Parameter(HelpMessage = "A Shared Contact name object.",
            Position = 1,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public Data.Name Name { get; set; }

        /// <summary>
        /// <para type="description">A collection of Shared Contact phone number objects.</para>
        /// </summary>
        [Parameter(HelpMessage = "A collection of Shared Contact phone number objects.",
            Position = 2,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public Data.PhoneNumber[] PhoneNumbers { get; set; }

        /// <summary>
        /// <para type="description">A collection of Shared Contact email objects.</para>
        /// </summary>
        [Parameter(HelpMessage = "A collection of Shared Contact email objects.",
            Position = 3,
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

    /// <summary>
    /// <para type="synopsis">Update a shared contact.</para>
    /// <para type="description">Update a shared contact.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Shared Contacts API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Set-GSharedContact -ContactObj $SomeContactObject</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GSharedContact">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GSharedContact",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GSharedContact",
          DefaultParameterSetName = "all")]
    public class SetGSharedContact : SharedcontactsCmdletBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">A Shared Contact object.</para>
        /// </summary>
        [Parameter(HelpMessage = "A Shared Contact object.",
            Position = 0,
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

    /// <summary>
    /// <para type="synopsis">Delete a shared contact.</para>
    /// <para type="description">Delete a shared contact.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Shared Contacts API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\> Remove-GSharedContact -ContactObj $SomeContactObject</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\> Get-GSharedContact -Id $SomeIdString | Remove-GSharedContact</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GSharedContact">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GSharedContact",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GSharedContact",
          DefaultParameterSetName = "all")]
    public class RemoveGSharedContact : SharedcontactsCmdletBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">A Google API Contact object to be deleted.</para>
        /// </summary>
        [Parameter(HelpMessage = "A Google API Contact object to be deleted.",
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Data.Contact ContactObj { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            string toRemoveTarget = "Shared Contact";
            
            if (Force || ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
			{
				try
				{
					WriteDebug("Attempting to remove " + toRemoveTarget + "...");

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
							
					WriteVerbose("Removal of " + toRemoveTarget + " completed without error.");
				}
				catch (Exception e)
				{
					WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, toRemoveTarget));
				}
			}
			else
			{
				WriteError(new ErrorRecord(new Exception("Deletion not confirmed"),
					"", ErrorCategory.InvalidData, toRemoveTarget));
			}
        }
    }
}