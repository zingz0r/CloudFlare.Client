using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Enumerators;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.ClientTests.Account
{
    public class MemberUnitTests
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

            accountMembers.Should().NotBeNull();
            accountMembers.Success.Should().BeTrue();
            accountMembers.Errors?.Should().BeEmpty();

        }

        [Theory]
        [InlineData("test@notexistingemail.lan")]
        public async Task TestAddAndDeleteAccountMemberAsync(string emailAddress)
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.GetAccountsAsync();
            var roles = await client.GetRolesAsync(accounts.Result.First().Id);
            var addedAccountMember = client.AddAccountMemberAsync(accounts.Result.First().Id, emailAddress, roles.Result).Result;

            addedAccountMember.Should().NotBeNull();

            var notAvailable = new List<int>
            {
                429, // add limit reached
                1004, // Account member already exists for email address
            };

            if (!addedAccountMember.Errors.Any(x => notAvailable.Contains(x.Code)))
            {
                addedAccountMember.Success.Should().BeTrue();
                addedAccountMember.Errors?.Should().BeEmpty();

                var deletedAccountMember = client.DeleteAccountMemberAsync(accounts.Result.First().Id, addedAccountMember.Result.Id).Result;

                deletedAccountMember.Should().NotBeNull();
                deletedAccountMember.Success.Should().BeTrue();
                addedAccountMember.Errors?.Should().BeEmpty();
            }
        }

        [Fact]
        public async Task TestGetAccountMemberDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.GetAccountsAsync();
            var accountMembers = await client.GetAccountMembersAsync(accounts.Result.First().Id);
            var accountMemberDetails = client.GetAccountMemberDetailsAsync(accounts.Result.First().Id, accountMembers.Result.First().Id).Result;

            accountMemberDetails.Should().NotBeNull();
            accountMemberDetails.Success.Should().BeTrue();
            accountMemberDetails.Errors?.Should().BeEmpty();
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

            updatedMember.Should().NotBeNull();

            var notAvailable = new List<int>
            {
                1001, // super user?
            };

            if (!updatedMember.Errors.Any(x => notAvailable.Contains(x.Code)))
            {
                updatedMember.Success.Should().BeTrue();
                updatedMember.Errors?.Should().BeEmpty();
            }
        }
    }
}