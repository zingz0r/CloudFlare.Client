using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization.Enumerators
{
    public class ClearanceLevelTest
    {
        [Fact]
        public void TestSerialization()
        {
            JsonHelper.GetSerializedEnums<ClearanceLevel>().Should().BeEquivalentTo(new SortedSet<string> { "no_clearance", "jschallenge", "managed", "interactive" });
        }
    }
}