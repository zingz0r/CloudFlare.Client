﻿using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Accounts.Subscriptions;

/// <summary>
/// Component value
/// </summary>
public class ComponentValue
{
    /// <summary>
    /// The name of the component
    /// </summary>
    [JsonProperty("name")]
    public ComponentValueType Name { get; set; }

    /// <summary>
    /// The value of the component
    /// </summary>
    [JsonProperty("value")]
    public long Value { get; set; }

    /// <summary>
    /// The default value of the component
    /// </summary>
    [JsonProperty("default")]
    public long Default { get; set; }

    /// <summary>
    /// The price of the component
    /// </summary>
    [JsonProperty("price")]
    public long Price { get; set; }
}
