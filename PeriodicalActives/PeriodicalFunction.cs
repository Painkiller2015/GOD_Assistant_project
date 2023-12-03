using System.Text.Json;
using System.Timers;

namespace GOD_Assistant.PeriodicalActives
{
    public class PeriodicalFunction
    {
        public PeriodicalFunctionParam Parameters { get; private set; }
        public PeriodicalFunction()
        {

        }
        public void GetSettings()
        {
            string json = File.ReadAllText(@"PeriodicalActives/PeriodicalActivesSettings.json");
            Parameters = JsonSerializer.Deserialize<PeriodicalFunctionParam>(json);
        }
        private void TimeEvent(object? sender, ElapsedEventArgs e)
        {
        }
        public static void SubscribeToFile(Action action, string FileName)
        {
            Console.WriteLine("i sub");
        }
        public static void UnSubscribeToFile(Action action, string FileName)
        {
            Console.WriteLine("i UnSub");
        }
        public class PeriodicalFunctionParam
        {
            public int OfficerDayOfMounth { get; set; }
            public int DamagerDayOfWeek { get; set; }
            public int Voice_Chat_ActivDayOfMounth { get; set; }
        }
    }
}
