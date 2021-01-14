using System.Collections.Generic;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class ApiErrorTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new ApiError();

            JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "code", "error_chain", "message" });
        }
    }
}