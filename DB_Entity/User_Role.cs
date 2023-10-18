using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOD_Assistant.DB_Entity
{
    [PrimaryKey(nameof(GuildId), nameof(UserId), nameof(RoleId))]
    [Table("User_Role")]
    public class User_Role
    {
        public long GuildId { get; set; }
        public Guild Guild { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long RoleId { get; set; }
        public Role Role { get; set; }
    }
}
