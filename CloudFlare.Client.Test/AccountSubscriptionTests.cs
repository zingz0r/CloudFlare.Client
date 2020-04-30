using System.Linq;
using CloudFlare.Client.Test.FactAttributes;
using Xunit;

namespace CloudFlare.Client.Test
{
    public static class AccountSubscriptionTests
    {
        [IgnoreOnEmptyCredentialsFact]
        public static void TestGetRolesAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = client.GetAccountsAsync().Result;
            var subscriptions = client.GetAccountSubscriptionsAsync(accounts.Result.First().Id).Result;

            Assert.NotNull(subscriptions);
            Assert.True(subscriptions.Success);
            if (subscriptions.Errors != null)
            {
                Assert.Empty(subscriptions.Errors);
            }
        }
    }
}
