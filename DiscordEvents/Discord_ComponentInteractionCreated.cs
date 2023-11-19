using DSharpPlus.EventArgs;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using GOD_Assistant.DB_Entities;
using GOD_Assistant.BotCommands;
using static System.Net.Mime.MediaTypeNames;

namespace GOD_Assistant.Events
{
    static partial class DiscordEvents
    {
        public static async Task Discord_ComponentInteractionCreated(DiscordClient sender, ComponentInteractionCreateEventArgs e)
        {                               
            if (e.Interaction.Data.CustomId.Split('_')[0] == "RequestPanel")
            {
                using DBContext dbContext = new();                                
                ClanApplication application = dbContext.ClanApplications.Find(Convert.ToInt32(e.Message.Embeds[0].Footer.Text));
                dbContext.Entry(application).Reference(app => app.User).Load();
                await WorkWithClanApplication(sender, e, application.User.DiscordId);                
            }
            else if (e.Interaction.Data.CustomId.Split('_')[0] == "SetPlayerAccount")
            {
                using DBContext dbContext = new();
                ClanApplication application = dbContext.ClanApplications.Find(Convert.ToInt32(e.Message.Embeds[0].Footer.Text));
                dbContext.Entry(application).Reference(app => app.User).Load();
                await WorkWithPlayerApplication(sender, e, application.User.DiscordId);
            }
            else if (e.Interaction.Data.CustomId == "ClanApplicationReset")
            {
                await RestoreClanApplication(sender, e);
            }           
        }
     
        private static async Task RestoreClanApplication(DiscordClient sender, ComponentInteractionCreateEventArgs e)
        {
            DiscordMessageBuilder builder = new(e.Message);
            builder.ClearComponents();

            builder.AddComponents(new DiscordComponent[]
            {
                    new DiscordButtonComponent(ButtonStyle.Primary, "RequestPanel_AcceptRequest", "", false, new DiscordComponentEmoji( DiscordEmoji.FromName(sender, ":white_check_mark:"))),
                    new DiscordButtonComponent(ButtonStyle.Primary, "RequestPanel_RefuseRequest", "", false, new DiscordComponentEmoji( DiscordEmoji.FromName(sender, ":x:"))),
            });
            await e.Message.ModifyAsync(builder);
            await e.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage);
        }

