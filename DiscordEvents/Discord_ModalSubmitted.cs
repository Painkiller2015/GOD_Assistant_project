using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;

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
