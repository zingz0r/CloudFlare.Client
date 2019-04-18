using System;
using System.IO;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            const string email = "secret";
            const string globalApiKey = "secret";
            var zoneId = "secret";
            var savePath = @"C:\Users\zingz0r\Desktop\exportBindTest.txt";

            CloudFlareClient cloudFlareClient = new CloudFlareClient(email, globalApiKey);

            var zones = cloudFlareClient.GetZonesAsync().Result;

            var file = new FileInfo(savePath);
            var importedResult = cloudFlareClient.ImportDnsRecordsAsync(zoneId, file, true).Result;

            var exportedDataBytes = cloudFlareClient.ExportDnsRecordsAsync(zoneId).Result;
            
            using (var fs = new FileStream(savePath, FileMode.Create, FileAccess.ReadWrite))
            {
                TextWriter tw = new StreamWriter(fs);
                tw.Write(exportedDataBytes);
                tw.Flush();
            }

            var dnsRecords = cloudFlareClient.GetDnsRecordsAsync(zoneId).Result;

            var newDnsRecord = cloudFlareClient.CreateDnsRecordAsync(zoneId, DnsRecordType.A, "cloudlareclient", "1.1.1.1", 120, 3).Result;

            var detailsDnsRecord = cloudFlareClient.GetDnsRecordDetailsAsync(zoneId, newDnsRecord.Result.Id).Result;

            var updateDnsRecord = cloudFlareClient.UpdateDnsRecordAsync(zoneId, detailsDnsRecord.Result.Id, DnsRecordType.A, "cloudflareclient", "2.2.2.2", 300).Result;

            var deleteDnsRecord = cloudFlareClient.DeleteDnsRecordAsync(zoneId, updateDnsRecord.Result.Id).Result;

        }
    }
}
