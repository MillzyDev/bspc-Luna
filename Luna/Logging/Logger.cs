using Luna.Configuration;
using System;
using Zenject;

using IPALogger = IPA.Logging.Logger;

namespace Luna.Logging
{
    internal class Logger : IPALogger
    {
        private static readonly Lazy<Logger> s_lazy = new Lazy<Logger>(() => new Logger());

        private readonly PluginConfig _config;
        private readonly IPALogger _base;

        private Logger()
        {
            _config = Plugin.Instance.Config;
            _base = Plugin.Instance.VanillaLogger;
        }

        public static void BindToContainer(DiContainer container) 
            => container.BindInstance(s_lazy.Value).AsSingle(); 

        public override void Log(Level level, string message)
        {
            if (_config.AllowedLogLevels.IndexOf(level) == -1) return;
            _base.Log(level, message);
        }
    }
}
