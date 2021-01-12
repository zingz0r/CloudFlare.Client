using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Parameters
{
    public class DisplayOptions
    {
        /// <summary>
        /// Page number of paginated result
        /// </summary>
        public int? Page { get; set; }
        /// <summary>
        /// Number of elements per pages
        /// </summary>
        public int? PerPage { get; set; }
        /// <summary>
        /// Direction to order
        /// </summary>
        public OrderType? Order { get; set; }
    }
}