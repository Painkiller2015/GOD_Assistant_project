using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using GOD_Assistant.DB_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOD_Assistant.OnStar
{
    public class SyncData()//DiscordClient discord
    {
        //private readonly DiscordClient discord = discord;
        private readonly DBConnect db = new();

        public void SyncGuildsUsers(List<DiscordGuild> guilds)
        {
            AddNewUsers(guilds);
            db.SaveChanges();
        }

        private void AddNewUsers(List<DiscordGuild> guildsId)
        {
            List<User> newUsers = new();
            foreach (var guild in guildsId)
            {
                foreach (var member in guild.Members)
                {
                    if (member.Value.IsBot)
                        continue;

                    User newUser = new()
                    {
                        DiscordID = member.Value.Id,
                        DiscordName = member.Value.GlobalName,
                        ServerName = member.Value.DisplayName,
                    };
                    if (!newUsers.Any(user => user.DiscordID == newUser.DiscordID))
                    {                        
                        if (!db.Users.Any(user => user.DiscordID == newUser.DiscordID))
                        {
                            newUsers.Add(newUser);
                            db.Users.Add(newUser);
                        }
                    }
                }
            }
        }
        public void SyncGuildsMessages()
        {

        }
    }
}
