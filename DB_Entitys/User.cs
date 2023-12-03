using Microsoft.EntityFrameworkCore;

namespace GOD_Assistant.DB_Entities;
[PrimaryKey(nameof(Id))]
public partial class User
{
    public int Id { get; set; }

    public ulong DiscordId { get; set; }

    public string? DiscordName { get; set; }

    public string ServerName { get; set; } = null!;

    public DateTime? Birthday { get; set; }

    public DateTime? JoinedInClan { get; set; }

    public int? LeaveCount { get; set; }

    public virtual ICollection<ChatLog> ChatLogs { get; set; } = new List<ChatLog>();

    public virtual ICollection<ClanApplication> ClanApplicationRespondents { get; set; } = new List<ClanApplication>();

    public virtual ICollection<ClanApplication> ClanApplicationUsers { get; set; } = new List<ClanApplication>();

    public virtual ICollection<DamagerResult> DamagerResults { get; set; } = new List<DamagerResult>();

    public virtual ICollection<GameAccount> GameAccounts { get; set; } = new List<GameAccount>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public virtual ICollection<VoiceLog> VoiceLogs { get; set; } = new List<VoiceLog>();

    public virtual ICollection<Guild> Guilds { get; set; } = new List<Guild>();

    public virtual ICollection<GameAccount> Players { get; set; } = new List<GameAccount>();
}
