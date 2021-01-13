using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Memberships;
using CloudFlare.Client.Api.Users;
using CloudFlare.Client.Enumerators;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Accounts
{
    public class MembersUnitTests
    {
        [Theory]
        [InlineData(0, 100, OrderType.Desc)]
        [InlineData(0, 100, OrderType.Asc)]
        [InlineData(0, 100, null)]
        [InlineData(0, null, null)]
        [InlineData(null, null, null)]
        public async Task TestGetAccountMembersAsync(int? page, int? perPage, OrderType? order)
        {
            var displayOptions = new DisplayOptions { Page = page, PerPage = perPage, Order = order };

            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);

            var accounts = await client.Accounts.GetAsync();
            var accountMembers = await client.Accounts.Memberships.GetAsync(accounts.Result.First().Id, displayOptions);

            accountMembers.Should().NotBeNull();
            accountMembers.Success.Should().BeTrue();
            accountMembers.Errors?.Should().BeEmpty();

        }

        [Theory]
        [InlineData("test@notexistingemail.lan")]
        public async Task TestAddAndDeleteAccountMemberAsync(string emailAddress)
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.Accounts.GetAsync();
            var roles = await client.Accounts.Roles.GetAsync(accounts.Result.First().Id);
            var addedAccountMember = client.Accounts.Memberships.AddAsync(accounts.Result.First().Id, emailAddress, roles.Result).Result;

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

                var deletedAccountMember = client.Accounts.Memberships.DeleteAsync(accounts.Result.First().Id, addedAccountMember.Result.Id).Result;

                deletedAccountMember.Should().NotBeNull();
                deletedAccountMember.Success.Should().BeTrue();
                addedAccountMember.Errors?.Should().BeEmpty();
            }
        }

        [Fact]
        public async Task TestGetAccountMemberDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.Accounts.GetAsync();
            var accountMembers = await client.Accounts.Memberships.GetAsync(accounts.Result.First().Id);
            var accountMemberDetails = client.Accounts.Memberships.GetDetailsAsync(accounts.Result.First().Id, accountMembers.Result.First().Id).Result;

            accountMemberDetails.Should().NotBeNull();
            accountMemberDetails.Success.Should().BeTrue();
            accountMemberDetails.Errors?.Should().BeEmpty();
        }

        [Fact]
        public async Task TestUpdateAccountMemberAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.Accounts.GetAsync();
            var accountMembers = await client.Accounts.Memberships.GetAsync(accounts.Result.First().Id);

            var firstAccountMember = accountMembers.Result.First();

            var updatedMember = await client.Accounts.Memberships.UpdateAsync(accounts.Result.First().Id, firstAccountMember.Id,
                firstAccountMember.Roles, new AdditionalMembershipSettings<User>
                {
                    Code = firstAccountMember.Code,
                    Entity = firstAccountMember.Entity,
                    Status = MembershipStatus.Accepted
                });

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