using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators;

/// <summary>
/// Represents possible feature statuses
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum FeatureStatus
{
    /// <summary>
    /// Feature enabled
    /// </summary>
    [EnumMember(Value = "on")]
    On,

    /// <summary>
    /// Feature disabled
    /// </summary>
    [EnumMember(Value = "off")]
    Off
}
