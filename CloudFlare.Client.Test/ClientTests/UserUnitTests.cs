using System.Threading.Tasks;
using Xunit;

namespace CloudFlare.Client.Test.ClientTests
{
    public class UserUnitTests
    {
        [Fact]
        public async Task TestGetUserDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var userDetails = await client.GetUserDetailsAsync();

            Assert.NotNull(userDetails);
            Assert.Empty(userDetails.Errors);
            Assert.True(userDetails.Success);
        }

        [Fact]
        public async Task TestEditUserAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var userDetails = await client.GetUserDetailsAsync();
            var editedUser = await client.EditUserAsync(userDetails.Result);

            Assert.NotNull(editedUser);
            Assert.Empty(editedUser.Errors);
            Assert.True(editedUser.Success);
        }
    }
}