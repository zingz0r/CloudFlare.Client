using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.ClientTests.Account
{
    public class RoleUnitTests
    {
        [Fact]
        public async Task TestGetRolesAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.GetAccountsAsync();
            var roles = await client.GetRolesAsync(accounts.Result.First().Id);

            roles.Should().NotBeNull();
            roles.Success.Should().BeTrue();
            roles.Errors?.Should().BeEmpty();
        }

        [Fact]
        public async Task TestGetRoleDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.GetAccountsAsync();
            var roles = await client.GetRolesAsync(accounts.Result.First().Id);
            var roleDetails = client.GetRoleDetailsAsync(accounts.Result.First().Id, roles.Result.First().Id).Result;

            roleDetails.Should().NotBeNull();
            roleDetails.Success.Should().BeTrue();
            roleDetails.Errors?.Should().BeEmpty();
        }
    }
}
