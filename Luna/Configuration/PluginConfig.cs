using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace Luna.Configuration
{
    internal class PluginConfig
    {
        public virtual bool addonsEnabled { get; set; } = true;
        public virtual bool enableAddonLogging { get; set; } = true;
        public virtual bool enableAddonDebugLogging { get; set; } = false;
    }
}

