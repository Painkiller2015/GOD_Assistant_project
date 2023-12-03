using Newtonsoft.Json;
using GameData.Replay.Data;

namespace ReplayReader
{
    public class ReplayReader
    {
        public ReplayReader(string replayPath)
        {
            ReadReplay(replayPath);
        }
        private BattleResult replay;
        void ReadReplay(string replayPath)
        {

            using (BinaryReader binaryReader = new(File.OpenRead(replayPath)))
            {
                int replayVersion = binaryReader.ReadInt32();
                string sharedVersion = binaryReader.ReadString();
                string buildVersion = binaryReader.ReadString();
                string matchData = binaryReader.ReadString();
                long playerId = binaryReader.ReadInt64();        //чей репл
                long startTick = binaryReader.ReadInt64();
                long EndTick = binaryReader.ReadInt64();
                int size = binaryReader.ReadInt32();
                string fullData = binaryReader.ReadString();

                replay = JsonConvert.DeserializeObject<BattleResult>(fullData);
            }
        }
    }
}

