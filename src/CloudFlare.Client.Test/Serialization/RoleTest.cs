﻿using System.Collections.Generic;
using CloudFlare.Client.Api.Accounts.Roles;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class RoleTest
{
    [Fact]
    public void TestSerialization()
    {
        var sut = new Role();

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "id", "name", "description", "permissions" });
    }
}
