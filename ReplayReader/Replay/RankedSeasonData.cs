
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayReader.Replay
{
    public class RankedSeasonData
    {
        [JsonConverter(typeof(ConfigRefConverter<RankedSeasonConfig>))]
        [JsonProperty(PropertyName = "0")]
        public RankedSeasonConfig Config;

        [JsonProperty(PropertyName = "1")]
        public int Points;

        [JsonProperty(PropertyName = "2", NullValueHandling = NullValueHandling.Ignore)]
        public int MaxPoints;

        [JsonProperty(PropertyName = "3", NullValueHandling = NullValueHandling.Ignore)]
        public int NumBattles;

        [JsonProperty(PropertyName = "4", NullValueHandling = NullValueHandling.Ignore)]
        public int NumWins;

        [JsonProperty(PropertyName = "5", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime LastRetentionDate;

        [JsonProperty(PropertyName = "6", NullValueHandling = NullValueHandling.Ignore)]
        public List<MatchResult> Calibration;

        public bool IsInRanked => false;

        public bool IsCalibrating => false;
    }
    public enum MatchResult
    {
        None = 0,
        Defeat = 1,
        Victory = 2,
        Draw = 3
    }
}
