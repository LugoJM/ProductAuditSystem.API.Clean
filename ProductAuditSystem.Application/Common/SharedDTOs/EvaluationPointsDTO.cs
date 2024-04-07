using ProductAuditSystem.Application.Features.Question.Classes;

namespace ProductAuditSystem.Application.Common.SharedDTOs;

public class EvaluationPointsDTO
{
    public string Comments { get; set; } = string.Empty;
    public List<EvaluationPointDTO>? Points { get; set; }
}
