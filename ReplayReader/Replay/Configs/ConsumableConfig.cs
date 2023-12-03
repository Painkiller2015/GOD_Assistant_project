using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReplayReader.Replay.Data.Replay.Entitys;

namespace ReplayReader.Replay.Data.Replay.Configs
{
    public class ConsumableConfig : ConfigDictionary<ConsumableConfig>
    {
        public EquipmentItemConfig Item;

        [JsonProperty("default")]
        public EquipmentItemConfig.EquipmentItemConfigOption Default;

        [JsonProperty("activeAbility")]
        public EquipmentItemConfig.EquipmentItemConfigOption ActiveAbility;

        
        public ConsumableType ConsumableType;

        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public List<SlotType> CompatibleSlots;

        [JsonConverter(typeof(ConfigRefConverter<CurrencyConfig>))]
        [JsonProperty("CurrencyId")]
        public CurrencyConfig Currency;

        [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<CollectionConfig>))]
        public HashSet<CollectionConfig> RestrictedCollections;

        [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<CollectionConfig>))]
        public HashSet<CollectionConfig> AllowedCollections;

        [JsonIgnore]
        public ShopEntryConfig ShopEntry;

        [JsonIgnore]
        public SlotType slot => default;

        [JsonIgnore]
        public int slotIndex => 0;

        [JsonIgnore]
        public bool IsInfinite => false;

        public static void Initialize()
        {
        }

        public bool CheckCompatibility(CollectionConfig collection)
        {
            return false;
        }

        public static ConsumableConfig GetAvailable(SlotType slot, CollectionConfig collection)
        {
            return null;
        }

        //public ConsumableConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
    public enum ConsumableType
    {
        None = 0,
        StaminaRegenBooster = 1,
        HealthPack = 2,
        SpecialRevive = 3,
        AmmoPack = 4,
        ArmorPack = 5,
        TeamAmmoBox = 6,
        TeamArmorBag = 7,
        DefendPointsBooster = 8,
        RandomBonus = 9,
        PerkTierUpgrade = 10,
        SpecialReviveV2 = 11,
        HealthPackV2 = 12,
        AmmoPackV2 = 13,
        Total = 14
    }
}
