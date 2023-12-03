using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOD_Assistant.DB_Entities;
[PrimaryKey(nameof(Id))]
public partial class Role
{
    public int Id { get; set; }

    public ulong DiscordId { get; set; }

    public string Name { get; set; } = null!;
    [ForeignKey(nameof(Guild))]
    public int GuildId { get; set; }
    public virtual Guild Guild { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
