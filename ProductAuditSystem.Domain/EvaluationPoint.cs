using ProductAuditSystem.Domain.Common;

namespace ProductAuditSystem.Domain;

public class EvaluationPoint : BaseEntity
{
    public string Contenido { get; set; } = string.Empty;
    public int StatusPuntoID { get; set; }
    public int PreguntaId { get; set; }
    public virtual Question? Pregunta { get; set; }
    public virtual PointStatus? StatusPunto { get; set; }
}
