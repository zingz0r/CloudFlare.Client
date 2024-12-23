using System.Collections.Generic;
using CloudFlare.Client.Api.Zones.CustomHostnames;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Test.TestData;

public static class SslTestData
{
    public static List<Ssl> Ssls { get; set; } = new()
    {
        new Ssl
        {
            Cname = "app",
            CnameTarget = "target",
            Method = MethodType.Http,
            Status = "pending_validation",
            Type = DomainValidationType.Dv,
            Settings = new AdditionalCustomHostnameSslSettings
            {
                Ciphers = new List<string> { "ECDHE-RSA-AES128-GCM-SHA256", "AES128-SHA" },
                Http2 = FeatureStatus.On,
                Tls13 = FeatureStatus.On,
                MinTlsVersion = TlsVersion.Tls13
            }
        }
    };
}
