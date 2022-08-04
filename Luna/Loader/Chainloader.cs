using NLua;
using System;
using System.Collections.Generic;
using System.IO;

namespace Luna.Loader
{
    public class Chainloader
    {
        private static readonly Lazy<Chainloader> _lazy = new Lazy<Chainloader>(() => new Chainloader());

        private AddonCollection addons = new AddonCollection();
        private List<LoaderException> loaderErrors = new List<LoaderException>();

        #region Entrypoints
        private AddonCollection onApp = new AddonCollection();
        private AddonCollection onMenu = new AddonCollection();
        private AddonCollection onStandardPlayer = new AddonCollection();
        private AddonCollection onCampaignPlayer = new AddonCollection();
        private AddonCollection onMultiPlayer = new AddonCollection();
        private AddonCollection onPlayer = new AddonCollection();
        private AddonCollection onTutorial = new AddonCollection();
        private AddonCollection onSinglePlayer = new AddonCollection();
        private AddonCollection onGameCore = new AddonCollection();
        private AddonCollection onMultiPlayerCore = new AddonCollection();
        private AddonCollection onConnectedPlayer = new AddonCollection();
        private AddonCollection onAlwaysMultiPlayer = new AddonCollection();
        private AddonCollection onInactiveMultiPlayer = new AddonCollection();
        #endregion

        private Chainloader() { }

        public static Chainloader Instance => _lazy.Value;

        public static string AddonsDirectoryPath 
        { 
            get => Path.Combine(Path.GetFullPath("./"), "UserData", "Luna", "Addons");
        }

        public AddonCollection Addons { get => addons; set => addons = value; }
        public List<LoaderException> LoaderErrors { get => loaderErrors; protected internal set => loaderErrors = value; }

        /// <summary>
        /// If this is true, the Chainloader will not accept any new addons to be loaded.
        /// </summary>
        public bool ReadyForExecution { get; protected internal set; }

        #region Entrypoints
        public AddonCollection OnApp { get => onApp; protected internal set => onApp = value; }
        public AddonCollection OnMenu { get => onMenu; protected internal set => onMenu = value; }
        public AddonCollection OnStandardPlayer { get => onStandardPlayer; protected internal set => onStandardPlayer = value; }
        public AddonCollection OnCampaignPlayer { get => onCampaignPlayer; protected internal set => onCampaignPlayer = value; }
        public AddonCollection OnMultiPlayer { get => onMultiPlayer; protected internal set => onMultiPlayer = value; }
        public AddonCollection OnPlayer { get => onPlayer; protected internal set => onPlayer = value; }
        public AddonCollection OnTutorial { get => onTutorial; protected internal set => onTutorial = value; }
        public AddonCollection OnSinglePlayer { get => onSinglePlayer; protected internal set => onSinglePlayer = value; }
        public AddonCollection OnGameCore { get => onGameCore; protected internal set => onGameCore = value; }
        public AddonCollection OnMultiPlayerCore { get => onMultiPlayerCore; protected internal set => onMultiPlayerCore = value; }
        public AddonCollection OnConnectedPlayer { get => onConnectedPlayer; protected internal set => onConnectedPlayer = value; }
        public AddonCollection OnAlwaysMultiPlayer { get => onAlwaysMultiPlayer; protected internal set => onAlwaysMultiPlayer = value; }
        public AddonCollection OnInactiveMultiPlayer { get => onInactiveMultiPlayer; protected internal set => onInactiveMultiPlayer = value; }
        #endregion

        /// <summary>
        /// Loads a singular lua or luac addon from a path.
        /// </summary>
        /// <param name="path">Path of the file, including the file name.</param>
        public void LoadAddon(string path)
        {
            Plugin.Instance.VanillaLogger.Info($"Attempting to load Addon at {path}");

            try
            {
                if (ReadyForExecution) throw new LoaderException("Attempted to load an addon too late.");

                Lua state = new Lua();
                state.DoFile(path);

                foreach (var g in state.Globals)
                {
                    Plugin.Instance.VanillaLogger.Info(g);
                }
                     
                var metadata = state.GetTable("ADDON_METADATA");

                string lunaVersion = metadata["_lunaVersion"] as string;
                string name = metadata["name"] as string;
                string description = metadata["description"] as string;
                string version = metadata["version"] as string;
                string author = metadata["author"] as string;

                if (string.IsNullOrEmpty(lunaVersion)
                    || string.IsNullOrEmpty(name)
                    || string.IsNullOrEmpty(description)
                    || string.IsNullOrEmpty(version)
                    || string.IsNullOrEmpty(author)
                    ) throw new LoaderException($"Metadata for addon at {path} is invalid.");

                var addonMetadata = new AddonMetadata
                {
                    _LunaVersion = lunaVersion,
                    Name = name,
                    Description = description,
                    Version = version,
                    Author = author,
                };

                var addon = new Addon(path, addonMetadata);

                Addons += addon;

                Plugin.Instance.VanillaLogger.Info($"Successfully loaded Addon: {addonMetadata.Name} - {addonMetadata.Version} by {addonMetadata.Author}!");

                state.Close();
            }
            catch (LoaderException e)
            {
                Plugin.Instance.VanillaLogger.Error($"Unable to load addon at {path}.");
                Plugin.Instance.VanillaLogger.Error(e);
            } 
        }

        /// <summary>
        /// Loads all lua or luac addons in a directory.
        /// </summary>
        /// <param name="path">Path to the directory that contains the addon files.</param>
        public void LoadAddons(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            foreach (FileInfo file in dir.GetFiles())
            {
                LoadAddon(file.FullName);
            }
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

        /// <summary>
        /// Forces a module that registered under a name to be loaded when a new state is created.
        /// </summary>
        /// <param name="name"></param>
        public void ForceLoadModule(string name)
        {

        }
    }
}
