using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using IPALogLevel = IPA.Logging.Logger.Level;

namespace Luna.Configuration
{
    internal class PluginConfig
    {
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
       
    }
}
