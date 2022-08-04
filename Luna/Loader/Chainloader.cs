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

        /// <summary>
        /// Loads a singular lua or luac addon from a path.
        /// </summary>
        /// <param name="path">Path of the file, including the file name.</param>
        public void LoadAddon(string path)
        {
            Lua state = new Lua();
            state.LoadFile(path);
        }

        /// <summary>
        /// Loads all lua or luac addons in a directory.
        /// </summary>
        /// <param name="path">Path to the directory that contains the addon files.</param>
        public void LoadAddons(string path)
        {

        }

        /// <summary>
        /// Registers an action to be run when the lua <c>loadModule</c> function is used.
        /// </summary>
        /// <param name="name">The name of the module that will be used in the lua <c>loadModule</c> function and will be used to access your module</param>
        /// <param name="onLoad">An action that will run when <c>loadModule(<paramref name="name"/>)</c> is invoked by an addon.</param>
        /// <param name="onUnload">An action that will run once the execution of an entrypoint has concluded.</param>
        public void RegisterModule(string name, Action<Lua> onLoad, Action onUnload = null)
        {

        }
    }
}
