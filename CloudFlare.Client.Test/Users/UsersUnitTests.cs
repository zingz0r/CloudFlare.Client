using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Users;
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

namespace CloudFlare.Client.Test.Users
{
    public class UsersUnitTests
    {
        private readonly WireMockServer _wireMockServer;
        private readonly ConnectionInfo _connectionInfo;
        public UsersUnitTests()
        {
            _wireMockServer = WireMockServer.Start();
            _connectionInfo = new WireMockConnection(_wireMockServer.Urls.First()).ConnectionInfo;
        }

        [Fact]
        public async Task TestGetUserDetailsAsync()
        {
            var user = UserTestData.Users.First();

            _wireMockServer
                .Given(Request.Create().WithPath($"/{UserEndpoints.Base}").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(user)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var userDetails = await client.Users.GetDetailsAsync();

            userDetails.Result.Should().BeEquivalentTo(user);
        }

        [Fact]
        public async Task TestUpdateUserDetailsAsync()
        {
            var expected = UserTestData.Users.First().DeepClone();
            expected.Email = "modified@test.com";

            _wireMockServer
                .Given(Request.Create().WithPath($"/{UserEndpoints.Base}").UsingPatch())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(x =>
                    {
                        var body = JsonConvert.DeserializeObject<User>(x.Body);
                        return WireMockResponseHelper.CreateTestResponse(body);
                    }));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var updatedUser = await client.Users.UpdateAsync(expected);

            updatedUser.Result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task TestVerifyUserAsync()
        {
            var token = TokenTestData.Tokens.First();

            _wireMockServer
                .Given(Request.Create().WithPath($"/{UserEndpoints.Base}/{TokenEndpoints.Base}/{TokenEndpoints.Verify}").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(token)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);
            var verification = await client.Users.VerifyAsync();

            verification.Result.Should().BeEquivalentTo(token);
        }
    }
}