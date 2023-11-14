using DSharpPlus.EventArgs;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using GOD_Assistant.DB_Entity;

namespace GOD_Assistant.Events
{
    static partial class DiscordEvents
    {
        public static async Task Discord_ComponentInteractionCreated(DiscordClient sender, ComponentInteractionCreateEventArgs e)
        {
            ulong idRequester = 419063111165804555; //DEBUG

            switch (e.Interaction.Data.CustomId.Split('_')[0])
            {
                case ("RequestPanel"):
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
                        DBConnect DB = new();
                        switch (e.Interaction.Data.CustomId.Split('_')[1])
                        {
                            case "AcceptRequest":
                                if (e.Guild.Members.First(user => user.Value.Id == idRequester).Value.Roles.Any(role => role.Name == "Рекрут" || role.Name == "Участник"))
                                {
                                    discordEmbed = new DiscordEmbedBuilder().WithTitle("Уже участник!")
                                                                                         .WithColor(DiscordColor.Yellow)
                                                                                         .Build();
                                }
                                else
                                {
                                    DiscordMember newClanMember = e.Guild.Members.First(user => user.Value.Id == idRequester).Value;
                                    await newClanMember.GrantRoleAsync(e.Guild.Roles.Values.First(role => role.Name == "Рекрут"));

                                    
                                    User newUser = DB.Users.First(user => user.DiscordID == idRequester);
                                    newUser.JoinedInClan = DateTime.Now;

                                  

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

                                DiscordMember refClanMember = e.Guild.Members.First(user => user.Value.Id == idRequester).Value;
                                await refClanMember.SendMessageAsync($"Здравствуйте! \n К сожалению ваша заявка отклонена по причине: \n {response.Result.Values["NegativeReason"]}");

                                break;
                            default:
                                await e.Interaction.CreateResponseAsync(InteractionResponseType.DeferredMessageUpdate);
                            break;
                        }
                    }
                    break;
            }
            DiscordMessageBuilder builder = new(e.Message);
            builder.ClearComponents();

            await e.Message.ModifyAsync(builder);
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
