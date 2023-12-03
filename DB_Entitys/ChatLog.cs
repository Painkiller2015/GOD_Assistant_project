using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOD_Assistant.DB_Entities;
[PrimaryKey(nameof(Id))]
public partial class ChatLog
{
    public int Id { get; set; }
    [ForeignKey(nameof(Guild))]
    public int GuildId { get; set; }
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }

    public ulong DiscordId { get; set; }

    public DateTime Date { get; set; }

    public ulong ChatDiscordId { get; set; }

    public bool IsDeleted { get; set; }

    public bool HasAttachment { get; set; }

    public string? Message { get; set; }

    public virtual Guild Guild { get; set; } = null!;

    public virtual User User { get; set; } = null!;

}
