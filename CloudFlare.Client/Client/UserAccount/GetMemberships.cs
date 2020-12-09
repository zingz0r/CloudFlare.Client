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
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync()
        {
            return await GetMembershipsAsync(null, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(CancellationToken cancellationToken)
        {
            return await GetMembershipsAsync(null, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status)
        {
            return await GetMembershipsAsync(status, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            CancellationToken cancellationToken)
        {
            return await GetMembershipsAsync(status, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            string accountName)
        {
            return await GetMembershipsAsync(status, accountName, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            string accountName, CancellationToken cancellationToken)
        {
            return await GetMembershipsAsync(status, accountName, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            string accountName, int? page)
        {
            return await GetMembershipsAsync(status, accountName, page, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            string accountName, int? page, CancellationToken cancellationToken)
        {
            return await GetMembershipsAsync(status, accountName, page, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            string accountName, int? page, int? perPage)
        {
            return await GetMembershipsAsync(status, accountName, page, perPage, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            string accountName, int? page, int? perPage, CancellationToken cancellationToken)
        {
            return await GetMembershipsAsync(status, accountName, page, perPage, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            string accountName, int? page, int? perPage, MembershipOrder? membershipOrder)
        {
            return await GetMembershipsAsync(status, accountName, page, perPage, membershipOrder, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            string accountName, int? page, int? perPage, MembershipOrder? membershipOrder, CancellationToken cancellationToken)
        {
            return await GetMembershipsAsync(status, accountName, page, perPage, membershipOrder, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            string accountName, int? page, int? perPage, MembershipOrder? membershipOrder, OrderType? order)
        {
            return await GetMembershipsAsync(status, accountName, page, perPage, membershipOrder, order, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            string accountName, int? page, int? perPage, MembershipOrder? membershipOrder, OrderType? order, CancellationToken cancellationToken)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Status, status)
                .InsertValue(ApiParameter.Filtering.AccountName, accountName)
                .InsertValue(ApiParameter.Filtering.Page, page)
                .InsertValue(ApiParameter.Filtering.PerPage, perPage)
                .InsertValue(ApiParameter.Filtering.Order, membershipOrder)
                .InsertValue(ApiParameter.Filtering.Direction, order);

            var parameterString = parameterBuilder.ParameterCollection;


            return await _httpClient.GetAsync<IEnumerable<UserMembership>>(
                $"{ApiParameter.Endpoints.Membership.Base}/?{parameterString}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}