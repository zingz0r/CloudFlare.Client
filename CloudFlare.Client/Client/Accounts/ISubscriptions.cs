using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts.Subscriptions;
using CloudFlare.Client.Api.Result;

namespace CloudFlare.Client.Client.Accounts
{
    public interface ISubscriptions
    {
        /// <summary>
        /// Creates an account subscription
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="subscription">New subscription details</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Subscription>> AddAsync(string accountId, Subscription subscription, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes an account subscription
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="subscriptionId">Subscription identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<DeletedSubscription>> DeleteAsync(string accountId, string subscriptionId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists all an account's subscriptions
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Subscription>>> GetAsync(string accountId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an account subscription
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="subscription">Modified subscription details</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Subscription>> UpdateAsync(string accountId, Subscription subscription, CancellationToken cancellationToken = default);
    }
}