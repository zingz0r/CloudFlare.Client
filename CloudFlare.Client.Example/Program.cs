using System;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudFlareClient cloudFlareClient = new CloudFlareClient("admin@example.com", "globalApiKey");
            var newDnsRecord = cloudFlareClient.CreateDnsRecordAsync("zoneid",
                DnsRecordType.A, "example.com", "1.1.1.1",120,3).Result;
        }
    }
}
