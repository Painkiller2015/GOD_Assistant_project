using Newtonsoft.Json;


namespace ReplayReader.Replay
{
    public class ConfigBase
    {
        [JsonIgnore]
        public string IdKey;

        [JsonIgnore]
        public int IdIndex;
    }
}
