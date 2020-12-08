using System.Security.Authentication;
using CloudFlare.Client.Test.FactAttributes;
using Xunit;

namespace CloudFlare.Client.Test
{
    public class AuthenticationTests
    {
        [Theory]
        [InlineData(null, null, null)]
        [InlineData("", "", "")]
        [InlineData("WrongEmail", "WrongKey", null)]
        [InlineData(null, null, "WrongToken")]
        public void TestClientAuthentication(string emailAddress, string apiKey, string apiToken)
        {
            Assert.Throws<AuthenticationException>(() => new CloudFlareClient(emailAddress, apiKey));
            Assert.Throws<AuthenticationException>(() => new CloudFlareClient(apiToken));
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("WrongEmail", null)]
        [InlineData(null, "WrongKey")]
        [InlineData("", "")]
        [InlineData("WrongEmail", "")]
        [InlineData("", "WrongKey")]
        [InlineData("WrongEmail", "WrongKey")]
        public void TestClientAuthenticationWithApiKey(string emailAddress, string apiKey)
        {
            Assert.Throws<AuthenticationException>(() => new CloudFlareClient(emailAddress, apiKey));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("WrongToken")]
        public void TestClientAuthenticationWithApiToken(string token)
        {
            Assert.Throws<AuthenticationException>(() => new CloudFlareClient(token));
        }

        [IgnoreOnEmptyCredentialsFact]
        public void TestClientAuthenticationWithApiKeyAuthObject()
        {
            Assert.NotNull(new CloudFlareClient(Credentials.Credentials.Authentication));
        }
    }
}
