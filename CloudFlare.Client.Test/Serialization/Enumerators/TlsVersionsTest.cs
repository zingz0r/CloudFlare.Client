using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization.Enumerators
{
    public class TlsVersionsTest
    {
        [Fact]
        public void TestSerialization()
        {
            JsonHelper.GetSerializedEnums<TlsVersion>().Should().BeEquivalentTo(new SortedSet<string>
            {
                "1.0", "1.1", "1.2", "1.3"
            });
        }
    }
}