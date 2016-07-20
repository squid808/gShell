using System;
using System.IO;
using Google.Apis;
using Google.Apis.Services;
using Google.Apis.Util;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

using Google.Apis.admin.Sharedcontacts.sharedcontacts_v3.Data;

namespace gShell.dotNet.CustomSerializer.Xml
{
    /// <summary>
    /// When creating a new service, we need to use this initializer in order to pass along the custom serializer with it.
    /// </summary>
    public class gXmlInitializer : BaseClientService.Initializer
    {
        /// <summary>Constructs a new initializer with default values.</summary>
        public gXmlInitializer()
            : base()
        {
            Serializer = new gXmlSerializer();
        }
    }

    /// <summary>Extensions to the XmlWriter to ease the serialization of the shared contacts API.</summary>
    public static class XmlSerializerExtensions
    {
        public static void gdWriteElementString(XmlWriter writer, string name, string content, bool ns = true)
        {
            if (!string.IsNullOrWhiteSpace(content))
                if (ns)
                    writer.WriteElementString("gd", name, null, content);
                else
                    writer.WriteElementString(name, content);
        }

        public static void gdWriteElementBool(XmlWriter writer, string name, bool? content, bool ns = true)
        {
            if (content.HasValue)
                if (ns)
                    writer.WriteElementString("gd", name, null, content.Value.ToString().ToLower());
                else
                    writer.WriteElementString(name, content.Value.ToString().ToLower());
        }

        public static void gdWriteAttributeString(XmlWriter writer, string name, string content)
        {
            if (!string.IsNullOrWhiteSpace(content))
                writer.WriteAttributeString(name, content);
        }

        public static void gdWriteAttributeString(XmlWriter writer, string name, bool? content)
        {
            if (content.HasValue)
                writer.WriteAttributeString(name, content.Value.ToString().ToLower());
        }

        public static void gdWriteStartElement(XmlWriter writer, string name, bool ns = true)
        {
            if (!string.IsNullOrWhiteSpace(name))
                if (ns)
                    writer.WriteStartElement("gd", name, null);
                else
                    writer.WriteStartElement(name);
        }

        public static void WriteContactEntry(this XmlWriter writer, object obj)
        {
            if (obj != null)
            {
                Contact c = (Contact)obj;

                if (!string.IsNullOrWhiteSpace(c.Id))
                    writer.WriteElementString("id", c.Id);

                if (!string.IsNullOrWhiteSpace(c.Updated))
                    writer.WriteElementString("updated", c.Updated);

                writer.WriteStartElement("category");
                writer.WriteAttributeString("scheme", "http://schemas.google.com/g/2005#kind");
                writer.WriteAttributeString("term", "http://schemas.google.com/contact/2008#contact");
                writer.WriteEndElement();

                writer.WriteStartElement("title");
                writer.WriteAttributeString("type", "text");
                if (!string.IsNullOrWhiteSpace(c.Title))
                    writer.WriteValue(c.Title);
                writer.WriteEndElement();

                writer.WriteLinks(c.Links);

                if (!string.IsNullOrWhiteSpace(c.Content))
                    writer.WriteElementString("content", c.Content);

                if (c.Email != null)
                    foreach (var e in c.Email)
                        writer.WriteEmail(e);

                if (c.ExtendedProperty != null)
                    foreach (var ep in c.ExtendedProperty)
                        writer.WriteExtendedProperty(ep);

                if (c.Deleted.HasValue)
                    writer.WriteElementString("deleted", "gd", c.Deleted.Value.ToString());

                if (c.Im != null)
                    foreach (var im in c.Im)
                        writer.WriteIm(im);

                writer.WriteName(c.Name);

                if (c.Organization != null)
                    foreach (var o in c.Organization)
                        writer.WriteOrganization(o);

                if (c.PhoneNumber != null)
                    foreach (var p in c.PhoneNumber)
                        writer.WritePhoneNumber(p);

                if (c.StructuredPostalAddress != null)
                    foreach (var s in c.StructuredPostalAddress)
                        writer.WriteStructuredPostalAddress(s);

                if (!string.IsNullOrWhiteSpace(c.Title))
                {
                    writer.WriteStartElement("title");
                    writer.WriteAttributeString("type", "text");
                    writer.WriteValue(c.Title);
                    writer.WriteEndElement();
                }

                writer.WriteWhere(c.Where);

            }
        }

