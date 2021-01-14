using System.Collections.Generic;
using CloudFlare.Client.Api.Accounts.Member;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class MemberTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new Member();

            JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "id", "code", "user", "status", "roles" });
        }
    }
}