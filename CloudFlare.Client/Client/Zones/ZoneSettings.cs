using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zones;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Client.Zones
{
    /// <inheritdoc />
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
        public async Task<CloudFlareResult<FeatureStatus>> GetAlwaysUseHttpsSettingAsync(string zoneId, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{ZoneSettingsEndpoints.AlwaysUseHttps}";
            return await Connection.GetAsync<FeatureStatus>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<FeatureStatus>> UpdateAlwaysUseHttpsSettingAsync(string zoneId, FeatureStatus status, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{ZoneSettingsEndpoints.AlwaysUseHttps}";
            return await Connection.PatchAsync<FeatureStatus>(requestUri, status, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<MinifySetting>> GetMinifySettingAsync(string zoneId, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{ZoneSettingsEndpoints.Minify}";
            return await Connection.GetAsync<MinifySetting>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<MinifySetting>> UpdateMinifySettingAsync(string zoneId, MinifySetting setting, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{ZoneSettingsEndpoints.Minify}";
            return await Connection.PatchAsync<MinifySetting>(requestUri, setting, cancellationToken).ConfigureAwait(false);
        }
    }
}
