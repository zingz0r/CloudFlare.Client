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
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> DeleteMembershipAsync(string membershipId)
        {
            return await DeleteMembershipAsync(membershipId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> DeleteMembershipAsync(string membershipId,
            CancellationToken cancellationToken)
        {
            return await _httpClient.DeleteAsync<IEnumerable<UserMembership>>(
                $"{ApiParameter.Endpoints.Membership.Base}/{membershipId}", cancellationToken).ConfigureAwait(false);
        }
    }
}