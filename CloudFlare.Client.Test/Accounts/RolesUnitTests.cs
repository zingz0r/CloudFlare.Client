using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Test.Helpers;
using CloudFlare.Client.Test.TestData;
using FluentAssertions;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace CloudFlare.Client.Test.Accounts;

public class RolesUnitTests
{
    private readonly WireMockServer _wireMockServer;
    private readonly ConnectionInfo _connectionInfo;

    public RolesUnitTests()
    {
        _wireMockServer = WireMockServer.Start();
        _connectionInfo = new WireMockConnection(_wireMockServer.Urls.First()).ConnectionInfo;
    }

    [Fact]
    public async Task TestGetRolesAsync()
    {
        var accountId = AccountTestData.Accounts.First().Id;
        var displayOptions = new DisplayOptions { Page = 1, PerPage = 30 };

        _wireMockServer
            .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Roles}")
                .WithParam(Filtering.Page)
                .WithParam(Filtering.PerPage)
                .UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(RoleTestData.Roles)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var roles = await client.Accounts.Roles.GetAsync(accountId, default, displayOptions);

        roles.Result.Should().BeEquivalentTo(RoleTestData.Roles);
    }

    [Fact]
    public async Task TestGetRoleDetailsAsync()
    {
        var accountId = AccountTestData.Accounts.First().Id;
        var role = RoleTestData.Roles.First();

        _wireMockServer
            .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Roles}/{role.Id}").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(role)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var roleDetails = await client.Accounts.Roles.GetDetailsAsync(accountId, role.Id);

        roleDetails.Result.Should().BeEquivalentTo(role);
    }
}