using CloudFlare.Client.Test.FactAttributes;
using Xunit;

namespace CloudFlare.Client.Test
{
    public static class UserUnitTests
    {
        [IgnoreOnEmptyCredentialsFact]
        public static void TestGetUserDetailsAsync()
        {
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var userDetails = client.GetUserDetailsAsync().Result;

                Assert.NotNull(userDetails);
                Assert.Empty(userDetails.Errors);
                Assert.True(userDetails.Success);
            }
        }

        [IgnoreOnEmptyCredentialsFact]
        public static void TestEditUserAsync()
        {
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var userDetails = client.GetUserDetailsAsync().Result;

                Assert.NotNull(userDetails);
                Assert.Empty(userDetails.Errors);
                Assert.True(userDetails.Success);

                var editedUser = client.EditUserAsync(userDetails.Result).Result;

                Assert.NotNull(editedUser);
                Assert.Empty(editedUser.Errors);
                Assert.True(editedUser.Success);
            }
        }
    }
}