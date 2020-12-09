using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface IGetCustomHostnameDetails
    {
        /// <summary>
        /// Get all details of the specified custom hostname
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId"></param>
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> GetCustomHostnameDetailsAsync(string zoneId, string customHostnameId);

        /// <summary>
        /// Get all details of the specified custom hostname
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> GetCustomHostnameDetailsAsync(string zoneId, string customHostnameId, CancellationToken cancellationToken);
    }
}