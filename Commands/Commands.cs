using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;
using GOD_Assistant.DB_Entities;
using Microsoft.EntityFrameworkCore;

namespace GOD_Assistant.BotCommands
{
    [SlashCommandGroup("slash", "slash commands")]
    public partial class Commands : BaseCommandModule
    {
        [Command("T1")]
        public async Task Test1(CommandContext ctx)
        {
            Console.WriteLine("tut1");
        }        
    }
    [SlashCommandGroup("GOD", "GOD_SlashCommands")]
    public class SlashCommands : ApplicationCommandModule
    {
        [SlashCommand("Активности", "Лучший офицер")]
        [RequirePermissions(Permissions.Administrator)]
        public async Task GetBestOfficer(InteractionContext ctx)
        {
            string message = "Самый красивый офицер сегодня :";
            string saxar = "255726604775456770";
            string light = "854631222684155904";

            switch (new Random().Next(0, 3))
            {
                case 0:
                    message += $"<@{saxar}>";
                    break;
                case 1:
                    message += $"<@{light}>";
                    break;
                default:
                    message = "Все офицеры вели себя плохо";
                    break;
            }
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent(message));
        }

        [SlashCommand("Заявка", "Подача Заявки в клан")]
        public async Task ClanApplicationPanel(InteractionContext ctx)
        {
            DiscordInteractionResponseBuilder builder = CreateClanApplicationPanel();
            await ctx.Interaction.CreateResponseAsync(InteractionResponseType.Modal, builder);
            var response = await ctx.Client.GetInteractivity().WaitForModalAsync("ClanApplicationPanel");

            ClanApplication application = SaveClanApplication(ctx.User.Id);
            DiscordMessageBuilder message = CreateUserCard(response.Result.Values, ctx, application);
            await message.SendAsync(ctx.Guild.Channels.FirstOrDefault(chat => chat.Value.Name == "test2").Value);
        }

        [SlashCommand("Аккаунт", "Игровой аккаунт")]
        public async Task RegPlayer(InteractionContext ctx)
        {
            DiscordInteractionResponseBuilder builder = CreateClanPlayerNickPanel();
            await ctx.Interaction.CreateResponseAsync(InteractionResponseType.Modal, builder);
            var response = await ctx.Client.GetInteractivity().WaitForModalAsync("ClanPlayerNickPanel");
            ClanApplication application = SaveSetPlayerApplication(ctx.User.Id);

            DiscordMessageBuilder message = CreateAppCard(response.Result.Values, ctx, application);
            await ctx.Channel.SendMessageAsync(message);
        }

        private static DiscordMessageBuilder CreateAppCard(IReadOnlyDictionary<string, string> response, InteractionContext ctx, ClanApplication application)
        {
            string messageText =
               $"""
                   <@{ctx.User.Id}>
                    **Ник в игре:** {response["NickName"]}
                   """;

            DBContext DB = new();
            List<GameAccount> a = DB.Users.AsNoTracking().First(up => up.Id == application.UserId).GameAccounts.ToList();

            if (a != null && a.Count != 0)
            {
                messageText += "\n Ники в других заявках: \n";
                foreach (var app in a)
                {
                    messageText += $"{app.PlayerName}\n";
                }
            }
            DiscordEmbed embed = new DiscordEmbedBuilder().WithDescription(messageText)
                                                          .WithColor(DiscordColor.Blurple)
                                                          .WithThumbnail(ctx.User.AvatarUrl)
                                                          .WithFooter(application.Id.ToString())
                                                          .Build();

            DiscordMessageBuilder messageBuilder = new();
            messageBuilder.AddEmbed(embed);

            //TODO доделать аппрув и глянуть как сообщение отправляется
            messageBuilder.AddComponents(new DiscordComponent[]
            {
                    new DiscordButtonComponent(ButtonStyle.Primary, "SetPlayerAccount_AcceptRequest", "", false, new DiscordComponentEmoji(DiscordEmoji.FromName(ctx.Client, ":white_check_mark:"))),
                    new DiscordButtonComponent(ButtonStyle.Primary, "SetPlayerAccount_RefuseRequest", "", false, new DiscordComponentEmoji(DiscordEmoji.FromName(ctx.Client, ":x:"))),
            });
            return messageBuilder;
        }

        private static DiscordMessageBuilder CreateUserCard(IReadOnlyDictionary<string, string> response, InteractionContext ctx, ClanApplication application)
        {
            string messageText =
               $"""
                   <@{ctx.User.Id}>
                    **Ник в игре:** {response["NickName"]}
                    **Возраст:** {response["age"]}
                    **Информацию о себе:** {response["selfInfo"]}
                    **Откуда узнали о нас:** {response["InfSourse"]}
                    **Цель вступления в клан:** {response["SelfMission"]}
               """;

            DiscordEmbed embed = new DiscordEmbedBuilder().WithDescription(messageText)
                                                          .WithColor(DiscordColor.Blurple)
                                                          .WithThumbnail(ctx.User.AvatarUrl)
                                                          .WithFooter(application.Id.ToString()) //DEBUG
                                                          .Build();

            DiscordMessageBuilder messageBuilder = new();
            messageBuilder.AddEmbed(embed);
            messageBuilder.AddComponents(new DiscordComponent[]
            {
                    new DiscordButtonComponent(ButtonStyle.Primary, "RequestPanel_AcceptRequest", "", false, new DiscordComponentEmoji(DiscordEmoji.FromName(ctx.Client, ":white_check_mark:"))),
                    new DiscordButtonComponent(ButtonStyle.Primary, "RequestPanel_RefuseRequest"," ", false, new DiscordComponentEmoji(DiscordEmoji.FromName(ctx.Client, ":x:"))),
            });
            return messageBuilder;
        }

