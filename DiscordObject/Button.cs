using DSharpPlus;
using DSharpPlus.Entities;

namespace GOD_Assistant.DiscordObject
{
    public class Button
    {
        public static DiscordButtonComponent CreatActionButton(ButtonStyle style, string customId, string label, bool disabled = false, DiscordComponentEmoji emoji = null)
        {
            return new DiscordButtonComponent(style, GenerateId(), label, disabled, emoji);
        }
        public static DiscordLinkButtonComponent CreatLinkButton(string url, string label, bool disabled = false, DiscordComponentEmoji emoji = null)
        {
            return new DiscordLinkButtonComponent(url, label, disabled, null);
        }
        private static string GenerateId()
        {
            return "b" + Guid.NewGuid().ToString();
        }
    }
}
