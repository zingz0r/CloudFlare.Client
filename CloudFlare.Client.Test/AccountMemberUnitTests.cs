using System.Linq;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.FactAttributes;
using Xunit;

namespace CloudFlare.Client.Test
{
    public class AccountMemberUnitTests
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

                var accountMember = client.GetAccountMembersAsync(accounts.Result.First().Id, null, null, null).Result;
                Assert.NotNull(accountMember);
                Assert.True(accountMember.Success);
                Assert.Empty(accountMember.Errors);
            }
        }
    }
}