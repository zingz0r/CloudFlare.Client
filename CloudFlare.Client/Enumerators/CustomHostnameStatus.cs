using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Status of the hostname's activation
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum CustomHostnameStatus
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
        /// ActiveRedeploying
        /// </summary>
        [EnumMember(Value = "active_redeploying")]
        ActiveRedeploying,

        /// <summary>
        /// Moved
        /// </summary>
        [EnumMember(Value = "moved")]
        Moved,

        /// <summary>
        /// PendingDeletion
        /// </summary>
        [EnumMember(Value = "pending_deletion")]
        PendingDeletion,

        /// <summary>
        /// Deleted
        /// </summary>
        [EnumMember(Value = "deleted")]
        Deleted,

        /// <summary>
        /// PendingBlocked
        /// </summary>
        [EnumMember(Value = "pending_blocked")]
        PendingBlocked,

        /// <summary>
        /// PendingMigration
        /// </summary>
        [EnumMember(Value = "pending_migration")]
        PendingMigration,

        /// <summary>
        /// PendingProvisioned
        /// </summary>
        [EnumMember(Value = "pending_provisioned")]
        PendingProvisioned,

        /// <summary>
        /// TestPending
        /// </summary>
        [EnumMember(Value = "test_pending")]
        TestPending,

        /// <summary>
        /// TestActive
        /// </summary>
        [EnumMember(Value = "test_active")]
        TestActive,

        /// <summary>
        /// TestActiveApex
        /// </summary>
        [EnumMember(Value = "test_active_apex")]
        TestActiveApex,

        /// <summary>
        /// TestBlocked
        /// </summary>
        [EnumMember(Value = "test_blocked")]
        TestBlocked,

        /// <summary>
        /// TestFailed
        /// </summary>
        [EnumMember(Value = "test_failed")]
        TestFailed,

        /// <summary>
        /// Provisioned
        /// </summary>
        [EnumMember(Value = "provisioned")]
        Provisioned,

        /// <summary>
        /// Blocked
        /// </summary>
        [EnumMember(Value = "blocked")]
        Blocked
    }
}
