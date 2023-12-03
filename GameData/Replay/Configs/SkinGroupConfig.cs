using Newtonsoft.Json;
using GameData.Replay.Data.Replay.Entitys;

namespace GameData.Replay.Data.Replay.Configs
{
    public class SkinGroupConfig : ConfigDictionary<SkinGroupConfig>
    {
        public string visual;


        public SkinGroupType type;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string modelVisualPostfix;

        [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<SkinConfig>))]
        public List<SkinConfig> skins;

        [JsonIgnore]
        public ShopEntryConfig ShopEntry;

        //public SkinGroupConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
    public class SkinConfig : ConfigDictionary<SkinConfig>
    {

        public SlotType slot;

        public string visual;

        //public SkinConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
    public enum SkinGroupType
    {
        Head = 0,
        Suit = 1,
        Gear = 2,
        Weapons = 3,
        Model = 4,
        ModelAndWeapons = 5,
        All = 6
    }
}
