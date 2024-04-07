
using ProductAuditSystem.Application.Common.SharedDTOs;

namespace ProductAuditSystem.Application.Features.Question.Classes;

public class QuestionEP
{
    public int IdPunto { get; set; }
    public string Contenido { get; set; } = string.Empty;
    public int StatusPuntoID { get; set; } 
    public int PreguntaId { get; set; }
    public PointStatusDTO? PointStatus { get; set; }
}
