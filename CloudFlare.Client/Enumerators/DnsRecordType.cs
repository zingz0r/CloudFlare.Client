using System.Runtime.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents DNS record types
    /// </summary>
    public enum DnsRecordType
    {
        [EnumMember(Value = "A")]
        A,

        [EnumMember(Value = "AAAA")]
        Aaaa,

        [EnumMember(Value = "CNAME")]
        Cname,

        [EnumMember(Value = "MX")]
        Mx,

        [EnumMember(Value = "LOC")]
        Loc,

        [EnumMember(Value = "SRV")]
        Srv,

        [EnumMember(Value = "SPF")]
        Spf,

        [EnumMember(Value = "TXT")]
        Txt,

        [EnumMember(Value = "NS")]
        Ns,

        [EnumMember(Value = "CAA")]
        Caa,

        [EnumMember(Value = "PTR")]
        Ptr,

        [EnumMember(Value = "CERT")]
        Cert,

        [EnumMember(Value = "DNSKEY")]
        DnsKey,

        [EnumMember(Value = "DS")]
        Ds,

        [EnumMember(Value = "NAPTR")]
        NaPtr,

        [EnumMember(Value = "SMIMEA")]
        SMimeA,

        [EnumMember(Value = "SSHFP")]
        SshFp,

        [EnumMember(Value = "TLSA")]
        TlsA,

        [EnumMember(Value = "URI")]
        Uri
    }
}
