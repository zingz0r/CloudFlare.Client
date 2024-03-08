using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zones;

namespace CloudFlare.Client.Client.Zones
{
    /// <summary>
    /// Interface for interacting with zones
    /// </summary>
    public interface IZones : IGetApi<ZoneFilter, DisplayOptions, Zone>
    {
        /// <summary>
        /// Custom hostnames
        /// </summary>
        /// <value>The implementation of the custom hostnames interaction</value>
        public ICustomHostnames CustomHostnames { get; }

        /// <summary>
        /// Dns records
        /// </summary>
        /// <value>The implementation of the dns records interaction</value>
        public IDnsRecords DnsRecords { get; }

        /// <summary>
        /// Filters
        /// </summary>
        /// <value>The implementation of the filters interaction</value>
        public IFilters Filters { get; }

        /// <summary>
        /// Firewall Rules
        /// </summary>
        /// <value>The implementation of the firewall rules interaction</value>
        public IFirewallRules FirewallRules { get; }

        /// <summary>
        /// SSL/TLS Settings for Edge Certificates
        /// </summary>
        /// <value>The implementation of the SSL/TLS edge certificate settings interaction</value>
        public IZoneSettings Settings { get; }

        /// <summary>
        /// Worker routes
        /// </summary>
        /// <value>The implementation of the worker routes interaction</value>
        public IWorkerRoutes WorkerRoutes { get; }

        /// <summary>
        /// Create a new zone
        /// </summary>
        /// <param name="newZone">The new zone to add</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created zone</returns>
        Task<CloudFlareResult<Zone>> AddAsync(NewZone newZone, CancellationToken cancellationToken = default);

        /// <summary>
        /// Initiate another zone activation check
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The checked zone</returns>
        Task<CloudFlareResult<Zone>> CheckActivationAsync(string zoneId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete DNS zone
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The deleted zone</returns>
        Task<CloudFlareResult<Zone>> DeleteAsync(string zoneId, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="filter">Zones filtering options</param>
        /// <param name="displayOptions">Display options</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The requested zones</returns>
        new Task<CloudFlareResult<IReadOnlyList<Zone>>> GetAsync(ZoneFilter filter = null, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all details of the specified zone
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The requested zone details</returns>
        Task<CloudFlareResult<Zone>> GetDetailsAsync(string zoneId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Remove ALL files from CloudFlare's cache
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="purgeEverything">A flag that indicates all resources in CloudFlare's cache should be removed. Note: This may have dramatic affects on your origin server load after performing this action.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The purged zone cache result</returns>
        Task<CloudFlareResult<Zone>> PurgeAllFilesAsync(string zoneId, bool purgeEverything, CancellationToken cancellationToken = default);

        /// <summary>
        /// Change key zone property with new value
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="modifiedZone">The modified zone values</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated zone</returns>
        Task<CloudFlareResult<Zone>> UpdateAsync(string zoneId, ModifiedZone modifiedZone, CancellationToken cancellationToken = default);
    }
}
