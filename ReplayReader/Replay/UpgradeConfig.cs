﻿


using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayReader.Replay
{
    public class UpgradeConfig : ConfigDictionary<UpgradeConfig>
    {
        [JsonProperty("visual")]
        public string Visual;

        [JsonProperty("localesKey")]
        public string LocalesKey;

        [JsonProperty("typeLocalesKey")]
        public string TypeLocalesKey;

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("slot")]
        public SlotType Slot;

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("unlockableSlot")]
        public SlotType UnlockableSlot;

        [JsonProperty("moduleType")]
        [JsonConverter(typeof(VisualConverter<Visuals.Module>))]
        public Visuals.Module ModuleType;

        [JsonProperty("soundUpgrade", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public SoundUpgradeType SoundUpgrade;

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("bulletVisualOverride", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Visuals.BulletType BulletVisualOverride;

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("attachment")]
        public ItemUpgradeAttachment Attachment;

        [JsonProperty("price")]
        public Money Price;

        [JsonProperty("autoInstall")]
        public bool AutoInstall;

        [JsonProperty("uninstallable")]
        public bool Uninstallable;

        [JsonProperty("workInProgress")]
        public bool WorkInProgress;

        [JsonProperty("passiveAbilities", ItemConverterType = typeof(ConfigRefConverter<AbilityConfig>))]
        public List<AbilityConfig> PassiveAbilities;

        [JsonProperty("modifiers")]
        public ParamModifierConfig Modifiers;

        public static void Initialize()
        {
        }

        //public UpgradeConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
    public enum SoundUpgradeType
    {
        None = 0,
        Magnum = 1,
        ExplosiveDamage = 2,
        Total = 3
    }
    public enum ItemUpgradeAttachment
    {
        None = -1,
        top = 0,
        front = 1,
        side = 2,
        back = 3,
        underbarrel = 4,
        mag = 5,
        wear_slot = 6,
        ammo = 7,
        Total = 8
    }
}
