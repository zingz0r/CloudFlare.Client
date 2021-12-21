using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts.Member;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Helpers;

namespace CloudFlare.Client.Client.Accounts
{
    /// <inheritdoc />
    public class Members : ApiContextBase<IConnection>, IMembers
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Members"/> class
        /// </summary>
        /// <param name="connection">Connection settings</param>
        public Members(IConnection connection)
            : base(connection)
        {
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Member>> AddAsync(string accountId, NewMember newMember, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Members}";
            return await Connection.PostAsync<Member, NewMember>(requestUri, newMember, cancellationToken).ConfigureAwait(false);
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
        public async Task<CloudFlareResult<Member>> UpdateAsync(string accountId, Member member, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Members}/{member.Id}";
            return await Connection.PutAsync(requestUri, member, cancellationToken).ConfigureAwait(false);
        }
    }
}
