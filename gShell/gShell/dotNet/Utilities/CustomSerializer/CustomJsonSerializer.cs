using System;
using System.IO;
using Google.Apis.Json;
using Newtonsoft.Json;
using Google.Apis.Services;

using System.ServiceModel.Syndication;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace gShell.dotNet.CustomSerializer.Json
{

    /// <summary>
    /// A provider of the NullToken against which strings will be compared during JSON.net serialization, if the NullStringConverter is used.
    /// </summary>
    public class NullTokenProvider
    {
        /// <summary>
        /// A token generated once for each session, guaranteed to be relatively unique.
        /// </summary>
        public static string NullToken
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_nullToken))
                {
                    _nullToken = Guid.NewGuid().ToString() + "gShell";
                    return _nullToken;
                }
                else
                {
                    return _nullToken;
                }
            }
        }

        private static string _nullToken;
    }

    /// <summary>
    /// A custom converter for strings that will print a null value if it matches the NullToken, despite the settings to ignore null.
    /// </summary>
    public class NullStringConverter : JsonConverter
    {
        public override bool CanRead
        {
            get { return false; }
        }

        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanRead is false.");
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        /// <summary>
        /// Check the string to see if it matches the NullToken. If it does, serialize a null value. Othewise, continue as normal.
        /// </summary>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if ((string)value == NullTokenProvider.NullToken)
            {
                writer.WriteNull();
            }
            else
            {
                writer.WriteValue(value);
            }
        }
    }

    /// <summary>
    /// When creating a new service, we need to use this initializer in order to pass along the custom serializer with it.
    /// </summary>
    public class gJsonInitializer : BaseClientService.Initializer
    {
        /// <summary>Constructs a new initializer with default values.</summary>
        public gJsonInitializer()
            : base()
        {
            Serializer = new gNewtonsoftJsonSerializer();
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
    public class gNewtonsoftJsonSerializer : IJsonSerializer
    {
        private static readonly JsonSerializer gnewtonsoftSerializer;

        private static gNewtonsoftJsonSerializer instance;

        /// <summary>A singleton instance of the Newtonsoft JSON Serializer.</summary>
        public static gNewtonsoftJsonSerializer Instance
        {
            get
            {
                return (instance = instance ?? new gNewtonsoftJsonSerializer());
            }
        }

        static gNewtonsoftJsonSerializer()
        {
            // Initialize the Newtonsoft serializer.
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Converters.Add(new RFC3339DateTimeConverter());
            settings.Converters.Add(new NullStringConverter());
            gnewtonsoftSerializer = JsonSerializer.Create(settings);
        }

        public string Format
        {
            get { return "json"; }
        }

        public void Serialize(object obj, Stream target)
        {
            using (var writer = new StreamWriter(target))
            {
                if (obj == null)
                {
                    obj = string.Empty;
                }
                gnewtonsoftSerializer.Serialize(writer, obj);
            }
        }

        public string Serialize(object obj)
        {
            using (TextWriter tw = new StringWriter())
            {
                if (obj == null)
                {
                    obj = string.Empty;
                }
                gnewtonsoftSerializer.Serialize(tw, obj);
                return tw.ToString();
            }
        }

        public T Deserialize<T>(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return default(T);
            }

            //if this input is a result of the discovery api, remove the refs that we don't use to avoid the newtonsoft error
            //some google responses have a $ref to an object with additional information, and newtonsoft doesn't abide by that
            if (input.Contains("discovery#restDescription"))
            {
                input = input.Replace("$ref", "ref");
            }

            return JsonConvert.DeserializeObject<T>(input);
        }

        public object Deserialize(string input, Type type)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            return JsonConvert.DeserializeObject(input, type);
        }

        public T Deserialize<T>(Stream input)
        {
            // Convert the JSON document into an object.
            using (StreamReader streamReader = new StreamReader(input))
            {
                return (T)gnewtonsoftSerializer.Deserialize(streamReader, typeof(T));
            }
        }
    }
}
