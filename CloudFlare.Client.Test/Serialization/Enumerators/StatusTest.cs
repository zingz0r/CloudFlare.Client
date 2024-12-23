﻿using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization.Enumerators;

public class StatusTest
{
    [Fact]
    public void TestSerialization()
    {
        JsonHelper.GetSerializedEnums<MembershipStatus>().Should().BeEquivalentTo(new SortedSet<string> { "accepted", "pending", "rejected" });
    }
}
