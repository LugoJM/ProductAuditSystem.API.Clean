
using MediatR;
using ProductAuditSystem.Application.Responses;

namespace ProductAuditSystem.Application.Features.PointStatus.Commands.CreatePointStatus;

public class CommandCreateStatusPoint : IRequest<BaseCommandResponse>
{
    public string Status { get; set; } = string.Empty;
}
