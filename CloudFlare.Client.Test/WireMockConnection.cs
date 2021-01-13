using System;
using CloudFlare.Client.Api.Authentication;
using CloudFlare.Client.Contexts;

namespace CloudFlare.Client.Test
{
    public class WireMockConnection
    {
        public ConnectionInfo ConnectionInfo { get; }

        public WireMockConnection(string address)
        {
            ConnectionInfo = new ConnectionInfo(new ApiKeyAuthentication("test", "test"))
            {
                Address = new Uri(address)
            };
        }
    }
}