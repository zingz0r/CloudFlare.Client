using System;
using System.Collections.Generic;
using System.Text;
using CloudFlare.Client.Api.Accounts.Member;
using CloudFlare.Client.Api.Zones;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class MinifySettingTests
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new MinifySetting();

            JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "html", "css", "js" });
        }
    }
}
