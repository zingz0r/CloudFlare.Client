using System.Security.Authentication;
using CloudFlare.Client.Models;
using CloudFlare.Client.Test.FactAttributes;
using Xunit;

namespace CloudFlare.Client.Test
{
    public static class AuthenticationTests
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("WronngEmail", "WrongKey")]
        private static void TestClientAuthentication(string emailAddress, string apiKey)
        {
            Assert.Throws<AuthenticationException>(() => new CloudFlareClient(emailAddress, apiKey));
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("WronngEmail", "WrongKey")]
        public static void TestClientAuthenticationWithAuthenticationObject(string emailAddress, string apiKey)
        {
            Assert.Throws<AuthenticationException>(() => new CloudFlareClient(new Authentication(emailAddress, apiKey)));
        }

        [IgnoreOnEmptyCredentialsFact]
        public static void TestClientAuthenticationWithCredentials()
        {
            Assert.NotNull(new CloudFlareClient(Credentials.Credentials.Authentication));
        }
    }
}
