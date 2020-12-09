using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Enumerators;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.ClientTests
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
        public async Task TestGetMembershipsAsync(MembershipStatus? status, string accountName, int? page,
            int? perPage,
            MembershipOrder? membershipOrder, OrderType? order)
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var userMembership = await client.GetMembershipsAsync(status, accountName, page, perPage, membershipOrder, order);

            userMembership.Should().NotBeNull();
            userMembership.Success.Should().BeTrue();
            userMembership.Errors?.Should().BeEmpty();
        }

        [Fact]
        public async Task TestGetMembershipDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var userMembership = await client.GetMembershipsAsync();

            userMembership.Should().NotBeNull();
            userMembership.Success.Should().BeTrue();
            userMembership.Errors?.Should().BeEmpty();

            var userMembershipDetails = await client.GetMembershipDetailsAsync(userMembership.Result.First().Id);

            userMembershipDetails.Should().NotBeNull();
            userMembershipDetails.Success.Should().BeTrue();
            userMembershipDetails.Errors?.Should().BeEmpty();
        }

        [Theory]
        [InlineData(SetMembershipStatus.Accepted)]
        [InlineData(SetMembershipStatus.Rejected)]
        public async Task TestUpdateMembershipStatusAsync(SetMembershipStatus status)
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var userMembership = await client.GetMembershipsAsync();

            if (userMembership.Result.First().Status == MembershipStatus.Accepted)
            {
                var updateUserMembershipStatus = await client.UpdateMembershipStatusAsync(userMembership.Result.First().Id, status);

                updateUserMembershipStatus.Should().NotBeNull();
                Assert.Contains(1001, updateUserMembershipStatus.Errors.Select(x => x.Code));
                updateUserMembershipStatus.Success.Should().BeFalse();
            }
        }

        [Fact(Skip = "Would cause deleted membership")]
        public async Task TestDeleteMembershipAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var userMembership = await client.GetMembershipsAsync();
            var deletedMembership = await client.DeleteMembershipAsync(userMembership.Result.First().Id);

            deletedMembership.Should().NotBeNull();
            deletedMembership.Success.Should().BeTrue();
            deletedMembership.Errors?.Should().BeEmpty();
        }
    }
}