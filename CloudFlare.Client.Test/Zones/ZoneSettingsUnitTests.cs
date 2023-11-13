using System;
using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zones;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.Helpers;
using CloudFlare.Client.Test.TestData;
using FluentAssertions;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace CloudFlare.Client.Test.Zones
{
    public class ZoneSettingsUnitTests
    {
        private readonly WireMockServer _wireMockServer;
        private readonly ConnectionInfo _connectionInfo;

        public ZoneSettingsUnitTests()
        {
            _wireMockServer = WireMockServer.Start();
            _connectionInfo = new WireMockConnection(_wireMockServer.Urls.First()).ConnectionInfo;
        }

        [Theory]
        [InlineData(FeatureStatus.On)]
        [InlineData(FeatureStatus.Off)]
        public async Task TestGetAlwaysUseHttpsAsync(FeatureStatus status)
        {
            var zone = ZoneTestData.Zones.First();

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{SettingsEndpoints.Base}/{SettingsEndpoints.AlwaysUseHttps}").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(status)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var result = await client.Zones.Settings.GetAlwaysUseHttpsSettingAsync(zone.Id);

            result.Result.Should().Be(status);
        }

        [Theory]
        [InlineData(FeatureStatus.On)]
        [InlineData(FeatureStatus.Off)]
        public async Task TestUpdateAlwaysUseHttpsAsync(FeatureStatus status)
        {
            var zone = ZoneTestData.Zones.First();

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{SettingsEndpoints.Base}/{SettingsEndpoints.AlwaysUseHttps}").UsingPatch())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(status)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var result = await client.Zones.Settings.UpdateAlwaysUseHttpsSettingAsync(zone.Id, status);

            result.Result.Should().Be(status);
        }

        [Theory]
        [InlineData(SslSetting.Flexible)]
        [InlineData(SslSetting.Full)]
        [InlineData(SslSetting.Strict)]
        [InlineData(SslSetting.Off)]
        public async Task TestGetSslSettingsAsync(SslSetting status)
        {
            var zone = ZoneTestData.Zones.First();
            var zoneSetting = new ZoneSetting<SslSetting>
            {
                Id = Guid.NewGuid().ToString(),
                Value = status,
                ModifiedDate = DateTime.UtcNow,
                CertificateStatus = "active",
                ValidationErrors = Array.Empty<ErrorDetails>(),
                Editable = true
            };

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{SettingsEndpoints.Base}/{SettingsEndpoints.Ssl}").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(zoneSetting)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var result = await client.Zones.Settings.GetSslSettingAsync(zone.Id);

            result.Result.Should().BeEquivalentTo(zoneSetting);
        }

        [Theory]
        [InlineData(SslSetting.Flexible)]
        [InlineData(SslSetting.Full)]
        [InlineData(SslSetting.Strict)]
        [InlineData(SslSetting.Off)]
        public async Task TestUpdateSslSettingsAsync(SslSetting status)
        {
            var zone = ZoneTestData.Zones.First();
            var zoneSetting = new ZoneSetting<SslSetting>
            {
                Id = Guid.NewGuid().ToString(),
                Value = status,
                ModifiedDate = DateTime.UtcNow,
                CertificateStatus = "active",
                ValidationErrors = Array.Empty<ErrorDetails>(),
                Editable = true
            };

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{SettingsEndpoints.Base}/{SettingsEndpoints.Ssl}").UsingPatch())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(zoneSetting)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var result = await client.Zones.Settings.UpdateSslSettingAsync(zone.Id, status);

            result.Result.Should().BeEquivalentTo(zoneSetting);
        }
    }
}
