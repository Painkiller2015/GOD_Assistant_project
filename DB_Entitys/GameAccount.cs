using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOD_Assistant.DB_Entities;
[PrimaryKey(nameof(Id))]
public partial class GameAccount
{
    public int Id { get; set; }
    [ForeignKey(nameof(Users))]
    public int? UserId { get; set; }

    public int? PlayerId { get; set; }

    public bool IsApprove { get; set; }

    public string? PlayerName { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
