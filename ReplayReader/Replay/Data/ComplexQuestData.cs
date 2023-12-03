using Newtonsoft.Json;
using ReplayReader.Replay.Data.Replay.Configs;
using ReplayReader.Replay.Data.Replay.Entitys;

namespace ReplayReader.Replay.Data.Replay.Data
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ComplexQuestData
    {
        [JsonProperty(PropertyName = "0")]
        public string Id;

        [JsonConverter(typeof(ConfigRefConverter<ComplexQuestConfig>))]
        [JsonProperty(PropertyName = "1")]
        public ComplexQuestConfig Config;
        [JsonProperty(PropertyName = "2")]
        public int CurrentChapterIdx;
        [JsonProperty(PropertyName = "3")]
        public bool Marked;
        [JsonProperty(PropertyName = "4")]
        public List<ComplexQuestDataChapter> ChaptersProgress;
        public bool IsFinished => false;
        public bool AllChaptersPassed => false;
        public ComplexQuestDataChapter CurrentChapter => null;
        public QuestGroup Group => default;
    }
}
