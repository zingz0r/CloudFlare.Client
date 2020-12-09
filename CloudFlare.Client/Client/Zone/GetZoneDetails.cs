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
        public async Task<CloudFlareResult<Zone>> GetZoneDetailsAsync(string zoneId)
        {
            return await GetZoneDetailsAsync(zoneId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> GetZoneDetailsAsync(string zoneId,
            CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<Zone>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}", cancellationToken).ConfigureAwait(false);
        }
    }
}