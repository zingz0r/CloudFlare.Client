using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface IUpdateAccount
    {
        /// <summary>
        /// Update an existing Account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="name">Account name</param>
        /// <returns></returns>
        Task<CloudFlareResult<Account>> UpdateAccountAsync(string accountId, string name);

        /// <summary>
        /// Update an existing Account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="name">Account name</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Account>> UpdateAccountAsync(string accountId, string name, CancellationToken cancellationToken);

        /// <summary>
        /// Update an existing Account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="name">Account name</param>
        /// <param name="settings">Account settings</param>
        /// <returns></returns>
        Task<CloudFlareResult<Account>> UpdateAccountAsync(string accountId, string name, AccountSettings settings);

        /// <summary>
        /// Update an existing Account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="name">Account name</param>
        /// <param name="settings">Account settings</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Account>> UpdateAccountAsync(string accountId, string name, AccountSettings settings, CancellationToken cancellationToken);
    }
}