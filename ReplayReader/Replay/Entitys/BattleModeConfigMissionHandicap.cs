using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayReader.Replay.Entitys
{
    public class BattleModeConfigMissionHandicap
    {
        [JsonProperty(PropertyName = "is_friendly_fire_enabled", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(false)]
        public bool IsFriendlyFireEnabled;

        [JsonProperty(PropertyName = "is_ability_cooldown_on_start", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(false)]
        public bool IsAbilityCooldownOnStart;

        [JsonProperty(PropertyName = "is_death_penalty_enabled", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(false)]
        public bool IsDeathPenaltyEnalbed;

        [JsonProperty(PropertyName = "is_armor_reset_disabled", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(false)]
        public bool IsArmorResetDisabled;

        [DefaultValue(false)]
        [JsonProperty(PropertyName = "is_drop_item_remains_between_rounds", DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool IsDropItemRemainBetweenRounds;

        [DefaultValue(false)]
        [JsonProperty(PropertyName = "is_markers_difficult_for_detect", DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool IsMarkersDifficultForDetect;

        [JsonProperty(PropertyName = "players", DefaultValueHandling = DefaultValueHandling.Populate)]
        public BattleModeConfigPlayerHandicap Players;

        [JsonProperty(PropertyName = "bots", DefaultValueHandling = DefaultValueHandling.Populate)]
        public BattleModeConfigBotHandicap Bots;
    }
    public struct BattleModeConfigPlayerHandicap
    {
        [DefaultValue(1f)]
        [JsonProperty(PropertyName = "hit_mult_head", DefaultValueHandling = DefaultValueHandling.Populate)]
        public float HitBoxMultHead;

        [DefaultValue(1f)]
        [JsonProperty(PropertyName = "hit_mult_body", DefaultValueHandling = DefaultValueHandling.Populate)]
        public float HitBoxMultBody;

        [DefaultValue(1f)]
        [JsonProperty(PropertyName = "hit_mult_legs", DefaultValueHandling = DefaultValueHandling.Populate)]
        public float HitBoxMultLegs;

        [JsonProperty(PropertyName = "fpv_enabled", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(false)]
        public bool FPVEnabled;

        [JsonProperty(PropertyName = "fpv_only", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(false)]
        public bool FPVOnly;
    }
    public struct BattleModeConfigBotHandicap
    {
        [DefaultValue(1f)]
        [JsonProperty(PropertyName = "grenade_happiness", DefaultValueHandling = DefaultValueHandling.Populate)]
        public float GrenadeHappinessMult;

        [JsonProperty(PropertyName = "grenade_targeting", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(1f)]
        public float GrenadeTargetingMult;

        [DefaultValue(1f)]
        [JsonProperty(PropertyName = "lock_on_time_mult", DefaultValueHandling = DefaultValueHandling.Populate)]
        public float LockOnTimeMult;

        [DefaultValue(1f)]
        [JsonProperty(PropertyName = "rotation_rate_yaw", DefaultValueHandling = DefaultValueHandling.Populate)]
        public float RotationRateYawMult;

        [DefaultValue(1f)]
        [JsonProperty(PropertyName = "rotation_rate_pitch", DefaultValueHandling = DefaultValueHandling.Populate)]
        public float RotationRatePitchMult;

        [JsonProperty(PropertyName = "hit_mult_head", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(1f)]
        public float HitBoxMultHead;

        [JsonProperty(PropertyName = "hit_mult_body", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(1f)]
        public float HitBoxMultBody;

        [JsonProperty(PropertyName = "hit_mult_legs", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(1f)]
        public float HitBoxMultLegs;

        [JsonProperty(PropertyName = "bot_cfg_replaces", DefaultValueHandling = DefaultValueHandling.Populate)]
        public Dictionary<string, string> BotCfgReplaces;
    }
}
