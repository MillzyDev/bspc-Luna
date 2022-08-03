using Luna.Loader;
using NLua;
using System;
using System.Collections.Generic;

namespace Luna
{
    public class Chainloader
    {
        private static readonly Lazy<Chainloader> _lazy = new Lazy<Chainloader>(() => new Chainloader());

        private bool hasLoaded;

        private AddonCollection addons = new AddonCollection();
        private List<string> loaderErrors;

        #region Entrypoints
        private AddonCollection onApp;
        private AddonCollection onMenu;
        private AddonCollection onStandardPlayer;
        private AddonCollection onCampaignPlayer;
        private AddonCollection onMultiPlayer;
        private AddonCollection onPlayer;
        private AddonCollection onTutorial;
        private AddonCollection onSinglePlayer;
        private AddonCollection onGameCore;
        private AddonCollection onMultiPlayerCore;
        private AddonCollection onConnectedPlayer;
        private AddonCollection onAlwaysMultiPlayer;
        private AddonCollection onInactiveMultiPlayer;
        #endregion

        private Chainloader() { }

        public static Chainloader Instance => _lazy.Value;

        public bool HasLoaded { get => hasLoaded; }

        public AddonCollection Addons { get => addons; }
        public List<string> LoaderErrors { get => loaderErrors; }

        #region Entrypoints
        public AddonCollection OnApp { get => onApp; }
        public AddonCollection OnMenu { get => onMenu; }
        public AddonCollection OnStandardPlayer { get => onStandardPlayer; }
        public AddonCollection OnCampaignPlayer { get => onCampaignPlayer; }
        public AddonCollection OnMultiPlayer { get => onMultiPlayer; }
        public AddonCollection OnPlayer { get => onPlayer; }
        public AddonCollection OnTutorial { get => onTutorial; }
        public AddonCollection OnSinglePlayer { get => onSinglePlayer; }
        public AddonCollection OnGameCore { get => onGameCore; }
        public AddonCollection OnMultiPlayerCore { get => onMultiPlayerCore; }
        public AddonCollection OnConnectedPlayer { get => onConnectedPlayer; }
        public AddonCollection OnAlwaysMultiPlayer { get => onAlwaysMultiPlayer;  }
        public AddonCollection OnInactiveMultiPlayer { get => onInactiveMultiPlayer; }
        #endregion

        public void LoadAddon(string path)
        {

        }

        /// <summary>
        /// Loads all lua 
        /// </summary>
        /// <param name="path"></param>
        public void LoadAddons(string path)
        {

        }

        public void AddModule(string name, Action<Lua> onLoad, Action onUnload)
        {

        }
    }
}
