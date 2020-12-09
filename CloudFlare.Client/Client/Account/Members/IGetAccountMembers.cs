using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface IGetAccountMembers
    {
        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId, CancellationToken cancellationToken);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="page">Page number of paginated results</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId, int? page);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId, int? page, CancellationToken cancellationToken);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId, int? page, int? perPage);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId, int? page, int? perPage, CancellationToken cancellationToken);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId, int? page, int? perPage, OrderType? order);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId, int? page, int? perPage, OrderType? order, CancellationToken cancellationToken);

    }
}