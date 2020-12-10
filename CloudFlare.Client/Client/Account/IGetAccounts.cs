using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface IGetAccounts
    {
        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetAccountsAsync();

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetAccountsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="page">Page number of paginated results</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetAccountsAsync(int? page);

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetAccountsAsync(int? page, CancellationToken cancellationToken);

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetAccountsAsync(int? page, int? perPage);

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetAccountsAsync(int? page, int? perPage, CancellationToken cancellationToken);

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetAccountsAsync(int? page, int? perPage, OrderType? order);

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetAccountsAsync(int? page, int? perPage, OrderType? order, CancellationToken cancellationToken);
    }
}