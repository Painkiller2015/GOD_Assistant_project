
using Newtonsoft.Json;
using ReplayReader.Replay.Data.Replay.Entitys;
using System.Runtime.CompilerServices;

namespace ReplayReader.Replay.Data.Replay.Configs
{
    public class CardProgressLineConfig : ConfigDictionary<CardProgressLineConfig>, IConfigDisablable
    {
        public class Level
        {
            public int Xp;

            public Money Price;

            [JsonIgnore]
            public Level PrevLevel;

            [JsonIgnore]
            public int StartXp;

            [JsonIgnore]
            public int EndXp => 0;
        }

        public List<Level> levels;

        [JsonIgnore]
        public int LastLevelXp;

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

        public static void Initialize()
        {
        }

        //public CardProgressLineConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
}
