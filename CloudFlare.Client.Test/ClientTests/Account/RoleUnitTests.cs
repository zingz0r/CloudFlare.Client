using System.Linq;
using System.Threading.Tasks;
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

            Assert.NotNull(roles);
            Assert.True(roles.Success);
            if (roles.Errors != null)
            {
                Assert.Empty(roles.Errors);
            }
        }

        [Fact]
        public async Task TestGetRoleDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.GetAccountsAsync();
            var roles = await client.GetRolesAsync(accounts.Result.First().Id);
            var roleDetails = client.GetRoleDetailsAsync(accounts.Result.First().Id, roles.Result.First().Id).Result;

            Assert.NotNull(roleDetails);
            Assert.True(roleDetails.Success);
            if (roleDetails.Errors != null)
            {
                Assert.Empty(roleDetails.Errors);
            }
        }
    }
}
