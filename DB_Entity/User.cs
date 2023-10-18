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
        public ulong discordID { get; set; }
        public string discordName { get; set; }
        public string gameName { get; set; }
    }
}
