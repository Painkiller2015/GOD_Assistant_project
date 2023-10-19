using System.Timers;
using Microsoft.Extensions.Hosting;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using GOD_Assistant.Commands;
using static GOD_Assistant.Commands.MainCommand;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;
using GOD_Assistant.Config;
using GOD_Assistant.Events;



namespace GOD_Assistant
{
    public class Worker : BackgroundService
    {
        private static DiscordClient discord;
        private CommandsNextExtension commands;
        private InteractivityExtension interactivity;
        private ServiceCollection services;
        public Worker()
        {
            InitDiscordBot();
            SubscribeToDiscordEvents();
            SubscribeToTimeEvents();

            discord.ConnectAsync();                     
        }
        private DiscordClient InitDiscordBot()
        {
            DiscordConfig config = new();
            config.Init();

            InitClient(config.Token);
            InitCommands(config.CommandPrefix);

            return discord;
        }

        private void InitClient(string token)
        {
            discord = new DiscordClient(new DiscordConfiguration
            {
                TokenType = TokenType.Bot,
                Token = token,
                Intents = DiscordIntents.All
            });

            interactivity = discord.UseInteractivity(new InteractivityConfiguration()
            {
                Timeout = TimeSpan.FromSeconds(30)
            });
        }

        private void InitCommands(string prefix)
        {
            commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { prefix }
            });

            commands.RegisterCommands<MainCommand>();
            discord.UseSlashCommands().RegisterCommands<SlashCommands>();
        }
        private void SubscribeToDiscordEvents()
        {
            discord.MessageCreated += DiscordEvents.Discord_MessageCreated;
            discord.MessageDeleted += DiscordEvents.Discord_MessageDeleted;
            discord.VoiceStateUpdated += DiscordEvents.Discord_VoiceStateUpdate;
            discord.ComponentInteractionCreated += DiscordEvents.Discord_ComponentInteractionCreated; // Подключение кнопок
            discord.ClientErrored += DiscordEvents.Discord_ClientErrored;


            discord.ModalSubmitted += DiscordEvents.Discord_ModalSubmitted;

            discord.ComponentInteractionCreated += DiscordEvents.Discord_ComponentInteractionCreated;
            discord.GuildDownloadCompleted += DiscordEvents.Discord_GuildDownloadCompleted;



            //discord.MessageUpdated += _discord_MessageUpdated;
            //discord.MessageReactionAdded += _discord_MessageReactionAdded; // Подключение реакций
            //discord.GuildMemberAdded += _discord_GuildMemberAdded;
            //discord.GuildMemberRemoved += _discord_GuildMemberRemoved;
        }
        private void SubscribeToTimeEvents()
        {
            System.Timers.Timer aTimer = new();
            int interval60Minutes = 60 * 60 * 1000;
            aTimer.Interval = interval60Minutes;

            aTimer.Elapsed += TimeEvents.Time_TopDamageResult;
            aTimer.Elapsed += TimeEvents.Time_CommunityActiveResult;

            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(60 * 60 * 1000, stoppingToken);
            }
        }        

        //private async Task Discord_VoiceStateUpdate(DiscordClient sender, DSharpPlus.EventArgs.VoiceStateUpdateEventArgs e)
        //{


        //    //var a = e.Guild;

        //    //if (e.Channel != default && e.Before != null && e.Before.Channel != null)
        //    //{
        //    //    if (e.Before.Channel != e.Channel)
        //    //    {
        //    //        staticValues.polytest.ChangeChannel(e.User.Id, e.Channel);

        //    //        embed.Description = $"<@{e.User.Id}> перешел из <#{e.Before.Channel.Id}> в <#{e.Channel.Id}>";
        //    //        systemMessage.logText = $"<@{e.User.Id}> перешел из <#{e.Before.Channel.Name}> в <#{e.Channel.Name}>";
        //    //        embed.flagTimesTamp = true;
        //    //        systemMessage.Embeds.Add(embed);
        //    //        await systemMessage.SendMessageWithQ();
        //    //    }

        //    //}
        //    //else if (e.Channel != default)
        //    //{
        //    //    staticValues.polytest.ChangeChannel(e.User.Id, e.Channel);

        //    //    embed.Description = $"<@{e.User.Id}> вошел в канал <#{e.Channel.Id}>";
        //    //    systemMessage.logText = $"<@{e.User.Id}> вошел в канал <#{e.Channel.Name}>";
        //    //    embed.flagTimesTamp = true;
        //    //    systemMessage.Embeds.Add(embed);
        //    //    await systemMessage.SendMessageWithQ();

        //    //}
        //    //else
        //    //{
        //    //    DateTime VoiceJoin = staticValues.polytest.ChangeChannel(e.User.Id, null);

        //    //    embed.Description = $"<@{e.User.Id}> вышел из канала <#{e.Before.Channel.Id}>";
        //    //    if (VoiceJoin != default)
        //    //    {
        //    //        TimeSpan timeInVoice = DateTime.Now.GetMSK() - VoiceJoin;
        //    //        embed.Description += $"\n```В голосовом находился с     {VoiceJoin.GetNormalDate()} {VoiceJoin.Hour}:{VoiceJoin.Minute}\n" +
        //    //                                  $"Общее время в голосовом:    {timeInVoice.Hours}:{timeInVoice.Minutes}```";
        //    //    }
        //    //    systemMessage.logText = $"<@{e.User.Id}> вышел из канала <#{e.Before.Channel.Name}>";
        //    //    embed.flagTimesTamp = true;
        //    //    systemMessage.Embeds.Add(embed);
        //    //    await systemMessage.SendMessageWithQ();
        //    //}
        //}
    }
}
