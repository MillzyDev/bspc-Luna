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

        private Chainloader() { }

        public static Chainloader Instance => _lazy.Value;

        public static string AddonsDirectoryPath 
        { 
            get => Path.Combine(Path.GetFullPath("./"), "UserData", "Luna", "Addons");
        }

        public AddonCollection Addons { get => addons; set => addons = value; }
        public List<LoaderException> LoaderErrors { get => loaderErrors; protected internal set => loaderErrors = value; }

        #region Entrypoints
        public AddonCollection OnApp { get; protected internal set; } = new AddonCollection();
        public AddonCollection OnMenu { get; protected internal set; } = new AddonCollection();
        public AddonCollection OnStandardPlayer { get; protected internal set; } = new AddonCollection();
        public AddonCollection OnCampaignPlayer { get; protected internal set; } = new AddonCollection();
        public AddonCollection OnMultiPlayer { get; protected internal set; } = new AddonCollection();
        public AddonCollection OnPlayer { get; protected internal set; } = new AddonCollection();
        public AddonCollection OnTutorial { get; protected internal set; } = new AddonCollection();
        public AddonCollection OnSinglePlayer { get; protected internal set; } = new AddonCollection();
        public AddonCollection OnGameCore { get; protected internal set; } = new AddonCollection();
        public AddonCollection OnMultiPlayerCore { get; protected internal set; } = new AddonCollection();
        public AddonCollection OnConnectedPlayer { get; protected internal set; } = new AddonCollection();
        public AddonCollection OnAlwaysMultiPlayer { get; protected internal set; } = new AddonCollection();
        public AddonCollection OnInactiveMultiPlayer { get; protected internal set; } = new AddonCollection();
        #endregion

        public Dictionary<string, object> RegisteredModules { get; protected internal set; } = new Dictionary<string, object>();
        public Dictionary<string, object> LoadedModules { get; protected internal set; } = new Dictionary<string, object>();

        /// <summary>
        /// Loads a singular lua or luac addon from a path.
        /// </summary>
        /// <param name="path">Path of the file, including the file name.</param>
        public void LoadAddon(string path)
        {
            Plugin.Logger.Info($"Attempting to load Addon at {path}");

            try
            {
                Lua state = new Lua();
                state.DoFile(path);
                     
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

                #region Register Entrypoints
                if (state.GetFunction("onApp") != null) OnApp += addon;
                if (state.GetFunction("onMenu") != null) OnMenu += addon;
                if (state.GetFunction("onStandardPlayer") != null) OnStandardPlayer += addon;
                if (state.GetFunction("onCampaignPlayer") != null) OnCampaignPlayer += addon;
                if (state.GetFunction("onMultiPlayer") != null) OnMultiPlayer += addon;
                if (state.GetFunction("onPlayer") != null) OnPlayer += addon;
                if (state.GetFunction("onTutorial") != null) OnTutorial += addon;
                if (state.GetFunction("onSinglePlayer") != null) OnSinglePlayer += addon;
                if (state.GetFunction("onGameCore") != null) OnGameCore += addon;
                if (state.GetFunction("onMultiPlayerCore") != null) OnMultiPlayerCore += addon;
                if (state.GetFunction("onConnectedPlayer") != null) OnConnectedPlayer += addon;
                if (state.GetFunction("onAlwaysMultiPlayer") != null) OnAlwaysMultiPlayer += addon;
                if (state.GetFunction("onInactiveMultiPlayer") != null) OnInactiveMultiPlayer += addon;
                #endregion

                Plugin.Logger.Info($"Successfully loaded Addon: {addonMetadata.Name} - {addonMetadata.Version} by {addonMetadata.Author}!");

                state.Close();
            }
            catch (LoaderException e)
            {
                Plugin.Logger.Error($"Unable to load addon at {path}.");
                Plugin.Logger.Error(e);
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

        /*
        /// <summary>
        /// Registers an action to be run when the lua <c>loadModule</c> function is used.
        /// </summary>
        /// <param name="name">The name of the module that will be used in the lua <c>loadModule</c> function and will be used to access your module</param>
        /// <param name="module">An object that cont</param>
        public void RegisterModule<T>(string name) where T : LunaModule, new()
            => RegisteredModules.Add(name, new T());

        /// <summary>
        /// Forces a module that registered under a name to be loaded within the provided state
        /// </summary>
        /// <param name="name">Name of the module</param>
        /// <param name="state">The active Lua state that the module will be loaded into</param>
        public void ForceLoadModule(Lua state, string name)
        {
            object module = RegisteredModules[name];
            var methods = module.GetType().GetMethods();


        }
        */
    }
}
