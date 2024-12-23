using System;
using System.Net;

namespace CloudFlare.Client.Contexts;

/// <summary>
/// Connection information
/// </summary>
public class ConnectionInfo
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConnectionInfo"/> class
    /// </summary>
    /// <param name="uri">CloudFlare API uri</param>
    public ConnectionInfo(string uri = "https://api.cloudflare.com/client/v4/")
    {
        Address = new Uri(uri, UriKind.Absolute);
    }

    /// <summary>
    /// Address of the CloudFlare API
    /// </summary>
    public Uri Address { get; set; }

    /// <summary>
    /// Timeout
    /// </summary>
    public TimeSpan? Timeout { get; set; }

    /// <summary>
    /// Allow auto redirection
    /// </summary>
    public bool AllowAutoRedirect { get; set; } = false;

    /// <summary>
    /// Expect header for an HTTP request contains Continue.
    /// </summary>
    public bool ExpectContinue { get; set; } = false;

    /// <summary>
    /// Use proxy
    /// </summary>
    public bool UseProxy { get; set; } = true;

    /// <summary>
    /// Proxy
    /// </summary>
    public IWebProxy Proxy { get; set; } = null;
}
