using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface IGetCustomHostnames
    {
        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetCustomHostnamesAsync(string zoneId);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page, int? perPage);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page,
            int? perPage, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page,
            int? perPage, CustomHostnameOrderType? type);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page,
            int? perPage, CustomHostnameOrderType? type, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <param name="order">Direction to order hostnames</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page,
            int? perPage, CustomHostnameOrderType? type, OrderType? order);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <param name="order">Direction to order hostnames</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page,
            int? perPage, CustomHostnameOrderType? type, OrderType? order, CancellationToken cancellationToken);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <param name="order">Direction to order hostnames</param>
        /// <param name="ssl">Whether to filter hostnames based on if they have SSL enabled</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page,
            int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <param name="order">Direction to order hostnames</param>
        /// <param name="ssl">Whether to filter hostnames based on if they have SSL enabled</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page,
            int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl, CancellationToken cancellationToken);
    }
}