
using ProductAuditSystem.Domain.Common;

namespace ProductAuditSystem.Domain;

public class AuditStatus : BaseEntity
{
    public string Status { get; set; } = string.Empty;
}