using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using CloudFlare.Client.Contexts;

namespace CloudFlare.Client.Test.Helpers
{
    public static class JsonHelper
    {
        public static IEnumerable<string> GetSerializedKeys<T>(T content)
        {
            var serialized = JsonSerializer.Serialize(content, typeof(T), CloudFlareJsonSerializerContext.Default);

            var json = JsonObject.Parse(serialized) as IDictionary<string, JsonNode>;

            return json.Keys.ToList();
        }

        public static ISet<string> GetSerializedEnums<T>()
        {
            var result = new SortedSet<string>();

            foreach (var enumValue in Enum.GetValues(typeof(T)))
            {
                result.Add(JsonSerializer.Serialize(enumValue, typeof(T), CloudFlareJsonSerializerContext.Default).Replace("\"", string.Empty));
            }

            return result;
        }
    }
}