        public static void WriteLinks(this XmlWriter writer, IEnumerable<EntryLink> links)
        {
            if (links != null)
            {
                foreach (var link in links)
                {
                    writer.WriteStartElement("link");

                    switch (link.Rel)
                    {
                        case "link_self":
                            writer.WriteAttributeString("rel", "self");
                            writer.WriteAttributeString("type", "application/atom+xml");
                            break;

                        case "link_edit":
                            writer.WriteAttributeString("rel", "edit");
                            writer.WriteAttributeString("type", "application/atom+xml");
                            break;

                        case "link_edit-photo":
                            writer.WriteAttributeString("rel", "http://schemas.google.com/contacts/2008/rel#edit-photo");
                            writer.WriteAttributeString("type","image/*");
                            break;
                    }

                    writer.WriteAttributeString("href",link.Href);

                    writer.WriteEndElement();
                }
            }
        }

        public static void WriteEntryLink(this XmlWriter writer, EntryLink entry)
        {
            if (entry != null)
            {
                if (!string.IsNullOrWhiteSpace(entry.Href)
                    || entry.ReadOnly__.HasValue
                    || !string.IsNullOrWhiteSpace(entry.Rel)
                    || entry.Entry != null)
                {
                    gdWriteStartElement(writer, "entry");

                    gdWriteAttributeString(writer, "href", entry.Href);

                    gdWriteAttributeString(writer, "readOnly", entry.ReadOnly__.Value.ToString());

                    gdWriteAttributeString(writer, "rel", entry.Rel);

                    writer.WriteContactEntry(entry.Entry);

                    writer.WriteEndElement();
                }
            }
        }

        public static void WriteWhere(this XmlWriter writer, Where where)
        {
            if (where != null)
            {
                if (!string.IsNullOrWhiteSpace(where.Label)
                    || !string.IsNullOrWhiteSpace(where.Rel)
                    || !string.IsNullOrWhiteSpace(where.ValueString)
                    || where.EntryLink != null)
                {
                    gdWriteStartElement(writer, "where");

                    gdWriteAttributeString(writer, "label", where.Label);

                    gdWriteAttributeString(writer, "rel", where.Rel);

                    gdWriteAttributeString(writer, "valueString", where.ValueString);

                    writer.WriteEntryLink(where.EntryLink);

                    writer.WriteEndElement();
                }
            }
        }

        public static void WriteName(this XmlWriter writer, Name name)
        {
            if (name != null)
            {
                if (!string.IsNullOrWhiteSpace(name.GivenName)
                    || !string.IsNullOrWhiteSpace(name.AdditionalName)
                    || !string.IsNullOrWhiteSpace(name.FamilyName)
                    || !string.IsNullOrWhiteSpace(name.NamePrefix)
                    || !string.IsNullOrWhiteSpace(name.NameSuffix)
                    || !string.IsNullOrWhiteSpace(name.FullName))
                {
                    gdWriteStartElement(writer, "name");

                    gdWriteElementString(writer, "givenName", name.GivenName);

                    gdWriteElementString(writer, "additionalName", name.AdditionalName);

                    gdWriteElementString(writer, "familyName", name.FamilyName);

                    gdWriteElementString(writer, "namePrefix", name.NamePrefix);

                    gdWriteElementString(writer, "nameSuffix", name.NameSuffix);

                    gdWriteElementString(writer, "fullName", name.FullName);

                    writer.WriteEndElement();
                }
            }
        }

        public static void WriteEmail(this XmlWriter writer, Email email)
        {
            if (email != null)
            {
                gdWriteStartElement(writer, "email");

                writer.WriteAttributeString("address", email.Address);

                gdWriteAttributeString(writer, "displayName", email.DisplayName);

                gdWriteAttributeString(writer, "label", email.Label);

                gdWriteAttributeString(writer, "rel", email.Rel);

                gdWriteAttributeString(writer, "primary", email.Primary);

                writer.WriteEndElement();
            }
        }

        public static void WriteExtendedProperty(this XmlWriter writer, ExtendedProperty extProp)
        {
            if (extProp != null)
            {
                gdWriteStartElement(writer, "extendedProperty");

                writer.WriteAttributeString("name", extProp.Name);

                gdWriteAttributeString(writer, "value", extProp.Value);

                gdWriteAttributeString(writer, "realm", extProp.Realm);

                if (!string.IsNullOrWhiteSpace(extProp.ForeignElement))
                    writer.WriteValue(extProp.ForeignElement);

                writer.WriteEndElement();
            }
        }

