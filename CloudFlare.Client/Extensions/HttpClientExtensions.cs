using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Exceptions;
using Newtonsoft.Json;

namespace CloudFlare.Client.Extensions
{
    public static class HttpClientExtensions
    {

        public static async Task<CloudFlareResult<T>> GetAsync<T>(this HttpClient httpClient, string requestUri,
            CancellationToken cancellationToken = default)
        {
            var response = await httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
            return await GetCloudFlareResultAsync<T>(response).ConfigureAwait(false);
        }

        public static async Task<CloudFlareResult<T>> DeleteAsync<T>(this HttpClient httpClient, string requestUri,
            CancellationToken cancellationToken = default)
        {
            var response = await httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
            return await GetCloudFlareResultAsync<T>(response).ConfigureAwait(false);
        }

        public static async Task<CloudFlareResult<T>> PatchAsync<T>(this HttpClient httpClient, string requestUri,
            HttpContent content, CancellationToken cancellationToken = default)
        {
            try
            {
                var method = new HttpMethod("PATCH");
                var request = new HttpRequestMessage(method, requestUri) { Content = content };

                var response = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                return await GetCloudFlareResultAsync<T>(response).ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                throw new PersistenceUnavailableException(ex);
            }
        }

        public static async Task<CloudFlareResult<TResult>> PostAsync<TResult, TContent>(this HttpClient httpClient, string requestUri,
            TContent content, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.PostAsJsonAsync(requestUri, content, cancellationToken).ConfigureAwait(false);
            return await GetCloudFlareResultAsync<TResult>(response).ConfigureAwait(false);
        }

        public static async Task<CloudFlareResult<TResult>> PutAsync<TResult, TContent>(this HttpClient httpClient, string requestUri,
            TContent content, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.PutAsJsonAsync(requestUri, content, cancellationToken).ConfigureAwait(false);
            return await GetCloudFlareResultAsync<TResult>(response).ConfigureAwait(false);
        }

        private static async Task<CloudFlareResult<T>> GetCloudFlareResultAsync<T>(HttpResponseMessage response)
        {
            try
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.Unauthorized:
                        var errorResult = JsonConvert.DeserializeObject<CloudFlareResult<object>>(content);
                        throw new AuthenticationException(string.Join(Environment.NewLine, errorResult.Errors.Select(x => x.Message)));
                    default:
                        return JsonConvert.DeserializeObject<CloudFlareResult<T>>(content);
                }
            }
            catch (Exception ex)
            {
                throw new PersistenceUnavailableException(ex);
            }
        }
    }
}