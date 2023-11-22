using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zones.WorkerRoute;

namespace CloudFlare.Client.Client.Zones
{
    /// <summary>
    /// Interface for interacting with worker routes
    /// </summary>
    public interface IWorkerRoutes
    {
        /// <summary>
        /// Creates a route that maps a URL pattern to a Worker.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="newWorkerRoute">New worker route to add</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created worker route</returns>
        Task<CloudFlareResult<WorkerRoute>> AddAsync(string zoneId, NewWorkerRoute newWorkerRoute, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete worker route
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="identifier">Identifier of the worker route</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The deleted worker route</returns>
        Task<CloudFlareResult<WorkerRoute>> DeleteAsync(string zoneId, string identifier, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns worker routes for a zone.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The requested worker routes</returns>
        Task<CloudFlareResult<IReadOnlyList<WorkerRoute>>> GetAsync(string zoneId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all details of the specified worker route
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="identifier">Identifier of the route</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The requested worker route details</returns>
        Task<CloudFlareResult<WorkerRoute>> GetDetailsAsync(string zoneId, string identifier, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update DNS record
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="identifier">Identifier of the route</param>
        /// <param name="modifiedWorkerRoute">Modified worker route</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated worker route</returns>
        Task<CloudFlareResult<WorkerRoute>> UpdateAsync(string zoneId, string identifier, ModifiedWorkerRoute modifiedWorkerRoute, CancellationToken cancellationToken = default);
    }
}
