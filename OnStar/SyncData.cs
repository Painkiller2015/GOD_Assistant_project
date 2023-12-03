using DSharpPlus.Entities;
using GOD_Assistant.DB_Entities;

namespace GOD_Assistant.OnStar
{
    public class SyncData()
    {
        private readonly DBContext db = new();
        public async Task SyncGuildsAsync(List<DiscordGuild> guilds)
        {
            AddNewUsers(guilds);
            await db.SaveChangesAsync();
            await db.DisposeAsync();
        }

        private void AddNewUsers(List<DiscordGuild> guilds)
        {
            List<User> newUsers = new();
            List<User> preUsers;

            foreach (var guild in guilds)
            {
                preUsers = db.Users
                  .Where(u => u.Guilds.Any(g => g.DiscordId == guild.Id))
                  .ToList();

                foreach (var member in guild.Members)
                {
                    if (member.Value.IsBot)
                        continue;

                    User newUser = new()
                    {
                        DiscordId = member.Value.Id,
                        ServerName = member.Value.DisplayName,
                    };
                    if (!newUsers.Any(user => user.DiscordId == newUser.DiscordId))
                    {
                        if (!preUsers.Any(user => user.DiscordId == newUser.DiscordId))
                        {
                            Guild? currGuild = db.Guilds.FirstOrDefault(g => g.DiscordId == guild.Id);
                            if (currGuild == null)
                            {
                                currGuild = new();
                                currGuild.DiscordId = guild.Id;
                                currGuild.Name = guild.Name;
                            }
                            newUser.Guilds.Add(currGuild);

                            newUsers.Add(newUser);
                            db.Users.Add(newUser);
                        }
                    }
                }
            }
        }

    }
}
