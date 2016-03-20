using System;
using System.IO;
using Google.Apis;
using Google.Apis.Services;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

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
        //static Dictionary<Type, Type> parentSubtypes = new Dictionary<Type, Type>();

        /// <summary> Relationship of a parent object to its property that is considered during (de)serialization. </summary>
        /// <remarks> When the object to (de)serialize has a property that is a collection of other properties that need
        /// considering, we need to track which property on the object holds this information. </remarks>
        static Dictionary<Type, PropertyInfo> parentListproperty { get; set; }
        #endregion

        //private static readonly Xml gxmlSerializer;

        private static gXmlSerializer instance;

        /// <summary>A singleton instance of the Newtonsoft JSON Serializer.</summary>
        public static gXmlSerializer Instance
        {
            get
            {
                return (instance = instance ?? new gXmlSerializer());
            }
        }

        static gXmlSerializer()
        {
            // Initialize the Xml serializer.
            reflectedTypeProperties = new Dictionary<Type, PropertyInfo[]>();
            propertyDisplayNames = new Dictionary<PropertyInfo, string>();
            parentListproperty = new Dictionary<Type, PropertyInfo>();
        }

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

        public string Serialize(object obj)
        {
            Type type = obj.GetType();

            GetTypeProperties(type);

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

        public T Deserialize<T>(string input)
        {
            Type targetType = CheckForSubtypes(typeof(T));

            XElement xmlString = XElement.Parse(input);

            //Define the namespaces
            XNamespace appNS = "http://schemas.google.com/apps/2006";
            XNamespace mainNS = "http://www.w3.org/2005/Atom";

            //Prepare a collection of collections
            List<List<XElement>> propertyCollections = new List<List<XElement>>();

            //Get all entry elements
            var entryElements = xmlString.Elements(mainNS + "entry");

            //For each element, retrieve a list of the properties
            if (entryElements.Count() > 0)
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
            MethodInfo method = this.GetType().GetMethod("BuildObjFromXml"); //TODO: Find a way not based on string?
            MethodInfo generic = method.MakeGenericMethod(targetType);


            foreach (var propertiesList in propertyCollections)
            {
                resultCollection.Add(generic.Invoke(this, new object[] { propertiesList }));
                //resultCollection.Add(BuildObjFromXml<T>(propertiesList));
            }

            //now that we have our results, see if we have to map it to a parent object
            if (targetType != typeof(T))
            {
                T parentObj = (T)Activator.CreateInstance(typeof(T));

                parentListproperty[typeof(T)].SetValue(parentObj, resultCollection);

                return parentObj;
            }

            //Return a default object
            return (T)resultCollection[0];
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

        #region Helper Methods

        /// <summary> Reflects over a given type to determine the properties and the DisplayName attribute values. </summary>
        /// <remarks> Puts the results in to static variables to prevent other methods from having to reflect over an object
        /// repeatedly, hopefully improving performance. </remarks>
        static void GetTypeProperties(Type type)
        {
            if (!reflectedTypeProperties.ContainsKey(type))
            {
                PropertyInfo[] properties = type.GetProperties();
                reflectedTypeProperties.Add(type, properties);
                foreach (PropertyInfo info in properties)
                {
                    var attr = info.GetCustomAttribute(typeof(JsonPropertyAttribute), false);
                    if (attr != null)
                    {
                        propertyDisplayNames.Add(info, ((attr) as JsonPropertyAttribute).PropertyName);
                    }
                    else
                    {
                        propertyDisplayNames.Add(info, null);
                    }
                }
            }
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
        public static T BuildObjFromXml<T>(IEnumerable<XElement> properties) where T : new()
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
        /// Check the given type to see if it contains a property that is a collection of another type from 
        /// within the same namespace.
        /// </summary>
        /// <remarks>
        /// This is intended to figure out when a type passed in to be deserialized will actually encounter a series
        /// of another type from within the XML. For instance, given Labels, you will not encounter an object
        /// representing Labels in the Atom XML. Instead, you'll just get a series of Label, which correlate to the
        /// Labels.LabelsValue. This will check for any collections like this, and determine if the type we should
        /// be creating should be for this instead. Since it checks for the same namespace, it won't do this for
        /// something like IList<long?>, were that an option.
        /// 
        /// This expects only a single collection to be encountered. Complex objects may not work with more than one.
        /// </remarks>
        static Type CheckForSubtypes(Type type)
        {
            //First, reflect over the object to collect all information we might need anyways.
            GetTypeProperties(type);

            //check for any properties that are collections
            var collectionProperties = reflectedTypeProperties[type].Where(p => p.PropertyType.GetInterfaces()
                .Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICollection<>))).ToList();

            //bool forTest = false;

            //foreach (var prop in reflectedTypeProperties[type])
            //{
            //    //Check properties to see if there are any collections
            //    var isCollection = prop.PropertyType.GetInterfaces()
            //        .Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICollection<>));

            //    forTest = isCollection;
            //}

            //if there are, check the namespace of the target and this type to see if they match
            if (collectionProperties.Count > 0)
            {
                foreach (PropertyInfo prop in collectionProperties)
                {
                    var collectionTypes = prop.PropertyType.GetGenericArguments().ToList();

                    if (collectionTypes.Count > 0)
                    {
                        bool hasMatch = Assembly.GetExecutingAssembly().GetTypes()
                            .Any(x => x.IsClass
                                && x.Namespace == type.Namespace
                                && x == collectionTypes[0]);

                        if (hasMatch)
                        {
                            if (!parentListproperty.ContainsKey(type))
                            {
                                GetTypeProperties(collectionTypes[0]);
                                parentListproperty.Add(type, prop);
                            }
                            return collectionTypes[0];
                        }
                    }

                    //var otherTypes = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsClass && x.Namespace == type.Namespace).ToList();

                }
            }
            //if they do, return the type of the collection

            return type;
        }

        #endregion
    }
}
