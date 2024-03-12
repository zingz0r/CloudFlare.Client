using System;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Api.Users
{
    /// <summary>
    /// User
    /// </summary>
    public class User
    {
        /// <summary>
        /// User identifier tag
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// User's contact email address
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// User's first name
        /// </summary>
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// User's last name
        /// </summary>
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// A username used to access other CloudFlare services, like support
        /// </summary>
        [JsonPropertyName("username")]
        public string Username { get; set; }

        /// <summary>
        /// User's telephone number
        /// </summary>
        [JsonPropertyName("telephone")]
        public string Telephone { get; set; }

        /// <summary>
        /// The country in which the user lives.
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// The zipcode or postal code where the user lives.
        /// </summary>
        [JsonPropertyName("zipcode")]
        public string Zipcode { get; set; }

        /// <summary>
        /// When the user signed up.
        /// </summary>
        [JsonPropertyName("created_on")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Last time the user was modified
        /// </summary>
        [JsonPropertyName("modified_on")]
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// Whether two-factor authentication is enabled for the user account. This does not apply to API authentication
        /// </summary>
        [JsonPropertyName("two_factor_authentication_enabled")]
        public bool TwoFactorAuthenticationEnabled { get; set; }

        /// <summary>
        /// Indicates whether the user is prevented from performing certain actions within their account
        /// </summary>
        [JsonPropertyName("suspended")]
        public bool Suspended { get; set; }
    }
}
