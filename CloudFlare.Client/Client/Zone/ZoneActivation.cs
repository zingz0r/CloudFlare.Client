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
        public async Task<CloudFlareResult<Zone>> ZoneActivationCheckAsync(string zoneId)
        {
            return await ZoneActivationCheckAsync(zoneId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> ZoneActivationCheckAsync(string zoneId,
            CancellationToken cancellationToken)
        {
            return await _httpClient.PutAsync<Zone, object>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.Zone.ActivationCheck}", "", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}