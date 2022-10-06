using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Client.Zones
{
    /// <summary>
    /// Interface for interacting with a Zone's SSL/TLS Edge Certificate Settings
    /// </summary>
    public interface IZoneSettings
    {
        /// <summary>
        /// Retrieves whether or not the SSL/TLS Edget Certificate requires HTTPS or not
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Value of setting. "on" if required, "off" if not</returns>
        Task<CloudFlareResult<FeatureStatus>> GetAlwaysUseHttpsSettingAsync(string zoneId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates whether or not the SSL/TLS Edget Certificate requires HTTPS or not
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="status">Enum for turning on/off requirement for always using SSL</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Value of setting. "on" if required, "off" if not</returns>
        Task<CloudFlareResult<FeatureStatus>> UpdateAlwaysUseHttpsSettingAsync(string zoneId, FeatureStatus status, CancellationToken cancellationToken = default);
    }
}
