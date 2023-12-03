using Newtonsoft.Json;
using GameData.Replay.Data.Replay.Entitys;

namespace GameData.Replay.Data.Replay.Configs
{
    public class ComplexQuestConfig : ConfigDictionary<ComplexQuestConfig>, IRotatableQuest
    {
        public string visual;

        public int order;

        [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<ComplexQuestChapterConfig>))]
        public List<ComplexQuestChapterConfig> chapters;

        public bool enabled;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]

        public QuestGroup group;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool CommonQuestsFromFirstChapter;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool AutoChapterClaimAfterQuestClaim;

        [JsonIgnore]
        public bool IsPrologue => false;

        [JsonIgnore]
        public bool IsCommon => false;

        [JsonIgnore]
        public bool IsHard => false;

        [JsonIgnore]
        public bool IsSteam => false;

        //public ComplexQuestConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
}
