using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Result;

namespace CloudFlare.Client.Client.Accounts
{
    /// <summary>
    /// Interface for interacting with accounts
    /// </summary>
    public interface IAccounts
    {
        /// <summary>
        /// Members
        /// </summary>
        /// <value>The implementation of the members interaction</value>
        public IMembers Members { get; }

        /// <summary>
        /// Subscriptions
        /// </summary>
        /// <value>The implementation of the subscriptions interaction</value>
        public ISubscriptions Subscriptions { get; }

        /// <summary>
        /// Roles
        /// </summary>
        /// <value>The implementation of the roles interaction</value>
        public IRoles Roles { get; }

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="displayOptions">Display options</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The requested account</returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetAsync(DisplayOptions displayOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get information about a specific account that you are a member of
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The requested account details</returns>
        Task<CloudFlareResult<Account>> GetDetailsAsync(string accountId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update an existing account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="name">Account name</param>
        /// <param name="additionalAccountSettings">Additional account settings</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated account</returns>
        Task<CloudFlareResult<Account>> UpdateAsync(string accountId, string name, AdditionalAccountSettings additionalAccountSettings = null, CancellationToken cancellationToken = default);
    }
}
