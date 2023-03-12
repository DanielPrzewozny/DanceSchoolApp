using System.Globalization;
using Newtonsoft.Json;

namespace DanceSchoolAPI.Common.Converters;

public class ToUTCFormatConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        if (objectType == typeof(String) || objectType == typeof(DateTime) || objectType == typeof(DateTime?))
        {
            return true;
        }
        return false;
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        if (reader.Value is not null)
        {
            if (objectType == typeof(DateTime) || objectType == typeof(DateTime?))
            {
                var value = Convert.ToDateTime(reader.Value, CultureInfo.InvariantCulture);
                if (value.Kind != DateTimeKind.Utc)
                {
                    return value.ToUniversalTime();
                }
                else
                {
                    return value;
                }
            }
            else if (objectType == typeof(DateTimeOffset) || objectType == typeof(DateTimeOffset?))
            {
                var value = Convert.ToDateTime(reader.Value, CultureInfo.InvariantCulture);
                if (value.Kind != DateTimeKind.Utc)
                {
                    var utcTime1 = DateTime.SpecifyKind(value, DateTimeKind.Utc);
                    DateTimeOffset utcTime2 = utcTime1.ToUniversalTime();
                    return utcTime2;
                }
                else
                {
                    return (DateTimeOffset)value;
                }
            }
            return reader.Value;
        }
        else
        {
            return reader.Value;
        }
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is not null)
        {
            if (value is DateTime || value is DateTime?)
            {
                writer.WriteValue(((DateTime)value).ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ"));
            }
            else if (value is DateTimeOffset || value is DateTimeOffset?)
            {
                writer.WriteValue(((DateTimeOffset)value).UtcDateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ"));
            }
        }
        else
        {
            writer.WriteNull();
        }
    }
}
