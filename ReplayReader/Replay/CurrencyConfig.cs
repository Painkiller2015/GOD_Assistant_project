
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReplayReader.Replay
{
    public class CurrencyConfig : ConfigDictionary<CurrencyConfig>, IConfigPeriodic, IConfigDisablable
    {
        [JsonConverter(typeof(StringEnumConverter))]
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

        [JsonConverter(typeof(ConfigRefConverter<CurrencyConfig>))]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public CurrencyConfig ConvertCurrency;

        [JsonIgnore]
        public ShopEntryConfig ShopEntry;

        [JsonIgnore]
        public ConsumableConfig ConsumableConfig;

        public static CurrencyConfig hc
        {
            [CompilerGenerated]
            get
            {
                return null;
            }
            [CompilerGenerated]
            private set
            {
            }
        }

        public static CurrencyConfig sc
        {
            [CompilerGenerated]
            get
            {
                return null;
            }
            [CompilerGenerated]
            private set
            {
            }
        }

        public static CurrencyConfig tokens
        {
            [CompilerGenerated]
            get
            {
                return null;
            }
            [CompilerGenerated]
            private set
            {
            }
        }

        public static CurrencyConfig tickets
        {
            [CompilerGenerated]
            get
            {
                return null;
            }
            [CompilerGenerated]
            private set
            {
            }
        }

        public static CurrencyConfig freexp
        {
            [CompilerGenerated]
            get
            {
                return null;
            }
            [CompilerGenerated]
            private set
            {
            }
        }

        public static CurrencyConfig Refund
        {
            [CompilerGenerated]
            get
            {
                return null;
            }
            [CompilerGenerated]
            private set
            {
            }
        }

        public static CurrencyConfig cardLevelSwitchToken
        {
            [CompilerGenerated]
            get
            {
                return null;
            }
            [CompilerGenerated]
            private set
            {
            }
        }

        public bool EnabledInGame
        {
            [CompilerGenerated]
            get
            {
                return false;
            }
            [CompilerGenerated]
            set
            {
            }
        }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime StartDate
        {
            [CompilerGenerated]
            get
            {
                return default(DateTime);
            }
            [CompilerGenerated]
            set
            {
            }
        }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime EndDate
        {
            [CompilerGenerated]
            get
            {
                return default(DateTime);
            }
            [CompilerGenerated]
            set
            {
            }
        }

        public static void Prepare()
        {
        }

        public bool IsActive(DateTime onDate)
        {
            return false;
        }

        public static bool IsActive(CurrencyConfig currency, DateTime onDate)
        {
            return false;
        }

        public bool IsOutdated(DateTime onDate)
        {
            return false;
        }

        //public CurrencyConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
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
