using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Users.Memberships;
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

namespace CloudFlare.Client.Test.Users
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
        public async Task TestGetUserMembershipsAsync()
        {
            _wireMockServer
                .Given(Request.Create().WithPath($"/{MembershipEndpoints.Base}").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(UserMembershipTestsData.Memberships)));

            using var client = new CloudFlareClient(_connectionInfo);

            var userMembership = await client.Users.Memberships.GetAsync();

            userMembership.Result.Should().BeEquivalentTo(UserMembershipTestsData.Memberships);
        }

        [Fact]
        public async Task TestGetUserMembershipDetailsAsync()
        {
            var membership = UserMembershipTestsData.Memberships.First();

            _wireMockServer
                .Given(Request.Create().WithPath($"/{MembershipEndpoints.Base}/{membership.Id}").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(UserMembershipTestsData.Memberships.First())));

            using var client = new CloudFlareClient(_connectionInfo);

            var userMembershipDetails = await client.Users.Memberships.GetDetailsAsync(membership.Id);

            userMembershipDetails.Result.Should().BeEquivalentTo(membership);
        }

        [Fact]
        public async Task TestUpdateUserMembershipStatusAsync()
        {
            var membership = UserMembershipTestsData.Memberships.First();

            _wireMockServer
                .Given(Request.Create().WithPath($"/{MembershipEndpoints.Base}/{membership.Id}").UsingPut())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(x =>
                    {
                        var body = JsonConvert.DeserializeObject<Membership>(x.Body);
                        var response = UserMembershipTestsData.Memberships.First(y => y.Id == x.PathSegments[1]).DeepClone();

                        response.Status = body.Status;
                        return WireMockResponseHelper.CreateTestResponse(response);
                    }));

            using var client = new CloudFlareClient(_connectionInfo);


            var updateUserMembershipStatus = await client.Users.Memberships.UpdateAsync(membership.Id, MembershipStatus.Pending);
            updateUserMembershipStatus.Result.Should().BeEquivalentTo(membership, opt => opt.Excluding(x => x.Status));
            updateUserMembershipStatus.Result.Status.Should().Be(MembershipStatus.Pending);
        }

        [Fact]
        public async Task TestDeleteUserMembershipAsync()
        {
            var membership = UserMembershipTestsData.Memberships.First();
            var expected = new Membership { Id = membership.Id };

            _wireMockServer
                .Given(Request.Create().WithPath($"/{MembershipEndpoints.Base}/{membership.Id}").UsingDelete())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(expected)));

            using var client = new CloudFlareClient(_connectionInfo);

            var deletedMembership = await client.Users.Memberships.DeleteAsync(membership.Id);

            deletedMembership.Result.Should().BeEquivalentTo(expected);
        }
    }
}