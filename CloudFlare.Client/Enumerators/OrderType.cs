using System.Runtime.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the Order direction
    /// </summary>
    public enum OrderType
    {
        [EnumMember(Value = "asc")]
        Asc,

        [EnumMember(Value = "desc")]
        Desc
    }
}
