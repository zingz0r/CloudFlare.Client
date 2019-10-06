using Newtonsoft.Json;

namespace CloudFlare.Client.Models
{
    public class App
    {
        /// <summary>
        /// The app installation identifier
        /// </summary>
        [JsonProperty("install_id")]
        public object InstallId { get; set; }
    }
}
