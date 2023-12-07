using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the widget modes
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WidgetMode
    {
        /// <summary>
        /// Non-Interactive Mode
        /// </summary>
        [EnumMember(Value = "non-interactive")]
        NonInteractive,

        /// <summary>
        /// Invisible Mode
        /// </summary>
        [EnumMember(Value = "invisible")]
        Invisible,

        /// <summary>
        /// Managed Mode
        /// </summary>
        [EnumMember(Value = "managed")]
        Managed
    }
}