        public static void WriteIm(this XmlWriter writer, Im im)
        {
            if (im != null)
            {
                gdWriteStartElement(writer, "im");

                writer.WriteAttributeString("address", im.Address);

                gdWriteAttributeString(writer, "label", im.Label);

                gdWriteAttributeString(writer, "rel", im.Rel);

                gdWriteAttributeString(writer, "protocol", im.Protocol);

                gdWriteAttributeString(writer, "primary", im.Primary.ToString());

                writer.WriteEndElement();
            }
        }

        public static void WriteOrganization(this XmlWriter writer, Organization org)
        {
            if (org != null)
            {
                if (!string.IsNullOrWhiteSpace(org.Label)
                    || !string.IsNullOrWhiteSpace(org.OrgDepartment)
                    || !string.IsNullOrWhiteSpace(org.OrgJobDescription)
                    || !string.IsNullOrWhiteSpace(org.OrgName)
                    || !string.IsNullOrWhiteSpace(org.OrgSymbol)
                    || !string.IsNullOrWhiteSpace(org.OrgTitle)
                    || org.Primary.HasValue
                    || !string.IsNullOrWhiteSpace(org.Rel)
                    || org.Where != null)
                {
                    gdWriteStartElement(writer, "organization");

                    gdWriteAttributeString(writer, "label", org.Label);

                    gdWriteAttributeString(writer, "primary", org.Primary.Value.ToString());

                    gdWriteAttributeString(writer, "rel", org.Rel);

                    gdWriteElementString(writer, "orgDepartment", org.OrgDepartment);

                    gdWriteElementString(writer, "orgJobDescription", org.OrgJobDescription);

                    gdWriteElementString(writer, "orgName", org.OrgName);

                    gdWriteElementString(writer, "orgSymbol", org.OrgSymbol);

                    gdWriteElementString(writer, "orgTitle", org.OrgTitle);

                    writer.WriteWhere(org.Where);

                    writer.WriteEndElement();
                }
            }
        }

        public static void WritePhoneNumber(this XmlWriter writer, PhoneNumber phone)
        {
            if (phone != null)
            {
                gdWriteStartElement(writer, "phoneNumber");

                gdWriteAttributeString(writer, "label", phone.Label);

                gdWriteAttributeString(writer, "rel", phone.Rel);

                gdWriteAttributeString(writer, "uri", phone.Uri);

                gdWriteAttributeString(writer, "primary", phone.Primary);

                writer.WriteValue(phone.Text);

                writer.WriteEndElement();
            }
        }

        public static void WriteStructuredPostalAddress(this XmlWriter writer, StructuredPostalAddress postal)
        {
            if (postal != null)
            {
                if (!string.IsNullOrWhiteSpace(postal.Rel)
                    || !string.IsNullOrWhiteSpace(postal.MailClass)
                    || !string.IsNullOrWhiteSpace(postal.Usage)
                    || !string.IsNullOrWhiteSpace(postal.Label)
                    || postal.Primary.HasValue
                    || !string.IsNullOrWhiteSpace(postal.Agent)
                    || !string.IsNullOrWhiteSpace(postal.Housename)
                    || !string.IsNullOrWhiteSpace(postal.Street)
                    || !string.IsNullOrWhiteSpace(postal.Pobox)
                    || !string.IsNullOrWhiteSpace(postal.Neighborhood)
                    || !string.IsNullOrWhiteSpace(postal.City)
                    || !string.IsNullOrWhiteSpace(postal.Subregion)
                    || !string.IsNullOrWhiteSpace(postal.Region)
                    || !string.IsNullOrWhiteSpace(postal.Postcode)
                    || !string.IsNullOrWhiteSpace(postal.Country)
                    || !string.IsNullOrWhiteSpace(postal.FormattedAddress))
                {
                    gdWriteStartElement(writer, "structuredPostalAddress");

                    gdWriteAttributeString(writer, "rel", postal.Rel);

                    gdWriteAttributeString(writer, "mailClass", postal.MailClass);

                    gdWriteAttributeString(writer, "usage", postal.Usage);

                    gdWriteAttributeString(writer, "label", postal.Label);

                    gdWriteAttributeString(writer, "primary", postal.Primary.Value.ToString());

                    gdWriteElementString(writer, "agent", postal.Agent);

                    gdWriteElementString(writer, "housename", postal.Housename);

                    gdWriteElementString(writer, "street", postal.Street);

                    gdWriteElementString(writer, "pobox", postal.Pobox);

                    gdWriteElementString(writer, "neighborhood", postal.Neighborhood);

                    gdWriteElementString(writer, "city", postal.City);

                    gdWriteElementString(writer, "subregion", postal.Subregion);

                    gdWriteElementString(writer, "region", postal.Region);

                    gdWriteElementString(writer, "postcode", postal.Postcode);

                    gdWriteElementString(writer, "country", postal.Country);

                    gdWriteElementString(writer, "formattedAddress", postal.FormattedAddress);

                    writer.WriteEndElement();
                }
            }
        }
    }

