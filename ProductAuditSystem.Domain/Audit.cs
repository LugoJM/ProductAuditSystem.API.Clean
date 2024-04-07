using ProductAuditSystem.Domain.Common;

namespace ProductAuditSystem.Domain;

public class Audit : BaseEntity
{
    public DateTime Fecha_Auditoria { get; set; }
    public int StatusID { get; set; }
    public int OEMID { get; set; }
    public string Programa { get; set; } = string.Empty;
    public string Comentarios { get; set; } = string.Empty;
    public virtual ICollection<AuditQuestion>? AuditoriasPreguntas { get; set; }
    public virtual ICollection<AuditUser>? UsuariosAuditorias { get; set; }
    public virtual AuditStatus? Status { get; set; }
    public virtual OEM? OEM { get; set; }
}
