using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using GOD_Assistant.DB_Entity;
using GOD_Assistant.PeriodicalActives;

namespace GOD_Assistant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //Test();
            //while (true) 
            //{ 
            //    Thread.Sleep(100);
            //}
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            IHostBuilder builder = Host.CreateDefaultBuilder(args);
            IHostBuilder confBuilder = builder.ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Worker>();
            });
            return confBuilder;
        }
       private static void Test()
       {
            FileWatcher.UnSubscribeToFile();

            //string repPath = "C:\\Users\\Volos\\AppData\\LocalLow\\1CGS\\Caliber\\Replays\\a6773a0d-11f1-4d2f-8cf6-a45f9c5c09eb_2061_2023-10-12_23-02-35_11073_000.bytes";
            //string content = File.ReadAllText(repPath);

            //content.Substring(0, content.Length - repPath.Length);
            //Console.WriteLine();
        }
    }
}
