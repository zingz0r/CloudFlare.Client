using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CloudFlare.Client.Api.Accounts;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Zones
{
    /// <summary>
    /// Zone
    /// </summary>
    public class Zone
    {
        /// <summary>
        /// Zone identifier tag
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The domain name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The interval (in seconds) from when development mode expires (positive integer)
        /// or last expired (negative integer) for the domain.
        /// If development mode has never been enabled, this value is 0.
        /// </summary>
        [JsonPropertyName("development_mode")]
        public int DevelopmentMode { get; set; }

        /// <summary>
        /// Original name servers before moving to CloudFlare
        /// </summary>
        [JsonPropertyName("original_name_servers")]
        public IReadOnlyList<string> OriginalNameServers { get; set; }

        /// <summary>
        /// Registrar for the domain at the time of switching to CloudFlare
        /// </summary>
        [JsonPropertyName("original_registrar")]
        public string OriginalRegistrar { get; set; }

        /// <summary>
        /// DNS host at the time of switching to CloudFlare
        /// </summary>
        [JsonPropertyName("original_dnshost")]
        public string OriginalDnsHost { get; set; }

        /// <summary>
        /// When the zone was created
        /// </summary>
        [JsonPropertyName("created_on")]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// When the zone was last modified
        /// </summary>
        [JsonPropertyName("modified_on")]
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// The last time proof of ownership was detected and the zone was made active
        /// </summary>
        [JsonPropertyName("activated_on")]
        public DateTime? ActivatedDate { get; set; }

        /// <summary>
        /// Information about the owner of the zone
        /// </summary>
        [JsonPropertyName("owner")]
        public Owner Owner { get; set; }

        /// <summary>
        /// Information about the account the zone belongs to
        /// </summary>
        [JsonPropertyName("account")]
        public Account Account { get; set; }

        /// <summary>
        /// Available permissions on the zone for the current user requesting the item
        /// </summary>
        [JsonPropertyName("permissions")]
        public IReadOnlyList<string> Permissions { get; set; }

        /// <summary>
        /// A zone plan
        /// </summary>
        [JsonPropertyName("plan")]
        public Plan Plan { get; set; }

        /// <summary>
        /// A pending zone plan
        /// </summary>
        [JsonPropertyName("plan_pending")]
        public Plan PlanPending { get; set; }

        /// <summary>
        /// Status of the zone
        /// </summary>
        [JsonPropertyName("status")]
        public ZoneStatus Status { get; set; }

        /// <summary>
        /// Indicates if the zone is only using CloudFlare DNS services. A true value means the zone will not receive security or performance benefits.
        /// </summary>
        [JsonPropertyName("paused")]
        public bool Paused { get; set; }

        /// <summary>
        /// A full zone implies that DNS is hosted with CloudFlare. A partial zone is typically a partner-hosted zone or a CNAME setup.
        /// </summary>
        [JsonPropertyName("type")]
        public ZoneType Type { get; set; }

        /// <summary>
        /// CloudFlare-assigned name servers. This is only populated for zones that use CloudFlare DNS
        /// </summary>
        [JsonPropertyName("name_servers")]
        public IReadOnlyList<string> NameServers { get; set; }
    }
}
