using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

using GOD_Assistant.DiscordObject;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Internal;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace GOD_Assistant.Commands
{
    //[SlashCommandGroup("slash", "slash commands")]
    public class MainCommand : BaseCommandModule
    {
        [Command("T1")]
        public async Task Test1(CommandContext ctx)
        {
            Console.WriteLine("tut1");

            //await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource, null);
            var a = ctx.Member.ModifyAsync(user => user.Nickname = "new");



            //await ctx.Channel.SendMessageAsync(

            //    $"""
            //        you 
            //        {exUser}

            //    """
            //    );
            // await ctx.DeleteResponseAsync();

        }
        [Command("T2")]
        public async Task Test2(CommandContext ctx)
        {
            Console.WriteLine("tut2");

            DiscordMember exUser = ctx.Member;

            string fullInfo = "";

            PropertyInfo[] fields = exUser.GetType().GetProperties();
            await Console.Out.WriteLineAsync(fields.Count().ToString());
            foreach (var item in fields)
            {

                fullInfo += item.Name + " : " + item.GetValue(exUser) + "\n";
            }
            await Console.Out.WriteLineAsync(fullInfo);
            await ctx.Channel.SendMessageAsync(fullInfo);
        }

        [SlashCommandGroup("Prime", "Prime commands")]
        public class SlashCommands : ApplicationCommandModule
        {
            [SlashCommand("test", "Check this")]
            public async Task BeS(InteractionContext ctx)
            {
                await Console.Out.WriteLineAsync("sleshT1");
                await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("Success!"));
            }
            [SlashCommand("officer", "Take officer")]
            public async Task GetBestOfficer(InteractionContext ctx)
            {
                string message = "Самый красивый офицер сегодня :";
                string saxar = "255726604775456770";
                string light = "854631222684155904";

                switch (new Random().Next(0, 2))
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

            //[SlashCommand("test", "Check this")]
            //public async Task BeS(InteractionContext ctx)
            //{
            //    await Console.Out.WriteLineAsync("sleshT1");
            //    await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("Success!"));

            [SlashCommand("Admin", "AdminPanel")]
            //[RequirePermissions(Permissions.Administrator)]
            public async Task RegPanel(InteractionContext ctx)
            {
                DiscordInteractionResponseBuilder builder = CreateRequestPanel();
                await ctx.Interaction.CreateResponseAsync(InteractionResponseType.Modal, builder);
                var response = await ctx.Client.GetInteractivity().WaitForModalAsync("RegPlayer");
                DiscordMessageBuilder message = CreateUserCard(response, ctx);
                await ctx.Channel.SendMessageAsync(message);

                //добавить кнопки да/нет для офицеров и спршаивать причину/когда собес в лс писать что-то
                //добавить в канал вступления сообщение с кнопкой отправки заявки
            }

            private static DiscordMessageBuilder CreateUserCard(InteractivityResult<ModalSubmitEventArgs> response, InteractionContext ctx)
            {
                string messageText =
                   $"""
                   <@{ctx.User.Id}>
                    **Ник в игре:** {response.Result.Values["NickName"]}
                    **Возраст:** {response.Result.Values["age"]}
                    **Информацию о себе:** {response.Result.Values["selfInfo"]}
                    **Откуда узнали о нас:** {response.Result.Values["InfSourse"]}
                    **Цель вступления в клан:** {response.Result.Values["SelfMission"]}
                   """;

                DiscordEmbed embed = new DiscordEmbedBuilder().WithDescription(messageText)
                                                              .WithColor(DiscordColor.Blurple)
                                                              .WithThumbnail(ctx.User.AvatarUrl)
                                                              .Build();

                DiscordMessageBuilder messageBuilder = new();
                messageBuilder.AddEmbed(embed);
                messageBuilder.AddComponents(new DiscordComponent[]
                {
                    new DiscordButtonComponent(ButtonStyle.Success, "AcceptRequest","ᅠᅠᅠᅠᅠᅠᅠᅠ"),//, false, new DiscordComponentEmoji(DiscordEmoji.FromName(ctx.Client, ":white_check_mark:"))),
                    new DiscordButtonComponent(ButtonStyle.Danger, "RefuseRequest","ᅠᅠᅠᅠᅠᅠᅠᅠ")//, false, new DiscordComponentEmoji(DiscordEmoji.FromName(ctx.Client, ":x:"))),
                });
                return messageBuilder;
            }

            private static DiscordInteractionResponseBuilder CreateRequestPanel()
            {
                List<DiscordComponent> elements =
                       [
                           new TextInputComponent("Ник в игре", "NickName", required: true, min_length: 3, max_length: 20),
                           new TextInputComponent("Возраст", "age", required: true),
                           new TextInputComponent("Информацию о себе", "selfInfo"),
                           new TextInputComponent("Откуда узнали о нас", "InfSourse"),
                           new TextInputComponent("Цель вступления в клан", "SelfMission")
                       ];

                DiscordInteractionResponseBuilder builder = new();
                builder.WithCustomId("RegPlayer")
                       .WithTitle("Заявка в клан");

                foreach (var el in elements)
                    builder.AddComponents(el);

                return builder;
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
}