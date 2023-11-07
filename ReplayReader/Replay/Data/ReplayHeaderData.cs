using Newtonsoft.Json;


namespace ReplayReader.Replay.Data
{
    public class ReplayHeaderData
    {
        //public int ModelVersion;

        //public string SharedVersion;

        //public string BuildVersionLabel;

        public MatchData MatchData;

        //public long PlayerMetaId;

        //public long StartTick;

        //public long StopTick;

        //public int Size;

        //public string ResultString;

        //public float ReplayDurationSeconds;

        //public DateTime ReplayCreateTime;

        //public float DurationSeconds => 0f;

        //public long DurationTick => 0L;

    }
    public class MatchData
    {
        [JsonProperty(PropertyName = "0")]
        public Guid MatchId { get; set; }

        [JsonProperty(PropertyName = "1")]
        public string Map { get; set; }

        [JsonProperty(PropertyName = "2")]
        public string Mission { get; set; }

        [JsonProperty(PropertyName = "3")]
        public int[] Segments { get; set; }

        [JsonProperty(PropertyName = "4")]
        //[JsonConverter(typeof(ConfigRefConverter<BattleModeConfig>))]
        public string Mode;
        //[JsonProperty(PropertyName = "4")]
        //public string GameMode { get; set; }

        [JsonProperty(PropertyName = "5")]
        public string Route { get; set; }

        [JsonProperty(PropertyName = "6")]
        public string Zone { get; set; }

        [JsonProperty(PropertyName = "7")]
        public List<MatchDataUser> Users;

        [JsonProperty(PropertyName = "8")]
        public string BracketId { get; set; }

        [JsonProperty(PropertyName = "9")]
        public int? BotDifficulty { get; set; }

        [JsonProperty(PropertyName = "10")]
        public int? SquadDifficulty { get; set; }

        [JsonProperty(PropertyName = "11")]
        public string Endpoint { get; set; }

        [JsonProperty(PropertyName = "12")]
        public bool IsCustom { get; set; }

        [JsonProperty(PropertyName = "13")]
        public List<long> SpectatorIds { get; set; }

        [JsonProperty(PropertyName = "14")]
        public List<int> SpectatorDelays { get; set; }

        //[JsonIgnore]
        //public string Body;
    }
}
