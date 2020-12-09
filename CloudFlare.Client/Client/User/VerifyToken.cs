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
        public async Task<CloudFlareResult<VerifyToken>> VerifyTokenAsync()
        {
            return await VerifyTokenAsync(default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<VerifyToken>> VerifyTokenAsync(CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<VerifyToken>($"{ApiParameter.Endpoints.Tokens.Base}/{ApiParameter.Endpoints.Tokens.Verify}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}