    /// <summary>
    /// A reimplementation of the provided NewtonsoftJsonSerializer, intended to add the second converter to allow strings to be serialized to null, if desired,
    /// using the NullTokenProvider.NullToken.
    /// 
    /// Note: In order to prevent the service from falling back to the given newtonsoftSerializer, I had to rewrite the class instead of inheriting. The reason seems
    /// to be escaping me at the moment as to why this is, so if you know just let me know and we'll work it out. 
    /// 
    /// TODO: let this inherit from and override the base class from Google's api.
    /// </summary>
    public class gXmlSerializer : ISerializer
    {
        #region Properties

        /// <summary> Relationship of a type and the properties it contains. </summary>
        /// <remarks> This information is stored to prevent repeated, expensive reflection calls. </remarks>
        static Dictionary<Type, PropertyInfo[]> reflectedTypeProperties { get; set; }

        /// <summary> Relationship of a property and the separate display name it gets from the attribute. </summary>
        static Dictionary<PropertyInfo, string> propertyDisplayNames { get; set; }

        /// <summary> Relationship of a type's properties and the display names for each property.</summary>
        static Dictionary<Type, Dictionary<PropertyInfo, string>> propertyDisplayNamesByType { get; set; }

        /// <summary> Relationship of a type's property display names and the corresponding properties.</summary>
        /// <remarks> Essentially a version of type.GetProperty() without using reflection again, for speed.</remarks>
        static Dictionary<Type, Dictionary<string, PropertyInfo>> propertiesByName { get; set; }

        /// <summary> Relationship of a parent object to its property that is considered during (de)serialization. </summary>
        /// <remarks> When the object to (de)serialize has a property that is a collection of other properties that need
        /// considering, we need to track which property on the object holds this information. </remarks>
        static Dictionary<Type, PropertyInfo> parentListproperty { get; set; }

        /// <summary>
        /// Relationship of a type's collection to its inner property's type.
        /// </summary>
        static Dictionary<Type, Dictionary<PropertyInfo, Type>> parentCollectionOfInnerType { get; set; }
        #endregion

        #region InterfaceMembers
        public string Format
        {
            get { return "atom+xml"; }
        }

        public void Serialize(object obj, Stream target)
        {
            //using (var writer = new StreamWriter(target))
            //{
            //    if (obj == null)
            //    {
            //        obj = string.Empty;
            //    }
            //    gnewtonsoftSerializer.Serialize(writer, obj);
            //}
        }

        public object Deserialize(string input, Type type)
        {
            //if (string.IsNullOrEmpty(input))
            //{
            //    return null;
            //}
            //return JsonConvert.DeserializeObject(input, type);

            return null;
        }

        public T Deserialize<T>(Stream input)
        {
            //// Convert the JSON document into an object.
            //using (StreamReader streamReader = new StreamReader(input))
            //{
            //    return (T)gnewtonsoftSerializer.Deserialize(streamReader, typeof(T));
            //}

            return default(T);
        }
        #endregion

        #region MainSerializer
        //private static readonly Xml gxmlSerializer;

        private static gXmlSerializer instance;

        /// <summary>A singleton instance of the Newtonsoft JSON Serializer.</summary>
        public static gXmlSerializer Instance
        {
            get { return (instance = instance ?? new gXmlSerializer()); }
        }

        static gXmlSerializer()
        {
            // Initialize the Xml serializer.
            reflectedTypeProperties = new Dictionary<Type, PropertyInfo[]>();
            propertyDisplayNames = new Dictionary<PropertyInfo, string>();
            parentListproperty = new Dictionary<Type, PropertyInfo>();
            propertyDisplayNamesByType = new Dictionary<Type, Dictionary<PropertyInfo, string>>();
            propertiesByName = new Dictionary<Type, Dictionary<string, PropertyInfo>>();
            parentCollectionOfInnerType = new Dictionary<Type, Dictionary<PropertyInfo, Type>>();
        }

