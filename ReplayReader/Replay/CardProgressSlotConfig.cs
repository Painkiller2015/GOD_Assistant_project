
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReplayReader.Replay
{
    public class CardProgressSlotConfig : ConfigDictionary<CardProgressSlotConfig>
    {
        [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<UpgradeConfig>))]
        public List<UpgradeConfig> Upgrades;

        [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<ShopEntryConfig>))]
        public List<ShopEntryConfig> ShopItems;

        [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<TechnologyConfig>))]
        public List<TechnologyConfig> Technologies;

        public bool UnlockTechnologySlot;

        [JsonConverter(typeof(ConfigRefConverter<CardProgressSlotConfig>))]
        public CardProgressSlotConfig Required;

        [JsonIgnore]
        public CardProgressSlotConfig Dependent;

        [JsonIgnore]
        public int CardLevelNum;

        [JsonIgnore]
        public CardConfig.ProgressLevel ProgressLevel;

        [JsonIgnore]
        public UpgradeConfig Upgrade => null;

        [JsonIgnore]
        public TechnologyConfig Technology => null;

        [JsonIgnore]
        public ShopEntryConfig ShopItem => null;

        [JsonIgnore]
        public int TechnologyTear
        {
            [CompilerGenerated]
            get
            {
                return 0;
            }
            [CompilerGenerated]
            set
            {
            }
        }

        [JsonIgnore]
        public int UnlockTechnologySlotNumber
        {
            [CompilerGenerated]
            get
            {
                return 0;
            }
            [CompilerGenerated]
            set
            {
            }
        }

        public static void Initialize()
        {
        }

        //public CardProgressSlotConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
}
