
using System.Runtime.CompilerServices;
using IPA.Config.Stores;

using IPALogLevel = IPA.Logging.Logger.Level;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace Luna.Configuration
{
    internal class PluginConfig
    {

        public virtual bool Enabled { get; set; } = true;
        public virtual IPALogLevel[] AllowedLogLevels { get; set; } = 
        { 
            IPALogLevel.Info, 
            IPALogLevel.Warning, 
            IPALogLevel.Error, 
            IPALogLevel.Critical 
        };
       
    }
}
