using System;
using CloudFlare.Client.Attributes;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Extensions;

internal static class DnsRecordTypeExtensions
{
    internal static void EnsureIsDataType(this DnsRecordType dnsRecordType)
    {
        if(!dnsRecordType.IsDataType())
        { 
            throw new NotSupportedException($"{dnsRecordType} is not data type");
        }
    }
    
    internal static void EnsureIsNotDataType(this DnsRecordType dnsRecordType)
    {
        if (dnsRecordType.IsDataType())
        {
            throw new NotSupportedException($"{dnsRecordType} is data type");
        }
    }

    internal static bool IsDataType(this DnsRecordType dnsRecordType)
    {
        return typeof(DnsRecordType).GetField(dnsRecordType.ToString()).IsDefined(typeof(DataTypeDnsRecordAttribute), false);
    }
}