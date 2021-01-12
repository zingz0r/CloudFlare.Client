using System;
using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Enumerators;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Users
{
    public class UserMembershipUnitTests
    {
        [Theory]
        [InlineData(MembershipStatus.Accepted, null, null, null, null, null)]
        [InlineData(MembershipStatus.Pending, null, null, null, null, null)]
        [InlineData(MembershipStatus.Rejected, null, null, null, null, null)]
        [InlineData(null, "notExistingAccountName", null, null, null, null)]
        [InlineData(null, null, 0, null, null, null)]
        [InlineData(null, null, null, 100, null, null)]
        [InlineData(null, null, null, null, MembershipOrder.AccountName, null)]
        [InlineData(null, null, null, null, MembershipOrder.Status, null)]
        [InlineData(null, null, null, null, null, OrderType.Asc)]
        [InlineData(null, null, null, null, null, OrderType.Desc)]
        [InlineData(null, null, null, null, null, null)]
        public async Task TestGetMembershipsAsync(MembershipStatus? status, string accountName, int? page, int? perPage, MembershipOrder? membershipOrder, OrderType? order)
        {
            var filter = new MembershipFilter
            {
                AccountName = accountName,
                MembershipOrder = membershipOrder,
                Status = status
            };
            var displayOptions = new DisplayOptions { Page = page, PerPage = perPage, Order = order };

            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var userMembership = await client.Users.Memberships.GetAsync(filter, displayOptions);

            userMembership.Should().NotBeNull();
            userMembership.Success.Should().BeTrue();
            userMembership.Errors?.Should().BeEmpty();
        }

        [Fact]
        public async Task TestGetMembershipDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var userMembership = await client.Users.Memberships.GetAsync();
            var userMembershipDetails = await client.Users.Memberships.GetDetailsAsync(userMembership.Result.First().Id);

            userMembershipDetails.Should().NotBeNull();
            userMembershipDetails.Success.Should().BeTrue();
            userMembershipDetails.Errors?.Should().BeEmpty();
        }

        [Fact]
        public async Task TestUpdateMembershipStatusAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var userMembership = (await client.Users.Memberships.GetAsync()).Result.First();
            var updateUserMembershipStatus = await client.Users.Memberships.UpdateAsync(userMembership.Id, userMembership.Status);

            if (userMembership.Status == MembershipStatus.Accepted)
            {
                updateUserMembershipStatus.Should().NotBeNull();
                Assert.Contains(1001, updateUserMembershipStatus.Errors.Select(x =>
                {
                    if (x == null)
                    {
                        throw new ArgumentNullException(nameof(x));
                    }

                    return x.Code;
                }));
                updateUserMembershipStatus.Success.Should().BeFalse();
            }
        }

        [Fact(Skip = "Would cause deleted membership")]
        public async Task TestDeleteMembershipAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var userMembership = await client.Users.Memberships.GetAsync();
            var deletedMembership = await client.Users.Memberships.DeleteAsync(userMembership.Result.First().Id);

            deletedMembership.Should().NotBeNull();
            deletedMembership.Success.Should().BeTrue();
            deletedMembership.Errors?.Should().BeEmpty();
        }
    }
}