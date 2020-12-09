using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Extensions;
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public partial class CloudFlareClient
    {
        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAccountMembersAsync(string accountId)
        {
            return await GetAccountMembersAsync(accountId, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAccountMembersAsync(string accountId,
            CancellationToken cancellationToken)
        {
            return await GetAccountMembersAsync(accountId, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAccountMembersAsync(string accountId,
            int? page)
        {
            return await GetAccountMembersAsync(accountId, page, null, null, default).ConfigureAwait(false);

        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAccountMembersAsync(string accountId,
            int? page, CancellationToken cancellationToken)
        {
            return await GetAccountMembersAsync(accountId, page, null, null, cancellationToken).ConfigureAwait(false);

        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAccountMembersAsync(string accountId,
            int? page, int? perPage)
        {
            return await GetAccountMembersAsync(accountId, page, perPage, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAccountMembersAsync(string accountId,
            int? page, int? perPage, CancellationToken cancellationToken)
        {
            return await GetAccountMembersAsync(accountId, page, perPage, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAccountMembersAsync(string accountId,
            int? page, int? perPage, OrderType? order)
        {
            return await GetAccountMembersAsync(accountId, page, perPage, order, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAccountMembersAsync(string accountId,
            int? page, int? perPage, OrderType? order, CancellationToken cancellationToken)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Page, page)
                .InsertValue(ApiParameter.Filtering.PerPage, perPage)
                .InsertValue(ApiParameter.Filtering.Direction, order);

            var parameterString = parameterBuilder.ParameterCollection;

            return await _httpClient.GetAsync<IReadOnlyList<AccountMember>>(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/?{parameterString}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}