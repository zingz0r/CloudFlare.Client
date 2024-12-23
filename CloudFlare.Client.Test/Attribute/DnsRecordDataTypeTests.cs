using System;
using CloudFlare.Client.Attributes;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Extensions;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Attribute;

public class DnsRecordDataTypeTests
{
    [Theory]
    [MemberData(nameof(EnumHelper<DnsRecordType>.GetValuesOfWithoutAttribute), typeof(DataTypeDnsRecordAttribute), MemberType = typeof(EnumHelper<DnsRecordType>))]
    public void NotDataTypedDnsRecord_EnsureIsNotDataType_NoException(DnsRecordType dnsRecordType)
    {
        Action act = () => dnsRecordType.EnsureIsNotDataType();

        act.Should().NotThrow();
    }

    [Theory]
    [MemberData(nameof(EnumHelper<DnsRecordType>.GetValuesOfWithoutAttribute), typeof(DataTypeDnsRecordAttribute), MemberType = typeof(EnumHelper<DnsRecordType>))]
    public void NotDataTypedDnsRecord_EnsureIsDataType_NotSupportedException(DnsRecordType dnsRecordType)
    {
        Action act = () => dnsRecordType.EnsureIsDataType();

        act.Should().Throw<NotSupportedException>();
    }

    [Theory]
    [MemberData(nameof(EnumHelper<DnsRecordType>.GetValuesOfWithAttribute), typeof(DataTypeDnsRecordAttribute), MemberType = typeof(EnumHelper<DnsRecordType>))]
    public void DataTypedDnsRecord_EnsureIsDataType_NoException(DnsRecordType dnsRecordType)
    {
        Action act = () => dnsRecordType.EnsureIsDataType();

        act.Should().NotThrow();
    }

    [Theory]
    [MemberData(nameof(EnumHelper<DnsRecordType>.GetValuesOfWithAttribute), typeof(DataTypeDnsRecordAttribute), MemberType = typeof(EnumHelper<DnsRecordType>))]
    public void DataTypedDnsRecord_EnsureIsNotDataType_NotSupportedException(DnsRecordType dnsRecordType)
    {
        Action act = () => dnsRecordType.EnsureIsNotDataType();

        act.Should().Throw<NotSupportedException>();
    }
}