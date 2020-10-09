using System.Net.Http;
using System.Threading.Tasks;

namespace CloudFlare.Client.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent iContent)
        {
            try
            {
                var method = new HttpMethod("PATCH");
                var request = new HttpRequestMessage(method, requestUri)
                {
                    Content = iContent
                };

                var response = await client.SendAsync(request);

                return response;
            }
            catch
            {
                //logging
                throw;
            }
        }
    }
}