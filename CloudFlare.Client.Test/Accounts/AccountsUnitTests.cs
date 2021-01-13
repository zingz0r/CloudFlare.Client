using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Enumerators;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Accounts
{
    public class AccountsUnitTests
    {
        [Theory]
        [InlineData(0, null, null)]
        [InlineData(null, 100, null)]
        [InlineData(null, null, OrderType.Asc)]
        [InlineData(null, null, OrderType.Desc)]
        [InlineData(null, null, null)]
        public async Task TestGetAccountsAsync(int? page, int? perPage, OrderType? order)
        {
            var displayOptions = new DisplayOptions { Page = page, PerPage = perPage, Order = order };

            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.Accounts.GetAsync(displayOptions);

            accounts.Should().NotBeNull();
            accounts.Success.Should().BeTrue();
            accounts.Errors?.Should().BeEmpty();
        }

        [Fact]
        public async Task TestGetAccountDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.Accounts.GetAsync();
            var accountDetails = await client.Accounts.GetDetailsAsync(accounts.Result.First().Id);

            accountDetails.Should().NotBeNull();
            accountDetails.Success.Should().BeTrue();
            accountDetails.Errors?.Should().BeEmpty();
        }

        [Fact]
        public async Task UpdateAccountAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.Accounts.GetAsync();
            var updatedAccount = await client.Accounts.UpdateAsync(accounts.Result.First().Id, accounts.Result.First().Name);

            updatedAccount.Should().NotBeNull();
            updatedAccount.Success.Should().BeTrue();
            updatedAccount.Errors?.Should().BeEmpty();
        }
    }
}
