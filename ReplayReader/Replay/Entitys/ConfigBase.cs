using Newtonsoft.Json;


namespace ReplayReader.Replay.Entitys
{
    public class ConfigBase
    {
        [JsonIgnore]
        public string IdKey;

        [JsonIgnore]
        public int IdIndex;
    }
}
