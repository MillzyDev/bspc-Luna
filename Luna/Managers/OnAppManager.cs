using Luna.Loader;
using NLua;
using System;
using Zenject;

namespace Luna.Managers
{
    internal class OnAppManager : IInitializable, IDisposable
    {
        [Inject]
        private readonly Lua lua;

        public void Initialize()
        {

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
