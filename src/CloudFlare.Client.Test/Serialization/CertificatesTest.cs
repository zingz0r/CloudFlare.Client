using System.Collections.Generic;
using CloudFlare.Client.Api.Certificates;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class CertificatesTest
{
    [Fact]
    public void TestSerialization()
    {
        var sut = new OriginCaCertificate();

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string>
        {
            "id", "certificate", "hostnames", "expires_on", "request_type", "requested_validity", "csr"
        });
    }
}
