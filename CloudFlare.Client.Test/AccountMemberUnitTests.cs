using System.Collections.Generic;
using System.Linq;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;
using CloudFlare.Client.Test.FactAttributes;
using CloudFlare.Client.Test.TheoryAttributes;
using Xunit;

namespace CloudFlare.Client.Test
{
    public static class AccountMemberUnitTests
    {
        [IgnoreOnEmptyCredentialsTheory]
        [InlineData(0, 100, OrderType.Desc)]
        [InlineData(0, 100, OrderType.Asc)]
        [InlineData(0, 100, null)]
        [InlineData(0, null, null)]
        [InlineData(null, null, null)]
        public static void TestGetAccountMembersAsync(int? page, int? perPage, OrderType? order)
        {
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var accounts = client.GetAccountsAsync().Result;

                Assert.NotNull(accounts);
                Assert.Empty(accounts.Errors);
                Assert.True(accounts.Success);

                var accountMembers = client.GetAccountMembersAsync(accounts.Result.First().Id, page, perPage, order).Result;

                Assert.NotNull(accountMembers);
                Assert.Empty(accountMembers.Errors);
                Assert.True(accountMembers.Success);
            }
        }

        [IgnoreOnEmptyCredentialsTheory]
        //[InlineData("test@email.com", null, AddMembershipStatus.Accepted)]
        [InlineData("test@email.com", null, AddMembershipStatus.Pending)]
        public static void TestAddAccountMemberAsync(string emailAddress, IEnumerable<AccountRole> roles, AddMembershipStatus? status)
        {
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var addedAccountMember = client.AddAccountMemberAsync(emailAddress, roles, status).Result;

                Assert.NotNull(addedAccountMember);
                Assert.Empty(addedAccountMember.Errors);
                Assert.True(addedAccountMember.Success);
            }
        }
    }
}