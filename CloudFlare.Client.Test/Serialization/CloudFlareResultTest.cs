using System.Collections.Generic;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class CloudFlareResultTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new CloudFlareResult<string>(default, default, default, default, default, default);

            JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "result", "result_info", "timing", "messages", "errors", "success" });
        }
    }
}
