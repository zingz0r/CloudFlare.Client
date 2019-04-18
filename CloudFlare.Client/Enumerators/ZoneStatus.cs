using System.Runtime.Serialization;

namespace CloudFlare.Client.Enumerators
{
    public enum ZoneStatus
    {
        [EnumMember(Value = "active")]
        Active,

        [EnumMember(Value = "pending")]
        Pending,

        [EnumMember(Value = "initializing")]
        Initializing,

        [EnumMember(Value = "moved")]
        Moved,

        [EnumMember(Value = "deleted")]
        Deleted,

        [EnumMember(Value = "deactivated")]
        Deactivated
    }
}