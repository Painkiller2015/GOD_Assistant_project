
using Newtonsoft.Json;
using GameData.Replay.Data.Replay.Configs;
using GameData.Replay.Data.Replay.Entitys;

namespace GameData.Replay.Data.Replay.Data
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CardData
    {
        [JsonProperty(PropertyName = "0")]
        public int Id;

        [JsonConverter(typeof(ConfigRefConverter<CardConfig>))]
        [JsonProperty(PropertyName = "1")]
        public CardConfig Config;

        [JsonProperty(PropertyName = "2")]
        public bool Owned;

        [JsonProperty(PropertyName = "3")]
        public bool Active;

        [JsonProperty(PropertyName = "4")]
        public int Experience;

        [JsonProperty(PropertyName = "5")]
        public int TechnologiesSlotsCount;

        [JsonProperty(PropertyName = "6")]
        public long LevelSlotsUnlocked;

        [JsonProperty(PropertyName = "7")]
        public long UpgradesSelected;

        [JsonProperty(PropertyName = "8", ItemConverterType = typeof(ConfigRefConverter<SkinGroupConfig>))]
        public SkinGroupConfig[] SkinGroupsOwned;

        [JsonProperty(PropertyName = "9", ItemConverterType = typeof(ConfigRefConverter<SkinGroupConfig>))]
        public SkinGroupConfig[] SkinGroupsSelected;

        [JsonProperty(PropertyName = "10", ItemConverterType = typeof(ConfigRefConverter<CustomAnimationConfig>))]
        public CustomAnimationConfig[] EmotionsOwned;

        [JsonProperty(PropertyName = "11", ItemConverterType = typeof(ConfigRefConverter<CustomAnimationConfig>))]
        public CustomAnimationConfig[] EmotionsSelected;

        [JsonProperty(PropertyName = "12", ItemConverterType = typeof(ConfigRefConverter<CustomAnimationConfig>))]
        public CustomAnimationConfig[] FatalitiesOwned;

        [JsonConverter(typeof(ConfigRefConverter<CustomAnimationConfig>))]
        [JsonProperty(PropertyName = "13")]
        public CustomAnimationConfig FatalitySelected;

        [JsonProperty(PropertyName = "14", ItemConverterType = typeof(ConfigRefConverter<ConsumableConfig>))]
        public ConsumableConfig[] ConsumablesSelected;

        [JsonProperty(PropertyName = "15", ItemConverterType = typeof(ConfigRefConverter<TechnologyConfig>))]
        public TechnologyConfig[] TechnologiesSelected;

        [JsonProperty(PropertyName = "16")]
        public List<string> MarkedEntities;

        [JsonProperty(PropertyName = "17")]
        public DataDetail Details;

        [JsonProperty(PropertyName = "18")]
        public int UnlockedLevel;

        [JsonProperty(PropertyName = "19")]
        public int PrestigeLevel;

        [JsonProperty(PropertyName = "20")]
        public int PrestigeExp;
    }
    public class CustomAnimationConfig : ConfigDictionary<CustomAnimationConfig>
    {
        public static readonly CustomAnimationType[] Types;

        public static readonly List<CustomAnimationConfig> FatalityList;

        public static readonly List<CustomAnimationConfig> EmotionsList;

        public string visual;


        public CustomAnimationType type;

        [JsonIgnore]
        public List<CardConfig> CompatibleCards;

        [JsonIgnore]
        public ShopEntryConfig ShopEntry;

        public static void Initialize()
        {
        }

        //public CustomAnimationConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
    public enum DataDetail
    {
        Full = 0,
        Battle = 1,
        Light = 2
    }
    public enum CustomAnimationType
    {
        None = 0,
        Greeting = 1,
        KillingBlow = 2
    }
}
