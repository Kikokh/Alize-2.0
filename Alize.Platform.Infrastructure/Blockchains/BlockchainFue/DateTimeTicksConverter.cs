
using Newtonsoft.Json;

namespace Alize.Platform.Infrastructure.Services.BlockchainFue
{
    public class DateTimeTicksConverter : JsonConverter<DateTime>
    {
        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(reader.Value as long? ?? 0);
        }

        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Ticks);
        }
    }
}