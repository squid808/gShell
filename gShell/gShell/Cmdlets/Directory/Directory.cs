using Google.Apis.admin.Directory.directory_v1;
using gShell.Cmdlets.Directory.GAUserProperty;
using gShell.dotNet.CustomSerializer.Json;
using gShell.dotNet.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Security;
using Data = Google.Apis.admin.Directory.directory_v1.Data;

namespace gShell.Cmdlets.Directory
{
    /// <summary>
    /// <para type="synopsis">Creates a new Directory API Alias object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a Alias object which may be required as a parameter for some other Cmdlets in the Directory API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.admin.Directory.directory_v1.Data.Alias</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GAAliasObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GAAliasObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GAAliasObj",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAAliasObj")]
    [OutputType(typeof(Data.Alias))]
    public class NewGAAliasObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">A alias email</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "A alias email")]
        public string AliasValue { get; set; }

        /// <summary>
        /// <para type="description">Unique id of the group (Read-only) Unique id of the user (Read-only)</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Unique id of the group (Read-only) Unique id of the user (Read-only)")]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">Group's primary email (Read-only) User's primary email (Read-only)</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Group's primary email (Read-only) User's primary email (Read-only)")]
        public string PrimaryEmail { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.admin.Directory.directory_v1.Data.Alias()
            {
                AliasValue = this.AliasValue,
                Id = this.Id,
                PrimaryEmail = this.PrimaryEmail,
            };

            if (ShouldProcess("Alias"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Directory API CalendarResource object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a CalendarResource object which may be required as a parameter for some other Cmdlets in the Directory API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.admin.Directory.directory_v1.Data.CalendarResource</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GACalendarResourceObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GACalendarResourceObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GACalendarResourceObj",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GACalendarResourceObj")]
    [OutputType(typeof(Data.CalendarResource))]
    public class NewGACalendarResourceObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">ETag of the resource.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "ETag of the resource.")]
        public string Etags { get; set; }

        /// <summary>
        /// <para type="description">The brief description of the calendar resource.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The brief description of the calendar resource.")]
        public string ResourceDescription { get; set; }

        /// <summary>
        /// <para type="description">The read-only email ID for the calendar resource. Generated as part of creating a new calendar resource.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The read-only email ID for the calendar resource. Generated as part of creating a new calendar resource.")]
        public string ResourceEmail { get; set; }

        /// <summary>
        /// <para type="description">The unique ID for the calendar resource.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The unique ID for the calendar resource.")]
        public string ResourceId { get; set; }

        /// <summary>
        /// <para type="description">The name of the calendar resource. For example, Training Room 1A</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The name of the calendar resource. For example, Training Room 1A")]
        public string ResourceName { get; set; }

        /// <summary>
        /// <para type="description">The type of the calendar resource. Used for grouping resources in the calendar user interface.</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The type of the calendar resource. Used for grouping resources in the calendar user interface.")]
        public string ResourceType { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.CalendarResource()
            {
                Etags = this.Etags,
                ResourceDescription = this.ResourceDescription,
                ResourceEmail = this.ResourceEmail,
                ResourceId = this.ResourceId,
                ResourceName = this.ResourceName,
                ResourceType = this.ResourceType,
            };

            if (ShouldProcess("CalendarResource"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Directory API Customer object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a Customer object which may be required as a parameter for some other Cmdlets in the Directory API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.admin.Directory.directory_v1.Data.Customer</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GACustomerObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GACustomerObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GACustomerObj",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GACustomerObj")]
    [OutputType(typeof(Google.Apis.admin.Directory.directory_v1.Data.Customer))]
    public class NewGACustomerObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">The customer's secondary contact email address. This email address cannot be on the same domain as the customerDomain</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The customer's secondary contact email address. This email address cannot be on the same domain as the customerDomain")]
        public string AlternateEmail { get; set; }

        /// <summary>
        /// <para type="description">The customer's creation time (Readonly)</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The customer's creation time (Readonly)")]
        public DateTime? CustomerCreationTime { get; set; }

        /// <summary>
        /// <para type="description">The customer's primary domain name string. Do not include the www prefix when creating a new customer.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The customer's primary domain name string. Do not include the www prefix when creating a new customer.")]
        public string CustomerDomain { get; set; }

        /// <summary>
        /// <para type="description">The unique ID for the customer's Google account. (Readonly)</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The unique ID for the customer's Google account. (Readonly)")]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">The customer's ISO 639-2 language code. The default value is en-US</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The customer's ISO 639-2 language code. The default value is en-US")]
        public string Language { get; set; }

