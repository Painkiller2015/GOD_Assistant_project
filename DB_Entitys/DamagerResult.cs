using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOD_Assistant.DB_Entities;
[PrimaryKey(nameof(Id))]
public partial class DamagerResult
{
    public int Id { get; set; }
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    [ForeignKey(nameof(Attachment))]
    public int AttachmentId { get; set; }

    public double Damage { get; set; }

    public int Deaths { get; set; }

    public int RoundsCount { get; set; }

    public bool Win { get; set; }

    public double FinalScore { get; set; }

    public virtual Attachment Attachment { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
