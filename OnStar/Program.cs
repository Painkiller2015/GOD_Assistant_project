using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using GOD_Assistant.DB_Entity;
using GOD_Assistant.PeriodicalActives;
using System.Text;

namespace GOD_Assistant.OnStar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Test();
            CreateHostBuilder(args).Build().Run();
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


            // ReplayReader.ReplayReader rr = new(@"C:\Users\volosnikov\Downloads\c3e9feb5-3e27-45ae-ad22-04c98767dbb4_2686_2023-10-12_22-55-24_11073_000 (1).bytes");

            //rr.GetAllText();

            //DBConnect db = new();

            //db.Users.Add(new User(312313, "dadas", "assdad"));
            //db.SaveChanges();
            //FileWatcher.UnSubscribeToFile();

            //string repPath = "C:\\Users\\Volos\\AppData\\LocalLow\\1CGS\\Caliber\\Replays\\a6773a0d-11f1-4d2f-8cf6-a45f9c5c09eb_2061_2023-10-12_23-02-35_11073_000.bytes";
            //string content = File.ReadAllText(repPath);

            //content.Substring(0, content.Length - repPath.Length);
            //Console.WriteLine();           
        }
    }
}
