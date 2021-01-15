using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Zones.CustomHostnames;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.Helpers;
using CloudFlare.Client.Test.TestData;
using FluentAssertions;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace CloudFlare.Client.Test.Zones
{
    public class CustomHostnamesUnitTests
    {
        private readonly WireMockServer _wireMockServer;
        private readonly ConnectionInfo _connectionInfo;

        public CustomHostnamesUnitTests()
        {
            _wireMockServer = WireMockServer.Start();
            _connectionInfo = new WireMockConnection(_wireMockServer.Urls.First()).ConnectionInfo;
        }

        [Fact]
        public async Task TestAddCustomHostnameAsync()
        {
            var zone = ZoneTestData.Zones.First();
            var customHostname = CustomHostnameTestData.CustomHostnames.First();
            var newCustomHostname = new NewCustomHostname { Hostname = customHostname.Hostname, Ssl = SslTestData.Ssls.First() };

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{CustomHostnameEndpoints.Base}").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(customHostname)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var addCustomHostname = await client.Zones.CustomHostnames.AddAsync(zone.Id, newCustomHostname);

            addCustomHostname.Result.Should().BeEquivalentTo(customHostname);
        }

        [Fact]
        public async Task TestGetCustomHostnamesAsync()
        {
            var displayOptions = new DisplayOptions { Page = 1, PerPage = 20, Order = OrderType.Asc };

            var zone = ZoneTestData.Zones.First();

            _wireMockServer
                .Given(Request.Create()
                    .WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{CustomHostnameEndpoints.Base}/")
                    .WithParam(Filtering.Page)
                    .WithParam(Filtering.PerPage)
                    .WithParam(Filtering.PerPage)
                    .UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(CustomHostnameTestData.CustomHostnames)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var customHostnames = await client.Zones.CustomHostnames.GetAsync(zone.Id, displayOptions: displayOptions);

            customHostnames.Result.Should().BeEquivalentTo(CustomHostnameTestData.CustomHostnames);
        }

        [Fact]
        public async Task TestGetCustomHostnameDetailsAsync()
        {
            var zone = ZoneTestData.Zones.First();
            var customHostname = CustomHostnameTestData.CustomHostnames.First();

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{CustomHostnameEndpoints.Base}/{customHostname.Id}").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(customHostname)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var customHostnameDetails = await client.Zones.CustomHostnames.GetDetailsAsync(zone.Id, customHostname.Id);

            customHostnameDetails.Result.Should().BeEquivalentTo(customHostname);
        }

        [Fact]
        public async Task TestEditCustomHostnameAsync()
        {
            var zone = ZoneTestData.Zones.First();
            var customHostname = CustomHostnameTestData.CustomHostnames.First();
            var modified = new ModifiedCustomHostname
            {
                Ssl = SslTestData.Ssls.First().DeepClone()
            };
            modified.Ssl.Settings.Tls13 = FeatureStatus.Off;

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{CustomHostnameEndpoints.Base}/{customHostname.Id}").UsingPatch())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(x =>
                    {
                        var body = JsonConvert.DeserializeObject<NewCustomHostname>(x.Body);
                        var response = CustomHostnameTestData.CustomHostnames.First(y => y.Id == x.PathSegments[3]).DeepClone();
                        response.Ssl = body.Ssl;

                        return WireMockResponseHelper.CreateTestResponse(response);
                    }));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var editCustomHostname = await client.Zones.CustomHostnames.UpdateAsync(zone.Id, customHostname.Id, modified);

            editCustomHostname.Result.Should().BeEquivalentTo(customHostname, opt => opt.Excluding(y => y.Ssl.Settings.Tls13));
            editCustomHostname.Result.Ssl.Settings.Tls13.Should().BeEquivalentTo(FeatureStatus.Off);
        }

        [Fact]
        public async Task TestDeleteCustomHostnameAsync()
        {
            var zone = ZoneTestData.Zones.First();
            var customHostname = CustomHostnameTestData.CustomHostnames.First();
            var expected = new CustomHostname { Id = customHostname.Id };

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{CustomHostnameEndpoints.Base}/{customHostname.Id}").UsingDelete())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(expected)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var deleteCustomHostname = await client.Zones.CustomHostnames.DeleteAsync(zone.Id, customHostname.Id);

            deleteCustomHostname.Result.Should().BeEquivalentTo(expected);
        }
    }
}
