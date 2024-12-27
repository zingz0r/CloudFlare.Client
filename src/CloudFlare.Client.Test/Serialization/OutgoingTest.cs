using CloudFlare.Client.Api.Parameters;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class OutgoingTest
{
    [Fact]
    public void TestSerialization()
    {
        Outgoing.PurgeEverything.Should().Be("purge_everything");
    }
}
