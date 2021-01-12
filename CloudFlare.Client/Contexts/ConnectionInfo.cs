using System;
using System.Net;
using CloudFlare.Client.Api;
using CloudFlare.Client.Interfaces;

namespace CloudFlare.Client.Contexts
{
    public class ConnectionInfo
    {
        public Uri Address { get; } = new(ApiParameter.Config.BaseUrl);
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