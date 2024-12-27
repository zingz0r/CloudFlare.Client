using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zones.Filters;

namespace CloudFlare.Client.Client.Zones;

/// <summary>
/// Interface for interacting with zone filters
/// </summary>
public interface IFilters
{
    /// <summary>
    /// List all the filters currently defined
    /// </summary>
    /// <param name="zoneId">Zone identifier</param>
    /// <param name="filter">Filter request filtering options</param>
    /// <param name="displayOptions">Display options</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A list of filters</returns>
    Task<CloudFlareResult<IReadOnlyList<Filter>>> GetAsync(string zoneId, FilterRequestFilter filter = null, UnOrderableDisplayOptions displayOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// List one filters currently defined
    /// </summary>
    /// <param name="zoneId">Zone identifier</param>
    /// <param name="identifier">Filter identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Requested filter</returns>
    Task<CloudFlareResult<Filter>> GetDetailsAsync(string zoneId, string identifier, CancellationToken cancellationToken = default);

    /// <summary>
    /// Create new filters
    /// </summary>
    /// <param name="zoneId">Zone identifier</param>
    /// <param name="filters">New Filters</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created filters</returns>
    Task<CloudFlareResult<IReadOnlyList<Filter>>> PostAsync(string zoneId, IReadOnlyList<Filter> filters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update an existing filter. See the record object definitions for required attributes for each record type
    /// </summary>
    /// <param name="zoneId">Zone identifier</param>
    /// <param name="identifier">Filter identifier</param>
    /// <param name="filter">Modified Filter</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated filter</returns>
    Task<CloudFlareResult<Filter>> UpdateAsync(string zoneId, string identifier, Filter filter, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update existing filters. See the record object definitions for required attributes for each record type
    /// </summary>
    /// <param name="zoneId">Zone identifier</param>
    /// <param name="filters">Modified Filters</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The list of updated filters</returns>
    Task<CloudFlareResult<IReadOnlyList<Filter>>> UpdateAsync(string zoneId, IReadOnlyList<Filter> filters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete existing filters.
    /// </summary>
    /// <param name="zoneId">Zone identifier</param>
    /// <param name="identifiers">Filter identifiers</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The deleted filters</returns>
    Task<CloudFlareResult<IReadOnlyList<Filter>>> DeleteAsync(string zoneId, IEnumerable<string> identifiers, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete existing filters.
    /// </summary>
    /// <param name="zoneId">Zone identifier</param>
    /// <param name="identifier">Filter identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The deleted filter</returns>
    Task<CloudFlareResult<Filter>> DeleteAsync(string zoneId, string identifier, CancellationToken cancellationToken = default);
}
