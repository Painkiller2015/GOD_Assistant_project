using DSharpPlus;
using DSharpPlus.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

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
