using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Interfaces
{
    public interface IAccounts
    {
        public IMembers Members { get; }
        public ISubscriptions Subscriptions { get; }
        public IRoles Roles { get; }

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetAsync();

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="page">Page number of paginated results</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetAsync(int? page);

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetAsync(int? page, CancellationToken cancellationToken);

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetAsync(int? page, int? perPage);

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetAsync(int? page, int? perPage, CancellationToken cancellationToken);

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetAsync(int? page, int? perPage, OrderType? order);

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetAsync(int? page, int? perPage, OrderType? order, CancellationToken cancellationToken);

        /// <summary>
        /// Get information about a specific account that you are a member of
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetDetailsAsync(string accountId);

        /// <summary>
        /// Get information about a specific account that you are a member of
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetDetailsAsync(string accountId, CancellationToken cancellationToken);

        /// <summary>
        /// Update an existing Account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="name">Account name</param>
        /// <returns></returns>
        Task<CloudFlareResult<Account>> UpdateAsync(string accountId, string name);

        /// <summary>
        /// Update an existing Account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="name">Account name</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Account>> UpdateAsync(string accountId, string name, CancellationToken cancellationToken);

        /// <summary>
        /// Update an existing Account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="name">Account name</param>
        /// <param name="settings">Account settings</param>
        /// <returns></returns>
        Task<CloudFlareResult<Account>> UpdateAsync(string accountId, string name, AccountSettings settings);

        /// <summary>
        /// Update an existing Account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="name">Account name</param>
        /// <param name="settings">Account settings</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Account>> UpdateAsync(string accountId, string name, AccountSettings settings, CancellationToken cancellationToken);
    }
}
