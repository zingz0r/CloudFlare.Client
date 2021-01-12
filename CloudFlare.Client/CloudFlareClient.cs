using System;
using CloudFlare.Client.Client;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Interfaces;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public class CloudFlareClient : ICloudFlareClient
    {
        protected bool IsDisposed { get; private set; }

        public IAccounts Accounts { get; }
        public IUsers Users { get; }
        public IZones Zones { get; }

        private readonly IConnection _connection;

        /// <summary>
        /// Initialize CloudFlare Client with connection info
        /// </summary>
        /// <param name="connectionInfo">Connection info</param>
        public CloudFlareClient(ConnectionInfo connectionInfo)
        {
            IsDisposed = false;

            _connection = new ApiConnection(connectionInfo);

            Accounts = new Accounts(_connection);
            Users = new Users(_connection);
            Zones = new Zones(_connection);
        }

        /// <summary>
        /// Initialize CloudFlare Client
        /// </summary>
        /// <param name="authentication">Authentication which can be ApiKey and Token based</param>
        public CloudFlareClient(IAuthentication authentication) : this(new ConnectionInfo(authentication))
        {
        }

        /// <summary>
        /// Initialize CloudFlare Client
        /// </summary>
        /// <param name="emailAddress">Email address</param>
        /// <param name="apiKey">CloudFlare API Key</param>
        public CloudFlareClient(string emailAddress, string apiKey) : this(new ApiKeyAuthentication(emailAddress, apiKey)) { }

        /// <summary>
        /// Initialize CloudFlare Client
        /// </summary>
        /// <param name="apiToken">Authentication with api token</param>
        public CloudFlareClient(string apiToken) : this(new ApiTokenAuthentication(apiToken)) { }

        /// <summary>
        /// Destruct CloudFlare Client
        /// </summary>
        ~CloudFlareClient()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

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
