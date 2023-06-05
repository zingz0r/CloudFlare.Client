using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents possible feature statuses
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SslSetting
    {
        /// <summary>
        /// Encrypts traffic between the browser and Cloudflare
        /// </summary>
        [EnumMember(Value = "flexible")]
        Flexible,

        /// <summary>
        /// No encryption applied
        /// </summary>
        [EnumMember(Value = "off")]
        Off,

        /// <summary>
        /// Encrypts end-to-end, using a self signed certificate on the server
        /// </summary>
        [EnumMember(Value = "full")]
        Full,

        /// <summary>
        /// Encrypts end-to-end, but requires a trusted CA or Cloudflare Origin CA certificate on the server
        /// </summary>
        [EnumMember(Value = "strict")]
        Strict,
    }
}
