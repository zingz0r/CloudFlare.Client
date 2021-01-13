using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.CustomHostnames
{
    public class CustomHostnameSsl
    {
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
        /// SSL specific additionalAccountProperties
        /// </summary>
        [JsonProperty("additionalAccountProperties")]
        public CustomHostnameSslSettings Settings { get; set; }
    }
}
