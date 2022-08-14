//using NLua;
//using System;

//namespace Luna.Loader
//{
//    public abstract class LunaModule
//    {
//        protected Lua lua;

//        protected internal LunaModule(string name, Lua lua)
//        {
//            this.lua = lua;
//        }

//        protected void AddFunction(string name, Action func)
//        {
//            lua[name] = func;
//        }

//        public virtual void OnLoad() {}
//        public virtual void OnUnload() {}
//    }
//}
