using Newtonsoft.Json;


namespace ReplayReader.Replay.Data.Replay.Entitys
{
    public class ConfigBase
    {
        [JsonIgnore]
        public string IdKey;

        [JsonIgnore]
        public int IdIndex;
    }
}
