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
        public async Task<CloudFlareResult<User>> GetUserDetailsAsync()
        {
            return await GetUserDetailsAsync(default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<User>> GetUserDetailsAsync(CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<User>($"{ApiParameter.Endpoints.User.Base}/", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}