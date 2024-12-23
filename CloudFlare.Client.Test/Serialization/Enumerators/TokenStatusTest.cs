using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization.Enumerators;

public class TokenStatusTest
{
    [Fact]
    public void TestSerialization()
    {
        JsonHelper.GetSerializedEnums<TokenStatus>().Should().BeEquivalentTo(new SortedSet<string>
        {
            "disabled", "active", "expired"
        });
    }
}