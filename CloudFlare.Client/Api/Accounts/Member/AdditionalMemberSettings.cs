using CloudFlare.Client.Api.Users;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Accounts.Member
{
    public class AdditionalMemberSettings
    {
        /// <summary>
        /// The unique activation code for the account member
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Member user
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }

        /// <summary>
        /// A member's status in the account
        /// </summary>
        [JsonProperty("status")]
        public Status? Status { get; set; }
    }
}