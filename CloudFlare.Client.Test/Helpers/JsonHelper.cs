using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CloudFlare.Client.Test.Helpers
{
    public static class JsonHelper
    {
        public static IEnumerable<string> GetSerializedKeys<T>(T content)
        {
            var serialized = JsonConvert.SerializeObject(content);

            var json = JObject.Parse(serialized);

            return json.Properties().Select(p => p.Name).ToList();
        }
    }
}