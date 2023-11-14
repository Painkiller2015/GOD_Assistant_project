using DSharpPlus.EventArgs;
using DSharpPlus;
using GOD_Assistant.DB_Entity;

namespace GOD_Assistant.Events
{
    static partial class DiscordEvents
    {
        public static async Task Discord_MessageCreated(DiscordClient sender, MessageCreateEventArgs e)
        {
            //await LogMessageCreate(e);

//            if (sender == null) { }

        }
        private static async Task LogMessageCreate(MessageCreateEventArgs e)
        {
            DBConnect connect = new();
            ChatLog logRecord = new()
            {
                MessageDiscordId = e.Message.Id,
                GuildId = connect.Guilds.Single(guild => guild.DiscordID == e.Guild.Id).Id,
                ChatDiscordId = e.Message.ChannelId,
                Message = e.Message.Content,
                UserId = connect.Users.Single(user => user.DiscordID == e.Author.Id).Id,
                Timestamp = e.Message.Timestamp.Ticks
            };
            if (e.Message.Attachments.Any())
            {
                logRecord.HasAttachment = true;
                foreach (var attachment in e.Message.Attachments)
                {
                    connect.Attachments.Add(new Attachment(e.Message.Id, attachment.MediaType, attachment.Url));
                }
            }
            await connect.AddAsync(logRecord);
            await connect.SaveChangesAsync();
        }
    }
}