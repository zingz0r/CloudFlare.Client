using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.WorkerRoute;

/// <summary>
/// New worker route
/// </summary>
public class NewWorkerRoute
{
    /// <summary>
    /// Pattern to match a url
    /// </summary>
    /// <example>
    /// example.net/*
    /// </example>
    [JsonProperty("pattern")]
    public string Pattern { get; set; }

    /// <summary>
    /// Name of the script
    /// </summary>
    /// <example>
    /// this-is_my_script-01
    /// </example>
    [JsonProperty("script")]
    public string Script { get; set; }
}