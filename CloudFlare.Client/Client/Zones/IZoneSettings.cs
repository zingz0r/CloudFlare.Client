using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zones;
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

        /// <summary>
        /// Retrieves Optimization/Minification settings for <see cref="Zone"/>
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The minification setting</returns>
        Task<CloudFlareResult<MinifySetting>> GetMinifySettingAsync(string zoneId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates Optimization/Minification settings for <see cref="Zone"/>
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="setting">Enum for turning on/off requirement for always using SSL</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The new minification setting</returns>
        Task<CloudFlareResult<MinifySetting>> UpdateMinifySettingAsync(string zoneId, MinifySetting setting, CancellationToken cancellationToken = default);
    }
}
