using System;
using System.Net.Http;
using CloudFlare.Client.Api;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public partial class CloudFlareClient : ICloudFlareClient, IDisposable
    {
        private bool _disposed;

        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri(ApiParameter.Config.BaseUrl)
        };

        /// <summary>
        /// Initialize CloudFlare Client
        /// </summary>
        /// <param name="authentication">Authentication which can be ApiKey and Token based</param>
        public CloudFlareClient(IAuthentication authentication)
        {
            authentication.AddToHeaders(_httpClient);
        }

        /// <summary>
        /// Initialize CloudFlare Client
        /// </summary>
        /// <param name="emailAddress">Email address</param>
        /// <param name="apiKey">CloudFlare API Key</param>
        public CloudFlareClient(string emailAddress, string apiKey)
        {
            var apiKeyAuthentication = new ApiKeyAuthentication(emailAddress, apiKey);
            apiKeyAuthentication.AddToHeaders(_httpClient);
        }

        /// <summary>
        /// Initialize CloudFlare Client
        /// </summary>
        /// <param name="apiToken">Authentication with api token</param>
        public CloudFlareClient(string apiToken)
        {
            var apiTokenAuthentication = new ApiTokenAuthentication(apiToken);
            apiTokenAuthentication.AddToHeaders(_httpClient);
        }

        /// <summary>
        /// Destruct CloudFlare Client
        /// </summary>
        ~CloudFlareClient()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _httpClient?.Dispose();
            }

            _disposed = true;
        }

        /// <summary>
        /// Dispose CloudFlare Client
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
