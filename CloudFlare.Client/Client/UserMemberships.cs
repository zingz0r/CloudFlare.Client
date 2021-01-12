using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Parameters;
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
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> DeleteAsync(string membershipId,
            CancellationToken cancellationToken = default)
        {
            return await Connection.DeleteAsync<IReadOnlyList<UserMembership>>(
                $"{ApiParameter.Endpoints.Membership.Base}/{membershipId}", cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipFilter filter = null, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Status, filter?.Status)
                .InsertValue(ApiParameter.Filtering.AccountName, filter?.AccountName)
                .InsertValue(ApiParameter.Filtering.Order, filter?.MembershipOrder)
                .InsertValue(ApiParameter.Filtering.Page, displayOptions?.Page)
                .InsertValue(ApiParameter.Filtering.PerPage, displayOptions?.PerPage)
                .InsertValue(ApiParameter.Filtering.Direction, displayOptions?.Order);

            var parameterString = parameterBuilder.ParameterCollection;


            return await Connection.GetAsync<IReadOnlyList<UserMembership>>($"{ApiParameter.Endpoints.Membership.Base}/?{parameterString}", cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetDetailsAsync(string membershipId, CancellationToken cancellationToken = default)
        {
            return await Connection.GetAsync<IReadOnlyList<UserMembership>>($"{ApiParameter.Endpoints.Membership.Base}/?{membershipId}", cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<UserMembership>>> UpdateAsync(string membershipId, MembershipStatus status, CancellationToken cancellationToken = default)
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