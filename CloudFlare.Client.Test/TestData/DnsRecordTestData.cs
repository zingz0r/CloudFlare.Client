using System;
using System.Collections.Generic;
using CloudFlare.Client.Api.Zones.DnsRecord;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Test.TestData
{
    public static class DnsRecordTestData
    {
        public static List<DnsRecord> DnsRecords { get; set; } = new()
        {
            new DnsRecord
            {
                Content = "1.1.1.1",
                CreatedDate = DateTime.UtcNow,
                Id = "372e67954025e0ba6aaa6d586b9e0b59",
                Locked = false,
                ModifiedDate = DateTime.UtcNow,
                Name = "tothnet.hu",
                Proxiable = true,
                Proxied = false,
                Ttl = 120,
                Type = DnsRecordType.A,
                ZoneId = "023e105f4ecef8ad9ca31a8372d0c353",
                ZoneName = "tothnet.hu"
            }
        };

        public static List<DnsRecordScan> DnsRecordScans { get; set; } = new()
        {
            new DnsRecordScan
            {
                RecordsAdded = 200,
                RecordsAddedByType = new Dictionary<string, long> { { "tothnet.hu", 200 } },
                TotalRecordsParsed = 2000
            }
        };

        public static List<DnsRecordImport> DnsRecordImports { get; set; } = new()
        {
            new DnsRecordImport
            {
                RecordsAdded = 10,
                TotalRecordsParsed = 10
            }
        };

        public static string Export { get; set; } = @"
        ;;
        ;; Domain:     tothnet.hu.
        ;; Exported:   2021-01-14 11:24:11
        ;;
        ;; This file is intended for use for informational and archival
        ;; purposes ONLY and MUST be edited before use on a production
        ;; DNS server.  In particular, you must:
        ;;   -- update the SOA record with the correct authoritative name server
        ;;   -- update the SOA record with the contact e-mail address information
        ;;   -- update the NS record(s) with the authoritative name servers for this domain.
        ;;
        ;; For further information, please consult the BIND documentation
        ;; located on the following website:
        ;;
        ;; http://www.isc.org/
        ;;
        ;; And RFC 1035:
        ;;
        ;; http://www.ietf.org/rfc/rfc1035.txt
        ;;
        ;; Please note that we do NOT offer technical support for any use
        ;; of this zone data, the BIND name server, or any other third-party
        ;; DNS software.
        ;;
        ;; Use at your own risk.
        ;; SOA Record
        tothnet.hu.	3600	IN	SOA	tothnet.hu. root.tothnet.hu. 2036229005 7200 3600 86400 3600

        ;; A Records
        tothnet-dynamic.tothnet.hu.	1	IN	A	1.1.1.1

        ;; CAA Records
        tothnet.hu.	1	IN	CAA	0 issuewild ""letsencrypt.org""
        tothnet.hu.	1	IN	CAA	0 issuewild ""digicert.com""
        tothnet.hu.	1	IN	CAA	0 issuewild ""comodoca.com""
        tothnet.hu.	1	IN	CAA	0 issue ""digicert.com""
        tothnet.hu.	1	IN	CAA	0 issue ""comodoca.com""
        tothnet.hu.	1	IN	CAA	0 issue ""letsencrypt.org""

        ;; CNAME Records
        *.tothnet.hu.	1	IN	CNAME	tothnet-dynamic.tothnet.hu.
        tothnet.hu.	1	IN	CNAME	tothnet-dynamic.tothnet.hu.
        www.tothnet.hu.	1	IN	CNAME	tothnet-dynamic.tothnet.hu.

        ;; MX Records
        tothnet.hu.	1	IN	MX	10 mail.tothnet.hu.
        mail.tothnet.hu.	1	IN	MX	10 mail.tothnet.hu.

        ;; TXT Records
        tothnet.hu.	1	IN	TXT	""v=spf1 mx mx:mail.tothnet.hu a:mail01d.mail.t-online.hu a:mail00d.mail.t-online.hu a:mail02d.mail.t-online.hu a:mail01k.mail.t-online.hu a:mail00k.mail.t-online.hu a:mail-outd.mail.t-online.hu -all""
        _dmarc.tothnet.hu.	1	IN	TXT	""v=DMARC1; p=quarantine; pct=20;""
        ";
    }
}