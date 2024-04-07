using ProductAuditSystem.Domain.Common;

namespace ProductAuditSystem.Domain;

public class AuditQuestion : BaseEntity
{
    public int PreguntaID { get; set; }
    public int AuditoriaID { get; set; }

    public virtual Question? Pregunta { get; set; }
    public virtual Audit? Auditoria { get; set; }
}

