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
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetMembershipDetailsAsync(string membershipId)
        {
            return await GetMembershipDetailsAsync(membershipId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetMembershipDetailsAsync(string membershipId,
            CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<IReadOnlyList<UserMembership>>(
                    $"{ApiParameter.Endpoints.Membership.Base}/?{membershipId}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}