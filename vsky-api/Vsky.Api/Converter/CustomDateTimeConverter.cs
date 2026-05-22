using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vsky.Api.Converter
{
    public class CustomDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dateString = DateTime.Now.ToString("MM/dd/yyyy");

            return DateTime.ParseExact(dateString, "MM/dd/yyyy", null);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("M/d/yyyy"));
        }
    }
}