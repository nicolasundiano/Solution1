namespace Solution1.Domain.Common;

public class AuditableEntity
{
    public string CreatedBy { get; set; } = null!;
    public DateTimeOffset CreatedAt { get; set; }
    public string ModifiedBy { get; set; } = null!;
    public DateTimeOffset ModifiedAt { get; set; }
}