        public string Serialize(object obj)
        {
            Type type = obj.GetType();

            ReflectOverType(type);

            if (type.Namespace.ToLower().Contains("sharedcontacts"))
            {
                var result = SerializeSharedContact(obj);
                return result;
                //return "<?xml version='1.0' encoding='utf-8'?><atom:entry xmlns:atom='http://www.w3.org/2005/Atom' xmlns:gd='http://schemas.google.com/g/2005'><atom:category scheme='http://schemas.google.com/g/2005#kind' term='http://schemas.google.com/contact/2008#contact' /><gd:name><gd:givenName>Elizabeth</gd:givenName><gd:familyName>Bennet</gd:familyName><gd:fullName>Elizabeth Bennet</gd:fullName></gd:name><atom:content type='text'>Notes</atom:content><gd:email rel='http://schemas.google.com/g/2005#work' primary='true' address='liz@gmail.com' displayName='E. Bennet' /><gd:email rel='http://schemas.google.com/g/2005#home' address='liz@example.org' /><gd:phoneNumber rel='http://schemas.google.com/g/2005#work' primary='true'>(206)555-1212</gd:phoneNumber><gd:phoneNumber rel='http://schemas.google.com/g/2005#home'>(206)555-1213</gd:phoneNumber><gd:im address='liz@gmail.com' protocol='http://schemas.google.com/g/2005#GOOGLE_TALK' primary='true' rel='http://schemas.google.com/g/2005#home' /><gd:structuredPostalAddress rel='http://schemas.google.com/g/2005#work' primary='true'><gd:city>Mountain View</gd:city><gd:street>1600 Amphitheatre Pkwy</gd:street><gd:region>CA</gd:region><gd:postcode>94043</gd:postcode><gd:country>United States</gd:country><gd:formattedAddress>1600 Amphitheatre Pkwy Mountain View</gd:formattedAddress></gd:structuredPostalAddress></atom:entry>";
            }
            else
            {
                //If it's not a shared contact, it's either emailsettings or adminsettings
                return SerializeGdataObject(obj);
            }
        }

        public T Deserialize<T>(string input)
        {
            ReflectOverType(typeof(T));

            if (typeof(T).Namespace.ToLower().Contains("sharedcontacts"))
            {
                var result = DeserializeSharedContacts<T>(input);
                return result;
            }
            else
            {
                //If it's not a shared contact, it's either emailsettings or adminsettings
                return DeserializeGDataObj<T>(input);
            }
        }
        #endregion

        #region GDataSerializers
        public string SerializeGdataObject(object obj)
        {
            Type type = obj.GetType();

            string result = string.Empty;

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = false;
            settings.ConformanceLevel = ConformanceLevel.Document;
            settings.NewLineOnAttributes = false;

            //use memorystream to allow gathering of utf-8
            //http://www.timvw.be/2007/01/08/generating-utf-8-with-systemxmlxmlwriter/
            using (var ms = new System.IO.MemoryStream())
            {
                using (XmlWriter writer = XmlWriter.Create(ms, settings))
                {
                    writer.WriteStartElement("atom", "entry", "http://www.w3.org/2005/Atom");
                    writer.WriteAttributeString("xmlns", "apps", null, "http://schemas.google.com/apps/2006");

                    foreach (var property in reflectedTypeProperties[type])
                    {
                        var value = property.GetValue(obj);

                        if (value != null)
                        {
                            string displayName = propertyDisplayNames[property];

                            writer.WriteStartElement("apps", "property", null);
                            writer.WriteAttributeString("name", displayName);
                            writer.WriteAttributeString("value", value.ToString());
                            writer.WriteEndElement();
                        }
                    }

                    writer.WriteEndElement();
                    writer.Flush();
                }

                //in order to properly get utf-8 instead of utf-16
                result = Encoding.UTF8.GetString(ms.ToArray());
            }

            return result;
        }

        /// <summary>
        /// A generic method that will parse the xml properties of an XML entry and build out an object based on the
        /// key-value pairs found in the xml.
        /// </summary>
        /// <remarks>
        /// This of course requires that the format of the incoming XML be very specific, specifically an atom feed
        /// for an older google XML-based API. If that's not the case, this may need to be updated.
        /// </remarks>
        /// <typeparam name="T">The type of the object you wish to create.</typeparam>
        /// <param name="properties">A collection of properties from the XML atom feed.</param>
        public static T BuildObjFromKeyValueXml<T>(IEnumerable<XElement> properties) where T : new()
        {

            T newObj = new T();

            Type type = typeof(T);

            //GetTypeProperties(type);

            Dictionary<string, string> dict = properties.ToDictionary(x => x.Attribute("name").Value, x => x.Attribute("value").Value);

            foreach (PropertyInfo info in reflectedTypeProperties[type])
            {
                string display = propertyDisplayNames[info];

                if (display != null && dict.ContainsKey(display) && !string.IsNullOrWhiteSpace(dict[display]))
                {
                    if (info.PropertyType == typeof(string))
                    {
                        info.SetValue(newObj, dict[display]);
                    }
                    else if (info.PropertyType == typeof(long?))
                    {
                        info.SetValue(newObj, long.Parse(dict[display]));
                    }
                }
            }

            return newObj;
        }

