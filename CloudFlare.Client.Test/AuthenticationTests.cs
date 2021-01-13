using System;
using System.Security.Authentication;
using FluentAssertions;
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
            Func<CloudFlareClient> ctor = () => new CloudFlareClient(emailAddress, apiKey);
            ctor.Should().ThrowExactly<AuthenticationException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TestClientAuthenticationWithApiToken(string token)
        {
            Func<CloudFlareClient> ctor = () => new CloudFlareClient(token);
            ctor.Should().ThrowExactly<AuthenticationException>();
        }

        [Fact]
        public void TestClientAuthenticationWithAuthObject()
        {
            Func<CloudFlareClient> ctor = () => new CloudFlareClient(Credentials.Authentication);
            ctor.Should().NotThrow();
            ctor.Invoke().Should().NotBeNull();
        }
    }
}
