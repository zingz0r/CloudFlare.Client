using System;
using CloudFlare.Client.Attributes;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Extensions;

internal static class DnsRecordTypeExtensions
{
    internal static void EnsureIsDataType(this DnsRecordType dnsRecordType)
    {
        var fieldInfo = typeof(DnsRecordType).GetField(dnsRecordType.ToString());
        if (!fieldInfo.IsDefined(typeof(DataTypeDnsRecordAttribute), false))
        {
            throw new NotSupportedException($"{dnsRecordType} is not data type");
        }
    }
    
    internal static void EnsureIsNotDataType(this DnsRecordType dnsRecordType)
    {
        var fieldInfo = typeof(DnsRecordType).GetField(dnsRecordType.ToString());
        if (fieldInfo.IsDefined(typeof(DataTypeDnsRecordAttribute), false))
        {
            throw new NotSupportedException($"{dnsRecordType} is data type");
        }
    }
}