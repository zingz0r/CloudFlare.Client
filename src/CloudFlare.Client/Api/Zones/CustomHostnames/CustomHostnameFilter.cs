using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Zones.CustomHostnames;

/// <summary>
/// Custom hostname filter
/// </summary>
public class CustomHostnameFilter
{
    /// <summary>
    /// The custom hostname that will point to your hostname via CNAME
    /// </summary>
    public string Hostname { get; set; }

    /// <summary>
    /// Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation
    /// </summary>
    public string CustomHostnameId { get; set; }

    /// <summary>
    /// Field to order hostnames by
    /// </summary>
    public CustomHostnameOrderType? OrderType { get; set; }

    /// <summary>
    /// Whether to filter hostnames based on if they have SSL enabled
    /// </summary>
    public bool? Ssl { get; set; }
}