using System.Collections.Generic;
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
        public async Task<CloudFlareResult<Zone>> PurgeAllFilesAsync(string zoneId,
            bool purgeEverything)
        {
            return await PurgeAllFilesAsync(zoneId, purgeEverything, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> PurgeAllFilesAsync(string zoneId,
            bool purgeEverything, CancellationToken cancellationToken)
        {
            var content = new Dictionary<string, bool> { { ApiParameter.Outgoing.PurgeEverything, purgeEverything } };

            return await _httpClient.PostAsync<Zone, Dictionary<string, bool>>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.Zone.PurgeCache}", content, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}