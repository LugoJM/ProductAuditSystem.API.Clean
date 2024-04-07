
namespace ProductAuditSystem.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime? FechaCreacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
}
