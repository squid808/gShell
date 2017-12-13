using System.IO;
using Newtonsoft.Json;

namespace gShell.Main.Settings
{
    public class gShellSettingsLoader
    {
        /// <summary>The name for the settings file.</summary>
        private static readonly string fileName = "gShellSettings.config";

        /// <summary>The file path for the settings file.</summary>
        private static string filePath
        {
            get
            {
                var executingPath = Path.GetDirectoryName((new System.Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath);
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