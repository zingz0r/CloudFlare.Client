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
        /// Retrieves whether or not the SSL/TLS Edge Certificate requires HTTPS or not
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns><see cref="FeatureStatus"/></returns>
        Task<CloudFlareResult<FeatureStatus>> GetAlwaysUseHttpsSettingAsync(string zoneId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the zone SSL settings
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns><see cref="ZoneSetting"/></returns>
        Task<CloudFlareResult<ZoneSetting>> GetSslSettingAsync(string zoneId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates whether or not the SSL/TLS Edge Certificate requires HTTPS or not
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="status">Enum for turning on/off requirement for always using SSL</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns><see cref="FeatureStatus"/></returns>
        Task<CloudFlareResult<FeatureStatus>> UpdateAlwaysUseHttpsSettingAsync(string zoneId, FeatureStatus status, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the zone SSL settings
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="sslSetting">Enum for ssl setting</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns><see cref="ZoneSetting"/></returns>
        Task<CloudFlareResult<ZoneSetting>> UpdateSslSettingAsync(string zoneId, SslSetting sslSetting, CancellationToken cancellationToken = default);
    }
}
