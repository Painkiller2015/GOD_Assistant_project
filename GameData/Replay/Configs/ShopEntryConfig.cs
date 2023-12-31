﻿using Newtonsoft.Json;
using GameData.Replay.Data.Replay.Data;
using GameData.Replay.Data.Replay.Entitys;
using GameData.Replay.Data.Replay.Utils;
using System.Runtime.CompilerServices;

namespace GameData.Replay.Data.Replay.Configs
{
    public class ShopEntryConfig : ConfigDictionary<ShopEntryConfig>, IConfigDisablable
    {
        public static readonly Dictionary<(ShopItemType itemType, string itemId, CardConfig linkedCardId), ShopEntryConfig> ShopEntryByKey;

        public static readonly Dictionary<ShopItemType, HashSet<ShopEntryConfig>> ShopEntriesByType;

        public static readonly Dictionary<(ShopItemType, string), HashSet<CardConfig>> LinkedCardsByTypeAndItem;

        public static readonly Dictionary<CardConfig, int> CardLegendarySkinsCount;

        public static readonly Dictionary<ShopEntryConfig, ShopEntryConfig> SkinSetBySkinGroup;

        public static readonly Dictionary<ShopEntryKey, int> ShopEntryIndices;

        public static readonly Dictionary<ShopEntryConfig, List<ShopEntryConfig>> ShopChildsByEntry;

        public static readonly Dictionary<CurrencyConfig, ShopEntryConfig> PieceEntryByCurrency;

        public static readonly Dictionary<ShopEntryConfig, List<ShopEntryConfig>> ShopPacksByEntry;

        public static readonly Dictionary<PlayerRole, List<(ShopEntryConfig, CardConfig)>> CardsShopEntryByRole;

        public static readonly HashSet<ShopEntryConfig> ShopEntriesWithPieces;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool fullProgression;


        public ShopItemQuality quality;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]

        public ShopItemCategory category;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int order;

        public string itemId;

        [JsonConverter(typeof(ConfigRefConverter<CardConfig>))]
        [JsonProperty("linkedCardId")]
        public CardConfig linkedCard;

        [JsonConverter(typeof(ConfigDictionaryConverter<ShopEntryConfig, int>))]
        public Dictionary<ShopEntryConfig, int> childShopItems;


        public ShopItemType itemType;

        public readonly List<Money> price;

        public List<Money> oldPrice;

        public Money refundSum;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Money refundSite;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Money pieces;

        public bool sendNotificationFromPieces;

        public int amount;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int buyLimit;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool suspendable;


        public AcquisitionType acquisitionType;

        public string acquisitionVisual;

        public bool allowPartialPurchase;

        public bool workInProgress;

        public string shopUrl;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool lootBoxBuyLimit;

        [JsonIgnore]
        public CardConfig itemCard;

        [JsonIgnore]
        public ConsumableConfig itemConsumable;

        [JsonIgnore]
        public CurrencyConfig itemCurrency;

        [JsonIgnore]
        public BattlePassConfig itemBattlePassKey;

        [JsonIgnore]
        public UserbarConfig itemUserbar;

        [JsonIgnore]
        public CustomAnimationConfig itemAnim;

        [JsonIgnore]
        public SkinGroupConfig itemSkinGroup;

        [JsonIgnore]
        public QuartersBoosterConfig itemQuartersBooster;

        //[JsonIgnore]
        //public LootBoxConfig itemLootBox;

        [JsonIgnore]
        public HqStyleConfig itemHqStyle;

        [JsonIgnore]
        public FireworkConfig itemFirework;

        [JsonIgnore]
        public QuestConfig itemQuest;

        [JsonIgnore]
        public long PriceSortWeight;

        [JsonIgnore]
        public bool HasPieces => false;

        [JsonIgnore]
        public long GetPriceSortWeightWithSale => 0L;

        [JsonIgnore]
        public bool IsCanBuyWithSale => false;

        [JsonIgnore]
        public List<Money> GetPriceWithSale => null;

        [JsonIgnore]
        public Money DefaultPrice => null;

        [JsonIgnore]
        public bool HasPrice => false;

        [JsonIgnore]
        public bool FromPieces => false;

        [JsonFilter(~JsonFilterFlags.Client)]
        [JsonProperty("enabledInGame")]
        public bool EnabledInGame;

        [JsonIgnore]
        public bool LootBoxBuyLimit => false;

        bool IConfigDisablable.EnabledInGame { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    public enum AcquisitionType
    {
        Shop = 0,
        Reward = 1,
        WebShop = 2,
        HiddenUntilAcquired = 3,
        SpecialOffer = 4,
        DefaultAvailable = 5
    }
    [GenerateJs]
    public enum ShopItemCategory
    {
        None = 0,
        Shop = 1,
        Rewards = 2,
        Flags = 3,
        Exclusive = 4,
        Collections = 5,
        Special = 6,
        Events = 7,
        Competitive = 8
    }
    public enum ShopItemType
    {
        None = 0,
        Card = 1,
        Currency = 2,
        Consumable = 3,
        Premium = 4,
        Userbar = 5,
        Anim = 6,
        SkinGroup = 7,
        SkinSet = 8,
        ShopItemDeactivator = 9,
        ExtraPremium = 10,
        Pack = 11,
        FreeXp = 12,
        BattlePassKey = 13,
        MarathonTicket = 14,
        LootBox = 15,
        QuartersBooster = 16,
        HqStyle = 17,
        Firework = 18,
        Quest = 19,
        CardPrestige = 20
    }
    public enum ShopItemQuality
    {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3,
        Epic = 4,
        Legendary = 5
    }
    public class QuartersBoosterConfig : ConfigDictionary<QuartersBoosterConfig>
    {
        public string Visual;

        public TimeSpan Duration;

        [JsonIgnore]
        public ShopEntryConfig ShopEntry;

        //public QuartersBoosterConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
    public class HqStyleConfig : ConfigDictionary<HqStyleConfig>, IConfigDisablable
    {

        public Visuals.HqStyles Visual;

        [JsonIgnore]
        public ShopEntryConfig ShopEntry;

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

        //public HqStyleConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
    public class FireworkConfig : ConfigDictionary<FireworkConfig>, IConfigDisablable
    {
        public string Visual;

        [JsonConverter(typeof(ConfigRefConverter<FireworkGroupConfig>))]
        public FireworkGroupConfig Group;

        public bool ShowNickname;

        [JsonIgnore]
        public ShopEntryConfig ShopEntry;

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

        //public FireworkConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
    public enum FireworkLogic
    {
        Default = 0,
        Custom = 1
    }
    public class FireworkGroupConfig : ConfigDictionary<FireworkGroupConfig>
    {

        public FireworkLogic Logic;

        public int EmptyDelaySeconds;

        public int GapSeconds;

        public int UpdateSeconds;

        [JsonIgnore]
        public List<FireworkConfig> Fireworks;

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

        public DateTime StartDate
        {
            [CompilerGenerated]
            get
            {
                return default;
            }
            [CompilerGenerated]
            set
            {
            }
        }

        public DateTime EndDate
        {
            [CompilerGenerated]
            get
            {
                return default;
            }
            [CompilerGenerated]
            set
            {
            }
        }

        public static void Initialize()
        {
        }

        //public FireworkGroupConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
}
