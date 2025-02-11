using System.Collections.Generic;
using System.Linq;
using CloudFlare.Client.Api.Certificates;

namespace CloudFlare.Client.Test.TestData;

public class CertificatesTestData
{
    public static List<OriginCaCertificate> Certificates { get; set; } = new()
    {
        new OriginCaCertificate
        {
            Certificate = "",
            Csr = "",
            Id = "023e105f4ecef8ad9ca31a8372d0c353",
            Hostnames = new List<string> { "tothnet.hu", "*.tothnet.hu" },
            ExpiresOn = new System.DateTime(2050, 1, 1),
            RequestedValidity = 5475,
            RequestType = Enumerators.CertificateRequestType.OriginRsa,
        }
    };
}
