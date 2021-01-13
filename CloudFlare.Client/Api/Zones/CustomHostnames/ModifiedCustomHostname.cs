using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.CustomHostnames
{
    public class ModifiedCustomHostname
    {
        /// <summary>
        /// SSL settings used when creating the custom hostname
        /// </summary>
        [JsonProperty("ssl", NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(EmitDefaultValue = false)]
        public CustomHostnameSsl Ssl { get; set; }
    }
}
