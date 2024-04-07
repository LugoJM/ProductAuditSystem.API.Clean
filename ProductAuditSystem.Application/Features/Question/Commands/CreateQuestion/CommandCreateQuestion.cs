
using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Features.Question.Classes;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.Question.Commands.CreateQuestion;

public class CommandCreateQuestion : IRequest<BaseCommandResponse>
{
    public string Contenido { get; set; } = string.Empty;
    public int SoporteID { get; set; }
    public string Comentarios { get; set; } = string.Empty;
    public string ComentariosPuntos { get; set; } = string.Empty;
    public string ReferenceDocuments { get; set; } = string.Empty;  
    public QuestionEPs? EvaluationPoints { get; set; }
    public SupportDepartmentDTO? SupportDepartment { get; set; }
    public int AuditId { get; set; }
}
