using Newtonsoft.Json;
using GameData.Replay.Data.Replay.Entitys;
using System.Runtime.CompilerServices;

namespace GameData.Replay.Data.Replay.Configs
{
    public class CardPresetConfig : ConfigDictionary<CardPresetConfig>, IConfigDisablable
    {
        [JsonConverter(typeof(ConfigRefConverter<CardConfig>))]
        public CardConfig Card;

        public int Level;

        [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<UpgradeConfig>))]
        public List<UpgradeConfig> Upgrades;

        [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<CardProgressSlotConfig>))]
        public List<CardProgressSlotConfig> LevelSlots;

        [JsonConverter(typeof(ConfigDictionaryConverter<ConsumableConfig, int>))]
        public Dictionary<ConsumableConfig, int> ConsumablesCount;

        [JsonConverter(typeof(ConfigRefConverter<ConsumableConfig>))]
        public ConsumableConfig ConsumableOne;

        [JsonConverter(typeof(ConfigRefConverter<ConsumableConfig>))]
        public ConsumableConfig ConsumableTwo;

        public bool EnabledInGame
        {
            [CompilerGenerated]
            get
            {
                return false;
            }
            [CompilerGenerated]
            set
            {
            }
        }

        //public CardPresetConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
}
