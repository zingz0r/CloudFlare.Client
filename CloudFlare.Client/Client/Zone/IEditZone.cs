using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zone;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface IEditZone
    {
        /// <summary>
        /// Change key zone property with new value 
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="patchZone">The modified zone values</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> EditZoneAsync(string zoneId, PatchZone patchZone);

        /// <summary>
        /// Change key zone property with new value 
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="patchZone">The modified zone values</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> EditZoneAsync(string zoneId, PatchZone patchZone, CancellationToken cancellationToken);
    }
}