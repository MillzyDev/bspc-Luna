
using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace Luna.Configuration
{
    internal class PluginConfig
    {
        public virtual Logging Logger { get; set; }

        public virtual bool Enabled { get; set; } = true;

        public class Logging
        {
            public virtual bool LogInfo { get; set; } = true;
            public virtual bool LogWarn { get; set; } = true;
            public virtual bool LogError { get; set; } = true;
            public virtual bool LogCritical { get; set; } = true;
            public virtual bool LogDebug { get; set; } = false;

        }
    }
}