        /// <summary>
        /// Deserialize an object in and expected result format of the emailsettings or adminsettings.
        /// </summary>
        public T DeserializeGDataObj<T>(string input)
        {
            Type targetType = typeof(T);

            if (parentListproperty.ContainsKey(typeof(T)))
            {
                targetType = parentCollectionOfInnerType[typeof(T)][parentListproperty[typeof(T)]];
            }

            //Check for errors being thrown
            if (typeof(T).IsGenericType
                && typeof(T).GetGenericTypeDefinition() == typeof(StandardResponse<>))
            {
                T responseObj = (T)Activator.CreateInstance(typeof(T));

                reflectedTypeProperties[typeof(T)].Where(x => x.Name == "Error").First()
                    .SetValue(responseObj, new Google.Apis.Requests.RequestError() { Message = input });

                return responseObj;
            }

            XElement xmlString;

            xmlString = XElement.Parse(input);

            //Define the namespaces
            XNamespace appNS = "http://schemas.google.com/apps/2006";
            XNamespace mainNS = "http://www.w3.org/2005/Atom";

            //Prepare a collection of collections
            List<List<XElement>> propertyCollections = new List<List<XElement>>();

            //Get all entry elements
            var entryElements = xmlString.Elements(mainNS + "entry");

            //For each element, retrieve a list of the properties
            if (entryElements != null && entryElements.Count() > 0)
            {
                foreach (XElement item in entryElements)
                {
                    propertyCollections.Add(item.Elements(appNS + "property").ToList());
                }
            }
            else
            {
                propertyCollections.Add(xmlString.Elements(appNS + "property").ToList());
            }

            //Prepare and gather a collection of result objects
            var resultCollection = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(targetType));

            ////Locate the generic method
            MethodInfo method = this.GetType().GetMethod("BuildObjFromKeyValueXml"); //TODO: Find a way not based on string?
            MethodInfo generic = method.MakeGenericMethod(targetType);

            foreach (var propertiesList in propertyCollections)
            {
                resultCollection.Add(generic.Invoke(this, new object[] { propertiesList }));
            }

            //now that we have our results, see if we have to map it to a parent object
            if (targetType != typeof(T))
            {
                T parentObj = (T)Activator.CreateInstance(typeof(T));

                parentListproperty[typeof(T)].SetValue(parentObj, resultCollection);

                return parentObj;
            }

            //Return an object of type T
            return (T)resultCollection[0];
        }
        #endregion

        #region SharedContactsSerializers
        /// <summary>The base serialization method for shared contact API objects.</summary>
        public string SerializeSharedContact(object obj)
        {
            Type type = obj.GetType();

            string result = string.Empty;

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = false;
            settings.ConformanceLevel = ConformanceLevel.Document;
            settings.NewLineOnAttributes = false;

            //use memorystream to allow gathering of utf-8
            //http://www.timvw.be/2007/01/08/generating-utf-8-with-systemxmlxmlwriter/
            using (var ms = new System.IO.MemoryStream())
            {
                using (XmlWriter writer = XmlWriter.Create(ms, settings))
                {
                    writer.WriteStartElement("entry", "http://www.w3.org/2005/Atom");
                    writer.WriteAttributeString("xmlns", "gd", null, "http://schemas.google.com/g/2005");

                    if (type == typeof(Contact))
                    {
                        writer.WriteContactEntry(obj);
                    }

                    writer.WriteEndElement();
                    writer.Flush();
                }

                //in order to properly get utf-8 instead of utf-16
                result = Encoding.UTF8.GetString(ms.ToArray());
            }

            return result;
        }

