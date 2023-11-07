﻿using System.Timers;
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



namespace GOD_Assistant.OnStar
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
    }
}