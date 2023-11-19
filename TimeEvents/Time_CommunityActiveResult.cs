using DSharpPlus;
using DSharpPlus.Entities;
using GOD_Assistant.DB_Entities;
using GOD_Assistant.DiscordObject;
using Microsoft.EntityFrameworkCore;
using Polly;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GOD_Assistant.Events
{
    public static partial class TimeEvents
    {
        public static async Task Time_CommunityActiveResultAsync(object? sender, ElapsedEventArgs e, DiscordClient discord)
        {
            
            await PostVoiceWinnersAsync(e.SignalTime, discord.Guilds.First(gu => gu.Value.Id == 1161632736835031111).Value.Channels.First(ch => ch.Value.Id == 1174261401871720448).Value);//придумать что-то нормальное, брать конфиг и тянуть от туда
            await PostChatWinnersAsync(e.SignalTime, discord.Guilds.First(gu => gu.Value.Id == 1161632736835031111).Value.Channels.First(ch => ch.Value.Id == 1174261401871720448).Value);


        }

        private static async Task PostVoiceWinnersAsync(DateTime eventTime, DiscordChannel channel)
        {
            using DBContext dBContext = new();

            var voiceLogs = dBContext.VoiceLogs
                .Where(vo => vo.DateTimeEnter.Month == eventTime.Month && vo.DateTimeExit.HasValue)
                .GroupBy(x => x.User)
                .Select(g => new { userName = g.Key.ServerName,  ticks = g.Sum(x => x.DateTimeExit.Value.Ticks - x.DateTimeEnter.Ticks)})
                .OrderByDescending(ord => ord.ticks)
                .Take(5)
                .ToDictionary(dlv => dlv.userName, dlv => TimeSpan.FromTicks(dlv.ticks).Seconds / 60d);

            await SendLeaderBoardVoiceAsync(voiceLogs, channel);
        }
        private static async Task PostChatWinnersAsync(DateTime eventTime, DiscordChannel channel)
        {
            using DBContext dBContext = new();

            var chatLogs = dBContext.ChatLogs
                .Where(cl => cl.Date.Month == eventTime.Month && !cl.IsDeleted)
                .GroupBy(x => x.User)
                .Select(g => new { userName = g.Key.ServerName, messCount = g.Count() })
                .OrderByDescending(ord => ord.messCount)
            .Take(5)
                .ToDictionary(dlv => dlv.userName, dlv => dlv.messCount);

            await SendLeaderBoardChatAsync(chatLogs, channel);
        }
        private static async Task SendLeaderBoardVoiceAsync(Dictionary<string, double> nameResultDict, DiscordChannel channel) 
        {
            DiscordMessageBuilder messageBuilder = new();            
            DiscordEmbedBuilder embedBuilder = new();

            string leadBoard = "";

            foreach (var user in nameResultDict)
            {
                leadBoard += $"{user.Key}: {Double.Round(user.Value, 2)} ч\n";
            }
            embedBuilder.WithTitle("Самые активные в этом месяце!").WithColor(DiscordColor.Magenta).WithDescription(leadBoard);           
            messageBuilder.WithEmbed(embedBuilder.Build());     

             await channel.SendMessageAsync(messageBuilder);
        }
        private static async Task SendLeaderBoardChatAsync(Dictionary<string, int> nameResultDict, DiscordChannel channel)
        {
            DiscordMessageBuilder messageBuilder = new();
            DiscordEmbedBuilder embedBuilder = new();

            string leadBoard = "";

            foreach (var user in nameResultDict)
            {
                leadBoard += $"{user.Key}: {Double.Round(user.Value, 2)} сообщений\n";
            }
            embedBuilder.WithTitle("Самые активные в этом месяце!").WithColor(DiscordColor.Magenta).WithDescription(leadBoard);
            messageBuilder.WithEmbed(embedBuilder.Build());

            await channel.SendMessageAsync(messageBuilder);
        }
    }
}
