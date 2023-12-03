using Newtonsoft.Json;
using ReplayReader.Replay.Data.Replay.Log;


namespace ReplayReader.Replay.Data
{
    public class BattleResult
    {
        public BattleLog Log;

        public List<BattleResultUser> Users;

        public bool GameModesBanEnabled;

        public bool PlayerReportsEnabled;
    }

}
