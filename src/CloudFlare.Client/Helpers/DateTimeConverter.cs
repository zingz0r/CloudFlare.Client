using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace CloudFlare.Client.Helpers;

/// <summary>
/// Converts DateTime to Json with the desired format
/// </summary>
/// <param name="format">Date format to use for serialization/deserialization</param>
/// <param name="removeColonsfromTz">When writing json .Net automatically splits timezone with colon. For ex.: using format "zzz" will always end up +00:00. If you prefer to have it like +0000 set this true.</param>
internal class DateTimeConverter(string format, bool removeColonsfromTz = false) : JsonConverter<DateTime?>
{
    public override DateTime? ReadJson(JsonReader reader, Type objectType, DateTime? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value is null or DateTime)
        {
            return (DateTime?)reader.Value;
        }

        if (!DateTimeOffset.TryParseExact(reader.Value.ToString(), format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
        {
            throw new JsonSerializationException("Invalid date format");
        }

        return date.UtcDateTime;
    }

    public override void WriteJson(JsonWriter writer, DateTime? value, JsonSerializer serializer)
    {
        if (value == null)
        {
            writer.WriteNull();
        }
        else
        {
            var json = value.Value.ToString(format);
            
            if (removeColonsfromTz)
            {
                json = Regex.Replace(json, "(\\+[0-9]{2}):([0-9]{2})", "$1$2", RegexOptions.None);
            }
            
            writer.WriteValue(json);
        }
    }
}
