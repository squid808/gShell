using System.IO;

using Newtonsoft.Json;

namespace gShell.dotNet.Utilities.Settings
{
    /// <summary>Determines what serialize type to use for the gShell info.</summary>
    public class gShellSettings
    {
        public enum SerializeTypes { Bin, Json }

        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public SerializeTypes SerializeType { get; set; }

        public gShellSettings()
        {
            SerializeType = SerializeTypes.Bin;
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
                return Path.Combine(
                    OAuth2.OAuth2InfoConsumer.dataStoreLocation, fileName);
            }
        }

        /// <summary>Save the settings to file.</summary>
        public static void Save(gShellSettings settings)
        {
            string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        /// <summary>Return the saved settings, or null if no file exists.</summary>
        public static gShellSettings Load()
        {
            if (!File.Exists(filePath)) { return null; }

            gShellSettings settings = null;

            using (StreamReader file = File.OpenText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                settings = (gShellSettings)serializer.Deserialize(file, typeof(gShellSettings));
            }

            return settings;
        }
    }
}
