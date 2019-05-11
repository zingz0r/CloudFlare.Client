using System.Security.Authentication;
using CloudFlare.Client.Models;
using CloudFlare.Client.Test.FactAttributes;
using Xunit;

namespace CloudFlare.Client.Test
{
    public static class AuthenticationTests
    {
        [Fact]
        private static void TestClientWithoutAuthentication()
        {
            Assert.Throws<AuthenticationException>(() => new CloudFlareClient(new Authentication("", "")));

            Assert.Throws<AuthenticationException>(() => new CloudFlareClient("", ""));
        }

        [IgnoreOnEmptyCredentialsFact]
        private static void TestClientWithAuthentication()
        {
            Assert.NotNull(new CloudFlareClient(Credentials.Credentials.Authentication));
        }
    }
}
