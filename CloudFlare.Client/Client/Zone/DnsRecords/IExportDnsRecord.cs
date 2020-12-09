using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;

namespace CloudFlare.Client
{
    public interface IExportDnsRecord
    {
        /// <summary>
        /// Export your BIND config through this endpoint.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <returns></returns>
        Task<CloudFlareResult<string>> ExportDnsRecordsAsync(string zoneId);

        /// <summary>
        /// Export your BIND config through this endpoint.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<string>> ExportDnsRecordsAsync(string zoneId, CancellationToken cancellationToken);
    }
}