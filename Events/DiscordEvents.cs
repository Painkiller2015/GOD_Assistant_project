using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using GOD_Assistant.DB_Entity;
using GOD_Assistant.DiscordObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOD_Assistant.Events
{
    internal static class DiscordEvents
    {
        public static async Task Discord_MessageCreated(DiscordClient sender, MessageCreateEventArgs e)
        {
           // await LogMessageCreate(e);
        }

        public static async Task Discord_MessageDeleted(DiscordClient sender, MessageDeleteEventArgs e)
        {

        }
        public static async Task Discord_VoiceStateUpdate(DiscordClient sender, VoiceStateUpdateEventArgs e)
        {

        }
        public static async Task Discord_ClientErrored(DiscordClient sender, ClientErrorEventArgs e)
        {
            Console.WriteLine(e.Exception); 
        }
        
        public static async Task Discord_ComponentInteractionCreated(DiscordClient sender, ComponentInteractionCreateEventArgs e)
        {
            //switch (e.Id)
            //{

            //}
        }
        public static async Task Discord_ModalSubmitted(DiscordClient sender, ModalSubmitEventArgs e)
        {
            await e.Interaction.CreateResponseAsync(InteractionResponseType.DeferredMessageUpdate);
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
                UserId = connect.Users.Single(user => user.discordID == e.Author.Id).Id,
                Timestamp = e.Message.Timestamp.Ticks
            };
            if (e.Message.Attachments.Any())
            {
                logRecord.HasAttachment = true;
                foreach (var attachment in e.Message.Attachments)
                {
                    connect.Attachments.Add
                        (
                            new Attachment()
                            {
                                MessageId = e.Message.Id,
                                Type = attachment.MediaType,
                                URL = attachment.Url
                            }
                        );
                }
            }
            await connect.AddAsync(logRecord);
            await connect.SaveChangesAsync();
        }
    }
}
