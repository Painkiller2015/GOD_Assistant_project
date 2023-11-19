using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOD_Assistant.DB_Entities;
[PrimaryKey(nameof(Id))]
public partial class VoiceLog
{
    public int Id { get; set; }
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    [ForeignKey(nameof(Guild))]
    public int GuildId { get; set; }

    public DateTime DateTimeEnter { get; set; }

    public DateTime? DateTimeExit { get; set; }

    public virtual Guild Guild { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
