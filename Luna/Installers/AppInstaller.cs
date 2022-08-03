using Luna.Configuration;
using Luna.Logging;
using Zenject;
using IPALogger = IPA.Logging.Logger;

namespace Luna.Installers
{
    internal class AppInstaller : Installer
    {
        public override void InstallBindings()
        {
            Logger.BindToContainer(Container);
        }
    }
}
