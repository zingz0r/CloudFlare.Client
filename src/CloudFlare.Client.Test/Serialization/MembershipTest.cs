using System.Collections.Generic;
using CloudFlare.Client.Api.Users.Memberships;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class MembershipTest
{
    [Fact]
    public void TestSerialization()
    {
        var sut = new Membership();

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "id", "code", "status", "account", "roles", "permissions" });
    }
}