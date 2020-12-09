using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Extensions;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public partial class CloudFlareClient
    {
        /// <inheritdoc />
        public async Task<CloudFlareResult<Account>> UpdateAccountAsync(string accountId,
            string name)
        {
            return await UpdateAccountAsync(accountId, name, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Account>> UpdateAccountAsync(string accountId,
            string name, CancellationToken cancellationToken)
        {
            return await UpdateAccountAsync(accountId, name, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Account>> UpdateAccountAsync(string accountId,
            string name, AccountSettings settings)
        {
            return await UpdateAccountAsync(accountId, name, settings, default).ConfigureAwait(false);

        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Account>> UpdateAccountAsync(string accountId,
            string name, AccountSettings settings, CancellationToken cancellationToken)
        {
            var updatedAccount = new Account
            {
                Id = accountId,
                Name = name,
                Settings = settings
            };

            return await _httpClient.PutAsync<Account, Account>(
                    $"{ApiParameter.Endpoints.Account.Base}/{accountId}", updatedAccount, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}