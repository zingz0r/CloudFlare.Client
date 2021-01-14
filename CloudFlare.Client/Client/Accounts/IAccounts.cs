using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Result;

namespace CloudFlare.Client.Client.Accounts
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
        Task<CloudFlareResult<Account>> GetDetailsAsync(string accountId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update an existing account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="name">Account name</param>
        /// <param name="additionalAccountSettings">Additional account settings</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Account>> UpdateAsync(string accountId, string name, AdditionalAccountSettings additionalAccountSettings = null, CancellationToken cancellationToken = default);
    }
}
