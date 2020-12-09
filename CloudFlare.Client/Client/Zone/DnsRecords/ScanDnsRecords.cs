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
        public async Task<CloudFlareResult<DnsRecordScan>> ScanDnsRecordsAsync(string zoneId)
        {
            return await ScanDnsRecordsAsync(zoneId, default);
        }

        public async Task<CloudFlareResult<DnsRecordScan>> ScanDnsRecordsAsync(string zoneId, CancellationToken cancellationToken)
        {
            return await _httpClient.PostAsync<DnsRecordScan, object>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{ApiParameter.Endpoints.DnsRecord.Scan}/", null, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}