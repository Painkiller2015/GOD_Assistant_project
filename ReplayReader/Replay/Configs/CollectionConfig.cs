
using Newtonsoft.Json;
using ReplayReader.Replay.Data.Replay.Entitys;
using System.Runtime.CompilerServices;

namespace ReplayReader.Replay.Data.Replay.Configs
{
    public class CollectionConfig : ConfigDictionary<CollectionConfig>, IConfigDisablable
    {
        [JsonConverter(typeof(VisualConverter<Visuals.CardCollection>))]
        public Visuals.CardCollection visual;

        public bool recruits;

        public bool CanPrestige;

        public bool HideProgress;

        [JsonIgnore]
        public readonly List<CardConfig> cards;

        [JsonIgnore]
        public static readonly List<CollectionConfig> SortingCollections;

        [JsonIgnore]
        public static readonly Dictionary<CollectionConfig, Visuals.Countries> CountryByCollections;

        [JsonProperty("enabledInGame")]
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

        [JsonIgnore]
        public Visuals.Countries Country
        {
            [CompilerGenerated]
            get
            {
                return default;
            }
            [CompilerGenerated]
            private set
            {
            }
        }

        public static void Initialize()
        {
        }

        public static void Prepare()
        {
        }

        //public CollectionConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
}
