using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Test.FactAttributes;
using Xunit;

namespace CloudFlare.Client.Test
{
    public class AccountSubscriptionTests
    {
        [IgnoreOnEmptyCredentialsFact]
        public async Task TestGetRolesAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.GetAccountsAsync();
            var subscriptions = await client.GetAccountSubscriptionsAsync(accounts.Result.First().Id);

            Assert.NotNull(subscriptions);
            Assert.True(subscriptions.Success);
            if (subscriptions.Errors != null)
            {
                Assert.Empty(subscriptions.Errors);
            }
        }
    }
}
