﻿using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Accounts.Subscriptions;

/// <summary>
/// App
/// </summary>
public class App
{
    /// <summary>
    /// The app installation identifier
    /// </summary>
    [JsonProperty("install_id")]
    public string InstallId { get; set; }
}
