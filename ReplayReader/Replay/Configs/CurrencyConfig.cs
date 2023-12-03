
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ReplayReader.Replay.Data.Replay.Data;
using ReplayReader.Replay.Data.Replay.Entitys;

namespace ReplayReader.Replay.Data.Replay.Configs
{
    public class CurrencyConfig : ConfigDictionary<CurrencyConfig>
    {

        public CurrencyGroup Group;

        public string Visual;

        public string LocaleKey;

        public int Order;

        public int NeedConfirmationWith;

        public bool ShowInTokenExchangeWindow;

        public string ShortageScreenName;

        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public List<AccessType> Accesses;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool ConvertAfterEndDate;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public float ConvertRate;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public float ConvertRatePremium;

        //[JsonConverter(typeof(ConfigRefConverter<CurrencyConfig>))]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public CurrencyConfig ConvertCurrency;

        public static CurrencyConfig hc;

        public static CurrencyConfig sc;

        public static CurrencyConfig tokens;

        public static CurrencyConfig tickets;

        public static CurrencyConfig freexp;

        public static CurrencyConfig Refund;

        public static CurrencyConfig cardLevelSwitchToken;

        public bool EnabledInGame;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime StartDate;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime EndDate;

    }
    public enum CurrencyGroup
    {
        None = 0,
        Event = 1,
        Resource = 2,
        Consumables = 3,
        Boosters = 4,
        Pieces = 5,
        Operators = 6
    }
}
