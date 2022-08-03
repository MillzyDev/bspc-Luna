using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using IPALogLevel = IPA.Logging.Logger.Level;

namespace Luna.Configuration { 
    // I made this because arrays and lists with the default BSIPA config system were not working, then I found out I needed to use [UseConverter]...
    // but I'd already done this before I found out, and I cba to change it again.
    internal class PluginConfig
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; } = true;


        [JsonProperty("allowedLogLevels")]
        public IPALogLevel[] AllowedLogLevels { get; set; } = 
        { 
            IPALogLevel.Info, 
            IPALogLevel.Warning, 
            IPALogLevel.Error, 
            IPALogLevel.Critical 
        };

#region Not-Config
        private static string configPath;
        public static string ConfigPath
        {
            get
            {
                if (configPath == null || configPath == string.Empty)
                    configPath = Path.Combine(Path.GetFullPath("./"), "UserData", $"{Assembly.GetExecutingAssembly().GetName().Name}.json");

                return configPath;
            }
        }

        public static PluginConfig Load()
        {
            if (!File.Exists(ConfigPath))
            {
                var pluginConfig = new PluginConfig();

                using (var file = File.CreateText(ConfigPath))
                {
                    string text = JsonConvert.SerializeObject(pluginConfig, Formatting.Indented);

                    file.Write(text);
                    return pluginConfig;
                }
            }

            string json = File.ReadAllText(ConfigPath);


            return JsonConvert.DeserializeObject<PluginConfig>(json);
        }

        public void Save()
        {
            using (var file = File.CreateText(ConfigPath))
            {
                string text = JsonConvert.SerializeObject(this, Formatting.Indented);

                file.Write(text);
            }
        }
#endregion
    }
}
