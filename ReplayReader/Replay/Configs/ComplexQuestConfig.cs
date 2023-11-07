
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReplayReader.Replay.Entitys;

namespace ReplayReader.Replay.Configs
{
    public class ComplexQuestConfig : ConfigDictionary<ComplexQuestConfig>, IRotatableQuest
    {
        public string visual;

        public int order;

        [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<ComplexQuestChapterConfig>))]
        public List<ComplexQuestChapterConfig> chapters;

        public bool enabled;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
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
