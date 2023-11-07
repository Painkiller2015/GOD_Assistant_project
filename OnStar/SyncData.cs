using DSharpPlus;
using GOD_Assistant.DB_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOD_Assistant.OnStar
{
    public class SyncData(DiscordClient discord)
    {
        private readonly DiscordClient discord = discord;
        private readonly DBConnect db = new();
        public  void SyncAll()
        {
            SyncGuildsUsers();
            SyncGuildsMessages();
        }
        public void SyncGuildsUsers()
        {
            AddNewUsers();

            db.SaveChanges();
        }

        private void AddNewUsers()
        {
            foreach (var guild in discord.Guilds)
            {
                foreach (var member in guild.Value.Members)
                {
                    if (member.Value.IsBot)
                        continue;

                    User newUser = new(member.Key, member.Value.GlobalName, member.Value.DisplayName);

                    if (!db.Users.Any(user => user.DiscordID == newUser.DiscordID))
                    {
                        db.Users.Add(newUser);
                    }
                }
            }
        }

        public void SyncGuildsMessages()
        {

        }
    }
}
