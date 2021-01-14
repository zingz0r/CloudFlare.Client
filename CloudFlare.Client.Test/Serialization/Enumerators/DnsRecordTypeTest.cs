using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization.Enumerators
{
    public class DnsRecordTypeTest
    {
        [Fact]
        public void TestSerialization()
        {
            JsonHelper.GetSerializedEnums<DnsRecordType>().Should().BeEquivalentTo(new SortedSet<string>
            {
                "A", "AAAA", "CAA", "CERT", "CNAME", "DNSKEY",
                "DS", "LOC", "MX", "NAPTR", "SMIMEA", "SPF",
                "SRV", "SSHFP", "PTR", "TLSA", "URI", "TXT", "NS"
            });
        }
    }
}