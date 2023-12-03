using Microsoft.EntityFrameworkCore;

namespace GOD_Assistant.DB_Entities;
[PrimaryKey(nameof(Id))]
public partial class Guild
{
    public int Id { get; set; }

    public ulong DiscordId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<ChatLog> ChatLogs { get; set; } = new List<ChatLog>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public virtual ICollection<VoiceLog> VoiceLogs { get; set; } = new List<VoiceLog>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
