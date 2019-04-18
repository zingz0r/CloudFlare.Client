using System.Runtime.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the owner types
    /// </summary>
    public enum OwnerType
    {
        [EnumMember(Value = "user")]
        User,

        [EnumMember(Value = "organization")]
        Organization
    }
}
