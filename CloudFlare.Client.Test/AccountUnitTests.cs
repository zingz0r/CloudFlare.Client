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

                var accountsPage = client.GetAccountsAsync(0).Result;
                Assert.NotNull(accountsPage);
                Assert.Empty(accountsPage.Errors);
                Assert.True(accountsPage.Success);

                var accountsPagePerPage = client.GetAccountsAsync(0, 100).Result;
                Assert.NotNull(accountsPagePerPage);
                Assert.Empty(accountsPagePerPage.Errors);
                Assert.True(accountsPagePerPage.Success);

                var accountsPagePerPageOrderDesc = client.GetAccountsAsync(0, 100, OrderType.Desc).Result;
                Assert.NotNull(accountsPagePerPageOrderDesc);
                Assert.Empty(accountsPagePerPageOrderDesc.Errors);
                Assert.True(accountsPagePerPageOrderDesc.Success);

                var accountsPagePerPageOrderAsc = client.GetAccountsAsync(0, 100, OrderType.Asc).Result;
                Assert.NotNull(accountsPagePerPageOrderAsc);
                Assert.Empty(accountsPagePerPageOrderAsc.Errors);
                Assert.True(accountsPagePerPageOrderAsc.Success);
            }
        }
    }
}
