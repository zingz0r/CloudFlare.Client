namespace CloudFlare.Client.Api.Parameters
{
    public class DnsRecordProperties
    {
        /// <summary>
        /// Time to live for DNS record. Value of 1 is 'automatic'
        /// </summary>
        public int? Ttl { get; set; }
        /// <summary>
        /// Used with some records like MX and SRV to determine priority. If you do not supply a priority for an MX record, a default value of 0 will be set
        /// </summary>
        public int? Priority { get; set; }
        /// <summary>
        /// Whether the record is receiving the performance and security benefits of CloudFlare
        /// </summary>
        public bool? Proxied { get; set; }
    }
}