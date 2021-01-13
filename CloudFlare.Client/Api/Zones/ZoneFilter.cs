using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Zones
{
    public class ZoneFilter
    {
        /// <summary>
        /// A domain name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Status of the zone<
        /// </summary>
        public ZoneStatus? Status { get; set; }
        /// <summary>
        /// Whether to match all search requirements or at least one
        /// </summary>
        public bool? Match { get; set; }
    }
}