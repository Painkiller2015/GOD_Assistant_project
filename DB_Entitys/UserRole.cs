using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOD_Assistant.DB_Entities;
[PrimaryKey(nameof(GuildId), nameof(UserId), nameof(RoleId))]
public partial class UserRole
{
    public int GuildId { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public virtual Guild Guild { get; set; } = null!;
    public virtual Role Role { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
