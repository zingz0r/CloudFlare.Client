using System.Collections.Generic;
using CloudFlare.Client.Api.Users;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class VerifyTokenTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new VerifyToken();

            JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "id", "name", "status", "expires_on", "issued_on", "modified_on", "not_before" });
        }
    }
}