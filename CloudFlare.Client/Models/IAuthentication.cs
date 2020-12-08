using System.Net.Http;

namespace CloudFlare.Client.Models
{
    public interface IAuthentication
    {
        /// <summary>
        /// Adds authentication to the HTTP headers
        /// </summary>
        /// <param name="client">Http client</param>
        void AddToHeaders(HttpClient client);
    }
}