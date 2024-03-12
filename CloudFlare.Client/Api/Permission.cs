using System.Text.Json.Serialization;

namespace CloudFlare.Client.Api
{
    /// <summary>
    /// Permission
    /// </summary>
    public class Permission
    {
        /// <summary>
        /// Permission read property
        /// </summary>
        [JsonPropertyName("read")]
        public bool Read { get; set; }

        /// <summary>
        /// Permission Write property
        /// </summary>
        [JsonPropertyName("write")]
        public bool Write { get; set; }
    }
}
