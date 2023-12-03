using DSharpPlus;
using DSharpPlus.EventArgs;
using GOD_Assistant.DB_Entities;

namespace GOD_Assistant.Events
{
    static partial class DiscordEvents
    {
        public static async Task Discord_VoiceStateUpdate(DiscordClient sender, VoiceStateUpdateEventArgs e)
        {
            if (e.Before == null)
            {
                using (DBContext dbContext = new())
                {
                    VoiceLog voice = new()
                    {
                        DateTimeEnter = DateTime.Now,
                        Guild = dbContext.Guilds.First(gu => gu.DiscordId == e.Guild.Id),
                        User = dbContext.Users.First(us => us.DiscordId == e.User.Id),
                    };

                    dbContext.VoiceLogs.Add(voice);
                    await dbContext.SaveChangesAsync();
                }
            }

            if (e.Channel == null)
            {
                using (DBContext dbContext = new())
                {
                    VoiceLog voice = dbContext.VoiceLogs.OrderBy(field => field.DateTimeEnter).LastOrDefault(vo => vo.User.DiscordId == e.User.Id && vo.Guild.DiscordId == e.Guild.Id);
                    if (voice != null)
                    {
                        voice.DateTimeExit = DateTime.Now;
                        await dbContext.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
