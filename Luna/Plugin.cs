using IPA;
using Luna.Configuration;
using Luna.Installers;
using SiraUtil.Zenject;
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

            zenjector.UseLogger(logger);

            #region Installers
            zenjector.Install<AppInstaller>(Location.App);
            #endregion
        }
    }
}
