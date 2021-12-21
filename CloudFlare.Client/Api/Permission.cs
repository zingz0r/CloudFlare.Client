using Newtonsoft.Json;

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
        [JsonProperty("read")]
        public bool Read { get; set; }

        /// <summary>
        /// Permission Write property
        /// </summary>
        [JsonProperty("write")]
        public bool Write { get; set; }
    }
}
