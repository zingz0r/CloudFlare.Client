using System.Runtime.Serialization;
using CloudFlare.Client.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators;

/// <summary>
/// Represents DNS record types
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum DnsRecordType
{
    /// <summary>
    /// A record
    /// </summary>
    [EnumMember(Value = "A")]
    A,

    /// <summary>
    /// AAAA record
    /// </summary>
    [EnumMember(Value = "AAAA")]
    Aaaa,

    /// <summary>
    /// CNAME record
    /// </summary>
    [EnumMember(Value = "CNAME")]
    Cname,

    /// <summary>
    /// MX record
    /// </summary>
    [EnumMember(Value = "MX")]
    Mx,

    /// <summary>
    /// LOC record
    /// </summary>
    [EnumMember(Value = "LOC")]
    Loc,

    /// <summary>
    /// SRV record
    /// </summary>
    [DataTypeDnsRecord]
    [EnumMember(Value = "SRV")]
    Srv,

    /// <summary>
    /// SPF record
    /// </summary>
    [EnumMember(Value = "SPF")]
    Spf,

    /// <summary>
    /// TXT record
    /// </summary>
    [EnumMember(Value = "TXT")]
    Txt,

    /// <summary>
    /// NS record
    /// </summary>
    [EnumMember(Value = "NS")]
    Ns,

    /// <summary>
    /// CAA record
    /// </summary>
    [EnumMember(Value = "CAA")]
    Caa,

    /// <summary>
    /// PTR record
    /// </summary>
    [EnumMember(Value = "PTR")]
    Ptr,

    /// <summary>
    /// CERT record
    /// </summary>
    [EnumMember(Value = "CERT")]
    Cert,

    /// <summary>
    /// DNSKEY record
    /// </summary>
    [EnumMember(Value = "DNSKEY")]
    DnsKey,

    /// <summary>
    /// DS record
    /// </summary>
    [EnumMember(Value = "DS")]
    Ds,

    /// <summary>
    /// NAPTR record
    /// </summary>
    [EnumMember(Value = "NAPTR")]
    NaPtr,

    /// <summary>
    /// SMIMEA record
    /// </summary>
    [EnumMember(Value = "SMIMEA")]
    SMimeA,

    /// <summary>
    /// SSHFP record
    /// </summary>
    [EnumMember(Value = "SSHFP")]
    SshFp,

    /// <summary>
    /// TLSA record
    /// </summary>
    [DataTypeDnsRecord]
    [EnumMember(Value = "TLSA")]
    TlsA,

    /// <summary>
    /// URI record
    /// </summary>
    [EnumMember(Value = "URI")]
    Uri
}
