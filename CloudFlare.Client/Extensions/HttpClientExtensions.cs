using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Exceptions;

namespace CloudFlare.Client.Extensions
{
    public static class HttpClientExtensions
    {

        public static async Task<CloudFlareResult<T>> GetAsync<T>(this HttpClient httpClient, string requestUri,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
            return await response.GetCloudFlareResultAsync<T>().ConfigureAwait(false);
        }

        public static async Task<CloudFlareResult<T>> DeleteAsync<T>(this HttpClient httpClient, string requestUri,
            CancellationToken cancellationToken)
        {
            var response = await httpClient.DeleteAsync(requestUri, cancellationToken).ConfigureAwait(false);
            return await response.GetCloudFlareResultAsync<T>().ConfigureAwait(false);
        }

        public static async Task<CloudFlareResult<T>> PatchAsync<T>(this HttpClient httpClient, string requestUri,
            HttpContent content, CancellationToken cancellationToken)
        {
            try
            {
                var method = new HttpMethod("PATCH");
                var request = new HttpRequestMessage(method, requestUri) { Content = content };

                var response = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                return await response.GetCloudFlareResultAsync<T>().ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                throw new PersistenceUnavailableException(ex);
            }
        }

        public static async Task<CloudFlareResult<TResult>> PostAsync<TResult, TContent>(this HttpClient httpClient, string requestUri,
            TContent content, CancellationToken cancellationToken)
        {
            var response = await httpClient.PostAsJsonAsync(requestUri, content, cancellationToken).ConfigureAwait(false);
            return await response.GetCloudFlareResultAsync<TResult>().ConfigureAwait(false);
        }

        public static async Task<CloudFlareResult<TResult>> PutAsync<TResult, TContent>(this HttpClient httpClient, string requestUri,
            TContent content, CancellationToken cancellationToken)
        {
            var response = await httpClient.PutAsJsonAsync(requestUri, content, cancellationToken).ConfigureAwait(false);
            return await response.GetCloudFlareResultAsync<TResult>().ConfigureAwait(false);
        }
    }
}