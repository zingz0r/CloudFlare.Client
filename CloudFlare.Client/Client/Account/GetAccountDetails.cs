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
        public async Task<CloudFlareResult<IReadOnlyList<Account>>> GetAccountDetailsAsync(string accountId)
        {
            return await GetAccountDetailsAsync(accountId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Account>>> GetAccountDetailsAsync(string accountId,
            CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<IReadOnlyList<Account>>(
                    $"{ApiParameter.Endpoints.Account.Base}/?{accountId}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}