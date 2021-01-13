using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.CustomHostnames
{
    public class ModifiedCustomHostname
    {
        /// <summary>
        /// SSL properties used when creating the custom hostname
        /// </summary>
        [JsonProperty("ssl", NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(EmitDefaultValue = false)]
        public CustomHostnameSsl Ssl { get; set; }
    }
}
