using DSharpPlus;
using DSharpPlus.EventArgs;

namespace GOD_Assistant.Events
{
    static partial class DiscordEvents
    {
        public static async Task Discord_ClientErrored(DiscordClient sender, ClientErrorEventArgs e)
        {
            Console.WriteLine(e.Exception);
        }
    }
}
