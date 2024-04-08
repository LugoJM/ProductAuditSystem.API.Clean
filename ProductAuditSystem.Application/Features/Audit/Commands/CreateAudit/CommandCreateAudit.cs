using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.Audit.Commands.CreateAudit;

public class CommandCreateAudit : IRequest<BaseCommandResponse>
{
    public DateTime? Fecha_Auditoria { get; set; }
    public List<UserID>? Auditores { get; set; }
    public OEM_DTO? AuditoriaOEM { get; set; }
    public string Programa { get; set; } = string.Empty;
    public string Comentarios { get; set; } = string.Empty;
    public AuditStatusDTO? AuditoriaStatus { get; set; }
}

public record UserID(int AuditorUserID);