using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Display
{
    public class DisplayOptions : UnOrderableDisplayOptions
    {
        /// <summary>
        /// Direction to order
        /// </summary>
        public OrderType? Order { get; set; }
    }
}