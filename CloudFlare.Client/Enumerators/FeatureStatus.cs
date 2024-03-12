using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents possible feature statuses
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
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
}
