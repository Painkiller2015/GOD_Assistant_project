
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ReplayReader.Replay.Entitys;

namespace ReplayReader.Replay.Configs
{
    public class AbilityConfig : ConfigDictionary<AbilityConfig>, IConfigRaw
    {
        public static readonly List<SlotType> SlotsFull;

        public static readonly List<SlotType> SlotsCompact;

        [JsonProperty(PropertyName = "client_name")]
        [JsonConverter(typeof(VisualConverter<Visuals.Ability>), new object[] { false })]
        public Visuals.Ability Visual;

        [JsonProperty(PropertyName = "drop_item")]
        [JsonConverter(typeof(ConfigRefConverter<DropItemConfig>))]
        public DropItemConfig DropItem;

        [JsonProperty(PropertyName = "wrong_placement_drop_item")]
        [JsonConverter(typeof(ConfigRefConverter<DropItemConfig>))]
        public DropItemConfig WrongPlacementDropItem;

        [JsonProperty(PropertyName = "meta_data")]
        public AbilityConfigMeta Meta;

        [JsonIgnore]
        public JObject Raw
        {
            [CompilerGenerated]
            get
            {
                return null;
            }
            [CompilerGenerated]
            set
            {
            }
        }

        public static void Initialize()
        {
        }

        //public AbilityConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
    public interface IConfigRaw
    {
        JObject Raw { get; set; }
    }
    public class AbilityConfigMeta
    {
        [JsonProperty(PropertyName = "upgrades", ItemConverterType = typeof(ConfigRefConverter<UpgradeConfig>))]
        public List<UpgradeConfig> Upgrades;

        [JsonProperty(PropertyName = "modifiers")]
        public ParamModifierConfig Modifiers;
    }
}

