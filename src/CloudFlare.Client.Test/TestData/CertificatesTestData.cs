using System;
using System.Collections.Generic;
using CloudFlare.Client.Api.Certificates;
using Newtonsoft.Json;

namespace CloudFlare.Client.Test.TestData;

public class CertificatesTestData
{
    public class TestDateTimeOriginCaCertificate : OriginCaCertificate
    {
        [JsonProperty("expires_on")] 
        public string ExpiresOnRaw { get; set; }
        
        [JsonIgnore]
        public new DateTime ExpiresOn { get; set; }
    }

    public static List<TestDateTimeOriginCaCertificate> Certificates { get; set; } = new()
    {
        new TestDateTimeOriginCaCertificate()
        {
            Certificate = "",
            Csr = "",
            Id = "023e105f4ecef8ad9ca31a8372d0c353",
            Hostnames = new List<string> { "tothnet.hu", "*.tothnet.hu" },
            ExpiresOnRaw = "2025-02-18 12:20:00 +0000 UTC",
            ExpiresOn = new DateTime(2025, 02, 18, 12, 20, 00),
            RequestedValidity = 5475,
            RequestType = Enumerators.CertificateRequestType.OriginRsa,
        }
    };
}
