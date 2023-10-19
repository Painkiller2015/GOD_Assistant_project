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
    [Table("Roles")]
    public class Role
    {
        public int Id { get; set; }
        public ulong DiscordID { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public Role(ulong discordID, string name, bool isAdmin)
        {
            DiscordID = discordID;
            Name = name;
            IsAdmin = isAdmin;
        }
    }
}
