
using Newtonsoft.Json;
using ReplayReader.Replay.Data.Replay.Configs;

namespace ReplayReader.Replay.Data.Replay.Entitys
{
    public class Money
    {
        public Dictionary<CurrencyGroup, int> values;

        public static Money Zero => null;

        [JsonIgnore]
        public int Soft;

        [JsonIgnore]
        public int Hard;

        [JsonIgnore]
        public int FreeXp;

        [JsonIgnore]
        public int RefundToken;

        [JsonIgnore]
        public int CardLevelSwitchToken;

        [JsonIgnore]
        public bool HasPrice => false;

        [JsonIgnore]
        public bool HasValues => false;
    }
}
