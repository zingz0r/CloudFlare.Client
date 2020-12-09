using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface IPurgeAllFiles
    {
        /// <summary>
        /// Remove ALL files from CloudFlare's cache
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="purgeEverything">A flag that indicates all resources in CloudFlare's cache should be removed. Note: This may have dramatic affects on your origin server load after performing this action.</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> PurgeAllFilesAsync(string zoneId, bool purgeEverything);

        /// <summary>
        /// Remove ALL files from CloudFlare's cache
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="purgeEverything">A flag that indicates all resources in CloudFlare's cache should be removed. Note: This may have dramatic affects on your origin server load after performing this action.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> PurgeAllFilesAsync(string zoneId, bool purgeEverything, CancellationToken cancellationToken);
    }
}