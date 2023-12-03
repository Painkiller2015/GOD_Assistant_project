
using Newtonsoft.Json;
using ReplayReader.Replay.Data.Replay.Entitys;

namespace ReplayReader.Replay.Data.Replay.Configs
{
    public class BattlePreparationConfig : ConfigDictionary<BattlePreparationConfig>
    {
        public const int DefaultMissionVoteCount = 3;

        [JsonProperty("preparation_stages")]
        public List<LobbyStageConfig> Stages;

        [JsonProperty("picks_count")]
        public List<int> PicksCount;

        [JsonProperty(PropertyName = "black_list", ItemConverterType = typeof(ConfigRefConverter<CardConfig>))]
        public List<CardConfig> BlackList;

        [JsonProperty("roles_enabled")]
        public bool RolesEnabled;

        [JsonProperty("card_duplicate_enabled")]
        public bool CardDuplicateEnabled;

        [JsonProperty(PropertyName = "pick_order", DefaultValueHandling = DefaultValueHandling.Populate)]
        public Dictionary<OperativeSlotRole, int> PickOrder;

        [JsonProperty("card_exchange_enabled")]
        public bool CardExchangeEnabled;

        [JsonProperty("disband_on_disconnect")]
        public bool DisbandOnDisconnect;

        [JsonProperty("missions_count")]
        public int MissionsCount;

        [JsonProperty("custom_missions_count")]
        public int CustomMissionsCount;

        [JsonIgnore]
        public bool AllPickEnabled;

        public static void Initialize()
        {
        }

        public int GetPicksCount(int stageIndex, int usersCount)
        {
            return 0;
        }

        public int GetStagesCount(int usersCount)
        {
            return 0;
        }

        public static void Validate()
        {
        }

        //public BattlePreparationConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
    public struct LobbyStageConfig
    {
        [JsonProperty("stage_type")]
        public LobbyStageType StageType;

        [JsonProperty("duration")]
        public TimeSpan Duration;

        [JsonProperty("end_delay")]
        public TimeSpan EndDelay;

        public bool IsRequired => false;
    }

    public enum LobbyStageType : byte
    {
        None = 0,
        Wait = 1,
        Ban = 2,
        Pick = 3,
        MissionVoting = 4,
        AllPick = 5,
        FinalPreparation = 6,
        Role = 7,
        BanFinish = 8,
        PickFinish = 9,
        MissionFinish = 10
    }
}
