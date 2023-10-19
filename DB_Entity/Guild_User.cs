using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOD_Assistant.DB_Entity
{
    [PrimaryKey(nameof(GuildId), nameof(UserId))]
    [Table("Guild_User")]
    public class Guild_User
    {
        public int GuildId { get; set; }
        public List<Guild> Guild { get; set; }
        public int UserId { get; set; }
        public List<User> User { get; set; }
    }
}
