
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOD_Assistant.DB_Entity
{
    [PrimaryKey("Id")]
    [Table("ChatLog")]
    public class ChatLog
    {
        public int Id { get; set; }
        public int GuildId { get; set; }
        public Guild Guild { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ulong MessageDiscordId { get; set; }
        public long Timestamp { get; set; }
        public ulong ChatDiscordId { get; set; }
        public string  Message { get; set; }
        public bool IsDeleted { get; set; }
        public bool HasAttachment { get; set; }
    }
}
