namespace CloudFlare.Client.Contexts
{
    /// <summary>
    /// API context base
    /// </summary>
    /// <typeparam name="TConnection">Connection type</typeparam>
    public abstract class ApiContextBase<TConnection>
        where TConnection : class, IConnection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiContextBase{T}"/> class
        /// </summary>
        /// <param name="connection">Connection</param>
        protected ApiContextBase(TConnection connection)
        {
            Connection = connection;
        }

        /// <summary>
        /// Connection
        /// </summary>
        protected TConnection Connection { get; }
    }
}
