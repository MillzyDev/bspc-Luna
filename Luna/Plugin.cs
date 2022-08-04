using IPA;
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

        internal IPALogger VanillaLogger { get; private set; }
        internal PluginConfig Config { get; private set; }

        [Init]
        public void Init(IPALogger logger, Zenjector zenjector)
        {
            Instance = this;
            VanillaLogger = logger;

            Config = PluginConfig.Load();
            Config.Save(); // making sure

            zenjector.UseLogger(logger);

            Directory.CreateDirectory(Chainloader.AddonsDirectoryPath);

            #region Installers
            zenjector.Install<AppInstaller>(Location.App);
            #endregion
        }

        [OnStart]
        public void OnStart()
        {
            VanillaLogger.Info("Loading addons...");
            Chainloader.Instance.LoadAddons(Chainloader.AddonsDirectoryPath);
        }
    }
}
