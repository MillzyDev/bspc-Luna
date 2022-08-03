using Luna.Configuration;
using System;
using Zenject;

using IPALogger = IPA.Logging.Logger;

namespace Luna.Logging
{
    internal class Logger : IPALogger, IInitializable
    {
        private readonly PluginConfig _config;

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public override void Log(Level level, string message)
        {
            throw new NotImplementedException();
        }
    }
}
