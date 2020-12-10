using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.ClientTests.Account
{
    public class SubscriptionTests
    {
        [Fact]
        public async Task TestGetAccountSubscriptionsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.GetAccountsAsync();
            var subscriptions = await client.GetAccountSubscriptionsAsync(accounts.Result.First().Id);

            subscriptions.Should().NotBeNull();
            subscriptions.Success.Should().BeTrue();
            subscriptions.Errors?.Should().BeEmpty();
        }
    }
}
