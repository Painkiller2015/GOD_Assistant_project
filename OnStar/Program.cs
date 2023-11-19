using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using GOD_Assistant.PeriodicalActives;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using GOD_Assistant.DB_Entities;
using System;

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
            using DBContext db = new();
                var users = db.Users
                .Where(u => u.Guilds.Any(g => g.DiscordId == 1009863965569974392))
                .ToList(); 
            Console.WriteLine(users.Count);

            //    //419063111165804555 //1161632736835031111
            //    var a = dbContext.Guilds.Single(guild => guild.DiscordId == 1161632736835031111);
            //    var b = dbContext.Users.Where(user => user.DiscordId == 419063111165804555).ToList();
            //    ChatLog logRecord = new()
            //    {
            //        DiscordId = 1175580474769424465,
            //        GuildId = dbContext.Guilds.Single(guild => guild.DiscordId == 1161632736835031111).Id,
            //        ChatDiscordId = 1173895608365482074,
            //        Message = ";lk",
            //        UserId = dbContext.Users.Single(user => user.DiscordId == 419063111165804555).Id,
            //        //Timestamp = 638359654898060000
            //    };
            //    dbContext.Add(logRecord);
            //    dbContext.SaveChanges();
            //}


            //using (DBContext dbContext = new())
            //{
            //    VoiceLog voice = new()
            //    {
            //        DateTimeEnter = DateTime.Now,
            //        Guild = dbContext.Guilds.First(gu => gu.DiscordId == 1161632736835031111),
            //        User = dbContext.Users.First(us => us.DiscordId == 419063111165804555),
            //    };

            //    dbContext.VoiceLogs.Add(voice);
            //    dbContext.SaveChangesAsync();
            //}
            //DBContext context = new();
            //ClanApplication application = new();
            //application.UserId = context.Users.First(user => user.DiscordId == 419063111165804555).Id;
            //application.Type = (int?)ClanApplication.ApplicationType.JoinedToClan;
            //application.ApplicationDate = DateTime.Now;
            //context.ClanApplications.Add(application);
            //context.SaveChanges();
            //DBContext dbContext = new DBContext();
            //List<User> users = new List<User>();
            //User newUser = new()
            //{
            //    DiscordId = 312312312312,
            //    ServerName = "321312312312",
            //};
            //if (!users.Any(user => user.DiscordId == newUser.DiscordId))
            //{
            //    if (!dbContext.Users.Any(user => user.DiscordId == newUser.DiscordId)) //тут померло
            //    {
            //        users.Add(newUser);
            //        dbContext.Users.Add(newUser);
            //        dbContext.SaveChanges();
            //    }
            //}
            //string? par1 = null;
            //string? name = null;
            //name ??= par1;

            //Console.ReadLine();
            // ReplayReader.ReplayReader rr = new(@"C:\Users\volosnikov\Downloads\c3e9feb5-3e27-45ae-ad22-04c98767dbb4_2686_2023-10-12_22-55-24_11073_000 (1).bytes");

            //rr.GetAllText();

            //DBContext db = new();

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
