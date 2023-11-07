
using Newtonsoft.Json;
using ReplayReader.Replay.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayReader.Replay.Configs
{
    public class TechnologyConfig : ConfigDictionary<TechnologyConfig>
    {
        public List<TechnologyConfigUpgrade> Tiers;

        [JsonIgnore]
        public TechnologyLineConfig Line;

        [JsonIgnore]
        public int Index;

        [JsonIgnore]
        public int MaxTier;

        [JsonIgnore]
        public CardConfig OpeningCard;

        public static void Initialize()
        {
        }

        public static void Validate()
        {
        }

        public UpgradeConfig GetMaxTierUpgrade(CardConfig card)
        {
            return null;
        }

        public UpgradeConfig GetUpgradeConfig(int tier, CardConfig card)
        {
            return null;
        }

        //public TechnologyConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
    public class TechnologyLineConfig : ConfigDictionary<TechnologyLineConfig>
    {
        [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<TechnologyConfig>))]
        public List<TechnologyConfig> Technologies;

        public static void Initialize()
        {
        }

        //public TechnologyLineConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
    public class TechnologyConfigUpgrade
    {
        public UpgradeConfig Default;

        [JsonConverter(typeof(ConfigDictionaryConverter<CardConfig, UpgradeConfig>))]
        public Dictionary<CardConfig, UpgradeConfig> Overrides;

        public void Initialize()
        {
        }
    }
}
