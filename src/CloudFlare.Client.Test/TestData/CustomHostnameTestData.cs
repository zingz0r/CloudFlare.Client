using System;
using System.Collections.Generic;
using System.Linq;
using CloudFlare.Client.Api.Zones.CustomHostnames;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Test.TestData;

public static class CustomHostnameTestData
{
    public static List<CustomHostname> CustomHostnames { get; set; } = new()
    {
        new CustomHostname
        {
            Id = "0d89c70d-ad9f-4843-b99f-6cc0252067e9",
            Hostname = "app.tothnet.hu",
            Ssl = SslTestData.Ssls.First(),
            CreatedAt = DateTime.UtcNow,
            CustomMetadata = new Dictionary<string, string> { { "key", "value" } },
            CustomOriginServer = "origin",
            OwnershipVerification = new OwnershipVerification { Name = "name", Type = "type", Value = Guid.NewGuid() },
            OwnershipVerificationHttp = new OwnershipVerificationHttp { HttpBody = Guid.NewGuid(), HttpUrl = new Uri("http://www.tothnet.hu") },
            Status = CustomHostnameStatus.Pending
        }
    };
}
