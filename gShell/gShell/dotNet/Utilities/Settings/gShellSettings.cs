using System.IO;

using Newtonsoft.Json;
using System;

namespace gShell.dotNet.Utilities.Settings
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
            AuthInfoPath = Path.GetDirectoryName((new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath);
        }
    }

    public class gShellSettingsLoader
    {
        /// <summary>The name for the settings file.</summary>
        private static readonly string fileName = "gShellSettings.config";

        /// <summary>The file path for the settings file.</summary>
        private static string filePath
        {
            get
            {
                var executingPath = Path.GetDirectoryName((new System.Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath);
                return Path.Combine(executingPath, fileName);
            }
        }

        /// <summary>Save the settings to file.</summary>
        public static void Save(gShellSettings settings)
        {
            string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        /// <summary>Return the saved settings, or creates one if no file exists.</summary>
        public static gShellSettings Load()
        {
            if (!File.Exists(filePath))
                Save(new gShellSettings());

            using (StreamReader file = File.OpenText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                var settings = (gShellSettings)serializer.Deserialize(file, typeof(gShellSettings));
                return settings;
            }
        }
    }
}
