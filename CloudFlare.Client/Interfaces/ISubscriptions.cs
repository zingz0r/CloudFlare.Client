using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Interfaces
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
        Task<CloudFlareResult<AccountSubscription>> AddAsync(string accountId, AccountSubscription subscription, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists all an account's subscriptions
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<AccountSubscription>>> GetAsync(string accountId, CancellationToken cancellationToken = default);
    }
}