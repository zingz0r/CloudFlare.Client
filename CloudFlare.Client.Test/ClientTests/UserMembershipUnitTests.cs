using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Enumerators;
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

            Assert.NotNull(userMembership);
            Assert.True(userMembership.Success);
            if (userMembership.Errors != null)
            {
                Assert.Empty(userMembership.Errors);
            }
        }

        [Fact]
        public async Task TestGetMembershipDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var userMembership = await client.GetMembershipsAsync();

            Assert.NotNull(userMembership);
            Assert.True(userMembership.Success);
            if (userMembership.Errors != null)
            {
                Assert.Empty(userMembership.Errors);
            }

            var userMembershipDetails = await client.GetMembershipDetailsAsync(userMembership.Result.First().Id);

            Assert.NotNull(userMembershipDetails);
            Assert.True(userMembershipDetails.Success);
            if (userMembershipDetails.Errors != null)
            {
                Assert.Empty(userMembershipDetails.Errors);
            }
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

                Assert.NotNull(updateUserMembershipStatus);
                Assert.Contains(1001, updateUserMembershipStatus.Errors.Select(x => x.Code));
                Assert.False(updateUserMembershipStatus.Success);
            }
        }

        [Fact(Skip = "Would cause deleted membership")]
        public async Task TestDeleteMembershipAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var userMembership = await client.GetMembershipsAsync();
            var deletedMembership = await client.DeleteMembershipAsync(userMembership.Result.First().Id);

            Assert.NotNull(deletedMembership);
            Assert.True(deletedMembership.Success);
            if (deletedMembership.Errors != null)
            {
                Assert.Empty(deletedMembership.Errors);
            }
        }
    }
}