﻿using CloudFlare.Client.Api.Accounts;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones;

/// <summary>
/// New zone
/// </summary>
public class NewZone
{
    /// <summary>
    /// The domain name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Information about the account the zone belongs to
    /// </summary>
    [JsonProperty("account")]
    public Account Account { get; set; }

    /// <summary>
    /// A full zone implies that DNS is hosted with CloudFlare. A partial zone is typically a partner-hosted zone or a CNAME setup.
    /// </summary>
    [JsonProperty("type")]
    public ZoneType Type { get; set; }

    /// <summary>
    /// Whether you want automatically attempt to fetch existing DNS records
    /// </summary>
    [JsonProperty("jump_start")]
    public bool JumpStart { get; set; }
}
