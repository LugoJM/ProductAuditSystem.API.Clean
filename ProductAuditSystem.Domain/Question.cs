
using ProductAuditSystem.Domain.Common;

namespace ProductAuditSystem.Domain;

public class Question : BaseEntity
{
    public string Contenido { get; set; } = string.Empty;
    public int SoporteID { get; set; }
    public string Comentarios { get; set; } = string.Empty;
    public string ComentariosPuntos { get; set; } = string.Empty;
    public string referenceDocuments { get;set; } = string.Empty;
    public virtual SupportDepartment? Soporte { get; set; }
    public virtual ICollection<EvaluationPoint>? PuntosAEvaluar { get; set; }
    public virtual ICollection<Files>? Files { get; set; }
    public virtual ICollection<AuditQuestion>? AuditoriasPreguntas { get; set; }

}