        /// <summary>Deserialize an object expected from the Shared Contacts API.</summary>
        public T DeserializeSharedContacts<T>(string input)
        {
            Type targetType = typeof(T);

            //With the shared contacts API, we have complex objects that also contain collections.
            //The only time this happens is with Contacts, so just manually specify it here.
            if (typeof(T) == typeof(Contacts))
            {
                targetType = typeof(Contact);
            }

            XElement xmlString;

            xmlString = XElement.Parse(input);

            //Define the namespaces
            XNamespace gd = "http://schemas.google.com/g/2005";
            XNamespace mainNS = "http://www.w3.org/2005/Atom";
            XNamespace openSearch = "http://a9.com/-/spec/opensearchrss/1.0/";

            //Get all entry elements
            var entryElements = xmlString.Elements(mainNS + "entry");

            if (entryElements.Count() == 0 && xmlString.Name.LocalName == "entry")
            {
                entryElements = new XElement[] { xmlString };
            }

            //Prepare and gather a collection of result objects
            var resultCollection = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(targetType));

            //For each element, retrieve a list of the properties
            if (entryElements != null && entryElements.Count() > 0)
            {
                foreach (XElement item in entryElements)
                {
                    MethodInfo method = this.GetType().GetMethod("DeserializeNamedElements"); //TODO: Find a way not based on string?
                    MethodInfo generic = method.MakeGenericMethod(targetType);

                    var elementObj = generic.Invoke(this, new object[] { item });

                    resultCollection.Add(elementObj);
                }
            }

            //now that we have our results, see if we have to map it to a parent object
            if (targetType != typeof(T))
            {
                T parentObj = (T)Activator.CreateInstance(typeof(T));

                parentListproperty[typeof(T)].SetValue(parentObj, resultCollection);

                return parentObj;
            }

