using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zones;

namespace CloudFlare.Client.Client.Zones
{
    public interface IZones
    {
        public ICustomHostnames CustomHostnames { get; }
        public IDnsRecords DnsRecords { get; }
        public IFilters Filters { get; }

        /// <summary>
        /// Create a new zone
        /// </summary>
        /// <param name="newZone">The new zone to add</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> AddAsync(NewZone newZone, CancellationToken cancellationToken = default);

        /// <summary>
        /// Initiate another zone activation check
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> CheckActivationAsync(string zoneId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete DNS zone
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> DeleteAsync(string zoneId, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="displayOptions">Display options</param>
        /// <param name="filter">Zones filtering options</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Zone>>> GetAsync(ZoneFilter filter = null, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all details of the specified zone
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> GetDetailsAsync(string zoneId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Remove ALL files from CloudFlare's cache
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="purgeEverything">A flag that indicates all resources in CloudFlare's cache should be removed. Note: This may have dramatic affects on your origin server load after performing this action.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> PurgeAllFilesAsync(string zoneId, bool purgeEverything, CancellationToken cancellationToken = default);

        /// <summary>
        /// Change key zone property with new value 
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="modifiedZone">The modified zone values</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> UpdateAsync(string zoneId, ModifiedZone modifiedZone, CancellationToken cancellationToken = default);
    }
}