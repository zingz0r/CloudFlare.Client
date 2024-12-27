using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zones;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Client.Zones;

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
    /// <returns><see cref="ZoneSetting{FeatureStatus}"/></returns>
    Task<CloudFlareResult<ZoneSetting<FeatureStatus>>> GetAlwaysUseHttpsSettingAsync(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates whether or not the SSL/TLS Edge Certificate requires HTTPS or not
    /// </summary>
    /// <param name="zoneId">Zone identifier</param>
    /// <param name="status">Enum for turning on/off requirement for always using SSL</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns><see cref="ZoneSetting{FeatureStatus}"/></returns>
    Task<CloudFlareResult<ZoneSetting<FeatureStatus>>> UpdateAlwaysUseHttpsSettingAsync(string zoneId, FeatureStatus status, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the zone SSL settings
    /// </summary>
    /// <param name="zoneId">Zone identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns><see cref="ZoneSetting{SslSetting}"/></returns>
    Task<CloudFlareResult<ZoneSetting<SslSetting>>> GetSslSettingAsync(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the zone SSL settings
    /// </summary>
    /// <param name="zoneId">Zone identifier</param>
    /// <param name="sslSetting">Enum for SSL setting</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// /// <returns><see cref="ZoneSetting{SslSetting}"/></returns>
    Task<CloudFlareResult<ZoneSetting<SslSetting>>> UpdateSslSettingAsync(string zoneId, SslSetting sslSetting, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the zone Minimum TLS version settings
    /// </summary>
    /// <param name="zoneId">Zone identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns><see cref="ZoneSetting{TlsVersion}"/></returns>
    Task<CloudFlareResult<ZoneSetting<TlsVersion>>> GetMinimumTlsVersionSettingAsync(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the zone Minimum TLS version settings
    /// </summary>
    /// <param name="zoneId">Zone identifier</param>
    /// <param name="tlsVersion">Enum for minimum TLS version</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// /// <returns><see cref="ZoneSetting{TlsVersion}"/></returns>
    Task<CloudFlareResult<ZoneSetting<TlsVersion>>> UpdateMinimumTlsVersionSettingAsync(string zoneId, TlsVersion tlsVersion, CancellationToken cancellationToken = default);
}
