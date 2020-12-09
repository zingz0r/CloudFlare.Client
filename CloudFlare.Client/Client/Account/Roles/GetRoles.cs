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
        public async Task<CloudFlareResult<IReadOnlyList<AccountRole>>> GetRolesAsync(string accountId)
        {
            return await GetRolesAsync(accountId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountRole>>> GetRolesAsync(string accountId,
            CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<IReadOnlyList<AccountRole>>(
                    $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Roles}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}