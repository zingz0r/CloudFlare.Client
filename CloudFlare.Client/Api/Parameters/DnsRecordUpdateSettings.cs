namespace CloudFlare.Client.Api.Parameters
{
    public class DnsRecordUpdateSettings
    {
        /// <summary>
        /// Time to live for DNS record. Value of 1 is 'automatic'
        /// </summary>
        public int? Ttl { get; set; }
        /// <summary>
        /// Whether the record is receiving the performance and security benefits of CloudFlare
        /// </summary>
        public bool? Proxied { get; set; }
    }
}
