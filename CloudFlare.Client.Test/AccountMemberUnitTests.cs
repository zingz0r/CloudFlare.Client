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

                var accountMember = client.GetAccountMembersAsync(accounts.Result.First().Id).Result;
                Assert.NotNull(accountMember);
                Assert.True(accountMember.Success);
                Assert.Empty(accountMember.Errors);

                var accountMemberPage = client.GetAccountMembersAsync(accounts.Result.First().Id, 0).Result;
                Assert.NotNull(accountMemberPage);
                Assert.Empty(accountMemberPage.Errors);
                Assert.True(accountMemberPage.Success);

                var accountMemberPagePerPage = client.GetAccountMembersAsync(accounts.Result.First().Id, 0, 100).Result;
                Assert.NotNull(accountMemberPagePerPage);
                Assert.Empty(accountMemberPagePerPage.Errors);
                Assert.True(accountMemberPagePerPage.Success);

                var accountMemberPagePerPageOrderDesc = client.GetAccountMembersAsync(accounts.Result.First().Id, 0, 100, OrderType.Desc).Result;
                Assert.NotNull(accountMemberPagePerPageOrderDesc);
                Assert.Empty(accountMemberPagePerPageOrderDesc.Errors);
                Assert.True(accountMemberPagePerPageOrderDesc.Success);

                var accountMemberPagePerPageOrderAsc = client.GetAccountMembersAsync(accounts.Result.First().Id, 0, 100, OrderType.Asc).Result;
                Assert.NotNull(accountMemberPagePerPageOrderAsc);
                Assert.Empty(accountMemberPagePerPageOrderAsc.Errors);
                Assert.True(accountMemberPagePerPageOrderAsc.Success);
            }
        }
    }
}