
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ReplayReader.Replay.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReplayReader.Replay
{
    public class CardConfig : ConfigDictionary<CardConfig>, IConfigDisablable
    {
        public class ProgressLevel
        {
            [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<CardProgressSlotConfig>))]
            public List<CardProgressSlotConfig> Tree;

            [JsonConverter(typeof(ConfigRefConverter<CardProgressSlotConfig>))]
            public CardProgressSlotConfig Line;

            [JsonIgnore]
            public CardConfig Card;

            [JsonIgnore]
            public int Index;

            [JsonIgnore]
            public ProgressLevel Prev;

            [JsonIgnore]
            public ProgressLevel Next;

            [JsonIgnore]
            public CardProgressLineConfig.Level Progress;

            [JsonIgnore]
            public List<CardProgressSlotConfig> AllSlots;

            [JsonIgnore]
            public List<UpgradeConfig> AllUpgrades;

            [JsonIgnore]
            public List<ShopEntryConfig> AllShopItems;

            [JsonIgnore]
            public List<TechnologyConfig> AllTechnologies;
        }

        [JsonConverter(typeof(VisualConverter<Visuals.CardModel>))]
        public Visuals.CardModel visual;

        [JsonConverter(typeof(ConfigRefConverter<CollectionConfig>))]
        public CollectionConfig collection;

        public PlayerRole role;

        public ParamModifierConfig modifiers;

        [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<EquipmentItemConfig>))]
        public Dictionary<SlotType, EquipmentItemConfig> items;

        [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<AbilityConfig>))]
        public Dictionary<SlotType, AbilityConfig> abilities;

        [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<AbilityConfig>))]
        public List<AbilityConfig> passiveAbilities;

        [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<ShopEntryConfig>))]
        public List<ShopEntryConfig> defaultShopItems;

        [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<UpgradeConfig>))]
        public List<UpgradeConfig> defaultUpgrades;

        [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<ShopEntryConfig>))]
        public List<ShopEntryConfig> historicalSkinSets;

        [JsonConverter(typeof(ConfigRefConverter<CardProgressLineConfig>))]
        public CardProgressLineConfig progressLine;

        public List<ProgressLevel> progressLevels;

        [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<UpgradeConfig>))]
        public HashSet<UpgradeConfig> upgrades;

        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public HashSet<SlotType> unlockableSlots;

        public FarmerBonus farmerBonus;

        [JsonProperty(PropertyName = "operator_labels")]
        [JsonConverter(typeof(BitMaskEnumConverter<OperatorLabels>))]
        public int OperatorLabels;

        [JsonProperty("progressSlotsPreset", ItemConverterType = typeof(ConfigRefConverter<CardProgressSlotConfig>))]
        public List<CardProgressSlotConfig> ProgressSlotsPreset;

        [JsonIgnore]
        public readonly List<UpgradeConfig> levelUpgrades;

        [JsonIgnore]
        public readonly List<CardProgressSlotConfig> levelSlots;

        [JsonIgnore]
        public readonly Dictionary<LevelType, int> majorLevelsXp;

        [JsonIgnore]
        public ShopEntryConfig ShopEntry;

        [JsonIgnore]
        public TechnologyConfig PersonalTechnology;

        [JsonIgnore]
        public readonly List<SkinGroupConfig> DefaultSkinGroups;

        [JsonProperty("enabledInGame")]
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

        [JsonIgnore]
        public OperativeSlotRole SlotRole => default(OperativeSlotRole);

        [JsonIgnore]
        public int LastLevelXp => 0;

        [JsonIgnore]
        public List<UpgradeConfig> ZeroLevelUpgrades => null;

        public static void Initialize()
        {
        }

        public FarmerBonus GetFarmerBonus(int farmerBonusLevel)
        {
            return default(FarmerBonus);
        }

        public ProgressLevel GetLevelByXp(int xp)
        {
            return null;
        }

        public ProgressLevel GetLevelUpPointByLevelSlot(CardProgressSlotConfig slot)
        {
            return null;
        }

        public ProgressLevel GetNextLevelUpPointByXp(long xp)
        {
            return null;
        }

        public ProgressLevel GetPreviousLevelUpPointByLevelSlot(CardProgressSlotConfig slot)
        {
            return null;
        }

        public CardProgressSlotConfig GetLevelSlotByUpgrade(UpgradeConfig upgrade)
        {
            return null;
        }

        public int GetLevelXpByLevelSlot(CardProgressSlotConfig slot)
        {
            return 0;
        }

        public Money CalcFreeXpConversionPrice(int priceIndex, long currentXp, long additiveXp)
        {
            return null;
        }

        //public CardConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PlayerRole
    {
        None = -1,
        Assault = 0,
        Sniper = 1,
        Medic = 2,
        Gunner = 3,
        Fighter = 4,
        Shooter = 5,
        Rocketman = 6,
        Shield = 7,
        HeavyFighter = 8,
        Commander = 9,
        Chemist = 10,
        Hostage = 11,
        Leader = 12,
        Sergeant = 13,
        Informer = 14,
        KarhadSoldier = 15,
        Total = 16
    }
    public struct FarmerBonus
    {
        public int Soft;

        public int Xp;

        public int ExpeditionXp;
    }
    [Flags]
    public enum OperativeSlotRole : byte
    {
        None = 0,
        Assault = 1,
        Gunner = 2,
        Medic = 4,
        Sniper = 8,
        All = 0xF
    }
    [Flags]
    public enum LevelType
    {
        Normal = 0,
        Elite = 1,
        Master = 2,
        Zero = 4,
        Last = 8
    }
    [GenerateJs]
    public enum SlotType
    {
        None = -1,
        PrimaryWeapon = 0,
        SecondaryWeapon = 1,
        HeavyWeapon = 2,
        Body = 3,
        Boots = 4,
        Hands = 5,
        Head = 6,
        Outfit = 7,
        PrimaryAbility = 8,
        SecondaryAbility = 9,
        MovementAbility = 10,
        ConsumableOne = 11,
        ConsumableTwo = 12,
        Total = 13
    }
    [Flags]
    public enum OperatorLabels
    {
        None = 0,
        NegativeVisibility = 1,
        NegativeAim = 2,
        Stun = 4,
        PhysicalDOT = 8,
        PoisonDOT = 0x10,
        NegativeMovement = 0x20,
        FireDOT = 0x40,
        NegativeAbility = 0x80,
        PositiveHealth = 0x100,
        PositiveBuff = 0x200
    }
    public class BitMaskEnumConverter<T> : JsonConverter where T : Enum
    {
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
