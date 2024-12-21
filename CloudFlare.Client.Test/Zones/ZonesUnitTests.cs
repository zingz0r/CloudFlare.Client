using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Zones;
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
    public class ZonesUnitTests
    {
        private readonly WireMockServer _wireMockServer;
        private readonly ConnectionInfo _connectionInfo;

        public ZonesUnitTests()
        {
            _wireMockServer = WireMockServer.Start();
            _connectionInfo = new WireMockConnection(_wireMockServer.Urls.First()).ConnectionInfo;
        }

        [Fact]
        public async Task TestCreateZoneAsync()
        {
            var zone = ZoneTestData.Zones.First();
            var newZone = new NewZone
            {
                Name = zone.Name,
                Type = zone.Type,
                Account = zone.Account,
            };

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(zone)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var addZone = await client.Zones.AddAsync(newZone);

            addZone.Result.Should().BeEquivalentTo(zone);
        }

        [Fact]
        public async Task TestGetZonesAsync()
        {
            var displayOptions = new DisplayOptions { Page = 1, PerPage = 20, Order = OrderType.Asc };
            var zoneFilter = new ZoneFilter { Match = false, Status = ZoneStatus.Active, Name = "tothnet.hu" };

            _wireMockServer
                .Given(Request.Create()
                    .WithPath($"/{ZoneEndpoints.Base}/")
                    .WithParam(Filtering.Page)
                    .WithParam(Filtering.PerPage)
                    .WithParam(Filtering.Order)
                    .WithParam(Filtering.Name)
                    .WithParam(Filtering.Status)
                    .WithParam(Filtering.Match)
                    .UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(ZoneTestData.Zones)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var zones = await client.Zones.GetAsync(zoneFilter, displayOptions);

            zones.Result.Should().BeEquivalentTo(ZoneTestData.Zones);
        }

        [Fact]
        public async Task TestGetZoneDetailsAsync()
        {
            var zone = ZoneTestData.Zones.First();

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(zone)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var zoneDetails = await client.Zones.GetDetailsAsync(zone.Id);

            zoneDetails.Result.Should().BeEquivalentTo(zone);
        }

        [Fact]
        public async Task TestEditZoneAsync()
        {
            var zone = ZoneTestData.Zones.First();
            var modified = new ModifiedZone { Paused = true };

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}").UsingPatch())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(x =>
                    {
                        var body = JsonConvert.DeserializeObject<ModifiedZone>(x.Body!);
                        var response = ZoneTestData.Zones.First(y => y.Id == x.PathSegments[1]).DeepClone();

                        if (body.Paused != null)
                        {
                            response.Paused = body.Paused.Value;
                        }

                        return WireMockResponseHelper.CreateTestResponse(response);
                    }));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var editZone = await client.Zones.UpdateAsync(zone.Id, modified);

            editZone.Result.Should().BeEquivalentTo(zone, opt => opt.Excluding(y => y.Paused));
            editZone.Result.Paused.Should().BeTrue();
        }

        [Fact]

        public async Task TestDeleteZoneAsync()
        {
            var zone = ZoneTestData.Zones.First();
            var expected = new Zone { Id = zone.Id };

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}").UsingDelete())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(expected)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var deletedZone = await client.Zones.DeleteAsync(zone.Id);

            deletedZone.Result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task TestZoneActivationCheckAsync()
        {
            var zone = ZoneTestData.Zones.First();
            var expected = new Zone { Id = zone.Id };

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{ZoneEndpoints.ActivationCheck}").UsingPut())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(expected)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var checkActivation = await client.Zones.CheckActivationAsync(zone.Id);

            checkActivation.Result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task TestPurgeAllFilesAsync()
        {
            var zone = ZoneTestData.Zones.First();
            var expected = new Zone { Id = zone.Id };

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{ZoneEndpoints.PurgeCache}").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(expected)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var purge = await client.Zones.PurgeAllFilesAsync(zone.Id, true);

            purge.Result.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public async Task TestPurgeFilesWithStringListAsync()
        {
            var zone = ZoneTestData.Zones.First();
            var files = CachePurgeFileTestData.CachePurgeFiles;
            var expected = new Zone { Id = zone.Id };

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{ZoneEndpoints.PurgeCache}").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(expected)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var purge = await client.Zones.PurgeFilesAsync(zone.Id, files.Select(x => x.Url));

            purge.Result.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public async Task TestPurgeFilesAsync()
        {
            var zone = ZoneTestData.Zones.First();
            var files = CachePurgeFileTestData.CachePurgeFiles;
            var expected = new Zone { Id = zone.Id };

            _wireMockServer
                .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{ZoneEndpoints.PurgeCache}").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(expected)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var purge = await client.Zones.PurgeFilesAsync(zone.Id, files);

            purge.Result.Should().BeEquivalentTo(expected);
        }
    }
}
