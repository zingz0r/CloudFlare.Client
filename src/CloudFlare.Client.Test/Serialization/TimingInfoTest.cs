using System.Collections.Generic;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class TimingInfoTest
{
    [Fact]
    public void TestSerialization()
    {
        var sut = new TimingInfo();

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "start_time", "end_time", "process_time" });
    }
}
