using System;
using System.Runtime.Serialization;

namespace CloudFlare.Client.Exceptions
{
    /// <summary>
    /// Exception for persistence 
    /// </summary>
    [Serializable]
    public class PersistenceUnavailableException : Exception
    {
        public PersistenceUnavailableException() { }

        public PersistenceUnavailableException(string message) : base(message) { }

        public PersistenceUnavailableException(Exception innerException) : base("Exception occurred.", innerException) { }

        // Without this constructor, deserialization will fail
        protected PersistenceUnavailableException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

    }
}
