using System;
using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts.Subscriptions;
using CloudFlare.Client.Api.Parameters.Endpoints;
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

namespace CloudFlare.Client.Test.Accounts;

public class SubscriptionsTests
{
    private readonly WireMockServer _wireMockServer;
    private readonly ConnectionInfo _connectionInfo;

    public SubscriptionsTests()
    {
        _wireMockServer = WireMockServer.Start();
        _connectionInfo = new WireMockConnection(_wireMockServer.Urls.First()).ConnectionInfo;
    }

    [Fact]
    public async Task TestAddAccountSubscriptionsAsync()
    {
        var accountId = AccountTestData.Accounts.First().Id;
        var subscription = SubscriptionTestData.Subscriptions.First();

        _wireMockServer
            .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Subscriptions}").UsingPost())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(subscription)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var addSubscription = await client.Accounts.Subscriptions.AddAsync(accountId, subscription);

        addSubscription.Result.Should().BeEquivalentTo(subscription);
    }

    [Fact]
    public async Task TestGetAccountSubscriptionsAsync()
    {
        var accountId = AccountTestData.Accounts.First().Id;

        _wireMockServer
            .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Subscriptions}").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(SubscriptionTestData.Subscriptions)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var subscriptions = await client.Accounts.Subscriptions.GetAsync(accountId);

        subscriptions.Result.Should().BeEquivalentTo(SubscriptionTestData.Subscriptions);
    }

    [Fact]
    public async Task TestModifyAccountSubscriptionsAsync()
    {
        var accountId = AccountTestData.Accounts.First().Id;
        var subscription = SubscriptionTestData.Subscriptions.First().DeepClone();
        subscription.Price = long.MaxValue;

        _wireMockServer
            .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Subscriptions}/{subscription.Id}").UsingPost())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(x =>
                {
                    var body = JsonConvert.DeserializeObject<Subscription>(x.Body ?? throw new InvalidOperationException());
                    var response = SubscriptionTestData.Subscriptions.First().DeepClone();
                    response.Price = body.Price;

                    return WireMockResponseHelper.CreateTestResponse(response);
                }));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var modifiedSubscription = await client.Accounts.Subscriptions.UpdateAsync(accountId, subscription);

        modifiedSubscription.Result.Should().BeEquivalentTo(SubscriptionTestData.Subscriptions.First(), opt => opt.Excluding(x => x.Price));
        modifiedSubscription.Result.Price.Should().Be(long.MaxValue);
    }

    [Fact]
    public async Task TestDeleteAccountSubscriptionsAsync()
    {
        var accountId = AccountTestData.Accounts.First().Id;
        var subscription = SubscriptionTestData.Subscriptions.First();
        var expected = new DeletedSubscription { SubscriptionId = subscription.Id };

        _wireMockServer
            .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Subscriptions}/{subscription.Id}").UsingDelete())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(expected)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var deletedSubscription = await client.Accounts.Subscriptions.DeleteAsync(accountId, subscription.Id);

        deletedSubscription.Result.Should().BeEquivalentTo(expected);
    }
}
