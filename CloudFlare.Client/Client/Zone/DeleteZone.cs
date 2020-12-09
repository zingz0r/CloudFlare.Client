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
        public async Task<CloudFlareResult<Zone>> DeleteZoneAsync(string zoneId)
        {
            return await DeleteZoneAsync(zoneId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> DeleteZoneAsync(string zoneId,
            CancellationToken cancellationToken)
        {
            return await _httpClient.DeleteAsync<Zone>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}