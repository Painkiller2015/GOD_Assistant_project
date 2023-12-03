using DSharpPlus;
using DSharpPlus.EventArgs;
using GOD_Assistant.OnStar;

namespace GOD_Assistant.Events
{
    static partial class DiscordEvents
    {
        public static async Task Discord_GuildDownloadCompleted(DiscordClient sender, GuildDownloadCompletedEventArgs e)
        {
            SyncData syncData = new();
            syncData.SyncGuildsAsync(e.Guilds.Values.ToList());
        }
    }
}
