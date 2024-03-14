using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts.TurnstileWidgets;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.Helpers;
using CloudFlare.Client.Test.TestData;
using FluentAssertions;
using Force.DeepCloner;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace CloudFlare.Client.Test.Accounts
{
    public class TurnstileWidgetsTests
    {
        private readonly WireMockServer _wireMockServer;
        private readonly ConnectionInfo _connectionInfo;

        public TurnstileWidgetsTests()
        {
            _wireMockServer = WireMockServer.Start();
            _connectionInfo = new WireMockConnection(_wireMockServer.Urls.First()).ConnectionInfo;
        }

        [Fact]
        public async Task TestAddAccountTurnstileWidgetsAsync()
        {
            var accountId = AccountTestData.Accounts.First().Id;
            var turnstileWidget = TurnstileWidgetTestData.TurnstileWidgets.First();
            var newTurnstileWidget = new NewTurnstileWidget()
            {
                BotFightMode = turnstileWidget.BotFightMode,
                Name = turnstileWidget.Name,
                ClearanceLevel = turnstileWidget.ClearanceLevel,
                Domains = turnstileWidget.Domains,
                Mode = turnstileWidget.Mode,
                OffLabel = turnstileWidget.OffLabel,
                Region = turnstileWidget.Region
            };

            _wireMockServer
                .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.TurnstileWidgets}").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(turnstileWidget)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var addTurnstileWidget = await client.Accounts.TurnStileWidgets.AddAsync(accountId, newTurnstileWidget);

            addTurnstileWidget.Result.Should().BeEquivalentTo(turnstileWidget);
        }

        [Fact]
        public async Task TestGetAccountTurnstileWidgetsTestsAsync()
        {
            var accountId = AccountTestData.Accounts.First().Id;

            _wireMockServer
                .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.TurnstileWidgets}").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(TurnstileWidgetTestData.TurnstileWidgets)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var turnstileWidgets = await client.Accounts.TurnStileWidgets.GetAsync(accountId);

            turnstileWidgets.Result.Should().BeEquivalentTo(TurnstileWidgetTestData.TurnstileWidgets);
        }


        [Fact]
        public async Task TestGetAccountSubscriptionDetailsAsync()
        {
            var accountId = AccountTestData.Accounts.First().Id;
            var turnstileWidget = TurnstileWidgetTestData.TurnstileWidgets.First();

            _wireMockServer
                .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.TurnstileWidgets}/{turnstileWidget.Id}").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(turnstileWidget)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var turnstileWidgetDetails = await client.Accounts.TurnStileWidgets.GetDetailsAsync(accountId, turnstileWidget.Id);

            turnstileWidgetDetails.Result.Should().BeEquivalentTo(turnstileWidget);
        }

        [Fact]
        public async Task TestModifyAccountTurnstileWidgetsAsync()
        {
            var accountId = AccountTestData.Accounts.First().Id;
            var turnstileWidget = TurnstileWidgetTestData.TurnstileWidgets.First().DeepClone();
            turnstileWidget.Mode = WidgetMode.NonInteractive;

            _wireMockServer
                .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.TurnstileWidgets}/{turnstileWidget.Id}").UsingPut())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(x =>
                    {
                        var body = JsonSerializer.Deserialize<TurnstileWidget>(x.Body!, CloudFlareJsonSerializerContext.Default.TurnstileWidget);
                        var response = TurnstileWidgetTestData.TurnstileWidgets.First().DeepClone();
                        response.Mode = body.Mode;

                        return WireMockResponseHelper.CreateTestResponse(response);
                    }));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var modifiedTurnstileWidget = await client.Accounts.TurnStileWidgets.UpdateAsync(accountId, turnstileWidget);

            modifiedTurnstileWidget.Result.Should().BeEquivalentTo(TurnstileWidgetTestData.TurnstileWidgets.First(), opt => opt.Excluding(x => x.Mode));
            modifiedTurnstileWidget.Result.Mode.Should().Be(WidgetMode.NonInteractive);
        }

        [Fact]
        public async Task TestDeleteAccountTurnstileWidgetsAsync()
        {
            var accountId = AccountTestData.Accounts.First().Id;
            var turnstileWidget = TurnstileWidgetTestData.TurnstileWidgets.First();

            _wireMockServer
                .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.TurnstileWidgets}/{turnstileWidget.Id}").UsingDelete())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(turnstileWidget)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var deletedTurnstileWidget = await client.Accounts.TurnStileWidgets.DeleteAsync(accountId, turnstileWidget.Id);

            deletedTurnstileWidget.Result.Should().BeEquivalentTo(turnstileWidget);
        }

        [Fact]
        public async Task TestRotateAccountTurnstileWidgetSecretAsync()
        {
            var accountId = AccountTestData.Accounts.First().Id;
            var turnstileWidget = TurnstileWidgetTestData.TurnstileWidgets.First();

            _wireMockServer
                .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.TurnstileWidgets}/{turnstileWidget.Id}/{AccountEndpoints.RotateSecret}").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(x =>
                    {
                        var response = TurnstileWidgetTestData.TurnstileWidgets.First().DeepClone();
                        response.Secret = "0x4AAF00AAAdABn0R22H12uz7sh92kja2hd";

                        return WireMockResponseHelper.CreateTestResponse(response);
                    }));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var rotatedSecretTurnstileWidget = await client.Accounts.TurnStileWidgets.RotateSecretAsync(accountId, turnstileWidget.Id, false);

            rotatedSecretTurnstileWidget.Result.Should().BeEquivalentTo(TurnstileWidgetTestData.TurnstileWidgets.First(), opt => opt.Excluding(x => x.Secret));
            rotatedSecretTurnstileWidget.Result.Secret.Should().NotBeEquivalentTo(turnstileWidget.Secret);
        }
    }
}