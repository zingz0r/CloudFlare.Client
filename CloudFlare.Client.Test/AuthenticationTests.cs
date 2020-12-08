using System.Security.Authentication;
using Xunit;

namespace CloudFlare.Client.Test
{
    public class AuthenticationTests
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData("WrongEmail", null)]
        [InlineData(null, "WrongKey")]
        [InlineData("", "")]
        [InlineData("WrongEmail", "")]
        [InlineData("", "WrongKey")]
        public void TestClientAuthenticationWithApiKey(string emailAddress, string apiKey)
        {
            Assert.Throws<AuthenticationException>(() => new CloudFlareClient(emailAddress, apiKey));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TestClientAuthenticationWithApiToken(string token)
        {
            Assert.Throws<AuthenticationException>(() => new CloudFlareClient(token));
        }

        [Fact]
        public void TestClientAuthenticationWithAuthObject()
        {
            Assert.NotNull(new CloudFlareClient(Credentials.Credentials.Authentication));
        }
    }
}
