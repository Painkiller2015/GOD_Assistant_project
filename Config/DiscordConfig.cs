using System.Text.Json;

namespace GOD_Assistant.Config
{
    public class DiscordConfig
    {
        public string Token { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string CommandPrefix { get; set; }
        public void Init()
        {
            string json = File.ReadAllText(@"Config\configNow.json");
            DiscordConfig config = JsonSerializer.Deserialize<DiscordConfig>(json);

            Token = config.Token;
            AppId = config.AppId;
            AppSecret = config.AppSecret;
            CommandPrefix = config.CommandPrefix;
        }
    }

}