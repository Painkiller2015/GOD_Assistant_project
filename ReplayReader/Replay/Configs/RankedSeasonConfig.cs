using Newtonsoft.Json;
using ReplayReader.Replay.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReplayReader.Replay.Configs
{
    public interface ILadderCapacity
    {
        int PlaceCapacity { get; set; }
    }
    public class RankedSeasonConfig : ConfigDictionary<RankedSeasonConfig>, IConfigPeriodic, ILadderCapacity
    {
        public class Rank
        {
            public string Visual;

            public int PointCount;

            public int PlaceCapacity;

            [JsonIgnore]
            public League League;

            [JsonIgnore]
            public int Index;

            [JsonIgnore]
            public int IndexInLeague;

            [JsonIgnore]
            public int LowerPoints;

            [JsonIgnore]
            public int UpperPoints;
        }

        public class League
        {
            public string Visual;

            //[JsonConverter(typeof(ConfigRefConverter<UserbarConfig>))]
            //  public UserbarConfig Userbar;

            public Reward NumWinsReward;

            public Reward ObtainingReward;

            public Reward RetentionReward;

            public Reward SeasonEndReward;

            public bool IgnoreLostMatches;

            public List<Rank> Ranks;

            public int Midpoint;

            public int ExpirationBattleThreshold;

            public int ExpirationPenaltyPoints;

            [JsonIgnore]
            public int Index;

            [JsonIgnore]
            public int LowerPoints;

            [JsonIgnore]
            public int UpperPoints;

            [JsonIgnore]
            public bool HasExpiration => false;
        }


        public static readonly List<RankedSeasonConfig> SortedList;

        public static readonly DateTime PointExpirationOffset;

        public static readonly TimeSpan PointExpirationInterval;

        // [JsonConverter(typeof(ConfigRefConverter<UserbarConfig>))]
        // public UserbarConfig Userbar;

        [JsonConverter(typeof(ConfigRefConverter<RankedSeasonConfig>))]
        public RankedSeasonConfig PreviousRankedSeason;

        public int NumWinsForReward;

        public int FinishPlaceCount;

        public Reward FinishPlaceReward;

        [JsonProperty(ItemConverterType = typeof(ConfigRefConverter<BattleModeConfig>))]
        public List<BattleModeConfig> GameModes;

        public int CalibrationBattlesCount;

        public List<League> Leagues;

        [JsonIgnore]
        public List<Rank> Ranks;

        [JsonProperty(Order = -3)]
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

        [JsonProperty(Order = -2)]
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

        public int PlaceCapacity
        {
            [CompilerGenerated]
            get
            {
                return 0;
            }
            [CompilerGenerated]
            set
            {
            }
        }

        public static void Initialize()
        {
        }

        public bool IsActive(DateTime time)
        {
            return false;
        }

        public League GetLeagueForPoints(int points)
        {
            return null;
        }

        public Rank GetRankForPoints(int points)
        {
            return null;
        }

        public int GetHalfLeagueRank(int points)
        {
            return 0;
        }

        public void GetPointRangeLeague(int leagueIndex, out int beginPoints, out int endPoints)
        {
            beginPoints = default;
            endPoints = default;
        }

        public void GetBeginPointToRank(int leagueIndex, int rankIndex, out int beginPoints, out int endPoints)
        {
            beginPoints = default;
            endPoints = default;
        }

        public static RankedSeasonConfig GetActiveRankedSeason()
        {
            return null;
        }

        public static RankedSeasonConfig GetActiveOrLastRankedSeason()
        {
            return null;
        }

        public int GetExpirationIteration(DateTime now)
        {
            return 0;
        }

        public int GetActualPoints(int points, int currentIteration, int recentIteration, int recentBattleCount)
        {
            return 0;
        }

        //public RankedSeasonConfig()
        //{
        //    ((ConfigDictionary<>)(object)this)._002Ector();
        //}
    }
    //public static class UserbarConfigExtension
    //{
    //    public static UserbarConfig CalculateUserbar(this UserbarConfig config, RankedSeasonData rankedSeasonData)
    //    {
    //        return null;
    //    }
    //    public static class UserbarConfigExtension
    //    {
    //        public static UserbarConfig CalculateUserbar(this UserbarConfig config, RankedSeasonData rankedSeasonData)
    //        {
    //            return null;
    //        }
    //    }
    //}
}
