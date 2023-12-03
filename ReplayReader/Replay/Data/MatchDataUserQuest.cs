using Newtonsoft.Json;
using ReplayReader.Replay.Data.Replay.Configs;
using ReplayReader.Replay.Data.Replay.Entitys;

namespace ReplayReader.Replay.Data.Replay.Data
{
    public class MatchDataUserQuest
    {
        [JsonProperty(PropertyName = "0")]
        public string Id;

        [JsonProperty(PropertyName = "1")]
        [JsonConverter(typeof(ConfigRefConverter<QuestConfig>))]
        public QuestConfig Config;

        [JsonProperty(PropertyName = "2")]
        public float[] Counters;

        [JsonProperty(PropertyName = "3")]
        public QuestGroup Group;

        [JsonProperty(PropertyName = "4")]
        public int ChapterIdx;

        [JsonProperty(PropertyName = "5")]
        public bool IsPremium;
    }
}
