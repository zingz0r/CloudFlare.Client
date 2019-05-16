using System.Linq;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.FactAttributes;
using CloudFlare.Client.Test.TheoryAttributes;
using Xunit;

namespace CloudFlare.Client.Test
{
    public static class UserMembershipUnitTests
    {
        [IgnoreOnEmptyCredentialsTheory]
        [InlineData(MembershipStatus.Accepted, null, null, null, null, null)]
        [InlineData(MembershipStatus.Pending, null, null, null, null, null)]
        [InlineData(MembershipStatus.Rejected, null, null, null, null, null)]
        [InlineData(null, "notExistingAccountName", null, null, null, null)]
        [InlineData(null, null, 0, null, null, null)]
        [InlineData(null, null, null, 100, null, null)]
        [InlineData(null, null, null, null, MembershipOrder.AccountName, null)]
        [InlineData(null, null, null, null, MembershipOrder.Id, null)]
        [InlineData(null, null, null, null, MembershipOrder.Status, null)]
        [InlineData(null, null, null, null, null, OrderType.Asc)]
        [InlineData(null, null, null, null, null, OrderType.Desc)]
        [InlineData(null, null, null, null, null, null)]
        public static void TestGetMembershipsAsync(MembershipStatus? status, string accountName, int? page,
            int? perPage,
            MembershipOrder? membershipOrder, OrderType? order)
        {
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var userMembership = client
                    .GetMembershipsAsync(status, accountName, page, perPage, membershipOrder, order).Result;

                Assert.NotNull(userMembership);
                Assert.Empty(userMembership.Errors);
                Assert.True(userMembership.Success);
            }
        }

        [IgnoreOnEmptyCredentialsFact]
        public static void TestGetMembershipDetailsAsync()
        {
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var userMembership = client.GetMembershipsAsync().Result;

                Assert.NotNull(userMembership);
                Assert.Empty(userMembership.Errors);
                Assert.True(userMembership.Success);

                var userMembershipDetails = client.GetMembershipDetailsAsync(userMembership.Result.First().Id).Result;

                Assert.NotNull(userMembershipDetails);
                Assert.Empty(userMembershipDetails.Errors);
                Assert.True(userMembershipDetails.Success);
            }
        }

        [IgnoreOnEmptyCredentialsTheory]
        [InlineData(SetMembershipStatus.Accepted)]
        [InlineData(SetMembershipStatus.Rejected)]
        public static void TestUpdateMembershipStatusAsync(SetMembershipStatus status)
        {
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var userMembership = client.GetMembershipsAsync().Result;

                Assert.NotNull(userMembership);
                Assert.Empty(userMembership.Errors);
                Assert.True(userMembership.Success);

                if (userMembership.Result.First().Status == MembershipStatus.Accepted)
                {
                    var updateUserMembershipStatus = client.UpdateMembershipStatusAsync(userMembership.Result.First().Id, status).Result;

                    Assert.NotNull(updateUserMembershipStatus);
                    Assert.Contains(1001, updateUserMembershipStatus.Errors.Select(x => x.Code));
                    Assert.False(updateUserMembershipStatus.Success);
                }
            }
        }

        [Fact(Skip = "Would cause deleted membership")]
        public static void TestDeleteMembershipAsync()
        {
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var userMembership = client.GetMembershipsAsync().Result;

                Assert.NotNull(userMembership);
                Assert.Empty(userMembership.Errors);
                Assert.True(userMembership.Success);

                var deletedMembership = client.DeleteMembershipAsync(userMembership.Result.First().Id).Result;

                Assert.NotNull(deletedMembership);
                Assert.Empty(deletedMembership.Errors);
                Assert.True(deletedMembership.Success);
            }
        }
    }
}