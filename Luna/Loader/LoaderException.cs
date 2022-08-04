using System;
using System.Runtime.Serialization;

namespace Luna.Loader
{
    public class LoaderException : Exception
    {
        public LoaderException() : base()
            => AddToErrorsList();

        public LoaderException(string message) : base(message)
            => AddToErrorsList();

        public LoaderException(string message, Exception innerException) : base(message, innerException)
            => AddToErrorsList();

        public LoaderException(SerializationInfo info, StreamingContext context) : base(info, context)
            => AddToErrorsList();

        private void AddToErrorsList()
        {
            Chainloader.Instance.LoaderErrors.Add(this);
        }
    }
}
