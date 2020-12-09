using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface IDeleteCustomHostname
    {
        /// <summary>
        /// Delete Custom Hostname (and any issued SSL certificates)
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Custom hostname identifier</param>
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> DeleteCustomHostnameAsync(string zoneId, string customHostnameId);

        /// <summary>
        /// Delete Custom Hostname (and any issued SSL certificates)
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Custom hostname identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> DeleteCustomHostnameAsync(string zoneId, string customHostnameId, CancellationToken cancellationToken);
    }
}