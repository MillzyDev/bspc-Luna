using IPA;
using IPA.Config;
using IPA.Config.Stores;
using Luna.Configuration;
using Luna.Installers;
using Newtonsoft.Json;
using SiraUtil.Zenject;
using System.IO;
using IPALogger = IPA.Logging.Logger;

namespace Luna
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }

        internal IPALogger VanillaLogger { get; private set; }
        internal PluginConfig Config { get; private set; }

        [Init]
        public void Init(IPALogger logger, Zenjector zenjector)
        {
            Instance = this;
            VanillaLogger = logger;

            LoadConfig(out PluginConfig config);
            Config = config;

            zenjector.UseLogger(logger);

            #region Install Installers

            zenjector.Install<AppInstaller>(Location.App);

            #endregion
        }

        void LoadConfig(out PluginConfig pluginConfig)
        {
            if (!File.Exists(PluginConfig.ConfigPath))
            {
                pluginConfig = new PluginConfig();

                using (var file = File.CreateText(PluginConfig.ConfigPath))
                {
                    string text = JsonConvert.SerializeObject(pluginConfig, Formatting.Indented);
                    VanillaLogger.Info(text);

                    file.Write(text);
                    return;
                }
            }

            string json = File.ReadAllText(PluginConfig.ConfigPath);


            pluginConfig = JsonConvert.DeserializeObject<PluginConfig>(json);
        }
    }
}
