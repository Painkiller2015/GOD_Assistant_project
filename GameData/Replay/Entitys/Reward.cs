

using Newtonsoft.Json;

namespace GameData.Replay.Data.Replay.Entitys
{
    public class Reward
    {
        [JsonProperty("shopEntries")]
        //[JsonConverter(typeof(ConfigDictionaryConverter<ShopEntryConfig, int>))]
        public Dictionary<string, int> ShopEntries;

        [JsonProperty("xp")]
        public int Xp;

        [JsonProperty("visual")]
        public string Visual;

        [JsonIgnore]
        public bool HasReward => false;


    }
    public class ConfigDictionaryConverter<T, V> : JsonConverter where T : ConfigDictionary<T>, new()
    {
        private readonly JsonConverter _valueConverter;

        public ConfigDictionaryConverter()
        {
        }

        public ConfigDictionaryConverter(Type value)
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
