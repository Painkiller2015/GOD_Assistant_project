
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using ReplayReader.Replay.Data.Replay.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReplayReader.Replay.Data.Replay.Configs
{
    public class EquipmentItemConfig : ConfigDictionary<EquipmentItemConfig>
    {
        public class EquipmentItemConfigOption : IConfigDisablable
        {
            public string visual;

            public string localesKey;

            [JsonConverter(typeof(ConfigRefConverter<DropItemConfig>))]
            public DropItemConfig dropItem;

            [JsonConverter(typeof(ConfigRefConverter<DropItemConfig>))]
            public DropItemConfig wrongPlacementDropItem;

            [JsonConverter(typeof(ConfigRefConverter<DropItemConfig>))]
            public DropItemConfig secondDropItem;

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public bool secondFireModeOnHold;

            
            public SlotType slot;

            [JsonProperty("linked_visual_slot")]
            
            public SlotType? linkedVisualSlot;

            
            public WeaponSpeciality speciality;

            
            public ExplosiveWeaponSubtype explosiveWeaponSubtype;

            
            public EquipmentItemType itemType;

            
            public WeaponStrategyType strategyType;

            public string fxType;

            public string deployVisualizerType;

            public string deployProcessVisualType;

            public string explosionFxType;

            public string explosionFxTypeInSky;

            public string hitFxOverride;

            public string hitFxOverrideEnemy;

            public bool hideBloodDecal;

            [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<UpgradeConfig>))]
            public List<UpgradeConfig> upgrades;

            [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<AbilityConfig>))]
            public List<AbilityConfig> passiveAbilities;

            public ParamModifierConfig modifiers;

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
        }

        [JsonProperty("default")]
        public EquipmentItemConfigOption Default;

        [JsonProperty("activeAbility")]
        public EquipmentItemConfigOption ActiveAbility;

        public static void Initialize()
        {
        }

        //public EquipmentItemConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
    public class DropItemConfigMeta
    {
        [JsonProperty(PropertyName = "modifiers")]
        public ParamModifierConfig Modifiers;
    }
    public class DropItemConfig : ConfigDictionary<DropItemConfig>, IConfigRaw
    {
        [JsonProperty(PropertyName = "meta_data")]
        public DropItemConfigMeta Meta;

        [JsonIgnore]
        public JObject Raw
        {
            [CompilerGenerated]
            get
            {
                return null;
            }
            [CompilerGenerated]
            set
            {
            }
        }

        //public DropItemConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
    public enum WeaponSpeciality
    {
        Common = 0,
        Sniper = 1,
        GrenadeLauncher = 2,
        RocketLauncher = 3,
        Deploy = 4,
        Airstrike = 5,
        Total = 6
    }
    public enum ExplosiveWeaponSubtype
    {
        None = 0,
        Grenade = 1,
        Airstrike = 2,
        Cloak = 3,
        Poison = 4,
        FlashBang = 5,
        Rocket = 6,
        Mine = 7,
        DirectedMine = 8,
        Sticky = 9,
        Total = 10
    }
    public enum EquipmentItemType
    {
        Common = 0,
        Pistol = 1,
        AssaultRifle = 2,
        SniperRifle = 3,
        Shotgun = 4,
        LMG = 5,
        SMG = 6,
        Explosive = 7,
        Consumable = 8,
        Melee = 9,
        Total = 10
    }
    public enum WeaponStrategyType
    {
        Fire = 0,
        Deploy = 1,
        Buff = 2,
        Airstrike = 3,
        MeleeAxe = 4,
        MeleeRam = 5,
        Total = 6
    }
}
