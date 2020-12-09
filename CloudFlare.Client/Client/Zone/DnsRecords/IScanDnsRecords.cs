using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface IScanDnsRecords
    {
        /// <summary>
        /// Scan for DNS Records, alternative to jump_start option
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecordScan>> ScanDnsRecordsAsync(string zoneId);

        /// <summary>
        /// Scan for DNS Records, alternative to jump_start option
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecordScan>> ScanDnsRecordsAsync(string zoneId, CancellationToken cancellationToken);
    }
}