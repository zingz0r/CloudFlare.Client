using System.Linq;
using CloudFlare.Client.Test.FactAttributes;
using Xunit;

namespace CloudFlare.Client.Test
{
    public static class AccountRoleUnitTests
    {
        [IgnoreOnEmptyCredentialsFact]
        public static void TestGetRolesAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = client.GetAccountsAsync().Result;
            var roles = client.GetRolesAsync(accounts.Result.First().Id).Result;

            Assert.NotNull(roles);
            Assert.True(roles.Success);
            if (roles.Errors != null)
            {
                Assert.Empty(roles.Errors);
            }
        }

        [IgnoreOnEmptyCredentialsFact]
        public static void TestGetRoleDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = client.GetAccountsAsync().Result;
            var roles = client.GetRolesAsync(accounts.Result.First().Id).Result;
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
