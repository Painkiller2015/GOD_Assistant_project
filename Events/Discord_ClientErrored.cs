using DSharpPlus.EventArgs;
using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
