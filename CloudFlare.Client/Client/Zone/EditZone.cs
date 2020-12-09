using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zone;
using CloudFlare.Client.Extensions;
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public partial class CloudFlareClient
    {
        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> EditZoneAsync(string zoneId,
            PatchZone patchZone)
        {
            return await EditZoneAsync(zoneId, patchZone, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> EditZoneAsync(string zoneId,
            PatchZone patchZone, CancellationToken cancellationToken)
        {
            return await _httpClient.PatchAsync<Zone>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}", PatchContentHelper.Create(patchZone), cancellationToken)
                .ConfigureAwait(false);
        }
    }
}