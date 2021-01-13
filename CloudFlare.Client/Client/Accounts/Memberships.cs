using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts.Roles;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Memberships;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Users;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Helpers;

namespace CloudFlare.Client.Client.Accounts
{
    public class Memberships : ApiContextBase<IConnection>, IMemberships
    {
        public Memberships(IConnection connection) : base(connection)
        {
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Membership<User, Role>>> AddAsync(string accountId, string emailAddress, IReadOnlyList<Role> roles, CancellationToken cancellationToken = default)
        {
            var membership = new NewMembership
            {
                EmailAddress = emailAddress,
                Roles = roles,
                Status = MembershipStatus.Pending
            };

            var requestUri = $"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Members}";
            return await Connection.PostAsync<Membership<User, Role>, NewMembership>(requestUri, membership, cancellationToken).ConfigureAwait(false);
        }


        /// <inheritdoc />
        public async Task<CloudFlareResult<Membership<User, Role>>> DeleteAsync(string accountId, string memberId, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Members}/{memberId}";
            return await Connection.DeleteAsync<Membership<User, Role>>(requestUri, cancellationToken).ConfigureAwait(false);
        }


        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Membership<User, Role>>>> GetAsync(string accountId, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default)
        {
            var builder = new ParameterBuilderHelper()
                .InsertValue(Filtering.Page, displayOptions?.Page)
                .InsertValue(Filtering.PerPage, displayOptions?.PerPage)
                .InsertValue(Filtering.Direction, displayOptions?.Order);

            var requestUri = $"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Members}/?{builder.ParameterCollection}";
            return await Connection.GetAsync<IReadOnlyList<Membership<User, Role>>>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Membership<User, Role>>> GetDetailsAsync(string accountId, string memberId, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Members}/{memberId}";
            return await Connection.GetAsync<Membership<User, Role>>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Membership<User, Role>>> UpdateAsync(string accountId, string memberId, IReadOnlyList<Role> roles, AdditionalMembershipSettings<User> settings = null,
            CancellationToken cancellationToken = default)
        {
            var modified = new Membership<User, Role>
            {
                Code = settings?.Code,
                Entity = settings?.Entity,
                Roles = roles
            };

            if (settings?.Status != null)
            {
                modified.Status = settings.Status.Value;
            }

            var requestUri = $"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Members}/{memberId}";
            return await Connection.PutAsync(requestUri, modified, cancellationToken).ConfigureAwait(false);
        }
    }
}