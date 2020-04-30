using System.Collections.Generic;
using System.Linq;
using CloudFlare.Client.Enumerators;
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
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            
            var accounts = client.GetAccountsAsync().Result;
            var accountMembers = client.GetAccountMembersAsync(accounts.Result.First().Id, page, perPage, order).Result;

            Assert.NotNull(accountMembers);
            Assert.True(accountMembers.Success);

            if (accountMembers.Errors != null)
            {
                Assert.Empty(accountMembers.Errors);
            }

        }

        [IgnoreOnEmptyCredentialsTheory]
        [InlineData("test@notexistingemail.lan")]
        public static void TestAddAndDeleteAccountMemberAsync(string emailAddress)
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = client.GetAccountsAsync().Result;
            var roles = client.GetRolesAsync(accounts.Result.First().Id).Result;
            var addedAccountMember = client.AddAccountMemberAsync(accounts.Result.First().Id, emailAddress, roles.Result).Result;

            Assert.NotNull(addedAccountMember);

            var notAvailable = new List<int>
            {
                429, // add limit reached
                1004, // Account member already exists for email address
            };

            if (!addedAccountMember.Errors.Any(x => notAvailable.Contains(x.Code)))
            {
                Assert.True(addedAccountMember.Success);
                if (addedAccountMember.Errors != null)
                {
                    Assert.Empty(addedAccountMember.Errors);
                }

                var deletedAccountMember = client.DeleteAccountMemberAsync(accounts.Result.First().Id, addedAccountMember.Result.Id).Result;

                Assert.NotNull(deletedAccountMember);
                Assert.True(deletedAccountMember.Success);
                if (addedAccountMember.Errors != null)
                {
                    Assert.Empty(addedAccountMember.Errors);
                }
            }
        }

        [IgnoreOnEmptyCredentialsFact]
        public static void TestGetAccountMemberDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = client.GetAccountsAsync().Result;
            var accountMembers = client.GetAccountMembersAsync(accounts.Result.First().Id).Result;
            var accountMemberDetails = client.GetAccountMemberDetailsAsync(accounts.Result.First().Id, accountMembers.Result.First().Id).Result;

            Assert.NotNull(accountMemberDetails);
            Assert.True(accountMemberDetails.Success);
            if (accountMemberDetails.Errors != null)
            {
                Assert.Empty(accountMemberDetails.Errors);
            }
        }

        [IgnoreOnEmptyCredentialsFact]
        public static void TestUpdateAccountMemberAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = client.GetAccountsAsync().Result;
            var accountMembers = client.GetAccountMembersAsync(accounts.Result.First().Id).Result;

            var firstAccountMember = accountMembers.Result.First();

            var updatedMember = client.UpdateAccountMemberAsync(accounts.Result.First().Id, firstAccountMember.Id,
                firstAccountMember.Roles, firstAccountMember.Code, firstAccountMember.User, MembershipStatus.Accepted).Result;

            Assert.NotNull(updatedMember);

            var notAvailable = new List<int>
            {
                1001, // super user?
            };

            if (!updatedMember.Errors.Any(x => notAvailable.Contains(x.Code)))
            {
                Assert.True(updatedMember.Success);
                if (updatedMember.Errors != null)
                {
                    Assert.Empty(updatedMember.Errors);
                }
            }
        }
    }
}