using ProductAuditSystem.Domain.Common;

namespace ProductAuditSystem.Domain;

public class AuditUser : BaseEntity
{
    public int UsuarioID { get; set; }
    public int AuditoriaID { get; set; }

    public virtual User? Usuario { get; set; }
    public virtual Audit? Auditoria { get; set; }
}