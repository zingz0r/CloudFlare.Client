using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts.Roles;
using CloudFlare.Client.Api.Memberships;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Users;
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

namespace CloudFlare.Client.Test.Accounts
{
    public class MembershipUnitTests
    {
        private readonly WireMockServer _wireMockServer;
        private readonly ConnectionInfo _connectionInfo;

        public MembershipUnitTests()
        {
            _wireMockServer = WireMockServer.Start();
            _connectionInfo = new WireMockConnection(_wireMockServer.Urls.First()).ConnectionInfo;
        }

        [Fact]
        public async Task TestGetAccountMembersAsync()
        {
            var accountId = AccountTestData.Accounts.First().Id;

            _wireMockServer
                .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Members}").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(AccountsMembershipTestData.Memberships)));

            using var client = new CloudFlareClient(_connectionInfo);

            var accountMembers = await client.Accounts.Memberships.GetAsync(accountId);

            accountMembers.Should().NotBeNull();
            accountMembers.Success.Should().BeTrue();
            accountMembers.Errors?.Should().BeEmpty();
        }

        [Fact]
        public async Task TestGetAccountMemberDetailsAsync()
        {
            var accountId = AccountTestData.Accounts.First().Id;
            var membership = AccountsMembershipTestData.Memberships.First();

            _wireMockServer
                .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Members}/{membership.Id}").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(membership)));

            using var client = new CloudFlareClient(_connectionInfo);

            var accountMemberDetails = await client.Accounts.Memberships.GetDetailsAsync(accountId, membership.Id);

            accountMemberDetails.Result.Should().BeEquivalentTo(membership);
        }

        [Fact]
        public async Task TestAddAccountMemberAsync()
        {
            var accountId = AccountTestData.Accounts.First().Id;
            var membership = AccountsMembershipTestData.Memberships.First();

            _wireMockServer
                .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Members}").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(membership)));

            using var client = new CloudFlareClient(_connectionInfo);

            var addedAccountMember = await client.Accounts.Memberships.AddAsync(accountId, membership.Entity.Email, membership.Status, membership.Roles);

            addedAccountMember.Result.Should().BeEquivalentTo(membership);
        }

        [Fact]
        public async Task TestDeleteAccountMemberAsync()
        {
            var accountId = AccountTestData.Accounts.First().Id;
            var membership = AccountsMembershipTestData.Memberships.First();
            var expected = new Membership<User, Role> { Id = membership.Id };

            _wireMockServer
                .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Members}/{membership.Id}").UsingDelete())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(expected)));

            using var client = new CloudFlareClient(_connectionInfo);

            var deletedAccountMember = await client.Accounts.Memberships.DeleteAsync(accountId, membership.Id);

            deletedAccountMember.Result.Should().BeEquivalentTo(expected);
        }


        [Fact]
        public async Task TestUpdateAccountMemberAsync()
        {
            var accountId = AccountTestData.Accounts.First().Id;
            var membership = AccountsMembershipTestData.Memberships.First();
            var expected = new AdditionalMembershipSettings<User>
            {
                Code = "testCode",
                Status = MembershipStatus.Rejected
            };

            _wireMockServer
                .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Members}/{membership.Id}").UsingPut())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(x =>
                    {
                        var body = JsonConvert.DeserializeObject<Membership<User, Role>>(x.Body);
                        var mbr = AccountsMembershipTestData.Memberships.First(y => y.Id == x.PathSegments[3]).DeepClone();

                        mbr.Code = body.Code;
                        mbr.Status = body.Status;
                        return WireMockResponseHelper.CreateTestResponse(mbr);
                    }));

            using var client = new CloudFlareClient(new WireMockConnection(_wireMockServer.Urls.FirstOrDefault()).ConnectionInfo);

            var updatedMember = await client.Accounts.Memberships.UpdateAsync(accountId, membership.Id, membership.Roles, expected);

            updatedMember.Result.Code.Should().Be(expected.Code);
            updatedMember.Result.Status.Should().Be(expected.Status);
            updatedMember.Result.Should().BeEquivalentTo(membership, opt => opt.Excluding(x => x.Code).Excluding(x => x.Status));
        }
    }
}