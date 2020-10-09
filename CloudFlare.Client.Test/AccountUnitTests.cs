using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.FactAttributes;
using CloudFlare.Client.Test.TheoryAttributes;
using Xunit;

namespace CloudFlare.Client.Test
{
    public class AccountUnitTests
    {
        [IgnoreOnEmptyCredentialsTheory]
        [InlineData(0, null, null)]
        [InlineData(null, 100, null)]
        [InlineData(null, null, OrderType.Asc)]
        [InlineData(null, null, OrderType.Desc)]
        [InlineData(null, null, null)]
        public async Task TestGetAccountsAsync(int? page, int? perPage, OrderType? order)
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.GetAccountsAsync(page, perPage, order);

            Assert.NotNull(accounts);
            Assert.True(accounts.Success);
            if (accounts.Errors != null)
            {
                Assert.Empty(accounts.Errors);
            }
        }

        [IgnoreOnEmptyCredentialsFact]
        public async Task TestGetAccountDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.GetAccountsAsync();
            var accountDetails = await client.GetAccountDetailsAsync(accounts.Result.First().Id);

            Assert.NotNull(accountDetails);
            Assert.True(accountDetails.Success);
            if (accountDetails.Errors != null)
            {
                Assert.Empty(accountDetails.Errors);
            }
        }

        [IgnoreOnEmptyCredentialsFact]
        public async Task UpdateAccountAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.GetAccountsAsync();
            var updatedAccount = await client.UpdateAccountAsync(accounts.Result.First().Id, accounts.Result.First().Name);

            Assert.NotNull(updatedAccount);
            Assert.True(updatedAccount.Success);
            if (updatedAccount.Errors != null)
            {
                Assert.Empty(updatedAccount.Errors);
            }
        }
    }
}
