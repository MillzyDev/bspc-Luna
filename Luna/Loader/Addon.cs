namespace Luna.Loader
{
    public class Addon
    {
        private string _path;
        private AddonMetadata _metadata;

        public Addon(string path)
        {
            _path = path;
            // TODO: Load Metadata
            _metadata = null;
        }

        public string Path { get => _path; }
        public AddonMetadata Metadata { get => _metadata; }
    }
}
