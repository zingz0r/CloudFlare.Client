using System.Text.Json.Serialization;

namespace CloudFlare.Client.Api.Accounts.Subscriptions
{
    /// <summary>
    /// App
    /// </summary>
    public class App
    {
        /// <summary>
        /// The app installation identifier
        /// </summary>
        [JsonPropertyName("install_id")]
        public string InstallId { get; set; }
    }
}
