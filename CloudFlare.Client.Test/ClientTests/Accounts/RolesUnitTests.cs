using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.ClientTests.Accounts
{
    public class RolesUnitTests
    {
        [Fact]
        public async Task TestGetRolesAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.Accounts.GetAsync();
            var roles = await client.Accounts.Roles.GetAsync(accounts.Result.First().Id);

            roles.Should().NotBeNull();
            roles.Success.Should().BeTrue();
            roles.Errors?.Should().BeEmpty();
        }

        [Fact]
        public async Task TestGetRoleDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.Accounts.GetAsync();
            var roles = await client.Accounts.Roles.GetAsync(accounts.Result.First().Id);
            var roleDetails = client.Accounts.Roles.GetDetailsAsync(accounts.Result.First().Id, roles.Result.First().Id).Result;

            roleDetails.Should().NotBeNull();
            roleDetails.Success.Should().BeTrue();
            roleDetails.Errors?.Should().BeEmpty();
        }
    }
}
