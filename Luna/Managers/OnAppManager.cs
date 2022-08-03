using Luna.Logging;
using Zenject;

namespace Luna.Managers
{
    internal class OnAppManager : IInitializable
    {
#pragma warning disable CS0649
        [Inject]
        private readonly Logger _logger;
#pragma warning restore CS0649

        public void Initialize()
        {
            _logger.Info("OnApp is workey");
        }
    }
}
