using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.CustomHostnames
{
    public class Ssl
    {
        /// <summary>
        /// Status of the hostname's SSL certificates
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Domain control validation (DCV) method used for this hostname
        /// </summary>
        [JsonProperty("method")]
        public MethodType Method { get; set; }

        /// <summary>
        /// Level of validation to be used for this hostname. Domain validation (dv) must be used
        /// </summary>
        [JsonProperty("type")]
        public DomainValidationType Type { get; set; }

        /// <summary>
        /// The value that must be returned when the CNAME (cname) is queried during domain validation
        /// </summary>
        [JsonProperty("cname_target")]
        public string CnameTarget { get; set; }

        /// <summary>
        /// The CNAME that the certificate authority (CA) will resolve during the domain validation
        /// </summary>
        [JsonProperty("cname")]
        public string Cname { get; set; }

        /// <summary>
        /// Additional SSL specific settings
        /// </summary>
        [JsonProperty("settings")]
        public AdditionalCustomHostnameSslSettings Settings { get; set; }
    }
}