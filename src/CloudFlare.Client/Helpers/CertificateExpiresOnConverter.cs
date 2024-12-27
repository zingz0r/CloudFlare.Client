using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Helpers;

/// <summary>
/// Formats the certificate expiration date.
/// </summary>
internal class CertificateExpiresOnConverter : DateTimeConverterBase
{
    private const string Format = "yyyy-MM-dd HH:mm:ss zzzz 'UTC'";

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.Value is null || !DateTime.TryParseExact(reader.Value.ToString(), Format, null, System.Globalization.DateTimeStyles.None, out var date))
        {
            throw new JsonSerializationException("Invalid date format");
        }

        return date;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        switch (value)
        {
            case null:
                writer.WriteNull();
                break;
            case DateTime date:
                writer.WriteValue(date.ToString(Format));
                break;
            case DateTimeOffset offset:
                writer.WriteValue(offset.ToString(Format));
                break;
            default:
                throw new JsonSerializationException("Expected date object value.");
        }
    }
}