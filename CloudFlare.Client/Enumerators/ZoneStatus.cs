﻿using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the zone statuses
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum ZoneStatus
    {
        /// <summary>
        /// Active
        /// </summary>
        [EnumMember(Value = "active")]
        Active,

        /// <summary>
        /// Pending
        /// </summary>
        [EnumMember(Value = "pending")]
        Pending,

        /// <summary>
        /// Initializing
        /// </summary>
        [EnumMember(Value = "initializing")]
        Initializing,

        /// <summary>
        /// Moved
        /// </summary>
        [EnumMember(Value = "moved")]
        Moved,

        /// <summary>
        /// Deleted
        /// </summary>
        [EnumMember(Value = "deleted")]
        Deleted,

        /// <summary>
        /// Deactivated
        /// </summary>
        [EnumMember(Value = "deactivated")]
        Deactivated
    }
}
