using Newtonsoft.Json;


namespace GameData.Replay.Data.Replay.Entitys
{
    public class ConfigBase
    {
        [JsonIgnore]
        public string IdKey;

        [JsonIgnore]
        public int IdIndex;
    }
}
