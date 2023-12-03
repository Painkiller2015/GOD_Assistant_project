using Microsoft.EntityFrameworkCore;

namespace GOD_Assistant.DB_Entities;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<ChatLog> ChatLogs { get; set; }

    public virtual DbSet<ClanApplication> ClanApplications { get; set; }

    public virtual DbSet<Config> Configs { get; set; }

    public virtual DbSet<DamagerResult> DamagerResults { get; set; }

    public virtual DbSet<GameAccount> GameAccounts { get; set; }

    public virtual DbSet<Guild> Guilds { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<VoiceLog> VoiceLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\Volos\\OneDrive\\Desktop\\GA\\GOD.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasIndex(e => e.Id, "IX_Attachments_Id").IsUnique();

            entity.Property(e => e.Url).HasColumnName("URL");
        });

        modelBuilder.Entity<ChatLog>(entity =>
        {
            entity.ToTable("ChatLog");

            entity.HasIndex(e => e.Id, "IX_ChatLog_Id").IsUnique();

            entity.HasOne(d => d.Guild).WithMany(p => p.ChatLogs).HasForeignKey(d => d.GuildId);

            entity.HasOne(d => d.User).WithMany(p => p.ChatLogs).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<ClanApplication>(entity =>
        {
            entity.ToTable("ClanApplication");

            entity.HasIndex(e => e.Id, "IX_ClanApplication_Id").IsUnique();

            entity.Property(e => e.Answer).HasDefaultValueSql("0");

            entity.HasOne(d => d.Respondent).WithMany(p => p.ClanApplicationRespondents)
                .HasForeignKey(d => d.RespondentId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.User).WithMany(p => p.ClanApplicationUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade); ;
        });

        modelBuilder.Entity<Config>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("Config");
        });

        modelBuilder.Entity<DamagerResult>(entity =>
        {
            entity.HasIndex(e => e.Id, "IX_DamagerResults_Id").IsUnique();

            entity.HasOne(d => d.Attachment).WithMany(p => p.DamagerResults).HasForeignKey(d => d.AttachmentId);

            entity.HasOne(d => d.User).WithMany(p => p.DamagerResults).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<GameAccount>(entity =>
        {
            entity.ToTable("GameAccount");

            entity.HasIndex(e => e.Id, "IX_GameAccount_Id").IsUnique();

            entity.HasOne(d => d.User).WithMany(p => p.GameAccounts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasIndex(e => e.Id, "IX_Roles_Id").IsUnique();
            entity.HasOne(d => d.Guild).WithMany(p => p.Roles)
               .HasForeignKey(d => d.GuildId)
               .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<Guild>(entity =>
        {
            entity.HasIndex(e => e.Id, "IX_Guilds_Id").IsUnique();

            entity.Property(e => e.DiscordId).HasColumnName("DiscordId");

        });
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Id, "IX_Users_Id").IsUnique();

            entity.Property(e => e.DiscordId).HasColumnName("DiscordID");
            entity.Property(e => e.LeaveCount).HasDefaultValue(0);

            entity.HasMany(d => d.Guilds).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "GuildUser",
                    r => r.HasOne<Guild>().WithMany().HasForeignKey("GuildId").HasPrincipalKey(x => x.Id),
                    l => l.HasOne<User>().WithMany().HasForeignKey("UserId").HasPrincipalKey(x => x.Id),
                    j =>
                    {
                        j.HasKey("UserId", "GuildId");
                        j.ToTable("Guild_User");
                    });

            entity.HasMany(d => d.Players).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserPlayer",
                    r => r.HasOne<GameAccount>().WithMany().HasForeignKey("PlayerId").HasPrincipalKey(x => x.UserId),
                    l => l.HasOne<User>().WithMany().HasForeignKey("UserId").HasPrincipalKey(x => x.Id),
                    j =>
                    {
                        j.HasKey("UserId", "PlayerId");
                        j.ToTable("User_Player");
                    });
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.RoleId, e.UserId, e.GuildId });

            entity.ToTable("User_Role");

            entity.HasOne(d => d.Guild).WithMany(p => p.UserRoles).HasForeignKey(d => d.GuildId);

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles).HasForeignKey(d => d.RoleId);

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<VoiceLog>(entity =>
        {
            entity.ToTable("VoiceLog");

            entity.HasIndex(e => e.Id, "IX_VoiceLog_Id").IsUnique();

            entity.HasOne(d => d.Guild).WithMany(p => p.VoiceLogs).HasForeignKey(d => d.GuildId);

            entity.HasOne(d => d.User).WithMany(p => p.VoiceLogs).HasForeignKey(d => d.UserId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
