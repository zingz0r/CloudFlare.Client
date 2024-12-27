using System;
using System.Runtime.Serialization;

namespace CloudFlare.Client.Exceptions;

/// <summary>
/// Exception for persistence
/// </summary>
[Serializable]
public class PersistenceUnavailableException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PersistenceUnavailableException"/> class
    /// </summary>
    public PersistenceUnavailableException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PersistenceUnavailableException"/> class
    /// </summary>
    /// <param name="message">Exception message</param>
    public PersistenceUnavailableException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PersistenceUnavailableException"/> class
    /// </summary>
    /// <param name="innerException">Inner exception</param>
    public PersistenceUnavailableException(Exception innerException)
        : base("Exception occurred.", innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PersistenceUnavailableException"/> class
    /// </summary>
    /// <param name="info">Serialization information</param>
    /// <param name="context">Streaming context</param>
    protected PersistenceUnavailableException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
