using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Extensions;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public partial class CloudFlareClient
    {
        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountSubscription>>> GetAccountSubscriptionsAsync(string accountId)
        {
            return await GetAccountSubscriptionsAsync(accountId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountSubscription>>> GetAccountSubscriptionsAsync(string accountId,
            CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<IReadOnlyList<AccountSubscription>>(
                    $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Subscriptions}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}