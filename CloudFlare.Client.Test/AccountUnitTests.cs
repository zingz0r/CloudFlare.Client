using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.FactAttributes;
using Xunit;

namespace CloudFlare.Client.Test
{
    public class AccountUnitTests
    {
        [IgnoreOnEmptyCredentialsFact]
        private void TestGetAccountsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Authentication);

            var accounts = client.GetAccountsAsync().Result;
            Assert.NotNull(accounts);
            Assert.Empty(accounts.Errors);

            accounts = client.GetAccountsAsync(0).Result;
            Assert.NotNull(accounts);
            Assert.Empty(accounts.Errors);

            accounts = client.GetAccountsAsync(0, 100).Result;
            Assert.NotNull(accounts);
            Assert.Empty(accounts.Errors);

            accounts = client.GetAccountsAsync(0, 100, OrderType.Desc).Result;
            Assert.NotNull(accounts);
            Assert.Empty(accounts.Errors);

            accounts = client.GetAccountsAsync(0, 100, OrderType.Asc).Result;
            Assert.NotNull(accounts);
            Assert.Empty(accounts.Errors);
        }
    }
}
