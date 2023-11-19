using DSharpPlus.EventArgs;
using DSharpPlus;
using GOD_Assistant.DB_Entities;

namespace GOD_Assistant.Events
{
    static partial class DiscordEvents
    {
        public static async Task Discord_MessageCreated(DiscordClient sender, MessageCreateEventArgs e)
        {
            await LogMessageCreate(e);

        }
        private static async Task LogMessageCreate(MessageCreateEventArgs e)
        {
            DBContext connect = new();

            if (e.Message.Author.IsBot)
                return;

            ChatLog logRecord = new()
            {
                DiscordId = e.Message.Id,
                Guild = connect.Guilds.First(guild => guild.DiscordId == e.Guild.Id),
                ChatDiscordId = e.Message.ChannelId,
                Message = e.Message.Content,
                User = connect.Users.First(user => user.DiscordId == e.Author.Id),
                Date = e.Message.Timestamp.DateTime
            };            
            if (e.Message.Attachments.Any())
            {
                logRecord.HasAttachment = true;                                                              
                foreach (var attachment in e.Message.Attachments)
                {
                    Attachment attach = new()
                    {
                        Type = attachment.MediaType,
                        Url = attachment.Url,
                        MessageId = logRecord.Id
                    };  
                    await connect.Attachments.AddAsync(attach);
                }
            }
            connect.Add(logRecord);
            await connect.SaveChangesAsync();
        }
    }
}