namespace Luna.Loader
{
    public class Addon
    {
        private string _path;
        private AddonMetadata _metadata;

        public Addon(string path, AddonMetadata metadata)
        {
            _path = path;
            _metadata = metadata;
        }

        public string Path { get => _path; }
        public AddonMetadata Metadata { get => _metadata; }
    }
}
