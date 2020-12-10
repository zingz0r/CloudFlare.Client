using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Enumerators;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.ClientTests.Account
{
    public class AccountUnitTests
    {
        [Theory]
        [InlineData(0, null, null)]
        [InlineData(null, 100, null)]
        [InlineData(null, null, OrderType.Asc)]
        [InlineData(null, null, OrderType.Desc)]
        [InlineData(null, null, null)]
        public async Task TestGetAccountsAsync(int? page, int? perPage, OrderType? order)
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.GetAccountsAsync(page, perPage, order);

            accounts.Should().NotBeNull();
            accounts.Success.Should().BeTrue();
            accounts.Errors?.Should().BeEmpty();
        }

        [Fact]
        public async Task TestGetAccountDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.GetAccountsAsync();
            var accountDetails = await client.GetAccountDetailsAsync(accounts.Result.First().Id);

            accountDetails.Should().NotBeNull();
            accountDetails.Success.Should().BeTrue();
            accountDetails.Errors?.Should().BeEmpty();
        }

        [Fact]
        public async Task UpdateAccountAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.GetAccountsAsync();
            var updatedAccount = await client.UpdateAccountAsync(accounts.Result.First().Id, accounts.Result.First().Name);

            updatedAccount.Should().NotBeNull();
            updatedAccount.Success.Should().BeTrue();
            updatedAccount.Errors?.Should().BeEmpty();
        }
    }
}
