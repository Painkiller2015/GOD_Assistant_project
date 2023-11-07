using Newtonsoft.Json;
using ReplayReader.Replay.Data;
using System.Timers;

namespace ReplayReader
{
    public class ReplayReader
    {
        public ReplayReader(string replayPath)
        {
            ReadReplay(replayPath);
        }
        private MatchData replay;
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
                string resultData = binaryReader.ReadString();

                replay = JsonConvert.DeserializeObject<MatchData>(matchData);



                //    //Console.WriteLine(TopDamage(replay, "Painkiller2015", OperatorClass.a, GameMode.hacking));
                //    //Console.WriteLine(TopDamage(replay, "Painkiller2015", OperatorClass.g, GameMode.hacking));
                //    //Console.WriteLine(TopDamage(replay, "Painkiller2015", OperatorClass.m, GameMode.hacking));
                //    //Console.WriteLine(TopDamage(replay, "Painkiller2015", OperatorClass.s, GameMode.hacking));
                //};
            }

            //режим
            //В этом конкурсе побеждать можно не более 3х раз подряд, после перерыв на 1 неделю.
            //Прием результатов до среды 00:00 по МСК. 

            //вынести коэфициент смерти

            //(Нанесённый урон - (количество смертей * 50)) / количество раундов = результат.
            //    static string TopDamage(Replay replay, string playerNickName, OperatorClass @class, GameMode gameMode)
            //    {
            //        string mode = replay.Log.Data.GameMode;

            //        if (mode == gameMode.ToString())
            //        {
            //            int playerIndex = Array.FindIndex(replay.Log.Data.Players, player => player.NickName == playerNickName);
            //            if (replay.Log.Users[playerIndex].WinRoundCount == replay.Log.Users.Max(user => user.WinRoundCount))
            //            {
            //                if (replay.Log.Data.Players[playerIndex].Operator.OperatorName[^1].ToString() == @class.ToString())  //добавить выбор из доступных
            //                {
            //                    double damage = replay.Log.Users[playerIndex].DamageDealt;
            //                    int death = replay.Log.Users[playerIndex].Deaths;
            //                    int roundsCount = replay.Log.Rounds.Length;

            //                    return ((damage - (death * 50)) / roundsCount).ToString();
            //                }
            //            }
            //        }
            //        //записать куда-нибудь discord_id _ nickName _ score _ damage _ death _ round
            //        return "";
            //    }
            //    enum OperatorClass
            //    {
            //        a,
            //        g,
            //        m,
            //        s
            //    }
            //    enum GameMode
            //    {
            //        pvehard,
            //        hacking
            //    }
            //}
        }
        public List<string> GetPlayersName()
        {
            return replay.Users.Select(el => el.Nickname).ToList();
        }
    }
}

