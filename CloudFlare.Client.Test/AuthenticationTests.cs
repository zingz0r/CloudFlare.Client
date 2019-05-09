using System.Security.Authentication;
using CloudFlare.Client.Models;
using CloudFlare.Client.Test.FactAttributes;
using Xunit;

namespace CloudFlare.Client.Test
{
    public class AuthenticationTests
    {
        [Fact]
        private void TestClientWithoutAuthentication()
        {
            Assert.Throws<AuthenticationException>(() => new CloudFlareClient(new Authentication("", "")));

            Assert.Throws<AuthenticationException>(() => new CloudFlareClient("", ""));
        }

        [IgnoreOnEmptyCredentialsFact]
        private void TestClientWithAuthentication()
        {
            Assert.NotNull(new CloudFlareClient(Credentials.Authentication));
        }
    }
}
