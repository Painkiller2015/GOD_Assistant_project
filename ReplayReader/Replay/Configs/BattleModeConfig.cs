using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ReplayReader.Replay.Data.Replay.Entitys;


namespace ReplayReader.Replay.Data.Replay.Configs
{
    public class BattleModeConfig : Entitys.ConfigDictionary<BattleModeConfig>
    {
        public static int MaxMapCount;

        public static BattleModeConfig Default;

        [JsonProperty("visual_effect")]
        public string VisualEffect;

        [JsonProperty("status")]
        public BattleModeStatus Status;

        [JsonProperty("category")]
        public BattleModeCategory Category;

        [JsonProperty("rating_type")]
        public UserRatingType RatingType;

        [JsonProperty("rating_min")]
        public int? RatingMin;

        [JsonProperty("rating_max")]
        public int? RatingMax;

        [JsonProperty("num_teams")]
        public int TeamCount;

        [JsonProperty("min_team_size")]
        private int? _minTeamSize;

        [JsonConverter(typeof(ConfigRefConverter<CardPresetConfig>))]
        [JsonProperty("card_preset")]
        public CardPresetConfig CardPreset;

        [JsonProperty("slots", ItemConverterType = typeof(StringEnumConverter))]
        public List<OperativeSlotRole> Slots;

        [JsonProperty("missions")]
        public List<BattleModeConfigMission> Missions;

        [JsonProperty("brackets")]
        public List<BattleModeConfigBracket> Brackets;

        [JsonProperty("difficulty")]
        public int Difficulty;

        [JsonProperty("flags")]
        public uint Flags;

        [JsonProperty("not_owned_card")]
        public bool NotOwnedCard;

        [JsonProperty("hide_postbattle")]
        public bool HidePostbattle;

        [JsonProperty("modifiers")]
        public BattleModeConfigMissionHandicap Modifiers;

        [JsonProperty(PropertyName = "restricted_collections", ItemConverterType = typeof(ConfigRefConverter<CollectionConfig>))]
        public List<CollectionConfig> RestrictedCollections;

        [JsonProperty(PropertyName = "allowed_collections", ItemConverterType = typeof(ConfigRefConverter<CollectionConfig>))]
        public List<CollectionConfig> AllowedCollections;

        [JsonProperty("min_operator_level")]
        public int MinOperatorLevel;

        [JsonProperty("min_level")]
        public int MinLevel;

        [JsonConverter(typeof(ConfigRefConverter<BattlePreparationConfig>))]
        [JsonProperty("battle_preparation")]
        public BattlePreparationConfig BattlePreparation;

        [JsonProperty("role_queue")]
        public RoleQueueType RoleQueue;

        [JsonProperty("anti_cheat_disabled")]
        public bool AntiCheatDisabled;

        [JsonProperty("default")]
        public bool IsDefault;

        [JsonIgnore]
        public Visuals.GameMode Visual;

        [JsonIgnore]
        public int MinTeamSize => 0;

        [JsonIgnore]
        public int MaxTeamSize => 0;

        [JsonIgnore]
        public int RequiredUserCount => 0;

        [JsonIgnore]
        public int MaxUserCount => 0;

        [JsonIgnore]
        public bool RoleQueueEnabled => false;

        public string DifficultyName => null;

        [JsonIgnore]
        public bool IsPrologue => false;

        [JsonIgnore]
        public bool IsPolygon => false;

        [JsonIgnore]
        public bool IsHacking => false;

        [JsonIgnore]
        public bool IsPvehard => false;

        [JsonIgnore]
        public bool IsOnslaught => false;

        [JsonIgnore]
        public bool IsPvpve => false;

        [JsonIgnore]
        public bool IsPvpve2 => false;

        [JsonIgnore]
        public bool IsPvpdestruction => false;

        [JsonIgnore]
        public bool IsPvp => false;

        [JsonIgnore]
        public bool HasMmr => false;

        [JsonIgnore]
        public bool IsRanked => false;

        [JsonIgnore]
        public bool RoleCountersDisabled => false;

        [JsonIgnore]
        public bool RoleTimeCountersEnabled => false;

        [JsonIgnore]
        public bool HasCollectionsRestrictions => false;
    }
    public class BattleModeConfigBracket
    {
        [JsonProperty("id")]
        public string BracketId;

        [JsonProperty("start_at")]
        public DateTime StartTime;

        [JsonProperty("end_at")]
        public DateTime EndTime;

        [JsonProperty("modifiers")]
        public BattleModeConfigMissionHandicap Modifiers;

        [JsonProperty("missions")]
        public List<BattleModeConfigMission> Missions;

        public bool IsActive(DateTime time)
        {
            return false;
        }
    }
    
    public enum BattleModeStatus
    {
        Enabled = 0,
        Disabled = 1,
        Hidden = 2
    }
    public enum BattleModeCategory
    {
        None = 0,
        PvE = 1,
        PvP = 2,
        PvPvE = 3,
        PvPvE2 = 4
    }
    
    public enum UserRatingType
    {
        None = 0,
        PvE = 1,
        PvP = 2,
        PvEHard = 3,
        PvPRanked = 4
    }
    [Utils.GenerateJs]
    public enum CondMatchType
    {
        PVP = 0,
        PVE = 1,
        HardPVE = 2,
        Hacking = 3,
        PVPVE = 4,
        PVPranked = 5,
        Prologue = 6,
        OnslaughtEasy = 7,
        OnslaughtNormal = 8,
        OnslaughtHard = 9,
        Intercept = 10,
        PVPFPP = 11,
        PVPDestruction = 12,
        PVPVE2 = 13
    }
    public enum RoleQueueType
    {
        None = 0,
        Single = 1,
        Multiple = 2,
        MultipleOneCard = 3
    }
    public class BattleModeConfigMission
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("maps")]
        public string[] Maps;

        [JsonProperty("segments")]
        public int[] Segments;

        public int[] GetRandomSegments(Random random)
        {
            return null;
        }
    }
}
