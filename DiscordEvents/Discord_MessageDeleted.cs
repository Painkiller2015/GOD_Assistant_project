using DSharpPlus.EventArgs;
using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOD_Assistant.DB_Entities;
using Microsoft.EntityFrameworkCore;

namespace GOD_Assistant.Events
{
    static partial class DiscordEvents
    {
        public static async Task Discord_MessageDeleted(DiscordClient sender, MessageDeleteEventArgs e)
        {
            using DBContext dBContext = new();
            var a = dBContext.ChatLogs.FirstOrDefaultAsync(x => x.DiscordId == e.Message.Id);
            if (a != null)
            {
                if (!e.Message.Author.IsBot)
                {
                    a.Result.IsDeleted = true;
                    await dBContext.SaveChangesAsync();
                }                
            }
        }
    }
}
