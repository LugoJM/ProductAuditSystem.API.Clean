
using MediatR;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.AuditStatus.Commands.CommandCreateAuditStatus;

public class CommandCreateAuditStatus : IRequest<BaseCommandResponse>
{
    public string Status { get; set; } = string.Empty;
}