            //Return an object of type T
            return (T)resultCollection[0];
        }

        /// <summary>Given an xml XElement deserialize to object T.</summary>
        public T DeserializeNamedElements<T>(XElement input)
        {
            var target = Activator.CreateInstance<T>();

            if (parentCollectionOfInnerType.ContainsKey(typeof(T))
                && parentCollectionOfInnerType[typeof(T)].Count > 0)
            {
                foreach (PropertyInfo key in parentCollectionOfInnerType[typeof(T)].Keys)
                {
                    Type collectionType = parentCollectionOfInnerType[typeof(T)][key];

                    //since we have a handle on the collections, create a new instance since we don't know ahead
                    // of time how many results each will have
                    key.SetValue(target, (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(collectionType)));
                }
            }

            var propsByName = new List<KeyValuePair<string, string>>();
            var elementsByName = new Dictionary<string, XElement>();

            //Use to track elements with just attributes that happen to be subobjects
            var elementsWithAttributes = new Dictionary<string, XElement>();

            foreach (var element in input.Elements())
            {
                propsByName.Add(new KeyValuePair<string, string>(element.Name.LocalName, element.Value));
                elementsByName[element.Name.LocalName] = element;
                if (element.Attributes().Count() > 0)
                    if (element.Name.LocalName != "link")
                    {
                        elementsWithAttributes[element.Name.LocalName] = element;
                    }
                    else
                    {
                        var linkRel = element.Attribute("rel");

                        if (linkRel != null)
                        {
                            string linkValue = element.Attribute("href").Value;

                            if (linkRel.Value == "self")
                                propsByName.Add(new KeyValuePair<string, string>("link_self", linkValue));
                            else if (linkRel.Value == "edit")
                                propsByName.Add(new KeyValuePair<string, string>("link_edit", linkValue));
                            else if (linkRel.Value.Contains("edit-photo"))
                                propsByName.Add(new KeyValuePair<string, string>("link_edit-photo", linkValue));
                        }
                    }
            }

            foreach (var att in input.Attributes())
            {
                propsByName.Add(new KeyValuePair<string, string>(att.Name.LocalName, att.Value));
            }

            if (input.Name.LocalName == "phoneNumber" && !string.IsNullOrWhiteSpace(input.Value))
            {
                propsByName.Add(new KeyValuePair<string, string>("text", input.Value));
            }

            //TODO: FIGURE OUT HOW TO GET THE EDIT LINK URL

            // Get all elements for the node
            foreach (var pair in propsByName)
            {
                if (!string.IsNullOrWhiteSpace(pair.Value) || elementsWithAttributes.ContainsKey(pair.Key))
                {
                    string ename = pair.Key;

                    //pbN[Contact][email] = property(List<Email>)
                    if (propertiesByName[typeof(T)].ContainsKey(ename))
                    {
                        //Property: Email
                        var prop = propertiesByName[typeof(T)][ename];

                        //List<Email>
                        Type targetType = prop.PropertyType;

                        if (parentCollectionOfInnerType.ContainsKey(typeof(T))
                            && parentCollectionOfInnerType[typeof(T)].ContainsKey(prop))
                        {
                            //Email
                            targetType = parentCollectionOfInnerType[typeof(T)][prop];
                        }

                        object result = new object(); // = Activator.CreateInstance(targetType);

                        if (targetType == typeof(string))
                        {
                            result = pair.Value;
                        }
                        else if (targetType == typeof(int?))
                        {
                            result = int.Parse(pair.Value);
                        }
                        else if (targetType == typeof(bool?))
                        {
                            result = bool.Parse(pair.Value);
                        }
                        else if (targetType == typeof(long?))
                        {
                            result = long.Parse(pair.Value);
                        }
                        else if (targetType == typeof(DateTime?))
                        {
                            result = DateTime.Parse(pair.Value);
                        }
                        else if (targetType.Namespace == typeof(T).Namespace)
                        {
                            MethodInfo method = this.GetType().GetMethod("DeserializeNamedElements"); //TODO: Find a way not based on string?
                            MethodInfo generic = method.MakeGenericMethod(targetType);

                            result = generic.Invoke(this, new object[] { elementsByName[pair.Key] });
                        }

                        //now that we have the result, set it if it's the right type
                        if (targetType != prop.PropertyType)
                        {
                            //find the collection and add it to that
                            ((IList)prop.GetValue(target)).Add(result);
                        }
                        else
                        {
                            prop.SetValue(target, result);
                        }
                    }
                    else if (ename.StartsWith("link_"))
                    {
                        var elink = new EntryLink()
                        {
                            Rel = pair.Key,
                            Href = pair.Value
                        };

                        var prop = propertiesByName[typeof(T)]["links"];

                        ((IList)prop.GetValue(target)).Add(elink);
                    }
                }
            }

            return target;
        }
        #endregion

        #region Helper Methods
        /// <summary> Reflects over a given type to determine the properties and the DisplayName attribute values. </summary>
        /// <remarks> Puts the results in to static variables to prevent other methods from having to reflect over an object
        /// repeatedly, hopefully improving performance. </remarks>
        static void ReflectOverType(Type type)
        {
            if (!reflectedTypeProperties.ContainsKey(type))
            {
                PropertyInfo[] properties = type.GetProperties();
                reflectedTypeProperties.Add(type, properties);
                foreach (PropertyInfo info in properties)
                {
                    if (!propertyDisplayNamesByType.ContainsKey(type))
                    {
                        //If one doesn't have it, none do since we don't set this anywhere else
                        propertyDisplayNamesByType[type] = new Dictionary<PropertyInfo, string>();
                        propertiesByName[type] = new Dictionary<string, PropertyInfo>();
                        parentCollectionOfInnerType[type] = new Dictionary<PropertyInfo, Type>();
                    }

                    var attr = info.GetCustomAttribute(typeof(JsonPropertyAttribute), false);
                    if (attr != null)
                    {
                        string attrName = ((attr) as JsonPropertyAttribute).PropertyName;

                        propertyDisplayNames.Add(info, attrName);

                        if (!propertyDisplayNamesByType[type].ContainsKey(info))
                        {
                            propertyDisplayNamesByType[type][info] = attrName;
                        }

                        if (!propertiesByName[type].ContainsKey(attrName))
                        {
                            propertiesByName[type][attrName] = info;
                        }
                    }
                    else
                    {
                        propertyDisplayNames.Add(info, info.Name);
                    }

                    //check if we need to call recursive 
                    var targetType = info.PropertyType;

                    if (targetType.GetInterfaces().Any(x => x.IsGenericType
                        && x.GetGenericTypeDefinition() == typeof(ICollection<>)))
                    {
                        //if it's a collection, get the inner type
                        var innerTypes = info.PropertyType.GetGenericArguments().ToList();

                        if (innerTypes.Count > 1)
                        {
                            throw new Exception("Unexpected number of generic arguments in collection.");
                        }

                        //If our inner type matches the namespace of the main type, we need to track it
                        if (innerTypes.Count == 1
                            && innerTypes[0].Namespace == type.Namespace)
                        {
                            ReflectOverType(innerTypes[0]);

                            //for the email and admin settings, we assume the first (and only) collection is
                            // what we want
                            if (!parentListproperty.ContainsKey(type)) { parentListproperty.Add(type, info); }

                            //for the contacts api, we need to link the collection with the inner type
                            if (!parentCollectionOfInnerType[type].ContainsKey(info))
                            {
                                parentCollectionOfInnerType[type][info] = innerTypes[0];
                            }
                        }
                    }
                    else if (info.PropertyType.Namespace == type.Namespace)
                    {
                        ReflectOverType(info.PropertyType);
                    }
                }
            }
        }
        #endregion
    }

}