        private static async Task WorkWithClanApplication(DiscordClient sender, ComponentInteractionCreateEventArgs e, ulong idRequester)
        {
            DiscordInteractionResponseBuilder res = new();
            DiscordEmbed discordEmbed;
            if (!e.Guild.Members.Any(user => user.Value.Id == idRequester))
            {
                res = new DiscordInteractionResponseBuilder();
                discordEmbed = new DiscordEmbedBuilder().WithTitle("Человек отсутствует на сервере!")
                                                                     .WithColor(DiscordColor.Red)
                                                                     .Build();
                res.AddEmbed(discordEmbed).AsEphemeral();
                await e.Interaction.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, res);

            }
            else
            {
                switch (e.Interaction.Data.CustomId.Split('_')[1])
                {
                    case "AcceptRequest":
                        if (e.Guild.Members.First(user => user.Value.Id == idRequester).Value.Roles.Any(role => role.Name == "Рекрут" || role.Name == "Участник"))
                        {
                            discordEmbed = new DiscordEmbedBuilder().WithTitle("Уже участник!").WithColor(DiscordColor.Yellow).Build();
                        }
                        else
                        {
                            DiscordMember newClanMember = e.Guild.Members.First(user => user.Value.Id == idRequester).Value;
                            await newClanMember.GrantRoleAsync(e.Guild.Roles.Values.First(role => role.Name == "Рекрут"));

                            SaveUserJoinedDate(idRequester);
                            await UpdateApplication(e.Message.Embeds[0].Footer.Text, e.User.Id, true);
                            await RenameUser(e);

                            //string nickName = e.Message.Content.Split(" ").Last();
                            await AddPlayerInUser(e.Message.Embeds[0].Footer.Text, nickName);

                            await e.Guild.Channels.First(c => c.Value.Name == "test3").Value.SendMessageAsync($"<@{newClanMember.Id}>  в общем чате!");                                                                                    
                            await newClanMember.SendMessageAsync("Вы приняты в клан Ghost Of Destruction!");

                            discordEmbed = new DiscordEmbedBuilder().WithTitle("Участник принят!")
                                                                                 .WithColor(DiscordColor.Green)
                                                                                 .Build();
                        }
                        res.AddEmbed(discordEmbed).AsEphemeral();
                        await e.Interaction.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, res);
                        break;
                    case "RefuseRequest":
                        DiscordInteractionResponseBuilder modalBuilder = CreateNegativeAnswer();
                        await e.Interaction.CreateResponseAsync(InteractionResponseType.Modal, modalBuilder);
                        var response = await sender.GetInteractivity().WaitForModalAsync("NegativeReason");

                        await UpdateApplication(e.Message.Embeds[0].Footer.Text, e.User.Id, false, response.Result.Values["NegativeReason"]);

                        DiscordMember refClanMember = e.Guild.Members.First(user => user.Value.Id == idRequester).Value;

                        if (response.Result.Values["NegativeReason"] != null)                        
                            await refClanMember.SendMessageAsync($"Здравствуйте! \n К сожалению ваша заявка на вступление отклонена по причине: \n {response.Result.Values["NegativeReason"]}");                                                
                        break;
                    default:
                        await e.Interaction.CreateResponseAsync(InteractionResponseType.DeferredMessageUpdate);
                        break;
                }
            }
            DiscordMessageBuilder builder = new(e.Message);
            builder.ClearComponents();            
            builder.AddComponents(new DiscordButtonComponent(ButtonStyle.Success, "ClanApplicationReset", "Reset"));
            await e.Message.ModifyAsync(builder);
        }
        private static async Task WorkWithPlayerApplication(DiscordClient sender, ComponentInteractionCreateEventArgs e, ulong idRequester)
        {
            DiscordInteractionResponseBuilder res = new();
            DiscordEmbed discordEmbed;
            switch (e.Interaction.Data.CustomId.Split('_')[1])
            {
                case "AcceptRequest":
                    string nickName = $"{e.Id}"; //e.Message.Content.Split(" ").Last();DEBUG

                    await AddPlayerInUser(e.Message.Embeds[0].Footer.Text, nickName);
                    await UpdateApplication(e.Message.Embeds[0].Footer.Text, e.User.Id, true);                                                   
                    discordEmbed = new DiscordEmbedBuilder().WithTitle("Аккаунт присвоен!")
                                                                            .WithColor(DiscordColor.Green)
                                                                            .Build();
                 
                    res.AddEmbed(discordEmbed).AsEphemeral();
                    await e.Interaction.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, res);
                    break;
                case "RefuseRequest":
                    DiscordInteractionResponseBuilder modalBuilder = CreateNegativeAnswer();
                    await e.Interaction.CreateResponseAsync(InteractionResponseType.Modal, modalBuilder);
                    var response = await sender.GetInteractivity().WaitForModalAsync("NegativeReason");

                    await UpdateApplication(e.Message.Embeds[0].Footer.Text, e.User.Id, false, response.Result.Values["NegativeReason"]);

                    DiscordMember refClanMember = e.Guild.Members.First(user => user.Value.Id == idRequester).Value;
                 
                    if (response.Result.Values["NegativeReason"] != null)
                        await refClanMember.SendMessageAsync($"Здравствуйте! \nК сожалению ваша заявка на привязку игрового аккаунта отклонена по причине: \n{response.Result.Values["NegativeReason"]}");
                    break;
                default:
                    await e.Interaction.CreateResponseAsync(InteractionResponseType.DeferredMessageUpdate);
                    break;
            }
        }

        private static async Task RenameUser(ComponentInteractionCreateEventArgs e)
        {
            using DBContext contex = new();
            ClanApplication app = contex.ClanApplications.First(app => app.Id == Convert.ToInt32(e.Message.Embeds[0].Footer.Text));
            contex.Entry(app).Reference(app => app.User).Load();

            DiscordMember mem = e.Interaction.Guild.Members.First(m => m.Value.Id == app.User.DiscordId).Value;
            await mem.ModifyAsync(u => u.Nickname = $"GOD_{mem.DisplayName}");
        }

        private static void SaveUserJoinedDate(ulong requesterId)
        {
            using DBContext DB = new();
            User newUser = DB.Users.First(user => user.DiscordId == requesterId);
            newUser.JoinedInClan = DateTime.Now;
            DB.SaveChanges();
        }
        private static async Task UpdateApplication(string appId, ulong respondentId, bool answer, string reason = null)
        {
            using DBContext DB = new();            
            ClanApplication app = DB.ClanApplications.First(app => app.Id == Convert.ToInt32(appId));
            app.RespondentId = DB.Users.First(user => user.DiscordId == respondentId).Id;
            app.AnswerDate = DateTime.Now;
            app.Answer = answer;
            app.Reason ??= reason;
                                    
            await DB.SaveChangesAsync();
        }
        private static async Task AddPlayerInUser(string userId, string NickName)
        {

        }

        private static DiscordInteractionResponseBuilder CreateNegativeAnswer()
        {
            List<DiscordComponent> elements =
                   [
                       new TextInputComponent("Причина отказа", "NegativeReason", required: true, style: TextInputStyle.Paragraph)
                   ];

            DiscordInteractionResponseBuilder builder = new();
            builder.WithCustomId("NegativeReason")
                   .WithTitle("Причина Отказа");

            foreach (var el in elements)
                builder.AddComponents(el);

            return builder;
        }
    }
}
