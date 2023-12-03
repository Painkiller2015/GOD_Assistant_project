using Newtonsoft.Json;

namespace GameData.Replay.Data.Replay.Entitys
{
    public class VisualConverter<T> : JsonConverter where T : Enum
    {
        private readonly bool _warning;

        public VisualConverter()
        {
        }

        public VisualConverter(bool warning = true)
        {
        }

        public override void WriteJson(JsonWriter writer, object enumValue, JsonSerializer serializer)
        {
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
}
