
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReplayReader.Replay
{
    public interface IConfigPeriodic
    {
        DateTime StartDate { get; set; }

        DateTime EndDate { get; set; }
    }
    public class BattlePassConfig : ConfigDictionary<BattlePassConfig>, IConfigPeriodic
    {
        [JsonProperty(Order = -4)]
        public string Visual;

        [JsonProperty(Order = -5)]
        public bool EnabledInGame;

        public int HardToXpConversionRate;

        public int AdditionalXpPercent;

        public string Group;

        public List<BattlePassStepConfig> Steps;

        [JsonIgnore]
        public ShopEntryConfig ShopEntry;

        [JsonProperty(Order = -3)]
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

        [JsonProperty(Order = -2)]
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

        public DateTime GalleryStartDate
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

        public DateTime GalleryActiveStartDate
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

        [JsonIgnore]
        public int LastStepXp => 0;

        public BattlePassStepConfig GetStepById(string stepId)
        {
            return null;
        }

        public bool IsGallery(DateTime time)
        {
            return false;
        }

        public bool IsGalleryActive(DateTime time)
        {
            return false;
        }

        public bool IsCurrent(DateTime time)
        {
            return false;
        }

        public int GetLevel(int xp)
        {
            return 0;
        }

        public static BattlePassConfig Get(DateTime date)
        {
            return null;
        }

        public int GetZeroStepCount()
        {
            return 0;
        }

        //public BattlePassConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
    public class BattlePassStepConfig
    {
        public string Id;

        public int Xp;

        public Reward EveryoneReward;

        public Reward BattlePassReward;
    }
}
