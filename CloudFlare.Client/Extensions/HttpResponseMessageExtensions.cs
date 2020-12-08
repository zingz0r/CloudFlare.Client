using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Exceptions;
using Newtonsoft.Json;

namespace CloudFlare.Client.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<CloudFlareResult<T>> GetCloudFlareResultAsync<T>(this HttpResponseMessage response)
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