        private static DiscordInteractionResponseBuilder CreateClanApplicationPanel()
        {
            List<DiscordComponent> elements =
                   [
                        new TextInputComponent("Ник в игре", "NickName", required: true, min_length: 3, max_length: 30),
                        new TextInputComponent("Возраст", "age", required: true),
                        new TextInputComponent("Информацию о себе", "selfInfo"),
                        new TextInputComponent("Откуда узнали о нас", "InfSourse"),
                        new TextInputComponent("Цель вступления в клан", "SelfMission")
                   ];

            DiscordInteractionResponseBuilder builder = new();
            builder.WithCustomId("ClanApplicationPanel")
                   .WithTitle("Заявка в клан");

            foreach (var el in elements)
                builder.AddComponents(el);

            return builder;
        }
        public static DiscordInteractionResponseBuilder CreateClanPlayerNickPanel()
        {
            List<DiscordComponent> elements =
                   [
                       new TextInputComponent("Ник в игре", "NickName", required: true, min_length: 3, max_length: 30),
                       ];

            DiscordInteractionResponseBuilder builder = new();
            builder.WithCustomId("ClanPlayerNickPanel")
                   .WithTitle("Привязать игровой аккаунт");

            foreach (var el in elements)
                builder.AddComponents(el);

            return builder;
        }
        private static ClanApplication SaveClanApplication(ulong AuthorId)
        {
            using DBContext context = new();
            ClanApplication application = new()
            {
                User = context.Users.First(user => user.DiscordId == AuthorId),
                Type = (int?)ClanApplication.ApplicationType.JoinedToClan,
                ApplicationDate = DateTime.Now
            };

            context.ClanApplications.Add(application);
            context.SaveChanges();
            return application;
        }
        private static ClanApplication SaveSetPlayerApplication(ulong AuthorId)
        {
            using DBContext context = new();
            ClanApplication application = new()
            {
                User = context.Users.First(user => user.DiscordId == AuthorId),
                Type = (int?)ClanApplication.ApplicationType.SetPlayerName,
                ApplicationDate = DateTime.Now
            };

            context.ClanApplications.Add(application);
            context.SaveChanges();
            return application;
        }
        //[SlashCommand("Admin", "AdminPanel")]
        ////[RequirePermissions(Permissions.Administrator)]
        //public async Task AdminPanel(InteractionContext ctx)
        //{
        //    DiscordInteractionResponseBuilder builder = CreateRequestPanel();
        //    ///////////
        //    List<DiscordComponent> elements =
        //       [
        //           new TextInputComponent("Ник в игре", "NickName", required: true, min_length: 3, max_length: 20),
        //           //new TextInputComponent("Возраст", "age", required: true),
        //           //new TextInputComponent("Информацию о себе", "selfInfo"),
        //           //                       new TextInputComponent("Откуда узнали о нас", "InfSourse"),
        //           //  new TextInputComponent("Цель вступления в клан", "SelfMission")
        //       ];

        //    var adminPanel = builder.WithTitle("Регистрация")
        //                                                            .WithCustomId("RequestPanel")
        //                                                            .AddComponents(elements);
        //    ///////////////
        //    await ctx.Interaction.CreateResponseAsync(InteractionResponseType.Modal, builder);


        //    InteractivityResult<ModalSubmitEventArgs> result = await ctx.Client.GetInteractivity().WaitForModalAsync("RequestPanel");

        //    //ctx.Channel.SendMessageAsync(result.Result.ToString());
        //}

        //private static DiscordInteractionResponseBuilder CreateRequestPanel()
        //{
        //    List<DiscordComponent> elements =
        //        [
        //            new TextInputComponent("Ник в игре", "NickName", required: true, min_length: 3, max_length: 20),
        //            new TextInputComponent("Возраст", "age", required: true),
        //            new TextInputComponent("Информацию о себе", "selfInfo"),
        //            new TextInputComponent("Откуда узнали о нас", "InfSourse"),
        //            new TextInputComponent("Цель вступления в клан", "SelfMission")
        //        ];

        //    var adminPanel = new DiscordInteractionResponseBuilder().WithTitle("Регистрация")
        //                                                            .WithCustomId("RequestPanel")
        //                                                            .AddComponents(elements);
        //    return adminPanel;
        //}
    }
}