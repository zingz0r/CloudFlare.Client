using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.CustomHostnames
{
    /// <summary>
    /// These are errors that were encountered while trying to activate a hostname.
    /// </summary>
    public class CustomHostnameSslValidationError
    {
        /// <summary>
        /// Validation error message
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
