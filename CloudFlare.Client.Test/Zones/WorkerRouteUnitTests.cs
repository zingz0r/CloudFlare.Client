using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Zones.WorkerRoute;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Test.Helpers;
using CloudFlare.Client.Test.TestData;
using FluentAssertions;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace CloudFlare.Client.Test.Zones;

public class WorkerRouteUnitTests
{
    private readonly WireMockServer _wireMockServer;
    private readonly ConnectionInfo _connectionInfo;

    public WorkerRouteUnitTests()
    {
        _wireMockServer = WireMockServer.Start();
        _connectionInfo = new WireMockConnection(_wireMockServer.Urls.First()).ConnectionInfo;
    }

    [Fact]
    public async Task TestCreateWorkerRouteAsync()
    {
        var zone = ZoneTestData.Zones.First();
        var workerRoute = WorkerRouteTestData.WorkerRoutes.First();
        var newWorkerRoute = new NewWorkerRoute
        {
            Script = workerRoute.Script,
            Pattern = workerRoute.Pattern
        };

        _wireMockServer
            .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{WorkerRouteEndpoints.Base}").UsingPost())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(workerRoute)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var created = await client.Zones.WorkerRoutes.AddAsync(zone.Id, newWorkerRoute);

        created.Result.Should().BeEquivalentTo(workerRoute);
    }

    [Fact]
    public async Task TestGetWorkerRoutesAsync()
    {
        var zone = ZoneTestData.Zones.First();

        _wireMockServer
            .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{WorkerRouteEndpoints.Base}").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(WorkerRouteTestData.WorkerRoutes)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var routes = await client.Zones.WorkerRoutes.GetAsync(zone.Id);

        routes.Result.Should().BeEquivalentTo(WorkerRouteTestData.WorkerRoutes);
    }

    [Fact]
    public async Task TestGetWorkerRouteDetailsAsync()
    {
        var zone = ZoneTestData.Zones.First();
        var workerRoute = WorkerRouteTestData.WorkerRoutes.First();

        _wireMockServer
            .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{WorkerRouteEndpoints.Base}/{workerRoute.Id}").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(workerRoute)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var routeDetails = await client.Zones.WorkerRoutes.GetDetailsAsync(zone.Id, workerRoute.Id);

        routeDetails.Result.Should().BeEquivalentTo(workerRoute);
    }

    [Fact]
    public async Task TestUpdateWorkerRouteAsync()
    {
        var zone = ZoneTestData.Zones.First();
        var workerRoute = WorkerRouteTestData.WorkerRoutes.First();
        var modified = new ModifiedWorkerRoute
        {
            Pattern = "www.example.net/*"
        };

        _wireMockServer
            .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{WorkerRouteEndpoints.Base}/{workerRoute.Id}").UsingPut())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(x =>
                {
                    var body = JsonConvert.DeserializeObject<ModifiedWorkerRoute>(x.Body);
                    var response = WorkerRouteTestData.WorkerRoutes.First(y => y.Id == x.PathSegments[4]).DeepClone();
                    response.Pattern = body.Pattern;

                    return WireMockResponseHelper.CreateTestResponse(response);
                }));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var update = await client.Zones.WorkerRoutes.UpdateAsync(zone.Id, workerRoute.Id, modified);

        update.Result.Should().BeEquivalentTo(workerRoute, opt => opt.Excluding(x => x.Pattern));
        update.Result.Pattern.Should().BeEquivalentTo(modified.Pattern);
    }

    [Fact]
    public async Task TestDeleteWorkerRouteAsync()
    {
        var zone = ZoneTestData.Zones.First();
        var workerRoute = WorkerRouteTestData.WorkerRoutes.First();
        var expected = new WorkerRoute { Id = workerRoute.Id };

        _wireMockServer
            .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{WorkerRouteEndpoints.Base}/{workerRoute.Id}").UsingDelete())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(expected)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var delete = await client.Zones.WorkerRoutes.DeleteAsync(zone.Id, workerRoute.Id);

        delete.Result.Should().BeEquivalentTo(expected);
    }

}
