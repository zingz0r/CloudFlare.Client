using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zones.WorkerRoute;
using CloudFlare.Client.Contexts;

namespace CloudFlare.Client.Client.Zones;

/// <inheritdoc />
public class WorkerRoutes : ApiContextBase<IConnection>, IWorkerRoutes
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WorkerRoutes"/> class
    /// </summary>
    /// <param name="connection">Connection settings</param>
    public WorkerRoutes(IConnection connection)
        : base(connection)
    {
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<WorkerRoute>> AddAsync(string zoneId, NewWorkerRoute newWorkerRoute, CancellationToken cancellationToken = default)
    {
        var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{WorkerRouteEndpoints.Base}";
        return await Connection.PostAsync<WorkerRoute, NewWorkerRoute>(requestUri, newWorkerRoute, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<WorkerRoute>> DeleteAsync(string zoneId, string identifier, CancellationToken cancellationToken = default)
    {
        var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{WorkerRouteEndpoints.Base}/{identifier}";
        return await Connection.DeleteAsync<WorkerRoute>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<IReadOnlyList<WorkerRoute>>> GetAsync(string zoneId, CancellationToken cancellationToken = default)
    {
        var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{WorkerRouteEndpoints.Base}";
        return await Connection.GetAsync<IReadOnlyList<WorkerRoute>>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<WorkerRoute>> GetDetailsAsync(string zoneId, string identifier, CancellationToken cancellationToken = default)
    {
        var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{WorkerRouteEndpoints.Base}/{identifier}";
        return await Connection.GetAsync<WorkerRoute>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<WorkerRoute>> UpdateAsync(string zoneId, string identifier, ModifiedWorkerRoute modifiedWorkerRoute, CancellationToken cancellationToken = default)
    {
        var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{WorkerRouteEndpoints.Base}/{identifier}";
        return await Connection.PutAsync<WorkerRoute, ModifiedWorkerRoute>(requestUri, modifiedWorkerRoute, cancellationToken).ConfigureAwait(false);
    }
}
