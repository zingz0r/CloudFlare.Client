using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Account;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Extensions;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public partial class CloudFlareClient
    {
        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> AddAccountMemberAsync(string accountId,
            string emailAddress, IReadOnlyList<AccountRole> roles)
        {
            return await AddAccountMemberAsync(accountId, emailAddress, roles, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> AddAccountMemberAsync(string accountId,
            string emailAddress, IReadOnlyList<AccountRole> roles, CancellationToken cancellationToken)
        {
            var addAccountMember = new PostAccount
            {
                EmailAddress = emailAddress,
                Roles = roles,
                Status = AddMembershipStatus.Pending
            };

            return await _httpClient.PostAsync<AccountMember, PostAccount>(
                    $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}", addAccountMember, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}