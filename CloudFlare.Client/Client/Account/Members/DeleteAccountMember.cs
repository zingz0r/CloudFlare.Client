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
        public async Task<CloudFlareResult<AccountMember>> DeleteAccountMemberAsync(string accountId,
            string memberId)
        {
            return await DeleteAccountMemberAsync(accountId, memberId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> DeleteAccountMemberAsync(string accountId,
            string memberId, CancellationToken cancellationToken)
        {
            return await _httpClient.DeleteAsync<AccountMember>(
                    $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/{memberId}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}