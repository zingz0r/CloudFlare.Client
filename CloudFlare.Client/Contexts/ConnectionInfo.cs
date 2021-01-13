using System;
using System.Net;
using CloudFlare.Client.Api.Authentication;

namespace CloudFlare.Client.Contexts
{
    public class ConnectionInfo
    {
        public static Uri Address { get; } = new("https://api.cloudflare.com/client/v4/", UriKind.Absolute);
        public IAuthentication Authentication { get; set; }
        public TimeSpan? Timeout { get; set; }
        public bool AllowAutoRedirect { get; set; } = false;
        public bool ExpectContinue { get; set; } = false;
        public bool UseProxy { get; set; } = true;
        public IWebProxy Proxy { get; set; } = null;

        public ConnectionInfo(IAuthentication authentication)
        {
            Authentication = authentication;
        }
    }
}