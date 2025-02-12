using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zones;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Client.Zones;

/// <inheritdoc cref="CloudFlare.Client.Client.Zones.IZoneSettings" />
public class ZoneSettings : ApiContextBase<IConnection>, IZoneSettings
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ZoneSettings"/> class
    /// </summary>
    /// <param name="connection">Connection settings</param>
    public ZoneSettings(IConnection connection)
        : base(connection)
    {
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<ZoneSetting<FeatureStatus>>> GetAlwaysUseHttpsSettingAsync(string zoneId, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{ZoneEndpoints.Base}/{zoneId}/{SettingsEndpoints.Base}/{SettingsEndpoints.AlwaysUseHttps}");
        return await Connection.GetAsync<ZoneSetting<FeatureStatus>>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<ZoneSetting<FeatureStatus>>> UpdateAlwaysUseHttpsSettingAsync(string zoneId, FeatureStatus status, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{ZoneEndpoints.Base}/{zoneId}/{SettingsEndpoints.Base}/{SettingsEndpoints.AlwaysUseHttps}");
        return await Connection.PatchAsync(requestUri, new ZoneSetting<FeatureStatus> { Value = status }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<ZoneSetting<SslSetting>>> GetSslSettingAsync(string zoneId, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{ZoneEndpoints.Base}/{zoneId}/{SettingsEndpoints.Base}/{SettingsEndpoints.Ssl}");
        return await Connection.GetAsync<ZoneSetting<SslSetting>>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<ZoneSetting<SslSetting>>> UpdateSslSettingAsync(string zoneId, SslSetting sslSetting, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{ZoneEndpoints.Base}/{zoneId}/{SettingsEndpoints.Base}/{SettingsEndpoints.Ssl}");
        return await Connection.PatchAsync(requestUri, new ZoneSetting<SslSetting> { Value = sslSetting }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<ZoneSetting<TlsVersion>>> GetMinimumTlsVersionSettingAsync(string zoneId, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{ZoneEndpoints.Base}/{zoneId}/{SettingsEndpoints.Base}/{SettingsEndpoints.MinimumTlsVersion}");
        return await Connection.GetAsync<ZoneSetting<TlsVersion>>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<ZoneSetting<TlsVersion>>> UpdateMinimumTlsVersionSettingAsync(string zoneId, TlsVersion tlsVersion, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{ZoneEndpoints.Base}/{zoneId}/{SettingsEndpoints.Base}/{SettingsEndpoints.MinimumTlsVersion}");
        return await Connection.PatchAsync(requestUri, new ZoneSetting<TlsVersion> { Value = tlsVersion }, cancellationToken).ConfigureAwait(false);
    }
}
