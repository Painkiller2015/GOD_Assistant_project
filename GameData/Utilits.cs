using GOD_Assistant;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameData.Replay.Data.Replay.Entitys.Visuals;
using GameMode = GameData.Replay.Data.Replay.Entitys.Visuals.GameMode;

namespace GameData
{
    public class Utilits
    {
        public static void InsertOperators()
        {
            Dictionary<string, string> source_ru_names = InitDictionary(@"C:\Users\Volos\source\repos\GameData\Dictionaries\NameOperators.json");

            using GameInfoContext context = new();

            foreach (HumanCoreConfigType item in Enum.GetValues(typeof(HumanCoreConfigType)))
            {
                int operId = (int)item;
                string operSourceName = Enum.GetName(item);

                if (!context.Operators.Any(oper => oper.Id == operId && oper.SourseName == operSourceName))
                {
                    Operator? operById = context.Operators.FirstOrDefault(oper => oper.Id == operId);

                    if (operById != null)
                    {
                        operById.SourseName = operSourceName;
                        operById.RuName = source_ru_names[operById.SourseName];
                        continue;
                    }

                    Operator? operBySourceName = context.Operators.FirstOrDefault(oper => oper.SourseName == operSourceName);

                    if (operBySourceName != null)
                    {
                        operBySourceName.Id = operId;
                        continue;
                    }

                    Operator newOperator = new(operId, operSourceName, source_ru_names[operSourceName]);


                    context.Operators.Add(newOperator);
                }
            }
            context.SaveChangesAsync();
        }
        //public static void InsertGameModes()
        //{
        //    Dictionary<string, string> GameModesNames = InitDictionary(@"C:\Users\Volos\source\repos\GameData\Dictionaries\TypesMission.json");

        //    using GameInfoContext context = new();

        //    foreach (GameMode item in Enum.GetValues(typeof(GameMode)))
        //    {
        //        int operId = (int)item;
        //        string operSourceName = Enum.GetName(item);

        //        if (!context.Operators.Any(oper => oper.Id == operId && oper.SourseName == operSourceName))
        //        {
        //            Operator? operById = context.GameModes.FirstOrDefault(oper => oper.Id == operId);

        //            if (operById != null)
        //            {
        //                operById.SourseName = operSourceName;
        //                operById.RuName = GameModesNames[operById.SourseName];
        //                continue;
        //            }

        //            Operator? operBySourceName = context.Operators.FirstOrDefault(oper => oper.SourseName == operSourceName);

        //            if (operBySourceName != null)
        //            {
        //                operBySourceName.Id = operId;
        //                continue;
        //            }

        //            Operator newOperator = new(operId, operSourceName, GameModesNames[operSourceName]);
        //            context.Operators.Add(newOperator);
        //        }
        //    }
        //    context.SaveChangesAsync();
        //}

        private static Dictionary<string, string> InitDictionary(string jsonPath)
        {
            Dictionary<string, string> source_ru_names = new();
            string jsonData = File.ReadAllText(jsonPath);
            source_ru_names = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(jsonData);

            foreach (var item in source_ru_names)
            {
                if (item.Value == null)
                {
                    continue;
                }
                if (item.Value[0] == '_')
                {
                    source_ru_names[item.Key] = item.Value.Substring(1);
                }
            }

            return source_ru_names;
        }
    }

}
