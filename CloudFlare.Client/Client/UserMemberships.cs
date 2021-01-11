using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Interfaces;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Client
{
    public class UserMemberships : ApiContextBase<IConnection>, IUserMemberships
    {
        public UserMemberships(IConnection connection) : base(connection)
        {
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> DeleteAsync(string membershipId)
        {
            return await DeleteAsync(membershipId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> DeleteAsync(string membershipId,
            CancellationToken cancellationToken)
        {
            return await Connection.DeleteAsync<IReadOnlyList<UserMembership>>(
                $"{ApiParameter.Endpoints.Membership.Base}/{membershipId}", cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync()
        {
            return await GetAsync(null, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(CancellationToken cancellationToken)
        {
            return await GetAsync(null, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status)
        {
            return await GetAsync(status, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, CancellationToken cancellationToken)
        {
            return await GetAsync(status, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, string accountName)
        {
            return await GetAsync(status, accountName, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, string accountName, CancellationToken cancellationToken)
        {
            return await GetAsync(status, accountName, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, string accountName, int? page)
        {
            return await GetAsync(status, accountName, page, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, string accountName, int? page, CancellationToken cancellationToken)
        {
            return await GetAsync(status, accountName, page, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, string accountName, int? page, int? perPage)
        {
            return await GetAsync(status, accountName, page, perPage, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, string accountName, int? page, int? perPage, CancellationToken cancellationToken)
        {
            return await GetAsync(status, accountName, page, perPage, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, string accountName, int? page, int? perPage, MembershipOrder? membershipOrder)
        {
            return await GetAsync(status, accountName, page, perPage, membershipOrder, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, string accountName, int? page, int? perPage, MembershipOrder? membershipOrder, CancellationToken cancellationToken)
        {
            return await GetAsync(status, accountName, page, perPage, membershipOrder, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, string accountName, int? page, int? perPage, MembershipOrder? membershipOrder, OrderType? order)
        {
            return await GetAsync(status, accountName, page, perPage, membershipOrder, order, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, string accountName, int? page, int? perPage, MembershipOrder? membershipOrder, OrderType? order, CancellationToken cancellationToken)
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


            return await Connection.GetAsync<IReadOnlyList<UserMembership>>($"{ApiParameter.Endpoints.Membership.Base}/?{parameterString}", cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetDetailsAsync(string membershipId)
        {
            return await GetDetailsAsync(membershipId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetDetailsAsync(string membershipId, CancellationToken cancellationToken)
        {
            return await Connection.GetAsync<IReadOnlyList<UserMembership>>($"{ApiParameter.Endpoints.Membership.Base}/?{membershipId}", cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> UpdateAsync(string membershipId, MembershipStatus status)
        {
            return await UpdateAsync(membershipId, status, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> UpdateAsync(string membershipId, MembershipStatus status, CancellationToken cancellationToken)
        {
            var data = new Dictionary<string, MembershipStatus>
            {
                {ApiParameter.Filtering.Status, status}
            };

            return await Connection.PutAsync<IReadOnlyList<UserMembership>, Dictionary<string, MembershipStatus>>($"{ApiParameter.Endpoints.Membership.Base}/{membershipId}", data, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}