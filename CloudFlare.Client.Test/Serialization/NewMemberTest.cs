using System.Collections.Generic;
using CloudFlare.Client.Api.Accounts.Member;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class NewMemberTest
{
    [Fact]
    public void TestSerialization()
    {
        var sut = new NewMember();

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "email", "status", "roles" });
    }
}
