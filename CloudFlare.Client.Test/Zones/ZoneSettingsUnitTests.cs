using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Client.Zones;
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
        [InlineData(SslSetting.Flexible)]
        [InlineData(SslSetting.Full)]
        [InlineData(SslSetting.Strict)]
        [InlineData(SslSetting.Off)]
        public async Task TestUpdateAlwaysUseHttpsAsync(SslSetting status)
        {
            var zone = ZoneTestData.Zones.First();

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{SettingsEndpoints.Base}/{SettingsEndpoints.Ssl}").UsingPatch())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(status)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var alwaysUseHttpsUnderTest = await client.Zones.ZoneSettings.UpdateAlwaysUseHttpsSettingAsync(zone.Id, status);

            alwaysUseHttpsUnderTest.Result.Should().Be(status);
        }

        [Theory]
        [InlineData(SslSetting.Flexible)]
        [InlineData(SslSetting.Full)]
        [InlineData(SslSetting.Strict)]
        [InlineData(SslSetting.Off)]
        public async Task TestGetAlwaysUseHttpsAsync(SslSetting status)
        {
            var zone = ZoneTestData.Zones.First();

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{SettingsEndpoints.Base}/{SettingsEndpoints.Ssl}").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(status)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var alwaysUseHttpsUnderTest = await client.Zones.ZoneSettings.GetAlwaysUseHttpsSettingAsync(zone.Id);

            alwaysUseHttpsUnderTest.Result.Should().Be(status);
        }
    }
}
