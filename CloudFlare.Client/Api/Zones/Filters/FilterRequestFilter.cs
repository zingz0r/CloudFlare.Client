
namespace CloudFlare.Client.Api.Zones.Filters
{
    public class FilterRequestFilter
    {
        /// <summary>
        /// Filter identifier
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Whether this filter is currently paused
        /// </summary>
        public bool? Paused { get; set; }
        
        /// <summary>
        /// Case-insensitive string to find in expression
        /// </summary>
        public string Expression { get; set; }
        
        /// <summary>
        /// Case-insensitive string to find in description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Exact match search on a ref
        /// </summary>
        public string Ref { get; set; }
    }
}