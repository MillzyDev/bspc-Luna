using Luna.Loader;
using Luna.Modules;
using NLua;

namespace Luna.StandardLibrary
{
    internal class Luna : LunaModule
    {
        private Lua lua;

        public void OnLoad(Lua lua)
            => this.lua = lua;

        public void OnUnload(Lua lua)
        {
        }

#pragma warning disable IDE1006
        public void loadModule(string name)
            => Chainloader.Instance.ForceLoadModule(lua, name);
#pragma warning restore IDE1006
    }
}
