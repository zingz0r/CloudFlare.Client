using System.Linq;
using CloudFlare.Client.Test.FactAttributes;
using Xunit;

namespace CloudFlare.Client.Test
{
    public static class RoleUnitTests
    {
        [IgnoreOnEmptyCredentialsFact]
        public static void TestGetRolesAsync()
        {
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var accounts = client.GetAccountsAsync().Result;
                var roles = client.GetRolesAsync(accounts.Result.First().Id).Result;

                Assert.NotNull(roles);
                Assert.Empty(roles.Errors);
                Assert.True(roles.Success);
            }
        }

        [IgnoreOnEmptyCredentialsFact]
        public static void TestGetRoleDetailsAsync()
        {
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var accounts = client.GetAccountsAsync().Result;
                var roles = client.GetRolesAsync(accounts.Result.First().Id).Result;
                var roleDetails = client.GetRoleDetailsAsync(accounts.Result.First().Id, roles.Result.First().Id).Result;

                Assert.NotNull(roleDetails);
                Assert.Empty(roleDetails.Errors);
                Assert.True(roleDetails.Success);
            }
        }
    }
}
