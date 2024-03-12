using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace CloudFlare.Client.Test.Helpers
{
    public static class JsonHelper
    {
        public static IEnumerable<string> GetSerializedKeys<T>(T content)
        {
            var serialized = JsonSerializer.Serialize(content);

            var json = JObject.Parse(serialized);

            return json.Properties().Select(p => p.Name).ToList();
        }

        public static ISet<string> GetSerializedEnums<T>()
        {
            var result = new SortedSet<string>();

            foreach (var enumValue in Enum.GetValues(typeof(T)))
            {
                result.Add(JsonSerializer.Serialize(enumValue).Replace("\"", string.Empty));
            }

            return result;
        }
    }
}