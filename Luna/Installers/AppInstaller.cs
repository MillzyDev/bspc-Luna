using Luna.Configuration;
using Luna.Logging;
using Luna.Managers;
using Zenject;
using IPALogger = IPA.Logging.Logger;

namespace Luna.Installers
{
    internal class AppInstaller : Installer
    {
        public override void InstallBindings()
        {
            AddonLogger.BindToContainer(Container);

            Container.BindInterfacesAndSelfTo<OnAppManager>().AsSingle();
        }
    }
}
