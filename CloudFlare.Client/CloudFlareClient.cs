using System;
using CloudFlare.Client.Api.Authentication;
using CloudFlare.Client.Client.Accounts;
using CloudFlare.Client.Client.Users;
using CloudFlare.Client.Client.Zones;
using CloudFlare.Client.Contexts;

namespace CloudFlare.Client
{
    /// <inheritdoc />
    public class CloudFlareClient : ICloudFlareClient
    {
        private readonly IConnection _connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFlareClient"/> class
        /// </summary>
        /// <param name="authentication">Authentication which can be ApiKey and Token based</param>
        /// <param name="connectionInfo">Connection info</param>
        public CloudFlareClient(IAuthentication authentication, ConnectionInfo connectionInfo = null)
        {
            IsDisposed = false;

            _connection = new ApiConnection(authentication, connectionInfo ?? new ConnectionInfo());

            Accounts = new Accounts(_connection);
            Users = new Users(_connection);
            Zones = new Zones(_connection);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFlareClient"/> class
        /// </summary>
        /// <param name="emailAddress">Email address</param>
        /// <param name="apiKey">CloudFlare API Key</param>
        /// <param name="connectionInfo">Connection info</param>
        public CloudFlareClient(string emailAddress, string apiKey, ConnectionInfo connectionInfo = null)
            : this(new ApiKeyAuthentication(emailAddress, apiKey), connectionInfo)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFlareClient"/> class
        /// </summary>
        /// <param name="apiToken">Authentication with api token</param>
        /// <param name="connectionInfo">Connection info</param>
        public CloudFlareClient(string apiToken, ConnectionInfo connectionInfo = null)
            : this(new ApiTokenAuthentication(apiToken), connectionInfo)
        {
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="CloudFlareClient"/> class.
        /// </summary>
        ~CloudFlareClient()
        {
            Dispose(false);
        }

        /// <inheritdoc />
        public IAccounts Accounts { get; }

        /// <inheritdoc />
        public IUsers Users { get; }

        /// <inheritdoc />
        public IZones Zones { get; }

        /// <summary>
        /// Whether the <see cref="CloudFlareClient"/> is disposed
        /// </summary>
        protected bool IsDisposed { get; private set; }

        /// <summary>
        /// Dispose the <see cref="CloudFlareClient"/>
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose the <see cref="CloudFlareClient"/>
        /// </summary>
        /// <param name="disposing">Dispose the connection</param>
        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed)
            {
                return;
            }

            if (disposing)
            {
                _connection?.Dispose();
            }

            IsDisposed = true;
        }
    }
}
