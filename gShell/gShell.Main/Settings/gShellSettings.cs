using System;
using System.IO;
using Newtonsoft.Json;

namespace gShell.Main.Settings
{
    /// <summary>Determines what serialize type to use for the gShell info.</summary>
    public class gShellSettings
    {
        public enum SerializeTypes { Bin, Json }

        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public SerializeTypes SerializeType { get; set; }

        [JsonProperty(PropertyName = "AuthInfoPath")]
        public string AuthInfoPath { get; set; }

        public gShellSettings()
        {
            SerializeType = SerializeTypes.Json;
            AuthInfoPath = Path.GetDirectoryName((new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath);
        }
    }
}
