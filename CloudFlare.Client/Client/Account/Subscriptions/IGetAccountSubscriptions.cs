using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface IGetAccountSubscriptions
    {
        /// <summary>
        /// Lists all an account's subscriptions
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<AccountSubscription>>> GetAccountSubscriptionsAsync(string accountId);

        /// <summary>
        /// Lists all an account's subscriptions
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<AccountSubscription>>> GetAccountSubscriptionsAsync(string accountId, CancellationToken cancellationToken);
    }
}