namespace Luna.Loader
{
    public class AddonMetadata
    {
        protected internal AddonMetadata() { }

        public string _LunaVersion { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string Author { get; set; }
    }
}
