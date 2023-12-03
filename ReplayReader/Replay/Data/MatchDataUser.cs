using Newtonsoft.Json;
using ReplayReader.Replay.Data.Replay.Configs;
using ReplayReader.Replay.Data.Replay.Entitys;
using System.Runtime.CompilerServices;
using static ReplayReader.Replay.Data.Replay.Entitys.Visuals;


namespace ReplayReader.Replay.Data.Replay.Data
{
    public class MatchDataUser
    {
        [JsonProperty(PropertyName = "0")]
        public long UserId;

        [JsonProperty(PropertyName = "1")]
        public long PartyId;

        [JsonProperty(PropertyName = "2")]
        public string Nickname;

        [JsonProperty(PropertyName = "3")]
        public int Level;

        [JsonProperty(PropertyName = "4")]
        [JsonFilter(~JsonFilterFlags.Client)]
        public int Rating;

        [JsonProperty(PropertyName = "5")]
        // [JsonConverter(typeof(ConfigRefConverter<UserbarConfig>))]
        public string Userbar;

        [JsonProperty(PropertyName = "6")]
        public bool HasPremium;

        [JsonProperty(PropertyName = "7")]
        public Guid LoadoutId;

        [JsonProperty(PropertyName = "8")]
        public CardData Card;

        [JsonProperty(PropertyName = "9")]
        public int[] Consumables;

        [JsonProperty(PropertyName = "10")]
        public int ReportPushesRemain;

        [JsonProperty(PropertyName = "11")]
        public List<MatchDataUserQuest> QuestProgress;

        [JsonProperty(PropertyName = "12")]
        public int QuestCurrentWeeklyChapter;

        [JsonProperty(PropertyName = "13")]
        public int QuestTotalWeeklyChapters;

        [JsonProperty(PropertyName = "16")]
        public RankedSeasonData RankedSeason;

        [JsonProperty(PropertyName = "17")]
        //[JsonConverter(typeof(ConfigRefConverter<BattlePassConfig>))]
        public string BattlePass;

        [JsonProperty(PropertyName = "18")]
        public AccessType Accesses;

        [JsonProperty(PropertyName = "19")]
        public int Permissions;

        [JsonProperty(PropertyName = "20")]
        //[JsonConverter(typeof(ConfigDictionaryConverter<TechnologyConfig, int>))]
        public Dictionary<SpritesQuartersTechnologiesName, int> UnlockedTechnologies;

        [JsonProperty(PropertyName = "21")]
        public int TeamId;

        [JsonProperty(PropertyName = "22")]
        public Dictionary<QuestGroup, int> QuestGroupCurrentChapter;

        [JsonProperty(PropertyName = "23")]
        public bool IsSteamSession;
    }
    public class UserbarConfig : ConfigDictionary<UserbarConfig>, IConfigDisablable
    {
        [JsonConverter(typeof(VisualConverter<AccountEmblem>))]
        public AccountEmblem visual;

        [JsonIgnore]
        public UserbarGroupConfig Group;

        [JsonIgnore]
        public ShopEntryConfig ShopEntry;

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

        //public UserbarConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
    public class UserbarGroupConfig : ConfigDictionary<UserbarGroupConfig>, IConfigDisablable
    {

        public UserbarVisualizationLogic VisualizationLogic;

        [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<UserbarConfig>))]
        public List<UserbarConfig> Userbars;

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

        public static void Initialize()
        {
        }

        //public UserbarGroupConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
    public enum UserbarVisualizationLogic
    {
        Default = 0,
        Ranked = 1
    }
    [Flags]
    public enum AccessType : long
    {
        None = 0L,
        DailyQuests = 2L,
        WeeklyQuests = 4L,
        HardQuests = 8L,
        GamemodeIntercept = 0x10L,
        Medals = 0x20L,
        AccountLevel = 0x40L,
        Userbars = 0x80L,
        Currency = 0x100L,
        Contacts = 0x200L,
        Premium = 0x400L,
        Customization = 0x800L,
        Consumables = 0x1000L,
        GamemodeOnslaughtEasy = 0x2000L,
        GamemodePve = 0x4000L,
        GamemodePvp = 0x8000L,
        GamemodePveHard = 0x10000L,
        Operator = 0x20000L,
        NewbieBuff = 0x40000L,
        FreeXp = 0x80000L,
        GamemodeOnslaughtNormal = 0x100000L,
        GamemodeOnslaughtHard = 0x200000L,
        AllOperators = 0x400000L,
        BattlePass = 0x800000L,
        GamemodeHacking = 0x1000000L,
        Marathon = 0x2000000L,
        GamemodePvPvE = 0x4000000L,
        RankedSeason = 0x8000000L,
        GamemodePvpRanked = 0x10000000L,
        Quarters = 0x20000000L,
        HqStyle = 0x40000000L,
        Expeditions = 0x80000000L,
        GamemodePVPFPP = 0x100000000L,
        GamemodePvPDestruction = 0x200000000L,
        OnboardingQuests = 0x400000000L,
        OrderableQuests = 0x800000000L,
        InfiniteQuest = 0x1000000000L,
        Prestige = 0x2000000000L,
        GamemodePveStorm = 0x4000000000L,
        CommonCause = 0x8000000000L,
        LootBoxQuests = 0x10000000000L,
        GamemodePvPvE2 = 0x20000000000L,
        All = 0x3FFFFFBFFFEL
    }
}
