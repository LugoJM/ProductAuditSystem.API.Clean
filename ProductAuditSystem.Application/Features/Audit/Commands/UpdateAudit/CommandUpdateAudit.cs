using MediatR;
using ProductAuditSystem.Application.Common.SharedDTOs;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.Audit.Commands.UpdateAudit;

public class CommandUpdateAudit : IRequest<BaseCommandResponse>
{
    public int Id { get; set; }
    public DateTime? Fecha_Auditoria { get; set; }
    public List<UserDTO>? Auditores { get; set; }
    public OEM_DTO? OEM { get; set; }
    public string Programa { get; set; } = string.Empty;
    public string Comentarios { get; set; } = string.Empty;
    public AuditStatusDTO? Status { get; set; }
}

