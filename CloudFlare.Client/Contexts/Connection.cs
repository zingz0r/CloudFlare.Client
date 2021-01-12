using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Exceptions;
using CloudFlare.Client.Extensions;
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Interfaces;

namespace CloudFlare.Client.Contexts
{
    public abstract class Connection : IConnection
    {
        public Uri BaseAddress => new Uri(ApiParameter.Config.BaseUrl);

        protected HttpClient HttpClient { get; private set; }
        protected bool IsDisposed { get; private set; }

        protected Connection(IAuthentication authentication)
        {
            HttpClient = CreateHttpClient(authentication);

            IsDisposed = false;
        }

        public async Task<CloudFlareResult<TResult>> GetAsync<TResult>(string requestUri, CancellationToken cancellationToken)
        {
            var response = await HttpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
            return await response.GetCloudFlareResultAsync<T>().ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<TResult>> DeleteAsync<TResult>(string requestUri, CancellationToken cancellationToken)
        {
            var response = await HttpClient.DeleteAsync(requestUri, cancellationToken).ConfigureAwait(false);
            return await response.GetCloudFlareResultAsync<T>().ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<TResult>> PatchAsync<TResult>(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            try
            {
                var method = new HttpMethod("PATCH");
                var request = new HttpRequestMessage(method, requestUri) { Content = content };

                var response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                return await response.GetCloudFlareResultAsync<T>().ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                throw new PersistenceUnavailableException(ex);
            }
        }

        public async Task<CloudFlareResult<TResult>> PostAsync<TResult, TContent>(string requestUri,
            TContent content, CancellationToken cancellationToken)
        {
            var response = await HttpClient.PostAsJsonAsync(requestUri, content, cancellationToken).ConfigureAwait(false);
            return await response.GetCloudFlareResultAsync<TResult>().ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<TResult>> PutAsync<TResult, TContent>(string requestUri,
            TContent content, CancellationToken cancellationToken)
        {
            var response = await HttpClient.PutAsJsonAsync(requestUri, content, cancellationToken).ConfigureAwait(false);
            return await response.GetCloudFlareResultAsync<TResult>().ConfigureAwait(false);
        }

        protected virtual HttpClient CreateHttpClient(IAuthentication authentication)
        {
            var handler = new HttpClientHandler
            {
                //AllowAutoRedirect = connectionInfo.AllowAutoRedirect,
                //UseProxy = connectionInfo.UseProxy
            };
            //handler.Proxy = connectionInfo.Proxy;

            var client = new HttpClient(handler, true)
            {
                BaseAddress = BaseAddress
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(HttpContentTypesHelper.Json));
            //client.DefaultRequestHeaders.ExpectContinue = connectionInfo.ExpectContinue;

            //if (connectionInfo.Timeout.HasValue)
            //    client.Timeout = connectionInfo.Timeout.Value;

            //if (connectionInfo.BasicAuth != null)
            //{
            //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", connectionInfo.BasicAuth.Value);
            //}

            authentication.AddToHeaders(client);

            return client;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            IsDisposed = true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed || !disposing)
            {
                return;
            }

            if (HttpClient != null)
            {
                HttpClient.CancelPendingRequests();
                HttpClient.Dispose();
                HttpClient = null;
            }
        }
    }
}
