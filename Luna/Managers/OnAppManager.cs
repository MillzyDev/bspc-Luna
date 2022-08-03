using Luna.Logging;
using Zenject;

namespace Luna.Managers
{
    internal class OnAppManager : IInitializable
    {
        [Inject]
        private readonly AddonLogger _logger;

        public void Initialize()
        {
            _logger.Info("OnApp is workey");
        }
    }
}
