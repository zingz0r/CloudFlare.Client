using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Accounts
{
    public class SubscriptionsTests
    {
        [Fact]
        public async Task TestGetAccountSubscriptionsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.Accounts.GetAsync();
            var subscriptions = await client.Accounts.Subscriptions.GetAsync(accounts.Result.First().Id);

            subscriptions.Should().NotBeNull();
            subscriptions.Success.Should().BeTrue();
            subscriptions.Errors?.Should().BeEmpty();
        }
    }
}
