

using Newtonsoft.Json;
using ReplayReader.Replay.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayReader.Replay.Entitys
{
    public class Reward
    {
        [JsonProperty("shopEntries")]
        [JsonConverter(typeof(ConfigDictionaryConverter<ShopEntryConfig, int>))]
        public Dictionary<ShopEntryConfig, int> ShopEntries;

        [JsonProperty("xp")]
        public int Xp;

        [JsonProperty("visual")]
        public string Visual;

        [JsonIgnore]
        public bool HasReward => false;

        public Reward()
        {
        }

        public Reward(ShopEntryConfig entryConfig, int count = 1)
        {
        }

        public Reward Clone()
        {
            return null;
        }

        public static Reward operator +(Reward lhs, Reward rhs)
        {
            return null;
        }

        public static Reward operator *(Reward reward, int multiplier)
        {
            return null;
        }

        public static bool Equals(Reward lhs, Reward rhs)
        {
            return false;
        }

        public bool Equals(Reward rewardObj)
        {
            return false;
        }

        public Money GetMoneyReward()
        {
            return null;
        }

        public int GetCurrencyAmount(CurrencyConfig config)
        {
            return 0;
        }

        public static Reward CalcPremiumReward(Reward regularReward)
        {
            return null;
        }

        private static int CalcPremiumXpReward(int xpReward)
        {
            return 0;
        }
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
