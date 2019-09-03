using System.Security.Authentication;
using CloudFlare.Client.Models;
using CloudFlare.Client.Test.FactAttributes;
using Xunit;

namespace CloudFlare.Client.Test
{
    public static class AuthenticationTests
    {
        [Theory]
        [InlineData(null, null, null)]
        [InlineData("", "", "")]
        [InlineData("WrongEmail", "WrongKey", null)]
        [InlineData(null, null, "WrongToken")]
        public static void TestClientAuthentication(string emailAddress, string apiKey, string apiToken)
        {
            Assert.Throws<AuthenticationException>(() => new CloudFlareClient(emailAddress, apiKey));
            Assert.Throws<AuthenticationException>(() => new CloudFlareClient(apiToken));
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData("", "", "")]
        [InlineData("WrongEmail", "WrongKey", null)]
        [InlineData(null, null, "WrongToken")]
        public static void TestClientAuthenticationWithAuthenticationObject(string emailAddress, string apiKey, string apiToken)
        {
            Assert.Throws<AuthenticationException>(() => new CloudFlareClient(new Authentication(emailAddress, apiKey, apiToken)));
        }

        [IgnoreOnEmptyCredentialsFact]
        public static void TestClientAuthenticationWithCredentials()
        {
            Assert.NotNull(new CloudFlareClient(Credentials.Credentials.Authentication));
        }
    }
}
