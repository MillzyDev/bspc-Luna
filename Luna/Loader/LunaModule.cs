using NLua;
using System.Reflection;

namespace Luna.Loader
{
    public abstract class LunaModule
    {
        protected Lua lua;

        protected internal LunaModule(string name, Lua lua)
        {
            this.lua = lua;
        }

        public virtual void OnLoad(Lua lua) {}
        public virtual void OnUnload(Lua lua) {}
    }
}
