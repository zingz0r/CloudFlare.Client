using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Zones;

/// <summary>
/// Zone filter
/// </summary>
public class ZoneFilter
{
    /// <summary>
    /// A domain name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Status of the zone
    /// </summary>
    public ZoneStatus? Status { get; set; }

    /// <summary>
    /// Whether to match all search requirements or at least one
    /// </summary>
    public bool? Match { get; set; }

    /// <summary>
    /// Account name
    /// </summary>
    public string AccountName { get; set; }

    /// <summary>
    /// Account identifier tag
    /// </summary>
    public string AccountId { get; set; }
}
