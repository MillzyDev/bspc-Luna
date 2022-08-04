using IPA;
using IPA.Config;
using IPA.Config.Stores;
using Luna.Configuration;
using Luna.Installers;
using Luna.Loader;
using SiraUtil.Zenject;
using System.IO;
using IPALogger = IPA.Logging.Logger;

namespace Luna
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }

        internal IPALogger _Logger { get; private set; }
        internal static IPALogger Logger => Instance._Logger;

        internal PluginConfig Config { get; private set; }

        [Init]
        public void Init(IPALogger logger, Config config, Zenjector zenjector)
        {
            Instance = this;
            _Logger = logger;

            Config = config.Generated<PluginConfig>();

            zenjector.UseLogger(logger);

            Directory.CreateDirectory(Chainloader.AddonsDirectoryPath);

            #region Installers
            zenjector.Install<AppInstaller>(Location.App);
            #endregion
        }

        [OnStart]
        public void OnStart()
        {
            _Logger.Info("Loading addons...");
            Chainloader.Instance.LoadAddons(Chainloader.AddonsDirectoryPath);
        }
    }
}
