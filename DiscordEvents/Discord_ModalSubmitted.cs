using DSharpPlus.EventArgs;
using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Entities;

namespace GOD_Assistant.Events
{
    static partial class DiscordEvents
    {
        public static async Task Discord_ModalSubmitted(DiscordClient sender, ModalSubmitEventArgs e)
        {
            if (e.Interaction.Data.CustomId == "ClanApplicationPanel")
            {
                DiscordInteractionResponseBuilder res = new();
                DiscordEmbed discordEmbed = new DiscordEmbedBuilder().WithTitle("Спасибо за заявку!")
                                                                     .WithDescription("Мы рассмотрим её и свяжется с вами в ближайшее время!")
                                                                     .WithThumbnail("https://img.freepik.com/free-photo/close-up-on-adorable-kitten-indoors_23-2150782415.jpg")
                                                                     .WithColor(DiscordColor.Green).Build();
                res.AddEmbed(discordEmbed).AsEphemeral();
                await e.Interaction.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, res);
            }
            else
            {
                await e.Interaction.CreateResponseAsync(InteractionResponseType.DeferredMessageUpdate);
            }
        }
    }
}
