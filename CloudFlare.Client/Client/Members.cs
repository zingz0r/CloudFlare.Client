using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Account;
using CloudFlare.Client.Api.Parameters;
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
        public async Task<CloudFlareResult<AccountMember>> AddAsync(string accountId, string emailAddress, IReadOnlyList<AccountRole> roles, CancellationToken cancellationToken = default)
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
        public async Task<CloudFlareResult<AccountMember>> DeleteAsync(string accountId, string memberId, CancellationToken cancellationToken = default)
        {
            return await Connection.DeleteAsync<AccountMember>(
                    $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/{memberId}", cancellationToken)
                .ConfigureAwait(false);
        }


        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAsync(string accountId, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Page, displayOptions?.Page)
                .InsertValue(ApiParameter.Filtering.PerPage, displayOptions?.PerPage)
                .InsertValue(ApiParameter.Filtering.Direction, displayOptions?.Order);

            var parameterString = parameterBuilder.ParameterCollection;

            return await Connection.GetAsync<IReadOnlyList<AccountMember>>(
                    $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/?{parameterString}", cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> GetDetailsAsync(string accountId, string memberId, CancellationToken cancellationToken = default)
        {
            return await Connection.GetAsync<AccountMember>(
                    $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/{memberId}", cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, MemberUpdateSettings settings = null,
            CancellationToken cancellationToken = default)
        {
            var updatedAccountMember = new AccountMember
            {
                Code = settings?.Code,
                User = settings?.User,
                Roles = roles,
            };

            if (settings?.Status != null)
            {
                updatedAccountMember.Status = settings.Status.Value;
            }

            return await Connection.PutAsync<AccountMember, AccountMember>($"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/{memberId}",
                    updatedAccountMember, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}