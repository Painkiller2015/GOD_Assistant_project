using GameData.Replay.Data.Replay.Log;


namespace GameData.Replay.Data
{
    public class BattleResult
    {
        public BattleLog Log;

        public List<BattleResultUser> Users;

        public bool GameModesBanEnabled;

        public bool PlayerReportsEnabled;
    }

}
