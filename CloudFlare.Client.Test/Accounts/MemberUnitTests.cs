using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts.Member;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Parameters.Endpoints;
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

namespace CloudFlare.Client.Test.Accounts;

public class MemberUnitTests
{
    private readonly WireMockServer _wireMockServer;
    private readonly ConnectionInfo _connectionInfo;

    public MemberUnitTests()
    {
        _wireMockServer = WireMockServer.Start();
        _connectionInfo = new WireMockConnection(_wireMockServer.Urls.First()).ConnectionInfo;
    }

    [Fact]
    public async Task TestGetAccountMembersAsync()
    {
        var displayOptions = new DisplayOptions { Page = 1, PerPage = 20, Order = OrderType.Asc };

        var accountId = AccountTestData.Accounts.First().Id;

        _wireMockServer
            .Given(Request.Create()
                .WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Members}/")
                .WithParam(Filtering.Page)
                .WithParam(Filtering.PerPage)
                .WithParam(Filtering.Direction)
                .UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(AccountMembershipTestData.Members)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var accountMembers = await client.Accounts.Members.GetAsync(accountId, displayOptions);

        accountMembers.Result.Should().BeEquivalentTo(AccountMembershipTestData.Members);
    }

    [Fact]
    public async Task TestGetAccountMemberDetailsAsync()
    {
        var accountId = AccountTestData.Accounts.First().Id;
        var membership = AccountMembershipTestData.Members.First();

        _wireMockServer
            .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Members}/{membership.Id}").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(membership)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var accountMemberDetails = await client.Accounts.Members.GetDetailsAsync(accountId, membership.Id);

        accountMemberDetails.Result.Should().BeEquivalentTo(membership);
    }

    [Fact]
    public async Task TestAddAccountMemberAsync()
    {
        var accountId = AccountTestData.Accounts.First().Id;
        var membership = AccountMembershipTestData.Members.First();
        var newMember = new NewMember
        {
            EmailAddress = membership.User.Email,
            Roles = membership.Roles,
            Status = membership.Status
        };

        _wireMockServer
            .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Members}").UsingPost())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(membership)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var addedAccountMember = await client.Accounts.Members.AddAsync(accountId, newMember);

        addedAccountMember.Result.Should().BeEquivalentTo(membership);
    }

    [Fact]
    public async Task TestDeleteAccountMemberAsync()
    {
        var accountId = AccountTestData.Accounts.First().Id;
        var membership = AccountMembershipTestData.Members.First();
        var expected = new Member { Id = membership.Id };

        _wireMockServer
            .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Members}/{membership.Id}").UsingDelete())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(expected)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var deletedAccountMember = await client.Accounts.Members.DeleteAsync(accountId, membership.Id);

        deletedAccountMember.Result.Should().BeEquivalentTo(expected);
    }


    [Fact]
    public async Task TestUpdateAccountMemberAsync()
    {
        var accountId = AccountTestData.Accounts.First().Id;
        var membership = AccountMembershipTestData.Members.First();

        _wireMockServer
            .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Members}/{membership.Id}").UsingPut())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(x =>
                {
                    var body = JsonConvert.DeserializeObject<Member>(x.Body);
                    var response = AccountMembershipTestData.Members.First(y => y.Id == x.PathSegments[3]).DeepClone();

                    response.Code = body.Code;
                    response.Status = body.Status;
                    return WireMockResponseHelper.CreateTestResponse(response);
                }));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var updatedMember = await client.Accounts.Members.UpdateAsync(accountId, membership);

        updatedMember.Result.Code.Should().Be(membership.Code);
        updatedMember.Result.Status.Should().Be(membership.Status);
        updatedMember.Result.Should().BeEquivalentTo(membership, opt => opt.Excluding(x => x.Code).Excluding(x => x.Status));
    }
}
