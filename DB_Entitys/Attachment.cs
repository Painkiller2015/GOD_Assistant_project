using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GOD_Assistant.DB_Entities;
[PrimaryKey(nameof(Id))]
public partial class Attachment()
{
    public int Id { get; set; }
    [ForeignKey(nameof(Message))]
    public int MessageId { get; set; }

    public string Type { get; set; }

    public string Url { get; set; }

    public virtual ICollection<DamagerResult> DamagerResults { get; set; } = new List<DamagerResult>();

    public virtual ChatLog Message { get; set; }
}
