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
                var accountMembers = client.GetAccountMembersAsync(accounts.Result.First().Id, page, perPage, order).Result;

                Assert.NotNull(accountMembers);
                Assert.Empty(accountMembers.Errors);
                Assert.True(accountMembers.Success);
            }
        }

        [IgnoreOnEmptyCredentialsTheory]
        [InlineData("accepted@notexistingemail.lan", AddMembershipStatus.Accepted)]
        [InlineData("pending@notexistingemail.lan", AddMembershipStatus.Pending)]
        public static void TestAddAccountMemberAsync(string emailAddress, AddMembershipStatus? status)
        {
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var accounts = client.GetAccountsAsync().Result;
                var roles = client.GetRolesAsync(accounts.Result.First().Id).Result;
                var addedAccountMember = client.AddAccountMemberAsync(accounts.Result.First().Id, emailAddress, roles.Result, status).Result;

                Assert.NotNull(addedAccountMember);

                if (!addedAccountMember.Errors.Select(x => x.Code).Contains(429))
                {
                    Assert.Empty(addedAccountMember.Errors);
                    Assert.True(addedAccountMember.Success);
                }

                Assert.True(false, "TODO Delete");
            }
        }

        [IgnoreOnEmptyCredentialsFact]
        public static void TestGetAccountMemberDetailsAsync()
        {
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var accounts = client.GetAccountsAsync().Result;
                var accountMembers = client.GetAccountMembersAsync(accounts.Result.First().Id).Result;
                var accountMemberDetails = client.GetAccountMemberDetailsAsync(accounts.Result.First().Id, accountMembers.Result.First().Id).Result;

                Assert.NotNull(accountMemberDetails);
                Assert.Empty(accountMemberDetails.Errors);
                Assert.True(accountMemberDetails.Success);
            }
        }
    }
}