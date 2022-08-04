using Luna.Managers;
using NLua;
using Zenject;

namespace Luna.Installers
{
    internal class AppInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInstance(new Lua()).AsSingle();
            Container.BindInterfacesAndSelfTo<OnAppManager>().AsSingle();
        }
    }
}
