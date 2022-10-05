using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Zones.DnsRecord
{
    /// <summary>
    /// Dns record filter
    /// </summary>
    public class DnsRecordFilter
    {
        /// <summary>
        /// DNS record type
        /// </summary>
        public DnsRecordType? Type { get; set; }

        /// <summary>
        /// DNS record name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// DNS record content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Whether to match all search requirements or at least one
        /// </summary>
        public MatchType? Match { get; set; }
    }
}
