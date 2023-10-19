using DSharpPlus.EventArgs;
using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOD_Assistant.DB_Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;
using Polly;
using System.Xml;

namespace GOD_Assistant.Events
{
    static partial class DiscordEvents
    {
        public static async Task Discord_GuildDownloadCompleted(DiscordClient sender, GuildDownloadCompletedEventArgs e)
        {
            //await UpdateDataBase_Users(sender);
        }
        private static async Task UpdateDataBase_Users(DiscordClient discord)
        {
            DBConnect db = new();

            foreach (var guild in discord.Guilds)
            {
                foreach (var member in guild.Value.Members)
                {
                    User newUser = new (member.Key, member.Value.DisplayName);

                    if (!db.Users.Any(user => user.DiscordID == newUser.DiscordID))
                    {
                        db.Users.Add(newUser);
                        
                    }
                        
                }
            }
            db.SaveChanges();
        }
    }
}
