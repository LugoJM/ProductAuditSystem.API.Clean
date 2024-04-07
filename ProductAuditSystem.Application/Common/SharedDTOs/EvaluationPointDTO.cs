namespace ProductAuditSystem.Application.Common.SharedDTOs;

public class EvaluationPointDTO
{
    public int idPunto { get; set; }
    public string Contenido { get; set; } = string.Empty;
    public PointStatusDTO? PointStatus { get; set; }
}
