using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Memberships;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Helpers;

namespace CloudFlare.Client.Client.Users
{
    public class Memberships : ApiContextBase<IConnection>, IMemberships
    {
        public Memberships(IConnection connection) : base(connection)
        {
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Membership<Account, string>>>> DeleteAsync(string membershipId, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{MembershipEndpoints.Base}/{membershipId}";
            return await Connection.DeleteAsync<IReadOnlyList<Membership<Account, string>>>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Membership<Account, string>>>> GetAsync(MembershipFilter filter = null, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default)
        {
            var builder = new ParameterBuilderHelper();

            builder
                .InsertValue(Filtering.Status, filter?.Status)
                .InsertValue(Filtering.AccountName, filter?.AccountName)
                .InsertValue(Filtering.Order, filter?.MembershipOrder)
                .InsertValue(Filtering.Page, displayOptions?.Page)
                .InsertValue(Filtering.PerPage, displayOptions?.PerPage)
                .InsertValue(Filtering.Direction, displayOptions?.Order);

            var requestUri = $"{MembershipEndpoints.Base}/?{builder.ParameterCollection}";
            return await Connection.GetAsync<IReadOnlyList<Membership<Account, string>>>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Membership<Account, string>>>> GetDetailsAsync(string membershipId, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{MembershipEndpoints.Base}/?{membershipId}";
            return await Connection.GetAsync<IReadOnlyList<Membership<Account, string>>>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Membership<Account, string>>>> UpdateAsync(string membershipId, MembershipStatus status, CancellationToken cancellationToken = default)
        {
            var data = new Dictionary<string, MembershipStatus>
            {
                {
                    Filtering.Status, status
                }
            };

            var requestUri = $"{MembershipEndpoints.Base}/{membershipId}";
            return await Connection.PutAsync<IReadOnlyList<Membership<Account, string>>, Dictionary<string, MembershipStatus>>(requestUri, data, cancellationToken).ConfigureAwait(false);
        }
    }
}