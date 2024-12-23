using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zones;

namespace CloudFlare.Client.Client;

/// <summary>
/// Interface for fetching data from CloudFlare
/// </summary>
/// <typeparam name="TDisplayOptions">Display options</typeparam>
/// <typeparam name="TResult">Result type</typeparam>
public interface IGetApi<in TDisplayOptions, TResult>
    where TDisplayOptions : UnOrderableDisplayOptions
{
    /// <summary>
    /// List, search, sort, and filter
    /// </summary>
    /// <param name="displayOptions">Display options</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result set</returns>
    Task<CloudFlareResult<IReadOnlyList<TResult>>> GetAsync(TDisplayOptions displayOptions = null, CancellationToken cancellationToken = default);
}

/// <summary>
/// Interface for fetching data from CloudFlare
/// </summary>
/// <typeparam name="TFilter">Filtering options</typeparam>
/// <typeparam name="TDisplayOptions">Display options</typeparam>
/// <typeparam name="TResult">Result type</typeparam>
public interface IGetApi<in TFilter, in TDisplayOptions, TResult>
    where TFilter : class
    where TDisplayOptions : UnOrderableDisplayOptions
{
    /// <summary>
    /// List, search, sort, and filter
    /// </summary>
    /// <param name="filter">Filtering options</param>
    /// <param name="displayOptions">Display options</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result set</returns>
    Task<CloudFlareResult<IReadOnlyList<TResult>>> GetAsync(TFilter filter = null, TDisplayOptions displayOptions = null, CancellationToken cancellationToken = default);
}