        /// <summary>
        /// <para type="description">The customer's contact phone number in E.164 format.</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The customer's contact phone number in E.164 format.")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// <para type="description">The customer's postal address information.</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The customer's postal address information.")]
        public Data.CustomerPostalAddress PostalAddress { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.admin.Directory.directory_v1.Data.Customer()
            {
                AlternateEmail = this.AlternateEmail,
                CustomerCreationTime = this.CustomerCreationTime,
                CustomerDomain = this.CustomerDomain,
                Id = this.Id,
                Language = this.Language,
                PhoneNumber = this.PhoneNumber,
                PostalAddress = this.PostalAddress,
            };

            if (ShouldProcess("Customer"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Directory API DomainAlias object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a DomainAlias object which may be required as a parameter for some other Cmdlets in the Directory API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.admin.Directory.directory_v1.Data.DomainAlias</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GADomainAliasObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GADomainAliasObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GADomainAliasObj",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GADomainAliasObj")]
    [OutputType(typeof(Google.Apis.admin.Directory.directory_v1.Data.DomainAlias))]
    public class NewGADomainAliasObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">The creation time of the domain alias. (Read-only).</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The creation time of the domain alias. (Read-only).")]
        public long? CreationTime { get; set; }

        /// <summary>
        /// <para type="description">The domain alias name.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The domain alias name.")]
        public string DomainAliasName { get; set; }

        /// <summary>
        /// <para type="description">The parent domain name that the domain alias is associated with. This can either be a primary or secondary domain name within a customer.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The parent domain name that the domain alias is associated with. This can either be a primary or secondary domain name within a customer.")]
        public string ParentDomainName { get; set; }

        /// <summary>
        /// <para type="description">Indicates the verification state of a domain alias. (Read-only)</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Indicates the verification state of a domain alias. (Read-only)")]
        public bool? Verified { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.DomainAlias()
            {
                CreationTime = this.CreationTime,
                DomainAliasName = this.DomainAliasName,
                ParentDomainName = this.ParentDomainName,
                Verified = this.Verified,
            };

            if (ShouldProcess("DomainAlias"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Directory API Domains object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a Domains object which may be required as a parameter for some other Cmdlets in the Directory API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.admin.Directory.directory_v1.Data.Domains</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GADomainsObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GADomainsObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GADomainsObj",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GADomainsObj")]
    [OutputType(typeof(Data.Domains))]
    public class NewGADomainsObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">Creation time of the domain. (Read-only).</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Creation time of the domain. (Read-only).")]
        public long CreationTime { get; set; }

        /// <summary>
        /// <para type="description">List of domain alias objects. (Read-only)</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "List of domain alias objects. (Read-only)")]
        public IList<Data.DomainAlias> DomainAliases { get; set; }

        /// <summary>
        /// <para type="description">The domain name of the customer.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The domain name of the customer.")]
        public string DomainName { get; set; }

        /// <summary>
        /// <para type="description">Indicates if the domain is a primary domain (Read-only).</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Indicates if the domain is a primary domain (Read-only).")]
        public bool? IsPrimary { get; set; }

        /// <summary>
        /// <para type="description">Indicates the verification state of a domain. (Read-only).</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Indicates the verification state of a domain. (Read-only).")]
        public bool? Verified { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Domains()
            {
                CreationTime = this.CreationTime,
                DomainAliases = this.DomainAliases,
                DomainName = this.DomainName,
                IsPrimary = this.IsPrimary,
                Verified = this.Verified,
            };

            if (ShouldProcess("Domains"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Directory API CustomerPostalAddress object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a CustomerPostalAddress object which may be required as a parameter for some other Cmdlets in the Directory API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.admin.Directory.directory_v1.Data.CustomerPostalAddress</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GACustomerPostalAddressObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GACustomerPostalAddressObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GACustomerPostalAddressObj",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GACustomerPostalAddressObj")]
    [OutputType(typeof(Google.Apis.admin.Directory.directory_v1.Data.CustomerPostalAddress))]
    public class NewGACustomerPostalAddressObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">A customer's physical address. The address can be composed of one to three lines.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "A customer's physical address. The address can be composed of one to three lines.")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// <para type="description">Address line 2 of the address.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Address line 2 of the address.")]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// <para type="description">Address line 3 of the address.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Address line 3 of the address.")]
        public string AddressLine3 { get; set; }

        /// <summary>
        /// <para type="description">The customer contact's name.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The customer contact's name.")]
        public string ContactName { get; set; }

        /// <summary>
        /// <para type="description">This is a required property. For countryCode information see the ISO 3166 country code elements.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "This is a required property. For countryCode information see the ISO 3166 country code elements.")]
        public string CountryCode { get; set; }

        /// <summary>
        /// <para type="description">Name of the locality. An example of a locality value is the city of San Francisco.</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of the locality. An example of a locality value is the city of San Francisco.")]
        public string Locality { get; set; }

        /// <summary>
        /// <para type="description">The company or company division name.</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The company or company division name.")]
        public string OrganizationName { get; set; }

        /// <summary>
        /// <para type="description">The postal code. A postalCode example is a postal zip code such as 10009. This is in accordance with - http://portablecontacts.net/draft-spec.html#address_element.</para>
        /// </summary>
        [Parameter(Position = 7,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The postal code. A postalCode example is a postal zip code such as 10009. This is in accordance with - http://portablecontacts.net/draft-spec.html#address_element.")]
        public string PostalCode { get; set; }

        /// <summary>
        /// <para type="description">Name of the region. An example of a region value is NY for the state of New York.</para>
        /// </summary>
        [Parameter(Position = 8,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of the region. An example of a region value is NY for the state of New York.")]
        public string Region { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.admin.Directory.directory_v1.Data.CustomerPostalAddress()
            {
                AddressLine1 = this.AddressLine1,
                AddressLine2 = this.AddressLine2,
                AddressLine3 = this.AddressLine3,
                ContactName = this.ContactName,
                CountryCode = this.CountryCode,
                Locality = this.Locality,
                OrganizationName = this.OrganizationName,
                PostalCode = this.PostalCode,
                Region = this.Region,
            };

            if (ShouldProcess("CustomerPostalAddress"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Directory API Role object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a Role object which may be required as a parameter for some other Cmdlets in the Directory API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.admin.Directory.directory_v1.Data.Role</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GARoleObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GARoleObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GARoleObj",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GARoleObj")]
    [OutputType(typeof(Google.Apis.admin.Directory.directory_v1.Data.Role))]
    public class NewGARoleObjCommand : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">Returns true if the role is a super admin role.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Returns true if the role is a super admin role.")]
        public System.Nullable<bool> IsSuperAdminRole { get; set; }

        /// <summary>
        /// <para type="description">Returns true if this is a pre-defined system role.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Returns true if this is a pre-defined system role.")]
        public System.Nullable<bool> IsSystemRole { get; set; }

        /// <summary>
        /// <para type="description">A short description of the role.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "A short description of the role.")]
        public string RoleDescription { get; set; }

        /// <summary>
        /// <para type="description">ID of the role.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "ID of the role.")]
        public System.Nullable<long> RoleId { get; set; }

        /// <summary>
        /// <para type="description">Name of the role.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of the role.")]
        public string RoleName { get; set; }

        /// <summary>
        /// <para type="description">The set of privileges that are granted to this role.</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The set of privileges that are granted to this role.")]
        public IList<Data.Role.RolePrivilegesData> RolePrivileges { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.Role()
            {
                IsSuperAdminRole = this.IsSuperAdminRole,
                IsSystemRole = this.IsSystemRole,
                RoleDescription = this.RoleDescription,
                RoleId = this.RoleId,
                RoleName = this.RoleName,
                RolePrivileges = this.RolePrivileges,
            };

            if (ShouldProcess("Role"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Directory API RoleAssignment object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a RoleAssignment object which may be required as a parameter for some other Cmdlets in the Directory API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.admin.Directory.directory_v1.Data.RoleAssignment</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GARoleAssignmentObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GARoleAssignmentObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GARoleAssignmentObj",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GARoleAssignmentObj")]
    [OutputType(typeof(Data.RoleAssignment))]
    public class NewGARoleAssignmentObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">The unique ID of the user this role is assigned to.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The unique ID of the user this role is assigned to.")]
        public string AssignedTo { get; set; }

        /// <summary>
        /// <para type="description">If the role is restricted to an organization unit, this contains the ID for the organization unit the exercise of this role is restricted to.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "If the role is restricted to an organization unit, this contains the ID for the organization unit the exercise of this role is restricted to.")]
        public string OrgUnitId { get; set; }

        /// <summary>
        /// <para type="description">ID of this roleAssignment.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "ID of this roleAssignment.")]
        public long? RoleAssignmentId { get; set; }

        /// <summary>
        /// <para type="description">The ID of the role that is assigned.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The ID of the role that is assigned.")]
        public long? RoleId { get; set; }

        /// <summary>
        /// <para type="description">The scope in which this role is assigned. Possible values are:- CUSTOMER- ORG_UNIT</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The scope in which this role is assigned. Possible values are: \n- CUSTOMER\n- ORG_UNIT")]
        public string ScopeType { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Data.RoleAssignment()
            {
                AssignedTo = this.AssignedTo,
                OrgUnitId = this.OrgUnitId,
                RoleAssignmentId = this.RoleAssignmentId,
                RoleId = this.RoleId,
                ScopeType = this.ScopeType,
            };

            if (ShouldProcess("RoleAssignment"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Directory API Schema object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a Schema object which may be required as a parameter for some other Cmdlets in the Directory API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.admin.Directory.directory_v1.Data.Schema</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GASchemaObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GASchemaObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GASchemaObj",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GASchemaObj")]
    [OutputType(typeof(Google.Apis.admin.Directory.directory_v1.Data.Schema))]
    public class NewGASchemaObjCommand : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">Fields of Schema</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Fields of Schema")]
        public IList<Data.SchemaFieldSpec> Fields { get; set; }

        /// <summary>
        /// <para type="description">Unique identifier of Schema (Read-only)</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Unique identifier of Schema (Read-only)")]
        public string SchemaId { get; set; }

        /// <summary>
        /// <para type="description">Schema name</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Schema name")]
        public string SchemaName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.admin.Directory.directory_v1.Data.Schema()
            {
                Fields = this.Fields,
                SchemaId = this.SchemaId,
                SchemaName = this.SchemaName,
            };

            if (ShouldProcess("Schema"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Directory API SchemaFieldSpec object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a SchemaFieldSpec object which may be required as a parameter for some other Cmdlets in the Directory API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.admin.Directory.directory_v1.Data.SchemaFieldSpec</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GASchemaFieldSpecObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GASchemaFieldSpecObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GASchemaFieldSpecObj",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GASchemaFieldSpecObj")]
    [OutputType(typeof(Google.Apis.admin.Directory.directory_v1.Data.SchemaFieldSpec))]
    public class NewGASchemaFieldSpecObjCommand : PSCmdlet
    {
        #region Properties

        /// <summary>
        /// <para type="description">Unique identifier of Field (Read-only)</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Unique identifier of Field (Read-only)")]
        public string FieldId { get; set; }

        /// <summary>
        /// <para type="description">Name of the field.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of the field.")]
        public string FieldName { get; set; }

        /// <summary>
        /// <para type="description">Type of the field.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Type of the field.")]
        public string FieldType { get; set; }

        /// <summary>
        /// <para type="description">Boolean specifying whether the field is indexed or not.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Boolean specifying whether the field is indexed or not.")]
        public System.Nullable<bool> Indexed { get; set; }

        /// <summary>
        /// <para type="description">Boolean specifying whether this is a multi-valued field or not.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Boolean specifying whether this is a multi-valued field or not.")]
        public System.Nullable<bool> MultiValued { get; set; }

        /// <summary>
        /// <para type="description">Indexing spec for a numeric field. By default, only exact match queries will be supported for numeric fields. Setting the numericIndexingSpec allows range queries to be supported.</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Indexing spec for a numeric field. By default, only exact match queries will be supported for numeric fields. Setting the numericIndexingSpec allows range queries to be supported.")]
        public Data.SchemaFieldSpec.NumericIndexingSpecData NumericIndexingSpec { get; set; }

        /// <summary>
        /// <para type="description">Read ACLs on the field specifying who can view values of this field. Valid values are "ALL_DOMAIN_USERS" and "ADMINS_AND_SELF".</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Read ACLs on the field specifying who can view values of this field. Valid values are \"ALL_DOMAIN_USERS\" and \"ADMINS_AND_SELF\".")]
        public string ReadAccessType { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.admin.Directory.directory_v1.Data.SchemaFieldSpec()
            {
                FieldId = this.FieldId,
                FieldName = this.FieldName,
                FieldType = this.FieldType,
                Indexed = this.Indexed,
                MultiValued = this.MultiValued,
                NumericIndexingSpec = this.NumericIndexingSpec,
                ReadAccessType = this.ReadAccessType,
            };

            if (ShouldProcess("SchemaFieldSpec"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Directory API User object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a User object which may be required as a parameter for some other Cmdlets in the Directory API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.admin.Directory.directory_v1.Data.User</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GAUserObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GAUserObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GAUserObj",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAUserObj")]
    [OutputType(typeof(Google.Apis.admin.Directory.directory_v1.Data.User))]
    public class NewGAUserObjCommand : PSCmdlet
    {
        #region Properties



        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true)]
        public object Addresses { get; set; }

        /// <summary>
        /// <para type="description">Indicates if user has agreed to terms (Read-only)</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Indicates if user has agreed to terms (Read-only)")]
        public System.Nullable<bool> AgreedToTerms { get; set; }

        /// <summary>
        /// <para type="description">List of aliases (Read-only)</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "List of aliases (Read-only)")]
        public System.Collections.Generic.IList<string> Aliases { get; set; }

        /// <summary>
        /// <para type="description">Boolean indicating if the user should change password in next login</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Boolean indicating if the user should change password in next login")]
        public System.Nullable<bool> ChangePasswordAtNextLogin { get; set; }

        /// <summary>
        /// <para type="description">User's Google account creation time. (Read-only)</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "User's Google account creation time. (Read-only)")]
        public System.Nullable<System.DateTime> CreationTime { get; set; }

        /// <summary>
        /// <para type="description">Custom fields of the user.</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Custom fields of the user.")]
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, object>> CustomSchemas { get; set; }

        /// <summary>
        /// <para type="description">CustomerId of User (Read-only)</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "CustomerId of User (Read-only)")]
        public string CustomerId { get; set; }


        [Parameter(Position = 7,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true)]
        public System.Nullable<System.DateTime> DeletionTime { get; set; }


        [Parameter(Position = 8,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true)]
        public object Emails { get; set; }


        [Parameter(Position = 9,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true)]
        public object ExternalIds { get; set; }

        /// <summary>
        /// <para type="description">Hash function name for password. Supported are MD5, SHA-1 and crypt</para>
        /// </summary>
        [Parameter(Position = 10,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Hash function name for password. Supported are MD5, SHA-1 and crypt")]
        public string HashFunction { get; set; }

        /// <summary>
        /// <para type="description">Unique identifier of User (Read-only)</para>
        /// </summary>
        [Parameter(Position = 11,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Unique identifier of User (Read-only)")]
        public string Id { get; set; }


        [Parameter(Position = 12,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true)]
        public object Ims { get; set; }

        /// <summary>
        /// <para type="description">Boolean indicating if user is included in Global Address List</para>
        /// </summary>
        [Parameter(Position = 13,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Boolean indicating if user is included in Global Address List")]
        public System.Nullable<bool> IncludeInGlobalAddressList { get; set; }

        /// <summary>
        /// <para type="description">Boolean indicating if ip is whitelisted</para>
        /// </summary>
        [Parameter(Position = 14,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Boolean indicating if ip is whitelisted")]
        public System.Nullable<bool> IpWhitelisted { get; set; }

        /// <summary>
        /// <para type="description">Boolean indicating if the user is admin (Read-only)</para>
        /// </summary>
        [Parameter(Position = 15,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Boolean indicating if the user is admin (Read-only)")]
        public System.Nullable<bool> IsAdmin { get; set; }

        /// <summary>
        /// <para type="description">Boolean indicating if the user is delegated admin (Read-only)</para>
        /// </summary>
        [Parameter(Position = 16,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Boolean indicating if the user is delegated admin (Read-only)")]
        public System.Nullable<bool> IsDelegatedAdmin { get; set; }

        /// <summary>
        /// <para type="description">Is mailbox setup (Read-only)</para>
        /// </summary>
        [Parameter(Position = 17,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Is mailbox setup (Read-only)")]
        public System.Nullable<bool> IsMailboxSetup { get; set; }

        /// <summary>
        /// <para type="description">User's last login time. (Read-only)</para>
        /// </summary>
        [Parameter(Position = 18,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "User's last login time. (Read-only)")]
        public System.Nullable<System.DateTime> LastLoginTime { get; set; }

        /// <summary>
        /// <para type="description">User's name</para>
        /// </summary>
        [Parameter(Position = 19,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "User's name")]
        public Data.UserName Name { get; set; }

        /// <summary>
        /// <para type="description">List of non editable aliases (Read-only)</para>
        /// </summary>
        [Parameter(Position = 20,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "List of non editable aliases (Read-only)")]
        public System.Collections.Generic.IList<string> NonEditableAliases { get; set; }


        [Parameter(Position = 21,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true)]
        public object Notes { get; set; }

        /// <summary>
        /// <para type="description">OrgUnit of User</para>
        /// </summary>
        [Parameter(Position = 22,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "OrgUnit of User")]
        public string OrgUnitPath { get; set; }


        [Parameter(Position = 23,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true)]
        public object Organizations { get; set; }

        /// <summary>
        /// <para type="description">User's password</para>
        /// </summary>
        [Parameter(Position = 24,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "User's password")]
        public string Password { get; set; }


        [Parameter(Position = 25,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true)]
        public object Phones { get; set; }

        /// <summary>
        /// <para type="description">username of User</para>
        /// </summary>
        [Parameter(Position = 26,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "username of User")]
        public string PrimaryEmail { get; set; }


        [Parameter(Position = 27,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true)]
        public object Relations { get; set; }

        /// <summary>
        /// <para type="description">Indicates if user is suspended</para>
        /// </summary>
        [Parameter(Position = 28,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Indicates if user is suspended")]
        public System.Nullable<bool> Suspended { get; set; }

        /// <summary>
        /// <para type="description">Suspension reason if user is suspended (Read-only)</para>
        /// </summary>
        [Parameter(Position = 29,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Suspension reason if user is suspended (Read-only)")]
        public string SuspensionReason { get; set; }

        /// <summary>
        /// <para type="description">ETag of the user's photo (Read-only)</para>
        /// </summary>
        [Parameter(Position = 30,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "ETag of the user's photo (Read-only)")]
        public string ThumbnailPhotoEtag { get; set; }

        /// <summary>
        /// <para type="description">Photo Url of the user (Read-only)</para>
        /// </summary>
        [Parameter(Position = 31,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Photo Url of the user (Read-only)")]
        public string ThumbnailPhotoUrl { get; set; }


        [Parameter(Position = 32,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true)]
        #endregion
        public object Websites { get; set; }

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.admin.Directory.directory_v1.Data.User()
            {
                Addresses = this.Addresses,
                AgreedToTerms = this.AgreedToTerms,
                Aliases = this.Aliases,
                ChangePasswordAtNextLogin = this.ChangePasswordAtNextLogin,
                CreationTime = this.CreationTime,
                CustomSchemas = this.CustomSchemas,
                CustomerId = this.CustomerId,
                DeletionTime = this.DeletionTime,
                Emails = this.Emails,
                ExternalIds = this.ExternalIds,
                HashFunction = this.HashFunction,
                Id = this.Id,
                Ims = this.Ims,
                IncludeInGlobalAddressList = this.IncludeInGlobalAddressList,
                IpWhitelisted = this.IpWhitelisted,
                IsAdmin = this.IsAdmin,
                IsDelegatedAdmin = this.IsDelegatedAdmin,
                IsMailboxSetup = this.IsMailboxSetup,
                LastLoginTime = this.LastLoginTime,
                Name = this.Name,
                NonEditableAliases = this.NonEditableAliases,
                Notes = this.Notes,
                OrgUnitPath = this.OrgUnitPath,
                Organizations = this.Organizations,
                Password = this.Password,
                Phones = this.Phones,
                PrimaryEmail = this.PrimaryEmail,
                Relations = this.Relations,
                Suspended = this.Suspended,
                SuspensionReason = this.SuspensionReason,
                ThumbnailPhotoEtag = this.ThumbnailPhotoEtag,
                ThumbnailPhotoUrl = this.ThumbnailPhotoUrl,
                Websites = this.Websites,
            };

            if (ShouldProcess("User"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Directory API UserAddress object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a UserAddress object which may be required as a parameter for some other Cmdlets in the Directory API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.admin.Directory.directory_v1.Data.UserAddress</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GAUserAddressObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GAUserAddressObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GAUserAddressObj",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAUserAddressObj")]
    [OutputType(typeof(Google.Apis.admin.Directory.directory_v1.Data.UserAddress))]
    public class NewGAUserAddressObjCommand : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">Country.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Country.")]
        public string Country { get; set; }

        /// <summary>
        /// <para type="description">Country code.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Country code.")]
        public string CountryCode { get; set; }

        /// <summary>
        /// <para type="description">Custom type.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Custom type.")]
        public string CustomType { get; set; }

        /// <summary>
        /// <para type="description">Extended Address.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Extended Address.")]
        public string ExtendedAddress { get; set; }

        /// <summary>
        /// <para type="description">Formatted address.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Formatted address.")]
        public string Formatted { get; set; }

        /// <summary>
        /// <para type="description">Locality.</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Locality.")]
        public string Locality { get; set; }

        /// <summary>
        /// <para type="description">Other parts of address.</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Other parts of address.")]
        public string PoBox { get; set; }

        /// <summary>
        /// <para type="description">Postal code.</para>
        /// </summary>
        [Parameter(Position = 7,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Postal code.")]
        public string PostalCode { get; set; }

        /// <summary>
        /// <para type="description">If this is user's primary address. Only one entry could be marked as primary.</para>
        /// </summary>
        [Parameter(Position = 8,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "If this is user's primary address. Only one entry could be marked as primary.")]
        public System.Nullable<bool> Primary { get; set; }

        /// <summary>
        /// <para type="description">Region.</para>
        /// </summary>
        [Parameter(Position = 9,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Region.")]
        public string Region { get; set; }

        /// <summary>
        /// <para type="description">User supplied address was structured. Structured addresses are NOT supported at this time. You might be able to write structured addresses, but any values will eventually be clobbered.</para>
        /// </summary>
        [Parameter(Position = 10,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "User supplied address was structured. Structured addresses are NOT supported at this time. You might be able to write structured addresses, but any values will eventually be clobbered.")]
        public System.Nullable<bool> SourceIsStructured { get; set; }

        /// <summary>
        /// <para type="description">Street.</para>
        /// </summary>
        [Parameter(Position = 11,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Street.")]
        public string StreetAddress { get; set; }

        /// <summary>
        /// <para type="description">Each entry can have a type which indicates standard values of that entry. For example address could be of home, work etc. In addition to the standard type, an entry can have a custom type and can take any value. Such type should have the CUSTOM value as type and also have a customType value.</para>
        /// </summary>
        [Parameter(Position = 12,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Each entry can have a type which indicates standard values of that entry. For example address could be of home, work etc. In addition to the standard type, an entry can have a custom type and can take any value. Such type should have the CUSTOM value as type and also have a customType value.")]
        public string Type { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.admin.Directory.directory_v1.Data.UserAddress()
            {
                Country = this.Country,
                CountryCode = this.CountryCode,
                CustomType = this.CustomType,
                ExtendedAddress = this.ExtendedAddress,
                Formatted = this.Formatted,
                Locality = this.Locality,
                PoBox = this.PoBox,
                PostalCode = this.PostalCode,
                Primary = this.Primary,
                Region = this.Region,
                SourceIsStructured = this.SourceIsStructured,
                StreetAddress = this.StreetAddress,
                Type = this.Type,
            };

            if (ShouldProcess("UserAddress"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Directory API UserEmail object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a UserEmail object which may be required as a parameter for some other Cmdlets in the Directory API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.admin.Directory.directory_v1.Data.UserEmail</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GAUserEmailObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GAUserEmailObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GAUserEmailObj",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAUserEmailObj")]
    [OutputType(typeof(Google.Apis.admin.Directory.directory_v1.Data.UserEmail))]
    public class NewGAUserEmailObjCommand : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">Email id of the user.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Email id of the user.")]
        public string Address { get; set; }

        /// <summary>
        /// <para type="description">Custom Type.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Custom Type.")]
        public string CustomType { get; set; }

        /// <summary>
        /// <para type="description">If this is user's primary email. Only one entry could be marked as primary.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "If this is user's primary email. Only one entry could be marked as primary.")]
        public System.Nullable<bool> Primary { get; set; }

        /// <summary>
        /// <para type="description">Each entry can have a type which indicates standard types of that entry. For example email could be of home, work etc. In addition to the standard type, an entry can have a custom type and can take any value Such types should have the CUSTOM value as type and also have a customType value.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Each entry can have a type which indicates standard types of that entry. For example email could be of home, work etc. In addition to the standard type, an entry can have a custom type and can take any value Such types should have the CUSTOM value as type and also have a customType value.")]
        public string Type { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.admin.Directory.directory_v1.Data.UserEmail()
            {
                Address = this.Address,
                CustomType = this.CustomType,
                Primary = this.Primary,
                Type = this.Type,
            };

            if (ShouldProcess("UserEmail"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Directory API UserExternalId object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a UserExternalId object which may be required as a parameter for some other Cmdlets in the Directory API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.admin.Directory.directory_v1.Data.UserExternalId</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GAUserExternalIdObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GAUserExternalIdObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GAUserExternalIdObj",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAUserExternalIdObj")]
    [OutputType(typeof(Google.Apis.admin.Directory.directory_v1.Data.UserExternalId))]
    public class NewGAUserExternalIdObjCommand : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">Custom type.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Custom type.")]
        public string CustomType { get; set; }

        /// <summary>
        /// <para type="description">The type of the Id.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The type of the Id.")]
        public string Type { get; set; }

        /// <summary>
        /// <para type="description">The value of the id.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The value of the id.")]
        public string Value { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.admin.Directory.directory_v1.Data.UserExternalId()
            {
                CustomType = this.CustomType,
                Type = this.Type,
                Value = this.Value,
            };

            if (ShouldProcess("UserExternalId"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Directory API UserIm object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a UserIm object which may be required as a parameter for some other Cmdlets in the Directory API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.admin.Directory.directory_v1.Data.UserIm</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GAUserImObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GAUserImObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GAUserImObj",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAUserImObj")]
    [OutputType(typeof(Google.Apis.admin.Directory.directory_v1.Data.UserIm))]
    public class NewGAUserImObjCommand : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">Custom protocol.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Custom protocol.")]
        public string CustomProtocol { get; set; }

        /// <summary>
        /// <para type="description">Custom type.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Custom type.")]
        public string CustomType { get; set; }

        /// <summary>
        /// <para type="description">Instant messenger id.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Instant messenger id.")]
        public string Im { get; set; }

        /// <summary>
        /// <para type="description">If this is user's primary im. Only one entry could be marked as primary.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "If this is user's primary im. Only one entry could be marked as primary.")]
        public System.Nullable<bool> Primary { get; set; }

        /// <summary>
        /// <para type="description">Protocol used in the instant messenger. It should be one of the values from ImProtocolTypes map. Similar to type, it can take a CUSTOM value and specify the custom name in customProtocol field.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Protocol used in the instant messenger. It should be one of the values from ImProtocolTypes map. Similar to type, it can take a CUSTOM value and specify the custom name in customProtocol field.")]
        public string Protocol { get; set; }

        /// <summary>
        /// <para type="description">Each entry can have a type which indicates standard types of that entry. For example instant messengers could be of home, work etc. In addition to the standard type, an entry can have a custom type and can take any value. Such types should have the CUSTOM value as type and also have a customType value.</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Each entry can have a type which indicates standard types of that entry. For example instant messengers could be of home, work etc. In addition to the standard type, an entry can have a custom type and can take any value. Such types should have the CUSTOM value as type and also have a customType value.")]
        public string Type { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.admin.Directory.directory_v1.Data.UserIm()
            {
                CustomProtocol = this.CustomProtocol,
                CustomType = this.CustomType,
                Im = this.Im,
                Primary = this.Primary,
                Protocol = this.Protocol,
                Type = this.Type,
            };

            if (ShouldProcess("UserIm"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Directory API UserName object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a UserName object which may be required as a parameter for some other Cmdlets in the Directory API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.admin.Directory.directory_v1.Data.UserName</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GAUserNameObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GAUserNameObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GAUserNameObj",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAUserNameObj")]
    [OutputType(typeof(Google.Apis.admin.Directory.directory_v1.Data.UserName))]
    public class NewGAUserNameObjCommand : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">Last Name</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Last Name")]
        public string FamilyName { get; set; }

        /// <summary>
        /// <para type="description">Full Name</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Full Name")]
        public string FullName { get; set; }

        /// <summary>
        /// <para type="description">First Name</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "First Name")]
        public string GivenName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.admin.Directory.directory_v1.Data.UserName()
            {
                FamilyName = this.FamilyName,
                FullName = this.FullName,
                GivenName = this.GivenName,
            };

            if (ShouldProcess("UserName"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Directory API UserOrganization object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a UserOrganization object which may be required as a parameter for some other Cmdlets in the Directory API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.admin.Directory.directory_v1.Data.UserOrganization</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GAUserOrganizationObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GAUserOrganizationObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GAUserOrganizationObj",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAUserOrganizationObj")]
    [OutputType(typeof(Google.Apis.admin.Directory.directory_v1.Data.UserOrganization))]
    public class NewGAUserOrganizationObjCommand : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">The cost center of the users department.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The cost center of the users department.")]
        public string CostCenter { get; set; }

        /// <summary>
        /// <para type="description">Custom type.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Custom type.")]
        public string CustomType { get; set; }

        /// <summary>
        /// <para type="description">Department within the organization.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Department within the organization.")]
        public string Department { get; set; }

        /// <summary>
        /// <para type="description">Description of the organization.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Description of the organization.")]
        public string Description { get; set; }

        /// <summary>
        /// <para type="description">The domain to which the organization belongs to.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The domain to which the organization belongs to.")]
        public string Domain { get; set; }

        /// <summary>
        /// <para type="description">Location of the organization. This need not be fully qualified address.</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Location of the organization. This need not be fully qualified address.")]
        public string Location { get; set; }

        /// <summary>
        /// <para type="description">Name of the organization</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of the organization")]
        public string Name { get; set; }

        /// <summary>
        /// <para type="description">If it user's primary organization.</para>
        /// </summary>
        [Parameter(Position = 7,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "If it user's primary organization.")]
        public System.Nullable<bool> Primary { get; set; }

        /// <summary>
        /// <para type="description">Symbol of the organization.</para>
        /// </summary>
        [Parameter(Position = 8,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Symbol of the organization.")]
        public string Symbol { get; set; }

        /// <summary>
        /// <para type="description">Title (designation) of the user in the organization.</para>
        /// </summary>
        [Parameter(Position = 9,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Title (designation) of the user in the organization.")]
        public string Title { get; set; }

        /// <summary>
        /// <para type="description">Each entry can have a type which indicates standard types of that entry. For example organization could be of school, work etc. In addition to the standard type, an entry can have a custom type and can give it any name. Such types should have the CUSTOM value as type and also have a CustomType value.</para>
        /// </summary>
        [Parameter(Position = 10,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Each entry can have a type which indicates standard types of that entry. For example organization could be of school, work etc. In addition to the standard type, an entry can have a custom type and can give it any name. Such types should have the CUSTOM value as type and also have a CustomType value.")]
        public string Type { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.admin.Directory.directory_v1.Data.UserOrganization()
            {
                CostCenter = this.CostCenter,
                CustomType = this.CustomType,
                Department = this.Department,
                Description = this.Description,
                Domain = this.Domain,
                Location = this.Location,
                Name = this.Name,
                Primary = this.Primary,
                Symbol = this.Symbol,
                Title = this.Title,
                Type = this.Type,
            };

            if (ShouldProcess("UserOrganization"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Directory API UserPhone object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a UserPhone object which may be required as a parameter for some other Cmdlets in the Directory API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.admin.Directory.directory_v1.Data.UserPhone</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GAUserPhoneObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GAUserPhoneObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GAUserPhoneObj",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAUserPhoneObj")]
    [OutputType(typeof(Google.Apis.admin.Directory.directory_v1.Data.UserPhone))]
    public class NewGAUserPhoneObjCommand : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">Custom Type.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Custom Type.")]
        public string CustomType { get; set; }

        /// <summary>
        /// <para type="description">If this is user's primary phone or not.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "If this is user's primary phone or not.")]
        public System.Nullable<bool> Primary { get; set; }

        /// <summary>
        /// <para type="description">Each entry can have a type which indicates standard types of that entry. For example phone could be of home_fax, work, mobile etc. In addition to the standard type, an entry can have a custom type and can give it any name. Such types should have the CUSTOM value as type and also have a customType value.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Each entry can have a type which indicates standard types of that entry. For example phone could be of home_fax, work, mobile etc. In addition to the standard type, an entry can have a custom type and can give it any name. Such types should have the CUSTOM value as type and also have a customType value.")]
        public string Type { get; set; }

        /// <summary>
        /// <para type="description">Phone number.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Phone number.")]
        public string Value { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.admin.Directory.directory_v1.Data.UserPhone()
            {
                CustomType = this.CustomType,
                Primary = this.Primary,
                Type = this.Type,
                Value = this.Value,
            };

            if (ShouldProcess("UserPhone"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Directory API UserRelation object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a UserRelation object which may be required as a parameter for some other Cmdlets in the Directory API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.admin.Directory.directory_v1.Data.UserRelation</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GAUserRelationObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GAUserRelationObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GAUserRelationObj",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAUserRelationObj")]
    [OutputType(typeof(Google.Apis.admin.Directory.directory_v1.Data.UserRelation))]
    public class NewGAUserRelationObjCommand : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">Custom Type.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Custom Type.")]
        public string CustomType { get; set; }

        /// <summary>
        /// <para type="description">The relation of the user. Some of the possible values are mother, father, sister, brother, manager, assistant, partner.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The relation of the user. Some of the possible values are mother, father, sister, brother, manager, assistant, partner.")]
        public string Type { get; set; }

        /// <summary>
        /// <para type="description">The name of the relation.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The name of the relation.")]
        public string Value { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.admin.Directory.directory_v1.Data.UserRelation()
            {
                CustomType = this.CustomType,
                Type = this.Type,
                Value = this.Value,
            };

            if (ShouldProcess("UserRelation"))
            {
                WriteObject(body);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a new Directory API UserWebsite object.</para>
    /// <para type="description">This provides a Cmdlet-Based approach to creating a UserWebsite object which may be required as a parameter for some other Cmdlets in the Directory API category.</para>
    /// <para type="description">You could alternately create this object by calling New-Object -TypeName Google.Apis.admin.Directory.directory_v1.Data.UserWebsite</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GAUserWebsiteObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GAUserWebsiteObj">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GAUserWebsiteObj",
    SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAUserWebsiteObj")]
    [OutputType(typeof(Google.Apis.admin.Directory.directory_v1.Data.UserWebsite))]
    public class NewGAUserWebsiteObjCommand : PSCmdlet
    {
        #region Properties


        /// <summary>
        /// <para type="description">Custom Type.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Custom Type.")]
        public string CustomType { get; set; }

        /// <summary>
        /// <para type="description">If this is user's primary website or not.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "If this is user's primary website or not.")]
        public System.Nullable<bool> Primary { get; set; }

        /// <summary>
        /// <para type="description">Each entry can have a type which indicates standard types of that entry. For example website could be of home, work, blog etc. In addition to the standard type, an entry can have a custom type and can give it any name. Such types should have the CUSTOM value as type and also have a customType value.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Each entry can have a type which indicates standard types of that entry. For example website could be of home, work, blog etc. In addition to the standard type, an entry can have a custom type and can give it any name. Such types should have the CUSTOM value as type and also have a customType value.")]
        public string Type { get; set; }

        /// <summary>
        /// <para type="description">Website.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Website.")]
        public string Value { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            var body = new Google.Apis.admin.Directory.directory_v1.Data.UserWebsite()
            {
                CustomType = this.CustomType,
                Primary = this.Primary,
                Type = this.Type,
                Value = this.Value,
            };

            if (ShouldProcess("UserWebsite"))
            {
                WriteObject(body);
            }
        }
    }
}

namespace gShell.Cmdlets.Directory.GAAsp
{
    /// <summary>
    /// <para type="synopsis">Get information about an ASP(s) issued by a user.</para>
    /// <para type="description">Get information about an ASP(s) issued by a user.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAAsps -UserKey $SomeUserKeyString -CodeId $SomeCodeIdSystemNullable<int></code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GAAsps -UserKey $SomeUserKeyString -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAAsps">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAAsp",
          DefaultParameterSetName = "One",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAAsp")]
    public class GetGAAspCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Identifies the user in the API request. The value can be the user's primary email address, alias email address, or unique user ID.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Identifies the user in the API request. The value can be the user's primary email address, alias email address, or unique user ID.")]
        public string UserKey { get; set; }

        /// <summary>
        /// <para type="description">The unique ID of the ASP.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = true,
        ParameterSetName = "One",
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The unique ID of the ASP.")]
        public int CodeId { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = true,
        ParameterSetName = "List",
        HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            UserKey = GetFullEmailAddress(UserKey, GAuthId);

            if (ShouldProcess("Directory Asps", "Get-GAAsp"))
            {
                switch (ParameterSetName)
                {
                    case "One":
                        WriteObject(asps.Get(UserKey, CodeId));
                        break;
                    case "List":
                        WriteObject(asps.List(UserKey).Items);
                        break;
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Delete an ASP issued by a user.</para>
    /// <para type="description">Delete an ASP issued by a user.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GAAsps -UserKey $SomeUserKeyString -CodeId $SomeCodeIdSystemNullable<int></code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GAAsp">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GAAsp",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GAAsp")]
    public class RemoveGAAspCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Identifies the user in the API request. The value can be the user's primary email address, alias email address, or unique user ID.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Identifies the user in the API request. The value can be the user's primary email address, alias email address, or unique user ID.")]
        public string UserKey { get; set; }

        /// <summary>
        /// <para type="description">The unique ID of the ASP to be deleted.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The unique ID of the ASP to be deleted.")]
        public int CodeId { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting.")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            UserKey = GetFullEmailAddress(UserKey, GAuthId);

            if (ShouldProcess("Directory Asps", "Remove-GAAsp"))
            {
                if (Force || ShouldContinue((string.Format("Asp {0} with CodeID {2} will be removed from the {1} Google Apps domain.\nContinue?",
                    UserKey, GAuthId, CodeId)), "Confirm Google Apps Asp Removal"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove Asp {0}...",
                            UserKey));
                        asps.Delete(UserKey, CodeId);
                        WriteVerbose(string.Format("Removal of Asp {0} completed without error.",
                            UserKey));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, UserKey));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Asp deletion not confirmed"),
                        "", ErrorCategory.InvalidData, UserKey));
                }
            }
        }
    }
}

namespace gShell.Cmdlets.Directory.GAChannel
{
    /// <summary>
    /// <para type="synopsis">Stop watching resources through this channel</para>
    /// <para type="description">Stop watching resources through this channel</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Stop-GAChannel -Id $SomeIdString -ResourceId $SomeResourceIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Stop-GAChannels">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "GAChannel",
    SupportsShouldProcess = true,
    HelpUri = @"https://github.com/squid808/gShell/wiki/Stop-GAChannel")]
    public class StopGAChannelCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">A UUID or similar unique string that identifies this channel.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "A UUID or similar unique string that identifies this channel.")]
        public string Id { get; set; }

        /// <summary>
        /// <para type="description">An opaque ID that identifies the resource being watched on this channel. Stable across different API versions.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "An opaque ID that identifies the resource being watched on this channel. Stable across different API versions.")]
        public string ResourceId { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting.")]
        public SwitchParameter Force { get; set; }


        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Directory Channels", "Stop-GAChannel"))
            {
                if (Force || ShouldContinue((String.Format("Resource with Id {0} will be stopped on channel with Id {1}\nContinue?",
                    ResourceId, Id)), "Confirm Channel Stop"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to stop Channel Resource..."));
                        channels.Stop(new Data.Channel()
                        {
                            Id = Id,
                            ResourceId = ResourceId
                        });
                        WriteVerbose(string.Format("Channel Resource stopped without error."));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, "Stop-GAChannel"));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Stopping of Channel Resource failed"),
                        "", ErrorCategory.InvalidData, "Stop-GAChannel"));
                }
            }
        }
    }
}

namespace gShell.Cmdlets.Directory.GAChromeosdevice
{
    /// <summary>
    /// <para type="synopsis">Retrieve Chrome OS Device(s)</para>
    /// <para type="description">Retrieve Chrome OS Device(s)</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAChromeosdevice -DeviceId $SomeDeviceIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>List-GAChromeosdevice -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAChromeosdevice">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAChromeosdevice",
          DefaultParameterSetName = "One",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAChromeosdevice")]
    public class GetGAChromeosdeviceCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable id of the Google Apps account</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Immutable id of the Google Apps account")]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Immutable id of Chrome OS Device</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = true,
        ParameterSetName = "One",
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Immutable id of Chrome OS Device")]
        public string DeviceId { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = true,
        ParameterSetName = "List",
        HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }

        /// <summary>
        /// <para type="description">Maximum number of results to return. Default is 100</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = "List",
        HelpMessage = "Maximum number of results to return. Default is 100")]
        public int? MaxResults { get; set; }

        /// <summary>
        /// <para type="description">Column to use for sorting results</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Column to use for sorting results")]
        public ChromeosdevicesResource.ListRequest.OrderByEnum? OrderBy { get; set; }

        /// <summary>
        /// <para type="description">Restrict information returned to a set of selected fields.</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Restrict information returned to a set of selected fields.")]
        public ChromeosdevicesResource.ListRequest.ProjectionEnum? Projection { get; set; }

        /// <summary>
        /// <para type="description">Search string in the format given at http://support.google.com/chromeos/a/bin/answer.py?hl=en=1698333</para>
        /// </summary>
        [Parameter(Position = 7,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Search string in the format given at http://support.google.com/chromeos/a/bin/answer.py?hl=en=1698333")]
        public string Query { get; set; }

        /// <summary>
        /// <para type="description">Whether to return results in ascending or descending order. Only of use when orderBy is also used</para>
        /// </summary>
        [Parameter(Position = 8,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Whether to return results in ascending or descending order. Only of use when orderBy is also used")]
        public ChromeosdevicesResource.ListRequest.SortOrderEnum? SortOrder { get; set; }
        

        #endregion

        protected override void ProcessRecord()
        {
            CustomerId = string.IsNullOrWhiteSpace(CustomerId) ? "my_customer" : CustomerId;

            if (ShouldProcess(CustomerId, "Get-GAChromeosdevice"))
            {
                switch (ParameterSetName)
                {
                    case "One":
                        WriteObject(chromeosdevices.Get(CustomerId, DeviceId));
                        break;
                    case "List":
                        var properties = new dotNet.Directory.Chromeosdevices.ChromeosdevicesListProperties()
                        {
                            OrderBy = this.OrderBy,
                            Projection = this.Projection,
                            Query = this.Query,
                            SortOrder = this.SortOrder
                        };

                        if (MaxResults.HasValue) properties.TotalResults = MaxResults.Value;

                        WriteObject(chromeosdevices.List(CustomerId, properties).SelectMany(x => x.Chromeosdevices).ToList());
                        break;
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Update Chrome OS Device. This method supports patch semantics.</para>
    /// <para type="description">Update Chrome OS Device. This method supports patch semantics.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GAChromeosdevice -CustomerId $SomeCustomerIdString -DeviceId $SomeDeviceIdString -ChromeOsDeviceBody $SomeChromeOsDeviceObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GAChromeosdevice">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GAChromeosdevice",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAChromeosdevice")]
    public class SetGAChromeosdeviceCommand : DirectoryBase
    {
        #region Properties
        [Parameter(Position = 0,
            Mandatory = false, //can use 'my_customer'
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Immutable id of Chrome OS Device</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Immutable id of Chrome OS Device")]
        public string DeviceId { get; set; }

        /// <summary>
        /// <para type="description">AssetId specified during enrollment or through later annotation</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "AssetId specified during enrollment or through later annotation")]
        public string AnnotatedAssetId { get; set; }

        /// <summary>
        /// <para type="description">Address or location of the device as noted by the administrator</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Address or location of the device as noted by the administrator")]
        public string AnnotatedLocation { get; set; }

        /// <summary>
        /// <para type="description">User of the device</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "User of the device")]
        public string AnnotatedUser { get; set; }

        /// <summary>
        /// <para type="description">Notes added by the administrator</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Notes added by the administrator")]
        public string Notes { get; set; }

        /// <summary>
        /// <para type="description">OrgUnit of the device</para>
        /// </summary>
        [Parameter(Position = 6,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "OrgUnit of the device")]
        public string OrgUnitPath { get; set; }

        /// <summary>
        /// <para type="description">Restrict information returned to a set of selected fields.</para>
        /// </summary>
        [Parameter(Position = 7,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Restrict information returned to a set of selected fields.")]
        public ChromeosdevicesResource.PatchRequest.ProjectionEnum? Projection { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            CustomerId = string.IsNullOrWhiteSpace(CustomerId) ? "my_customer" : CustomerId;

            if (ShouldProcess(CustomerId, "Set-GAChromeosdevice"))
            {
                Data.ChromeOsDevice body = new Data.ChromeOsDevice()
                {
                    AnnotatedAssetId = this.AnnotatedAssetId,
                    AnnotatedLocation = this.AnnotatedLocation,
                    AnnotatedUser = this.AnnotatedUser,
                    Notes = this.Notes,
                    OrgUnitPath = this.OrgUnitPath
                };

                var properties = new dotNet.Directory.Chromeosdevices.ChromeosdevicesPatchProperties()
                {
                    Projection = this.Projection
                };

                chromeosdevices.Patch(body, CustomerId, DeviceId, properties);
            }
        }
    }
}

namespace gShell.Cmdlets.Directory.GACustomer
{
    /// <summary>
    /// <para type="synopsis">Retrives a customer.</para>
    /// <para type="description">Retrives a customer.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GACustomer -CustomerKey $SomeCustomerKeyString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GACustomer">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GACustomers",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GACustomer")]
    public class GetGACustomerCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Id of the customer to be retrieved</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Id of the customer to be retrieved")]
        public string CustomerKey { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Directory Customers", "Get-GACustomers"))
            {
                WriteObject(customers.Get(CustomerKey));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Updates a customer. This method supports patch semantics.</para>
    /// <para type="description">Updates a customer. This method supports patch semantics.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GACustomers -CustomerKey $SomeCustomerKeyString -CustomerBody $SomeCustomerObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GACustomers">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GACustomers",
    SupportsShouldProcess = true,

      HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GACustomers")]
    public class SetGACustomerCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Id of the customer to be updated</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Id of the customer to be updated")]
        public string CustomerKey { get; set; }

        /// <summary>
        /// <para type="description">JSON template for Customer Resource object in Directory API.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "JSON template for Customer Resource object in Directory API.")]
        Data.Customer CustomerBody { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Directory Customers", "Patch-GACustomers"))
            {
                WriteObject(customers.Patch(CustomerBody, CustomerKey));
            }
        }
    }
}

namespace gShell.Cmdlets.Directory.GADomainAlias
{
    /// <summary>
    /// <para type="synopsis">Deletes a Domain Alias of the customer.</para>
    /// <para type="description">Deletes a Domain Alias of the customer.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GADomainAlias -Customer $SomeCustomerString -DomainAliasName $SomeDomainAliasNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GADomainAlias">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GADomainAlias",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GADomainAlias")]
    public class RemoveGADomainAliasCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable id of the Google Apps account.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Immutable id of the Google Apps account.")]
        public string Customer { get; set; }

        /// <summary>
        /// <para type="description">Name of domain alias to be retrieved.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of domain alias to be retrieved.")]
        public string DomainAliasName { get; set; }

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
            Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

            string toRemoveTarget = "domain alias";

            if (ShouldProcess(toRemoveTarget))
            {	
	            if (Force|| ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
	            {
		            try
		            {
			            WriteDebug("Attempting to remove " + toRemoveTarget + "...");
				
			            domainAliases.Delete(Customer, DomainAliasName);
				
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

    /// <summary>
    /// <para type="synopsis">Retrieves a domain alias of the customer.</para>
    /// <para type="description">Retrieves a domain alias of the customer.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GADomainAlias -Customer $SomeCustomerString -DomainAliasName $SomeDomainAliasNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GADomainAlias -Customer $SomeCustomerString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GADomainAlias">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GADomainAlias",
        SupportsShouldProcess = true,
        DefaultParameterSetName = "One",
        HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GADomainAlias")]
    public class GetGADomainAliasCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable id of the Google Apps account.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Immutable id of the Google Apps account.")]
        public string Customer { get; set; }

        /// <summary>
        /// <para type="description">Name of domain alias to be retrieved.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = "One",
        HelpMessage = "Name of domain alias to be retrieved.")]
        public string DomainAliasName { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ParameterSetName = "List",
        HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }

        /// <summary>
        /// <para type="description">Name of the parent domain for which domain aliases are to be fetched.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = "List",
        HelpMessage = "Name of the parent domain for which domain aliases are to be fetched.")]
        public string ParentDomainName { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

            if (ShouldProcess("Directory DomainAliases", "Get-GADomainAlias"))
            {
                if (ParameterSetName == "One")
                {
                    WriteObject(domainAliases.Get(Customer, DomainAliasName));
                }
                else
                {
                    var properties = new dotNet.Directory.DomainAliases.DomainAliasesListProperties()
                    {
                        ParentDomainName = this.ParentDomainName
                    };

                    WriteObject(domainAliases.List(Customer, properties).DomainAliasesValue);
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Inserts a Domain alias of the customer.</para>
    /// <para type="description">Inserts a Domain alias of the customer.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GADomainAlias -Customer $SomeCustomerString -DomainAliasBody $SomeDomainAliasObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GADomainAlias">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GADomainAlias",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GADomainAlias")]
    public class NewGADomainAliasCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable id of the Google Apps account.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Immutable id of the Google Apps account.")]
        public string Customer { get; set; }

        /// <summary>
        /// <para type="description">JSON template for Domain Alias object in Directory API.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "JSON template for Domain Alias object in Directory API.")]
        public Data.DomainAlias DomainAliasBody { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

            if (ShouldProcess("Directory DomainAliases", "Insert-GADomainAlias"))
            {
                WriteObject(domainAliases.Insert(DomainAliasBody, Customer));
            }
        }
    }
}

namespace gShell.Cmdlets.Directory.GADomain
{
    /// <summary>
    /// <para type="synopsis">Deletes a domain of the customer.</para>
    /// <para type="description">Deletes a domain of the customer.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GADomain -Customer $SomeCustomerString -DomainName $SomeDomainNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GADomain">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GADomain",
        SupportsShouldProcess = true,
      HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GADomain")]
    public class RemoveGADomainCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable id of the Google Apps account.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Immutable id of the Google Apps account.")]
        public string Customer { get; set; }

        /// <summary>
        /// <para type="description">Name of domain to be deleted</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name of domain to be deleted")]
        public string DomainName { get; set; }

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
            Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

            string toRemoveTarget = "Domain";

			if (ShouldProcess(toRemoveTarget))
			{	
				if (Force || ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
				{
					try
					{
						WriteDebug("Attempting to remove " + toRemoveTarget + "...");

                        domains.Delete(Customer, DomainName);
							
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

    /// <summary>
    /// <para type="synopsis">Retrives a domain of the customer.</para>
    /// <para type="description">Retrives a domain of the customer.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GADomain -Customer $SomeCustomerString -DomainName $SomeDomainNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GADomain -Customer $SomeCustomerString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GADomain">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GADomain",
        SupportsShouldProcess = true,
        DefaultParameterSetName = "One",
        HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GADomain")]
    public class GetGADomainCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable id of the Google Apps account.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Immutable id of the Google Apps account.")]
        public string Customer { get; set; }

        /// <summary>
        /// <para type="description">Name of domain to be retrieved</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = "One",
        HelpMessage = "Name of domain to be retrieved")]
        public string DomainName { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ParameterSetName = "List",
        HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

            if (ShouldProcess("Directory Domain", "Get-GADomain"))
            {
                if (ParameterSetName == "One")
                {
                    WriteObject(domains.Get(Customer, DomainName));
                }
                else
                {
                    WriteObject(domains.List(Customer).Domains);
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Inserts a domain of the customer.</para>
    /// <para type="description">Inserts a domain of the customer.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GADomain -Customer $SomeCustomerString -DomainBody $SomeDomainObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GADomain">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GADomain",
    SupportsShouldProcess = true,

      HelpUri = @"https://github.com/squid808/gShell/wiki/New-GADomain")]
    public class NewGADomainCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable id of the Google Apps account.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Immutable id of the Google Apps account.")]
        public string Customer { get; set; }

        /// <summary>
        /// <para type="description">JSON template for Domain object in Directory API.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "JSON template for Domain object in Directory API.")]
        public Data.Domains DomainBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

            if (ShouldProcess("Directory Domain", "Insert-GADomain"))
            {
                WriteObject(domains.Insert(DomainBody, Customer));
            }
        }
    }
}

namespace gShell.Cmdlets.Directory.GAGroup
{
    /// <summary>
    /// <para type="synopsis">Retrieve Group</para>
    /// <para type="description">Retrieve Group</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAGroup -Email $SomeGroupNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GAGroup -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GAGroup -UserName $SomeUserNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAGroup">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAGroup",
          DefaultParameterSetName = "OneUser",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAGroup")]
    public class GetGAGroupCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Email or immutable Id of the group</para>
        /// </summary>
        [Parameter(Position = 0,
        ParameterSetName = "OneGroup",
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Email or immutable Id of the group")]
        [ValidateNotNullOrEmpty]
        public string GroupKey { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ParameterSetName = "AllGroups",
        HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }

        /// <summary>
        /// <para type="description">Email or immutable Id of the user if only those groups are to be listed, the given user is a member of. If Id, it should match with id of user object</para>
        /// </summary>
        [Parameter(Position = 2,
            ParameterSetName = "OneUser",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Email or immutable Id of the user if only those groups are to be listed, the given user is a member of. If Id, it should match with id of user object")]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        /// <summary>
        /// <para type="description">Maximum number of results to return. Default is 200</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ParameterSetName = "AllGroups",
        HelpMessage = "Maximum number of results to return. Default is 200")]
        [Parameter(Position = 3,
        Mandatory = false,
        ParameterSetName = "OneUser",
        HelpMessage = "Maximum number of results to return. Default is 200")]
        public int? MaxResults { get; set; }

        /// <summary>
        /// <para type="description">The unique ID for the customer's Google account. In case of a multi-domain account, to fetch all groups for a customer, fill this field instead of domain. As an account administrator, you can also use the my_customer alias to represent your account's customerId. The customerId is also returned as part of the Users resource.</para>
        /// </summary>
        [Parameter(Position = 4,
            ParameterSetName = "AllGroups",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The unique ID for the customer's Google account. In case of a multi-domain account, to fetch all groups for a customer, fill this field instead of domain. As an account administrator, you can also use the my_customer alias to represent your account's customerId. The customerId is also returned as part of the Users resource.")]
        [ValidateNotNullOrEmpty]
        public string Customer { get; set; }

        ///// <summary>
        ///// <para type="description">The domain name. Use this field to get fields from only one domain. To return all domains for a customer account, use the customer query parameter instead.</para>
        ///// </summary>
        //[Parameter(Position = 5,
        //    ParameterSetName = "AllGroups",
        //Mandatory = false,
        //ValueFromPipelineByPropertyName = true,
        //HelpMessage = "The domain name. Use this field to get fields from only one domain. To return all domains for a customer account, use the customer query parameter instead.")]
        //[ValidateNotNullOrEmpty]
        //public string Domain { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case "OneUser":
                    if (ShouldProcess(GroupKey, "Get-GAGroup"))
                    {
                        Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

                        var properties = new dotNet.Directory.Groups.GroupsListProperties()
                        {
                            UserKey = GetFullEmailAddress(UserName, GAuthId)
                        };

                        if (!string.IsNullOrWhiteSpace(this.Customer)) properties.Customer = this.Customer;
                        else properties.Domain = this.GAuthId;

                        if (MaxResults.HasValue) properties.TotalResults = MaxResults.Value;

                        WriteObject(groups.List(properties).SelectMany(x => x.GroupsValue).ToList());
                    }
                    break;
                case "OneGroup":
                    GroupKey = GetFullEmailAddress(GroupKey, GAuthId);

                    if (ShouldProcess(GroupKey, "Get-GAGroup"))
                    {
                        WriteObject(groups.Get(GroupKey));
                    }
                    break;

                case "AllGroups":
                    if (ShouldProcess("All Groups", "Get-GAGroup"))
                    {
                        Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

                        var properties = new dotNet.Directory.Groups.GroupsListProperties();

                        if (!string.IsNullOrWhiteSpace(this.Customer)) properties.Customer = this.Customer;
                        else properties.Domain = this.GAuthId;

                        if (MaxResults.HasValue) properties.TotalResults = MaxResults.Value;

                        WriteObject(groups.List(properties).SelectMany(x => x.GroupsValue).ToList());
                    }
                    break;
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Create Group</para>
    /// <para type="description">Create Group</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GAGroup -GroupBody $SomeGroupObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GAGroup">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GAGroup",
          DefaultParameterSetName = "PasswordGenerated",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAGroup")]
    public class NewGAGroupCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Email of Group</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The email name of the group to be created.")]
        [ValidateNotNullOrEmpty]
        public string Email { get; set; }

        /// <summary>
        /// <para type="description">Group name</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        HelpMessage = "The formatted name of the group to be created.")]
        public string Name { get; set; }

        /// <summary>
        /// <para type="description">Description of the group</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        HelpMessage = "The description of the group to be created.")]
        public string Description { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(Name, "New-GAGroup"))
            {
                CreateGroup();
            }
        }

        private void CreateGroup()
        {
            Data.Group groupAcct = new Data.Group();

            groupAcct.Email = GetFullEmailAddress(Email, GAuthId);

            if (!string.IsNullOrWhiteSpace(Name))
            {
                groupAcct.Name = Name;
            }

            if (!string.IsNullOrWhiteSpace(Description))
            {
                groupAcct.Description = Description;
            }

            groups.Insert(groupAcct);
        }

    }

    /// <summary>
    /// <para type="synopsis">Delete Group</para>
    /// <para type="description">Delete Group</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GAGroup -GroupKey $SomeGroupKeyString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GAGroup">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GAGroup",
          DefaultParameterSetName = "Email",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GAGroup")]
    public class RemoveGAGroupCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Email or immutable Id of the group</para>
        /// </summary>
        [Parameter(Position = 0,
            ParameterSetName = "Email",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The email name of the group to remove. For a group AllThings@domain.com named 'All The Things', use AllThings.")]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        //Domain position = 1

        /// <summary>
        /// <para type="description">An object representing a group to remove</para>
        /// </summary>
        [Parameter(Position = 0,
            ParameterSetName = "GAGroupObject",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A Google Apps Group object representing the group. Retrieved from Get-GAGroup.")]
        [ValidateNotNullOrEmpty]
        public Data.Group GAGroupObject { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting.")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(GroupName, "Remove-GAGroup"))
            {
                if (Force || ShouldContinue((String.Format("Group {0} will be removed from the {1} Google Apps domain.\nContinue?",
                    GroupName, GAuthId)), "Confirm Google Apps Group Removal"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove group {0}@{1}...",
                            GroupName, GAuthId));
                        RemoveGroup();
                        WriteVerbose(string.Format("Removal of {0}@{1} completed without error.",
                            GroupName, GAuthId));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, GroupName));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Group deletion not confirmed"),
                        "", ErrorCategory.InvalidData, GroupName));
                }
            }
        }

        private void RemoveGroup()
        {
            string fullEmail = null;
            switch (ParameterSetName)
            {
                case "Email":
                    fullEmail = GroupName;
                    fullEmail = GetFullEmailAddress(fullEmail, GAuthId);
                    break;

                case "GAGroupObject":
                    fullEmail = GAGroupObject.Email;
                    break;
            }

            groups.Delete(fullEmail);
        }
    }

    /// <summary>
    /// <para type="synopsis">Update Group. This method supports patch semantics.</para>
    /// <para type="description">Update Group. This method supports patch semantics.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GAGroup -GroupKey $SomeGroupKeyString -GroupBody $SomeGroupObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GAGroup">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GAGroup",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAGroup")]
    public class SetGAGroupCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Email or immutable Id of the group. If Id, it should match with id of group object</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Email or immutable Id of the group. If Id, it should match with id of group object")]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        /// <summary>
        /// <para type="description">Description of the group</para>
        /// </summary>
        [Parameter(Position = 2,
            HelpMessage = "The new description of the group.")]
        public string NewDescription { get; set; }

        /// <summary>
        /// <para type="description">Group name</para>
        /// </summary>
        [Parameter(Position = 3,
            HelpMessage = "The new formatted name of the group.")]
        public string NewName { get; set; }

        /// <summary>
        /// <para type="description">Email of Group</para>
        /// </summary>
        [Parameter(Position = 4,
            HelpMessage = "The new email address for the group. Does not include the @domain.com")]
        public string NewEmailAddress { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(GroupName, "Set-GAGroup"))
            {
                UpdateGroup();
            }
        }

        private void UpdateGroup()
        {
            Data.Group groupAcct = new Data.Group();

            if (null == groupAcct)
            {
                WriteError(new ErrorRecord(new Exception(
                    string.Format("No group {0} was found to update.", GroupName)),
                        "", ErrorCategory.InvalidData, GroupName));
            }

            if (String.IsNullOrWhiteSpace(NewDescription) &&
                String.IsNullOrWhiteSpace(NewEmailAddress) &&
                String.IsNullOrWhiteSpace(NewName))
            {
                WriteError(new ErrorRecord(new Exception(
                    string.Format("No data was enetered to update {0}.", GroupName)),
                        "", ErrorCategory.InvalidData, GroupName));
            }

            if (!String.IsNullOrWhiteSpace(NewDescription))
            {
                groupAcct.Description = NewDescription;
            }

            if (!String.IsNullOrWhiteSpace(NewEmailAddress))
            {
                string _newEmail = GetFullEmailAddress(NewEmailAddress, GAuthId);
                groupAcct.Email = _newEmail;
            }

            if (!String.IsNullOrWhiteSpace(NewName))
            {
                groupAcct.Name = NewName;
            }

            GroupName = GetFullEmailAddress(GroupName, GAuthId);
            WriteObject(groups.Patch(groupAcct, GroupName));
        }
    }
}

namespace gShell.Cmdlets.Directory.GAGroupAlias
{
    /// <summary>
    /// <para type="synopsis">Remove a alias for the group</para>
    /// <para type="description">Remove a alias for the group</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GAUserAlias -GroupKey $SomeGroupKeyString -Alias $SomeAliasString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GAUserAlias">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GAGroupAlias",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GAGroupAlias")]
    public class RemoveGAGroupAliasCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Email or immutable Id of the group</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Email or immutable Id of the group")]
        public string GroupKey { get; set; }

        /// <summary>
        /// <para type="description">The alias to be removed</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The alias to be removed")]
        public string Alias { get; set; }

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
            string toRemoveTarget = "Group Alias";

			if (ShouldProcess(toRemoveTarget))
			{	
				if (Force || ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
				{
					try
					{
						WriteDebug("Attempting to remove " + toRemoveTarget + "...");
							
						groups.aliases.Delete(GroupKey, Alias);
							
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

    /// <summary>
    /// <para type="synopsis">Add a alias for the group</para>
    /// <para type="description">Add a alias for the group</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GAGroupAlias -GroupKey $SomeGroupKeyString -AliasBody $SomeAliasObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GAGroupAlias">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet("New", "GAGroupAlias",
    SupportsShouldProcess = true,

      HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAGroupAlias")]
    public class NewGAGroupAliasCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Email or immutable Id of the group</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Email or immutable Id of the group")]
        public string GroupKey { get; set; }

        /// <summary>
        /// <para type="description">JSON template for Alias object in Directory API.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "JSON template for Alias object in Directory API.")]
        public Data.Alias AliasBody { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Directory Aliases", "New-GAGroupAlias"))
            {
                WriteObject(groups.aliases.Insert(AliasBody, GroupKey));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">List all aliases for a group</para>
    /// <para type="description">List all aliases for a group</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAGroupAlias -GroupKey $SomeGroupKeyString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAGroupAlias">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAGroupAlias",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAGroupAlias")]
    public class GetGAGroupAliasCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Email or immutable Id of the group</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Email or immutable Id of the group")]
        public string GroupKey { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess("Directory Aliases", "Get-GAGroupAlias"))
            {
                WriteObject(groups.aliases.List(GroupKey).AliasesValue);
            }

        }
    }

}

namespace gShell.Cmdlets.Directory.GAGroupMember
{
    /// <summary>
    /// <para type="synopsis">Add user to the specified group.</para>
    /// <para type="description">Add user to the specified group.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Add-GAMembers -GroupKey $SomeGroupKeyString -MemberBody $SomeMemberObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Add-GAMembers">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "GAGroupMember",
          DefaultParameterSetName = "OneGroup",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Add-GAGroupMember")]
    public class AddGAGroupMemberCommand : DirectoryBase
    {
        #region Properties

        public enum GroupMembershipRoles { MEMBER, MANAGER, OWNER };

        /// <summary>
        /// <para type="description">Email or immutable Id of the group</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The email name of the group to which you'd like to add one or more members. For a group AllThings@domain.com named 'All The Things', use AllThings")]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        /// <summary>
        /// <para type="description">Email of member (Read-only)</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            HelpMessage = "The username of the group member you want to add.")]
        public string UserName { get; set; }

        /// <summary>
        /// <para type="description">Role of member</para>
        /// </summary>
        [Parameter(Position = 3,
            HelpMessage = "The role of the new group member. Values can be MEMBER, MANAGER, or OWNER.")]
        public GroupMembershipRoles Role { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            GroupName = GetFullEmailAddress(GroupName, GAuthId);

            if (ShouldProcess(GroupName, "Add-GAGroupMember"))
            {
                Data.Member member = new Data.Member
                {
                    Email = GetFullEmailAddress(UserName, GAuthId),
                    Role = this.Role.ToString()
                };

                WriteObject(members.Insert(member, GroupName));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Retrieve Group Member</para>
    /// <para type="description">Retrieve Group Member</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAGroupMember -GroupName $SomeGroupNameString </code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GAGroupMember -GroupName $SomeGroupNameString -UserName $SomeUserNameString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GAGroupMember -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAGroupMember">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAGroupMember",
          DefaultParameterSetName = "OneGroup",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAGroupMember")]
    public class GetGAGroupMemberCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Email or immutable Id of the group</para>
        /// </summary>
        [Parameter(Position = 0,
            ParameterSetName = "OneGroup",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The email name of the group whose member(s) you want to retrieve. For a group AllThings@domain.com named 'All The Things', use AllThings")]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        /// <summary>
        /// <para type="description">Email or immutable Id of the member</para>
        /// </summary>
        [Parameter(Position = 2,
            ParameterSetName = "OneGroup",
            HelpMessage = "The username of the user whose membership information you'd like to retrieve.")]
        public string UserName { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results.</para>
        /// </summary>
        [Parameter(Position = 3,
            ParameterSetName = "AllGroups",
            Mandatory = true,
            HelpMessage = "Indicates if you would like to get all members of all groups in the domain.")]
        public SwitchParameter All { get; set; }

        /// <summary>
        /// <para type="description">Include members in the results.</para>
        /// </summary>
        [Parameter(Position = 4,
            HelpMessage = "Include members in the results.")]
        public SwitchParameter Members { get; set; }

        /// <summary>
        /// <para type="description">Include managers in the results.</para>
        /// </summary>
        [Parameter(Position = 5,
            HelpMessage = "Include managers in the results.")]
        public SwitchParameter Managers { get; set; }

        /// <summary>
        /// <para type="description">Include owners in the results.</para>
        /// </summary>
        [Parameter(Position = 6,
            HelpMessage = "Include owners in the results.")]
        public SwitchParameter Owners { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                if (ShouldProcess(GroupName, "Get-GAGroupMember"))
                {
                    GroupName = GetFullEmailAddress(GroupName, GAuthId);
                    UserName = GetFullEmailAddress(UserName, GAuthId);
                    WriteObject(members.Get(GroupName, UserName));
                }
            }
            else
            {
                switch (ParameterSetName)
                {
                    case "OneGroup":
                        if (ShouldProcess(GroupName, "Get-GAGroupMember"))
                        {
                            var properties = new dotNet.Directory.Members.MembersListProperties()
                            {
                                Roles = DetermineRoles()
                            };

                            GroupName = GetFullEmailAddress(GroupName, GAuthId);
                            WriteObject(members.List(GroupName, properties).SelectMany(x => x.MembersValue).ToList());
                        }
                        break;

                    case "AllGroups":
                        if (ShouldProcess("All Groups and Members", "Get-GAGroupMember"))
                        {
                            WriteObject(GetAllGroupsAndMembers());
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Construct a roles string based on the parameters passed. Defaults to all.
        /// </summary>
        /// <returns></returns>
        private string DetermineRoles()
        {
            if (!Members && !Managers && !Owners)
            {
                return "MEMBER,MANAGER,OWNER";
            }

            string roles = "";

            int count = 0;

            if (Members)
            {
                roles += "MEMBER";
                count += 1;
            }

            if (Managers)
            {
                if (count > 0)
                {
                    roles += ",";
                }

                roles += "MANAGER";
                count += 1;
            }

            if (Owners)
            {
                if (count > 0)
                {
                    roles += ",";
                }

                roles += "OWNER";
            }

            return roles;
        }

        /// <summary>
        /// Gets a list of all members from all groups. Calls for cached list of all groups.
        /// </summary>
        private GAMultiGroupMembersList GetAllGroupsAndMembers()
        {
            List<Data.Group> allGroups = groups.List().SelectMany(x => x.GroupsValue).ToList();

            GAMultiGroupMembersList multiList = new GAMultiGroupMembersList();

            foreach (Data.Group group in allGroups)
            {
                GroupName = GetFullEmailAddress(GroupName, GAuthId);
                List<Data.Member> membersList = members.List(GroupName).SelectMany(x => x.MembersValue).ToList();

                multiList.Add(group.Email, membersList);
            }

            return (multiList);
        }
    }

    /// <summary>
    /// A collection of members sorted by group.
    /// </summary>
    public class GAMultiGroupMembersList
    {
        public List<GACustomMembersList> membersByGroup;
        private Dictionary<string, int> groupIndex;

        public GAMultiGroupMembersList()
        {
            membersByGroup = new List<GACustomMembersList>();
            groupIndex = new Dictionary<string, int>();
        }

        public void Add(string groupName, List<Data.Member> membersList)
        {
            GACustomMembersList temp = new GACustomMembersList(groupName, membersList);
            membersByGroup.Add(temp);
            groupIndex[groupName] = membersByGroup.Count - 1;
        }

        public List<Data.Member> GetGroupMembers(string groupName)
        {
            if (groupIndex.ContainsKey(groupName))
            {
                return membersByGroup[groupIndex[groupName]].MembersList;
            }
            else
            {
                throw new System.InvalidOperationException(
                    string.Format("Object does not contain group information for {0}.", groupName));
            }
        }

        public List<GACustomMembersListEntry> ToSingleList()
        {
            List<GACustomMembersListEntry> singleList = new List<GACustomMembersListEntry>();

            foreach (GACustomMembersList group in membersByGroup)
            {
                singleList.AddRange(group.ToCustomList());
            }

            return singleList;
        }

        public int GetMemberCount()
        {
            int count = 0;

            foreach (GACustomMembersList list in membersByGroup)
            {
                count += list.MembersList.Count;
            }

            return count;
        }
    }

    public class GACustomMembersList
    {
        public string GroupName;
        public List<Data.Member> MembersList;

        public GACustomMembersList(string groupName, List<Data.Member> members)
        {
            GroupName = groupName;
            MembersList = members;
        }

        public List<GACustomMembersListEntry> ToCustomList()
        {
            List<GACustomMembersListEntry> customList = new List<GACustomMembersListEntry>();

            foreach (Data.Member member in MembersList)
            {
                customList.Add(new GACustomMembersListEntry(
                    GroupName, member));
            }

            return (customList);
        }
    }

    /// <summary>
    /// Extends the base Member class to include the group it came from.
    /// </summary>
    public class GACustomMembersListEntry : Data.Member
    {
        public string Group;

        public GACustomMembersListEntry(string groupEmail, Data.Member baseMember)
        {
            Email = baseMember.Email;
            ETag = baseMember.ETag;
            Id = baseMember.Id;
            Kind = baseMember.Kind;
            Role = baseMember.Role;
            Type = baseMember.Type;
            Group = groupEmail;
        }
    }

    /// <summary>
    /// <para type="synopsis">Remove membership.</para>
    /// <para type="description">Remove membership.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GAMembes -GroupName $SomeGroupNameString -MemberKey $SomeMemberKeyString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GAMember">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GAGroupMember",
          DefaultParameterSetName = "OneGroup",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GAGroupMember")]
    public class RemoveGAGroupMemberCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Email or immutable Id of the group</para>
        /// </summary>
        [Parameter(Position = 0,
            ParameterSetName = "OneGroup",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The email name of the group whose member you want to remove. For a group AllThings@domain.com named 'All The Things', use AllThings")]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        /// <summary>
        /// <para type="description">Email or immutable Id of the member</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName = "OneGroup",
            HelpMessage = "The username of the group member you want to remove.")]
        public string UserName { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting.</para>
        /// </summary>
        [Parameter(Position = 3,
            HelpMessage = "Force the action to complete without a prompt to continue.")]
        public SwitchParameter Force { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            GroupName = GetFullEmailAddress(GroupName, GAuthId);

            if (ShouldProcess(GroupName, "Remove-GAGroupMember"))
            {
                if (Force || ShouldContinue((String.Format("Group member {0} will be removed from the {1}@{2} group.\nContinue?",
                    UserName, GroupName, GAuthId)), "Confirm Google Apps Group Member Removal"))
                {
                    try
                    {
                        UserName = GetFullEmailAddress(UserName, GAuthId);

                        WriteDebug(string.Format("Attempting to remove member {0} from group {1}...",
                            UserName, GroupName));

                        members.Delete(GroupName, UserName);

                        WriteVerbose(string.Format("Removal of {0} from {1} completed without error.",
                            UserName, GroupName));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, GroupName));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Group member removal not confirmed"),
                        "", ErrorCategory.InvalidData, GroupName));
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Update membership of a user in the specified group. This method supports patch semantics.</para>
    /// <para type="description">Update membership of a user in the specified group. This method supports patch semantics.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GAMembers -GroupKey $SomeGroupKeyString -MemberKey $SomeMemberKeyString -MemberBody $SomeMemberObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GAMembers">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GAGroupMember",
          DefaultParameterSetName = "OneGroup",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAGroupMember")]
    public class SetGAGroupMemberCommand : DirectoryBase
    {
        #region Properties

        public enum GroupMembershipRoles { MEMBER, MANAGER, OWNER };

        /// <summary>
        /// <para type="description">Email or immutable Id of the group. If Id, it should match with id of group object</para>
        /// </summary>
        [Parameter(Position = 0,
            ParameterSetName = "OneGroup",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The email name of the group whose member you want to update. For a group AllThings@domain.com named 'All The Things', use AllThings")]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        /// <summary>
        /// <para type="description">Email or immutable Id of the user. If Id, it should match with id of member object</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName = "OneGroup",
            HelpMessage = "The username of the group member you want to update.")]
        public string UserName { get; set; }

        /// <summary>
        /// <para type="description">Role of member</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = true,
            ParameterSetName = "OneGroup",
            HelpMessage = "The new role of the group member. Values can be MEMBER, MANAGER, or OWNER.")]
        public GroupMembershipRoles Role { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(GroupName, "Set-GAGroupMember"))
            {
                Data.Member member = new Data.Member
                {
                    Role = this.Role.ToString()
                };

                GroupName = GetFullEmailAddress(GroupName, GAuthId);
                UserName = GetFullEmailAddress(UserName, GAuthId);

                WriteObject(members.Update(member, GroupName, UserName));
            }
        }
    }

}

namespace gShell.Cmdlets.Directory.GAMobileDevice
{
    /// <summary>
    /// <para type="synopsis">Retrieve Mobile Device</para>
    /// <para type="description">Retrieve Mobile Device</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAMobiledevice -CustomerId $SomeCustomerIdString -ResourceId $SomeResourceIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GAMobiledevice -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAMobiledevice">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAMobiledevice",
        DefaultParameterSetName = "One",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAMobiledevice")]
    public class GetGAMobiledeviceCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable id of the Google Apps account</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Immutable id of the Google Apps account")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Immutable id of Mobile Device</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName = "One",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Immutable id of Mobile Device")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results.</para>
        /// </summary>
        [Parameter(Position = 3,
            ParameterSetName = "List",
            HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }

        /// <summary>
        /// <para type="description">Maximum number of results to return. Default is 100</para>
        /// </summary>
        [Parameter(Position = 4,
            Mandatory = false,
            ParameterSetName = "List",
            HelpMessage = "Maximum number of results to return. Default is 100")]
        public int? MaxResults { get; set; }

        /// <summary>
        /// <para type="description">Column to use for sorting results</para>
        /// </summary>
        [Parameter(Position = 5,
            Mandatory = false,
            ParameterSetName = "List",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Column to use for sorting results")]
        public MobiledevicesResource.ListRequest.OrderByEnum? OrderBy { get; set; }

        /// <summary>
        /// <para type="description">Restrict information returned to a set of selected fields.</para>
        /// </summary>
        [Parameter(Position = 6,
            Mandatory = false,
            ParameterSetName = "List",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Restrict information returned to a set of selected fields.")]
        public MobiledevicesResource.ListRequest.ProjectionEnum? Projection { get; set; }

        /// <summary>
        /// <para type="description">Search string in the format given at http://support.google.com/a/bin/answer.py?hl=en=1408863#search</para>
        /// </summary>
        [Parameter(Position = 7,
            Mandatory = false,
            ParameterSetName = "List",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Search string in the format given at http://support.google.com/a/bin/answer.py?hl=en=1408863#search")]
        public string Query { get; set; }

        /// <summary>
        /// <para type="description">Whether to return results in ascending or descending order. Only of use when orderBy is also used</para>
        /// </summary>
        [Parameter(Position = 8,
            Mandatory = false,
            ParameterSetName = "List",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether to return results in ascending or descending order. Only of use when orderBy is also used")]
        public MobiledevicesResource.ListRequest.SortOrderEnum? SortOrder { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            CustomerId = string.IsNullOrWhiteSpace(CustomerId) ? "my_customer" : CustomerId;

            if (ShouldProcess(CustomerId, "Get-GAMobiledevice"))
            {
                switch (ParameterSetName)
                {
                    case "One":
                        WriteObject(mobiledevices.Get(CustomerId, ResourceId));
                        break;
                    case "List":

                        var properties = new dotNet.Directory.Mobiledevices.MobiledevicesListProperties()
                        {
                            OrderBy = this.OrderBy,
                            Projection = this.Projection,
                            Query = this.Query,
                            SortOrder = this.SortOrder
                        };

                        if (MaxResults.HasValue) properties.MaxResults = MaxResults.Value;

                        WriteObject(mobiledevices.List(CustomerId, properties).SelectMany(x => x.Mobiledevices).ToList());
                        break;
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Delete Mobile Device</para>
    /// <para type="description">Delete Mobile Device</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GAMobiledevice -CustomerId $SomeCustomerIdString -ResourceId $SomeResourceIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GAMobiledevice">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GAMobiledevice",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GAMobiledevice")]
    public class RemoveGAMobiledeviceCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable id of the Google Apps account</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Immutable id of the Google Apps account")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Immutable id of Mobile Device</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Immutable id of Mobile Device")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting.</para>
        /// </summary>
        [Parameter(Position = 3,
            HelpMessage = "A switch to run the cmdlet without prompting.")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            CustomerId = string.IsNullOrWhiteSpace(CustomerId) ? "my_customer" : CustomerId;

            if (ShouldProcess(CustomerId, "Remove-GAMobiledevice"))
            {
                if (Force ||
                    ShouldContinue(
                        (String.Format(
                            "Mobile Device {0} with ResourceId {2} will be removed from the {1} Google Apps domain.\nContinue?",
                            CustomerId, GAuthId, ResourceId)), "Confirm Google Apps Mobile Device Removal"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove Mobile Device {0}...",
                            CustomerId));
                        mobiledevices.Delete(CustomerId, ResourceId);
                        WriteVerbose(string.Format("Removal of Mobile Device {0} completed without error.",
                            CustomerId));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData,
                            CustomerId));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Mobile Device deletion not confirmed"),
                        "", ErrorCategory.InvalidData, CustomerId));
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Take action on Mobile Device</para>
    /// <para type="description">Take action on Mobile Device</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Invoke-GAMobiledevice -CustomerId $SomeCustomerIdString -ResourceId $SomeResourceIdString -MobileDeviceActionBody $SomeMobileDeviceActionObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Invoke-GAMobiledevice">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "GAMobiledevice",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Invoke-GAMobiledevice")]
    public class SetGAMobiledeviceCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable id of the Google Apps account</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Immutable id of the Google Apps account")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Immutable id of Mobile Device</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Immutable id of Mobile Device")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// <para type="description">Action to be taken on the Mobile Device</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Action to be taken on the Mobile Device")]
        [ValidateNotNullOrEmpty]
        public string Action { get; set; }

        #endregion


        protected override void ProcessRecord()
        {
            CustomerId = string.IsNullOrWhiteSpace(CustomerId) ? "my_customer" : CustomerId;

            if (ShouldProcess(CustomerId, "Invoke-GAMobiledevice"))
            {
                var body = new Data.MobileDeviceAction()
                {
                    Action = this.Action
                };

                mobiledevices.Action(body, CustomerId, ResourceId);
            }
        }
    }

}

namespace gShell.Cmdlets.Directory.GANotification
{
    /// <summary>
    /// <para type="synopsis">Retrieves a notification.</para>
    /// <para type="description">Retrieves a notification.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GANotification -Customer $SomeCustomerString -NotificationId $SomeNotificationIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GANotifications -Customer $SomeCustomerString -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GANotification">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GANotification",
          DefaultParameterSetName = "One",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GANotification")]
    public class GetGANotificationCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The unique ID for the customer's Google account. The customerId is also returned as part of the Users resource.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The unique ID for the customer's Google account. The customerId is also returned as part of the Users resource.")]
        [ValidateNotNullOrEmpty]
        public string Customer { get; set; }

        /// <summary>
        /// <para type="description">The unique ID of the notification.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName = "One",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The unique ID of the notification.")]
        [ValidateNotNullOrEmpty]
        public string NotificationId { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results.</para>
        /// </summary>
        [Parameter(Position = 2,
            ParameterSetName = "List",
            HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }

        /// <summary>
        /// <para type="description">The ISO 639-1 code of the language notifications are returned in. The default is English (en).</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The ISO 639-1 code of the language notifications are returned in. The default is English (en).")]
        public string Language { get; set; }

        /// <summary>
        /// <para type="description">Maximum number of notifications to return per page. The default is 100.</para>
        /// </summary>
        [Parameter(Position = 4,
            Mandatory = false,
            ParameterSetName = "List",
            HelpMessage = "Maximum number of notifications to return per page. The default is 100.")]
        public int? MaxResults { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

            if (ShouldProcess(Customer, "Get-GANotification"))
            {
                switch (ParameterSetName)
                {
                    case "One":
                        WriteObject(notifications.Get(Customer, NotificationId));
                        break;
                    case "List":
                        var properties = new dotNet.Directory.Notifications.NotificationsListProperties()
                        {
                            Language = this.Language
                        };

                        if (MaxResults.HasValue) properties.TotalResults = MaxResults.Value;

                        WriteObject(notifications.List(Customer, properties).SelectMany(x => x.Items).ToList());
                        break;
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Deletes a notification</para>
    /// <para type="description">Deletes a notification</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GANotification -Customer $SomeCustomerString -NotificationId $SomeNotificationIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GANotification">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GANotification",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GANotification")]
    public class RemoveGANotificationCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The unique ID for the customer's Google account. The customerId is also returned as part of the Users resource.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The unique ID for the customer's Google account. The customerId is also returned as part of the Users resource.")]
        [ValidateNotNullOrEmpty]
        public string Customer { get; set; }

        /// <summary>
        /// <para type="description">The unique ID of the notification.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The unique ID of the notification.")]
        [ValidateNotNullOrEmpty]
        public string NotificationId { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting.</para>
        /// </summary>
        [Parameter(Position = 3,
            HelpMessage = "A switch to run the cmdlet without prompting.")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

            if (ShouldProcess(Customer, "Remove-GANotification"))
            {
                if (Force || ShouldContinue((String.Format("Notification {0} with NotificationId {2} will be removed from the {1} Google Apps domain.\nContinue?",
                    Customer, GAuthId, NotificationId)), "Confirm Google Apps Notification Removal"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove Notification {0}...",
                            Customer));
                        notifications.Delete(Customer, NotificationId);
                        WriteVerbose(string.Format("Removal of Notification {0} completed without error.",
                            Customer));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, Customer));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Notification deletion not confirmed"),
                        "", ErrorCategory.InvalidData, Customer));
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Updates a notification. This method supports patch semantics.</para>
    /// <para type="description">Updates a notification. This method supports patch semantics.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GANotification -Customer $SomeCustomerString -NotificationId $SomeNotificationIdString -NotificationBody $SomeNotificationObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GANotification">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GANotification",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GANotification")]
    public class SetGANotificationCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The unique ID for the customer's Google account.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The unique ID for the customer's Google account.")]
        [ValidateNotNullOrEmpty]
        public string Customer { get; set; }

        /// <summary>
        /// <para type="description">The unique ID of the notification.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The unique ID of the notification.")]
        [ValidateNotNullOrEmpty]
        public string NotificationId { get; set; }

        /// <summary>
        /// <para type="description">Boolean indicating whether the notification is unread or not.</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Boolean indicating whether the notification is unread or not.")]
        [ValidateNotNullOrEmpty]
        public bool IsUnread { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

            if (ShouldProcess(Customer, "Set-GANotification"))
            {
                Data.Notification body = new Data.Notification();

                body.IsUnread = IsUnread;

                WriteObject(notifications.Patch(body, Customer, NotificationId));
            }
        }
    }
}

namespace gShell.Cmdlets.Directory.GAOrgUnit
{
    /// <summary>
    /// <para type="synopsis">Retrieve Organization Unit</para>
    /// <para type="description">Retrieve Organization Unit</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAOrgUnit -CustomerId $SomeCustomerIdString -OrgUnitPath @("some","strings")</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GAOrgUnit -CustomerId $SomeCustomerIdString -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAOrgUnit">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAOrgUnit",
          DefaultParameterSetName = "One",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAOrgUnit")]
    public class GetGAOrgUnitCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable id of the Google Apps account</para>
        /// </summary>
        [Parameter(Position = 0,
            ParameterSetName = "One",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Immutable id of the Google Apps account")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Full path of the organization unit or its Id</para>
        /// </summary>
        [Parameter(Position = 2,
            ParameterSetName = "One",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Full path of the organization unit or its Id")]
        [Parameter(Position = 2,
            ParameterSetName = "List",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Full path of the organization unit or its Id")]
        public string OrgUnitPath { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results.</para>
        /// </summary>
        [Parameter(Position = 3,
            ParameterSetName = "List",
            HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }

        /// <summary>
        /// <para type="description">Whether to return all sub-organizations or just immediate children</para>
        /// </summary>
        [Parameter(Position = 4,
            Mandatory = false,
            ParameterSetName = "List",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether to return all sub-organizations or just immediate children")]
        [ValidateNotNullOrEmpty]
        public OrgunitsResource.ListRequest.TypeEnum? Type { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            CustomerId = string.IsNullOrWhiteSpace(CustomerId) ? "my_customer" : CustomerId;

            if (ShouldProcess(CustomerId, "Get-GAOrgUnit"))
            {
                if (ParameterSetName == "List")
                {
                    WriteObject(orgunits.List(CustomerId, new dotNet.Directory.Orgunits.OrgunitsListProperties()
                    {
                        OrgUnitPath = OrgUnitPath,
                        Type = Type
                    }).OrganizationUnits);
                }
                else
                {
                    WriteObject(orgunits.Get(CustomerId, OrgUnitPath));
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Remove Organization Unit</para>
    /// <para type="description">Remove Organization Unit</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GAOrgUnit -CustomerId $SomeCustomerIdString -OrgUnitPath @("some","strings")</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GAOrgUnit">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GAOrgUnit",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GAOrgUnit")]
    public class RemoveGAOrgUnitCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable id of the Google Apps account</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Immutable id of the Google Apps account")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Full path of the organization unit or its Id</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Full path of the organization unit or its Id")]
        [ValidateNotNullOrEmpty]
        public string OrgUnitPath { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting.</para>
        /// </summary>
        [Parameter(Position = 3,
            HelpMessage = "A switch to run the cmdlet without prompting.")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            CustomerId = string.IsNullOrWhiteSpace(CustomerId) ? "my_customer" : CustomerId;

            if (ShouldProcess(CustomerId, "Remove-GAOrgUnit"))
            {
                if (Force || ShouldContinue((String.Format("OrgUnit {0} for CustomerId {2} will be removed from the {1} Google Apps domain.\nContinue?",
                    OrgUnitPath, GAuthId, CustomerId)), "Confirm Google Apps OrgUnit Removal"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove OrgUnit {0}...",
                            CustomerId));
                        orgunits.Delete(CustomerId, OrgUnitPath);
                        WriteVerbose(string.Format("Removal of OrgUnit {0} completed without error.",
                            CustomerId));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, CustomerId));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("OrgUnit deletion not confirmed"),
                        "", ErrorCategory.InvalidData, CustomerId));
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Update Organization Unit. This method supports patch semantics.</para>
    /// <para type="description">Update Organization Unit. This method supports patch semantics.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GAOrgUnit -CustomerId $SomeCustomerIdString -OrgUnitPath $SomeOrgUnitPathString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GAOrgUnit">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GAOrgUnit",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAOrgUnit")]
    public class SetGAOrgUnitCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable id of the Google Apps account</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Immutable id of the Google Apps account")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Full path of the organization unit or its Id</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Full path of the organization unit or its Id")]
        [ValidateNotNullOrEmpty]
        public string OrgUnitPath { get; set; }

        /// <summary>
        /// <para type="description">Name of OrgUnit</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of OrgUnit")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// <para type="description">Id of parent OrgUnit</para>
        /// </summary>
        [Parameter(Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Id of parent OrgUnit")]
        [ValidateNotNullOrEmpty]
        public string ParentOrgUnitPath { get; set; }

        /// <summary>
        /// <para type="description">Should block inheritance</para>
        /// </summary>
        [Parameter(Position = 5,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Should block inheritance")]
        [ValidateNotNullOrEmpty]
        public bool? BlockInheritance { get; set; }

        /// <summary>
        /// <para type="description">Description of OrgUnit</para>
        /// </summary>
        [Parameter(Position = 6,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Description of OrgUnit")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            CustomerId = string.IsNullOrWhiteSpace(CustomerId) ? "my_customer" : CustomerId;

            if (ShouldProcess(CustomerId, "Set-GAOrgUnit"))
            {
                Data.OrgUnit body = new Data.OrgUnit();

                if (!string.IsNullOrWhiteSpace(Name))
                {
                    body.Name = Name;
                }

                if (!string.IsNullOrWhiteSpace(ParentOrgUnitPath))
                {
                    body.ParentOrgUnitPath = ParentOrgUnitPath;
                }

                if (BlockInheritance.HasValue)
                {
                    body.BlockInheritance = BlockInheritance.Value;
                }

                if (!string.IsNullOrWhiteSpace(Description))
                {
                    body.Description = Description;
                }

                WriteObject(orgunits.Patch(body, CustomerId, OrgUnitPath));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Add Organization Unit</para>
    /// <para type="description">Add Organization Unit</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GAOrgUnit -CustomerId $SomeCustomerIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GAOrgUnit">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GAOrgUnit",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAOrgUnit")]
    public class NewGAOrgUnitCommand : DirectoryBase
    {
        #region Properties
        /// <summary>
        /// <para type="description">Immutable id of the Google Apps account</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Immutable id of the Google Apps account")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Name of OrgUnit</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of OrgUnit")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// <para type="description">Id of parent OrgUnit</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Id of parent OrgUnit")]
        [ValidateNotNullOrEmpty]
        public string ParentOrgUnitPath { get; set; }

        /// <summary>
        /// <para type="description">Should block inheritance</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Should block inheritance")]
        [ValidateNotNullOrEmpty]
        public bool? BlockInheritance { get; set; }

        /// <summary>
        /// <para type="description">Description of OrgUnit</para>
        /// </summary>
        [Parameter(Position = 4,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Description of OrgUnit")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            CustomerId = string.IsNullOrWhiteSpace(CustomerId) ? "my_customer" : CustomerId;

            if (ShouldProcess(CustomerId, "Add-GAOrgUnit"))
            {
                Data.OrgUnit body = new Data.OrgUnit()
                {
                    Name = this.Name,
                    ParentOrgUnitPath = this.ParentOrgUnitPath,
                    BlockInheritance = this.BlockInheritance,
                    Description = this.Description
                };

                WriteObject(orgunits.Insert(body, CustomerId));
            }
        }
    }
}

namespace gShell.Cmdlets.Directory.GAPrivilege
{
    /// <summary>
    /// <para type="synopsis">Retrieves a paginated list of all Privilege for a customer.</para>
    /// <para type="description">Retrieves a paginated list of all Privilege for a customer.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAPrivilege -Customer $SomeCustomerString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAPrivilege">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet("Get", "GAPrivilege",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAPrivilege")]
    public class GetGAPrivilegeCommand : DirectoryBase
    {
        #region Properties
        
        /// <summary>
        /// <para type="description">Immutable ID of the Google Apps account.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Immutable ID of the Google Apps account.")]
        public string Customer { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

            if (ShouldProcess("Directory Privilege", "Get-GAPrivilege"))
            {

                WriteObject(privileges.List(Customer).Items);
            }

        }
    }
}

namespace gShell.Cmdlets.Directory.GACalendar
{
    /// <summary>
    /// <para type="synopsis">Deletes a calendar resource.</para>
    /// <para type="description">Deletes a calendar resource.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GACalendar -Customer $SomeCustomerString -CalendarResourceId $SomeCalendarResourceIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GACalendar">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GACalendar",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GACalendar")]
    public class RemoveGACalendarCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The unique ID for the customer's Google account. As an account administrator, you can also use the my_customer alias to represent your account's customer ID.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The unique ID for the customer's Google account. As an account administrator, you can also use the my_customer alias to represent your account's customer ID.")]
        public string Customer { get; set; }

        /// <summary>
        /// <para type="description">The unique ID of the calendar resource to delete.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The unique ID of the calendar resource to delete.")]
        public string CalendarResourceId { get; set; }

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
            Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

            string toRemoveTarget = "Calendar";

			if (ShouldProcess(toRemoveTarget))
			{	
				if (Force || ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
				{
					try
					{
						WriteDebug("Attempting to remove " + toRemoveTarget + "...");

                        resources.calendars.Delete(Customer, CalendarResourceId);
							
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

    /// <summary>
    /// <para type="synopsis">Retrieves a calendar resource.</para>
    /// <para type="description">Retrieves a calendar resource.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GACalendar -Customer $SomeCustomerString -CalendarResourceId $SomeCalendarResourceIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>List-GACalendar -Customer $SomeCustomerString -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GACalendar">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GACalendar",
        SupportsShouldProcess = true,
        DefaultParameterSetName = "One",
        HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GACalendar")]
    public class GetGACalendarCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The unique ID for the customer's Google account. As an account administrator, you can also use the my_customer alias to represent your account's customer ID.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The unique ID for the customer's Google account. As an account administrator, you can also use the my_customer alias to represent your account's customer ID.")]
        public string Customer { get; set; }

        /// <summary>
        /// <para type="description">The unique ID of the calendar resource to retrieve.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = "One",
        HelpMessage = "The unique ID of the calendar resource to retrieve.")]
        public string CalendarResourceId { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ParameterSetName = "List",
        HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }

        /// <summary>
        /// <para type="description">Maximum number of results to return.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = "List",
        HelpMessage = "Maximum number of results to return.")]
        public int? MaxResults { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

            if (ShouldProcess("Directory Calendar", "Get-GACalendar"))
            {
                if (ParameterSetName == "One")
                {
                    WriteObject(resources.calendars.Get(Customer, CalendarResourceId));
                }
                else
                {
                    var properties = new dotNet.Directory.Resources.Calendars.CalendarsListProperties();

                    if (MaxResults.HasValue) properties.TotalResults = MaxResults.Value;

                    WriteObject(resources.calendars.List(Customer, properties).SelectMany(x => x.Items).ToList());
                }
            }

        }
    }

    /// <summary>
    /// <para type="synopsis">Inserts a calendar resource.</para>
    /// <para type="description">Inserts a calendar resource.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GACalendar -Customer $SomeCustomerString -CalendarResourceBody $SomeCalendarResourceObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GACalendar">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet("New", "GACalendar",
    SupportsShouldProcess = true,

      HelpUri = @"https://github.com/squid808/gShell/wiki/New-GACalendar")]
    public class NewGACalendarCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The unique ID for the customer's Google account. As an account administrator, you can also use the my_customer alias to represent your account's customer ID.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The unique ID for the customer's Google account. As an account administrator, you can also use the my_customer alias to represent your account's customer ID.")]
        public string Customer { get; set; }

        /// <summary>
        /// <para type="description">JSON template for Calendar Resource object in Directory API.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "JSON template for Calendar Resource object in Directory API.")]
        public Data.CalendarResource CalendarResourceBody { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

            if (ShouldProcess("Directory Calendar", "New-GACalendar"))
            {

                WriteObject(resources.calendars.Insert(CalendarResourceBody, Customer));
            }

        }
    }

    /// <summary>
    /// <para type="synopsis">Updates a calendar resource. This method supports patch semantics.</para>
    /// <para type="description">Updates a calendar resource. This method supports patch semantics.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GACalendar -Customer $SomeCustomerString -CalendarResourceId $SomeCalendarResourceIdString -CalendarResourceBody $SomeCalendarResourceObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GACalendar">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet("Set", "GACalendar",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GACalendar")]
    public class SetGACalendarCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The unique ID for the customer's Google account. As an account administrator, you can also use the my_customer alias to represent your account's customer ID.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The unique ID for the customer's Google account. As an account administrator, you can also use the my_customer alias to represent your account's customer ID.")]
        public string Customer { get; set; }

        /// <summary>
        /// <para type="description">The unique ID of the calendar resource to update.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The unique ID of the calendar resource to update.")]
        public string CalendarResourceId { get; set; }

        /// <summary>
        /// <para type="description">JSON template for Calendar Resource object in Directory API.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "JSON template for Calendar Resource object in Directory API.")]
        public Data.CalendarResource CalendarResourceBody { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

            if (ShouldProcess("Directory Calendar", "Set-GACalendar"))
            {
                WriteObject(resources.calendars.Patch(CalendarResourceBody, Customer, CalendarResourceId));
            }

        }
    }
}

namespace gShell.Cmdlets.Directory.GARole
{
    /// <summary>
    /// <para type="synopsis">Deletes a role.</para>
    /// <para type="description">Deletes a role.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GARole -Customer $SomeCustomerString -RoleId $SomeRoleIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GARole">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GARole",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GARole")]
    public class RemoveGARoleCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable ID of the Google Apps account.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Immutable ID of the Google Apps account.")]
        public string Customer { get; set; }

        /// <summary>
        /// <para type="description">Immutable ID of the role.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Immutable ID of the role.")]
        public string RoleId { get; set; }

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
            Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

            string toRemoveTarget = "Role";

			if (ShouldProcess(toRemoveTarget))
			{	
				if (Force || ShouldContinue(toRemoveTarget + "will be removed.\nContinue?", "Confirm Removal"))
				{
					try
					{
						WriteDebug("Attempting to remove " + toRemoveTarget + "...");

                        roles.Delete(Customer, RoleId);
							
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

    /// <summary>
    /// <para type="synopsis">Retrieves a role.</para>
    /// <para type="description">Retrieves a role.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GARole -Customer $SomeCustomerString -RoleId $SomeRoleIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>List-GARole -Customer $SomeCustomerString -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GARole">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GARole",
        SupportsShouldProcess = true,
        DefaultParameterSetName = "One",
        HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GARole")]
    public class GetGARoleCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable ID of the Google Apps account.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Immutable ID of the Google Apps account.")]
        public string Customer { get; set; }

        /// <summary>
        /// <para type="description">Immutable ID of the role.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = true,
            ParameterSetName = "One",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Immutable ID of the role.")]
        public string RoleId { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = true,
        ParameterSetName = "List",
        HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }

        /// <summary>
        /// <para type="description">Maximum number of results to return.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            ParameterSetName = "List",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Maximum number of results to return.")]
        public int? MaxResults { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

            if (ShouldProcess("Directory Role", "Get-GARole"))
            {
                if (ParameterSetName == "One")
                {
                    WriteObject(roles.Get(Customer, RoleId));
                }
                else
                {
                    var properties = new dotNet.Directory.Roles.RolesListProperties();

                    if (MaxResults.HasValue) properties.TotalResults = MaxResults.Value;

                    WriteObject(roles.List(Customer, properties).SelectMany(x => x.Items).ToList());
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a role.</para>
    /// <para type="description">Creates a role.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GARole -Customer $SomeCustomerString -RoleBody $SomeRoleObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GARole">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GARole",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/New-GARole")]
    public class NewGARoleCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable ID of the Google Apps account.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Immutable ID of the Google Apps account.")]
        public string Customer { get; set; }

        /// <summary>
        /// <para type="description">JSON template for role resource in Directory API.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "JSON template for role resource in Directory API.")]
        public Data.Role RoleBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

            if (ShouldProcess("Directory Role", "New-GARole"))
            {
                WriteObject(roles.Insert(RoleBody, Customer));
            }

        }
    }

    /// <summary>
    /// <para type="synopsis">Updates a role. This method supports patch semantics.</para>
    /// <para type="description">Updates a role. This method supports patch semantics.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GARole -Customer $SomeCustomerString -RoleId $SomeRoleIdString -RoleBody $SomeRoleObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GARole">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GARole",
        SupportsShouldProcess = true,

        HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GARole")]
    public class SetGARoleCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable ID of the Google Apps account.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Immutable ID of the Google Apps account.")]
        public string Customer { get; set; }

        /// <summary>
        /// <para type="description">Immutable ID of the role.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Immutable ID of the role.")]
        public string RoleId { get; set; }

        /// <summary>
        /// <para type="description">JSON template for role resource in Directory API.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "JSON template for role resource in Directory API.")]
        public Data.Role RoleBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

            if (ShouldProcess("Directory Role", "Set-GARole"))
            {
                WriteObject(roles.Patch(RoleBody, Customer, RoleId));
            }

        }
    }
}

namespace gShell.Cmdlets.Directory.GARoleAssignment
{
    /// <summary>
    /// <para type="synopsis">Deletes a role assignment.</para>
    /// <para type="description">Deletes a role assignment.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GARoleAssignment -Customer $SomeCustomerString -RoleAssignmentId $SomeRoleAssignmentIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GARoleAssignment">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet("Remove", "GARoleAssignment",
        SupportsShouldProcess = true,
        HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GARoleAssignment")]
    public class RemoveGARoleAssignmentCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable ID of the Google Apps account.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Immutable ID of the Google Apps account.")]
        public string Customer { get; set; }

        /// <summary>
        /// <para type="description">Immutable ID of the role assignment.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Immutable ID of the role assignment.")]
        public string RoleAssignmentId { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

            if (ShouldProcess("Directory RoleAssignment", "Remove-GARoleAssignment"))
            {
                roleAssignments.Delete(Customer, RoleAssignmentId);
            }

        }
    }

    /// <summary>
    /// <para type="synopsis">Retrieve a role assignment.</para>
    /// <para type="description">Retrieve a role assignment.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GARoleAssignment -Customer $SomeCustomerString -RoleAssignmentId $SomeRoleAssignmentIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GARoleAssignment -Customer $SomeCustomerString -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GARoleAssignment">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GARoleAssignment",
        SupportsShouldProcess = true,
        DefaultParameterSetName = "One",
        HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GARoleAssignment")]
    public class GetGARoleAssignmentCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable ID of the Google Apps account.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Immutable ID of the Google Apps account.")]
        public string Customer { get; set; }

        /// <summary>
        /// <para type="description">Immutable ID of the role assignment.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ParameterSetName = "One",
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Immutable ID of the role assignment.")]
        public string RoleAssignmentId { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = true,
        ParameterSetName = "List",
        HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }

        /// <summary>
        /// <para type="description">Maximum number of results to return.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        ParameterSetName = "List",
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Maximum number of results to return.")]
        public int? MaxResults { get; set; }

        /// <summary>
        /// <para type="description">Immutable ID of a role. If included in the request, returns only role assignments containing this role ID.</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ParameterSetName = "List",
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Immutable ID of a role. If included in the request, returns only role assignments containing this role ID.")]
        public string RoleId { get; set; }

        /// <summary>
        /// <para type="description">The user's primary email address, alias email address, or unique user ID. If included in the request, returns role assignments only for this user.</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ParameterSetName = "List",
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "The user's primary email address, alias email address, or unique user ID. If included in the request, returns role assignments only for this user.")]
        public string UserKey { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

            if (ShouldProcess("Directory RoleAssignment", "Get-GARoleAssignment"))
            {
                if (ParameterSetName == "One")
                {
                    WriteObject(roleAssignments.Get(Customer, RoleAssignmentId));
                }
                else
                {
                    var properties = new dotNet.Directory.RoleAssignments.RoleAssignmentsListProperties()
                    {
                        RoleId = this.RoleId,
                        UserKey = this.UserKey
                    };

                    if (MaxResults.HasValue) properties.TotalResults = MaxResults.Value;

                    WriteObject(roleAssignments.List(Customer, properties).SelectMany(x => x.Items).ToList());
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Creates a role assignment.</para>
    /// <para type="description">Creates a role assignment.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GARoleAssignment -Customer $SomeCustomerString -RoleAssignmentBody $SomeRoleAssignmentObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GARoleAssignment">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet("New", "GARoleAssignment",
    SupportsShouldProcess = true,

      HelpUri = @"https://github.com/squid808/gShell/wiki/New-GARoleAssignment")]
    public class NewGARoleAssignmentCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable ID of the Google Apps account.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Immutable ID of the Google Apps account.")]
        public string Customer { get; set; }

        /// <summary>
        /// <para type="description">JSON template for roleAssignment resource in Directory API.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "JSON template for roleAssignment resource in Directory API.")]
        Data.RoleAssignment RoleAssignmentBody { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

            if (ShouldProcess("Directory RoleAssignment", "New-GARoleAssignment"))
            {
                WriteObject(roleAssignments.Insert(RoleAssignmentBody, Customer));
            }
        }
    }
}

//TODO: REFACTOR SET, NEW
namespace gShell.Cmdlets.Directory.GASchema
{
    /// <summary>
    /// <para type="synopsis">Retrieve schema</para>
    /// <para type="description">Retrieve schema</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GASchema -CustomerId $SomeCustomerIdString -SchemaKey $SomeSchemaKeyString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GASchema -CustomerId $SomeCustomerIdString -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GASchema">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GASchema",
          DefaultParameterSetName = "One",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GASchema")]
    public class GetGASchemaCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable id of the Google Apps account</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Immutable id of the Google Apps account")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Name or immutable Id of the schema</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName = "One",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name or immutable Id of the schema")]
        [ValidateNotNullOrEmpty]
        public string SchemaKey { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results.</para>
        /// </summary>
        [Parameter(Position = 3,
            ParameterSetName = "List",
            HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            CustomerId = string.IsNullOrWhiteSpace(CustomerId) ? "my_customer" : CustomerId;

            if (ShouldProcess(CustomerId, "Get-GASchema"))
            {
                switch (ParameterSetName)
                {
                    case "One":
                        WriteObject((SchemaFieldCollection)schemas.Get(CustomerId, SchemaKey));
                        break;
                    case "List":
                        WriteObject((SchemaFieldCollection)schemas.List(CustomerId).SchemasValue);
                        break;
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Delete schema</para>
    /// <para type="description">Delete schema</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GASchema -CustomerId $SomeCustomerIdString -SchemaKey $SomeSchemaKeyString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GASchema">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GASchema",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GASchema")]
    public class RemoveGASchemaCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable id of the Google Apps account</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Immutable id of the Google Apps account")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Name or immutable Id of the schema</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name or immutable Id of the schema")]
        [ValidateNotNullOrEmpty]
        public string SchemaKey { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            HelpMessage = "A switch to run the cmdlet without prompting.")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            CustomerId = string.IsNullOrWhiteSpace(CustomerId) ? "my_customer" : CustomerId;

            if (ShouldProcess(CustomerId, "Remove-GASchema"))
            {
                if (Force || ShouldContinue((String.Format("Schema Key {0} for CustomerId {2} will be removed from the {1} Google Apps domain.\nContinue?",
                    SchemaKey, GAuthId, CustomerId)), "Confirm Google Apps Schema Removal"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove Schema {0}...",
                            CustomerId));
                        schemas.Delete(CustomerId, SchemaKey);
                        WriteVerbose(string.Format("Removal of Schema {0} completed without error.",
                            CustomerId));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, CustomerId));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Schema deletion not confirmed"),
                        "", ErrorCategory.InvalidData, CustomerId));
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Update schema. This method supports patch semantics.</para>
    /// <para type="description">Update schema. This method supports patch semantics.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GASchema -CustomerId $SomeCustomerIdString -SchemaKey $SomeSchemaKeyString -SchemaBody $SomeSchemaObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GASchema">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GASchema",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GASchema")]
    public class SetGASchemaCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable id of the Google Apps account</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
        HelpMessage = "Immutable id of the Google Apps account")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        /// <summary>
        /// <para type="description">Name or immutable Id of the schema.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
        HelpMessage = "Name or immutable Id of the schema.")]
        [ValidateNotNullOrEmpty]
        public string SchemaKey { get; set; }

        [Parameter(Position = 3,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public SchemaFieldCollection FieldCollection { get; set; }

        ///// <summary>
        ///// <para type="description">JSON template for Schema resource in Directory API.</para>
        ///// </summary>
        //[Parameter(Position = 2,
        //Mandatory = false,
        //ValueFromPipeline = true,
        //ValueFromPipelineByPropertyName = true,
        //HelpMessage = "JSON template for Schema resource in Directory API.")]
        //public Google.Apis.admin.Directory.directory_v1.Data.Schema SchemaBody { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            CustomerId = string.IsNullOrWhiteSpace(CustomerId) ? "my_customer" : CustomerId;

            if (ShouldProcess(CustomerId, "Set-GASchema"))
            {
                WriteObject(schemas.Patch((Data.Schema)FieldCollection, CustomerId, SchemaKey));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Create schema.</para>
    /// <para type="description">Create schema.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GASchema -CustomerId $SomeCustomerIdString -SchemaBody $SomeSchemaObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GASchema">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GASchema",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Add-GASchema")]
    public class NewGASchemaCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Immutable id of the Google Apps account</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Immutable id of the Google Apps account")]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; }

        //Domain position = 1

        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public SchemaFieldCollection FieldCollection { get; set; }

        ///// <summary>
        ///// <para type="description">JSON template for Schema resource in Directory API.</para>
        ///// </summary>
        //[Parameter(Position = 2,
        //Mandatory = false,
        //ValueFromPipeline = true,
        //ValueFromPipelineByPropertyName = true,
        //HelpMessage = "JSON template for Schema resource in Directory API.")]
        //public Google.Apis.admin.Directory.directory_v1.Data.Schema SchemaBody { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            CustomerId = string.IsNullOrWhiteSpace(CustomerId) ? "my_customer" : CustomerId;

            if (ShouldProcess(CustomerId, "Add-GASchema"))
            {
                WriteObject(schemas.Insert((Data.Schema)FieldCollection, CustomerId));
            }
        }
    }

    //TODO: Phase out
    [Cmdlet(VerbsCommon.New, "GASchemaField",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GASchemaField",
          DefaultParameterSetName = "New")]
    public class NewGASchemaFieldCommand : PSCmdlet
    {
        #region Properties
        [Parameter(Position = 0,
            ParameterSetName = "New",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string FieldName { get; set; }

        [Parameter(Position = 1,
            ParameterSetName = "New",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public SchemaField.SchemaFieldType FieldType { get; set; }

        [Parameter(Position = 2,
            ParameterSetName = "New",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public bool? Indexed { get; set; }

        [Parameter(Position = 3,
            ParameterSetName = "New",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public bool? MultiValued { get; set; }

        [Parameter(Position = 4,
            ParameterSetName = "New",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public double? MinValue { get; set; }

        [Parameter(Position = 5,
            ParameterSetName = "New",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public double? MaxValue { get; set; }

        [Parameter(Position = 6,
            ParameterSetName = "New",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public SchemaField.SchemaFieldReadAccessType? ReadAccessType { get; set; }

        [Parameter(Position = 0,
            ParameterSetName = "Google",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public Data.SchemaFieldSpec SchemaFieldSpec { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case "New":

                    SchemaField field = new SchemaField(FieldName, FieldType)
                    {
                        minValue = MinValue,
                        maxValue = MaxValue,
                        indexed = Indexed,
                        multiValued = MultiValued,
                        readAccessType = ReadAccessType
                    };

                    WriteObject(field);
                    break;

                case "Google":
                    WriteObject((SchemaField)SchemaFieldSpec);
                    break;
            }

        }
    }

    //TODO: Phase out
    [Cmdlet(VerbsCommon.New, "GASchemaFieldCollection",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GASchemaFieldCollection",
          DefaultParameterSetName = "New")]
    public class NewGASchemaFieldCollectionCommand : PSCmdlet
    {
        #region Properties
        [Parameter(Position = 0,
            ParameterSetName = "New",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SchemaName { get; set; }

        [Parameter(Position = 1,
            ParameterSetName = "New",
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public SchemaField Field { get; set; }

        [Parameter(Position = 0,
            ParameterSetName = "Google",
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public Data.Schema Schema { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            if (Field != null)
            {
                WriteObject(new SchemaFieldCollection(SchemaName, Field));
            }
            else if (Schema != null)
            {
                WriteObject((SchemaFieldCollection)Schema);
            }
            else
            {
                WriteObject(new SchemaFieldCollection(SchemaName));
            }
        }
    }

    //TODO: Phase out
    /// <summary>
    /// A custom wrapper for a List<SchemaField> type.
    /// </summary>
    public class SchemaFieldCollection
    {
        #region Properties
        public string schemaName;

        public List<SchemaField> fields { get { return _fields; } }

        private List<SchemaField> _fields = new List<SchemaField>();
        #endregion

        #region Getters
        public List<SchemaField> GetFields()
        {
            return _fields;
        }
        #endregion

        #region Constructors
        public SchemaFieldCollection() { }

        public SchemaFieldCollection(string SchemaName)
        {
            schemaName = SchemaName;
        }

        public SchemaFieldCollection(string SchemaName, SchemaField field)
        {
            schemaName = SchemaName;
            Add(field);
        }
        #endregion

        #region Add
        public void Add(SchemaField field)
        {
            _fields.Add(field);
        }
        #endregion

        #region AddRange
        public void AddRange(IEnumerable<SchemaField> fList)
        {
            foreach (SchemaField field in fList)
            {
                _fields.Add(field);
            }
        }
        #endregion

        #region OperatorPlusOverload
        public static SchemaFieldCollection operator +(SchemaFieldCollection coll1, SchemaFieldCollection coll2)
        {
            coll1.AddRange(coll2.fields);

            return coll1;
        }

        public static SchemaFieldCollection operator +(SchemaFieldCollection coll1, SchemaField f2)
        {
            coll1.Add(f2);

            return coll1;
        }
        #endregion

        #region RemoveAt
        public void RemoveAt(int index)
        {
            if (index >= 0)
            {
                if (_fields.Count > index)
                {
                    _fields.RemoveAt(index);
                }
            }
        }
        #endregion

        #region Clear
        public void Clear()
        {
            _fields.Clear();
        }
        #endregion

        #region Explicit Conversion

        public static explicit operator SchemaFieldCollection(Data.Schema schema)
        {
            SchemaFieldCollection coll = new SchemaFieldCollection();

            coll.schemaName = schema.SchemaName;

            foreach (Data.SchemaFieldSpec spec in schema.Fields)
            {
                coll.Add((SchemaField)spec);
            }

            return coll;
        }

        public static explicit operator Data.Schema(SchemaFieldCollection coll)
        {
            Data.Schema schema = new Data.Schema()
            {
                Fields = new List<Data.SchemaFieldSpec>()
            };

            schema.SchemaName = coll.schemaName;

            foreach (SchemaField field in coll.fields)
            {
                schema.Fields.Add((Data.SchemaFieldSpec)field);
            }

            return schema;
        }
        #endregion
    }

    //TODO: Phase out
    /// <summary>
    /// A friendly version of Data.Schema, allowing for use of enums to restrict options.
    /// </summary>
    public class SchemaField
    {
        public enum SchemaFieldType
        {
            STRING, INT64, BOOL, DOUBLE, EMAIL, PHONE, DATE
        }

        public enum SchemaFieldReadAccessType
        {
            ALL_DOMAIN_USERS, ADMINS_AND_SELF
        }

        #region Properties
        public string fieldName;
        public SchemaFieldType fieldType;
        public bool? indexed;
        public bool? multiValued;
        public double? minValue;
        public double? maxValue;
        public SchemaFieldReadAccessType? readAccessType;
        #endregion

        public SchemaField(string FieldName, SchemaFieldType FieldType)
        {
            fieldName = FieldName;
            fieldType = FieldType;
        }

        #region Explicit Conversion
        public static explicit operator SchemaField(Data.SchemaFieldSpec spec)
        {
            SchemaFieldType type = (SchemaFieldType)Enum.Parse(typeof(SchemaFieldType), (string)spec.FieldType, false);

            SchemaField field = new SchemaField(spec.FieldName, type);

            if (spec.Indexed.HasValue)
            {
                field.indexed = spec.Indexed.Value;
            }

            if (spec.MultiValued.HasValue)
            {
                field.multiValued = spec.MultiValued.Value;
            }

            if (spec.NumericIndexingSpec != null &&
                spec.NumericIndexingSpec.MinValue.HasValue &&
                spec.NumericIndexingSpec.MaxValue.HasValue)
            {
                if (spec.NumericIndexingSpec.MinValue.HasValue)
                {
                    field.minValue = spec.NumericIndexingSpec.MinValue.Value;
                }

                if (spec.NumericIndexingSpec.MaxValue.HasValue)
                {
                    field.maxValue = spec.NumericIndexingSpec.MaxValue.Value;
                }
            }

            if (!string.IsNullOrWhiteSpace(spec.ReadAccessType))
            {
                field.readAccessType = (SchemaFieldReadAccessType)Enum.Parse(typeof(SchemaFieldReadAccessType),
                        spec.ReadAccessType, false);
            }

            return field;
        }

        public static explicit operator Data.SchemaFieldSpec(SchemaField field)
        {
            Data.SchemaFieldSpec spec = new Data.SchemaFieldSpec()
            {
                FieldName = field.fieldName,
                FieldType = field.fieldType.ToString(),
                Indexed = field.indexed,
                MultiValued = field.multiValued,
                ReadAccessType = field.readAccessType.ToString()
            };

            spec.NumericIndexingSpec = new Data.SchemaFieldSpec.NumericIndexingSpecData()
            {
                MinValue = field.minValue,
                MaxValue = field.maxValue
            };

            return spec;
        }
        #endregion
    }


}

namespace gShell.Cmdlets.Directory.GAToken
{
    /// <summary>
    /// <para type="synopsis">Get information about an access token issued by a user.</para>
    /// <para type="description">Get information about an access token issued by a user.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAToken -UserKey $SomeUserKeyString -ClientId $SomeClientIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GAToken -UserKey $SomeUserKeyString -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAToken">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAToken",
          DefaultParameterSetName = "One",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAToken")]
    public class GetGATokenCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Identifies the user in the API request. The value can be the user's primary email address, alias email address, or unique user ID.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Identifies the user in the API request. The value can be the user's primary email address, alias email address, or unique user ID.")]
        [ValidateNotNullOrEmpty]
        public string UserKey { get; set; }

        /// <summary>
        /// <para type="description">The Client ID of the application the token is issued to.</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            ParameterSetName = "One",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Client ID of the application the token is issued to.")]
        [ValidateNotNullOrEmpty]
        public string ClientId { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results.</para>
        /// </summary>
        [Parameter(Position = 3,
            ParameterSetName = "List",
            HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            UserKey = GetFullEmailAddress(UserKey, GAuthId);

            if (ShouldProcess(UserKey, "Get-GAToken"))
            {
                switch (ParameterSetName)
                {
                    case "One":
                        WriteObject(tokens.Get(UserKey, ClientId));
                        break;
                    case "List":
                        WriteObject(tokens.List(UserKey).Items);
                        break;
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Delete all access tokens issued by a user for an application.</para>
    /// <para type="description">Delete all access tokens issued by a user for an application.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GAToken -UserKey $SomeUserKeyString -ClientId $SomeClientIdString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GAToken">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GAToken",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GAToken")]
    public class RemoveGATokenCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Identifies the user in the API request. The value can be the user's primary email address, alias email address, or unique user ID.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Identifies the user in the API request. The value can be the user's primary email address, alias email address, or unique user ID.")]
        [ValidateNotNullOrEmpty]
        public string UserKey { get; set; }

        /// <summary>
        /// <para type="description">The Client ID of the application the token is issued to.</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Client ID of the application the token is issued to.")]
        [ValidateNotNullOrEmpty]
        public string ClientId { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting.</para>
        /// </summary>
        [Parameter(Position = 2,
        Mandatory = false,
        HelpMessage = "A switch to run the cmdlet without prompting.")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            UserKey = GetFullEmailAddress(UserKey, GAuthId);

            if (ShouldProcess(ClientId, "Remove-GAToken"))
            {
                if (Force || ShouldContinue((String.Format("Token for application with Client ID of {0} will be removed for user {2} from the {1} Google Apps domain.\nContinue?",
                    ClientId, GAuthId, UserKey)), "Confirm Google Apps Token Removal"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove Token for application {0}...",
                            ClientId));
                        tokens.Delete(UserKey, ClientId);
                        WriteVerbose(string.Format("Removal of Token for application {0} completed without error.",
                            ClientId));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, ClientId));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Token deletion not confirmed"),
                        "", ErrorCategory.InvalidData, ClientId));
                }
            }
        }
    }
}

//TODO: Refactor username -> userkey
//TODO: Add Make Admin User
//TODO: Refactor SET, NEW - allow param set to use object (or pipeline?)
//TODO: Fix Remove
namespace gShell.Cmdlets.Directory.GAUser
{
    /// <summary>
    /// <para type="synopsis">retrieve user</para>
    /// <para type="description">retrieve user</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAUser -UserKey $SomeUserKeyString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <example>
    ///   <code>PS C:\>Get-GAUser -All</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAUser">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAUser",
          DefaultParameterSetName = "OneUser",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAUser")]
    public class GetGAUserCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Email or immutable Id of the user</para>
        /// </summary>
        [Parameter(Position = 0,
            ParameterSetName = "OneUser",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Email or immutable Id of the user")]
        [ValidateNotNullOrEmpty]
        public string UserKey { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results.</para>
        /// </summary>
        [Parameter(Position = 1,
            ParameterSetName = "AllUsers",
            HelpMessage = "A switch to list all results.")]
        public SwitchParameter All { get; set; }

        /// <summary>
        /// <para type="description">Comma-separated list of schema names. All fields from these schemas are fetched. This should only be set when projection=custom.</para>
        /// </summary>
        [Parameter(Position = 2,
            ParameterSetName = "OneUser",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Comma-separated list of schema names. All fields from these schemas are fetched. This should only be set when projection=custom.")]
        [Parameter(Position = 2,
            ParameterSetName = "AllUsers",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Comma-separated list of schema names. All fields from these schemas are fetched. This should only be set when projection=custom.")]
        public string CustomFieldMask { get; set; }

        /// <summary>
        /// <para type="description">What subset of fields to fetch for this user.</para>
        /// </summary>
        [Parameter(Position = 3,
            ParameterSetName = "OneUser",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "What subset of fields to fetch for this user.")]
        public UsersResource.GetRequest.ProjectionEnum? Projection { get; set; }

        [Parameter(Position = 3,
            ParameterSetName = "AllUsers",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "What subset of fields to fetch for this user.")]
        public UsersResource.ListRequest.ProjectionEnum? ProjectionType { get; set; }

        /// <summary>
        /// <para type="description">Whether to fetch the ADMIN_VIEW or DOMAIN_PUBLIC view of the user.</para>
        /// </summary>
        [Parameter(Position = 4,
            ParameterSetName = "OneUser",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether to fetch the ADMIN_VIEW or DOMAIN_PUBLIC view of the user.")]
        public UsersResource.GetRequest.ViewTypeEnum? View { get; set; }

        [Parameter(Position = 4,
            ParameterSetName = "AllUsers",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether to fetch the ADMIN_VIEW or DOMAIN_PUBLIC view of the user.")]
        public UsersResource.ListRequest.ViewTypeEnum? ViewType { get; set; }

        /// <summary>
        /// <para type="description">Immutable id of the Google Apps account. In case of multi-domain, to fetch all users for a customer, fill this field instead of domain.</para>
        /// </summary>
        [Parameter(Position = 5,
            ParameterSetName = "AllUsers",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Immutable id of the Google Apps account. In case of multi-domain, to fetch all users for a customer, fill this field instead of domain.")]
        public string Customer { get; set; }

        ///// <summary>
        ///// <para type="description">Name of the domain. Fill this field to get users from only this domain. To return all users in a multi-domain fill customer field instead.</para>
        ///// </summary>
        //[Parameter(Position = 6,
        //ParameterSetName = "AllUsers",
        //Mandatory = false,
        //ValueFromPipelineByPropertyName = true,
        //HelpMessage = "Name of the domain. Fill this field to get users from only this domain. To return all users in a multi-domain fill customer field instead.")]
        //public string OneDomain { get; set; }

        ///// <summary>
        ///// <para type="description">Event on which subscription is intended (if subscribing)</para>
        ///// </summary>
        //[Parameter(Position = 7,
        //ParameterSetName = "AllUsers",
        //Mandatory = false,
        //ValueFromPipelineByPropertyName = true,
        //HelpMessage = "Event on which subscription is intended (if subscribing)")]
        //public UsersResource.ListRequest.EventEnum? Event { get; set; }

        /// <summary>
        /// <para type="description">Maximum number of results to return. Default is 100. Max allowed is 500</para>
        /// </summary>
        [Parameter(Position = 8,
        ParameterSetName = "AllUsers",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Maximum number of results to return. Default is 100. Max allowed is 500")]
        public int? MaxResults { get; set; }

        /// <summary>
        /// <para type="description">Column to use for sorting results</para>
        /// </summary>
        [Parameter(Position = 9,
        ParameterSetName = "AllUsers",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Column to use for sorting results")]
        public UsersResource.ListRequest.OrderByEnum? OrderBy { get; set; }

        /// <summary>
        /// <para type="description">Query string search. Should be of the form "". Complete documentation is at https://developers.google.com/admin-sdk/directory/v1/guides/search-users</para>
        /// </summary>
        [Parameter(Position = 10,
        ParameterSetName = "AllUsers",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Query string search. Should be of the form \"\". Complete documentation is at https://developers.google.com/admin-sdk/directory/v1/guides/search-users")]
        public string Query { get; set; }

        /// <summary>
        /// <para type="description">If set to true retrieves the list of deleted users. Default is false</para>
        /// </summary>
        [Parameter(Position = 11,
        ParameterSetName = "AllUsers",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "If set to true retrieves the list of deleted users. Default is false")]
        public string ShowDeleted { get; set; }

        /// <summary>
        /// <para type="description">Whether to return results in ascending or descending order.</para>
        /// </summary>
        [Parameter(Position = 12,
        ParameterSetName = "AllUsers",
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Whether to return results in ascending or descending order.")]
        public UsersResource.ListRequest.SortOrderEnum? SortOrder { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case "OneUser":

                    UserKey = GetFullEmailAddress(UserKey, GAuthId);

                    var properties = new dotNet.Directory.Users.UsersGetProperties()
                    {
                        CustomFieldMask = this.CustomFieldMask,
                        Projection = this.Projection,
                        ViewType = this.View
                    };

                    if (ShouldProcess(UserKey, "Get-GAUser"))
                    {
                        WriteObject(new GShellUserObject(users.Get(UserKey, properties)));
                    }
                    break;

                case "AllUsers":

                    Customer = string.IsNullOrWhiteSpace(Customer) ? "my_customer" : Customer;

                    if (ShouldProcess("All Users", "Get-GAUser"))
                    {
                        var listproperties = new dotNet.Directory.Users.UsersListProperties()
                        {
                            CustomFieldMask = this.CustomFieldMask,
                            //Event = this.Event,
                            OrderBy = this.OrderBy,
                            Projection = this.ProjectionType,
                            Query = this.Query,
                            ShowDeleted = this.ShowDeleted,
                            SortOrder = this.SortOrder,
                            ViewType = this.ViewType
                        };

                        if (!string.IsNullOrWhiteSpace(this.Customer)) listproperties.Customer = this.Customer;
                        else listproperties.Domain = this.GAuthId;

                        //Make sure to include the domain here because List could use things other than domain (customer, etc)
                        List<Data.User> result = users.List(listproperties).SelectMany(x => x.UsersValue).ToList();

                        WriteObject(GShellUserObject.ConvertList(result));
                    }
                    break;
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">create user.</para>
    /// <para type="description">create user.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GAUser -UserBody $SomeUserObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GAUser">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GAUser",
          DefaultParameterSetName = "PasswordGenerated",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAUser")]
    public sealed class NewGAUserCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">User's name</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "User's name")]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        /// <summary>
        /// <para type="description">First Name</para>
        /// </summary>
        [Parameter(Position = 2,
            ParameterSetName = "PasswordProvided",
            Mandatory = true,
        HelpMessage = "First Name")]
        [Parameter(Position = 2,
            ParameterSetName = "PasswordGenerated",
            Mandatory = true,
        HelpMessage = "First Name")]
        [Parameter(Position = 2,
            ParameterSetName = "SecureString",
            Mandatory = true,
        HelpMessage = "First Name")]
        public string GivenName { get; set; }

        /// <summary>
        /// <para type="description">Last Name</para>
        /// </summary>
        [Parameter(Position = 3,
            ParameterSetName = "PasswordProvided",
            Mandatory = true,
            HelpMessage = "Full Name")]
        [Parameter(Position = 3,
            ParameterSetName = "PasswordGenerated",
            Mandatory = true,
            HelpMessage = "Full Name")]
        [Parameter(Position = 3,
            ParameterSetName = "SecureString",
            Mandatory = true,
            HelpMessage = "Full Name")]
        public string FamilyName { get; set; }

        /// <summary>
        /// <para type="description">User's password</para>
        /// </summary>
        [Parameter(Position = 4,
            ParameterSetName = "PasswordProvided",
            HelpMessage = "User's password")]
        public string Password { get; set; }

        /// <summary>
        /// <para type="description">A secure string password.</para>
        /// </summary>
        [Parameter(Position = 6,
            HelpMessage = "A secure string password.",
            ParameterSetName = "SecureString")]
        public SecureString SecureStringPassword { get; set; }

        /// <summary>
        /// <para type="description">The desired length of the generated password</para>
        /// </summary>
        [Parameter(Position = 5,
            ParameterSetName = "PasswordGenerated",
            HelpMessage = "The desired length of the generated password")]
        public int? PasswordLength { get; set; }

        /// <summary>
        /// <para type="description">Indicates if the generated password should be shown</para>
        /// </summary>
        [Parameter(Position = 6,
            ParameterSetName = "PasswordGenerated",
            HelpMessage = "Indicates if the generated password should be shown")]
        public SwitchParameter ShowNewPassword { get; set; }

        /// <summary>
        /// <para type="description">Boolean indicating if user is included in Global Address List</para>
        /// </summary>
        [Parameter(Position = 7,
            ParameterSetName = "PasswordProvided",
            HelpMessage = "Boolean indicating if user is included in Global Address List")]
        [Parameter(Position = 7,
            ParameterSetName = "PasswordGenerated",
            HelpMessage = "Boolean indicating if user is included in Global Address List")]
        [Parameter(Position = 7,
            ParameterSetName = "SecureString",
            HelpMessage = "Boolean indicating if user is included in Global Address List")]
        public bool? IncludeInDirectory { get; set; }

        /// <summary>
        /// <para type="description">Indicates if user is suspended</para>
        /// </summary>
        [Parameter(Position = 8,
            ParameterSetName = "PasswordProvided",
            HelpMessage = "Indicates if user is suspended")]
        [Parameter(Position = 8,
            ParameterSetName = "PasswordGenerated",
            HelpMessage = "Indicates if user is suspended")]
        [Parameter(Position = 8,
            ParameterSetName = "SecureString",
            HelpMessage = "Indicates if user is suspended")]
        public bool? Suspended { get; set; }

        /// <summary>
        /// <para type="description">Boolean indicating if ip is whitelisted</para>
        /// </summary>
        [Parameter(Position = 9,
            ParameterSetName = "PasswordProvided",
            HelpMessage = "Boolean indicating if ip is whitelisted")]
        [Parameter(Position = 9,
            ParameterSetName = "PasswordGenerated",
            HelpMessage = "Boolean indicating if ip is whitelisted")]
        [Parameter(Position = 9,
            ParameterSetName = "SecureString",
            HelpMessage = "Boolean indicating if ip is whitelisted")]
        public bool? IpWhiteListed { get; set; }

        /// <summary>
        /// <para type="description">Boolean indicating if the user should change password in next login</para>
        /// </summary>
        [Parameter(Position = 10,
            ParameterSetName = "PasswordProvided",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Boolean indicating if the user should change password in next login")]
        [Parameter(Position = 10,
            ParameterSetName = "PasswordGenerated",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Boolean indicating if the user should change password in next login")]
        [Parameter(Position = 10,
            ParameterSetName = "SecureString",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Boolean indicating if the user should change password in next login")]
        public bool? ChangePasswordAtNextLogin { get; set; }

        /// <summary>
        /// <para type="description">OrgUnit of User</para>
        /// </summary>
        [Parameter(Position = 11,
            ParameterSetName = "PasswordProvided",
            HelpMessage = "OrgUnit of User")]
        [Parameter(Position = 11,
            ParameterSetName = "PasswordGenerated",
            HelpMessage = "OrgUnit of User")]
        [Parameter(Position = 11,
            ParameterSetName = "SecureString",
            HelpMessage = "OrgUnit of User")]
        public string OrgUnitPath { get; set; }

        /// <summary>
        /// <para type="description">JSON template for User object in Directory API.</para>
        /// </summary>
        [Parameter(Position = 0,
        Mandatory = false,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = "Body",
        HelpMessage = "JSON template for User object in Directory API.")]
        public Data.User UserBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(UserName, "New-GAUser"))
            {
                if (ParameterSetName == "Body")
                {
                    users.Insert(UserBody);
                }
                else
                {
                    CreateUser();
                }
            }
        }

        private void CreateUser()
        {
            Data.User userAcct = new Data.User();

            userAcct.Name = new Data.UserName();

            userAcct.Name.GivenName = GivenName;

            userAcct.Name.FamilyName = FamilyName;

            userAcct.PrimaryEmail = GetFullEmailAddress(UserName, GAuthId);

            switch (ParameterSetName)
            {
                case "PasswordProvided":
                    userAcct.HashFunction = "MD5";
                    userAcct.Password = GetMd5Hash(Password);
                    break;

                case "PasswordGenerated":
                    userAcct.HashFunction = "MD5";
                    userAcct.Password = GeneratePassword(PasswordLength, ShowNewPassword);
                    break;

                case "SecureString":
                    userAcct.HashFunction = "MD5";
                    userAcct.Password = GetMd5Hash(ConvertToUnsecureString(SecureStringPassword));
                    break;
            }

            if (IncludeInDirectory.HasValue) userAcct.IncludeInGlobalAddressList = IncludeInDirectory;

            if (Suspended.HasValue) userAcct.Suspended = Suspended;

            if (IpWhiteListed.HasValue) userAcct.IpWhitelisted = IpWhiteListed;

            if (ChangePasswordAtNextLogin.HasValue) userAcct.ChangePasswordAtNextLogin = ChangePasswordAtNextLogin.Value;

            if (!string.IsNullOrWhiteSpace(OrgUnitPath)) userAcct.OrgUnitPath = OrgUnitPath;

            users.Insert(userAcct);
        }

        private string ConvertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
                throw new ArgumentNullException("securePassword");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Delete user</para>
    /// <para type="description">Delete user</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GAUser -UserKey $SomeUserKeyString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GAUser">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GAUser",
        DefaultParameterSetName = "UserKey",
        SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GAUser")]
    public class RemoveGAUserCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Email or immutable Id of the user</para>
        /// </summary>
        [Parameter(Position = 0,
            ParameterSetName = "UserKey",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Help Text")]
        [ValidateNotNullOrEmpty]
        public string UserKey { get; set; }

        /// <summary>
        /// <para type="description">A Google Apps User object</para>
        /// </summary>
        [Parameter(Position = 0,
            ParameterSetName = "GAUserObject",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A Google Apps User object")]
        [ValidateNotNullOrEmpty]
        public Data.User GAUserObject { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting</para>
        /// </summary>
        [Parameter(Position = 2,
            HelpMessage = "A switch to run the cmdlet without prompting")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(UserKey, "Remove-GAUser"))
            {
                if (Force || ShouldContinue((String.Format("User {0} will be removed from the {1} Google Apps domain.\nContinue?",
                    UserKey, GAuthId)), "Confirm Google Apps User Removal"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove user {0}@{1}...",
                            UserKey, GAuthId));
                        RemoveUser();
                        WriteVerbose(string.Format("Removal of {0}@{1} completed without error.",
                            UserKey, GAuthId));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), 
                            ErrorCategory.InvalidData, UserKey));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Account deletion not confirmed"),
                        "", ErrorCategory.InvalidData, UserKey));
                }
            }
        }

        private void RemoveUser()
        {
            string fullEmail = "";
            switch (ParameterSetName)
            {
                case "UserKey":
                    fullEmail = UserKey;
                    break;

                case "GAUserObject":
                    fullEmail = GAUserObject.PrimaryEmail;
                    break;
            }

            users.Delete(GetFullEmailAddress(fullEmail, GAuthId));
        }
    }

    /// <summary>
    /// <para type="synopsis">Undelete a deleted user</para>
    /// <para type="description">Undelete a deleted user</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Restore-GAUser -UserKey $SomeUserKeyString -UserUndeleteBody $SomeUserUndeleteObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Restore-GAUser">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsData.Restore, "GAUser",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Restore-GAUser")]
    public class RestoreGAUserCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Email or immutable Id of the user. If Id, it should match with id of user object</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The unique UserID")]
        [ValidateNotNullOrEmpty]
        public string UserID { get; set; }

        /// <summary>
        /// <para type="description">OrgUnit of User</para>
        /// </summary
        [Parameter(Position = 1,
            Mandatory = false,
            HelpMessage = "OrgUnit of User")]
        public string OrgUnitPath { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(UserID, "Restore-GAUser"))
            {
                RestoreUser();
            }
        }

        private void RestoreUser()
        {
            var undelete = new Data.UserUndelete();

            if (string.IsNullOrWhiteSpace(OrgUnitPath))
            {
                undelete.OrgUnitPath = @"/";
            }
            else
            {
                undelete.OrgUnitPath = OrgUnitPath;
            }

            users.Undelete(undelete, UserID);
        }
    }

    /// <summary>
    /// <para type="synopsis">update user. This method supports patch semantics.</para>
    /// <para type="description">update user. This method supports patch semantics.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GAUser -UserKey $SomeUserKeyString -UserBody $SomeUserObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GAUser">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GAUser",
          DefaultParameterSetName = "PasswordProvided",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAUser")]
    public sealed class SetGAUserCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">User's name</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The username of the user to update.")]
        [ValidateNotNullOrEmpty]
        public string UserKey { get; set; }
        
        /// <summary>
        /// <para type="description">First Name</para>
        /// </summary>
        [Parameter(Position = 2,
            ParameterSetName = "PasswordProvided",
            HelpMessage = "The user's first name. Required when creating a user account.")]
        [Parameter(Position = 2,
            ParameterSetName = "PasswordGenerated",
            HelpMessage = "The user's first name. Required when creating a user account.")]
        [Parameter(Position = 2,
            ParameterSetName = "SecureString",
            HelpMessage = "The user's first name. Required when creating a user account.")]
        public string NewGivenName { get; set; }

        /// <summary>
        /// <para type="description">Last Name</para>
        /// </summary>
        [Parameter(Position = 3,
            ParameterSetName = "PasswordProvided",
            HelpMessage = "The user's last name. Required when creating a user account.")]
        [Parameter(Position = 3,
            ParameterSetName = "PasswordGenerated",
            HelpMessage = "The user's last name. Required when creating a user account.")]
        [Parameter(Position = 3,
            ParameterSetName = "SecureString",
            HelpMessage = "The user's last name. Required when creating a user account.")]
        public string NewFamilyName { get; set; }

        /// <summary>
        /// <para type="description">Updated user's name</para>
        /// </summary>
        [Parameter(Position = 4,
            ParameterSetName = "PasswordProvided",
            HelpMessage = "The user's username, post-update.")]
        [Parameter(Position = 4,
            ParameterSetName = "PasswordGenerated",
            HelpMessage = "The user's username, post-update.")]
        [Parameter(Position = 4,
            ParameterSetName = "SecureString",
            HelpMessage = "The user's username, post-update.")]
        public string NewUserName { get; set; }

        /// <summary>
        /// <para type="description">Indicates if user is suspended</para>
        /// </summary>
        [Parameter(Position = 5,
            ParameterSetName = "PasswordProvided",
            HelpMessage = "Indicates if the user is suspended.")]
        [Parameter(Position = 5,
            ParameterSetName = "PasswordGenerated",
            HelpMessage = "Indicates if the user is suspended.")]
        [Parameter(Position = 5,
            ParameterSetName = "SecureString",
            HelpMessage = "Indicates if the user is suspended.")]
        public bool? Suspended { get; set; }

        /// <summary>
        /// <para type="description">User's password</para>
        /// </summary>
        [Parameter(Position = 6,
            HelpMessage = "Stores the password for the user account. A password can contain any combination of ASCII characters. A minimum of 8 characters is required. The maximum length is 100 characters.",
            ParameterSetName = "PasswordProvided")]
        public string NewPassword { get; set; }

        /// <summary>
        /// <para type="description">A secure string password.</para>
        /// </summary>
        [Parameter(Position = 6,
            HelpMessage = "A secure string password.",
            ParameterSetName = "SecureString")]
        public SecureString SecureStringPassword { get; set; }

        /// <summary>
        /// <para type="description">The desired length of the generated password</para>
        /// </summary
        [Parameter(Position = 7,
            HelpMessage = "Indicates the length of the password desired if it is to be automatically generated.",
            ParameterSetName = "PasswordGenerated")]
        public int? PasswordLength { get; set; }

        /// <summary>
        /// <para type="description">Indicates if the generated password should be shown</para>
        /// </summary>
        [Parameter(Position = 8,
            HelpMessage = "Indicates if the new password should be shown after it is to be automatically generated.",
            ParameterSetName = "PasswordGenerated")]
        public SwitchParameter ShowNewPassword { get; set; }

        /// <summary>
        /// <para type="description">Boolean indicating if the user should change password in next login</para>
        /// </summary>
        [Parameter(Position = 9,
            ParameterSetName = "PasswordProvided",
            HelpMessage = "Indicates if the user is forced to change their password at next login.")]
        [Parameter(Position = 9,
            ParameterSetName = "PasswordGenerated",
            HelpMessage = "Indicates if the user is forced to change their password at next login.")]
        [Parameter(Position = 9,
            ParameterSetName = "SecureString",
            HelpMessage = "Indicates if the user is forced to change their password at next login.")]
        public bool? ChangePasswordAtNextLogin { get; set; }

        /// <summary>
        /// <para type="description">OrgUnit of User</para>
        /// </summary>
        [Parameter(Position = 10,
            ParameterSetName = "PasswordProvided",
            HelpMessage = "The full path of the parent organization associated with the user. If the parent organization is the top-level, it is represented as a forward slash (/).")]
        [Parameter(Position = 10,
            ParameterSetName = "PasswordGenerated",
            HelpMessage = "The full path of the parent organization associated with the user. If the parent organization is the top-level, it is represented as a forward slash (/).")]
        [Parameter(Position = 10,
            ParameterSetName = "SecureString",
            HelpMessage = "The full path of the parent organization associated with the user. If the parent organization is the top-level, it is represented as a forward slash (/).")]
        public string OrgUnitPath { get; set; }

        /// <summary>
        /// <para type="description">A supplied property collection to update the user with. Create with New/Get-GAUserPropertyCollection and update with New/Remove-GauserProperty</para>
        /// </summary>
        [Parameter(Position = 11,
            ParameterSetName = "PasswordProvided",
            HelpMessage = "A supplied property collection to update the user with. Create with New/Get-GAUserPropertyCollection and update with New/Remove-GauserProperty")]
        [Parameter(Position = 11,
            ParameterSetName = "PasswordGenerated",
            HelpMessage = "A supplied property collection to update the user with. Create with New/Get-GAUserPropertyCollection and update with New/Remove-GauserProperty")]
        [Parameter(Position = 11,
            ParameterSetName = "SecureString",
            HelpMessage = "A supplied property collection to update the user with. Create with New/Get-GAUserPropertyCollection and update with New/Remove-GauserProperty")]
        public GAUserPropertyCollection PropertyCollection { get; set; }

        /// <summary>
        /// <para type="description">JSON template for User object in Directory API.</para>
        /// </summary>
        [Parameter(Position = 1,
        Mandatory = false,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        ParameterSetName = "Body",
        HelpMessage = "JSON template for User object in Directory API.")]
        public Data.User UserBody { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            UserKey = GetFullEmailAddress(UserKey, GAuthId);

            if (ShouldProcess(UserKey, "Set-GAUser"))
            {
                if (ParameterSetName == "Body")
                {
                    users.Patch(UserBody, UserKey);
                }
                else
                {
                    UpdateUser();
                }
            }
        }

        private void UpdateUser()
        {
            Data.User userAcct = new Data.User();

            if (String.IsNullOrWhiteSpace(NewGivenName) &&
                String.IsNullOrWhiteSpace(NewFamilyName) &&
                String.IsNullOrWhiteSpace(NewUserName) &&
                String.IsNullOrWhiteSpace(NewPassword) &&
                !PasswordLength.HasValue &&
                ShowNewPassword == false &&
                !Suspended.HasValue &&
                !ChangePasswordAtNextLogin.HasValue &&
                String.IsNullOrWhiteSpace(OrgUnitPath) &&
                null == PropertyCollection &&
                null == SecureStringPassword)
            {
                WriteError(new ErrorRecord(new Exception(
                    string.Format("No data was entered to update {0}.", UserKey)),
                        "", ErrorCategory.InvalidData, UserKey));
            }

            if (Suspended.HasValue)
                userAcct.Suspended = Suspended.Value;

            if (!String.IsNullOrWhiteSpace(NewGivenName))
            {
                if (userAcct.Name == null) userAcct.Name = new Data.UserName();
                userAcct.Name.GivenName = NewGivenName;
            }

            if (!String.IsNullOrWhiteSpace(NewFamilyName))
            {
                if (userAcct.Name == null) userAcct.Name = new Data.UserName();
                userAcct.Name.FamilyName = NewFamilyName;
            }

            if (!String.IsNullOrWhiteSpace(NewUserName))
            {
                NewUserName = GetFullEmailAddress(NewUserName, GAuthId);
                userAcct.PrimaryEmail = NewUserName;
            }

            switch (ParameterSetName)
            {
                case "PasswordProvided":
                    if (!string.IsNullOrWhiteSpace(NewPassword))
                    {
                        userAcct.HashFunction = "MD5";
                        userAcct.Password = GetMd5Hash(NewPassword);
                    }
                    break;

                case "PasswordGenerated":
                    userAcct.HashFunction = "MD5";
                    userAcct.Password = GeneratePassword(PasswordLength, ShowNewPassword);
                    break;

                case "SecureString":
                    userAcct.HashFunction = "MD5";
                    userAcct.Password = GetMd5Hash(ConvertToUnsecureString(SecureStringPassword));
                    break;
            }

            if (ChangePasswordAtNextLogin.HasValue)
                userAcct.ChangePasswordAtNextLogin = ChangePasswordAtNextLogin.Value;

            if (!string.IsNullOrWhiteSpace(OrgUnitPath))
                userAcct.OrgUnitPath = OrgUnitPath;

            if (null != PropertyCollection)
            {
                //here we don't check if it's an empty list since that may be on purpose - we check it that list had been updated.
                if (PropertyCollection.IsUpdated(GAUserPropertyType.address))
                    userAcct.Addresses = PropertyCollection.GetAddresses();

                if (PropertyCollection.IsUpdated(GAUserPropertyType.email))
                    userAcct.Emails = PropertyCollection.GetEmails();

                if (PropertyCollection.IsUpdated(GAUserPropertyType.externalid))
                    userAcct.ExternalIds = PropertyCollection.GetExternalIds();

                if (PropertyCollection.IsUpdated(GAUserPropertyType.im))
                    userAcct.Ims = PropertyCollection.GetIms();

                if (PropertyCollection.IsUpdated(GAUserPropertyType.organization))
                    userAcct.Organizations = PropertyCollection.GetOrganizations();

                if (PropertyCollection.IsUpdated(GAUserPropertyType.phone))
                    userAcct.Phones = PropertyCollection.GetPhones();

                if (PropertyCollection.IsUpdated(GAUserPropertyType.relation))
                    userAcct.Relations = PropertyCollection.GetRelations();
            }

            users.Patch(userAcct, UserKey);
        }

        private string ConvertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
                throw new ArgumentNullException("securePassword");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}

//TODO: Refactor List to evaluate ReturnGoogleAPIObjects
namespace gShell.Cmdlets.Directory.GAUserAlias
{
    /// <summary>
    /// <para type="synopsis">List all aliases for a user</para>
    /// <para type="description">List all aliases for a user</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAUserAlias -UserKey $SomeUserKeyString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAUserAlias">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAUserAlias",
          DefaultParameterSetName = "OneUser",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAUserAlias")]
    public class GetGAUserAliasCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Email or immutable Id of the user</para>
        /// </summary>
        [Parameter(Position = 0,
            ParameterSetName = "OneUser",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Email or immutable Id of the user")]
        [ValidateNotNullOrEmpty]
        public string UserKey { get; set; }

        /// <summary>
        /// <para type="description">A switch to list all results</para>
        /// </summary>
        [Parameter(Position = 2,
            ParameterSetName = "AllUserAliases",
            HelpMessage = "A switch to list all results")]
        public SwitchParameter All { get; set; }

        [Parameter(
            ParameterSetName = "AllUserAliases")]
        public SwitchParameter ReturnGoogleAPIObjects { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case "OneUser":
                    UserKey = GetFullEmailAddress(UserKey, GAuthId);

                    if (ShouldProcess(UserKey, "Get-GAUserAlias"))
                    {
                        //var properties = new dotNet.Directory.Users.Aliases.AliasesListProperties()
                        //{
                        //    //Event = this.Event
                        //};

                        var results = users.aliases.List(UserKey);

                        WriteObject(results.AliasesValue.ToList());
                    }
                    break;

                case "AllUserAliases":
                    if (ShouldProcess("All User Aliases", "Get-GAUserAlias"))
                    {
                        if (ReturnGoogleAPIObjects)
                        {
                            WriteObject(GetAllAliases());
                        }
                        else
                        {
                            WriteObject(GetAllCustomAliases());
                        };
                    }
                    break;
            }
        }

        private List<GAUserAliasObject> GetAllCustomAliases()
        {
            List<GAUserAliasObject> customAliasList = new List<GAUserAliasObject>();

            List<Data.Alias> aliasList = GetAllAliases();

            foreach (Data.Alias alias in aliasList)
            {
                customAliasList.Add(new GAUserAliasObject(alias.PrimaryEmail, alias.AliasValue, alias));
            }

            return customAliasList;
        }

        /// <summary>
        /// Take a list of users who have an Data.Alias, and for each user get a list of their aliases. Makes potentially many API calls.
        /// </summary>
        private List<Data.Alias> GetAllAliases()
        {
            //HashSet<Data.User> usersList = new HashSet<Data.User>();

            var allUsers = users.List(new dotNet.Directory.Users.UsersListProperties());

            List<Data.User> usersList = allUsers.SelectMany(x => x.UsersValue)
                .Where(x => x.Aliases != null).Distinct().ToList();

            List<Data.Alias> aliasList = new List<Data.Alias>();

            int i = 1;

            foreach (Data.User user in usersList)
            {
                UpdateProgressBar(i, usersList.Count, "Gathering aliases",
                    string.Format("-Collecting alias for user {0} of {1}",
                    i, usersList.Count));
                aliasList.AddRange(users.aliases.List(user.PrimaryEmail).AliasesValue.Cast<Data.Alias>());
                i++;
            }

            return aliasList;
        }
    }


    public class GAUserAliasObject
    {
        public string UserName;
        public string Alias;
        public Data.Alias BaseObject;

        public GAUserAliasObject(string _userName, string _alias, Data.Alias baseAlias)
        {
            UserName = _userName;
            Alias = _alias;
            BaseObject = baseAlias;
        }
    }

    /// <summary>
    /// <para type="synopsis">Add a alias for the user</para>
    /// <para type="description">Add a alias for the user</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GAUserAlias -UserKey $SomeUserKeyString -AliasBody $SomeAliasObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GAUserAlias">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GAUserAlias",
          DefaultParameterSetName = "PasswordGenerated",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAUserAlias")]
    public class NewGAUserAliasCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Email or immutable Id of the user</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The user's main username")]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        /// <summary>
        /// <para type="description">A alias email</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            HelpMessage = "A alias email")]
        public string Alias { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            UserName = GetFullEmailAddress(UserName, GAuthId);

            if (ShouldProcess(UserName, "New-GAUserAlias"))
            {
                Data.Alias aliasBody = new Data.Alias()
                {
                    AliasValue = GetFullEmailAddress(Alias, GAuthId)
                };

                WriteObject(users.aliases.Insert(aliasBody, UserName));
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Remove a alias for the user</para>
    /// <para type="description">Remove a alias for the user</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GAUserAlias -UserKey $SomeUserKeyString -Alias $SomeAliasString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GAUserAlias">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GAUserAlias",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GAUserAlias")]
    public class RemoveGAUserAliasCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">The alias to be removed</para>
        /// </summary>
        [Parameter(Position = 0,
            ParameterSetName = "UserAliasName",
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The user alias account to remove")]
        [ValidateNotNullOrEmpty]
        public string UserAliasName { get; set; }

        /// <summary>
        /// <para type="description">Email or immutable Id of the user</para>
        /// </summary>
        [Parameter(Position = 2,
            ParameterSetName = "UserAliasName",
            Mandatory = false,
            HelpMessage = "The user account to which the alias belongs")]
        [ValidateNotNullOrEmpty]
        public string UserKey { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting</para>
        /// </summary>
        [Parameter(Position = 3,
            HelpMessage = "A switch to run the cmdlet without prompting")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            UserAliasName = GetFullEmailAddress(UserAliasName, GAuthId);

            if (ShouldProcess(UserAliasName, "Remove-GAUserAlias"))
            {
                if (Force || ShouldContinue((String.Format("User alias {0} will be removed from the {1} Google Apps domain.\nContinue?",
                    UserAliasName, GAuthId)), "Confirm Google Apps user alias Removal"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove user alias {0}@{1}...",
                            UserAliasName, GAuthId));

                        if (string.IsNullOrWhiteSpace(UserKey))
                        {
                            UserKey = users.Get(UserAliasName).PrimaryEmail;
                        }

                        users.aliases.Delete(UserKey, UserAliasName);

                        WriteVerbose(string.Format("Removal of {0}@{1} completed without error.",
                            UserAliasName, GAuthId));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, UserAliasName));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Alias deletion not confirmed"),
                        "", ErrorCategory.InvalidData, UserAliasName));
                }
            }
        }
    }
}

namespace gShell.Cmdlets.Directory.GAUserPhoto
{
    /// <summary>
    /// <para type="synopsis">Retrieve photo of a user</para>
    /// <para type="description">Retrieve photo of a user</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAUserPhoto -UserKey $SomeUserKeyString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAUserPhoto">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAUserPhoto",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAUserPhoto")]
    public class GetGAUserPhotoCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Email or immutable Id of the user</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
        HelpMessage = "Email or immutable Id of the user")]
        [ValidateNotNullOrEmpty]
        public string UserKey { get; set; }

        /// <summary>
        /// <para type="description">Desired path for resulting file</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Desired path for resulting file")]
        [ValidateNotNullOrEmpty]
        public string FilePath { get; set; }

        /// <summary>
        /// <para type="description">Will not overwrite (replace the contents) of an existing file. By default, if a file exists in the specified path, Out-File overwrites the file without warning. If both Append and NoClobber are used, the output is appended to the existing file.</para>
        /// </summary>
        [Parameter(Position = 3,
            Mandatory = false,
            HelpMessage = "Will not overwrite (replace the contents) of an existing file. By default, if a file exists in the specified path, Out-File overwrites the file without warning. If both Append and NoClobber are used, the output is appended to the existing file.")]
        public SwitchParameter NoClobber { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            UserKey = GetFullEmailAddress(UserKey, GAuthId);

            if (ShouldProcess(UserKey, "Get-GAUserPhoto"))
            {
                try
                {
                    Data.UserPhoto result = users.photos.Get(UserKey);

                    if (FilePath != null)
                    {
                        FilePath = Path.Combine(Path.GetDirectoryName(FilePath), string.Format("{0}.{1}", Path.GetFileNameWithoutExtension(FilePath), result.MimeType.Split('/')[1]));

                        Utils.SaveImageFromBase64(result.PhotoData, FilePath, NoClobber.IsPresent);
                    }
                    else
                    {
                        WriteObject(result);
                    }
                }
                catch (Exception e)
                {
                    WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, UserKey));
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Remove photos for the user</para>
    /// <para type="description">Remove photos for the user</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Remove-GAUserPhoto -UserKey $SomeUserKeyString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Remove-GAUserPhoto">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "GAUserPhoto",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GAUserPhoto")]
    public class RemoveGAUserPhotoCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Email or immutable Id of the user</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
        HelpMessage = "Email or immutable Id of the user")]
        [ValidateNotNullOrEmpty]
        public string UserKey { get; set; }

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
            UserKey = GetFullEmailAddress(UserKey, GAuthId);

            if (ShouldProcess(UserKey, "Remove-GAUserPhoto"))
            {
                if (Force || ShouldContinue((String.Format("Photo for User {0} will be removed from the {1} Google Apps domain.\nContinue?",
                    UserKey, GAuthId)), "Confirm Google Apps User Photo Removal"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to remove Photo for User {0}...",
                            UserKey));
                        users.photos.Delete(UserKey);
                        WriteVerbose(string.Format("Removal of User {0}'s photo completed without error.",
                            UserKey));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, UserKey));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("User Photo deletion not confirmed"),
                        "", ErrorCategory.InvalidData, UserKey));
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Add a photo for the user. This method supports patch semantics.</para>
    /// <para type="description">Add a photo for the user. This method supports patch semantics.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Set-GAUserPhoto -UserKey $SomeUserKeyString -UserPhotoBody $SomeUserPhotoObj</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Set-GAUserPhoto">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "GAUserPhoto",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Set-GAUserPhoto")]
    public class SetGAUserPhotoCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Email or immutable Id of the user</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Email or immutable Id of the user")]
        [ValidateNotNullOrEmpty]
        public string UserKey { get; set; }

        /// <summary>
        /// <para type="description">Path to the source file</para>
        /// </summary>
        [Parameter(Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Path to the source file")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        /// <summary>
        /// <para type="description">Height in pixels of the photo</para>
        /// </summary>
        [Parameter(Position = 3,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Height in pixels of the photo")]
        [ValidateNotNullOrEmpty]
        public int? Height { get; set; }

        /// <summary>
        /// <para type="description">Mime Type of the photo</para>
        /// </summary>
        [Parameter(Position = 4,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Mime Type of the photo")]
        [ValidateNotNullOrEmpty]
        public MimeTypeEnum? MimeType { get; set; }

        /// <summary>
        /// <para type="description">Width in pixels of the photo</para>
        /// </summary>
        [Parameter(Position = 5,
        Mandatory = false,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Width in pixels of the photo")]
        [ValidateNotNullOrEmpty]
        public int? Width { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            UserKey = GetFullEmailAddress(UserKey, GAuthId);

            if (ShouldProcess(UserKey, "Set-GAUserPhoto"))
            {
                Data.UserPhoto body = new Data.UserPhoto();

                if (MimeType.HasValue)
                {
                    body.MimeType = MimeType.Value.ToString();
                }

                if (Height.HasValue)
                {
                    body.Height = Height.Value;
                }

                if (Width.HasValue)
                {
                    body.Width = Width.Value;
                }

                body.PhotoData = Utils.LoadImageToBase64(Path);

                WriteObject(users.photos.Update(body, UserKey));
            }
        }
    }

    public enum MimeTypeEnum
    {
        JPEG, PNG, GIF, BMP, TIFF
    }
}

//todo: refactor?
namespace gShell.Cmdlets.Directory.GAUserProperty
{
    public class GAUserPropertyBaseCommand : DirectoryBase
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
            AddRange(GAUserPropertyBaseCommand.GetAddressFromUser(u));
            AddRange(GAUserPropertyBaseCommand.GetEmailFromUser(u));
            AddRange(GAUserPropertyBaseCommand.GetExIdFromUser(u));
            AddRange(GAUserPropertyBaseCommand.GetImFromUser(u));
            AddRange(GAUserPropertyBaseCommand.GetOrgFromUser(u));
            AddRange(GAUserPropertyBaseCommand.GetPhoneFromUser(u));
            AddRange(GAUserPropertyBaseCommand.GetRelationFromUser(u));
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

    [Cmdlet(VerbsCommon.Get, "GAUserProperty",
         SupportsShouldProcess = true,
         HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAUserProperty")]
    public class GetGAUserPropertyCommand : GAUserPropertyBaseCommand
    {
        #region Properties

        //UserName = 0

        //Domain position = 1

        [Parameter(Position = 2,
           Mandatory = false,
           HelpMessage = "The GShellUserObject to act upon. For example, the result of Get-GAUser",
           ValueFromPipeline = true)]
        public GShellUserObject GShellObject { get; set; }

        [Parameter(Position = 3,
           Mandatory = true,
           HelpMessage = "The property type to retrieve for the user. Allowed values are: address, email, externalid, im, organization, phone, relation.",
           ParameterSetName = "OneType")]
        [Alias("Type")]
        public GAUserPropertyType PropertyType { get; set; }

        [Parameter(Position = 3,
           Mandatory = true,
           HelpMessage = "Get all property types for the given user as a Property Collection.",
           ParameterSetName = "AllTypes")]
        public SwitchParameter AllTypes { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            UserName = GetFullEmailAddress(UserName, GAuthId);

            if (ShouldProcess(UserName, "Get-GAUserProperty"))
            {
                Data.User u = new Data.User();

                if (null != GShellObject)
                {
                    u = GShellObject.userObject;
                }
                else if (!string.IsNullOrWhiteSpace(UserName))
                {
                    u = users.Get(UserName);
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception(
                    string.Format("No username or user object was provided.")),
                        "", ErrorCategory.InvalidOperation, UserName));
                }

                switch (ParameterSetName)
                {
                    case "OneType":
                        switch (PropertyType)
                        {
                            case GAUserPropertyType.address:
                                WriteObject(GetAddressFromUser(u));
                                break;
                            case GAUserPropertyType.email:
                                WriteObject(GetEmailFromUser(u));
                                break;
                            case GAUserPropertyType.externalid:
                                WriteObject(GetExIdFromUser(u));
                                break;
                            case GAUserPropertyType.im:
                                WriteObject(GetImFromUser(u));
                                break;
                            case GAUserPropertyType.organization:
                                WriteObject(GetOrgFromUser(u));
                                break;
                            case GAUserPropertyType.phone:
                                WriteObject(GetPhoneFromUser(u));
                                break;
                            case GAUserPropertyType.relation:
                                WriteObject(GetRelationFromUser(u));
                                break;
                        }

                        break;

                    case "AllTypes":
                        WriteObject(new GAUserPropertyCollection(u));
                        break;
                }
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "GAUserProperty",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAUserProperty")]
    public class NewGAUserPropertyCommand : PSCmdlet, IDynamicParameters
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
        private Google.Apis.admin.Directory.directory_v1.Data.UserAddress GetUserAddress(UserAddressProperties p)
        {
            //GAUserPropertyAddress address = new GAUserPropertyAddress();
            Google.Apis.admin.Directory.directory_v1.Data.UserAddress address = new Google.Apis.admin.Directory.directory_v1.Data.UserAddress();

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

            return (address);
        }

        private Google.Apis.admin.Directory.directory_v1.Data.UserEmail GetUserEmail(UserEmailProperties p)
        {
            Google.Apis.admin.Directory.directory_v1.Data.UserEmail email = new Google.Apis.admin.Directory.directory_v1.Data.UserEmail();

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

        private Google.Apis.admin.Directory.directory_v1.Data.UserExternalId GetUserExternalId(UserExternalIdProperties p)
        {
            Google.Apis.admin.Directory.directory_v1.Data.UserExternalId externalId = new Google.Apis.admin.Directory.directory_v1.Data.UserExternalId();

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

        private Google.Apis.admin.Directory.directory_v1.Data.UserIm GetUserIm(UserImProperties p)
        {
            Google.Apis.admin.Directory.directory_v1.Data.UserIm im = new Google.Apis.admin.Directory.directory_v1.Data.UserIm();

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

        private Google.Apis.admin.Directory.directory_v1.Data.UserOrganization GetUserOrganization(UserOrganizationProperties p)
        {
            Google.Apis.admin.Directory.directory_v1.Data.UserOrganization org = new Google.Apis.admin.Directory.directory_v1.Data.UserOrganization();

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

        private Google.Apis.admin.Directory.directory_v1.Data.UserPhone GetUserPhone(UserPhoneProperties p)
        {
            Google.Apis.admin.Directory.directory_v1.Data.UserPhone phone = new Google.Apis.admin.Directory.directory_v1.Data.UserPhone();

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

        private Google.Apis.admin.Directory.directory_v1.Data.UserRelation GetUserRelation(UserRelationProperties p)
        {
            Google.Apis.admin.Directory.directory_v1.Data.UserRelation e = new Google.Apis.admin.Directory.directory_v1.Data.UserRelation();

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

    [Cmdlet(VerbsCommon.New, "GAUserPropertyCollection",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAUserPropertyCollection")]
    public class NewGAUserPropertyCollectionCommand : PSCmdlet
    {

        protected override void ProcessRecord()
        {
            WriteObject(new GAUserPropertyCollection());
        }

    }

    [Cmdlet(VerbsCommon.Remove, "GAUserProperty",
         SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Remove-GAUserProperty")]
    public class RemoveGAUserProperty : GAUserPropertyBaseCommand
    {
        #region Properties

        //UserName = 0

        //Domain position = 1

        [Parameter(
           Mandatory = false,
           HelpMessage = "The GShellUserObject to act upon. For example, the result of Get-GAUser",
           ValueFromPipeline = true)]
        public GShellUserObject GShellObject { get; set; }

        [Parameter(Position = 3,
           Mandatory = false,
           HelpMessage = "The property type to retrieve for the user. Allowed values are: address, email, externalid, im, organization, phone, relation.",
           ParameterSetName = "ClearOneProperty")]
        [Parameter(Position = 3,
           Mandatory = false,
           HelpMessage = "The property type to retrieve for the user. Allowed values are: address, email, externalid, im, organization, phone, relation.",
           ParameterSetName = "ClearOneType")]
        [Alias("Type")]
        public GAUserPropertyType PropertyType { get; set; }

        [Parameter(Position = 4,
           Mandatory = false,
           HelpMessage = "The 0-based index number of the item you want to remove for the given Property Type. (The first item in the list is an index of 0.)",
           ParameterSetName = "ClearOneProperty")]
        public int Index { get; set; }

        [Parameter(Position = 5,
            Mandatory = false,
            HelpMessage = "Clear the entire selected property type for the given user.",
            ParameterSetName = "ClearOneType")]
        public SwitchParameter ClearType { get; set; }

        [Parameter(Position = 6,
            Mandatory = false,
            HelpMessage = "Clear all property types for the given user.",
            ParameterSetName = "ClearAll")]
        public SwitchParameter ClearAll { get; set; }

        [Parameter(Position = 7,
            HelpMessage = "Force the action to complete without a prompt to continue.")]
        public SwitchParameter Force { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            WriteWarning("At the time of release of this version there is a bug in the Google API preventing the deletion of User Properties. For more information, see https://code.google.com/a/google.com/p/apps-api-issues/issues/detail?id=3701 - if you would like this fixed please star the issue to bring it more to their attention. There is no guarantee your information will be deleted.");

            if (ShouldProcess(UserName, "Get-GAUserProperty"))
            {
                if (Force || ShouldContinue((String.Format("One or more user property types of type {0} will be removed from {1}@{2}.\nContinue?",
                    PropertyType.ToString(), UserName, GAuthId)), "Confirm Google Apps User Property Removal"))
                {
                    Data.User u = new Data.User();

                    if (null != GShellObject)
                    {
                        u = GShellObject.userObject;
                    }
                    else if (!string.IsNullOrWhiteSpace(UserName))
                    {
                        UserName = GetFullEmailAddress(UserName, GAuthId);
                        u = users.Get(UserName);
                    }
                    else
                    {
                        WriteError(new ErrorRecord(new Exception(
                        string.Format("No username or user object was provided.")),
                            "", ErrorCategory.InvalidOperation, UserName));
                    }

                    switch (ParameterSetName)
                    {
                        case "ClearOneProperty":
                            RemoveOneProperty(u);
                            break;

                        case "ClearOneType":
                            ClearOneProperty(u);
                            break;

                        case "ClearAll":
                            ClearAllProperties(u);
                            break;

                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Removal of user property not confirmed"),
                        "", ErrorCategory.InvalidData, UserName));
                }
            }
        }

        /// <summary>
        /// Remove one property item from a property list of a User.
        /// </summary>
        /// <param name="u"></param>
        public void RemoveOneProperty(Data.User u)
        {

            Data.User userAcct = new Data.User();

            //pull it in to a collection in order to access the methods
            GAUserPropertyCollection upc = new GAUserPropertyCollection(u);

            //we don't need to worry about empty lists removing other information here since we're directly adding it to the user object
            switch (PropertyType)
            {
                case GAUserPropertyType.address:
                    if (upc.addresses.Count > 1)
                    {
                        upc.RemoveAt(PropertyType, Index);
                        userAcct.Addresses = upc.GetAddresses();
                    }
                    else
                    {
                        userAcct.Addresses = NullTokenProvider.NullToken;
                    }
                    break;

                case GAUserPropertyType.email:
                    if (upc.emails.Count > 1)
                    {
                        upc.RemoveAt(PropertyType, Index);
                        userAcct.Emails = upc.GetEmails();
                    }
                    else
                    {
                        userAcct.Emails = NullTokenProvider.NullToken;
                    }
                    break;

                case GAUserPropertyType.externalid:
                    if (upc.externalIds.Count > 1)
                    {
                        upc.RemoveAt(PropertyType, Index);
                        userAcct.ExternalIds = upc.GetExternalIds();
                    }
                    else
                    {
                        userAcct.ExternalIds = NullTokenProvider.NullToken;
                    }
                    break;

                case GAUserPropertyType.im:
                    if (upc.ims.Count > 1)
                    {
                        upc.RemoveAt(PropertyType, Index);
                        userAcct.Ims = upc.GetIms();
                    }
                    else
                    {
                        userAcct.Ims = NullTokenProvider.NullToken;
                    }
                    break;

                case GAUserPropertyType.organization:
                    if (upc.organizations.Count > 1)
                    {
                        upc.RemoveAt(PropertyType, Index);
                        userAcct.Organizations = upc.GetOrganizations();
                    }
                    else
                    {
                        userAcct.Organizations = NullTokenProvider.NullToken;
                    }
                    break;

                case GAUserPropertyType.phone:
                    if (upc.phones.Count > 1)
                    {
                        upc.RemoveAt(PropertyType, Index);
                        userAcct.Phones = upc.GetPhones();
                    }
                    else
                    {
                        userAcct.Phones = NullTokenProvider.NullToken;
                    }
                    break;

                case GAUserPropertyType.relation:
                    if (upc.relations.Count > 1)
                    {
                        upc.RemoveAt(PropertyType, Index);
                        userAcct.Relations = upc.GetRelations();
                    }
                    else
                    {
                        userAcct.Relations = NullTokenProvider.NullToken;
                    }
                    break;
            }
            string UserKey = GetFullEmailAddress(u.PrimaryEmail, GAuthId);
            users.Update(userAcct, UserKey);
        }

        /// <summary>
        /// Clear one property fully from a User account.
        /// </summary>
        /// <param name="u"></param>
        public void ClearOneProperty(Data.User u)
        {
            Data.User userAcct = new Data.User();

            //again, we're only directly setting one attribute and don't have to worry about the other collection information
            switch (PropertyType)
            {
                case GAUserPropertyType.address:
                    userAcct.Addresses = NullTokenProvider.NullToken;
                    break;

                case GAUserPropertyType.email:
                    userAcct.Emails = NullTokenProvider.NullToken;
                    break;

                case GAUserPropertyType.externalid:
                    userAcct.ExternalIds = NullTokenProvider.NullToken;
                    break;

                case GAUserPropertyType.im:
                    userAcct.Ims = NullTokenProvider.NullToken;
                    break;

                case GAUserPropertyType.organization:
                    userAcct.Organizations = NullTokenProvider.NullToken;
                    break;

                case GAUserPropertyType.phone:
                    userAcct.Phones = NullTokenProvider.NullToken;
                    break;

                case GAUserPropertyType.relation:
                    userAcct.Relations = NullTokenProvider.NullToken;
                    break;
            }

            string UserKey = GetFullEmailAddress(u.PrimaryEmail, GAuthId);
            users.Patch(userAcct, UserKey);

        }

        /// <summary>
        /// Clear all the properties from a user account.
        /// </summary>
        /// <param name="u"></param>
        public void ClearAllProperties(Data.User u)
        {
            Data.User userAcct = new Data.User();

            userAcct.Addresses = NullTokenProvider.NullToken;
            userAcct.Emails = NullTokenProvider.NullToken;
            userAcct.ExternalIds = NullTokenProvider.NullToken;
            userAcct.Ims = NullTokenProvider.NullToken;
            userAcct.Organizations = NullTokenProvider.NullToken;
            userAcct.Phones = NullTokenProvider.NullToken;
            userAcct.Relations = NullTokenProvider.NullToken;

            string UserKey = GetFullEmailAddress(u.PrimaryEmail, GAuthId);
            users.Patch(userAcct, UserKey);
        }
    }
}

namespace gShell.Cmdlets.Directory.GAVerificationCode
{
    /// <summary>
    /// <para type="synopsis">Returns the current set of valid backup verification codes for the specified user.</para>
    /// <para type="description">Returns the current set of valid backup verification codes for the specified user.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Get-GAVerificationCode -UserKey $SomeUserKeyString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Get-GAVerificationCode">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GAVerificationCode",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Get-GAVerificationCode")]
    public class GetGAVerificationCodeCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Identifies the user in the API request. The value can be the user's primary email address, alias email address, or unique user ID.</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Identifies the user in the API request. The value can be the user's primary email address, alias email address, or unique user ID.")]
        [ValidateNotNullOrEmpty]
        public string UserKey { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            UserKey = GetFullEmailAddress(UserKey, GAuthId);

            if (ShouldProcess(UserKey, "Get-GAVerificationCode"))
            {
                WriteObject(verificationCodes.List(UserKey).Items);
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Invalidate the current backup verification codes for the user.</para>
    /// <para type="description">Invalidate the current backup verification codes for the user.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>Revoke-GAVerificationCode -UserKey $SomeUserKeyString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Revoke-GAVerificationCode">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsSecurity.Revoke, "GAVerificationCode",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/Revoke-GAVerificationCode")]
    public class RemoveGAVerificationCodeCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Email or immutable Id of the user</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Email or immutable Id of the user")]
        [ValidateNotNullOrEmpty]
        public string UserKey { get; set; }

        /// <summary>
        /// <para type="description">A switch to run the cmdlet without prompting</para>
        /// </summary>
        [Parameter(Position = 1,
            Mandatory = false,
            HelpMessage = "A switch to run the cmdlet without prompting")]
        public SwitchParameter Force { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(UserKey, "Revoke-GAVerificationCode"))
            {
                if (Force || ShouldContinue((String.Format("Verification Codes for user {0} will be invalidated on the {1} Google Apps domain.\nContinue?",
                    UserKey, GAuthId)), "Confirm Google Apps Verification Code Invalidation"))
                {
                    try
                    {
                        WriteDebug(string.Format("Attempting to revoke Verification Codes {0}...",
                            UserKey));
                        verificationCodes.Invalidate(UserKey);
                        WriteVerbose(string.Format("Invalidation of Verification Codes for user {0} completed without error.",
                            UserKey));
                    }
                    catch (Exception e)
                    {
                        WriteError(new ErrorRecord(e, e.GetBaseException().ToString(), ErrorCategory.InvalidData, UserKey));
                    }
                }
                else
                {
                    WriteError(new ErrorRecord(new Exception("Verification Codes invalidation not confirmed"),
                        "", ErrorCategory.InvalidData, UserKey));
                }
            }
        }
    }

    /// <summary>
    /// <para type="synopsis">Generate new backup verification codes for the user.</para>
    /// <para type="description">Generate new backup verification codes for the user.</para>
    /// <list type="alertSet"><item><term>About this Cmdlet</term><description>
    /// Part of the gShell Project, relating to the Google Directory API; see Related Links or use the -Online parameter.
    /// </description></item></list>
    /// <example>
    ///   <code>PS C:\>New-GAVerificationCode -UserKey $SomeUserKeyString</code>
    ///   <para>This automatically generated example serves to show the bare minimum required to call this Cmdlet.</para>
    ///   <para>Additional examples may be added, viewed and edited by users on the community wiki at the URL found in the related links.</para>
    /// </example>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/New-GAVerificationCode">[Wiki page for this Cmdlet]</para>
    /// <para type="link" uri="https://github.com/squid808/gShell/wiki/Getting-Started">[Getting started with gShell]</para>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "GAVerificationCode",
          SupportsShouldProcess = true,
          HelpUri = @"https://github.com/squid808/gShell/wiki/New-GAVerificationCode")]
    public class NewGAVerificationCodeCommand : DirectoryBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">Email or immutable Id of the user</para>
        /// </summary>
        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Email or immutable Id of the user")]
        [ValidateNotNullOrEmpty]
        public string UserKey { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            UserKey = GetFullEmailAddress(UserKey, GAuthId);

            if (ShouldProcess(UserKey, "New-GAVerificationCode"))
            {
                verificationCodes.Generate(UserKey);
            }
        }
    }
}
