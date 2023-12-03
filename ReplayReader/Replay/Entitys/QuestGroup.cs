using ReplayReader.Replay.Data.Replay.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayReader.Replay.Data.Replay.Entitys
{
    [GenerateJs]
    public enum QuestGroup
    {
        Common = 0,
        Daily = 1,
        Infinite = 2,
        Hard = 3,
        Weekly = 4,
        Prologue = 5,
        Onboarding = 6,
        Orderable = 7,
        SteamAchievement = 8,
        LootBox = 9,
        CommonCause = 10
    }
}
