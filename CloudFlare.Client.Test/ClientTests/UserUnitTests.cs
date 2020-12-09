using System.Threading.Tasks;
using FluentAssertions;
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

            userDetails.Should().NotBeNull();
            userDetails.Errors?.Should().BeEmpty();
            userDetails.Success.Should().BeTrue();
        }

        [Fact]
        public async Task TestEditUserAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var userDetails = await client.GetUserDetailsAsync();
            var editedUser = await client.EditUserAsync(userDetails.Result);

            editedUser.Should().NotBeNull();
            editedUser.Errors?.Should().BeEmpty();
            editedUser.Success.Should().BeTrue();
        }
    }
}