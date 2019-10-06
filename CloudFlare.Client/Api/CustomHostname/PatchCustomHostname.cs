using System.Collections.Generic;
using System.Runtime.Serialization;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.CustomHostname
{
    public class PatchCustomHostname
    {
        /// <summary>
        /// SSL properties used when creating the custom hostname
        /// </summary>
        [JsonProperty("ssl", NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(EmitDefaultValue = false)]
        public CustomHostnameSsl Ssl { get; set; }
    }
}
