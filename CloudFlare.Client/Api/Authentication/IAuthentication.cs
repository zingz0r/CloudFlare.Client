using System.Net.Http;

namespace CloudFlare.Client.Api.Authentication
{
    /// <summary>
    /// Interface of authentication
    /// </summary>
    public interface IAuthentication
    {
        /// <summary>
        /// Adds authentication to the HTTP headers
        /// </summary>
        /// <param name="client">Http client</param>
        internal void AddToHeaders(HttpClient client);
    }
}
