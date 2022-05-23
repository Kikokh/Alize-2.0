using System.Text.Json;
using System.Text.Json.Serialization;

namespace Alize.Platform.Infrastructure.Services.BlockchainFue
{
    public class DateTimeTicksConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => new DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(reader.GetInt64());

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) => writer.WriteNumberValue(value.Ticks); // TODO review
    }
}