using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.FactAttributes;
using Xunit;

namespace CloudFlare.Client.Test
{
    public static class AccountUnitTests
    {
        [IgnoreOnEmptyCredentialsFact]
        private static void TestGetAccountsAsync()
        {
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var accounts = client.GetAccountsAsync().Result;
                Assert.NotNull(accounts);
                Assert.Empty(accounts.Errors);
                Assert.True(accounts.Success);

                accounts = client.GetAccountsAsync(0).Result;
                Assert.NotNull(accounts);
                Assert.Empty(accounts.Errors);
                Assert.True(accounts.Success);

                accounts = client.GetAccountsAsync(0, 100).Result;
                Assert.NotNull(accounts);
                Assert.Empty(accounts.Errors);
                Assert.True(accounts.Success);

                accounts = client.GetAccountsAsync(0, 100, OrderType.Desc).Result;
                Assert.NotNull(accounts);
                Assert.Empty(accounts.Errors);
                Assert.True(accounts.Success);

                accounts = client.GetAccountsAsync(0, 100, OrderType.Asc).Result;
                Assert.NotNull(accounts);
                Assert.Empty(accounts.Errors);
                Assert.True(accounts.Success);
            }
        }
    }
}
