using RR;
using System.Net.Http.Json;
using System.Text.Json;

namespace ReplayReader
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string replaypath = @"C:\Users\Volos\AppData\LocalLow\1CGS\Caliber\Replays\0bc98b70-afe7-4b54-9e11-89b098cebd39_2061_2023-10-16_22-10-58_11073_000.bytes";

            using (BinaryReader binaryReader = new(File.OpenRead(replaypath)))
            {
                var rv = binaryReader.ReadInt32();
                var sv = binaryReader.ReadString();
                var bv = binaryReader.ReadString();
                var md = binaryReader.ReadString();
                var playerId = binaryReader.ReadInt64();        //чей репл
                var startTick = binaryReader.ReadInt64();
                var EndTick = binaryReader.ReadInt64();
                var size = binaryReader.ReadInt32();
                var resultData = binaryReader.ReadString();

                Replay replay = JsonSerializer.Deserialize<Replay>(resultData);
                Console.WriteLine(TopDamage(replay, "Painkiller2015", OperatorClass.a, GameMode.hacking));
                Console.WriteLine(TopDamage(replay, "Painkiller2015", OperatorClass.g, GameMode.hacking));
                Console.WriteLine(TopDamage(replay, "Painkiller2015", OperatorClass.m, GameMode.hacking));
                Console.WriteLine(TopDamage(replay, "Painkiller2015", OperatorClass.s, GameMode.hacking));
            };
        }

        //режим
        //В этом конкурсе побеждать можно не более 3х раз подряд, после перерыв на 1 неделю.
        //Прием результатов до среды 00:00 по МСК. 

        //вынести коэфициент смерти

        //(Нанесённый урон - (количество смертей * 50)) / количество раундов = результат.
        static string TopDamage(Replay replay, string playerNickName, OperatorClass @class, GameMode gameMode)
        {
            string mode = replay.Log.Data.GameMode;

            if (mode == gameMode.ToString())
            {
                int playerIndex = Array.FindIndex(replay.Log.Data.Players, player => player.NickName == playerNickName);
                if (replay.Log.Users[playerIndex].WinRoundCount == replay.Log.Users.Max(user => user.WinRoundCount))
                {
                    if (replay.Log.Data.Players[playerIndex].Operator.OperatorName[^1].ToString() == @class.ToString())  //добавить выбор из доступных
                    {
                        double damage = replay.Log.Users[playerIndex].DamageDealt;
                        int death = replay.Log.Users[playerIndex].Deaths;
                        int roundsCount = replay.Log.Rounds.Length;

                        return ((damage - (death * 50)) / roundsCount).ToString();
                    }
                }
            }
            //записать куда-нибудь discord_id _ nickName _ score _ damage _ death _ round
            return "";
        }
        enum OperatorClass
        {
            a,
            g,
            m,
            s
        }
        enum GameMode
        {
            pvehard,
            hacking
        }
    }
}

