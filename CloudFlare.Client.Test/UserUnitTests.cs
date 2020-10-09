using System.Threading.Tasks;
using CloudFlare.Client.Test.FactAttributes;
using Xunit;

namespace CloudFlare.Client.Test
{
    public class UserUnitTests
    {
        [IgnoreOnEmptyCredentialsFact]
        public async Task TestGetUserDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var userDetails = await client.GetUserDetailsAsync();

            Assert.NotNull(userDetails);
            Assert.Empty(userDetails.Errors);
            Assert.True(userDetails.Success);
        }

        [IgnoreOnEmptyCredentialsFact]
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