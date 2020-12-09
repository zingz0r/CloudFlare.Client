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
        public async Task<CloudFlareResult<AccountRole>> GetRoleDetailsAsync(string accountId,
            string roleId)
        {
            return await GetRoleDetailsAsync(accountId, roleId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountRole>> GetRoleDetailsAsync(string accountId,
            string roleId, CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<AccountRole>(
                    $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Roles}/{roleId}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}