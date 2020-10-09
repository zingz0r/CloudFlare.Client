using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Test.FactAttributes;
using Xunit;

namespace CloudFlare.Client.Test
{
    public class AccountRoleUnitTests
    {
        [IgnoreOnEmptyCredentialsFact]
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

        [IgnoreOnEmptyCredentialsFact]
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
