using System;
using Newtonsoft.Json;

namespace ReplayReader.Replay.Entitys
{
    public class ConfigRefConverter<T> : JsonConverter where T : ConfigDictionary<T>, new()
    {
        private readonly bool _weak;

        public ConfigRefConverter()
        {
        }

        public ConfigRefConverter(bool weak)
        {
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
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
