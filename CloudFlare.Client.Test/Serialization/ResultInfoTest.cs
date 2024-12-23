using System.Collections.Generic;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class ResultInfoTest
{
    [Fact]
    public void TestSerialization()
    {
        var sut = new ResultInfo();

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "page", "total_pages", "per_page", "count", "total_count" });
    }
}
