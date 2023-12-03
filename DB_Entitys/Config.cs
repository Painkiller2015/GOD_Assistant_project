using Microsoft.EntityFrameworkCore;

namespace GOD_Assistant.DB_Entities;
[PrimaryKey(nameof(Name))]
public partial class Config
{
    public string Name { get; set; } = null!;
    public string? Value { get; set; }
}
