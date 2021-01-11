using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Account;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Interfaces;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Client
{
    public class Members : ApiContextBase<IConnection>, IMembers
    {
        public Members(IConnection connection) : base(connection)
        {
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> AddAsync(string accountId, string emailAddress, IReadOnlyList<AccountRole> roles)
        {
            return await AddAsync(accountId, emailAddress, roles, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> AddAsync(string accountId, string emailAddress, IReadOnlyList<AccountRole> roles, CancellationToken cancellationToken)
        {
            var addAccountMember = new PostAccount
            {
                EmailAddress = emailAddress,
                Roles = roles,
                Status = MembershipStatus.Pending
            };

            return await Connection.PostAsync<AccountMember, PostAccount>(
                    $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}", addAccountMember, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> DeleteAsync(string accountId, string memberId)
        {
            return await DeleteAsync(accountId, memberId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> DeleteAsync(string accountId, string memberId, CancellationToken cancellationToken)
        {
            return await Connection.DeleteAsync<AccountMember>(
                    $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/{memberId}", cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAsync(string accountId)
        {
            return await GetAsync(accountId, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAsync(string accountId, CancellationToken cancellationToken)
        {
            return await GetAsync(accountId, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAsync(string accountId, int? page)
        {
            return await GetAsync(accountId, page, null, null, default).ConfigureAwait(false);

        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAsync(string accountId, int? page, CancellationToken cancellationToken)
        {
            return await GetAsync(accountId, page, null, null, cancellationToken).ConfigureAwait(false);

        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAsync(string accountId, int? page, int? perPage)
        {
            return await GetAsync(accountId, page, perPage, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAsync(string accountId, int? page, int? perPage, CancellationToken cancellationToken)
        {
            return await GetAsync(accountId, page, perPage, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAsync(string accountId, int? page, int? perPage, OrderType? order)
        {
            return await GetAsync(accountId, page, perPage, order, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAsync(string accountId, int? page, int? perPage, OrderType? order, CancellationToken cancellationToken)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Page, page)
                .InsertValue(ApiParameter.Filtering.PerPage, perPage)
                .InsertValue(ApiParameter.Filtering.Direction, order);

            var parameterString = parameterBuilder.ParameterCollection;

            return await Connection.GetAsync<IReadOnlyList<AccountMember>>(
                    $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/?{parameterString}", cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> GetDetailsAsync(string accountId, string memberId)
        {
            return await GetDetailsAsync(accountId, memberId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> GetDetailsAsync(string accountId, string memberId, CancellationToken cancellationToken)
        {
            return await Connection.GetAsync<AccountMember>(
                    $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/{memberId}", cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles)
        {
            return await UpdateAsync(accountId, memberId, roles, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, CancellationToken cancellationToken)
        {
            return await UpdateAsync(accountId, memberId, roles, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, string code)
        {
            return await UpdateAsync(accountId, memberId, roles, code, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, string code, CancellationToken cancellationToken)
        {
            return await UpdateAsync(accountId, memberId, roles, code, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, string code, User user)
        {
            return await UpdateAsync(accountId, memberId, roles, code, user, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, string code, User user, CancellationToken cancellationToken)
        {
            return await UpdateAsync(accountId, memberId, roles, code, user, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, string code, User user, MembershipStatus? status)
        {
            return await UpdateAsync(accountId, memberId, roles, code, user, status, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, string code, User user, MembershipStatus? status, CancellationToken cancellationToken)
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

            return await Connection.PutAsync<AccountMember, AccountMember>($"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/{memberId}",
                    updatedAccountMember, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}