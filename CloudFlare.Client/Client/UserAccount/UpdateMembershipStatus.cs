using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Extensions;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public partial class CloudFlareClient
    {
        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> UpdateMembershipStatusAsync(string membershipId,
            SetMembershipStatus status)
        {
            return await UpdateMembershipStatusAsync(membershipId, status, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> UpdateMembershipStatusAsync(string membershipId,
            SetMembershipStatus status, CancellationToken cancellationToken)
        {
            var data = new Dictionary<string, SetMembershipStatus>
            {
                {ApiParameter.Filtering.Status, status}
            };

            return await _httpClient.PutAsync<IReadOnlyList<UserMembership>, Dictionary<string, SetMembershipStatus>>($"{ApiParameter.Endpoints.Membership.Base}/{membershipId}", data, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}