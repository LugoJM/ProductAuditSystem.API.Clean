using ProductAuditSystem.Domain.Common;

namespace ProductAuditSystem.Domain;

public class PointStatus : BaseEntity
{
    public string Status { get; set; } = string.Empty;
}
