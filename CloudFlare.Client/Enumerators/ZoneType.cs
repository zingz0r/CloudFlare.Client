using System.Runtime.Serialization;

namespace CloudFlare.Client.Enumerators
{
    public enum ZoneType
    {
        [EnumMember(Value = "full")]
        Full,

        [EnumMember(Value = "partial")]
        Partial
    }
}