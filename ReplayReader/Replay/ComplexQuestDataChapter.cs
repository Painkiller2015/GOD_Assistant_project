

using Newtonsoft.Json;

namespace ReplayReader.Replay
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ComplexQuestDataChapter
    {
        [JsonProperty(PropertyName = "0")]
        public string Id;

        [JsonProperty(PropertyName = "1")]
        [JsonConverter(typeof(ConfigRefConverter<ComplexQuestChapterConfig>))]
        public ComplexQuestChapterConfig Config;

        [JsonProperty(PropertyName = "2")]
        public bool IsFinished;

        [JsonProperty(PropertyName = "3")]
        public List<QuestData> QuestsProgress;
    }
   
    [JsonObject(MemberSerialization.OptIn)]
    public class QuestData
    {
        [JsonProperty(PropertyName = "0")]
        public string Id;

        [JsonConverter(typeof(ConfigRefConverter<QuestConfig>))]
        [JsonProperty(PropertyName = "1")]
        public QuestConfig Config;

        [JsonProperty(PropertyName = "2", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsFinished;

        [JsonProperty(PropertyName = "3", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool HadPremiumWhenFinished;

        [JsonProperty(PropertyName = "4")]
        public float[] Counters;

        [JsonProperty(PropertyName = "5", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Marked;

        [JsonProperty(PropertyName = "6", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool RewardReceived;

        [JsonProperty(PropertyName = "7", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Purchased;

        [JsonProperty(PropertyName = "8", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public QuestGroup AssignedGroup;

        [JsonProperty(PropertyName = "9", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsPremium;

        [JsonProperty(PropertyName = "10", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int AccumulatedCompletions;

        [JsonProperty(PropertyName = "11", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Reward AccumulatedReward;

        [JsonIgnore]
        public float Counter => 0f;

        [JsonIgnore]
        public bool IsActive => false;
    }
    public class ComplexQuestChapterConfig : ConfigDictionary<ComplexQuestChapterConfig>
    {
        public string visual;

        [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<QuestGroupConfig>))]
        public List<QuestGroupConfig> groups;

        public Reward reward;

        public int QuestsNeedToBeFinished;

        public bool CanClaimRewardsFromQuests;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Reward BaseQuestRewardOverride;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Reward PremiumQuestRewardOverride;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool RandomizeQuests;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int RandomizedRegularQuestsCount;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int RandomizedPremiumQuestsCount;

        public QuestGroupConfig GetGroupOnDate(DateTime date)
        {
            return null;
        }

        public Reward GetOverriddenReward(bool forPremiumQuest)
        {
            return null;
        }

        //public ComplexQuestChapterConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
    public class QuestGroupConfig : ConfigDictionary<QuestGroupConfig>
    {
        [JsonIgnore]
        public static Dictionary<QuestGroup, List<QuestGroupConfig>> GroupsByType;

        public bool Enabled;

        public bool IsDefault;

        public QuestGroup GroupType;

        [JsonConverter(typeof(ConfigDictionaryConverter<QuestConfig, int>))]
        public Dictionary<QuestConfig, int> Quests;

        [JsonConverter(typeof(ConfigDictionaryConverter<ComplexQuestConfig, int>))]
        public Dictionary<ComplexQuestConfig, int> ComplexQuests;

        public DateTime StartDate;

        public DateTime EndDate;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int StartLevel;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int EndLevel;

        //public QuestGroupConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
}

