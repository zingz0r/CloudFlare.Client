using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts.Member;
using CloudFlare.Client.Api.Accounts.Roles;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Helpers;

namespace CloudFlare.Client.Client.Accounts
{
    public class Members : ApiContextBase<IConnection>, IMembers
    {
        public Members(IConnection connection) : base(connection)
        {
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Member>> AddAsync(string accountId, string emailAddress, Status status, IReadOnlyList<Role> roles, CancellationToken cancellationToken = default)
        {
            var membership = new NewMember
            {
                EmailAddress = emailAddress,
                Roles = roles,
                Status = status
            };

            var requestUri = $"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Members}";
            return await Connection.PostAsync<Member, NewMember>(requestUri, membership, cancellationToken).ConfigureAwait(false);
        }


        /// <inheritdoc />
        public async Task<CloudFlareResult<Member>> DeleteAsync(string accountId, string memberId, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Members}/{memberId}";
            return await Connection.DeleteAsync<Member>(requestUri, cancellationToken).ConfigureAwait(false);
        }


        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Member>>> GetAsync(string accountId, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default)
        {
            var builder = new ParameterBuilderHelper()
                .InsertValue(Filtering.Page, displayOptions?.Page)
                .InsertValue(Filtering.PerPage, displayOptions?.PerPage)
                .InsertValue(Filtering.Direction, displayOptions?.Order);

            var requestUri = $"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Members}";
            if (builder.ParameterCollection.HasKeys())
            {
                requestUri = $"{requestUri}/?{builder.ParameterCollection}";
            }

            return await Connection.GetAsync<IReadOnlyList<Member>>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Member>> GetDetailsAsync(string accountId, string memberId, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Members}/{memberId}";
            return await Connection.GetAsync<Member>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Member>> UpdateAsync(string accountId, string memberId, IReadOnlyList<Role> roles, AdditionalMemberSettings settings = null,
            CancellationToken cancellationToken = default)
        {
            var modified = new Member
            {
                Code = settings?.Code,
                User = settings?.User,
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