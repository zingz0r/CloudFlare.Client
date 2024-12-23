﻿using System.Collections.Generic;
using CloudFlare.Client.Api.Accounts.Subscriptions;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class ComponentValueTest
{
    [Fact]
    public void TestSerialization()
    {
        var sut = new ComponentValue();

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "name", "value", "default", "price" });
    }
}