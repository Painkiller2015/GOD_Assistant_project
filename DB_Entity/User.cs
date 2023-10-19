using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOD_Assistant.DB_Entity
{
    [PrimaryKey("Id")]
    [Table("Users")]
    public class User
    {        
        public int Id { get; set; }
        public ulong DiscordID { get; set; }
        public string DiscordName { get; set; }
        public string? GameName { get; set; }
        public User(ulong discordID, string discordName, string? gameName = null)
        {
            DiscordID = discordID;
            DiscordName = discordName;
            GameName = gameName;
        }
    }
}
