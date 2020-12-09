using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface IGetZones
    {
        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync();

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name, ZoneStatus? status);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name, ZoneStatus? status, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <param name="page">Page number of paginated results</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page, int? perPage);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page,
            int? perPage, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page,
            int? perPage, OrderType? order);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page,
            int? perPage, OrderType? order, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <param name="match">Whether to match all search requirements or at least one</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page,
            int? perPage, OrderType? order, bool? match);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <param name="match">Whether to match all search requirements or at least one</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page,
            int? perPage, OrderType? order, bool? match, CancellationToken cancellationToken);
    }
}