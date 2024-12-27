using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.CustomHostnames;

/// <summary>
/// New custom hostname
/// </summary>
public class NewCustomHostname
{
    /// <summary>
    /// The custom hostname that will point to your hostname via CNAME
    /// </summary>
    [JsonProperty("hostname")]
    public string Hostname { get; set; }

    /// <summary>
    /// SSL settings used when creating the custom hostname
    /// </summary>
    [JsonProperty("ssl")]
    public Ssl Ssl { get; set; }
}
