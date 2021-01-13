using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Accounts
{
    public class EnterpriseZoneQuota
    {
        [JsonProperty("maximum")]
        public long Maximum { get; set; }

        [JsonProperty("current")]
        public long Current { get; set; }

        [JsonProperty("available")]
        public long Available { get; set; }
    }
}