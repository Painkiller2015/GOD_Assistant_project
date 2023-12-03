using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOD_Assistant.DB_Entities;
[PrimaryKey(nameof(Id))]
public partial class ClanApplication
{
    public int Id { get; set; }
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }

    public int? Type { get; set; }

    public DateTime ApplicationDate { get; set; }

    public DateTime? AnswerDate { get; set; }
    [ForeignKey(nameof(Respondent))]
    public int? RespondentId { get; set; }

    public bool Answer { get; set; }

    public string? Reason { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual User? Respondent { get; set; }

    public virtual User User { get; set; } = null!;
    public enum ApplicationType
    {
        JoinedToClan,
        SetPlayerName
    }
}
