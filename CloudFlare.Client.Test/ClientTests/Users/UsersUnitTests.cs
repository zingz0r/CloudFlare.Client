using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.ClientTests.Users
{
    public class UsersUnitTests
    {
        [Fact]
        public async Task TestGetUserDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var user = await client.Users.GetDetailsAsync();

            user.Should().NotBeNull();
            user.Success.Should().BeTrue();
            user.Errors?.Should().BeEmpty();
        }

        [Fact]
        public async Task TestUpdateUserDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var user = await client.Users.GetDetailsAsync();
            var updatedUser = await client.Users.UpdateAsync(user.Result);

            updatedUser.Should().NotBeNull();
            updatedUser.Success.Should().BeTrue();
            updatedUser.Errors?.Should().BeEmpty();
        }

        [Fact]
        public async Task TestVerifyUserAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var user = await client.Users.GetDetailsAsync();
            var verification = await client.Users.VerifyAsync();

            verification.Should().NotBeNull();
            verification.Success.Should().BeTrue();
            verification.Errors?.Should().BeEmpty();
        }
    }
}