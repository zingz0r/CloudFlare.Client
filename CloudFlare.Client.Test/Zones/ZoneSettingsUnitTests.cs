using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Parameters.Endpoints;
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

        [Fact]
        public async Task TestUpdateAlwaysUseHttpsAsync()
        {
            var zone = ZoneTestData.Zones.First();
            FeatureStatus alwaysUseHttps = ZoneSettingsTestData.Values.First();

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{ZoneSettingsEndpoints.AlwaysUseHttps}").UsingPatch())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(alwaysUseHttps)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var alwaysUseHttpsUnderTest = await client.Zones.ZoneSettings.UpdateAlwaysUseHttpsSettingAsync(zone.Id, alwaysUseHttps);

            alwaysUseHttpsUnderTest.Result.Should().Be(alwaysUseHttps);
        }

        [Fact]
        public async Task TestGetAlwaysUseHttpsAsync()
        {
            var zone = ZoneTestData.Zones.First();
            FeatureStatus alwaysUseHttps = ZoneSettingsTestData.Values.First();

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{ZoneSettingsEndpoints.AlwaysUseHttps}").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(alwaysUseHttps)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var alwaysUseHttpsUnderTest = await client.Zones.ZoneSettings.GetAlwaysUseHttpsSettingAsync(zone.Id);

            alwaysUseHttpsUnderTest.Result.Should().Be(alwaysUseHttps);
        }

        [Fact]
        public async Task TestUpdateMinifySettingAsync()
        {
            var zone = ZoneTestData.Zones.First();
            var minify = ZoneSettingsTestData.MinifySettings.First();
            var minifyUpdateResult = ZoneSettingsTestData.MinifySettings.Last();

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{ZoneSettingsEndpoints.Minify}").UsingPatch())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(minifyUpdateResult)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var alwaysUseHttpsUnderTest = await client.Zones.ZoneSettings.UpdateMinifySettingAsync(zone.Id, minify);

            alwaysUseHttpsUnderTest.Result.Should().BeEquivalentTo(minifyUpdateResult);
        }

        [Fact]
        public async Task TestGetMinifySettingAsync()
        {
            var zone = ZoneTestData.Zones.First();
            var minify = ZoneSettingsTestData.MinifySettings.First();

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{ZoneSettingsEndpoints.Minify}").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(minify)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var alwaysUseHttpsUnderTest = await client.Zones.ZoneSettings.GetMinifySettingAsync(zone.Id);

            alwaysUseHttpsUnderTest.Result.Should().BeEquivalentTo(minify);
        }
    }
}
