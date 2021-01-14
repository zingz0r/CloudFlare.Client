using System;
using System.Net;

namespace CloudFlare.Client.Contexts
{
    public class ConnectionInfo
    {
        public Uri Address { get; set; } = new("https://api.cloudflare.com/client/v4/", UriKind.Absolute);
        public TimeSpan? Timeout { get; set; }
        public bool AllowAutoRedirect { get; set; } = false;
        public bool ExpectContinue { get; set; } = false;
        public bool UseProxy { get; set; } = true;
        public IWebProxy Proxy { get; set; } = null;
    }
}