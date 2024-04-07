
using MediatR;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.AuditStatus.Commands.CommandUpdateAuditStatus;

public class CommandUpdateAuditStatus : IRequest<BaseCommandResponse>
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
}
