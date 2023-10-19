using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOD_Assistant.DB_Entity
{
    public class DBConnect : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<ChatLog> ChatLogs { get; set; } = null!;
        public DbSet<Guild> Guilds { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<User_Role> User_Role { get; set; } = null!;
        public DbSet<Guild_User> Guilds_Users { get; set; } = null!;
        public DbSet<VoiceLog> VoiceLogs { get; set; } = null!;
        public DbSet<Attachment> Attachments { get; set; } = null!;
        public DbSet<DamagerResult> DamagerResults { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=GOD.db");
        }
    }
}
