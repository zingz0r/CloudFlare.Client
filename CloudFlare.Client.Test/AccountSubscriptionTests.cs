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
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var accounts = client.GetAccountsAsync().Result;
                var roles = client.GetAccountSubscriptionsAsync(accounts.Result.First().Id).Result;

                Assert.NotNull(roles);
                Assert.Empty(roles.Errors);
                Assert.True(roles.Success);
            }
        }
    }
}