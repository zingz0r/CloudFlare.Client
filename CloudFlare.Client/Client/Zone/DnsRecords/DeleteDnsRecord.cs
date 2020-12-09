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
        public async Task<CloudFlareResult<DnsRecord>> DeleteDnsRecordAsync(string zoneId,
            string identifier)
        {
            return await DeleteDnsRecordAsync(zoneId, identifier, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> DeleteDnsRecordAsync(string zoneId,
            string identifier, CancellationToken cancellationToken)
        {
            return await _httpClient.DeleteAsync<DnsRecord>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{identifier}/", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}