using System.Collections.Generic;
using CloudFlare.Client.Api.Zones.CustomHostnames;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class SslCertificateTest
{
    [Fact]
    public void TestSerialization()
    {
        var sut = new SslCertificate();

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string>
        {
            "id", "issued_on", "expires_on", "uploaded_on", "issuer", "serial_number", "signature", "fingerprint_sha256"
        });
    }
}