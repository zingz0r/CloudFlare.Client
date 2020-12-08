using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Enumerators;
using Xunit;

namespace CloudFlare.Client.Test
{
    public class AccountMemberUnitTests
    {
        [Theory]
        [InlineData(0, 100, OrderType.Desc)]
        [InlineData(0, 100, OrderType.Asc)]
        [InlineData(0, 100, null)]
        [InlineData(0, null, null)]
        [InlineData(null, null, null)]
        public async Task TestGetAccountMembersAsync(int? page, int? perPage, OrderType? order)
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);

            var accounts = await client.GetAccountsAsync();
            var accountMembers = await client.GetAccountMembersAsync(accounts.Result.First().Id, page, perPage, order);

            Assert.NotNull(accountMembers);
            Assert.True(accountMembers.Success);

            if (accountMembers.Errors != null)
            {
                Assert.Empty(accountMembers.Errors);
            }

        }

        [Theory]
        [InlineData("test@notexistingemail.lan")]
        public async Task TestAddAndDeleteAccountMemberAsync(string emailAddress)
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.GetAccountsAsync();
            var roles = await client.GetRolesAsync(accounts.Result.First().Id);
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

        [Fact]
        public async Task TestGetAccountMemberDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.GetAccountsAsync();
            var accountMembers = await client.GetAccountMembersAsync(accounts.Result.First().Id);
            var accountMemberDetails = client.GetAccountMemberDetailsAsync(accounts.Result.First().Id, accountMembers.Result.First().Id).Result;

            Assert.NotNull(accountMemberDetails);
            Assert.True(accountMemberDetails.Success);
            if (accountMemberDetails.Errors != null)
            {
                Assert.Empty(accountMemberDetails.Errors);
            }
        }

        [Fact]
        public async Task TestUpdateAccountMemberAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.GetAccountsAsync();
            var accountMembers = await client.GetAccountMembersAsync(accounts.Result.First().Id);

            var firstAccountMember = accountMembers.Result.First();

            var updatedMember = await client.UpdateAccountMemberAsync(accounts.Result.First().Id, firstAccountMember.Id,
                firstAccountMember.Roles, firstAccountMember.Code, firstAccountMember.User, MembershipStatus.Accepted);

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