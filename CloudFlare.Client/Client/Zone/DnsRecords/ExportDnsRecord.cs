using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Extensions;

namespace CloudFlare.Client
{
    public partial class CloudFlareClient
    {
        /// <inheritdoc />
        public async Task<CloudFlareResult<string>> ExportDnsRecordsAsync(string zoneId)
        {
            return await ExportDnsRecordsAsync(zoneId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<string>> ExportDnsRecordsAsync(string zoneId,
            CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<string>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{ApiParameter.Endpoints.DnsRecord.Export}/", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}