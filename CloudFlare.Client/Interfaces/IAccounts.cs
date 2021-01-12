using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Result;
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
        /// <param name="displayOptions">Display options</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetAsync(DisplayOptions displayOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get information about a specific account that you are a member of
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetDetailsAsync(string accountId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update an existing Account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="name">Account name</param>
        /// <param name="settings">Account settings</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Account>> UpdateAsync(string accountId, string name, AccountSettings settings = null, CancellationToken cancellationToken = default);
    }
}
