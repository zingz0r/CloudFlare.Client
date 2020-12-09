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
        public async Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId,
            string memberId, IEnumerable<AccountRole> roles)
        {
            return await UpdateAccountMemberAsync(accountId, memberId, roles, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId,
            string memberId, IEnumerable<AccountRole> roles, CancellationToken cancellationToken)
        {
            return await UpdateAccountMemberAsync(accountId, memberId, roles, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId,
            string memberId, IEnumerable<AccountRole> roles, string code)
        {
            return await UpdateAccountMemberAsync(accountId, memberId, roles, code, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId,
            string memberId, IEnumerable<AccountRole> roles, string code, CancellationToken cancellationToken)
        {
            return await UpdateAccountMemberAsync(accountId, memberId, roles, code, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId,
            string memberId, IEnumerable<AccountRole> roles, string code, User user)
        {
            return await UpdateAccountMemberAsync(accountId, memberId, roles, code, user, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId,
            string memberId, IEnumerable<AccountRole> roles, string code, User user, CancellationToken cancellationToken)
        {
            return await UpdateAccountMemberAsync(accountId, memberId, roles, code, user, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId,
            string memberId, IEnumerable<AccountRole> roles, string code, User user, MembershipStatus? status)
        {
            return await UpdateAccountMemberAsync(accountId, memberId, roles, code, user, status, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId,
            string memberId, IEnumerable<AccountRole> roles, string code, User user, MembershipStatus? status, CancellationToken cancellationToken)
        {
            var updatedAccountMember = new AccountMember
            {
                Code = code,
                User = user,
                Roles = roles,
            };

            if (status.HasValue)
            {
                updatedAccountMember.Status = status.Value;
            }

            return await _httpClient.PutAsync<AccountMember, AccountMember>($"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/{memberId}",
                    updatedAccountMember, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}