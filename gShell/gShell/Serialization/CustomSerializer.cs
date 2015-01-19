using System;
using System.IO;
using Google.Apis.Json;
using Newtonsoft.Json;
using Google.Apis.Services;
//using Google.Apis.Util;

namespace gShell.Serialization
{
    public class NullStringConverter : JsonConverter
    {
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
            //This will be hit for every string
            return objectType == typeof(string);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if ((string)value != NullToken)
            {
                writer.WriteValue(value);
            }
            else
            {
                writer.WriteNull();
            }
        }
    }

    public class gInitializer : BaseClientService.Initializer
    {
        //[Google.Apis.Testing.VisibleForTestOnly]
        //internal const uint DefaultMaxUrlLength = 2048;

        /// <summary>Constructs a new initializer with default values.</summary>
        public gInitializer()
            : base()
        {
            //GZipEnabled = true;
            Serializer = new gNewtonsoftJsonSerializer();
            //DefaultExponentialBackOffPolicy = Google.Apis.Http.ExponentialBackOffPolicy.UnsuccessfulResponse503;
            //MaxUrlLength = DefaultMaxUrlLength;
            string test = Serializer.Serialize(NullStringConverter.NullToken);
        }
    }

    public class gNewtonsoftJsonSerializer : NewtonsoftJsonSerializer
    {
        private static readonly JsonSerializer newtonsoftSerializer;

        static gNewtonsoftJsonSerializer()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Converters.Add(new RFC3339DateTimeConverter());
            settings.Converters.Add(new NullStringConverter());
            newtonsoftSerializer = JsonSerializer.Create(settings);
        }
    }

    //class CustomInitializer : IJsonSerializer
    //{
    //    private static readonly JsonSerializer customSerializer;

    //    private static NewtonsoftJsonSerializer instance;

    //    /// <summary>A singleton instance of the Newtonsoft JSON Serializer.</summary>
    //    public static NewtonsoftJsonSerializer Instance
    //    {
    //        get
    //        {
    //            return (instance = instance  ?? new NewtonsoftJsonSerializer());
    //        }
    //    }

    //    static NewtonsoftJsonSerializer()
    //    {
    //        // Initialize the Newtonsoft serializer.
    //        JsonSerializerSettings settings = new JsonSerializerSettings();
    //        settings.NullValueHandling = NullValueHandling.Ignore;
    //        settings.Converters.Add(new RFC3339DateTimeConverter());
    //        customSerializer = JsonSerializer.Create(settings);
    //    }

    //    public string Format
    //    {
    //        get { return "json"; }
    //    }

    //    public void Serialize(object obj, Stream target)
    //    {
    //        using (var writer = new StreamWriter(target))
    //        {
    //            if (obj == null)
    //            {
    //                obj = string.Empty;
    //            }
    //            customSerializer.Serialize(writer, obj);
    //        }
    //    }

    //    public string Serialize(object obj)
    //    {
    //        using (TextWriter tw = new StringWriter())
    //        {
    //            if (obj == null)
    //            {
    //                obj = string.Empty;
    //            }
    //            customSerializer.Serialize(tw, obj);
    //            return tw.ToString();
    //        }
    //    }

    //    public T Deserialize<T>(string input)
    //    {
    //        if (string.IsNullOrEmpty(input))
    //        {
    //            return default(T);
    //        }
    //        return JsonConvert.DeserializeObject<T>(input);
    //    }

    //    public object Deserialize(string input, Type type)
    //    {
    //        if (string.IsNullOrEmpty(input))
    //        {
    //            return null;
    //        }
    //        return JsonConvert.DeserializeObject(input, type);
    //    }

    //    public T Deserialize<T>(Stream input)
    //    {
    //        // Convert the JSON document into an object.
    //        using (StreamReader streamReader = new StreamReader(input))
    //        {
    //            return (T)customSerializer.Deserialize(streamReader, typeof(T));
    //        }
    //    }
    //}
}
